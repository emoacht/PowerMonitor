Imports System.Threading.Tasks

Imports PowerMonitor

Public Class InfoMonitorForm

#Region "Property"

	''' <summary>
	''' モニターする電力会社
	''' </summary>
	Private ReadOnly Property MonitoredCompany As PowerCompany
		Get
			Return PowerCompany.Companies(MonitoredCompanyIndex)
		End Get
	End Property

	''' <summary>
	''' モニターする電力会社の選択（モニターを停止、再開するまで不変）
	''' </summary>
	Private Property MonitoredCompanyIndex As Integer
		Get
			Return _monitoredCompanyIndex
		End Get
		Set(value As Integer)
			_monitoredCompanyIndex = value

			TextBox_Company.Text = MonitoredCompany.Name
		End Set
	End Property
	Private _monitoredCompanyIndex As Integer

	''' <summary>
	''' モニター中かどうかの状態
	''' </summary>
	Private Property IsMonitoring As Boolean
		Get
			Return _isMonitoring
		End Get
		Set(value As Boolean)
			_isMonitoring = value

			Button_Start.Enabled = Not value
			Button_Stop.Enabled = value
		End Set
	End Property
	Private _isMonitoring As Boolean

	''' <summary>
	''' モニター時間（分）
	''' </summary>
	Private Const MonitorDuration As Integer = 30

	''' <summary>
	''' モニター停止時刻
	''' </summary>
	Private Property MonitorEndTime As DateTimeOffset

	''' <summary>
	''' モニター残り時間
	''' </summary>
	Private Property MonitorRemainingTime As TimeSpan
		Get
			Return _monitorRemainingTime
		End Get
		Set(value As TimeSpan)
			_monitorRemainingTime = If(TimeSpan.Zero < value, value, TimeSpan.Zero)

			TextBox_RemainingTime.Text = $"{_monitorRemainingTime.Minutes:00}:{_monitorRemainingTime.Seconds:00}"
		End Set
	End Property
	Private _monitorRemainingTime As TimeSpan

#End Region

	Private WithEvents CheckTimer As New Windows.Forms.Timer()

	Private Sub InfoMonitorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		CheckTimer.Interval = 3000
		CheckTimer.Enabled = True
	End Sub

	Private Async Sub CheckTimer_Tick(sender As Object, e As EventArgs) Handles CheckTimer.Tick
		If (IsMonitoring) Then 'モニター中の場合
			MonitorRemainingTime = MonitorEndTime - DateTimeOffset.Now

			If (TimeSpan.Zero < MonitorRemainingTime) Then 'まだ残り時間がある場合
				Await CheckDataAsync()
			Else 'ない場合
				IsMonitoring = False
			End If
		End If

		AdjustLocation()
	End Sub

