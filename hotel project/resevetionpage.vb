Imports System.Data.OleDb
Imports System.Data
Imports System.Security.Cryptography
Public Class resevetionpage
    Public Sub Recordshow()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim adp As New OleDbDataAdapter("select * from reservation", con)
        Dim ds As New DataSet
        adp.Fill(ds, "client")
        DataGridView1.DataSource = ds.Tables("client")
        con.Close()
    End Sub

    Sub cleardata()
        id.Clear()
        roomno.Clear()
        name.Clear()
        age.Clear()
        gender.ResetText()
        country.Clear()
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into reservation values(" & id.Text & ", " & roomno.Text & ", '" & name.Text & "', " & age.Text & ", '" & gender.Text & "', '" & country.Text & "') "
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record Added Successfully.....")
        cleardata()
        Recordshow()
    End Sub

    Private Sub Resevetionpage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Recordshow()
        DataGridView1.Columns(0).HeaderText = "ID"
        DataGridView1.Columns(1).HeaderText = "Room No"
        DataGridView1.Columns(2).HeaderText = "Name"
        DataGridView1.Columns(3).HeaderText = "Age"
        DataGridView1.Columns(4).HeaderText = "Gender"
        DataGridView1.Columns(5).HeaderText = "Country"

        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update reservation set room_no=" & roomno.Text & ", c_name='" & name.Text & "', c_age=" & age.Text & ", gender='" & gender.Text & "', coutry='" & country.Text & "' where c_id=" & id.Text & " "
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record Updated Successfully.....")
        cleardata()
        Recordshow()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        login.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from reservation where c_id=" & id.Text & ""
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record Deleted Successfully.....")
        id.Clear()
        Recordshow()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        payment.Show()
    End Sub
End Class