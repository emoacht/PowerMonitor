<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfoMonitorForm
	Inherits System.Windows.Forms.Form

	'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Windows フォーム デザイナーで必要です。
	Private components As System.ComponentModel.IContainer

	'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
	'Windows フォーム デザイナーを使用して変更できます。  
	'コード エディターを使って変更しないでください。
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim ListViewItem25 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("1")
		Dim ListViewItem26 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("2")
		Dim ListViewItem27 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("3")
		Dim ListViewItem28 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("4")
		Dim ListViewItem29 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("5")
		Dim ListViewItem30 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("6")
		Me.ListView_UpdateTime = New System.Windows.Forms.ListView()
		Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.Button_Start = New System.Windows.Forms.Button()
		Me.Button_Stop = New System.Windows.Forms.Button()
		Me.TextBox_Company = New System.Windows.Forms.TextBox()
		Me.TextBox_RemainingTime = New System.Windows.Forms.TextBox()
		Me.Label_RemainingTime = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'ListView_UpdateTime
		'
		Me.ListView_UpdateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.ListView_UpdateTime.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
		Me.ListView_UpdateTime.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.ListView_UpdateTime.GridLines = True
		Me.ListView_UpdateTime.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
		ListViewItem26.IndentCount = 1
		ListViewItem27.IndentCount = 2
		ListViewItem28.IndentCount = 3
		ListViewItem29.IndentCount = 4
		ListViewItem30.IndentCount = 5
		Me.ListView_UpdateTime.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem25, ListViewItem26, ListViewItem27, ListViewItem28, ListViewItem29, ListViewItem30})
		Me.ListView_UpdateTime.Location = New System.Drawing.Point(5, 35)
		Me.ListView_UpdateTime.Name = "ListView_UpdateTime"
		Me.ListView_UpdateTime.Size = New System.Drawing.Size(264, 132)
		Me.ListView_UpdateTime.TabIndex = 5
		Me.ListView_UpdateTime.TabStop = False
		Me.ListView_UpdateTime.UseCompatibleStateImageBehavior = False
		Me.ListView_UpdateTime.View = System.Windows.Forms.View.Details
		'
		'ColumnHeader1
		'
		Me.ColumnHeader1.Text = "回"
		Me.ColumnHeader1.Width = 26
		'
		'ColumnHeader2
		'
		Me.ColumnHeader2.Text = "更新時刻"
		Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.ColumnHeader2.Width = 66
		'
		'ColumnHeader3
		'
		Me.ColumnHeader3.Text = "差"
		Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.ColumnHeader3.Width = 34
		'
		'ColumnHeader4
		'
		Me.ColumnHeader4.Text = "UPDATE"
		Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'ColumnHeader5
		'
		Me.ColumnHeader5.Text = "データ"
		Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.ColumnHeader5.Width = 56
		'
		'Button_Start
		'
		Me.Button_Start.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.Button_Start.Location = New System.Drawing.Point(5, 4)
		Me.Button_Start.Name = "Button_Start"
		Me.Button_Start.Size = New System.Drawing.Size(40, 26)
		Me.Button_Start.TabIndex = 0
		Me.Button_Start.Text = "開始"
		Me.Button_Start.UseVisualStyleBackColor = True
		'
		'Button_Stop
		'
		Me.Button_Stop.Enabled = False
		Me.Button_Stop.FlatStyle = System.Windows.Forms.FlatStyle.System
		Me.Button_Stop.Location = New System.Drawing.Point(51, 4)
		Me.Button_Stop.Name = "Button_Stop"
		Me.Button_Stop.Size = New System.Drawing.Size(40, 26)
		Me.Button_Stop.TabIndex = 1
		Me.Button_Stop.Text = "停止"
		Me.Button_Stop.UseVisualStyleBackColor = True
		'
		'TextBox_Company
		'
		Me.TextBox_Company.BackColor = System.Drawing.SystemColors.ControlLightLight
		Me.TextBox_Company.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TextBox_Company.Cursor = System.Windows.Forms.Cursors.Default
		Me.TextBox_Company.Location = New System.Drawing.Point(101, 9)
		Me.TextBox_Company.Name = "TextBox_Company"
		Me.TextBox_Company.ReadOnly = True
		Me.TextBox_Company.Size = New System.Drawing.Size(66, 18)
		Me.TextBox_Company.TabIndex = 6
		Me.TextBox_Company.TabStop = False
		'
		'TextBox_RemainingTime
		'
		Me.TextBox_RemainingTime.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TextBox_RemainingTime.Cursor = System.Windows.Forms.Cursors.Default
		Me.TextBox_RemainingTime.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.TextBox_RemainingTime.Location = New System.Drawing.Point(224, 7)
		Me.TextBox_RemainingTime.Name = "TextBox_RemainingTime"
		Me.TextBox_RemainingTime.ReadOnly = True
		Me.TextBox_RemainingTime.Size = New System.Drawing.Size(44, 20)
		Me.TextBox_RemainingTime.TabIndex = 3
		Me.TextBox_RemainingTime.TabStop = False
		Me.TextBox_RemainingTime.Text = "30:00"
		Me.TextBox_RemainingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Label_RemainingTime
		'
		Me.Label_RemainingTime.AutoSize = True
		Me.Label_RemainingTime.Font = New System.Drawing.Font("メイリオ", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.Label_RemainingTime.Location = New System.Drawing.Point(171, 9)
		Me.Label_RemainingTime.Name = "Label_RemainingTime"
		Me.Label_RemainingTime.Size = New System.Drawing.Size(52, 17)
		Me.Label_RemainingTime.TabIndex = 2
		Me.Label_RemainingTime.Text = "残り時間"
		'
		'InfoMonitorForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.BackColor = System.Drawing.SystemColors.ControlLightLight
		Me.ClientSize = New System.Drawing.Size(274, 171)
		Me.Controls.Add(Me.TextBox_Company)
		Me.Controls.Add(Me.TextBox_RemainingTime)
		Me.Controls.Add(Me.Label_RemainingTime)
		Me.Controls.Add(Me.Button_Stop)
		Me.Controls.Add(Me.Button_Start)
		Me.Controls.Add(Me.ListView_UpdateTime)
		Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "InfoMonitorForm"
		Me.ShowIcon = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "更新状況"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents ListView_UpdateTime As System.Windows.Forms.ListView
	Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
	Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
	Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
	Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
	Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
	Friend WithEvents Button_Start As System.Windows.Forms.Button
	Friend WithEvents Button_Stop As System.Windows.Forms.Button
	Friend WithEvents TextBox_Company As System.Windows.Forms.TextBox
	Friend WithEvents TextBox_RemainingTime As System.Windows.Forms.TextBox
	Friend WithEvents Label_RemainingTime As System.Windows.Forms.Label
End Class
