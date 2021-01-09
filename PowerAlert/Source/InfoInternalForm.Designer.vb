<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InfoInternalForm
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
        Me.Label_CheckLast = New System.Windows.Forms.Label()
        Me.Label_CheckNext = New System.Windows.Forms.Label()
        Me.Label_AlertLast = New System.Windows.Forms.Label()
        Me.Label_AlertNext = New System.Windows.Forms.Label()
        Me.TextBox_CheckLast = New System.Windows.Forms.TextBox()
        Me.TextBox_CheckNext = New System.Windows.Forms.TextBox()
        Me.TextBox_AlertLast = New System.Windows.Forms.TextBox()
        Me.TextBox_AlertEarliest = New System.Windows.Forms.TextBox()
        Me.TextBox_CheckNextInterval = New System.Windows.Forms.TextBox()
        Me.TextBox_AlertNextInterval = New System.Windows.Forms.TextBox()
        Me.Label_IntervalCheckNext = New System.Windows.Forms.Label()
        Me.Label_IntervalAlertNext = New System.Windows.Forms.Label()
        Me.GroupBox_Check = New System.Windows.Forms.GroupBox()
        Me.GroupBox_Alert = New System.Windows.Forms.GroupBox()
        Me.ProgressBar_Alert = New PowerAlert.VerticalProgressBar()
        Me.GroupBox_Check.SuspendLayout()
        Me.GroupBox_Alert.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label_CheckLast
        '
        Me.Label_CheckLast.AutoSize = True
        Me.Label_CheckLast.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_CheckLast.Location = New System.Drawing.Point(2, 17)
        Me.Label_CheckLast.Name = "Label_CheckLast"
        Me.Label_CheckLast.Size = New System.Drawing.Size(30, 17)
        Me.Label_CheckLast.TabIndex = 0
        Me.Label_CheckLast.Text = "前回"
        '
        'Label_CheckNext
        '
        Me.Label_CheckNext.AutoSize = True
        Me.Label_CheckNext.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_CheckNext.Location = New System.Drawing.Point(2, 37)
        Me.Label_CheckNext.Name = "Label_CheckNext"
        Me.Label_CheckNext.Size = New System.Drawing.Size(30, 17)
        Me.Label_CheckNext.TabIndex = 3
        Me.Label_CheckNext.Text = "次回"
        '
        'Label_AlertLast
        '
        Me.Label_AlertLast.AutoSize = True
        Me.Label_AlertLast.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_AlertLast.Location = New System.Drawing.Point(2, 17)
        Me.Label_AlertLast.Name = "Label_AlertLast"
        Me.Label_AlertLast.Size = New System.Drawing.Size(30, 17)
        Me.Label_AlertLast.TabIndex = 0
        Me.Label_AlertLast.Text = "前回"
        '
        'Label_AlertNext
        '
        Me.Label_AlertNext.AutoSize = True
        Me.Label_AlertNext.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_AlertNext.Location = New System.Drawing.Point(2, 37)
        Me.Label_AlertNext.Name = "Label_AlertNext"
        Me.Label_AlertNext.Size = New System.Drawing.Size(52, 17)
        Me.Label_AlertNext.TabIndex = 2
        Me.Label_AlertNext.Text = "次回最早"
        '
        'TextBox_CheckLast
        '
        Me.TextBox_CheckLast.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_CheckLast.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox_CheckLast.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_CheckLast.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox_CheckLast.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_CheckLast.Location = New System.Drawing.Point(60, 17)
        Me.TextBox_CheckLast.Name = "TextBox_CheckLast"
        Me.TextBox_CheckLast.ReadOnly = True
        Me.TextBox_CheckLast.Size = New System.Drawing.Size(55, 17)
        Me.TextBox_CheckLast.TabIndex = 2
        Me.TextBox_CheckLast.TabStop = False
        Me.TextBox_CheckLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_CheckNext
        '
        Me.TextBox_CheckNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_CheckNext.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox_CheckNext.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_CheckNext.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox_CheckNext.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_CheckNext.Location = New System.Drawing.Point(60, 37)
        Me.TextBox_CheckNext.Name = "TextBox_CheckNext"
        Me.TextBox_CheckNext.ReadOnly = True
        Me.TextBox_CheckNext.Size = New System.Drawing.Size(55, 17)
        Me.TextBox_CheckNext.TabIndex = 4
        Me.TextBox_CheckNext.TabStop = False
        Me.TextBox_CheckNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_AlertLast
        '
        Me.TextBox_AlertLast.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_AlertLast.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox_AlertLast.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_AlertLast.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox_AlertLast.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_AlertLast.Location = New System.Drawing.Point(61, 17)
        Me.TextBox_AlertLast.Name = "TextBox_AlertLast"
        Me.TextBox_AlertLast.ReadOnly = True
        Me.TextBox_AlertLast.Size = New System.Drawing.Size(55, 17)
        Me.TextBox_AlertLast.TabIndex = 1
        Me.TextBox_AlertLast.TabStop = False
        Me.TextBox_AlertLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_AlertEarliest
        '
        Me.TextBox_AlertEarliest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_AlertEarliest.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox_AlertEarliest.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_AlertEarliest.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox_AlertEarliest.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_AlertEarliest.Location = New System.Drawing.Point(61, 37)
        Me.TextBox_AlertEarliest.Name = "TextBox_AlertEarliest"
        Me.TextBox_AlertEarliest.ReadOnly = True
        Me.TextBox_AlertEarliest.Size = New System.Drawing.Size(55, 17)
        Me.TextBox_AlertEarliest.TabIndex = 3
        Me.TextBox_AlertEarliest.TabStop = False
        Me.TextBox_AlertEarliest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_CheckNextInterval
        '
        Me.TextBox_CheckNextInterval.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_CheckNextInterval.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox_CheckNextInterval.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_CheckNextInterval.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox_CheckNextInterval.Font = New System.Drawing.Font("Meiryo", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_CheckNextInterval.Location = New System.Drawing.Point(60, 57)
        Me.TextBox_CheckNextInterval.Name = "TextBox_CheckNextInterval"
        Me.TextBox_CheckNextInterval.ReadOnly = True
        Me.TextBox_CheckNextInterval.Size = New System.Drawing.Size(55, 24)
        Me.TextBox_CheckNextInterval.TabIndex = 6
        Me.TextBox_CheckNextInterval.TabStop = False
        Me.TextBox_CheckNextInterval.Text = "00:00"
        Me.TextBox_CheckNextInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_AlertNextInterval
        '
        Me.TextBox_AlertNextInterval.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_AlertNextInterval.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox_AlertNextInterval.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_AlertNextInterval.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox_AlertNextInterval.Font = New System.Drawing.Font("Meiryo", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_AlertNextInterval.Location = New System.Drawing.Point(61, 57)
        Me.TextBox_AlertNextInterval.Name = "TextBox_AlertNextInterval"
        Me.TextBox_AlertNextInterval.ReadOnly = True
        Me.TextBox_AlertNextInterval.Size = New System.Drawing.Size(55, 24)
        Me.TextBox_AlertNextInterval.TabIndex = 5
        Me.TextBox_AlertNextInterval.TabStop = False
        Me.TextBox_AlertNextInterval.Text = "00:00"
        Me.TextBox_AlertNextInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_IntervalCheckNext
        '
        Me.Label_IntervalCheckNext.AutoSize = True
        Me.Label_IntervalCheckNext.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_IntervalCheckNext.Location = New System.Drawing.Point(2, 62)
        Me.Label_IntervalCheckNext.Name = "Label_IntervalCheckNext"
        Me.Label_IntervalCheckNext.Size = New System.Drawing.Size(52, 17)
        Me.Label_IntervalCheckNext.TabIndex = 5
        Me.Label_IntervalCheckNext.Text = "次回まで"
        '
        'Label_IntervalAlertNext
        '
        Me.Label_IntervalAlertNext.AutoSize = True
        Me.Label_IntervalAlertNext.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_IntervalAlertNext.Location = New System.Drawing.Point(2, 62)
        Me.Label_IntervalAlertNext.Name = "Label_IntervalAlertNext"
        Me.Label_IntervalAlertNext.Size = New System.Drawing.Size(52, 17)
        Me.Label_IntervalAlertNext.TabIndex = 4
        Me.Label_IntervalAlertNext.Text = "次回まで"
        '
        'GroupBox_Check
        '
        Me.GroupBox_Check.Controls.Add(Me.TextBox_CheckLast)
        Me.GroupBox_Check.Controls.Add(Me.Label_CheckLast)
        Me.GroupBox_Check.Controls.Add(Me.Label_CheckNext)
        Me.GroupBox_Check.Controls.Add(Me.TextBox_CheckNextInterval)
        Me.GroupBox_Check.Controls.Add(Me.Label_IntervalCheckNext)
        Me.GroupBox_Check.Controls.Add(Me.TextBox_CheckNext)
        Me.GroupBox_Check.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox_Check.Location = New System.Drawing.Point(5, 1)
        Me.GroupBox_Check.Name = "GroupBox_Check"
        Me.GroupBox_Check.Size = New System.Drawing.Size(122, 87)
        Me.GroupBox_Check.TabIndex = 0
        Me.GroupBox_Check.TabStop = False
        Me.GroupBox_Check.Text = "チェック"
        '
        'GroupBox_Alert
        '
        Me.GroupBox_Alert.Controls.Add(Me.ProgressBar_Alert)
        Me.GroupBox_Alert.Controls.Add(Me.TextBox_AlertLast)
        Me.GroupBox_Alert.Controls.Add(Me.TextBox_AlertEarliest)
        Me.GroupBox_Alert.Controls.Add(Me.Label_AlertLast)
        Me.GroupBox_Alert.Controls.Add(Me.Label_AlertNext)
        Me.GroupBox_Alert.Controls.Add(Me.TextBox_AlertNextInterval)
        Me.GroupBox_Alert.Controls.Add(Me.Label_IntervalAlertNext)
        Me.GroupBox_Alert.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox_Alert.Location = New System.Drawing.Point(131, 1)
        Me.GroupBox_Alert.Name = "GroupBox_Alert"
        Me.GroupBox_Alert.Size = New System.Drawing.Size(139, 87)
        Me.GroupBox_Alert.TabIndex = 1
        Me.GroupBox_Alert.TabStop = False
        Me.GroupBox_Alert.Text = "アラート"
        '
        'ProgressBar_Alert
        '
        Me.ProgressBar_Alert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar_Alert.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ProgressBar_Alert.ForeColor = System.Drawing.Color.LimeGreen
        Me.ProgressBar_Alert.Location = New System.Drawing.Point(122, 18)
        Me.ProgressBar_Alert.Name = "ProgressBar_Alert"
        Me.ProgressBar_Alert.Size = New System.Drawing.Size(10, 63)
        Me.ProgressBar_Alert.TabIndex = 6
        '
        'InfoInternalForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(274, 91)
        Me.Controls.Add(Me.GroupBox_Alert)
        Me.Controls.Add(Me.GroupBox_Check)
        Me.Font = New System.Drawing.Font("Meiryo", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InfoInternalForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "内部時刻"
        Me.GroupBox_Check.ResumeLayout(False)
        Me.GroupBox_Check.PerformLayout()
        Me.GroupBox_Alert.ResumeLayout(False)
        Me.GroupBox_Alert.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label_CheckLast As System.Windows.Forms.Label
    Friend WithEvents Label_CheckNext As System.Windows.Forms.Label
    Friend WithEvents Label_AlertLast As System.Windows.Forms.Label
    Friend WithEvents Label_AlertNext As System.Windows.Forms.Label
    Friend WithEvents TextBox_CheckLast As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_CheckNext As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_AlertLast As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_AlertEarliest As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_CheckNextInterval As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_AlertNextInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label_IntervalCheckNext As System.Windows.Forms.Label
    Friend WithEvents Label_IntervalAlertNext As System.Windows.Forms.Label
    Friend WithEvents GroupBox_Check As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_Alert As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar_Alert As PowerAlert.VerticalProgressBar
End Class
