Imports System.IO
Imports System.Media
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

Imports PowerMonitor

Public Class MainForm

#Region "Property"

	''' <summary>
	''' 対象の電力会社
	''' </summary>
	Friend ReadOnly Property TargetCompany As PowerCompany
		Get
			Return PowerCompany.Companies(Settings.Current.TargetCompanyIndex)
		End Get
	End Property

	''' <summary>
	''' 前回チェック時刻
	''' </summary>
	Friend Property CheckTimeLast As DateTimeOffset

	''' <summary>
	''' 次回チェック時刻（予定）
	''' </summary>
	Friend Property CheckTimeNext As DateTimeOffset

	''' <summary>
	''' 前回アラート時刻
	''' </summary>
	Friend Property AlertTimeLast As DateTimeOffset

	''' <summary>
	''' 次回アラート最早時刻（実際の次回アラート時刻はこの時刻以降のチェック時刻）
	''' </summary>
	Friend Property AlertTimeEarliest As DateTimeOffset

	''' <summary>
	''' チェック中かどうかの状態
	''' </summary>
	Private Property IsChecking As Boolean
		Get
			Return _isChecking
		End Get
		Set(value As Boolean)
			_isChecking = value

			Button_Check.Enabled = Not value
		End Set
	End Property
	Private _isChecking As Boolean

	''' <summary>
	''' ログを記録するかどうかの選択
	''' </summary>
	Private isRecordEnabled As Boolean

	''' <summary>
	''' MainFormがLoadされたかどうかの状態
	''' </summary>
	Private isLoaded As Boolean

#End Region

