Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class WebForm3
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
        cmd = New SqlCommand("select * from LOGIN", con)
        da = New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        TextBox12.Text = "CUS_" & (dt.Rows.Count + 1).ToString()
        con.Close()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        con.Open()
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("Give the valid input")
        Else
            cmd = New SqlCommand("insert into LOGIN values(@CID,@USERNAME,@PWD,@FNAME,@LNAME,@DOB,@GENDER,@CREDITNO,@ADDRESS,@CITY,@STATE,@PIN,@MOBILNO)", con)
            cmd.Parameters.AddWithValue("@CID", TextBox12.Text)
            cmd.Parameters.AddWithValue("@USERNAME", TextBox1.Text)
            cmd.Parameters.AddWithValue("@PWD", TextBox2.Text)
            cmd.Parameters.AddWithValue("@FNAME", TextBox3.Text)
            cmd.Parameters.AddWithValue("@LNAME", TextBox4.Text)
            cmd.Parameters.AddWithValue("@DOB", TextBox5.Text)
            cmd.Parameters.AddWithValue("@GENDER", DropDownList1.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@CREDITNO", TextBox6.Text)
            cmd.Parameters.AddWithValue("@ADDRESS", TextBox7.Text)
            cmd.Parameters.AddWithValue("@CITY", TextBox8.Text)
            cmd.Parameters.AddWithValue("@STATE", TextBox9.Text)
            cmd.Parameters.AddWithValue("@PIN", TextBox10.Text)
            cmd.Parameters.AddWithValue("@MOBILNO", TextBox11.Text)
            cmd.ExecuteNonQuery()
            MsgBox("SUCESSFULLY REGISTER")
        End If
        Response.Redirect("login.aspx")
        con.Close()

    End Sub

    
End Class