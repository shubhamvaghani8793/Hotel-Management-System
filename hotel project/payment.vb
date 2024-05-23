Imports System.Data.OleDb
Public Class payment

    Sub recordshow()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim adp As New OleDbDataAdapter("select * from payment", con)
        Dim ds As New DataSet
        adp.Fill(ds, "pay")
        dgv1.DataSource = ds.Tables("pay")
        con.Close()
    End Sub

    Sub cleardata()
        pid.Clear()
        cid.Clear()
        ptype.ResetText()
        amt.Clear()
        pdate.ResetText()
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
        cmd.CommandText = "insert into payment values(" & pid.Text & ", " & cid.Text & ", '" & ptype.Text & "', " & amt.Text & ", '" & pdate.Value & "')"
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record Add successfully.....")
        recordshow()
        cleardata()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from payment where pay_id=" & pid.Text & ""
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Recorn Deleted Success.....")
        recordshow()
        cleardata()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Shubham\source\repos\hotel project\hotelDB.accdb")
        con.Open()
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update payment set c_id=" & cid.Text & ", type='" & ptype.Text & "', amount=" & amt.Text & ", pdate='" & pdate.Value & "' "
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record Updated Successfully.....")
        recordshow()
        cleardata()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        resevetionpage.Show()
    End Sub

    Private Sub payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        recordshow()

        dgv1.Columns(0).HeaderText = "Pay ID"
        dgv1.Columns(1).HeaderText = "Client ID"
        dgv1.Columns(2).HeaderText = "Type"
        dgv1.Columns(3).HeaderText = "Amount"
        dgv1.Columns(4).HeaderText = "Date"


    End Sub
End Class