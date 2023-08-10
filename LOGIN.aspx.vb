Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con = New SqlConnection("Data Source=COMPUTER-40;Initial Catalog=RENTALSYS;Integrated Security=True;Pooling=False")

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        con.Open()

        cmd = New SqlCommand("select * from login where username='" & TextBox1.Text & "'and pwd='" & TextBox2.Text & "'", con)
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            Response.Redirect("BOOKINGPRO.aspx")
        Else
            MsgBox("Give valid username or password")
        End If
        dr.Close()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        con.Open()
        If TextBox1.Text = "admin" And TextBox2.Text = "rental" Then
            Response.Redirect("ADMIN.aspx")
        Else
            MsgBox("Give valid username and password")
        End If
    End Sub
End Class