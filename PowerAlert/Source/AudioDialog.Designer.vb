<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AudioDialog
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
        Me.RadioButton_AudioFile = New System.Windows.Forms.RadioButton()
        Me.RadioButton_SystemSound = New System.Windows.Forms.RadioButton()
        Me.Button_OK = New System.Windows.Forms.Button()
        Me.TextBox_AudioFile = New System.Windows.Forms.TextBox()
        Me.Button_Browse = New System.Windows.Forms.Button()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.Panel_Control = New System.Windows.Forms.Panel()
        Me.GroupBox_AudioFile = New System.Windows.Forms.GroupBox()
        Me.Panel_Control.SuspendLayout()
        Me.GroupBox_AudioFile.SuspendLayout()
        Me.SuspendLayout()
        '
        'RadioButton_AudioFile
        '
        Me.RadioButton_AudioFile.AutoSize = True
        Me.RadioButton_AudioFile.Location = New System.Drawing.Point(10, 36)
        Me.RadioButton_AudioFile.Name = "RadioButton_AudioFile"
        Me.RadioButton_AudioFile.Size = New System.Drawing.Size(158, 22)
        Me.RadioButton_AudioFile.TabIndex = 1
        Me.RadioButton_AudioFile.TabStop = True
        Me.RadioButton_AudioFile.Text = "音声ファイルを再生する"
        Me.RadioButton_AudioFile.UseVisualStyleBackColor = True
        '
        'RadioButton_SystemSound
        '
        Me.RadioButton_SystemSound.AutoSize = True
        Me.RadioButton_SystemSound.Checked = True
        Me.RadioButton_SystemSound.Location = New System.Drawing.Point(10, 12)
        Me.RadioButton_SystemSound.Name = "RadioButton_SystemSound"
        Me.RadioButton_SystemSound.Size = New System.Drawing.Size(158, 22)
        Me.RadioButton_SystemSound.TabIndex = 0
        Me.RadioButton_SystemSound.TabStop = True
        Me.RadioButton_SystemSound.Text = "システム警告音を鳴らす"
        Me.RadioButton_SystemSound.UseVisualStyleBackColor = True
        '
        'Button_OK
        '
        Me.Button_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_OK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_OK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_OK.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_OK.Location = New System.Drawing.Point(97, 9)
        Me.Button_OK.Name = "Button_OK"
        Me.Button_OK.Size = New System.Drawing.Size(80, 26)
        Me.Button_OK.TabIndex = 0
        Me.Button_OK.Text = "OK"
        Me.Button_OK.UseVisualStyleBackColor = True
        '
        'TextBox_AudioFile
        '
        Me.TextBox_AudioFile.Location = New System.Drawing.Point(10, 23)
        Me.TextBox_AudioFile.Name = "TextBox_AudioFile"
        Me.TextBox_AudioFile.Size = New System.Drawing.Size(180, 25)
        Me.TextBox_AudioFile.TabIndex = 0
        '
        'Button_Browse
        '
        Me.Button_Browse.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_Browse.Location = New System.Drawing.Point(195, 22)
        Me.Button_Browse.Name = "Button_Browse"
        Me.Button_Browse.Size = New System.Drawing.Size(50, 27)
        Me.Button_Browse.TabIndex = 1
        Me.Button_Browse.Text = "参照"
        Me.Button_Browse.UseVisualStyleBackColor = True
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_Cancel.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Cancel.Location = New System.Drawing.Point(185, 9)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(80, 26)
        Me.Button_Cancel.TabIndex = 1
        Me.Button_Cancel.Text = "キャンセル"
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'Panel_Control
        '
        Me.Panel_Control.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel_Control.BackColor = System.Drawing.SystemColors.Control
        Me.Panel_Control.Controls.Add(Me.Button_Cancel)
        Me.Panel_Control.Controls.Add(Me.Button_OK)
        Me.Panel_Control.Location = New System.Drawing.Point(0, 127)
        Me.Panel_Control.Name = "Panel_Control"
        Me.Panel_Control.Size = New System.Drawing.Size(274, 44)
        Me.Panel_Control.TabIndex = 3
        '
        'GroupBox_AudioFile
        '
        Me.GroupBox_AudioFile.Controls.Add(Me.TextBox_AudioFile)
        Me.GroupBox_AudioFile.Controls.Add(Me.Button_Browse)
        Me.GroupBox_AudioFile.Enabled = False
        Me.GroupBox_AudioFile.Location = New System.Drawing.Point(10, 60)
        Me.GroupBox_AudioFile.Name = "GroupBox_AudioFile"
        Me.GroupBox_AudioFile.Size = New System.Drawing.Size(254, 58)
        Me.GroupBox_AudioFile.TabIndex = 2
        Me.GroupBox_AudioFile.TabStop = False
        Me.GroupBox_AudioFile.Text = "音声ファイル"
        '
        'AudioDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(274, 171)
        Me.Controls.Add(Me.GroupBox_AudioFile)
        Me.Controls.Add(Me.RadioButton_SystemSound)
        Me.Controls.Add(Me.RadioButton_AudioFile)
        Me.Controls.Add(Me.Panel_Control)
        Me.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AudioDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "アラート音の設定"
        Me.Panel_Control.ResumeLayout(False)
        Me.GroupBox_AudioFile.ResumeLayout(False)
        Me.GroupBox_AudioFile.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioButton_AudioFile As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton_SystemSound As System.Windows.Forms.RadioButton
    Friend WithEvents Button_OK As System.Windows.Forms.Button
    Friend WithEvents TextBox_AudioFile As System.Windows.Forms.TextBox
    Friend WithEvents Button_Browse As System.Windows.Forms.Button
    Friend WithEvents Button_Cancel As System.Windows.Forms.Button
    Friend WithEvents Panel_Control As System.Windows.Forms.Panel
    Friend WithEvents GroupBox_AudioFile As System.Windows.Forms.GroupBox
End Class
