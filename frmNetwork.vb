Public Class frmNetwork
    Private Function IntToBin(ByVal intValue As Integer) As String
        Dim sb As New System.Text.StringBuilder
        While intValue <> 0
            sb.Insert(0, (intValue Mod 2).ToString())
            intValue \= 2
        End While
        Return sb.ToString()
    End Function

    Private Sub txtCompute_Click_1(sender As Object, e As EventArgs) Handles txtCompute.Click
        If String.IsNullOrWhiteSpace(txt1octet.Text) OrElse String.IsNullOrWhiteSpace(txt2octet.Text) OrElse String.IsNullOrWhiteSpace(txt3octet.Text) OrElse String.IsNullOrWhiteSpace(txt4octet.Text) Then
            MessageBox.Show("Please enter a value in all octet fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

               Dim CIDR As String
        CIDR = cboSM.Text
        Select Case CIDR
            Case "1"
                lblOsmCIDR.Text = "128.0.0.0"
            Case "2"
                lblOsmCIDR.Text = "192.0.0.0"
            Case "3"
                lblOsmCIDR.Text = "224.0.0.0"
            Case "4"
                lblOsmCIDR.Text = "240.0.0.0"
            Case "5"
                lblOsmCIDR.Text = "248.0.0.0"
            Case "6"
                lblOsmCIDR.Text = "252.0.0.0"
            Case "7"
                lblOsmCIDR.Text = "254.0.0.0"
            Case "8"
                lblOsmCIDR.Text = "255.0.0.0"
            Case "9"
                lblOsmCIDR.Text = "255.128.0.0"
            Case "10"
                lblOsmCIDR.Text = "255.192.0.0"
            Case "11"
                lblOsmCIDR.Text = "255.224.0.0"
            Case "12"
                lblOsmCIDR.Text = "255.240.0.0"
            Case "13"
                lblOsmCIDR.Text = "255.248.0.0"
            Case "14"
                lblOsmCIDR.Text = "255.252.0.0"
            Case "15"
                lblOsmCIDR.Text = "255.254.0.0"
            Case "16"
                lblOsmCIDR.Text = "255.255.0.0"
            Case "17"
                lblOsmCIDR.Text = "255.255.128.0"
            Case "18"
                lblOsmCIDR.Text = "255.255.192.0"
            Case "19"
                lblOsmCIDR.Text = "255.255.224.0"
            Case "20"
                lblOsmCIDR.Text = "255.255.240.0"
            Case "21"
                lblOsmCIDR.Text = "255.255.248.0"
            Case "22"
                lblOsmCIDR.Text = "255.255.252.0"
            Case "23"
                lblOsmCIDR.Text = "255.255.254.0"
            Case "24"
                lblOsmCIDR.Text = "255.255.255.0"
            Case "25"
                lblOsmCIDR.Text = "255.255.255.128"
            Case "26"
                lblOsmCIDR.Text = "255.255.255.192"
            Case "27"
                lblOsmCIDR.Text = "255.255.255.224"
            Case "28"
                lblOsmCIDR.Text = "255.255.255.240"
            Case "29"
                lblOsmCIDR.Text = "255.255.255.248"
            Case "30"
                lblOsmCIDR.Text = "255.255.255.252"
            Case "31"
                lblOsmCIDR.Text = "255.255.255.254"
            Case "32"
                lblOsmCIDR.Text = "255.255.255.255"
        End Select

        Dim bits As Integer
        bits = txtNetwork.Text
        Select Case bits
            Case 1
                lblBits.Text = "1"
            Case 2 To 3
                lblBits.Text = "2"
            Case 4 To 7
                lblBits.Text = "3"
            Case 8 To 15
                lblBits.Text = "4"
            Case 16 To 31
                lblBits.Text = "5"
            Case 32 To 63
                lblBits.Text = "6"
            Case 64 To 127
                lblBits.Text = "7"
            Case 128 To 255
                lblBits.Text = "8"
            Case 256 To 511
                lblBits.Text = "9"
            Case 512 To 1023
                lblBits.Text = "10"
            Case 1024 To 2047
                lblBits.Text = "11"
            Case 2048 To 4095
                lblBits.Text = "12"
            Case 4096 To 8191
                lblBits.Text = "13"
            Case 8192 To 16383
                lblBits.Text = "14"
            Case 16384 To 32767
                lblBits.Text = "15"
            Case 32768 To 65536
                lblBits.Text = "16"
            Case 65336 To 131071
                lblBits.Text = "17"
            Case 131072 To 262143
                lblBits.Text = "18"
            Case 262144 To 524287
                lblBits.Text = "19"
            Case 524288 To 1048575
                lblBits.Text = "20"
        End Select

        Dim firstoctet As String
        Dim secondoctet As String
        Dim thirdoctet As String
        Dim fourthoctet As String

        firstoctet = IntToBin(txt1octet.Text)
        secondoctet = IntToBin(txt2octet.Text)
        thirdoctet = IntToBin(txt3octet.Text)
        fourthoctet = IntToBin(txt4octet.Text)

        lblHost.Text = txtNetwork.Text
        lblIP.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text & " " & "/" & cboSM.Text
        lblAN.Text = 2 ^ Val(lblBits.Text)
        lblUsable.Text = 2 ^ (32 - Val(cboSM.Text)) - 2
        lblBinary.Text = firstoctet.ToString().PadLeft(8, "0") & " " & secondoctet.ToString().PadLeft(8, "0") & " " & thirdoctet.ToString().PadLeft(8, "0") & " " & fourthoctet.ToString().PadLeft(8, "0")
        lblNsm.Text = Val(cboSM.Text) + Val(lblBits.Text)
        lblAH.Text = 2 ^ (32 - Val(lblNsm.Text))
        lblUsable.Text = lblAH.Text - 2

        If txt1octet.Text <= 127 Then
            txtClass.Text = "A"

        ElseIf txt1octet.Text > 127 And txt1octet.Text < 192 Then
            txtClass.Text = "B"
        Else
            txtClass.Text = "C"
        End If

        Dim Menu As Integer
        Menu = lblNsm.Text
        Select Case Menu
            Case "1"
                lblCidr.Text = "128.0.0.0"
                lblIncrement.Text = "128"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                End If
            Case "2"
                lblCidr.Text = "192.0.0.0"
                lblIncrement.Text = "64"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                End If
            Case "3"
                lblCidr.Text = "224.0.0.0"
                lblIncrement.Text = "32"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                End If

            Case "4"
                lblCidr.Text = "240.0.0.0"
                lblIncrement.Text = "16"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                End If
            Case "5"
                lblCidr.Text = "248.0.0.0"
                lblIncrement.Text = "8"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                End If
            Case "6"
                lblCidr.Text = "252.0.0.0"
                lblIncrement.Text = "4"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                End If
            Case "7"
                lblCidr.Text = "254.0.0.0"
                lblIncrement.Text = "2"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                End If
            Case "8"
                lblCidr.Text = "255.0.0.0"
                lblIncrement.Text = "1"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt2octet.Text & "." & txt3octet.Text & "." & "254"
                End If

            Case "9"
                lblCidr.Text = "255.128.0.0"
                lblIncrement.Text = "128"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "254"
                End If
            Case "10"
                lblCidr.Text = "255.192.0.0"
                lblIncrement.Text = "64"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "254"
                End If
            Case "11"
                lblCidr.Text = "255.224.0.0"
                lblIncrement.Text = "32"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "254"
                End If
            Case "12"
                lblCidr.Text = "255.240.0.0"
                lblIncrement.Text = "16"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "254"
                End If
            Case "13"
                lblCidr.Text = "255.248.0.0"
                lblIncrement.Text = "8"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "254"
                End If
            Case "14"
                lblCidr.Text = "255.252.0.0"
                lblIncrement.Text = "4"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "254"
                End If
            Case "15"
                lblCidr.Text = "255.254.0.0"
                lblIncrement.Text = "2"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "254"
                End If
            Case "16"
                lblCidr.Text = "255.255.0.0"
                lblIncrement.Text = "1"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & "0" & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & "0" & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & "0" & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & "0" & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255" & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255" & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255" & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255" & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 & "." & txt3octet.Text & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 & "." & txt3octet.Text & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & txt3octet.Text & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & txt3octet.Text & "." & "254"
                End If
            Case "17"
                lblCidr.Text = "255.255.128.0"
                lblIncrement.Text = "128"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                End If
            Case "18"
                lblCidr.Text = "255.255.192.0"
                lblIncrement.Text = "64"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                End If
            Case "19"
                lblCidr.Text = "255.255.224.0"
                lblIncrement.Text = "32"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                End If
            Case "20"
                lblCidr.Text = "255.255.240.0"
                lblIncrement.Text = "16"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                End If
            Case "21"
                lblCidr.Text = "255.255.248.0"
                lblIncrement.Text = "8"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                End If
            Case "22"
                lblCidr.Text = "255.255.252.0"
                lblIncrement.Text = "4"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                End If
            Case "23"
                lblCidr.Text = "255.255.254.0"
                lblIncrement.Text = "2"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                End If
            Case "24"
                lblCidr.Text = "255.255.255.0"
                lblIncrement.Text = "1"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "255"
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "255"
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "255"
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & "1"
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 & "." & "1"
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 & "." & "1"
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 2 - 1 & "." & "254"
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 3 - 1 & "." & "254"
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 4 - 1 & "." & "254"
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) * 5 - 1 & "." & "254"
                End If
            Case "25"
                lblCidr.Text = "255.255.255.128"
                lblIncrement.Text = "128"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 2
                End If
            Case "26"
                lblCidr.Text = "255.255.255.192"
                lblIncrement.Text = "64"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 2
                End If
            Case "27"
                lblCidr.Text = "255.255.255.224"
                lblIncrement.Text = "32"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 2
                End If
            Case "28"
                lblCidr.Text = "255.255.255.240"
                lblIncrement.Text = "16"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 2
                End If
            Case "29"
                lblCidr.Text = "255.255.255.248"
                lblIncrement.Text = "8"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 2
                End If
            Case "30"
                lblCidr.Text = "255.255.255.252"
                lblIncrement.Text = "4"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 2
                End If
            Case "31"
                lblCidr.Text = "255.255.255.254"
                lblIncrement.Text = "2"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 2
                End If
            Case "32"
                lblCidr.Text = "255.255.255.255"
                lblIncrement.Text = "1"
                If txtClass.Text = "A" Then
                    lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "B" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 5 - 2

                ElseIf txtClass.Text = "C" Then
                    lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 1
                    lblBA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 1
                    lblBA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 1
                    lblBA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 1
                    lblBA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
                    lblFA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text + 1
                    lblFA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 + 1
                    lblFA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 + 1
                    lblFA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text - 2
                    lblLA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 2 - 2
                    lblLA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 3 - 2
                    lblLA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 4 - 2
                    lblLA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblIncrement.Text) * 5 - 2
                End If
        End Select


        txt1octet.Clear()
        txt2octet.Clear()
        txt3octet.Clear()
        txt4octet.Clear()
        txtNetwork.Clear()
        cboSM.Text = "8"
    End Sub
End Class