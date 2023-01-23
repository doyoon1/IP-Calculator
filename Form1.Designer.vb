<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt1octet = New System.Windows.Forms.TextBox()
        Me.txt3octet = New System.Windows.Forms.TextBox()
        Me.txt2octet = New System.Windows.Forms.TextBox()
        Me.txt4octet = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblHost = New System.Windows.Forms.Label()
        Me.lblUsable = New System.Windows.Forms.Label()
        Me.lblLongFormat = New System.Windows.Forms.Label()
        Me.lblNA = New System.Windows.Forms.Label()
        Me.lblBA = New System.Windows.Forms.Label()
        Me.lblFA = New System.Windows.Forms.Label()
        Me.lblLA = New System.Windows.Forms.Label()
        Me.btnCompute = New System.Windows.Forms.Button()
        Me.lblBinary = New System.Windows.Forms.Label()
        Me.txtClass = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblIP = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboSM = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblHex = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(38, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "IP Addressing"
        '
        'txt1octet
        '
        Me.txt1octet.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt1octet.Location = New System.Drawing.Point(41, 98)
        Me.txt1octet.MaxLength = 255
        Me.txt1octet.Name = "txt1octet"
        Me.txt1octet.Size = New System.Drawing.Size(35, 26)
        Me.txt1octet.TabIndex = 1
        '
        'txt3octet
        '
        Me.txt3octet.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt3octet.Location = New System.Drawing.Point(123, 98)
        Me.txt3octet.MaxLength = 255
        Me.txt3octet.Name = "txt3octet"
        Me.txt3octet.Size = New System.Drawing.Size(35, 26)
        Me.txt3octet.TabIndex = 2
        '
        'txt2octet
        '
        Me.txt2octet.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt2octet.Location = New System.Drawing.Point(82, 98)
        Me.txt2octet.MaxLength = 255
        Me.txt2octet.Name = "txt2octet"
        Me.txt2octet.Size = New System.Drawing.Size(35, 26)
        Me.txt2octet.TabIndex = 3
        '
        'txt4octet
        '
        Me.txt4octet.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt4octet.Location = New System.Drawing.Point(164, 98)
        Me.txt4octet.MaxLength = 255
        Me.txt4octet.Name = "txt4octet"
        Me.txt4octet.Size = New System.Drawing.Size(35, 26)
        Me.txt4octet.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(38, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 19)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "IP address"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(208, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "/"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(191, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 19)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Subnet mask"
        '
        'lblHost
        '
        Me.lblHost.AutoSize = True
        Me.lblHost.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHost.Location = New System.Drawing.Point(84, 175)
        Me.lblHost.Name = "lblHost"
        Me.lblHost.Size = New System.Drawing.Size(0, 19)
        Me.lblHost.TabIndex = 9
        '
        'lblUsable
        '
        Me.lblUsable.AutoSize = True
        Me.lblUsable.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsable.Location = New System.Drawing.Point(126, 191)
        Me.lblUsable.Name = "lblUsable"
        Me.lblUsable.Size = New System.Drawing.Size(0, 19)
        Me.lblUsable.TabIndex = 10
        '
        'lblLongFormat
        '
        Me.lblLongFormat.AutoSize = True
        Me.lblLongFormat.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLongFormat.Location = New System.Drawing.Point(88, 223)
        Me.lblLongFormat.Name = "lblLongFormat"
        Me.lblLongFormat.Size = New System.Drawing.Size(0, 19)
        Me.lblLongFormat.TabIndex = 11
        '
        'lblNA
        '
        Me.lblNA.AutoSize = True
        Me.lblNA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNA.Location = New System.Drawing.Point(153, 325)
        Me.lblNA.Name = "lblNA"
        Me.lblNA.Size = New System.Drawing.Size(0, 19)
        Me.lblNA.TabIndex = 13
        '
        'lblBA
        '
        Me.lblBA.AutoSize = True
        Me.lblBA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBA.Location = New System.Drawing.Point(167, 340)
        Me.lblBA.Name = "lblBA"
        Me.lblBA.Size = New System.Drawing.Size(0, 19)
        Me.lblBA.TabIndex = 14
        '
        'lblFA
        '
        Me.lblFA.AutoSize = True
        Me.lblFA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFA.Location = New System.Drawing.Point(131, 356)
        Me.lblFA.Name = "lblFA"
        Me.lblFA.Size = New System.Drawing.Size(0, 19)
        Me.lblFA.TabIndex = 15
        '
        'lblLA
        '
        Me.lblLA.AutoSize = True
        Me.lblLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLA.Location = New System.Drawing.Point(132, 372)
        Me.lblLA.Name = "lblLA"
        Me.lblLA.Size = New System.Drawing.Size(0, 19)
        Me.lblLA.TabIndex = 16
        '
        'btnCompute
        '
        Me.btnCompute.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnCompute.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCompute.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCompute.ForeColor = System.Drawing.SystemColors.Control
        Me.btnCompute.Location = New System.Drawing.Point(273, 97)
        Me.btnCompute.Name = "btnCompute"
        Me.btnCompute.Size = New System.Drawing.Size(75, 27)
        Me.btnCompute.TabIndex = 17
        Me.btnCompute.Text = "Compute"
        Me.btnCompute.UseVisualStyleBackColor = False
        '
        'lblBinary
        '
        Me.lblBinary.AutoSize = True
        Me.lblBinary.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBinary.Location = New System.Drawing.Point(89, 207)
        Me.lblBinary.Name = "lblBinary"
        Me.lblBinary.Size = New System.Drawing.Size(0, 19)
        Me.lblBinary.TabIndex = 18
        '
        'txtClass
        '
        Me.txtClass.AutoSize = True
        Me.txtClass.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClass.Location = New System.Drawing.Point(86, 159)
        Me.txtClass.Name = "txtClass"
        Me.txtClass.Size = New System.Drawing.Size(0, 19)
        Me.txtClass.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(43, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 20)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "CIDR"
        '
        'lblIP
        '
        Me.lblIP.AutoSize = True
        Me.lblIP.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIP.Location = New System.Drawing.Point(43, 139)
        Me.lblIP.Name = "lblIP"
        Me.lblIP.Size = New System.Drawing.Size(0, 15)
        Me.lblIP.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(101, 240)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 19)
        Me.Label6.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(43, 239)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 20)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Wildcard"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(43, 159)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 20)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Class"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(43, 191)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 20)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Usable Host"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(43, 175)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 20)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Host"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(43, 372)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 20)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Last Address"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(43, 356)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 20)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "First Address"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(43, 340)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 20)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "Broadcast Address"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(43, 324)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 20)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Network Address"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(43, 299)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(112, 20)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Network Ranges:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(43, 207)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 20)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Binary"
        '
        'cboSM
        '
        Me.cboSM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSM.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSM.FormattingEnabled = True
        Me.cboSM.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cboSM.Location = New System.Drawing.Point(219, 100)
        Me.cboSM.Name = "cboSM"
        Me.cboSM.Size = New System.Drawing.Size(35, 24)
        Me.cboSM.TabIndex = 36
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(43, 255)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 20)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Hex"
        '
        'lblHex
        '
        Me.lblHex.AutoSize = True
        Me.lblHex.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHex.Location = New System.Drawing.Point(75, 255)
        Me.lblHex.Name = "lblHex"
        Me.lblHex.Size = New System.Drawing.Size(0, 19)
        Me.lblHex.TabIndex = 37
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 424)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblHex)
        Me.Controls.Add(Me.cboSM)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblIP)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtClass)
        Me.Controls.Add(Me.lblBinary)
        Me.Controls.Add(Me.btnCompute)
        Me.Controls.Add(Me.lblLA)
        Me.Controls.Add(Me.lblFA)
        Me.Controls.Add(Me.lblBA)
        Me.Controls.Add(Me.lblNA)
        Me.Controls.Add(Me.lblLongFormat)
        Me.Controls.Add(Me.lblUsable)
        Me.Controls.Add(Me.lblHost)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt4octet)
        Me.Controls.Add(Me.txt2octet)
        Me.Controls.Add(Me.txt3octet)
        Me.Controls.Add(Me.txt1octet)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt1octet As System.Windows.Forms.TextBox
    Friend WithEvents txt3octet As System.Windows.Forms.TextBox
    Friend WithEvents txt2octet As System.Windows.Forms.TextBox
    Friend WithEvents txt4octet As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblHost As System.Windows.Forms.Label
    Friend WithEvents lblUsable As System.Windows.Forms.Label
    Friend WithEvents lblLongFormat As System.Windows.Forms.Label
    Friend WithEvents lblNA As System.Windows.Forms.Label
    Friend WithEvents lblBA As System.Windows.Forms.Label
    Friend WithEvents lblFA As System.Windows.Forms.Label
    Friend WithEvents lblLA As System.Windows.Forms.Label
    Friend WithEvents btnCompute As System.Windows.Forms.Button
    Friend WithEvents lblBinary As System.Windows.Forms.Label
    Friend WithEvents txtClass As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblIP As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboSM As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblHex As System.Windows.Forms.Label

End Class
