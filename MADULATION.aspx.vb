Imports System.Data
Imports System.Data.SqlClient
Public Class WebForm6
    Inherits System.Web.UI.Page
    Dim con As SqlConnection
    Dim cd As SqlCommand
    Dim ds As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con = New SqlConnection("Data Source=COMPUTER-40;Initial Catalog=RENTALSYS;Integrated Security=True;Pooling=False")
        con.Open()
        cd = New SqlCommand("select * from uploadproduct", con)
        Dim myd As SqlDataReader = cd.ExecuteReader
        While myd.Read = True
            DropDownList1.Items.Add(myd.GetValue(0))
        End While
        con.Close()
        

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        con.Open()
        cd = New SqlCommand("update UPLOADPRODUCT set RENT='" + TextBox1.Text + "' where pid='" + DropDownList1.SelectedItem.Value + "'", con)
        Dim myd1 As SqlDataReader = cd.ExecuteReader
        While myd1.Read = True
            TextBox1.Text = myd1.GetValue(3)
            cd.ExecuteNonQuery()
            MsgBox("Record updated")
        End While
        con.Close()
       
        con.Close()

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        con.Open()
        cd = New SqlCommand("delete from UPLOADPRODUCT where pid='" + DropDownList1.SelectedItem.Value + "'", con)
        Dim myd As SqlDataReader = cd.ExecuteReader
        While myd.Read = True
            TextBox1.Text = myd.GetValue(3)
            cd.ExecuteNonQuery()
            MsgBox("Record deleted")
        End While
        con.Close()


    End Sub

  
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Response.Redirect("admin.aspx")
    End Sub

   
End Class