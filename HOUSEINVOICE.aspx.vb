Imports System
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Page
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Drawing
Imports System.Data.SqlClient
Public Class WebForm12
    Inherits System.Web.UI.Page
    Dim con As SqlConnection
    Dim cmd, cmd1 As SqlCommand
    Dim reader As SqlDataReader
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim dt As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con = New SqlConnection("Data Source=COMPUTER-40;Initial Catalog=RENTALSYS;Integrated Security=True;Pooling=False")
          con.Open()
        cmd = New SqlCommand("select * from INVOICE", con)
        da = New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        TextBox15.Text = "BILL_" & (dt.Rows.Count + 1).ToString()
        con.Close()
        
        con.Open()
        cmd = New SqlCommand("select * from BOOKING", con)
        Dim myd2 As SqlDataReader = cmd.ExecuteReader
        While myd2.Read = True
            TextBox16.Text = myd2.GetValue(1)
            TextBox9.Text = myd2.GetValue(9)
            TextBox10.Text = myd2.GetValue(2)
            TextBox13.Text = myd2.GetValue(4)
            TextBox14.Text = myd2.GetValue(7)
        End While
        con.Close()

        con.Open()
        cmd = New SqlCommand("select * from LOGIN", con)
        Dim myd3 As SqlDataReader = cmd.ExecuteReader
        While myd3.Read = True
            TextBox17.Text = myd3.GetValue(0)
            TextBox2.Text = myd3.GetValue(3)
            TextBox3.Text = myd3.GetValue(4)
            TextBox4.Text = myd3.GetValue(12)

        End While
        con.Close()

        

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        con.Open()
        cmd = New SqlCommand("insert into invoice values(@firstname,@lastname,@mobileno,@destination,@pid,@noofdays,@totalamount,@cid,@billid,@bdate)", con)
        cmd.Parameters.AddWithValue("@firstname", TextBox2.Text)
        cmd.Parameters.AddWithValue("@lastname", TextBox3.Text)
        cmd.Parameters.AddWithValue("@mobileno", TextBox4.Text)
        cmd.Parameters.AddWithValue("@destination", TextBox9.Text)
        cmd.Parameters.AddWithValue("@pid", TextBox10.Text)
        cmd.Parameters.AddWithValue("@noofdays", TextBox13.Text)
        cmd.Parameters.AddWithValue("@totalamount", TextBox14.Text)
        cmd.Parameters.AddWithValue("@cid", TextBox17.Text)

 cmd.Parameters.AddWithValue("@billid", TextBox15.Text)
        cmd.Parameters.AddWithValue("@bdate", TextBox16.Text)
        cmd.ExecuteNonQuery()
        MsgBox("BILL completed")
        con.Close()

    End Sub

   
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Response.Redirect("feedback.aspx")
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Response.Redirect("payment.aspx")
    End Sub
End Class