Imports System
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Page
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Public Class WebForm11
    Inherits System.Web.UI.Page
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con = New SqlConnection("Data Source=COMPUTER-40;Initial Catalog=RENTALSYS;Integrated Security=True;Pooling=False")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Label1.Text = "CUSTOMER DETAILS"
        GridView1.Visible = True
        con.Open()
        cmd = New SqlCommand("select * from login", con)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        con.Close()
    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Label1.Text = "PRODUCT DETAILS"
        GridView1.Visible = True
        con.Open()
        cmd = New SqlCommand("select * from uploadproduct", con)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        con.Close()
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Label1.Text = "BOOKING DETAILS"
        GridView1.Visible = True
        con.Open()
        cmd = New SqlCommand("select * from booking", con)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        con.Close()
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Label1.Text = "BILLING DETAILS"
        GridView1.Visible = True
        con.Open()
        cmd = New SqlCommand("select * from invoice", con)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        con.Close()
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click
        Label1.Text = "PAYMENT DETAILS"
        GridView1.Visible = True
        con.Open()
        cmd = New SqlCommand("select * from payment", con)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        con.Close()
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click
        Label1.Text = "FEEDBACK DETAILS"
        GridView1.Visible = True
        con.Open()
        cmd = New SqlCommand("select * from feedback", con)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        con.Close()
    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button7.Click
        Response.Redirect("admin.aspx")
    End Sub
End Class