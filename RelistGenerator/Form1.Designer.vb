<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RelistMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RelistMain))
        Me.FolderLocTXT = New System.Windows.Forms.TextBox()
        Me.CSVLocationLabel = New System.Windows.Forms.Label()
        Me.CollectBTN = New System.Windows.Forms.Button()
        Me.FolderSelection = New System.Windows.Forms.FolderBrowserDialog()
        Me.ClicktochangeLabel = New System.Windows.Forms.Label()
        Me.CSVNameLabel = New System.Windows.Forms.Label()
        Me.CSVNameTXT = New System.Windows.Forms.TextBox()
        Me.DotCSVLabel = New System.Windows.Forms.Label()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout
        Me.SuspendLayout
        '
        'FolderLocTXT
        '
        Me.FolderLocTXT.Location = New System.Drawing.Point(101, 269)
        Me.FolderLocTXT.Name = "FolderLocTXT"
        Me.FolderLocTXT.ReadOnly = true
        Me.FolderLocTXT.Size = New System.Drawing.Size(177, 36)
        Me.FolderLocTXT.TabIndex = 3
        Me.FolderLocTXT.Text = "V:\Warehouse\Relist\"
        '
        'CSVLocationLabel
        '
        Me.CSVLocationLabel.AutoSize = true
        Me.CSVLocationLabel.Location = New System.Drawing.Point(73, 204)
        Me.CSVLocationLabel.Name = "CSVLocationLabel"
        Me.CSVLocationLabel.Size = New System.Drawing.Size(222, 28)
        Me.CSVLocationLabel.TabIndex = 4
        Me.CSVLocationLabel.Text = "CSV Export Location"
        '
        'CollectBTN
        '
        Me.CollectBTN.Font = New System.Drawing.Font("Cambria", 16!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.CollectBTN.Location = New System.Drawing.Point(53, 12)
        Me.CollectBTN.Name = "CollectBTN"
        Me.CollectBTN.Size = New System.Drawing.Size(205, 49)
        Me.CollectBTN.TabIndex = 1
        Me.CollectBTN.Text = "Collect Relist Data"
        Me.CollectBTN.UseVisualStyleBackColor = true
        '
        'ClicktochangeLabel
        '
        Me.ClicktochangeLabel.AutoSize = true
        Me.ClicktochangeLabel.Location = New System.Drawing.Point(110, 308)
        Me.ClicktochangeLabel.Name = "ClicktochangeLabel"
        Me.ClicktochangeLabel.Size = New System.Drawing.Size(168, 28)
        Me.ClicktochangeLabel.TabIndex = 5
        Me.ClicktochangeLabel.Text = "Click to change"
        '
        'CSVNameLabel
        '
        Me.CSVNameLabel.AutoSize = true
        Me.CSVNameLabel.Location = New System.Drawing.Point(130, 363)
        Me.CSVNameLabel.Name = "CSVNameLabel"
        Me.CSVNameLabel.Size = New System.Drawing.Size(117, 28)
        Me.CSVNameLabel.TabIndex = 7
        Me.CSVNameLabel.Text = "CSV Name"
        '
        'CSVNameTXT
        '
        Me.CSVNameTXT.Location = New System.Drawing.Point(117, 408)
        Me.CSVNameTXT.Name = "CSVNameTXT"
        Me.CSVNameTXT.Size = New System.Drawing.Size(141, 36)
        Me.CSVNameTXT.TabIndex = 6
        Me.CSVNameTXT.Text = "relist-yyMMdd"
        '
        'DotCSVLabel
        '
        Me.DotCSVLabel.AutoSize = true
        Me.DotCSVLabel.Location = New System.Drawing.Point(264, 416)
        Me.DotCSVLabel.Name = "DotCSVLabel"
        Me.DotCSVLabel.Size = New System.Drawing.Size(50, 28)
        Me.DotCSVLabel.TabIndex = 8
        Me.DotCSVLabel.Text = ".csv"
        '
        'StatusLabel
        '
        Me.StatusLabel.Location = New System.Drawing.Point(35, 108)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(260, 70)
        Me.StatusLabel.TabIndex = 9
        Me.StatusLabel.Text = "This will take approx. 5 minutes"
        Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(48,Byte),Integer), CType(CType(48,Byte),Integer), CType(CType(48,Byte),Integer))
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 474)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(508, 337)
        Me.Panel1.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(72,Byte),Integer), CType(CType(72,Byte),Integer), CType(CType(72,Byte),Integer))
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(96,Byte),Integer), CType(CType(96,Byte),Integer), CType(CType(96,Byte),Integer))
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(96,Byte),Integer), CType(CType(96,Byte),Integer), CType(CType(96,Byte),Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(84,Byte),Integer), CType(CType(84,Byte),Integer), CType(CType(84,Byte),Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Gill Sans MT", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240,Byte),Integer), CType(CType(240,Byte),Integer), CType(CType(240,Byte),Integer))
        Me.Button1.Location = New System.Drawing.Point(88, 125)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(325, 73)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Embrace the Future™"
        Me.Button1.UseVisualStyleBackColor = false
        '
        'RelistMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(506, 808)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.DotCSVLabel)
        Me.Controls.Add(Me.CSVNameLabel)
        Me.Controls.Add(Me.CSVNameTXT)
        Me.Controls.Add(Me.ClicktochangeLabel)
        Me.Controls.Add(Me.CSVLocationLabel)
        Me.Controls.Add(Me.FolderLocTXT)
        Me.Controls.Add(Me.CollectBTN)
        Me.Font = New System.Drawing.Font("Cambria", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "RelistMain"
        Me.Opacity = 0.1R
        Me.Text = "6"
        Me.Panel1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents FolderLocTXT As TextBox
    Friend WithEvents CSVLocationLabel As Label
    Friend WithEvents CollectBTN As Button
    Friend WithEvents FolderSelection As FolderBrowserDialog
    Friend WithEvents ClicktochangeLabel As Label
    Friend WithEvents CSVNameLabel As Label
    Friend WithEvents CSVNameTXT As TextBox
    Friend WithEvents DotCSVLabel As Label
    Friend WithEvents StatusLabel As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
End Class
