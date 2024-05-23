Imports System.Data.OleDb
Imports System.Data
Public Class Staffs
    Public Sub recordshow()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim adp As New OleDbDataAdapter("select * from staff", con)
        Dim ds As New DataSet
        adp.Fill(ds, "staff")
        DataGridView2.DataSource = ds.Tables("staff")
        con.Close()
    End Sub

    Sub dataclean()
        staffid.Clear()
        staffname.Clear()
        staffage.Clear()
        staffgender.ResetText()
        staffpass.Clear()

    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Application.Exit()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        login.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into staff values(" & staffid.Text & ", '" & staffname.Text & "', " & staffage.Text & ", '" & staffgender.Text & "', '" & staffpass.Text & "')"
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record Added Successfully.....")
        dataclean()
        recordshow()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from staff where s_id=" & staffid.Text & " "
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record Deleted Successfully.....")
        dataclean()
        recordshow()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update staff set s_name='" & staffname.Text & "', s_age=" & staffage.Text & ", s_gender='" & staffgender.Text & "', s_password='" & staffpass.Text & "' where s_id=" & staffid.Text & " "
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record Updated Successfully.....")
        dataclean()
        recordshow()
    End Sub

    Private Sub Staffs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        recordshow()
        DataGridView2.Columns(0).HeaderText = "ID"
        DataGridView2.Columns(1).HeaderText = "Name"
        DataGridView2.Columns(2).HeaderText = "Age"
        DataGridView2.Columns(3).HeaderText = "Gender"
        DataGridView2.Columns(4).HeaderText = "Password"

    End Sub
End Class