''' <summary>
''' ProgressBar of automatic increment/decrement
''' </summary>
Public Class IncrementProgressBar
	Inherits ProgressBar

	''' <summary>
	''' Interval of increment/decrement (msec)
	''' </summary>
	Public Property Interval As Integer

	''' <summary>
	''' Target value for increment/decrement
	''' </summary>
	Public Property TargetValue As Integer
		Get
			Return _targetValue
		End Get
		Set(value As Integer)
			_targetValue = value

			If ((Me.Value <> TargetValue) AndAlso Me.Visible AndAlso (0 < Interval)) Then
				StartIncrement()
			End If
		End Set
	End Property
	Private _targetValue As Integer

	Private IncrementTimer As Windows.Forms.Timer

	Private Sub StartIncrement()
		If (IncrementTimer IsNot Nothing) Then
			IncrementTimer.Enabled = False
		Else
			IncrementTimer = New Windows.Forms.Timer()
			AddHandler IncrementTimer.Tick, AddressOf IncrementTimer_Tick
		End If

		IncrementTimer.Interval = Interval
		IncrementTimer.Enabled = True
	End Sub

	Private Sub IncrementTimer_Tick(sender As Object, e As EventArgs)
		IncrementTimer.Enabled = False

		If (TargetValue < Me.Value) Then
			If (Me.Minimum <= Me.Value - 1) Then
				Me.Value -= 1
			End If

			If (Me.Minimum = Me.Value) Then Exit Sub

		ElseIf (Me.Value < TargetValue) Then
			If (Me.Value + 1 <= Me.Maximum) Then
				Me.Value += 1
			End If

			If (Me.Value = Me.Maximum) Then Exit Sub
		End If

		If ((Me.Value <> TargetValue) AndAlso Me.Visible) Then IncrementTimer.Enabled = True
	End Sub

End Class