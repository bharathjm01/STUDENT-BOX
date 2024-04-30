Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form8
    Public con As New SqlConnection("Data Source=LAPTOP\SQLEXPRESS;Initial Catalog=studentbox;Integrated Security=True;Encrypt=False")
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("google pay")
        ComboBox1.Items.Add("phone pay")
        ComboBox1.Items.Add("paytm")
        TextBox4.ReadOnly = True

        Try

                ' Open the database connection
                con.Open()

                ' Get the user ID
                Dim userId As Integer = GetuseridByName(login.TextBox1.Text)

                ' Execute SQL command to get the sum of totalprice
                Dim sql As String = "SELECT SUM(totalprice) FROM cart WHERE UserID = @userid"
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@userid", userId)

                    ' Execute the command and get the sum
                    Dim totalAmount As Object = cmd.ExecuteScalar()

                    ' Display the total amount in TextBox4
                    If totalAmount IsNot Nothing AndAlso Not IsDBNull(totalAmount) Then
                        TextBox4.Text = totalAmount.ToString()
                    Else
                        TextBox4.Text = "0"
                    End If
                End Using
            Catch ex As Exception
                ' Handle any exceptions that may occur during database operations
                MessageBox.Show("Error: " & ex.Message)
            Finally
                ' Close the database connection in the finally block to ensure it's always closed
                con.Close()
            End Try



    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            TextBox2.Visible = True
            TextBox4.Visible = True
            DateTimePicker1.Visible = True
            Label3.Visible = True
            Label5.Visible = True
            Label4.Visible = True
            Label6.Visible = True
        Else
            TextBox2.Visible = False
            TextBox4.Visible = False
            DateTimePicker1.Visible = False
            Label3.Visible = False
            Label5.Visible = False
            Label4.Visible = False
            Label6.Visible = False
        End If

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            ComboBox1.Visible = True
            TextBox2.Visible = False
            RadioButton3.Visible = True
            TextBox4.Visible = True
        Else
            ComboBox1.Visible = False
            TextBox2.Visible = False
            TextBox4.Visible = False
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton2.Checked = True Then

            If TextBox2.Text.Count = 16 Then

                If MessageBox.Show("payment successful") Then

                    Me.Hide()
                Else
                    MessageBox.Show("please try again to pay")

                End If
            Else
                MessageBox.Show("Enter Valid Card Number")
            End If
        Else
            If MessageBox.Show("payment successful") Then

                Me.Hide()
            Else
                MessageBox.Show("please try again to pay")

            End If

        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            TextBox2.Visible = False
            TextBox4.Visible = False
            DateTimePicker1.Visible = False
            Label3.Visible = False
            Label5.Visible = False
            ComboBox1.Visible = False
            Label6.Visible = False
            TextBox4.Visible = True


        Else
            TextBox2.Visible = False
            TextBox4.Visible = True
            DateTimePicker1.Visible = True
            Label3.Visible = True
            Label5.Visible = True
            ComboBox1.Visible = True
            Label6.Visible = True
            TextBox4.Visible = False
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub



    Private Sub Back_Click(sender As Object, e As EventArgs) Handles Back.Click
        Me.Hide()
        Mainform.Show()
    End Sub
    Public Function GetuseridByName(username As String) As Integer
        Dim userId As Integer = 0
        Dim conn As String = "Data Source=LAPTOP\SQLEXPRESS;Initial Catalog=studentbox;Integrated Security=True;Encrypt=False"
        Using connection As New SqlConnection(conn)
            Try
                connection.Open()
                Dim query As String = "SELECT UserID FROM users WHERE Username = @Username"
                Using cmd As New SqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Username", username)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        userId = Convert.ToInt32(result)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error retrieving user ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return userId
    End Function

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class

