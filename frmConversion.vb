Public Class frmConversion
    Private Function IntToBin(intValue As Integer) As String
        Dim sb As New System.Text.StringBuilder
        While intValue.ToString <> 0
            sb.Insert(0, (intValue Mod 2).ToString())
            intValue \= 2
        End While
        Return sb.ToString()
    End Function
    Private Sub txtCompute_Click(sender As Object, e As EventArgs) Handles txtCompute.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Please enter a value in the decimal field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim dec As String
        Dim hexString As String = Nothing

        Label5.Text = "Decimal: " & TextBox1.Text
        dec = IntToBin(TextBox1.Text.ToString)
        Label2.Text = "Binary: " & dec.ToString().PadLeft(8, "0")

        dec = Int(TextBox1.Text.Trim)
        hexString = Hex(dec)
        Label3.Text = "Hexadecimal: " & hexString
        TextBox1.Clear()
    End Sub

End Class