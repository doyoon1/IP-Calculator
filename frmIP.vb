Public Class Form1
    Private Function IntToBin(ByVal intValue As Integer) As String
        Dim sb As New System.Text.StringBuilder
        While intValue <> 0
            sb.Insert(0, (intValue Mod 2).ToString())
            intValue \= 2
        End While
        Return sb.ToString()
    End Function

    Private Sub txtCompute_Click(sender As Object, e As EventArgs) Handles btnCompute.Click
        Dim first As Integer
        Dim second As Integer
        Dim third As Integer
        Dim fourth As Integer
        If String.IsNullOrWhiteSpace(txt1octet.Text) OrElse String.IsNullOrWhiteSpace(txt2octet.Text) OrElse String.IsNullOrWhiteSpace(txt3octet.Text) OrElse String.IsNullOrWhiteSpace(txt4octet.Text) Then
            MessageBox.Show("Please enter a value in all octet fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf Not Integer.TryParse(txt1octet.Text, first) OrElse Not Integer.TryParse(txt2octet.Text, second) OrElse Not Integer.TryParse(txt3octet.Text, third) OrElse Not Integer.TryParse(txt4octet.Text, fourth) Then
            MessageBox.Show("Invalid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim hexString1 As String = Nothing
        Dim hexString2 As String = Nothing
        Dim hexString3 As String = Nothing
        Dim hexString4 As String = Nothing

        first = Int(txt1octet.Text.Trim)
        second = Int(txt2octet.Text.Trim)
        third = Int(txt3octet.Text.Trim)
        fourth = Int(txt4octet.Text.Trim)

        hexString1 = Hex(first)
        hexString2 = Hex(second)
        hexString3 = Hex(third)
        hexString4 = Hex(fourth)


        lblHex.Text = hexString1 & ":" & hexString2 & ":" & hexString3 & ":" & hexString4


        Dim firstoctet As String
        Dim secondoctet As String
        Dim thirdoctet As String
        Dim fourthoctet As String
        firstoctet = IntToBin(txt1octet.Text)
        secondoctet = IntToBin(txt2octet.Text)
        thirdoctet = IntToBin(txt3octet.Text)
        fourthoctet = IntToBin(txt4octet.Text)

        lblIP.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text & " " & "/" & cboSM.Text
        lblHost.Text = 2 ^ (32 - Val(cboSM.Text))
        lblUsable.Text = Val(lblHost.Text) - 2
        lblBinary.Text = firstoctet.ToString().PadLeft(8, "0") & " " & secondoctet.ToString().PadLeft(8, "0") & " " & thirdoctet.ToString().PadLeft(8, "0") & " " & fourthoctet.ToString().PadLeft(8, "0")

        If txt1octet.Text <= 127 Then
            txtClass.Text = "A"
            lblNA.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
            lblBA.Text = txt1octet.Text & "." & "255" & "." & "255" & "." & "255"
            lblFA.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
            lblLA.Text = txt1octet.Text & "." & "255" & "." & "255" & "." & "254"

        ElseIf txt1octet.Text > 127 And txt1octet.Text < 192 Then
            txtClass.Text = "B"
            lblNA.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
            lblBA.Text = txt1octet.Text & "." & txt2octet.Text & "." & "255" & "." & "255"
            lblLA.Text = txt1octet.Text & "." & txt2octet.Text & "." & "255" & "." & "254"
            lblFA.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
        Else
            txtClass.Text = "C"
            lblNA.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
            lblBA.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "255"
            lblLA.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
            lblFA.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
        End If

        Dim Menu As String
        Menu = cboSM.Text
        Select Case Menu
            Case "1"
                lblLongFormat.Text = "128.0.0.0"
                Label6.Text = "127.255.255.255"
            Case "2"
                lblLongFormat.Text = "192.0.0.0"
                Label6.Text = "63.255.255.255"
            Case "3"
                lblLongFormat.Text = "224.0.0.0"
                Label6.Text = "31.255.255.255"
            Case "4"
                lblLongFormat.Text = "240.0.0.0"
                Label6.Text = "15.255.255.255"
            Case "5"
                lblLongFormat.Text = "248.0.0.0"
                Label6.Text = "7.255.255.255"
            Case "6"
                lblLongFormat.Text = "252.0.0.0"
                Label6.Text = "3.255.255.255"
            Case "7"
                lblLongFormat.Text = "254.0.0.0"
                Label6.Text = "1.255.255.255"
            Case "8"
                lblLongFormat.Text = "255.0.0.0"
                Label6.Text = "0.255.255.255"
            Case "9"
                lblLongFormat.Text = "255.128.0.0"
                Label6.Text = "0.127.255.255"
            Case "10"
                lblLongFormat.Text = "255.192.0.0"
                Label6.Text = "0.63.255.255"
            Case "11"
                lblLongFormat.Text = "255.224.0.0"
                Label6.Text = "0.31.255.255"
            Case "12"
                lblLongFormat.Text = "255.240.0.0"
                Label6.Text = "0.15.255.255"
            Case "13"
                lblLongFormat.Text = "255.248.0.0"
                Label6.Text = "0.7.255.255"
            Case "14"
                lblLongFormat.Text = "255.252.0.0"
                Label6.Text = "0.3.255.255"
            Case "15"
                lblLongFormat.Text = "255.254.0.0"
                Label6.Text = "0.1.255.255"
            Case "16"
                lblLongFormat.Text = "255.255.0.0"
                Label6.Text = "0.0.255.255"
            Case "17"
                lblLongFormat.Text = "255.255.128.0"
                Label6.Text = "0.0.127.255"
            Case "18"
                lblLongFormat.Text = "255.255.192.0"
                Label6.Text = "0.0.63.255"
            Case "19"
                lblLongFormat.Text = "255.255.224.0"
                Label6.Text = "0.0.31.255"
            Case "20"
                lblLongFormat.Text = "255.255.240.0"
                Label6.Text = "0.0.15.255"
            Case "21"
                lblLongFormat.Text = "255.255.248.0"
                Label6.Text = "0.0.7.255"
            Case "22"
                lblLongFormat.Text = "255.255.252.0"
                Label6.Text = "0.0.3.255"
            Case "23"
                lblLongFormat.Text = "255.255.254.0"
                Label6.Text = "0.0.1.255"
            Case "24"
                lblLongFormat.Text = "255.255.255.0"
                Label6.Text = "0.0.0.255"
            Case "25"
                lblLongFormat.Text = "255.255.255.128"
                Label6.Text = "0.0.0.127"
            Case "26"
                lblLongFormat.Text = "255.255.255.192"
                Label6.Text = "0.0.0.63"
            Case "27"
                lblLongFormat.Text = "255.255.255.224"
                Label6.Text = "0.0.0.31"
            Case "28"
                lblLongFormat.Text = "255.255.255.240"
                Label6.Text = "0.0.0.15"
            Case "29"
                lblLongFormat.Text = "255.255.255.248"
                Label6.Text = "0.0.0.7"
            Case "30"
                lblLongFormat.Text = "255.255.255.252"
                Label6.Text = "0.0.0.3"
            Case "31"
                lblLongFormat.Text = "255.255.255.254"
                Label6.Text = "0.0.0.1"
            Case "32"
                lblLongFormat.Text = "255.255.255.255"
                Label6.Text = "0.0.0.0"
        End Select

        txt1octet.Clear()
        txt2octet.Clear()
        txt3octet.Clear()
        txt4octet.Clear()
        cboSM.ResetText()
    End Sub
End Class
