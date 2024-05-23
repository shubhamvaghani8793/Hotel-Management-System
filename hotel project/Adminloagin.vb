Public Class Adminloagin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pass As String

        pass = txtpass.Text

        If (pass.Equals("Admin@123")) Then
            Me.Hide()
            Staffs.Show()
        Else
            MessageBox.Show("Error : Please Try Again...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Application.Exit()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Hide()
        txtpass.Clear()
        login.Show()
    End Sub

    Private Sub txtpass_TextChanged(sender As Object, e As EventArgs) Handles txtpass.TextChanged

    End Sub

    Private Sub Adminloagin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class