Public Class login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim user As String
        Dim userpass As String

        user = txtuser.Text
        userpass = txtpass.Text

        If (user.Equals("Admin") And userpass.Equals("Admin@123")) Then
            Me.Close()
            txtuser.Clear()
            txtpass.Clear()
            resevetionpage.Show()
        Else
            MessageBox.Show("Error : Please Try Again...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Application.Exit()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Hide()
        Adminloagin.Show()
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class