#Region "Load"

	Private Async Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'同一の実行ファイルからの二重起動を抑止する
		Dim myProc As Process = Process.GetCurrentProcess()
		Dim procList As Process() = Process.GetProcessesByName(myProc.ProcessName)

		Try
			If (procList.
				Where(Function(x) x.Id <> myProc.Id).
				Any(Function(x) x.MainModule.FileName = Application.ExecutablePath)) Then
				MessageBox.Show("既に同一の実行ファイルから起動されているので、終了します。",
								My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.Close()
				Exit Sub
			End If

		Finally
			myProc.Dispose()

			procList.
				Where(Function(x) x IsNot Nothing).
				ToList().
				ForEach(Sub(x) x.Dispose())
		End Try

		Me.Text = $"{My.Application.Info.ProductName} {My.Application.Info.Version.ToString(3)}"

		'コマンドライン変数を処理する
		Dim addedThreshold As Integer

		For Each arg In My.Application.CommandLineArgs
			Select Case arg.Substring(0, 2)
				Case "/i" '内部時刻を開く項目を表示する
					InfoInternal_ToolStripMenuItem.Visible = True

				Case "/m" '更新状況を開く項目を表示する
					InfoMonitor_ToolStripMenuItem.Visible = True
					HelpMonitor_ToolStripMenuItem.Visible = True

				Case "/r" 'ログを記録するようにする
					isRecordEnabled = True

				Case "/t" '使用率の閾値を追加する
					If (4 <= arg.Length) Then
						Dim buff As Integer
						If (Integer.TryParse(arg.Substring(3), buff) AndAlso
							(1 <= buff) AndAlso (buff <= 99)) Then
							addedThreshold = buff
						End If
					End If

				Case "/?" 'コマンドライン変数の説明を表示する
					MessageBox.Show("コマンドライン変数" & Environment.NewLine & Environment.NewLine &
									"/i 内部時刻を見られるようにする。" & Environment.NewLine & Environment.NewLine &
									"/m 更新状況を見られるようにする。" & Environment.NewLine & Environment.NewLine &
									"/r ログを記録する。" & Environment.NewLine & Environment.NewLine &
									"/t:XX 使用率の閾値を追加する(XXはパーセントを示す" & Environment.NewLine &
									"1～99の数字)。",
									My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
			End Select
		Next

		'電力会社データを管理する
		Await ManageCompanyList()

		ComboBox_Companies.Items.AddRange(PowerCompany.Companies.Select(Function(x) x.Name).ToArray())
		ComboBox_Companies.SelectedIndex = 0

		'前回の設定を復元する
		If (Await Settings.LoadAsync()) Then '設定ファイルが既に存在する場合
			'電力会社の選択をComboBoxと合わせる
			If (Settings.Current.TargetCompanyIndex <= ComboBox_Companies.Items.Count - 1) Then
				ComboBox_Companies.SelectedIndex = Settings.Current.TargetCompanyIndex
			Else
				Settings.Current.TargetCompanyIndex = 0 '初期化
			End If

			'ショートカットが存在するか確認する
			If (Settings.Current.IsStartupRegistered) Then
				If (File.Exists(GetStartupShortcutPath())) Then
					Startup_ToolStripMenuItem.Checked = True
				Else
					Settings.Current.IsStartupRegistered = False '初期化
				End If
			End If

			'音声ファイルが存在するか確認する
			If (Not File.Exists(Settings.Current.AudioFilePath)) Then
				Settings.Current.AudioFilePath = String.Empty '初期化
			End If
		End If

		PopulateAlertIntervals()
		ManageAlertInterval(Settings.Current.AlertInterval, False)

		PopulateAlertThresholds(addedThreshold)
		ManageAlertThreshold(Settings.Current.AlertThreshold)

		'MainFormを表示する
		If (Settings.Current.IsWindowShown) Then
			Me.Visible = True
			Me.WindowState = FormWindowState.Normal 'デザイナーでMainFormをMinimizedにしてあるのをNormalに戻す
		Else
			Me.Visible = False
		End If

		isLoaded = True

		'初回チェック
		Dim checkTask As Task = CheckDataAsync()
	End Sub

	Private Async Function ManageCompanyList() As Task
		If (File.Exists(PowerCompany.CompanyFileName)) Then
			Try
				PowerCompany.ImportList(Await Task.Run(Function() File.ReadAllText(PowerCompany.CompanyFileName)))

			Catch ex As Exception
				Debug.WriteLine(ex)
			End Try
		End If

		If (Await PowerCompany.UpdateListAsnyc()) Then
			Try
				Await Task.Run(Sub() File.WriteAllText(PowerCompany.CompanyFileName, PowerCompany.ExportList()))

			Catch ex As Exception
				Debug.WriteLine(ex)
			End Try
		End If
	End Function

#End Region

#Region "Check"

	Private WithEvents CheckTimer As New Windows.Forms.Timer()

	'次回チェック時刻と次回アラート最早時刻を調整する
	Private Sub SetCheckAlertTime()
		CheckTimer.Enabled = False

		'次回チェックまでの間隔を計算する
		Dim checkTiming As Integer = (DateTimeOffset.Now.Minute * 60 + DateTimeOffset.Now.Second) Mod
			(TargetCompany.Interval * 60) '更新間隔刻みの時刻と現在時刻の差（秒）

		If (checkTiming < TargetCompany.Offset) Then '差がOffsetより小さい場合、今回の更新時刻に間に合うので、その時刻にチェックする
			CheckTimer.Interval = (TargetCompany.Offset - checkTiming) * 1000

		ElseIf ((checkTiming = TargetCompany.Offset) AndAlso
				(CheckTimeLast.AddSeconds(1) < DateTimeOffset.Now)) Then '差がOffsetと同じ場合で、かつチェック直後（1秒以内に完了すれば起こり得る）でない場合、すぐにチェックする
			CheckTimer.Interval = 100 'Timer.Intervalは0にはできないため、0にはしない

		Else '差がOffsetより大きい場合、今回の更新時刻には間に合わないので、次回の更新時刻にチェックする
			CheckTimer.Interval = (TargetCompany.Interval * 60 + TargetCompany.Offset - checkTiming) * 1000
		End If

		'次回チェック時刻を記録する
		CheckTimeNext = DateTimeOffset.Now.AddMilliseconds(CheckTimer.Interval)

		'次回アラート最早時刻を計算する
		AlertTimeEarliest = AlertTimeLast.AddSeconds(Settings.Current.AlertInterval * 60 - 10) '前回アラート時刻にアラート間隔を足し、処理の遅れを考慮して10秒引く

		CheckTimer.Enabled = True
	End Sub

	'自動チェック
	Private Async Sub CheckTimer_Tick(sender As Object, e As EventArgs) Handles CheckTimer.Tick
		Await CheckDataAsync()
	End Sub

	'手動チェック
	Private Async Sub Button_Check_Click(sender As Object, e As EventArgs) Handles Button_Check.Click
		Await CheckDataAsync()
	End Sub

	'電力会社の変更に伴うチェック
	Private Async Sub ComboBox_Companies_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Companies.SelectedIndexChanged
		Settings.Current.TargetCompanyIndex = ComboBox_Companies.SelectedIndex

		If (Not isLoaded) Then Exit Sub

		'初期化する
		CheckTimeNext = DateTimeOffset.MinValue
		AlertTimeLast = DateTimeOffset.MinValue
		AlertTimeEarliest = DateTimeOffset.MinValue

		updateTimeLast = DateTimeOffset.MinValue
		dataTimeLast = DateTimeOffset.MinValue
		usagePercentageLast = 0

		'表示をクリアする
		ClearAppearance()

		Await CheckDataAsync()
	End Sub

	Private updateTimeLast As DateTimeOffset '前回のアップデート時刻
	Private dataTimeLast As DateTimeOffset '前回のデータ時刻
	Private usagePercentageLast As Double '前回の使用率

	'電力データをチェックする
	Private Async Function CheckDataAsync() As Task
		IsChecking = True

		'電力データを取得する
		Await TargetCompany.CheckAsync()

		If (TargetCompany.Data IsNot Nothing) Then
			'アップデート時刻を記録する
			updateTimeLast = TargetCompany.Data.UpdateTime

			If (dataTimeLast < TargetCompany.Data.DataTime) Then '前回のデータ時刻と違う場合（初回チェックの場合を含む）
				'データ時刻を記録する
				dataTimeLast = TargetCompany.Data.DataTime

				'使用率の増減を確認する
				Dim phraseUpDown As String = String.Empty
				Dim colorUpDown As Color = Color.Black

				If (0 < usagePercentageLast) Then '初回チェックでない場合
					Dim rateUpDown As Double = TargetCompany.Data.UsagePercentage - usagePercentageLast '前回の使用率との差

					Select Case rateUpDown
						Case Is > 0.1
							phraseUpDown = "↑上昇"
							colorUpDown = Color.Red

						Case Is < -0.1
							phraseUpDown = "↓下降"
							colorUpDown = Color.Blue

						Case Else
							phraseUpDown = "－横ばい"
							colorUpDown = Color.Black
					End Select

					phraseUpDown &= $" {rateUpDown:+#0.0;-#0.0;0.0}"
				End If

				'使用率を記録する
				usagePercentageLast = TargetCompany.Data.UsagePercentage

				'表示に反映する
				ChangeAppearance(TargetCompany.Data.PeakSupply,
								 TargetCompany.Data.UsageAmount,
								 TargetCompany.Data.UsagePercentage,
								 phraseUpDown,
								 colorUpDown)

				If ((Settings.Current.AlertThreshold <= TargetCompany.Data.UsagePercentage) AndAlso
					(AlertTimeEarliest < DateTimeOffset.Now)) Then '次回アラート最早時刻を現在時刻が過ぎている場合
					'アラートを出す
					PlayAudio(Settings.Current.AudioFilePath)
					ShowBalloon(TargetCompany.Data.UsagePercentage, phraseUpDown)

					'アラート時刻を記録する
					AlertTimeLast = DateTimeOffset.Now
				End If

				'ログをファイルに記録する
				If (isRecordEnabled) Then
					Dim filePath As String = Path.Combine(Application.StartupPath, $"{Date.Today:yyyyMMdd}.log")
					Dim content As String = $"<<{TargetCompany.Name} {Date.Now:yyyy/M/d HH:mm:ss}>>" & Environment.NewLine &
					TargetCompany.Data.Source & Environment.NewLine &
					Environment.NewLine

					Await RecordLogAsync(filePath, content)
				End If
			End If
		End If

		'前回のアップデート時刻から30分が過ぎている場合、表示をクリアする
		If ((DateTimeOffset.MinValue < updateTimeLast) AndAlso
			(updateTimeLast.AddMinutes(30) < DateTimeOffset.Now)) Then
			ClearAppearance()
		End If

		'チェック時刻を記録する
		CheckTimeLast = DateTimeOffset.Now

		IsChecking = False
		SetCheckAlertTime()
	End Function

	Private Async Function RecordLogAsync(filePath As String, content As String) As Task
		Try
			Using writer As New StreamWriter(filePath, True, Encoding.GetEncoding("Shift-JIS")) '追記
				Await writer.WriteAsync(content)
			End Using

		Catch ex As Exception
			Debug.WriteLine(ex)
		End Try
	End Function

#End Region

#Region "Appearance"

	Private isCleared As Boolean = False

	'表示を変更する
	Private Sub ChangeAppearance(peakSupply As Double, usageAmount As Double, usageRate As Double, phraseUpDown As String, colorUpDown As Color)
		TextBox_PeakSupply.Text = peakSupply.ToString("f0")
		TextBox_UsageAmount.Text = usageAmount.ToString("f0")

		TextBox_UpDown.Text = phraseUpDown
		TextBox_UpDown.ForeColor = colorUpDown

		ManageUsageRateBarIcon(usageRate)

		'通知領域アイコンのツールチップを変更する
		NotifyIcon1.Text = $"[{TargetCompany.Name}の使用状況]" & Environment.NewLine &
						   $"最新の使用量 {usageAmount:f0} 万kW" & Environment.NewLine &
						   $"最新の使用率 {usageRate:f1} %" & Environment.NewLine &
						   phraseUpDown

		isCleared = False
	End Sub

	'表示をクリアする
	Private Sub ClearAppearance()
		If (isCleared) Then Exit Sub

		TextBox_PeakSupply.Text = String.Empty
		TextBox_UsageAmount.Text = String.Empty

		TextBox_UpDown.Text = String.Empty
		TextBox_UpDown.ForeColor = Color.Black

		ManageUsageRateBarIcon(0)

		'通知領域アイコンのツールチップを変更する
		NotifyIcon1.Text = $"[{TargetCompany.Name}の使用状況]" & Environment.NewLine &
						   "不明"

		isCleared = True
	End Sub

	'バルーンを出す
	Private Sub ShowBalloon(usageRate As Double, phraseUpDown As String)
		ToolTip1.IsBalloon = True
		NotifyIcon1.BalloonTipTitle = $"[{TargetCompany.Name}の使用状況]"
		NotifyIcon1.BalloonTipText = $"最新の使用率 {usageRate:f1} %" & Environment.NewLine &
									 phraseUpDown
		NotifyIcon1.BalloonTipIcon = ToolTipIcon.Warning
		NotifyIcon1.ShowBalloonTip(8000)
	End Sub

#Region "Usage Rate"

	Private WithEvents UsageRateTimer As New Windows.Forms.Timer()

	'使用率のプログレスバーと通知領域（タスクトレイ）アイコンを管理する
	Private Sub ManageUsageRateBarIcon(Optional usageRate As Double = -1) '既定値は無効な使用率
		UsageRateTimer.Enabled = False

		Static targetRate As Double = 50 '到達する目標の使用率
		Static wayRate As Double = 50    '到達する途中の使用率

		'有効な使用率の場合、endRateに保存する
		If (0 <= usageRate) Then targetRate = usageRate

		If (targetRate = 0) Then '使用率が0の場合
			SetUsageRateBarIcon(0)

			'wayRateを初期値に戻す
			wayRate = 50

		Else 'それ以外の場合 
			Dim numStep As Integer = Convert.ToInt32(Math.Abs(Math.Truncate(targetRate) - Math.Truncate(wayRate))) '到達までの残り回数

			If (numStep <= 1) Then '残り回数が1の場合（0は基本的にない）
				SetUsageRateBarIcon(targetRate)

				'wayRateを揃えておく
				wayRate = targetRate

			Else '残り回数が2以上の場合
				'wayRateを1回分だけ増減させる
				wayRate += (targetRate - wayRate) / numStep

				SetUsageRateBarIcon(Math.Round(wayRate * 10) / 10)

				UsageRateTimer.Interval = 30
				UsageRateTimer.Enabled = True
			End If
		End If
	End Sub

	Private Sub UsageRateTimer_Tick(sender As Object, e As EventArgs) Handles UsageRateTimer.Tick
		ManageUsageRateBarIcon()
	End Sub

	Private Sub SetUsageRateBarIcon(rate As Double)
		Dim rateColor As Color
		Dim rateRounded As Integer = Convert.ToInt32(Math.Round(rate))

		'使用率に応じたアイコンを設定し、色を決める
		Select Case rateRounded
			Case 0
				Me.NotifyIcon1.Icon = My.Resources.blank
				'Me.NotifyIcon1.Icon = My.Resources._00
				rateColor = Color.FromArgb(160, 160, 160)
			Case 1
				Me.NotifyIcon1.Icon = My.Resources._01
				rateColor = Color.FromArgb(160, 160, 160)
			Case 2
				Me.NotifyIcon1.Icon = My.Resources._02
				rateColor = Color.FromArgb(160, 160, 160)
			Case 3
				Me.NotifyIcon1.Icon = My.Resources._03
				rateColor = Color.FromArgb(160, 160, 160)
			Case 4
				Me.NotifyIcon1.Icon = My.Resources._04
				rateColor = Color.FromArgb(160, 160, 160)
			Case 5
				Me.NotifyIcon1.Icon = My.Resources._05
				rateColor = Color.FromArgb(160, 160, 160)
			Case 6
				Me.NotifyIcon1.Icon = My.Resources._06
				rateColor = Color.FromArgb(160, 160, 160)
			Case 7
				Me.NotifyIcon1.Icon = My.Resources._07
				rateColor = Color.FromArgb(160, 160, 160)
			Case 8
				Me.NotifyIcon1.Icon = My.Resources._08
				rateColor = Color.FromArgb(160, 160, 160)
			Case 9
				Me.NotifyIcon1.Icon = My.Resources._09
				rateColor = Color.FromArgb(160, 160, 160)
			Case 10
				Me.NotifyIcon1.Icon = My.Resources._10
				rateColor = Color.FromArgb(0, 176, 240)
			Case 11
				Me.NotifyIcon1.Icon = My.Resources._11
				rateColor = Color.FromArgb(0, 176, 240)
			Case 12
				Me.NotifyIcon1.Icon = My.Resources._12
				rateColor = Color.FromArgb(0, 176, 240)
			Case 13
				Me.NotifyIcon1.Icon = My.Resources._13
				rateColor = Color.FromArgb(0, 176, 240)
			Case 14
				Me.NotifyIcon1.Icon = My.Resources._14
				rateColor = Color.FromArgb(0, 176, 240)
			Case 15
				Me.NotifyIcon1.Icon = My.Resources._15
				rateColor = Color.FromArgb(0, 176, 240)
			Case 16
				Me.NotifyIcon1.Icon = My.Resources._16
				rateColor = Color.FromArgb(0, 176, 240)
			Case 17
				Me.NotifyIcon1.Icon = My.Resources._17
				rateColor = Color.FromArgb(0, 176, 240)
			Case 18
				Me.NotifyIcon1.Icon = My.Resources._18
				rateColor = Color.FromArgb(0, 176, 240)
			Case 19
				Me.NotifyIcon1.Icon = My.Resources._19
				rateColor = Color.FromArgb(0, 176, 240)
			Case 20
				Me.NotifyIcon1.Icon = My.Resources._20
				rateColor = Color.FromArgb(0, 176, 240)
			Case 21
				Me.NotifyIcon1.Icon = My.Resources._21
				rateColor = Color.FromArgb(0, 176, 240)
			Case 22
				Me.NotifyIcon1.Icon = My.Resources._22
				rateColor = Color.FromArgb(0, 176, 240)
			Case 23
				Me.NotifyIcon1.Icon = My.Resources._23
				rateColor = Color.FromArgb(0, 176, 240)
			Case 24
				Me.NotifyIcon1.Icon = My.Resources._24
				rateColor = Color.FromArgb(0, 176, 240)
			Case 25
				Me.NotifyIcon1.Icon = My.Resources._25
				rateColor = Color.FromArgb(0, 176, 240)
			Case 26
				Me.NotifyIcon1.Icon = My.Resources._26
				rateColor = Color.FromArgb(0, 176, 240)
			Case 27
				Me.NotifyIcon1.Icon = My.Resources._27
				rateColor = Color.FromArgb(0, 176, 240)
			Case 28
				Me.NotifyIcon1.Icon = My.Resources._28
				rateColor = Color.FromArgb(0, 176, 240)
			Case 29
				Me.NotifyIcon1.Icon = My.Resources._30
				rateColor = Color.FromArgb(0, 176, 240)
			Case 31
				Me.NotifyIcon1.Icon = My.Resources._31
				rateColor = Color.FromArgb(0, 176, 240)
			Case 32
				Me.NotifyIcon1.Icon = My.Resources._32
				rateColor = Color.FromArgb(0, 176, 240)
			Case 33
				Me.NotifyIcon1.Icon = My.Resources._33
				rateColor = Color.FromArgb(0, 176, 240)
			Case 34
				Me.NotifyIcon1.Icon = My.Resources._34
				rateColor = Color.FromArgb(0, 176, 240)
			Case 35
				Me.NotifyIcon1.Icon = My.Resources._35
				rateColor = Color.FromArgb(0, 176, 240)
			Case 36
				Me.NotifyIcon1.Icon = My.Resources._36
				rateColor = Color.FromArgb(0, 176, 240)
			Case 37
				Me.NotifyIcon1.Icon = My.Resources._37
				rateColor = Color.FromArgb(0, 176, 240)
			Case 38
				Me.NotifyIcon1.Icon = My.Resources._38
				rateColor = Color.FromArgb(0, 176, 240)
			Case 39
				Me.NotifyIcon1.Icon = My.Resources._39
				rateColor = Color.FromArgb(0, 176, 240)
			Case 40
				Me.NotifyIcon1.Icon = My.Resources._40
				rateColor = Color.FromArgb(0, 176, 240)
			Case 41
				Me.NotifyIcon1.Icon = My.Resources._41
				rateColor = Color.FromArgb(0, 176, 240)
			Case 42
				Me.NotifyIcon1.Icon = My.Resources._42
				rateColor = Color.FromArgb(0, 176, 240)
			Case 43
				Me.NotifyIcon1.Icon = My.Resources._43
				rateColor = Color.FromArgb(0, 176, 240)
			Case 44
				Me.NotifyIcon1.Icon = My.Resources._44
				rateColor = Color.FromArgb(0, 176, 240)
			Case 45
				Me.NotifyIcon1.Icon = My.Resources._45
				rateColor = Color.FromArgb(0, 176, 240)
			Case 46
				Me.NotifyIcon1.Icon = My.Resources._46
				rateColor = Color.FromArgb(0, 176, 240)
			Case 47
				Me.NotifyIcon1.Icon = My.Resources._47
				rateColor = Color.FromArgb(0, 176, 240)
			Case 48
				Me.NotifyIcon1.Icon = My.Resources._48
				rateColor = Color.FromArgb(0, 176, 240)
			Case 49
				Me.NotifyIcon1.Icon = My.Resources._49
				rateColor = Color.FromArgb(0, 176, 240)
			Case 50
				Me.NotifyIcon1.Icon = My.Resources._50
				rateColor = Color.FromArgb(0, 176, 240)
			Case 51
				Me.NotifyIcon1.Icon = My.Resources._51
				rateColor = Color.FromArgb(0, 176, 240)
			Case 52
				Me.NotifyIcon1.Icon = My.Resources._52
				rateColor = Color.FromArgb(10, 178, 236)
			Case 53
				Me.NotifyIcon1.Icon = My.Resources._53
				rateColor = Color.FromArgb(20, 180, 232)
			Case 54
				Me.NotifyIcon1.Icon = My.Resources._54
				rateColor = Color.FromArgb(31, 183, 227)
			Case 55
				Me.NotifyIcon1.Icon = My.Resources._55
				rateColor = Color.FromArgb(41, 185, 223)
			Case 56
				Me.NotifyIcon1.Icon = My.Resources._56
				rateColor = Color.FromArgb(52, 188, 218)
			Case 57
				Me.NotifyIcon1.Icon = My.Resources._57
				rateColor = Color.FromArgb(62, 190, 214)
			Case 58
				Me.NotifyIcon1.Icon = My.Resources._58
				rateColor = Color.FromArgb(72, 192, 210)
			Case 59
				Me.NotifyIcon1.Icon = My.Resources._59
				rateColor = Color.FromArgb(83, 195, 205)
			Case 60
				Me.NotifyIcon1.Icon = My.Resources._60
				rateColor = Color.FromArgb(93, 197, 201)
			Case 61
				Me.NotifyIcon1.Icon = My.Resources._61
				rateColor = Color.FromArgb(104, 200, 196)
			Case 62
				Me.NotifyIcon1.Icon = My.Resources._62
				rateColor = Color.FromArgb(114, 202, 192)
			Case 63
				Me.NotifyIcon1.Icon = My.Resources._63
				rateColor = Color.FromArgb(124, 204, 188)
			Case 64
				Me.NotifyIcon1.Icon = My.Resources._64
				rateColor = Color.FromArgb(135, 207, 183)
			Case 65
				Me.NotifyIcon1.Icon = My.Resources._65
				rateColor = Color.FromArgb(145, 209, 179)
			Case 66
				Me.NotifyIcon1.Icon = My.Resources._66
				rateColor = Color.FromArgb(156, 212, 174)
			Case 67
				Me.NotifyIcon1.Icon = My.Resources._67
				rateColor = Color.FromArgb(166, 214, 170)
			Case 68
				Me.NotifyIcon1.Icon = My.Resources._68
				rateColor = Color.FromArgb(176, 216, 166)
			Case 69
				Me.NotifyIcon1.Icon = My.Resources._69
				rateColor = Color.FromArgb(187, 219, 161)
			Case 70
				Me.NotifyIcon1.Icon = My.Resources._70
				rateColor = Color.FromArgb(197, 221, 157)
			Case 71
				Me.NotifyIcon1.Icon = My.Resources._71
				rateColor = Color.FromArgb(208, 224, 152)
			Case 72
				Me.NotifyIcon1.Icon = My.Resources._72
				rateColor = Color.FromArgb(218, 226, 148)
			Case 73
				Me.NotifyIcon1.Icon = My.Resources._73
				rateColor = Color.FromArgb(228, 228, 144)
			Case 74
				Me.NotifyIcon1.Icon = My.Resources._74
				rateColor = Color.FromArgb(239, 231, 139)
			Case 75
				Me.NotifyIcon1.Icon = My.Resources._75
				rateColor = Color.FromArgb(249, 233, 135)
			Case 76
				Me.NotifyIcon1.Icon = My.Resources._76
				rateColor = Color.FromArgb(255, 231, 130)
			Case 77
				Me.NotifyIcon1.Icon = My.Resources._77
				rateColor = Color.FromArgb(255, 221, 124)
			Case 78
				Me.NotifyIcon1.Icon = My.Resources._78
				rateColor = Color.FromArgb(255, 212, 119)
			Case 79
				Me.NotifyIcon1.Icon = My.Resources._79
				rateColor = Color.FromArgb(255, 202, 114)
			Case 80
				Me.NotifyIcon1.Icon = My.Resources._80
				rateColor = Color.FromArgb(255, 192, 108)
			Case 81
				Me.NotifyIcon1.Icon = My.Resources._81
				rateColor = Color.FromArgb(255, 183, 103)
			Case 82
				Me.NotifyIcon1.Icon = My.Resources._82
				rateColor = Color.FromArgb(255, 173, 97)
			Case 83
				Me.NotifyIcon1.Icon = My.Resources._83
				rateColor = Color.FromArgb(255, 164, 92)
			Case 84
				Me.NotifyIcon1.Icon = My.Resources._84
				rateColor = Color.FromArgb(255, 154, 87)
			Case 85
				Me.NotifyIcon1.Icon = My.Resources._85
				rateColor = Color.FromArgb(255, 144, 81)
			Case 86
				Me.NotifyIcon1.Icon = My.Resources._86
				rateColor = Color.FromArgb(255, 135, 76)
			Case 87
				Me.NotifyIcon1.Icon = My.Resources._87
				rateColor = Color.FromArgb(255, 125, 71)
			Case 88
				Me.NotifyIcon1.Icon = My.Resources._88
				rateColor = Color.FromArgb(255, 116, 65)
			Case 89
				Me.NotifyIcon1.Icon = My.Resources._89
				rateColor = Color.FromArgb(255, 106, 60)
			Case 90
				Me.NotifyIcon1.Icon = My.Resources._90
				rateColor = Color.FromArgb(255, 96, 54)
			Case 91
				Me.NotifyIcon1.Icon = My.Resources._91
				rateColor = Color.FromArgb(255, 87, 49)
			Case 92
				Me.NotifyIcon1.Icon = My.Resources._92
				rateColor = Color.FromArgb(255, 77, 44)
			Case 93
				Me.NotifyIcon1.Icon = My.Resources._93
				rateColor = Color.FromArgb(255, 68, 38)
			Case 94
				Me.NotifyIcon1.Icon = My.Resources._94
				rateColor = Color.FromArgb(255, 58, 33)
			Case 95
				Me.NotifyIcon1.Icon = My.Resources._95
				rateColor = Color.FromArgb(255, 48, 27)
			Case 96
				Me.NotifyIcon1.Icon = My.Resources._96
				rateColor = Color.FromArgb(255, 39, 22)
			Case 97
				Me.NotifyIcon1.Icon = My.Resources._97
				rateColor = Color.FromArgb(255, 29, 17)
			Case 98
				Me.NotifyIcon1.Icon = My.Resources._98
				rateColor = Color.FromArgb(255, 20, 11)
			Case 99
				Me.NotifyIcon1.Icon = My.Resources._99
				rateColor = Color.FromArgb(255, 10, 6)
			Case 100
				Me.NotifyIcon1.Icon = My.Resources._100
				rateColor = Color.FromArgb(255, 0, 0)
			Case Else
				Me.NotifyIcon1.Icon = My.Resources.over100
				rateColor = Color.FromArgb(255, 0, 0)
		End Select

		'使用率のプログレスバーを更新する
		ProgressBar_UsageRate.Value = rateRounded
		ProgressBar_UsageRate.ForeColor = rateColor

		'テキストボックスの文字を（背景色とともに）更新する
		TextBox_UsageRate.Text = rate.ToString("f1")
		TextBox_UsageRate.BackColor = rateColor
		TextBox_UsageRateUnit.BackColor = rateColor

		'テキストボックスを表示する（rateが0でない場合）
		TextBox_UsageRate.Visible = (0 < rate)
		TextBox_UsageRateUnit.Visible = (0 < rate)
	End Sub

#End Region

#End Region

#Region "Audio"

	Private mediaPlayer As Windows.Controls.MediaElement 'WPFのMediaElement

	Private Sub PlayAudio(audioFilePath As String)
		If (File.Exists(audioFilePath)) Then
			'音声ファイルの再生を開始する
			Try
				If (mediaPlayer Is Nothing) Then
					mediaPlayer = New Windows.Controls.MediaElement With {.LoadedBehavior = Windows.Controls.MediaState.Manual,
																		  .UnloadedBehavior = Windows.Controls.MediaState.Manual}
					AddHandler mediaPlayer.MediaEnded,
						Sub(sender, e)
							'再生を自動で終了する（後始末）
							StopAudio()
						End Sub
				End If

				mediaPlayer.Source = New Uri(audioFilePath)
				mediaPlayer.Play()

				TextBox_Play.Text = "アラート音再生中"
				TextBox_Play.Visible = True

			Catch ex As Exception
				Debug.WriteLine(ex)
			End Try
		Else
			SystemSounds.Exclamation.Play()
		End If
	End Sub

	Private Sub TextBox_Play_MouseHover(sender As Object, e As EventArgs) Handles TextBox_Play.MouseHover,
																				  TextBox_Play.MouseMove,
																				  TextBox_Play.GotFocus
		TextBox_Play.Text = "再生を終了する"
	End Sub

	Private Sub TextBox_Play_MouseLeave(sender As Object, e As EventArgs) Handles TextBox_Play.MouseLeave,
																				  TextBox_Play.LostFocus
		TextBox_Play.Text = "アラート音再生中"
	End Sub

	Private Sub TextBox_Play_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox_Play.MouseClick
		'マウスクリックされれば、再生を手動で終了する
		StopAudio()
	End Sub

	Private Sub TextBox_Play_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_Play.KeyDown
		'押されたキーがEnterであれば、再生を手動で終了する
		If (e.KeyCode = Keys.Enter) Then
			StopAudio()
		End If
	End Sub

	Private Sub StopAudio()
		'再生を終了する
		Try
			If (mediaPlayer IsNot Nothing) Then
				mediaPlayer.Stop()
			End If

			TextBox_Play.Visible = False

		Catch ex As Exception
			Debug.WriteLine(ex)
		End Try
	End Sub

#End Region

#Region "Misc Management"

#Region "Alert Interval"

	'アラート間隔の項目を入れる
	Private Sub PopulateAlertIntervals()
		Dim intervals As New List(Of Integer) From {20, 30, 60} '既定の間隔

		intervals.ForEach(
			Sub(x)
				Dim item As New ToolStripMenuItem With {.Text = $"{x}分",
														.Tag = x}
				AddHandler item.Click,
					Sub(sender, e)
						Dim interval As Integer = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Integer)
						ManageAlertInterval(interval)
					End Sub

				Interval_ToolStripMenuItem.DropDownItems.Add(item)
			End Sub)
	End Sub

	'アラート間隔を設定する
	Private Sub ManageAlertInterval(interval As Integer, Optional setTime As Boolean = True)
		Interval_ToolStripMenuItem.DropDownItems.
			OfType(Of ToolStripMenuItem)().
			ToList().
			ForEach(Sub(x) x.Checked = (DirectCast(x.Tag, Integer) = interval))

		Settings.Current.AlertInterval = interval

		If (setTime) Then
			'次回アラート最早時刻を調整
			SetCheckAlertTime()
		End If
	End Sub

#End Region

#Region "Alert Threshold"

	'使用率の閾値の項目を入れる
	Private Sub PopulateAlertThresholds(addedThreshold As Integer)
		Dim thresholds As New List(Of Integer) From {80, 85, 90, 95} '既定の閾値

		If ((0 < addedThreshold) AndAlso Not thresholds.Contains(addedThreshold)) Then
			thresholds.Add(addedThreshold)
			Settings.Current.AlertThreshold = addedThreshold
		ElseIf (Not thresholds.Contains(Settings.Current.AlertThreshold)) Then
			thresholds.Add(Settings.Current.AlertThreshold)
		End If

		thresholds.Sort()
		thresholds.ForEach(
			Sub(x)
				Dim item As New ToolStripMenuItem With {.Text = $"{x}%",
														.Tag = x}
				AddHandler item.Click,
					Sub(sender, e)
						Dim threshold As Integer = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Integer)
						ManageAlertThreshold(threshold)
					End Sub

				Threshold_ToolStripMenuItem.DropDownItems.Add(item)
			End Sub)
	End Sub

	'使用率の閾値を設定する
	Private Sub ManageAlertThreshold(threshold As Integer)
		Threshold_ToolStripMenuItem.DropDownItems.
			OfType(Of ToolStripMenuItem)().
			ToList().
			ForEach(Sub(x) x.Checked = (DirectCast(x.Tag, Integer) = threshold))

		Settings.Current.AlertThreshold = threshold
	End Sub

