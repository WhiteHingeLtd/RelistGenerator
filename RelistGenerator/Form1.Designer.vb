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
        Me.SuspendLayout()
        '
        'FolderLocTXT
        '
        Me.FolderLocTXT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FolderLocTXT.Location = New System.Drawing.Point(54, 156)
        Me.FolderLocTXT.Name = "FolderLocTXT"
        Me.FolderLocTXT.ReadOnly = True
        Me.FolderLocTXT.Size = New System.Drawing.Size(177, 26)
        Me.FolderLocTXT.TabIndex = 3
        Me.FolderLocTXT.Text = "V:\Warehouse\Relist\"
        '
        'CSVLocationLabel
        '
        Me.CSVLocationLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CSVLocationLabel.AutoSize = True
        Me.CSVLocationLabel.Location = New System.Drawing.Point(66, 137)
        Me.CSVLocationLabel.Name = "CSVLocationLabel"
        Me.CSVLocationLabel.Size = New System.Drawing.Size(151, 19)
        Me.CSVLocationLabel.TabIndex = 4
        Me.CSVLocationLabel.Text = "CSV Export Location"
        '
        'CollectBTN
        '
        Me.CollectBTN.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CollectBTN.Font = New System.Drawing.Font("Cambria", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CollectBTN.Location = New System.Drawing.Point(40, 13)
        Me.CollectBTN.Name = "CollectBTN"
        Me.CollectBTN.Size = New System.Drawing.Size(205, 49)
        Me.CollectBTN.TabIndex = 1
        Me.CollectBTN.Text = "Collect Relist Data"
        Me.CollectBTN.UseVisualStyleBackColor = True
        '
        'ClicktochangeLabel
        '
        Me.ClicktochangeLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ClicktochangeLabel.AutoSize = True
        Me.ClicktochangeLabel.Location = New System.Drawing.Point(83, 182)
        Me.ClicktochangeLabel.Name = "ClicktochangeLabel"
        Me.ClicktochangeLabel.Size = New System.Drawing.Size(112, 19)
        Me.ClicktochangeLabel.TabIndex = 5
        Me.ClicktochangeLabel.Text = "Click to change"
        '
        'CSVNameLabel
        '
        Me.CSVNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CSVNameLabel.AutoSize = True
        Me.CSVNameLabel.Location = New System.Drawing.Point(96, 213)
        Me.CSVNameLabel.Name = "CSVNameLabel"
        Me.CSVNameLabel.Size = New System.Drawing.Size(80, 19)
        Me.CSVNameLabel.TabIndex = 7
        Me.CSVNameLabel.Text = "CSV Name"
        '
        'CSVNameTXT
        '
        Me.CSVNameTXT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CSVNameTXT.Location = New System.Drawing.Point(54, 232)
        Me.CSVNameTXT.Name = "CSVNameTXT"
        Me.CSVNameTXT.Size = New System.Drawing.Size(141, 26)
        Me.CSVNameTXT.TabIndex = 6
        Me.CSVNameTXT.Text = "relist-yyMMdd"
        '
        'DotCSVLabel
        '
        Me.DotCSVLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DotCSVLabel.AutoSize = True
        Me.DotCSVLabel.Location = New System.Drawing.Point(195, 235)
        Me.DotCSVLabel.Name = "DotCSVLabel"
        Me.DotCSVLabel.Size = New System.Drawing.Size(34, 19)
        Me.DotCSVLabel.TabIndex = 8
        Me.DotCSVLabel.Text = ".csv"
        '
        'StatusLabel
        '
        Me.StatusLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.StatusLabel.Location = New System.Drawing.Point(12, 61)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(260, 70)
        Me.StatusLabel.TabIndex = 9
        Me.StatusLabel.Text = "This will take approx. 5 minutes"
        Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'RelistMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.DotCSVLabel)
        Me.Controls.Add(Me.CSVNameLabel)
        Me.Controls.Add(Me.CSVNameTXT)
        Me.Controls.Add(Me.ClicktochangeLabel)
        Me.Controls.Add(Me.CSVLocationLabel)
        Me.Controls.Add(Me.FolderLocTXT)
        Me.Controls.Add(Me.CollectBTN)
        Me.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(300, 300)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "RelistMain"
        Me.Text = "Relist Generator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
End Class
