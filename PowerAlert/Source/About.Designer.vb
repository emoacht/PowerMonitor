<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label_ProductName = New System.Windows.Forms.Label()
        Me.Label_Copyright = New System.Windows.Forms.Label()
        Me.Button_OK = New System.Windows.Forms.Button()
        Me.Panel_Color = New System.Windows.Forms.Panel()
        Me.Label_ProductVersion = New System.Windows.Forms.Label()
        Me.Panel_Color.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label_ProductName
        '
        Me.Label_ProductName.AutoSize = True
        Me.Label_ProductName.BackColor = System.Drawing.Color.Transparent
        Me.Label_ProductName.Font = New System.Drawing.Font("Meiryo", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_ProductName.Location = New System.Drawing.Point(10, 12)
        Me.Label_ProductName.Name = "Label_ProductName"
        Me.Label_ProductName.Size = New System.Drawing.Size(155, 28)
        Me.Label_ProductName.TabIndex = 0
        Me.Label_ProductName.Text = "Product Name"
        '
        'Label_Copyright
        '
        Me.Label_Copyright.AutoSize = True
        Me.Label_Copyright.BackColor = System.Drawing.Color.Transparent
        Me.Label_Copyright.Font = New System.Drawing.Font("Meiryo", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_Copyright.Location = New System.Drawing.Point(14, 72)
        Me.Label_Copyright.Name = "Label_Copyright"
        Me.Label_Copyright.Size = New System.Drawing.Size(64, 18)
        Me.Label_Copyright.TabIndex = 2
        Me.Label_Copyright.Text = "Copyright"
        '
        'Button_OK
        '
        Me.Button_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_OK.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button_OK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_OK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_OK.Font = New System.Drawing.Font("Meiryo", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_OK.Location = New System.Drawing.Point(111, 108)
        Me.Button_OK.Name = "Button_OK"
        Me.Button_OK.Size = New System.Drawing.Size(80, 26)
        Me.Button_OK.TabIndex = 0
        Me.Button_OK.Text = "OK"
        Me.Button_OK.UseVisualStyleBackColor = False
        '
        'Panel_Color
        '
        Me.Panel_Color.BackgroundImage = Global.PowerAlert.My.Resources.Resources.colorchart
        Me.Panel_Color.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Color.Controls.Add(Me.Label_ProductVersion)
        Me.Panel_Color.Controls.Add(Me.Label_ProductName)
        Me.Panel_Color.Controls.Add(Me.Label_Copyright)
        Me.Panel_Color.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Color.Name = "Panel_Color"
        Me.Panel_Color.Size = New System.Drawing.Size(200, 99)
        Me.Panel_Color.TabIndex = 1
        '
        'Label_ProductVersion
        '
        Me.Label_ProductVersion.AutoSize = True
        Me.Label_ProductVersion.BackColor = System.Drawing.Color.Transparent
        Me.Label_ProductVersion.Font = New System.Drawing.Font("Meiryo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_ProductVersion.Location = New System.Drawing.Point(12, 40)
        Me.Label_ProductVersion.Name = "Label_ProductVersion"
        Me.Label_ProductVersion.Size = New System.Drawing.Size(146, 24)
        Me.Label_ProductVersion.TabIndex = 1
        Me.Label_ProductVersion.Text = "Product Version"
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(200, 143)
        Me.Controls.Add(Me.Button_OK)
        Me.Controls.Add(Me.Panel_Color)
        Me.Font = New System.Drawing.Font("Meiryo", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel_Color.ResumeLayout(False)
        Me.Panel_Color.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label_ProductName As System.Windows.Forms.Label
    Friend WithEvents Label_Copyright As System.Windows.Forms.Label
    Friend WithEvents Button_OK As System.Windows.Forms.Button
    Friend WithEvents Panel_Color As System.Windows.Forms.Panel
    Friend WithEvents Label_ProductVersion As System.Windows.Forms.Label

End Class
