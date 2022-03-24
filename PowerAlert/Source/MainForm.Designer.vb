<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.TextBox_PeakSupply = New System.Windows.Forms.TextBox()
        Me.TextBox_UsageAmount = New System.Windows.Forms.TextBox()
        Me.TextBox_UsageRate = New System.Windows.Forms.TextBox()
        Me.Label_PeakSupply = New System.Windows.Forms.Label()
        Me.Label_UsageAmount = New System.Windows.Forms.Label()
        Me.Label_UsageRate = New System.Windows.Forms.Label()
        Me.Label_PeakSupplyUnit = New System.Windows.Forms.Label()
        Me.Label_UsageAmountUnit = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Settings_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Interval_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Threshold_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Audio_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Startup_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Help_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoInternal_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoMonitor_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMonitor_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.About_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComboBox_Companies = New System.Windows.Forms.ComboBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Open_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.End_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TextBox_UpDown = New System.Windows.Forms.TextBox()
        Me.TextBox_UsageRateUnit = New System.Windows.Forms.TextBox()
        Me.TextBox_Play = New System.Windows.Forms.TextBox()
        Me.Button_Check = New System.Windows.Forms.Button()
        Me.Button_Forecast = New System.Windows.Forms.Button()
        Me.ProgressBar_UsageRate = New PowerAlert.FlatProgressBar()
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Check
        '
        Me.Button_Check.BackColor = System.Drawing.SystemColors.Window
        Me.Button_Check.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_Check.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Check.Location = New System.Drawing.Point(179, 40)
        Me.Button_Check.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Check.Name = "Button_Check"
        Me.Button_Check.Size = New System.Drawing.Size(40, 23)
        Me.Button_Check.TabIndex = 1
        Me.Button_Check.Text = "更新"
        Me.Button_Check.UseVisualStyleBackColor = False
        '
        'Button_Forecast
        '
        Me.Button_Forecast.BackColor = System.Drawing.SystemColors.Window
        Me.Button_Forecast.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_Forecast.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button_Forecast.Location = New System.Drawing.Point(225, 40)
        Me.Button_Forecast.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button_Forecast.Name = "Button_Forecast"
        Me.Button_Forecast.Size = New System.Drawing.Size(40, 23)
        Me.Button_Forecast.TabIndex = 2
        Me.Button_Forecast.Text = "予報"
        Me.Button_Forecast.UseVisualStyleBackColor = False
        '
        'TextBox_PeakSupply
        '
        Me.TextBox_PeakSupply.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TextBox_PeakSupply.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_PeakSupply.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox_PeakSupply.Font = New System.Drawing.Font("Meiryo", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_PeakSupply.Location = New System.Drawing.Point(133, 77)
        Me.TextBox_PeakSupply.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_PeakSupply.Name = "TextBox_PeakSupply"
        Me.TextBox_PeakSupply.ReadOnly = True
        Me.TextBox_PeakSupply.Size = New System.Drawing.Size(40, 18)
        Me.TextBox_PeakSupply.TabIndex = 5
        Me.TextBox_PeakSupply.TabStop = False
        Me.TextBox_PeakSupply.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_UsageAmount
        '
        Me.TextBox_UsageAmount.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TextBox_UsageAmount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_UsageAmount.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox_UsageAmount.Font = New System.Drawing.Font("Meiryo", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_UsageAmount.Location = New System.Drawing.Point(133, 103)
        Me.TextBox_UsageAmount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_UsageAmount.Name = "TextBox_UsageAmount"
        Me.TextBox_UsageAmount.ReadOnly = True
        Me.TextBox_UsageAmount.Size = New System.Drawing.Size(40, 18)
        Me.TextBox_UsageAmount.TabIndex = 8
        Me.TextBox_UsageAmount.TabStop = False
        Me.TextBox_UsageAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox_UsageRate
        '
        Me.TextBox_UsageRate.BackColor = System.Drawing.Color.Silver
        Me.TextBox_UsageRate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_UsageRate.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox_UsageRate.Font = New System.Drawing.Font("Meiryo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_UsageRate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextBox_UsageRate.Location = New System.Drawing.Point(100, 135)
        Me.TextBox_UsageRate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox_UsageRate.Name = "TextBox_UsageRate"
        Me.TextBox_UsageRate.ReadOnly = True
        Me.TextBox_UsageRate.Size = New System.Drawing.Size(40, 24)
        Me.TextBox_UsageRate.TabIndex = 13
        Me.TextBox_UsageRate.TabStop = False
        Me.TextBox_UsageRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox_UsageRate.Visible = False
        '
        'Label_PeakSupply
        '
        Me.Label_PeakSupply.AutoSize = True
        Me.Label_PeakSupply.Font = New System.Drawing.Font("Meiryo", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_PeakSupply.Location = New System.Drawing.Point(7, 77)
        Me.Label_PeakSupply.Name = "Label_PeakSupply"
        Me.Label_PeakSupply.Size = New System.Drawing.Size(128, 18)
        Me.Label_PeakSupply.TabIndex = 4
        Me.Label_PeakSupply.Text = "本日のピーク時供給力"
        '
        'Label_UsageAmount
        '
        Me.Label_UsageAmount.AutoSize = True
        Me.Label_UsageAmount.Font = New System.Drawing.Font("Meiryo", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_UsageAmount.Location = New System.Drawing.Point(7, 103)
        Me.Label_UsageAmount.Name = "Label_UsageAmount"
        Me.Label_UsageAmount.Size = New System.Drawing.Size(80, 18)
        Me.Label_UsageAmount.TabIndex = 7
        Me.Label_UsageAmount.Text = "最新の使用量"
        '
        'Label_UsageRate
        '
        Me.Label_UsageRate.AutoSize = True
        Me.Label_UsageRate.Font = New System.Drawing.Font("Meiryo", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_UsageRate.Location = New System.Drawing.Point(7, 127)
        Me.Label_UsageRate.Name = "Label_UsageRate"
        Me.Label_UsageRate.Size = New System.Drawing.Size(80, 18)
        Me.Label_UsageRate.TabIndex = 10
        Me.Label_UsageRate.Text = "最新の使用率"
        '
        'Label_PeakSupplyUnit
        '
        Me.Label_PeakSupplyUnit.AutoSize = True
        Me.Label_PeakSupplyUnit.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_PeakSupplyUnit.Location = New System.Drawing.Point(173, 78)
        Me.Label_PeakSupplyUnit.Name = "Label_PeakSupplyUnit"
        Me.Label_PeakSupplyUnit.Size = New System.Drawing.Size(36, 17)
        Me.Label_PeakSupplyUnit.TabIndex = 6
        Me.Label_PeakSupplyUnit.Text = "万kW"
        '
        'Label_UsageAmountUnit
        '
        Me.Label_UsageAmountUnit.AutoSize = True
        Me.Label_UsageAmountUnit.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label_UsageAmountUnit.Location = New System.Drawing.Point(173, 104)
        Me.Label_UsageAmountUnit.Name = "Label_UsageAmountUnit"
        Me.Label_UsageAmountUnit.Size = New System.Drawing.Size(36, 17)
        Me.Label_UsageAmountUnit.TabIndex = 9
        Me.Label_UsageAmountUnit.Text = "万kW"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Settings_ToolStripMenuItem, Me.Help_ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(274, 25)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Settings_ToolStripMenuItem
        '
        Me.Settings_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Interval_ToolStripMenuItem, Me.Threshold_ToolStripMenuItem, Me.ToolStripSeparator1, Me.Audio_ToolStripMenuItem, Me.ToolStripSeparator2, Me.Startup_ToolStripMenuItem})
        Me.Settings_ToolStripMenuItem.Name = "Settings_ToolStripMenuItem"
        Me.Settings_ToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.Settings_ToolStripMenuItem.Size = New System.Drawing.Size(39, 19)
        Me.Settings_ToolStripMenuItem.Text = "設定"
        '
        'Interval_ToolStripMenuItem
        '
        Me.Interval_ToolStripMenuItem.Name = "Interval_ToolStripMenuItem"
        Me.Interval_ToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.Interval_ToolStripMenuItem.Tag = ""
        Me.Interval_ToolStripMenuItem.Text = "アラート間隔"
        '
        'Threshold_ToolStripMenuItem
        '
        Me.Threshold_ToolStripMenuItem.Name = "Threshold_ToolStripMenuItem"
        Me.Threshold_ToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.Threshold_ToolStripMenuItem.Tag = ""
        Me.Threshold_ToolStripMenuItem.Text = "アラートを出す使用率"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(183, 6)
        '
        'Audio_ToolStripMenuItem
        '
        Me.Audio_ToolStripMenuItem.Name = "Audio_ToolStripMenuItem"
        Me.Audio_ToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.Audio_ToolStripMenuItem.Text = "アラート音の設定"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(183, 6)
        '
        'Startup_ToolStripMenuItem
        '
        Me.Startup_ToolStripMenuItem.Name = "Startup_ToolStripMenuItem"
        Me.Startup_ToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.Startup_ToolStripMenuItem.Text = "スタートアップに登録する"
        '
        'Help_ToolStripMenuItem
        '
        Me.Help_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoInternal_ToolStripMenuItem, Me.InfoMonitor_ToolStripMenuItem, Me.HelpMonitor_ToolStripMenuItem, Me.About_ToolStripMenuItem})
        Me.Help_ToolStripMenuItem.Name = "Help_ToolStripMenuItem"
        Me.Help_ToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.Help_ToolStripMenuItem.Size = New System.Drawing.Size(44, 19)
        Me.Help_ToolStripMenuItem.Text = "ヘルプ"
        '
        'InfoInternal_ToolStripMenuItem
        '
        Me.InfoInternal_ToolStripMenuItem.Name = "InfoInternal_ToolStripMenuItem"
        Me.InfoInternal_ToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.InfoInternal_ToolStripMenuItem.Text = "内部時刻を見る"
        Me.InfoInternal_ToolStripMenuItem.Visible = False
        '
        'InfoMonitor_ToolStripMenuItem
        '
        Me.InfoMonitor_ToolStripMenuItem.Name = "InfoMonitor_ToolStripMenuItem"
        Me.InfoMonitor_ToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.InfoMonitor_ToolStripMenuItem.Text = "更新状況を見る"
        Me.InfoMonitor_ToolStripMenuItem.Visible = False
        '
        'HelpMonitor_ToolStripMenuItem
        '
        Me.HelpMonitor_ToolStripMenuItem.Name = "HelpMonitor_ToolStripMenuItem"
        Me.HelpMonitor_ToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.HelpMonitor_ToolStripMenuItem.Text = "更新状況の説明"
        Me.HelpMonitor_ToolStripMenuItem.Visible = False
        '
        'About_ToolStripMenuItem
        '
        Me.About_ToolStripMenuItem.Name = "About_ToolStripMenuItem"
        Me.About_ToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.About_ToolStripMenuItem.Text = "電気アラートについて"
        '
        'ComboBox_Companies
        '
        Me.ComboBox_Companies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Companies.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBox_Companies.Font = New System.Drawing.Font("Meiryo", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBox_Companies.FormattingEnabled = True
        Me.ComboBox_Companies.Location = New System.Drawing.Point(10, 38)
        Me.ComboBox_Companies.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBox_Companies.Name = "ComboBox_Companies"
        Me.ComboBox_Companies.Size = New System.Drawing.Size(100, 28)
        Me.ComboBox_Companies.TabIndex = 0
        Me.ComboBox_Companies.Tag = ""
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "電力会社の使用状況"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Open_ToolStripMenuItem, Me.ToolStripSeparator3, Me.End_ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(167, 54)
        '
        'Open_ToolStripMenuItem
        '
        Me.Open_ToolStripMenuItem.Name = "Open_ToolStripMenuItem"
        Me.Open_ToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.Open_ToolStripMenuItem.Text = "ウィンドウを開く"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(163, 6)
        '
        'End_ToolStripMenuItem
        '
        Me.End_ToolStripMenuItem.Name = "End_ToolStripMenuItem"
        Me.End_ToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.End_ToolStripMenuItem.Text = "電気アラートを終了"
        '
        'TextBox_UpDown
        '
        Me.TextBox_UpDown.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TextBox_UpDown.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_UpDown.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox_UpDown.Font = New System.Drawing.Font("Meiryo", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_UpDown.Location = New System.Drawing.Point(10, 146)
        Me.TextBox_UpDown.Name = "TextBox_UpDown"
        Me.TextBox_UpDown.ReadOnly = True
        Me.TextBox_UpDown.Size = New System.Drawing.Size(76, 17)
        Me.TextBox_UpDown.TabIndex = 11
        Me.TextBox_UpDown.TabStop = False
        '
        'TextBox_UsageRateUnit
        '
        Me.TextBox_UsageRateUnit.BackColor = System.Drawing.Color.Silver
        Me.TextBox_UsageRateUnit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_UsageRateUnit.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox_UsageRateUnit.Font = New System.Drawing.Font("Meiryo", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_UsageRateUnit.Location = New System.Drawing.Point(140, 138)
        Me.TextBox_UsageRateUnit.Name = "TextBox_UsageRateUnit"
        Me.TextBox_UsageRateUnit.ReadOnly = True
        Me.TextBox_UsageRateUnit.Size = New System.Drawing.Size(16, 18)
        Me.TextBox_UsageRateUnit.TabIndex = 14
        Me.TextBox_UsageRateUnit.TabStop = False
        Me.TextBox_UsageRateUnit.Text = "%"
        Me.TextBox_UsageRateUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox_UsageRateUnit.Visible = False
        '
        'TextBox_Play
        '
        Me.TextBox_Play.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Play.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox_Play.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox_Play.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox_Play.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox_Play.Location = New System.Drawing.Point(168, 5)
        Me.TextBox_Play.Name = "TextBox_Play"
        Me.TextBox_Play.ReadOnly = True
        Me.TextBox_Play.Size = New System.Drawing.Size(100, 16)
        Me.TextBox_Play.TabIndex = 16
        Me.TextBox_Play.Text = "アラート音"
        Me.TextBox_Play.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox_Play.Visible = False
        '
        'ProgressBar_UsageRate
        '
        Me.ProgressBar_UsageRate.BackColor = System.Drawing.Color.Gainsboro
        Me.ProgressBar_UsageRate.ForeColor = System.Drawing.Color.Gainsboro
        Me.ProgressBar_UsageRate.Location = New System.Drawing.Point(93, 129)
        Me.ProgressBar_UsageRate.Name = "ProgressBar_UsageRate"
        Me.ProgressBar_UsageRate.Size = New System.Drawing.Size(172, 34)
        Me.ProgressBar_UsageRate.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar_UsageRate.TabIndex = 12
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(274, 171)
        Me.Controls.Add(Me.Button_Check)
        Me.Controls.Add(Me.Button_Forecast)
        Me.Controls.Add(Me.TextBox_Play)
        Me.Controls.Add(Me.TextBox_UsageRate)
        Me.Controls.Add(Me.TextBox_UsageRateUnit)
        Me.Controls.Add(Me.TextBox_UpDown)
        Me.Controls.Add(Me.TextBox_PeakSupply)
        Me.Controls.Add(Me.ComboBox_Companies)
        Me.Controls.Add(Me.Label_PeakSupplyUnit)
        Me.Controls.Add(Me.Label_UsageAmountUnit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TextBox_UsageAmount)
        Me.Controls.Add(Me.Label_PeakSupply)
        Me.Controls.Add(Me.Label_UsageAmount)
        Me.Controls.Add(Me.Label_UsageRate)
        Me.Controls.Add(Me.ProgressBar_UsageRate)
        Me.Font = New System.Drawing.Font("Meiryo", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.ShowInTaskbar = False
        Me.Text = "電気アラート"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_Check As System.Windows.Forms.Button
    Friend WithEvents Button_Forecast As Button
    Friend WithEvents TextBox_PeakSupply As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_UsageAmount As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_UsageRate As System.Windows.Forms.TextBox
    Friend WithEvents Label_PeakSupply As System.Windows.Forms.Label
    Friend WithEvents Label_UsageAmount As System.Windows.Forms.Label
    Friend WithEvents Label_UsageRate As System.Windows.Forms.Label
    Friend WithEvents Label_PeakSupplyUnit As System.Windows.Forms.Label
    Friend WithEvents Label_UsageAmountUnit As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Settings_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboBox_Companies As System.Windows.Forms.ComboBox
    Friend WithEvents Help_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents About_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Interval_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Threshold_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Open_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents End_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents InfoInternal_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox_UpDown As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_UsageRateUnit As System.Windows.Forms.TextBox
    Friend WithEvents Startup_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoMonitor_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgressBar_UsageRate As PowerAlert.FlatProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Audio_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox_Play As System.Windows.Forms.TextBox
    Friend WithEvents HelpMonitor_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
