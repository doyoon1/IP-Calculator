Public Class Network
    Private Function IntToBin(ByVal intValue As Integer) As String
        Dim sb As New System.Text.StringBuilder
        While intValue <> 0
            sb.Insert(0, (intValue Mod 2).ToString())
            intValue \= 2
        End While
        Return sb.ToString()
    End Function

    Private Sub txtCompute_Click(sender As Object, e As EventArgs) Handles txtCompute.Click
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

        lblNetwork.Text = txtNetwork.Text
        lblIP.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text & " " & "/" & nudOsm.Text
        lblHost.Text = "Host: " & 2 ^ (32 - Val(nudOsm.Text))
        lblUsable.Text = "Usable Host: " & 2 ^ (32 - Val(nudOsm.Text)) - 2
        lblBinary.Text = "Binary: " & firstoctet.ToString().PadLeft(8, "0") & " " & secondoctet.ToString().PadLeft(8, "0") & " " & thirdoctet.ToString().PadLeft(8, "0") & " " & fourthoctet.ToString().PadLeft(8, "0")
        lblNsm.Text = Val(nudOsm.Text) + Val(lblBits.Text)

        If txt1octet.Text <= 127 Then
            txtClass.Text = "A"
            lblNA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "0"

            If txt2octet.Text Or txt3octet.Text = 0 Then
                lblBA1.Text = txt1octet.Text - 1 & "." & "255" & "." & "255" & "." & "255"
            End If
            lblFA1.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & "1"
            lblLA1.Text = txt1octet.Text - 1 & "." & "255" & "." & "255" & "." & "254"

        ElseIf txt1octet.Text > 127 And txt1octet.Text < 192 Then
            txtClass.Text = "B"
            lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "0"

            If txt3octet.Text Or txt4octet.Text = 0 Then
                lblBA1.Text = txt1octet.Text & "." & txt2octet.Text - 1 & "." & "255" & "." & "255"
                lblLA1.Text = txt1octet.Text & "." & txt2octet.Text - 1 & "." & "255" & "." & "254"
                If txt2octet.Text < 1 Then
                    lblBA1.Text = txt1octet.Text & "." & "0" & "." & "255" & "." & "255"
                    lblLA1.Text = txt1octet.Text & "." & "0" & "." & "255" & "." & "254"
                End If
            End If
            lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & "1"
        Else
            txtClass.Text = "C"
            lblNA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"

            If txt4octet.Text Or txt4octet.Text = 0 Then
                lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text - 1 & "." & "255"
                lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text - 1 & "." & "254"
                If txt3octet.Text < 1 Then
                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "255" & "." & "255"
                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & "255" & "." & "254"
                End If
            End If
            lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"
        End If

        Dim Menu As Integer
        Menu = lblNsm.Text
        Select Case Menu
            Case "1"
                lblCidr.Text = "128.0.0.0"
                lblIncrement.Text = "128"
                If txtClass.Text = "A" Then
                    lblNA2.Text = lblIncrement.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                End If
            Case "2"
                lblCidr.Text = "192.0.0.0"
                lblIncrement.Text = "64"
                If txtClass.Text = "A" Then
                    lblNA2.Text = lblIncrement.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                End If
            Case "3"
                lblCidr.Text = "224.0.0.0"
                lblIncrement.Text = "32"
                If txtClass.Text = "A" Then
                    lblNA2.Text = lblIncrement.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                End If

            Case "4"
                lblCidr.Text = "240.0.0.0"
                lblIncrement.Text = "16"
                If txtClass.Text = "A" Then
                    lblNA2.Text = lblIncrement.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                End If
            Case "5"
                If txtClass.Text = "A" Then
                    lblNA2.Text = lblIncrement.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                End If
            Case "6"
                lblCidr.Text = "252.0.0.0"
                lblIncrement.Text = "4"
                If txtClass.Text = "A" Then
                    lblNA2.Text = lblIncrement.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                End If
            Case "7"
                lblCidr.Text = "254.0.0.0"
                lblIncrement.Text = "2"
                If txtClass.Text = "A" Then
                    lblNA2.Text = lblIncrement.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                End If
            Case "8"
                lblCidr.Text = "255.0.0.0"
                lblIncrement.Text = "1"
                If txtClass.Text = "A" Then
                    lblNA2.Text = lblIncrement.Text & "." & "0" & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = lblIncrement.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & "0"
                End If
            Case "9"
                lblCidr.Text = "255.128.0.0"
                lblIncrement.Text = "128"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & lblIncrement.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                End If
            Case "10"
                lblCidr.Text = "255.192.0.0"
                lblIncrement.Text = "64"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & lblIncrement.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                End If
            Case "11"
                lblCidr.Text = "255.224.0.0"
                lblIncrement.Text = "32"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & lblIncrement.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                End If
            Case "12"
                lblCidr.Text = "255.240.0.0"
                lblIncrement.Text = "16"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & lblIncrement.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                End If
            Case "13"
                lblCidr.Text = "255.248.0.0"
                lblIncrement.Text = "8"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & lblIncrement.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                End If
            Case "14"
                lblCidr.Text = "255.252.0.0"
                lblIncrement.Text = "4"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & lblIncrement.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                End If
            Case "15"
                lblCidr.Text = "255.254.0.0"
                lblIncrement.Text = "2"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & lblIncrement.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                End If
            Case "16"
                lblCidr.Text = "255.255.0.0"
                lblIncrement.Text = "1"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & lblIncrement.Text & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0" & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & "0"
                End If
            Case "17"
                lblCidr.Text = "255.255.128.0"
                lblIncrement.Text = "128"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                End If
            Case "18"
                lblCidr.Text = "255.255.192.0"
                lblIncrement.Text = "64"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                End If
            Case "19"
                lblCidr.Text = "255.255.224.0"
                lblIncrement.Text = "32"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                End If
            Case "20"
                lblCidr.Text = "255.255.240.0"
                lblIncrement.Text = "16"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                End If
            Case "21"
                lblCidr.Text = "255.255.248.0"
                lblIncrement.Text = "8"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 2 & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) * 3 & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblIncrement.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                End If
            Case "22"
                lblCidr.Text = "255.255.252.0"
                lblIncrement.Text = "4"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                End If
            Case "23"
                lblCidr.Text = "255.255.254.0"
                lblIncrement.Text = "2"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                End If
            Case "24"
                lblCidr.Text = "255.255.255.0"
                lblIncrement.Text = "1"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & lblIncrement.Text & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text) & "." & "0"
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text) & "." & "0"
                End If
            Case "25"
                lblCidr.Text = "255.255.255.128"
                lblIncrement.Text = "128"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                End If
            Case "26"
                lblCidr.Text = "255.255.255.192"
                lblIncrement.Text = "64"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                End If
            Case "27"
                lblCidr.Text = "255.255.255.224"
                lblIncrement.Text = "32"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                End If
            Case "28"
                lblCidr.Text = "255.255.255.240"
                lblIncrement.Text = "16"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                End If
            Case "29"
                lblCidr.Text = "255.255.255.248"
                lblIncrement.Text = "8"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                End If
            Case "30"
                lblCidr.Text = "255.255.255.252"
                lblIncrement.Text = "4"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                End If
            Case "31"
                lblCidr.Text = "255.255.255.254"
                lblIncrement.Text = "2"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                End If
            Case "32"
                lblCidr.Text = "255.255.255.255"
                lblIncrement.Text = "1"
                If txtClass.Text = "A" Then
                    lblNA2.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & "0" & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "B" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & "0" & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                ElseIf txtClass.Text = "C" Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & lblIncrement.Text
                    lblNA3.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA2.Text) + Val(lblIncrement.Text)
                    lblNA4.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA3.Text) + Val(lblIncrement.Text)
                    lblNA5.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & Val(lblNA4.Text) + Val(lblIncrement.Text)
                End If
        End Select

        lblAH.Text = 2 ^ Val(lblBits.Text)

        txt1octet.Clear()
        txt2octet.Clear()
        txt3octet.Clear()
        txt4octet.Clear()
        txtNetwork.Clear()
        nudOsm.ResetText()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles nudOsm.ValueChanged
        Me.nudOsm.Minimum = 1
        Me.nudOsm.Maximum = 32
    End Sub
End Class