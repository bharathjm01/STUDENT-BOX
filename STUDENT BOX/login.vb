Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class login

    Public con As New SqlConnection("Data Source=LAPTOP\SQLEXPRESS;Initial Catalog=studentbox;Integrated Security=True;Encrypt=False")


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.UseSystemPasswordChar = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PerformLogin()

    End Sub
    Private Sub PerformLogin()
        Try
            ' Open the database connection
            con.Open()

            ' Execute SQL command
            Dim sql As String = "SELECT * FROM users WHERE Username = @Username AND Password = @Password"
            Using cmd As New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@Username", TextBox1.Text)
                cmd.Parameters.AddWithValue("@Password", TextBox2.Text)

                ' Execute the command
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                ' Check if there is a row with matching username and password
                If reader.HasRows Then
                    ' User is authenticated
                    MessageBox.Show("Login successful")
                    Me.Hide()
                    mainform.Show()
                Else
                    ' User authentication failed
                    MessageBox.Show("Invalid username or password")
                End If

                ' Close the SqlDataReader
                reader.Close()
            End Using
        Catch ex As Exception
            ' Handle any exceptions that may occur during database operations
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Close the database connection in the finally block to ensure it's always closed
            con.Close()
        End Try
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        register.Show()
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
