Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.VisualBasic.ApplicationServices
Imports STUDENT_BOX.Quantity
Public Class Mainform
    Private connectionString As String = "Data Source=LAPTOP\SQLEXPRESS;Initial Catalog=studentbox;Integrated Security=True;Encrypt=False"
    Public Property SelectedProductId As Integer

    Private Sub Button_1(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Hide()
        Cart.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim productId As Integer = 9
        Dim userId As Integer = GetuseridByName(login.TextBox1.Text)
        If userId <> 0 Then
            PictureBox_Click(productId, userId)
        Else
            MessageBox.Show("User not found.")
        End If
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim productId As Integer = 10
        Dim userId As Integer = GetuseridByName(login.TextBox1.Text)
        If userId <> 0 Then
            PictureBox_Click(productId, userId)
        Else
            MessageBox.Show("User not found.")
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim productId As Integer = 11
        Dim userId As Integer = GetuseridByName(login.TextBox1.Text)
        If userId <> 0 Then
            PictureBox_Click(productId, userId)
        Else
            MessageBox.Show("User not found.")
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim productId As Integer = 12
        Dim userId As Integer = GetuseridByName(login.TextBox1.Text)
        If userId <> 0 Then
            PictureBox_Click(productId, userId)
        Else
            MessageBox.Show("User not found.")
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim productId As Integer = 13
        Dim userId As Integer = GetuseridByName(login.TextBox1.Text)
        If userId <> 0 Then
            PictureBox_Click(productId, userId)
        Else
            MessageBox.Show("User not found.")
        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim productId As Integer = 14
        Dim userId As Integer = GetuseridByName(login.TextBox1.Text)
        If userId <> 0 Then
            PictureBox_Click(productId, userId)
        Else
            MessageBox.Show("User not found.")
        End If
    End Sub
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Dim productId As Integer = 15
        Dim userId As Integer = GetuseridByName(login.TextBox1.Text)
        If userId <> 0 Then
            PictureBox_Click(productId, userId)
        Else
            MessageBox.Show("User not found.")
        End If
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Dim productId As Integer = 16
        Dim userId As Integer = GetuseridByName(login.TextBox1.Text)
        If userId <> 0 Then
            PictureBox_Click(productId, userId)
        Else
            MessageBox.Show("User not found.")
        End If
    End Sub
    Private Sub PictureBox_Click(productId As Integer, userId As Integer)
        ' Prompt the user to enter the quantity
        Dim quantityInput As String = InputBox("Enter the quantity:", "Quantity", "1")

        ' Validate if the quantity entered is a valid integer
        Dim quantity As Integer
        If Integer.TryParse(quantityInput, quantity) Then
            ' Fetch the product details
            Dim product As Product = GetProductById(productId)

            If product IsNot Nothing Then
                ' Calculate the total price
                Dim totalPrice As Decimal = product.Price * quantity

                ' Show the total price
                MessageBox.Show("Total price is " & totalPrice.ToString("C"))

                ' Add the product to the cart
                AddToCart(productId, totalPrice, quantity, userId)
                Me.Hide()
                Cart.Show()
            Else
                MessageBox.Show("Product not found.")
            End If
        Else
            MessageBox.Show("Please enter a valid quantity.")
        End If
    End Sub
    Private Function GetProductById(productId As Integer) As Product
        Dim product As Product = Nothing
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT PRODUCT_ID, PRODUCT_NAME, PRODUCT_PRICE FROM Product WHERE PRODUCT_ID = @productId"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@productId", productId)
                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        product = New Product() With {
                            .Id = reader.GetInt32(0),
                            .Name = reader.GetString(1),
                            .Price = reader.GetDecimal(2)
                        }
                    End If
                End Using
            End Using
        End Using
        Return product
    End Function
    Public Function GetuseridByName(username As String) As Integer
        Dim userId As Integer = 0
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT UserID FROM users WHERE Username = @Username"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Username", username)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        userId = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving user ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return userId
    End Function

    Public Sub AddToCart(productId As Integer, totalPrice As Decimal, quantity As Integer, userId As Integer)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "INSERT INTO cart (PRODUCT_ID, totalprice, quantity, UserID) VALUES (@productId, @totalPrice, @quantity, @UserID)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@productId", productId)
                command.Parameters.AddWithValue("@totalPrice", totalPrice)
                command.Parameters.AddWithValue("@quantity", quantity)
                command.Parameters.AddWithValue("@UserID", userId)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Me.Hide()
        settings.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class






