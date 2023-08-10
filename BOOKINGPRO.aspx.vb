Imports System
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Page
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Public Class WebForm9
    Inherits System.Web.UI.Page
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con = New SqlConnection("Data Source=COMPUTER-40;Initial Catalog=RENTALSYS;Integrated Security=True;Pooling=False")
        con.Open()
        cmd = New SqlCommand("select * from UPLOADPRODUCT", con)
        Dim myd1 As SqlDataReader = cmd.ExecuteReader
        While myd1.Read = True
            DropDownList1.Items.Add(myd1.GetValue(0))
        End While
        con.Close()
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("BOOKING.ASPX")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        GridView1.Visible = True
        con.Open()
        cmd = New SqlCommand("select * from UPLOADPRODUCT where PID='" + DropDownList1.SelectedItem.Value + "'", con)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet
        da.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        con.Close()
    End Sub
End Class