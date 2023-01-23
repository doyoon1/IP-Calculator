<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVLSM
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt4octet = New System.Windows.Forms.TextBox()
        Me.txt2octet = New System.Windows.Forms.TextBox()
        Me.txt3octet = New System.Windows.Forms.TextBox()
        Me.txt1octet = New System.Windows.Forms.TextBox()
        Me.dgvStocks = New System.Windows.Forms.DataGridView()
        Me.btnCompute = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblBinary = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblIncrement = New System.Windows.Forms.Label()
        Me.lblNsm = New System.Windows.Forms.Label()
        Me.lblBits = New System.Windows.Forms.Label()
        Me.lblHost = New System.Windows.Forms.Label()
        Me.lblAH = New System.Windows.Forms.Label()
        Me.lblIP = New System.Windows.Forms.Label()
        Me.txtClass = New System.Windows.Forms.Label()
        Me.lblCidr = New System.Windows.Forms.Label()
        Me.lblUsable = New System.Windows.Forms.Label()
        Me.lblAN = New System.Windows.Forms.Label()
        Me.lblNA2 = New System.Windows.Forms.Label()
        Me.lblLA1 = New System.Windows.Forms.Label()
        Me.lblFA1 = New System.Windows.Forms.Label()
        Me.lblBA1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboSM = New System.Windows.Forms.ComboBox()
        CType(Me.dgvStocks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(189, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 21)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Subnet mask"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(207, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 16)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "/"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 21)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "IP address"
        '
        'txt4octet
        '
        Me.txt4octet.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt4octet.Location = New System.Drawing.Point(165, 99)
        Me.txt4octet.Name = "txt4octet"
        Me.txt4octet.Size = New System.Drawing.Size(35, 26)
        Me.txt4octet.TabIndex = 51
        '
        'txt2octet
        '
        Me.txt2octet.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt2octet.Location = New System.Drawing.Point(83, 99)
        Me.txt2octet.Name = "txt2octet"
        Me.txt2octet.Size = New System.Drawing.Size(35, 26)
        Me.txt2octet.TabIndex = 50
        '
        'txt3octet
        '
        Me.txt3octet.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt3octet.Location = New System.Drawing.Point(124, 99)
        Me.txt3octet.Name = "txt3octet"
        Me.txt3octet.Size = New System.Drawing.Size(35, 26)
        Me.txt3octet.TabIndex = 49
        '
        'txt1octet
        '
        Me.txt1octet.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt1octet.Location = New System.Drawing.Point(42, 99)
        Me.txt1octet.Name = "txt1octet"
        Me.txt1octet.Size = New System.Drawing.Size(35, 26)
        Me.txt1octet.TabIndex = 48
        '
        'dgvStocks
        '
        Me.dgvStocks.BackgroundColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStocks.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStocks.GridColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.dgvStocks.Location = New System.Drawing.Point(42, 157)
        Me.dgvStocks.Name = "dgvStocks"
        Me.dgvStocks.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStocks.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvStocks.RowHeadersWidth = 60
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvStocks.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvStocks.Size = New System.Drawing.Size(714, 318)
        Me.dgvStocks.TabIndex = 62
        '
        'btnCompute
        '
        Me.btnCompute.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnCompute.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCompute.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCompute.ForeColor = System.Drawing.SystemColors.Control
        Me.btnCompute.Location = New System.Drawing.Point(266, 99)
        Me.btnCompute.Name = "btnCompute"
        Me.btnCompute.Size = New System.Drawing.Size(75, 26)
        Me.btnCompute.TabIndex = 63
        Me.btnCompute.Text = "Compute"
        Me.btnCompute.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(220, 608)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 16)
        Me.Label16.TabIndex = 164
        Me.Label16.Text = "Usable Host"
        Me.Label16.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(220, 592)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 16)
        Me.Label15.TabIndex = 163
        Me.Label15.Text = "Actual Host"
        Me.Label15.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(220, 576)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 16)
        Me.Label14.TabIndex = 162
        Me.Label14.Text = "Actual Network"
        Me.Label14.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(11, 672)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 16)
        Me.Label13.TabIndex = 161
        Me.Label13.Text = "Binary"
        Me.Label13.Visible = False
        '
        'lblBinary
        '
        Me.lblBinary.AutoSize = True
        Me.lblBinary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBinary.Location = New System.Drawing.Point(69, 672)
        Me.lblBinary.Name = "lblBinary"
        Me.lblBinary.Size = New System.Drawing.Size(46, 16)
        Me.lblBinary.TabIndex = 160
        Me.lblBinary.Text = "Binary"
        Me.lblBinary.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 624)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 16)
        Me.Label6.TabIndex = 159
        Me.Label6.Text = "Increment"
        Me.Label6.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 608)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 16)
        Me.Label11.TabIndex = 158
        Me.Label11.Text = "Bits"
        Me.Label11.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 592)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 16)
        Me.Label9.TabIndex = 157
        Me.Label9.Text = "Network"
        Me.Label9.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 640)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 16)
        Me.Label7.TabIndex = 156
        Me.Label7.Text = "NSM"
        Me.Label7.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 656)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 16)
        Me.Label10.TabIndex = 155
        Me.Label10.Text = "CIDR"
        Me.Label10.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 576)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 16)
        Me.Label5.TabIndex = 154
        Me.Label5.Text = "Class"
        Me.Label5.Visible = False
        '
        'lblIncrement
        '
        Me.lblIncrement.AutoSize = True
        Me.lblIncrement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncrement.Location = New System.Drawing.Point(82, 624)
        Me.lblIncrement.Name = "lblIncrement"
        Me.lblIncrement.Size = New System.Drawing.Size(66, 16)
        Me.lblIncrement.TabIndex = 153
        Me.lblIncrement.Text = "Increment"
        Me.lblIncrement.Visible = False
        '
        'lblNsm
        '
        Me.lblNsm.AutoSize = True
        Me.lblNsm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNsm.Location = New System.Drawing.Point(52, 640)
        Me.lblNsm.Name = "lblNsm"
        Me.lblNsm.Size = New System.Drawing.Size(36, 16)
        Me.lblNsm.TabIndex = 152
        Me.lblNsm.Text = "Nsm"
        Me.lblNsm.Visible = False
        '
        'lblBits
        '
        Me.lblBits.AutoSize = True
        Me.lblBits.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBits.Location = New System.Drawing.Point(46, 608)
        Me.lblBits.Name = "lblBits"
        Me.lblBits.Size = New System.Drawing.Size(30, 16)
        Me.lblBits.TabIndex = 151
        Me.lblBits.Text = "Bits"
        Me.lblBits.Visible = False
        '
        'lblHost
        '
        Me.lblHost.AutoSize = True
        Me.lblHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHost.Location = New System.Drawing.Point(74, 592)
        Me.lblHost.Name = "lblHost"
        Me.lblHost.Size = New System.Drawing.Size(36, 16)
        Me.lblHost.TabIndex = 150
        Me.lblHost.Text = "Host"
        Me.lblHost.Visible = False
        '
        'lblAH
        '
        Me.lblAH.AutoSize = True
        Me.lblAH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAH.Location = New System.Drawing.Point(320, 592)
        Me.lblAH.Name = "lblAH"
        Me.lblAH.Size = New System.Drawing.Size(76, 16)
        Me.lblAH.TabIndex = 149
        Me.lblAH.Text = "Actual Host"
        Me.lblAH.Visible = False
        '
        'lblIP
        '
        Me.lblIP.AutoSize = True
        Me.lblIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIP.Location = New System.Drawing.Point(11, 556)
        Me.lblIP.Name = "lblIP"
        Me.lblIP.Size = New System.Drawing.Size(22, 16)
        Me.lblIP.TabIndex = 148
        Me.lblIP.Text = "IP"
        Me.lblIP.Visible = False
        '
        'txtClass
        '
        Me.txtClass.AutoSize = True
        Me.txtClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClass.Location = New System.Drawing.Point(60, 576)
        Me.txtClass.Name = "txtClass"
        Me.txtClass.Size = New System.Drawing.Size(42, 16)
        Me.txtClass.TabIndex = 147
        Me.txtClass.Text = "Class"
        Me.txtClass.Visible = False
        '
        'lblCidr
        '
        Me.lblCidr.AutoSize = True
        Me.lblCidr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCidr.Location = New System.Drawing.Point(56, 656)
        Me.lblCidr.Name = "lblCidr"
        Me.lblCidr.Size = New System.Drawing.Size(46, 16)
        Me.lblCidr.TabIndex = 146
        Me.lblCidr.Text = "Binary"
        Me.lblCidr.Visible = False
        '
        'lblUsable
        '
        Me.lblUsable.AutoSize = True
        Me.lblUsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsable.Location = New System.Drawing.Point(320, 608)
        Me.lblUsable.Name = "lblUsable"
        Me.lblUsable.Size = New System.Drawing.Size(83, 16)
        Me.lblUsable.TabIndex = 145
        Me.lblUsable.Text = "Usable Host"
        Me.lblUsable.Visible = False
        '
        'lblAN
        '
        Me.lblAN.AutoSize = True
        Me.lblAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAN.Location = New System.Drawing.Point(337, 576)
        Me.lblAN.Name = "lblAN"
        Me.lblAN.Size = New System.Drawing.Size(97, 16)
        Me.lblAN.TabIndex = 144
        Me.lblAN.Text = "Actual Network"
        Me.lblAN.Visible = False
        '
        'lblNA2
        '
        Me.lblNA2.AutoSize = True
        Me.lblNA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNA2.Location = New System.Drawing.Point(231, 656)
        Me.lblNA2.Name = "lblNA2"
        Me.lblNA2.Size = New System.Drawing.Size(27, 16)
        Me.lblNA2.TabIndex = 169
        Me.lblNA2.Text = "NA"
        Me.lblNA2.Visible = False
        '
        'lblLA1
        '
        Me.lblLA1.AutoSize = True
        Me.lblLA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLA1.Location = New System.Drawing.Point(626, 656)
        Me.lblLA1.Name = "lblLA1"
        Me.lblLA1.Size = New System.Drawing.Size(27, 16)
        Me.lblLA1.TabIndex = 168
        Me.lblLA1.Text = "NA"
        '
        'lblFA1
        '
        Me.lblFA1.AutoSize = True
        Me.lblFA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFA1.Location = New System.Drawing.Point(519, 656)
        Me.lblFA1.Name = "lblFA1"
        Me.lblFA1.Size = New System.Drawing.Size(27, 16)
        Me.lblFA1.TabIndex = 167
        Me.lblFA1.Text = "NA"
        Me.lblFA1.Visible = False
        '
        'lblBA1
        '
        Me.lblBA1.AutoSize = True
        Me.lblBA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBA1.Location = New System.Drawing.Point(368, 656)
        Me.lblBA1.Name = "lblBA1"
        Me.lblBA1.Size = New System.Drawing.Size(27, 16)
        Me.lblBA1.TabIndex = 166
        Me.lblBA1.Text = "NA"
        Me.lblBA1.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Control
        Me.Button2.Location = New System.Drawing.Point(347, 99)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 26)
        Me.Button2.TabIndex = 170
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'txtHost
        '
        Me.txtHost.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHost.Location = New System.Drawing.Point(83, 130)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(76, 22)
        Me.txtHost.TabIndex = 171
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 21)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "Host"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(38, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(274, 24)
        Me.Label8.TabIndex = 173
        Me.Label8.Text = "Variable Length Subnet Mask"
        '
        'cboSM
        '
        Me.cboSM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSM.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSM.FormattingEnabled = True
        Me.cboSM.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32"})
        Me.cboSM.Location = New System.Drawing.Point(218, 102)
        Me.cboSM.Name = "cboSM"
        Me.cboSM.Size = New System.Drawing.Size(35, 24)
        Me.cboSM.TabIndex = 174
        '
        'frmVLSM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 518)
        Me.Controls.Add(Me.cboSM)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblNA2)
        Me.Controls.Add(Me.lblLA1)
        Me.Controls.Add(Me.lblFA1)
        Me.Controls.Add(Me.lblBA1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblBinary)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblIncrement)
        Me.Controls.Add(Me.lblNsm)
        Me.Controls.Add(Me.lblBits)
        Me.Controls.Add(Me.lblHost)
        Me.Controls.Add(Me.lblAH)
        Me.Controls.Add(Me.lblIP)
        Me.Controls.Add(Me.txtClass)
        Me.Controls.Add(Me.lblCidr)
        Me.Controls.Add(Me.lblUsable)
        Me.Controls.Add(Me.lblAN)
        Me.Controls.Add(Me.btnCompute)
        Me.Controls.Add(Me.dgvStocks)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt4octet)
        Me.Controls.Add(Me.txt2octet)
        Me.Controls.Add(Me.txt3octet)
        Me.Controls.Add(Me.txt1octet)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmVLSM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmVLSM"
        CType(Me.dgvStocks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt4octet As System.Windows.Forms.TextBox
    Friend WithEvents txt2octet As System.Windows.Forms.TextBox
    Friend WithEvents txt3octet As System.Windows.Forms.TextBox
    Friend WithEvents txt1octet As System.Windows.Forms.TextBox
    Friend WithEvents dgvStocks As System.Windows.Forms.DataGridView
    Friend WithEvents btnCompute As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblBinary As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblIncrement As System.Windows.Forms.Label
    Friend WithEvents lblNsm As System.Windows.Forms.Label
    Friend WithEvents lblBits As System.Windows.Forms.Label
    Friend WithEvents lblHost As System.Windows.Forms.Label
    Friend WithEvents lblAH As System.Windows.Forms.Label
    Friend WithEvents lblIP As System.Windows.Forms.Label
    Friend WithEvents txtClass As System.Windows.Forms.Label
    Friend WithEvents lblCidr As System.Windows.Forms.Label
    Friend WithEvents lblUsable As System.Windows.Forms.Label
    Friend WithEvents lblAN As System.Windows.Forms.Label
    Friend WithEvents lblNA2 As System.Windows.Forms.Label
    Friend WithEvents lblLA1 As System.Windows.Forms.Label
    Friend WithEvents lblFA1 As System.Windows.Forms.Label
    Friend WithEvents lblBA1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboSM As System.Windows.Forms.ComboBox
End Class
