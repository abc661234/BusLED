<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Start
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Start))
        Me.Button100 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label500 = New System.Windows.Forms.Label()
        Me.Label600 = New System.Windows.Forms.Label()
        Me.Button200 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Button100
        '
        Me.Button100.Location = New System.Drawing.Point(646, 90)
        Me.Button100.Name = "Button100"
        Me.Button100.Size = New System.Drawing.Size(107, 38)
        Me.Button100.TabIndex = 10
        Me.Button100.Text = "出發！"
        Me.Button100.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label500
        '
        Me.Label500.AutoSize = True
        Me.Label500.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label500.Location = New System.Drawing.Point(35, 200)
        Me.Label500.Name = "Label500"
        Me.Label500.Size = New System.Drawing.Size(54, 27)
        Me.Label500.TabIndex = 13
        Me.Label500.Text = "新增"
        '
        'Label600
        '
        Me.Label600.AutoSize = True
        Me.Label600.ForeColor = System.Drawing.Color.Red
        Me.Label600.Location = New System.Drawing.Point(95, 200)
        Me.Label600.Name = "Label600"
        Me.Label600.Size = New System.Drawing.Size(54, 27)
        Me.Label600.TabIndex = 14
        Me.Label600.Text = "移除"
        Me.Label600.Visible = False
        '
        'Button200
        '
        Me.Button200.Location = New System.Drawing.Point(646, 48)
        Me.Button200.Name = "Button200"
        Me.Button200.Size = New System.Drawing.Size(107, 38)
        Me.Button200.TabIndex = 15
        Me.Button200.Text = "測試模式"
        Me.Button200.UseVisualStyleBackColor = True
        Me.Button200.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(463, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 27)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "模擬廠牌："
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"銓鼎-下一站", "銓鼎-即將抵達", "北圜-下一站", "北圜-即將抵達", "寶錄-下一站", "寶錄-到了", "立皓-下一站", "立皓-即將抵達"})
        Me.ComboBox1.Location = New System.Drawing.Point(468, 92)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(158, 35)
        Me.ComboBox1.TabIndex = 17
        '
        'Start
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 27.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 448)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button200)
        Me.Controls.Add(Me.Label600)
        Me.Controls.Add(Me.Label500)
        Me.Controls.Add(Me.Button100)
        Me.Font = New System.Drawing.Font("Microsoft JhengHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.Name = "Start"
        Me.Text = "公車站名播報模擬  by Petrix Huang"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button100 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label500 As Label
    Friend WithEvents Label600 As Label
    Friend WithEvents Button200 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class
