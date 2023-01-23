Imports System.Data.OleDb
Public Class frmVLSM
    Private Function IntToBin(ByVal intValue As Integer) As String
        Dim sb As New System.Text.StringBuilder
        While intValue <> 0
            sb.Insert(0, (intValue Mod 2).ToString())
            intValue \= 2
        End While
        Return sb.ToString()
    End Function

    Private Sub frmVLSM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connection()
        Call VLSMdb()
    End Sub

    Public Sub VLSMdb()
        sql = "Select Host,Bits,NSM,Increment,NA,BA,FA,LA from VLSM"
        cmd = New OleDbCommand(sql, cn)
        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        dgvStocks.DataSource = dt
    End Sub

    Private Sub btnCompute_Click(sender As Object, e As EventArgs) Handles btnCompute.Click
        Dim bits As Integer
        bits = txtHost.Text
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
            Case 524288 To 1048557
                lblBits.Text = "20"
            Case 1048558 To 2097150
                lblBits.Text = "21"
            Case 2097151 To 4194300
                lblBits.Text = "22"
            Case 4194301 To 8388600
                lblBits.Text = "23"
            Case 8388601 To 16777200
                lblBits.Text = "24"
            Case 16777201 To 33554400
                lblBits.Text = "25"
        End Select

        Dim firstoctet As String
        Dim secondoctet As String
        Dim thirdoctet As String
        Dim fourthoctet As String

        firstoctet = IntToBin(txt1octet.Text)
        secondoctet = IntToBin(txt2octet.Text)
        thirdoctet = IntToBin(txt3octet.Text)
        fourthoctet = IntToBin(txt4octet.Text)

        lblHost.Text = txtHost.Text
        lblIP.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text & " " & "/" & cboSM.Text
        lblUsable.Text = 2 ^ (32 - Val(cboSM.Text)) - 2
        lblBinary.Text = firstoctet.ToString().PadLeft(8, "0") & " " & secondoctet.ToString().PadLeft(8, "0") & " " & thirdoctet.ToString().PadLeft(8, "0") & " " & fourthoctet.ToString().PadLeft(8, "0")
        lblNsm.Text = 32 - Val(lblBits.Text)
        lblAH.Text = 2 ^ (32 - Val(lblNsm.Text))
        lblUsable.Text = lblAH.Text - 2
        lblAN.Text = 2 ^ Val(cboSM.Text) - Val(lblNsm.Text)

        If String.IsNullOrWhiteSpace(txt1octet.Text) OrElse String.IsNullOrWhiteSpace(txt2octet.Text) OrElse String.IsNullOrWhiteSpace(txt3octet.Text) OrElse String.IsNullOrWhiteSpace(txt4octet.Text) Then
            MessageBox.Show("Please enter a value in all octet fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not Integer.TryParse(txt4octet.Text, fourthoctet) Then
            ' Handle invalid input, for example show error message
            Return
        End If
        If fourthoctet > 255 Then
            thirdoctet += 1
            fourthoctet = 0
        End If
        If thirdoctet > 255 Then
            secondoctet += 1
            thirdoctet = 0
        End If
        If secondoctet > 255 Then
            firstoctet += 1
            secondoctet = 0
        End If


        Dim Menu As Integer
        Menu = lblNsm.Text
        Select Case Menu
            Case "8"
                lblCidr.Text = "255.0.0.0"
                lblIncrement.Text = "1"

                lblNA2.Text = txt1octet.Text + Val(lblIncrement.Text) & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text

                lblBA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "255"

                lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                lblLA1.Text = txt1octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255" & "." & "254"
            Case "9"
                lblCidr.Text = "255.128.0.0"
                lblIncrement.Text = "128"
                If txt2octet.Text > 255 Or txt2octet.Text = 256 Then
                    lblNA2.Text = Val(txt1octet.Text) + 1 & "." & "0" & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                End If
            Case "10"
                lblCidr.Text = "255.192.0.0"
                lblIncrement.Text = "64"
                If txt2octet.Text > 255 Or txt2octet.Text = 256 Then
                    lblNA2.Text = Val(txt1octet.Text) + 1 & "." & "0" & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                End If
            Case "11"
                lblCidr.Text = "255.224.0.0"
                lblIncrement.Text = "32"
                If txt2octet.Text > 255 Or txt2octet.Text = 256 Then
                    lblNA2.Text = Val(txt1octet.Text) + 1 & "." & "0" & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                End If
            Case "12"
                lblCidr.Text = "255.240.0.0"
                lblIncrement.Text = "16"
                If txt2octet.Text > 255 Or txt2octet.Text = 256 Then
                    lblNA2.Text = Val(txt1octet.Text) + 1 & "." & "0" & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                End If
            Case "13"
                lblCidr.Text = "255.248.0.0"
                lblIncrement.Text = "8"
                If txt2octet.Text > 255 Or txt2octet.Text = 256 Then
                    lblNA2.Text = Val(txt1octet.Text) + 1 & "." & "0" & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                End If
            Case "14"
                lblCidr.Text = "255.252.0.0"
                lblIncrement.Text = "4"
                If txt2octet.Text > 255 Or txt2octet.Text = 256 Then
                    lblNA2.Text = Val(txt1octet.Text) + 1 & "." & "0" & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                End If
            Case "15"
                lblCidr.Text = "255.254.0.0"
                lblIncrement.Text = "2"
                If txt2octet.Text > 255 Or txt2octet.Text = 256 Then
                    lblNA2.Text = Val(txt1octet.Text) + 1 & "." & "0" & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                End If
            Case "16"
                lblCidr.Text = "255.255.0.0"
                lblIncrement.Text = "1"
                If txt2octet.Text > 255 Or txt2octet.Text = 256 Then
                    lblNA2.Text = Val(txt1octet.Text) + 1 & "." & "0" & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) & "." & txt3octet.Text & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text + Val(lblIncrement.Text) - 1 & "." & "255" & "." & "254"
                End If

            Case "17"
                lblCidr.Text = "255.255.128.0"
                lblIncrement.Text = "128"
                If txt3octet.Text > 255 Or txt3octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + 1 & "." & "0" & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                End If
            Case "18"
                lblCidr.Text = "255.255.192.0"
                lblIncrement.Text = "64"
                If txt3octet.Text > 255 Or txt3octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + 1 & "." & "0" & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                End If
            Case "19"
                lblCidr.Text = "255.255.224.0"
                lblIncrement.Text = "32"
                If txt3octet.Text > 255 Or txt3octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + 1 & "." & "0" & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                End If
            Case "20"
                lblCidr.Text = "255.255.240.0"
                lblIncrement.Text = "16"
                If txt3octet.Text > 255 Or txt3octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + 1 & "." & "0" & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                End If
            Case "21"
                lblCidr.Text = "255.255.248.0"
                lblIncrement.Text = "8"
                If txt3octet.Text > 255 Or txt3octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + 1 & "." & "0" & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                End If
            Case "22"
                lblCidr.Text = "255.255.252.0"
                lblIncrement.Text = "4"
                If txt3octet.Text > 255 Or txt3octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + 1 & "." & "0" & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                End If
            Case "23"
                lblCidr.Text = "255.255.254.0"
                lblIncrement.Text = "2"
                If txt3octet.Text > 255 Or txt3octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + 1 & "." & "0" & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                End If
            Case "24"
                lblCidr.Text = "255.255.255.0"
                lblIncrement.Text = "1"
                If txt3octet.Text > 255 Or txt3octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & Val(txt2octet.Text) + 1 & "." & "0" & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) & "." & txt4octet.Text

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "255"

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & "1"

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text + Val(lblIncrement.Text) - 1 & "." & "254"
                End If

            Case "25"
                lblCidr.Text = "255.255.255.128"
                lblIncrement.Text = "128"
                If txt4octet.Text > 255 Or txt4octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + 1 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text)

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                End If

            Case "26"
                lblCidr.Text = "255.255.255.192"
                lblIncrement.Text = "64"
                If txt4octet.Text > 255 Or txt4octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + 1 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text)

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                End If

            Case "27"
                lblCidr.Text = "255.255.255.224"
                lblIncrement.Text = "32"

                'If txt4octet.Text > 255 Or txt4octet.Text = 256 Then
                '    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + 1 & "." & "0"

                '    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                '    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                '    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                'Else
                lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text)

                lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                'End If

            Case "28"
                lblCidr.Text = "255.255.255.240"
                lblIncrement.Text = "16"
                If txt4octet.Text > 255 Or txt4octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + 1 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text)

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                End If

            Case "29"
                lblCidr.Text = "255.255.255.248"
                lblIncrement.Text = "8"
                If txt4octet.Text > 255 Or txt4octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + 1 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text)

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                End If

            Case "30"
                lblCidr.Text = "255.255.255.252"
                lblIncrement.Text = "4"
                If txt4octet.Text > 255 Or txt4octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + 1 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text)

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                End If

            Case "31"
                lblCidr.Text = "255.255.255.254"
                lblIncrement.Text = "2"
                If txt4octet.Text > 255 Or txt4octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + 1 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text)

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                End If

            Case "32"
                lblCidr.Text = "255.255.255.255"
                lblIncrement.Text = "1"
                If txt4octet.Text > 255 Or txt4octet.Text = 256 Then
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + 1 & "." & "0"

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & Val(txt3octet.Text) + 1 & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                Else
                    lblNA2.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text)

                    lblBA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 1

                    lblFA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + 1

                    lblLA1.Text = txt1octet.Text & "." & txt2octet.Text & "." & txt3octet.Text & "." & txt4octet.Text + Val(lblIncrement.Text) - 2
                End If

        End Select

        sql = "Insert into [VLSM](Host,Bits,NSM,Increment,NA,BA,FA,LA)Values('" & txtHost.Text & "','" & lblBits.Text & "','" & lblNsm.Text & "','" & lblIncrement.Text & "','" & lblNA2.Text & "','" & lblBA1.Text & "','" & lblFA1.Text & "','" & lblLA1.Text & "')"
        cmd = New OleDbCommand(sql, cn)
        cmd.ExecuteNonQuery()
        Call VLSMdb()

        txt1octet.Clear()
        txt2octet.Clear()
        txt3octet.Clear()
        txt4octet.Clear()
        cboSM.ResetText()
        cboSM.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sql = "Delete Host,Bits,NSM,Increment,NA,BA,FA,LA from VLSM"
        cmd = New OleDbCommand(sql, cn)
        cmd.ExecuteNonQuery()
        Call VLSMdb()
    End Sub
End Class