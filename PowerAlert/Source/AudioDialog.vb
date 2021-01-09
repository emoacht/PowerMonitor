Imports System.IO

Public Class AudioDialog

	Private closeObjection As Boolean 'このフォームを閉じるのに問題があるかどうかの状態

	Private Sub AudioDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'音声ファイルが存在するか確認する
		If (File.Exists(Settings.Current.AudioFilePath)) Then
			TextBox_AudioFile.Text = Settings.Current.AudioFilePath
			RadioButton_AudioFile.Checked = True
		End If
	End Sub

	Private Sub RadioButton_AudioFile_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_AudioFile.CheckedChanged
		GroupBox_AudioFile.Enabled = RadioButton_AudioFile.Checked
	End Sub

	Private Sub Button_Browse_Click(sender As Object, e As EventArgs) Handles Button_Browse.Click
		Dim startPath As String = If(Not String.IsNullOrEmpty(Settings.Current.AudioFilePath),
									 Path.GetDirectoryName(Settings.Current.AudioFilePath),
									 Directory.GetDirectoryRoot(Application.StartupPath))

		'音声ファイルのパスの入力
		Using ofd As New OpenFileDialog With {.InitialDirectory = startPath,
											  .Filter = "|*.mp3;*.wma;*.wav;*.mid||*.*"}

			If (ofd.ShowDialog() = DialogResult.OK) Then
				TextBox_AudioFile.Text = ofd.FileName
			End If
		End Using
	End Sub

	Private Sub Button_OK_Click(sender As Object, e As EventArgs) Handles Button_OK.Click
		'音声ファイルのパスを保存する
		If (RadioButton_AudioFile.Checked AndAlso
			Not String.IsNullOrEmpty(TextBox_AudioFile.Text)) Then
			If (File.Exists(TextBox_AudioFile.Text)) Then
				Settings.Current.AudioFilePath = TextBox_AudioFile.Text
			Else
				MessageBox.Show("指定されたファイルが見つかりません。",
								My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
				closeObjection = True
			End If
		Else
			Settings.Current.AudioFilePath = String.Empty
		End If
	End Sub

	Private Sub AudioDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		'このフォームを閉じるのに問題があるか確認する
		If (closeObjection) Then
			closeObjection = False

			e.Cancel = True
		End If
	End Sub

End Class