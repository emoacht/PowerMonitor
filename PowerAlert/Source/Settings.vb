Imports System.IO
Imports System.Threading.Tasks
Imports System.Xml.Serialization

Public Class Settings

	Private Sub New()
	End Sub

	Friend Shared ReadOnly Property Current As New Settings()

#Region "Settings"

	''' <summary>
	''' 対象の電力会社の選択
	''' </summary>
	Public Property TargetCompanyIndex As Integer = 0

	''' <summary>
	''' アラート間隔の選択（分）
	''' </summary>
	Public Property AlertInterval As Integer = 30

	''' <summary>
	''' 使用率の閾値の選択（％）
	''' </summary>
	Public Property AlertThreshold As Integer = 85

	''' <summary>
	''' スタートアップに登録しているかどうかの状態
	''' </summary>
	Public Property IsStartupRegistered As Boolean

	''' <summary>
	''' アラート音の音声ファイルのパス
	''' </summary>
	Public Property AudioFilePath As String

	''' <summary>
	''' MainFormを表示しているかどうかの状態
	''' </summary>
	Public Property IsWindowShown As Boolean = True

#End Region

#Region "Load/Save"

	Private Const settingsFileName As String = "settings.xml" '設定ファイルのファイル名

	''' <summary>
	''' 設定ファイルを読み込む
	''' </summary>
	''' <returns>設定ファイルが既に存在し、読み込んだ場合はTrue、それ以外はFalse</returns>
	Friend Shared Async Function LoadAsync() As Task(Of Boolean)
		Dim filePath As String = Path.Combine(Application.StartupPath, settingsFileName)
		If (Not File.Exists(filePath)) Then Return False

		Dim serializer As New XmlSerializer(GetType(Settings))

		Try
			Using fs As New FileStream(filePath, FileMode.Open)
				Using ms As New MemoryStream()
					Await fs.CopyToAsync(ms)
					ms.Seek(0, SeekOrigin.Begin)

					_Current = DirectCast(serializer.Deserialize(ms), Settings)
					Return True
				End Using
			End Using

		Catch ex As Exception
			Debug.WriteLine(ex)
			Return False
		End Try
	End Function

	''' <summary>
	''' 設定ファイルを書き込む
	''' </summary>
	Friend Shared Async Function SaveAsync() As Task
		Dim serializer As New XmlSerializer(GetType(Settings))

		Try
			Using stream As New FileStream(Path.Combine(Application.StartupPath, settingsFileName), FileMode.Create)
				serializer.Serialize(stream, _Current)
				Await stream.FlushAsync()
			End Using

		Catch ex As Exception
			Debug.WriteLine(ex)
		End Try
	End Function

#End Region

End Class