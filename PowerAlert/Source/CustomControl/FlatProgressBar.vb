''' <summary>
''' ProgressBar of flat face
''' </summary>
''' <remarks>This Control will not work properly when Visual style is not enabled.</remarks>
Public Class FlatProgressBar
	Inherits ProgressBar

	Public Sub New()
		If ProgressBarRenderer.IsSupported Then Me.SetStyle(ControlStyles.UserPaint, True)
	End Sub

	Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
		'None (To avoid background being painted so as to prevent flickering)
	End Sub

	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		Using offscreen As Image = New Bitmap(Me.Width, Me.Height)
			Using g As Graphics = Graphics.FromImage(offscreen)
				'=========
				' Outline
				'=========
				Dim rectBase As New Rectangle(Point.Empty, Me.Size)

				'Draw outline of standard ProgressBar
				If ProgressBarRenderer.IsSupported Then ProgressBarRenderer.DrawHorizontalBar(g, rectBase)

				'===========================================
				' Background bar (to overwrite vacant area)
				'===========================================
				Dim rectVacant As Rectangle = Rectangle.Inflate(rectBase, -2, -2) '-2 is not to overwrite outline

				'Draw vacant area with Me.BackColor
				Using brush As New SolidBrush(Me.BackColor)
					g.FillRectangle(brush, rectVacant)
				End Using

				'==========
				' Main bar
				'==========
				Dim rectMain As Rectangle = Rectangle.Inflate(rectBase, -1, -1)	'-1 is not to overwrite outline
				Dim rectMainMax As Integer = rectMain.Width

				'Adjust length of bar according to Value
				rectMain.Width = Convert.ToInt32(Math.Truncate(rectMain.Width * Me.Value / Me.Maximum))

				'Draw bar with Me.ForeColor
				Using brush As New SolidBrush(Me.ForeColor)
					g.FillRectangle(brush, rectMain)
				End Using

				'Draw right edge
				If (0 < rectMain.Width) AndAlso (rectMain.Width < rectMainMax) Then
					Using penEdge As New Pen(Color.FromArgb(204, 204, 204))
						g.DrawLines(penEdge, New Point() {New Point(rectMain.Width + 1, 1),
														  New Point(rectMain.Width + 1, rectMain.Height)})
					End Using
				End If

				'==================
				' Reflect in image
				'==================
				e.Graphics.DrawImage(offscreen, Point.Empty)
			End Using
		End Using
	End Sub

End Class