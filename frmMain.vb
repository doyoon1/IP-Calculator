Public Class frmMain

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        changemenu("Converter")
        RadioButton3.Checked = True
    End Sub
    Private Sub addForm(frm As Form)
        pnlContainer.Controls.Clear()
        frm.TopLevel = False
        frm.TopMost = True
        frm.Dock = DockStyle.Fill
        pnlContainer.Controls.Add(frm)
        frm.Show()
    End Sub
    Private Sub changemenu(menu As String)
        Select Case menu
            Case "Ip"
                addForm(Form1)
            Case "Converter"
                addForm(frmConversion)
            Case "Subnet"
                addForm(frmSubnetting)
            Case "VLSM"
                addForm(frmVLSM)
        End Select
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        changemenu("Converter")
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        changemenu("Ip")
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        changemenu("Subnet")
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        changemenu("VLSM")
    End Sub

End Class