Imports System
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Page
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Drawing
Imports System.Data.SqlClient
Public Class WebForm14
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
        cmd = New SqlCommand("select * from PAYMENT", con)
        da = New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        TextBox1.Text = "PAY" & (dt.Rows.Count + 1).ToString()
        con.Close()

        con.Open()
        cmd = New SqlCommand("select * from BOOKING", con)
        Dim myd As SqlDataReader = cmd.ExecuteReader
        While myd.Read = True
            TextBox7.Text = myd.GetValue(7)
        End While
        con.Close()
        
        TextBox4.Text = DateTime.Now.ToString()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        con.Open()
        cmd = New SqlCommand("insert into PAYMENT values(@TID,@FNAME,@LNAME,@PDATE,@PMODE,@TAMOUNT,@CARDNUMBER,@BANK)", con)
        cmd.Parameters.AddWithValue("@TID", TextBox1.Text)
        cmd.Parameters.AddWithValue("@FNAME", TextBox2.Text)
        cmd.Parameters.AddWithValue("@LNAME", TextBox3.Text)
        cmd.Parameters.AddWithValue("@PDATE", TextBox4.Text)
        cmd.Parameters.AddWithValue("@PMODE", DropDownList2.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@TAMOUNT", TextBox7.Text)
        cmd.Parameters.AddWithValue("@CARDNUMBER", TextBox5.Text)
        cmd.Parameters.AddWithValue("@BANK", TextBox6.Text)
        cmd.ExecuteNonQuery()
        MsgBox("TRANSACTION SUCCESSFULLY")
        Response.Redirect("houseinvoice.aspx")
        con.Close()
    End Sub

  

   

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click
        Response.Redirect("booking.aspx")
    End Sub

    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class