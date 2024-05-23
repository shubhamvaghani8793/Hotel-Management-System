Imports System.Data.OleDb

Public Class client

    Public Sub Recordshow()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim adp As New OleDbDataAdapter("select * from reservation", con)
        Dim ds As New DataSet
        adp.Fill(ds, "client")
        DataGridView1.DataSource = ds.Tables("client")
        con.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) 
        Me.Hide()
        Staffs.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 
        Me.Hide()
        resevetionpage.Show()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update reservation set room_no=" & roomno.Text & ", c_name='" & cname.Text & "', c_age=" & age.Text & ", gender='" & gender.Text & "', coutry='" & country.Text & "' where c_id=" & cid.Text & " "
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record Updated Successfully....")
        Recordshow()
    End Sub

    Private Sub client_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Recordshow()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from reservation where c_id=" & cid.Text & ""
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record Deleted Successfully.....")
        Recordshow()
    End Sub
End Class