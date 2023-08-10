Imports System
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Page
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Public Class WebForm8
    Inherits System.Web.UI.Page
    Dim con As SqlConnection
    Dim cmd, cmd1 As SqlCommand
    Dim reader As SqlDataReader
    Dim da As SqlDataAdapter
    Dim dt As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        con = New SqlConnection("Data Source=COMPUTER-40;Initial Catalog=RENTALSYS;Integrated Security=True;Pooling=False")
        con.Open()

        cmd = New SqlCommand("select * from UPLOADPRODUCT", con)
        Dim myd As SqlDataReader = cmd.ExecuteReader
        While myd.Read = True
            DropDownList1.Items.Add(myd.GetValue(0))
        End While
        con.Close()

        con.Open()
        cmd = New SqlCommand("select * from BOOKING", con)
        da = New SqlDataAdapter(cmd)
        dt = New DataTable
        da.Fill(dt)
        TextBox1.Text = "BID_" & (dt.Rows.Count + 1).ToString()
        con.Close()
        TextBox2.Text = DateTime.Now.ToString()

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        con.Open()
        Dim ds As New Data.DataTable
        Dim sda As New SqlDataAdapter
        cmd1 = New SqlCommand("select * from booking where  pid='" + DropDownList1.SelectedItem.Text + "' and deliverydate='" + TextBox8.Text + "'", con)
        sda.SelectCommand = cmd1
        sda.Fill(ds)
        If ds.Rows.Count > 0 Then
            MsgBox("Already booked")
        Else
            cmd = New SqlCommand("insert into BOOKING values(@BID,@BDATE,@PID,@RENT,@NOOFDAYS,@AMOUNT,@GST,@TOTALAMOUNT,@DELIVERYDATE,@DESTINATION)", con)
            cmd.Parameters.AddWithValue("@BID", TextBox1.Text)
            cmd.Parameters.AddWithValue("@BDATE", TextBox2.Text)
            cmd.Parameters.AddWithValue("@PID", DropDownList1.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@RENT", TextBox4.Text)
            cmd.Parameters.AddWithValue("@NOOFDAYS", TextBox3.Text)
            cmd.Parameters.AddWithValue("@AMOUNT", TextBox5.Text)
            cmd.Parameters.AddWithValue("@GST", TextBox6.Text)
            cmd.Parameters.AddWithValue("@TOTALAMOUNT", TextBox7.Text)
            cmd.Parameters.AddWithValue("DELIVERYDATE", TextBox8.Text)
            cmd.Parameters.AddWithValue("@DESTINATION", DropDownList2.SelectedItem.Text)
            cmd.ExecuteNonQuery()
            MsgBox("sucessfully Booking")
            con.Close()
        End If
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Calendar1.SelectionChanged
        TextBox8.Text = Calendar1.SelectedDate
    End Sub

   

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        TextBox5.Text = Val(TextBox4.Text) * Val(TextBox3.Text)
        TextBox9.Text = Val(TextBox6.Text) / 100 * Val(TextBox5.Text)
        TextBox7.Text = Val(TextBox5.Text) + Val(TextBox9.Text)
    End Sub

  
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        con.Open()
        cmd = New SqlCommand("select * from UPLOADPRODUCT where pid='" + DropDownList1.SelectedItem.Text + "'", con)
        Dim myd1 As SqlDataReader = cmd.ExecuteReader
        While myd1.Read = True
            TextBox4.Text = myd1.GetValue(3)
            TextBox6.Text = myd1.GetValue(6)
        End While
        con.Close()
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click
        Response.Redirect("payment.aspx")
    End Sub

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click
        Response.Redirect("bookingpro.aspx")
    End Sub
End Class