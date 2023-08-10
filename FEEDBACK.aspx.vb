Imports System
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Page
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Drawing
Imports System.Data.SqlClient

Public Class WebForm5
    Inherits System.Web.UI.Page
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim reader As SqlDataReader
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim dt As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con = New SqlConnection("Data Source=COMPUTER-40;Initial Catalog=RENTALSYS;Integrated Security=True;Pooling=False")
        con.Open()
        cmd = New SqlCommand("select * from feedback", con)
        da = New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        TextBox6.Text = "fb_" & (dt.Rows.Count + 1).ToString()
        con.Close()

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        con.Open()
        cmd = New SqlCommand("insert into FEEDBACK values(@FID,@FIRSTNAME,@LASTNAME,@PHONENO,@EMAIL,@SUGGESTION,@REMARKS)", con)
        cmd.Parameters.AddWithValue("@FID", TextBox6.Text)
        cmd.Parameters.AddWithValue("@FIRSTNAME", TextBox1.Text)
        cmd.Parameters.AddWithValue("@LASTNAME", TextBox2.Text)
        cmd.Parameters.AddWithValue("@PHONENO", TextBox3.Text)
        cmd.Parameters.AddWithValue("@EMAIL", TextBox4.Text)
        cmd.Parameters.AddWithValue("@SUGGESTION", TextBox5.Text)
        cmd.Parameters.AddWithValue("@REMARKS", DropDownList1.SelectedItem.Text)
        cmd.ExecuteNonQuery()
        MsgBox("THANK YOU FOR YOUR FEEDBACK")
        con.Close()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Response.Redirect("LASTPAGE.aspx")
    End Sub
End Class