Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization




Public Class settings
    Public con As New SqlConnection("Data Source=LAPTOP\SQLEXPRESS;Initial Catalog=studentbox;Integrated Security=True;Encrypt=False")
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Remove_user_btn_Click(sender As Object, e As EventArgs) Handles Remove_user_btn.Click
        Dim usernameToRemove As String = InputBox("Enter the username to remove:", "Remove User")


        RemoveUser(usernameToRemove)
    End Sub

    Private Sub RemoveUser(username As String)
        Try

            Dim password As String = InputBox("Enter your password to confirm deletion of the user.", "Confirm Deletion")


            If AuthenticateUser(username, password) Then

                con.Open()
                Dim sql As String = "DELETE FROM [users] WHERE Username = @Username"
                Using cmd As New SqlCommand(sql, con)

                    cmd.Parameters.AddWithValue("@Username", username)


                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()


                    If rowsAffected > 0 Then
                        MessageBox.Show("User removed successfully")
                        Me.Close()
                        login.Show()
                    Else
                        MessageBox.Show("User not found or could not be removed")
                    End If
                End Using
            Else
                MessageBox.Show("Incorrect password. User deletion cancelled.")
            End If
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)
        Finally

            con.Close()
        End Try

    End Sub

    Private Function AuthenticateUser(username As String, password As String) As Boolean
        Dim authenticated As Boolean = False
        Try

            con.Open()


            Dim sql As String = "SELECT * FROM users WHERE Username = @Username AND Password = @Password"
            Using cmd As New SqlCommand(sql, con)
                ' Replace the parameters with the actual values
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Password", password)


                Dim reader As SqlDataReader = cmd.ExecuteReader()


                authenticated = reader.HasRows
            End Using
        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)
        Finally

            con.Close()
        End Try

        Return authenticated
    End Function


    Private Sub Logout_btn_Click(sender As Object, e As EventArgs) Handles Logout_btn.Click
        Me.Hide()
        login.Show()

    End Sub

    Private Sub Back1_btn_Click(sender As Object, e As EventArgs) Handles Back1_btn.Click
        Me.Hide()
        Mainform.Show()

    End Sub
End Class