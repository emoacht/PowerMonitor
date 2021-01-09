Public NotInheritable Class About

	Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.Label_ProductName.Text = My.Application.Info.ProductName
		Me.Label_ProductVersion.Text = My.Application.Info.Version.ToString()
		Me.Label_Copyright.Text = My.Application.Info.Copyright
	End Sub

End Class