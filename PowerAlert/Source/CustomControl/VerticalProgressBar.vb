''' <summary>
''' Vertical ProgressBar
''' </summary>
Public Class VerticalProgressBar
	Inherits ProgressBar

	Private Const PBS_VERTICAL As Integer = &H4 'Progress Bar Control Styles for vertical progress bar

	Protected Overrides ReadOnly Property CreateParams() As CreateParams
		Get
			Dim cp As CreateParams = MyBase.CreateParams
			cp.Style = cp.Style Or PBS_VERTICAL

			Return cp
		End Get
	End Property

End Class