#Region "Monitor"

	'モニターを開始する（再開する）
	Private Async Sub Button_Start_Click(sender As Object, e As EventArgs) Handles Button_Start.Click
		IsMonitoring = True

		'MainFormの電力会社の選択と一致させる
		If (MonitoredCompanyIndex <> Settings.Current.TargetCompanyIndex) Then '前回の電力会社と違う場合（最初回で0のとき以外の場合も含まれるが、問題ない）
			'初期化する
			MonitorRemainingTime = TimeSpan.Zero
			checkTimeLast = DateTimeOffset.MinValue
			dataTimeLast = DateTimeOffset.MinValue

			ClearListView()
		End If

		MonitoredCompanyIndex = Settings.Current.TargetCompanyIndex '最初回で0のときでも会社名を表示させるためにセットする

		'残り時間と停止時刻を計算する
		If (MonitorRemainingTime = TimeSpan.Zero) Then '初回チェックの場合、モニターを完了した後の場合
			MonitorRemainingTime = TimeSpan.FromMinutes(MonitorDuration)
			MonitorEndTime = DateTimeOffset.Now.AddMinutes(MonitorDuration) '現在時刻にモニター時間を足す
		Else '未完了のモニターを再開する場合
			MonitorEndTime = DateTimeOffset.Now.Add(MonitorRemainingTime) '現在時刻に残り時間を足す
		End If

		'初回チェック
		Await CheckDataAsync()
	End Sub

	'モニターを停止する（再開できるので、終了ではない）
	Private Sub Button_Stop_Click(sender As Object, e As EventArgs) Handles Button_Stop.Click
		IsMonitoring = False
	End Sub

	Private checkTimeLast As DateTimeOffset '前回チェック時刻
	Private dataTimeLast As DateTimeOffset '前回データ時刻

	'電力データをチェックする
	Private Async Function CheckDataAsync() As Task
		Dim isInitial As Boolean = (checkTimeLast = DateTimeOffset.MinValue)

		'電力データを取得する
		Dim result As CheckResult = Await MonitoredCompany.CheckAsync(checkTimeLast)

		'チェック時刻を記録する
		checkTimeLast = DateTimeOffset.Now

		If (result <> CheckResult.Success) Then Exit Function

		If (dataTimeLast = MonitoredCompany.Data.DataTime) Then Exit Function

		'データ時刻を記録する
		dataTimeLast = MonitoredCompany.Data.DataTime

		'初回チェックの結果は使わない
		If (isInitial) Then Exit Function

		Dim updateTiming As Integer = (DateTimeOffset.Now.Minute * 60 + DateTimeOffset.Now.Second) Mod
			(MonitoredCompany.Interval * 60) '更新間隔刻みの時刻と現在時刻の差（秒）

		ChangeListView(checkTimeLast,
					   updateTiming,
					   MonitoredCompany.Data.UpdateTime,
					   MonitoredCompany.Data.DataTime)
	End Function

	'ListViewに追加する
	Private Sub ChangeListView(checkTime As DateTimeOffset, updateTiming As Integer, updateTime As DateTimeOffset, dataTime As DateTimeOffset)
		Dim targetIndex As Integer = ListView_UpdateTime.Items.
			OfType(Of ListViewItem)().
			ToList().
			FindIndex(Function(x) x.SubItems().
						  OfType(Of ListViewItem.ListViewSubItem)().
						  Skip(1).
						  All(Function(y) String.IsNullOrEmpty(y.Text)))

		Dim insertsItem As Boolean = True

		If (targetIndex < 0) Then
			targetIndex = ListView_UpdateTime.Items.Count
			insertsItem = False
		End If

		Dim item As New ListViewItem({
			$"{targetIndex + 1}",
			$"{checkTime:H:mm:ss}",
			$"{updateTiming}",
			$"{updateTime:mm:ss}",
			$"{dataTime:mm:ss}"})

		If (insertsItem) Then
			ListView_UpdateTime.Items.RemoveAt(targetIndex)
			ListView_UpdateTime.Items.Insert(targetIndex, item)
		Else
			ListView_UpdateTime.Items.Add(item)
		End If

		ListView_UpdateTime.EnsureVisible(targetIndex)
	End Sub

	'ListViewをクリアする
	Private Sub ClearListView()
		If ((0 < ListView_UpdateTime.Items.Count) AndAlso
			ListView_UpdateTime.Items(0).SubItems.
				OfType(Of ListViewItem.ListViewSubItem)().
				Skip(1).
				All(Function(x) String.IsNullOrEmpty(x.Text))) Then
			Return
		End If

		ListView_UpdateTime.Items.Clear()

		Enumerable.Range(1, 6).
			Select(Function(x) {x.ToString()}.Concat(Enumerable.Repeat(String.Empty, 4))).
			Select(Function(x) New ListViewItem(x.ToArray())).
			ToList().
			ForEach(Sub(x) ListView_UpdateTime.Items.Add(x))
	End Sub

#End Region

#Region "Misc Management"

	'MainFormとInfoInternalFormの移動に追随する
	Friend Sub AdjustLocation()
		If (Not MainForm.InfoInternal_ToolStripMenuItem.Enabled) Then 'InfoInternalFormが開いている場合
			Me.Location = New Point(MainForm.Bounds.Location.X, MainForm.Bounds.Location.Y + 340) '位置をInfoInternalFormの直下に設定

		Else '開いてない場合
			Me.Location = New Point(MainForm.Bounds.Location.X, MainForm.Bounds.Location.Y + 210) '位置をMainFormの直下に設定
		End If
	End Sub

	'ListViewのcolumnの幅変更を抑止する
	Private Sub ListView_UpdateTime_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles ListView_UpdateTime.ColumnWidthChanging
		e.NewWidth = Me.ListView_UpdateTime.Columns(e.ColumnIndex).Width
		e.Cancel = True
	End Sub

#End Region

#Region "Close"

	Private Sub InfoMonitor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		MainForm.InfoMonitor_ToolStripMenuItem.Enabled = True

		CheckTimer.Enabled = False
	End Sub

#End Region

End Class