Public Class frmSubnetting
    Private Sub frmSubnetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        changemenu("Host")
        RadioButton4.Checked = True
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
            Case "Network"
                addForm(frmNetwork)
            Case "Host"
                addForm(frmHost)
        End Select
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        changemenu("Host")
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        changemenu("Network")
    End Sub
End Class