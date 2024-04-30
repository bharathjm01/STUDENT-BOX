
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Public Class Register
    Public con As New SqlConnection("Data Source=LAPTOP\SQLEXPRESS;Initial Catalog=studentbox;Integrated Security=True;Encrypt=False")

    Private Sub PerformRegistration()
        Try
            ' Validate input: Check if both username and password are provided
            If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) Then
                MessageBox.Show("Please enter username and password.")
                Return ' Exit the method without proceeding to database operations
            End If
            ' Open the database connection
            con.Open()

            ' Execute SQL command to insert new user registration
            Dim sql As String = "INSERT INTO users (Username, Password) VALUES (@Username, @Password)"
            Using cmd As New SqlCommand(sql, con)
                ' Replace these parameters with actual values or retrieve them from controls
                cmd.Parameters.AddWithValue("@Username", TextBox1.Text)
                cmd.Parameters.AddWithValue("@Password", TextBox2.Text)

                ' Execute the command
                cmd.ExecuteNonQuery()

                ' Display registration success message
                MessageBox.Show("Registration successful")
                Me.Hide()
                login.Show()
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
        Me.Hide()
        login.Show()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PerformRegistration()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class