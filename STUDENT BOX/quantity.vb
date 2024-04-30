Imports System.Data.SqlClient

Public Class Quantity
    Private connectionString As String = "Data Source=LAPTOP\SQLEXPRESS;Initial Catalog=studentbox;Integrated Security=True;Encrypt=False"

    Public Class Product
        Public Property Id As Integer
        Public Property Name As String
        Public Property Price As Decimal
    End Class

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim productId As Integer = mainform.SelectedProductId ' Get the selected product ID
        Dim quantity As Integer

        ' Validate if the quantity entered is a valid integer
        If Integer.TryParse(TextBox1.Text, quantity) Then
            ' If the quantity is valid, fetch the product from the database
            Dim product As Product = GetProductById(productId)

            If product IsNot Nothing Then
                ' Calculate the total price
                Dim totalPrice As Decimal = product.Price * quantity
                MessageBox.Show("total price is " & totalPrice)

                ' Add the product to the cart with the calculated total price
                AddToCart(productId, totalPrice, quantity)

                ' Hide the current form and show the cart form
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

    Public Sub AddToCart(productId As Integer, totalPrice As Decimal, quantity As Integer)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "INSERT INTO cart (PRODUCT_ID, totalprice, quantity) VALUES (@productId, @totalPrice, @quantity)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@productId", productId)
                command.Parameters.AddWithValue("@totalPrice", totalPrice)
                command.Parameters.AddWithValue("@quantity", quantity)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' You can add validation or other actions here if needed.
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        mainform.Show()
    End Sub

    Private Sub Quantity_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