#End Region

#Region "Shortcut"

	Private Function GetStartupShortcutPath() As String
		Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "電気アラート.lnk")
	End Function

	Private Sub Startup_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Startup_ToolStripMenuItem.Click
		Dim shortcutPath As String = GetStartupShortcutPath()

		If (Not Startup_ToolStripMenuItem.Checked) Then
			Startup_ToolStripMenuItem.Checked = True
			Settings.Current.IsStartupRegistered = True

			'スタートアップにショートカットを作成する
			Dim shell As New IWshRuntimeLibrary.WshShell()
			Dim shortcut As IWshRuntimeLibrary.WshShortcut = DirectCast(shell.CreateShortcut(shortcutPath), IWshRuntimeLibrary.WshShortcut)

			With shortcut
				.TargetPath = Application.ExecutablePath
				.Description = String.Empty
				.IconLocation = Application.ExecutablePath
				.WorkingDirectory = Application.StartupPath
				.Save()
			End With

			MessageBox.Show($"{My.Application.Info.ProductName}をスタートアップに登録しました。",
							My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
		Else
			Startup_ToolStripMenuItem.Checked = False
			Settings.Current.IsStartupRegistered = False

			'ショートカットを削除する
			If (File.Exists(shortcutPath)) Then
				File.Delete(shortcutPath)

				MessageBox.Show($"{My.Application.Info.ProductName}をスタートアップから削除しました。",
								My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
			End If
		End If
	End Sub

#End Region

#End Region

#Region "Window Management"

	Private Sub Audio_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Audio_ToolStripMenuItem.Click
		'AudioDialog（アラート音の設定）をモーダルダイアログとして開く
		Using f As New AudioDialog()
			f.ShowDialog(Me)
		End Using
	End Sub

	Private Sub InfoInternal_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoInternal_ToolStripMenuItem.Click
		InfoInternal_ToolStripMenuItem.Enabled = False

		'InfoInternalForm（内部時刻）をモードレスフォームとして開く
		Dim f As New InfoInternalForm()
		f.AdjustLocation()
		f.Show(Me)
	End Sub

	Private Sub InfoMonitor_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoMonitor_ToolStripMenuItem.Click
		InfoMonitor_ToolStripMenuItem.Enabled = False

		'InfoMonitorForm（更新状況）をモードレスフォームとして開く
		Dim f As New InfoMonitorForm()
		f.AdjustLocation()
		f.Show(Me)
	End Sub

	Private Sub HelpMonitor_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpMonitor_ToolStripMenuItem.Click
		'更新状況の説明を表示する
		MessageBox.Show("更新状況の説明" & Environment.NewLine & Environment.NewLine &
						"電力会社のデータファイルの更新を3秒おきに確認する" & Environment.NewLine & Environment.NewLine &
						"更新時刻: ファイルが実際に更新された時刻" & Environment.NewLine & Environment.NewLine &
						"差: 更新間隔刻みの時刻と更新時刻の差(秒)" & Environment.NewLine & Environment.NewLine &
						"UPDATE: ファイルにUPDATEと示された時刻" & Environment.NewLine & Environment.NewLine &
						"データ: ファイルにある最新の使用量データの時刻",
						My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
	End Sub

	Private Sub About_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles About_ToolStripMenuItem.Click
		'Aboutをモーダルダイアログとして開く
		Using f As New About()
			f.ShowDialog(Me)
		End Using
	End Sub

	Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		If (Me.WindowState = FormWindowState.Minimized) Then Me.Visible = False
	End Sub

	Private Sub Open_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Open_ToolStripMenuItem.Click,
																					   NotifyIcon1.MouseDoubleClick
		Me.Visible = True
		If (Me.WindowState = FormWindowState.Minimized) Then Me.WindowState = FormWindowState.Normal
		Me.Activate()
	End Sub

	Private Sub End_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles End_ToolStripMenuItem.Click
		Me.Close()
	End Sub

#End Region

#Region "Close"

	Private Async Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		'設定を記録する
		Settings.Current.IsWindowShown = Me.Visible

		Await Settings.SaveAsync()

		NotifyIcon1.Visible = False
	End Sub

#End Region

End Class