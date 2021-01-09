Public Class InfoInternalForm

	Private WithEvents CheckTimer As New Windows.Forms.Timer()

	Private Sub InfoInternalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'初回表示
		GetTime()

		CheckTimer.Interval = 1000
		CheckTimer.Enabled = True
	End Sub

	Private Sub CheckTimer_Tick(sender As Object, e As EventArgs) Handles CheckTimer.Tick
		GetTime()

		AdjustLocation()
	End Sub

#Region "Internal"

	'内部時刻を表示する
	Private Sub GetTime()
		TextBox_CheckLast.Text = MainForm.CheckTimeLast.ToString("HH:mm:ss")
		TextBox_CheckNext.Text = MainForm.CheckTimeNext.ToString("HH:mm:ss")
		TextBox_AlertLast.Text = MainForm.AlertTimeLast.ToString("HH:mm:ss")
		TextBox_AlertEarliest.Text = MainForm.AlertTimeEarliest.ToString("HH:mm:ss")

		'次回チェック時刻を確認する
		If (MainForm.CheckTimeNext < DateTimeOffset.Now) Then Exit Sub '次回チェック時刻が現在時刻より遅い場合（タイミングによっては起こり得る）

		'次回チェック時刻までの間隔を計算する
		Dim checkTimeNextInterval As TimeSpan = MainForm.CheckTimeNext - DateTimeOffset.Now '次回チェック時刻までの間隔

		If (TimeSpan.Zero < checkTimeNextInterval) Then
			SetTextBoxInterval(TextBox_CheckNextInterval, checkTimeNextInterval)
		End If

		'実際の次回アラート時刻までの間隔を計算する
		Dim checkTiming As Integer = (DateTimeOffset.Now.Minute * 60 + DateTimeOffset.Now.Second) Mod
			(MainForm.TargetCompany.Interval * 60) '更新間隔刻みの時刻と現在時刻の差（秒）

		Dim checkTimeBase As DateTimeOffset = DateTimeOffset.Now.AddSeconds(checkTiming * -1) '未来のチェック時刻を計算するベースとなる時刻
		Dim checkTimeFuture As DateTimeOffset '未来のチェック時刻（次回アラート最早時刻以降になれば実際の次回アラート時刻になる）

		For i = 0 To 60 '更新間隔が最短1分と仮定した場合の60分間の最大チェック回数
			checkTimeFuture = checkTimeBase.AddMinutes(MainForm.TargetCompany.Interval * i).AddSeconds(MainForm.TargetCompany.Offset)

			If (MainForm.AlertTimeEarliest <= checkTimeFuture) Then Exit For 'checkTimeFutureが次回アラート最早時刻以降になれば終了
		Next

		If (checkTimeFuture < MainForm.CheckTimeNext) Then 'checkTimeFutureを次回チェック時刻が過ぎた場合（checkTimeFutureの時刻にアラートが出てなければそうなる）
			checkTimeFuture = MainForm.CheckTimeNext '次回チェック時刻に合わせる
		End If

		Dim alertTimeNextInterval As TimeSpan = checkTimeFuture - DateTimeOffset.Now '実際の次回アラート時刻までの間隔

		If (TimeSpan.Zero < alertTimeNextInterval) Then
			SetTextBoxInterval(TextBox_AlertNextInterval, alertTimeNextInterval)

			Dim alertTimeNextRate As Double = alertTimeNextInterval.TotalSeconds /
				(checkTimeFuture - MainForm.AlertTimeLast).TotalSeconds '実際の次回アラート時刻までの間隔の、前回アラート時刻と実際の次回アラート時刻の間隔に対する割合

			ProgressBar_Alert.Value = Convert.ToInt32(Math.Round(alertTimeNextRate * 100))
		End If
	End Sub

	Private Sub SetTextBoxInterval(target As TextBox, interval As TimeSpan)
		target.Text = $"{interval.Minutes:00}:{interval.Seconds:00}"

		If (interval < TimeSpan.Parse("0:0:11")) Then
			target.BackColor = Color.FromArgb(230, 142, 215)
		ElseIf (interval < TimeSpan.Parse("0:1:1")) Then
			target.BackColor = Color.FromArgb(241, 227, 0)
		Else
			target.BackColor = Color.FromArgb(240, 240, 240)
		End If
	End Sub

#End Region

#Region "Misc Management"

	'MainFormの移動に追随する
	Friend Sub AdjustLocation()
		Me.Location = New Point(MainForm.Bounds.Location.X, MainForm.Bounds.Location.Y + 210) '位置をMainFormの直下に設定
	End Sub

#End Region

#Region "Close"

	Private Sub InfoInternal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		MainForm.InfoInternal_ToolStripMenuItem.Enabled = True

		CheckTimer.Enabled = False
	End Sub

#End Region

End Class