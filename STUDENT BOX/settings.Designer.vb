<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Remove_user_btn = New System.Windows.Forms.Button()
        Me.Logout_btn = New System.Windows.Forms.Button()
        Me.Back1_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Remove_user_btn
        '
        Me.Remove_user_btn.Location = New System.Drawing.Point(45, 101)
        Me.Remove_user_btn.Name = "Remove_user_btn"
        Me.Remove_user_btn.Size = New System.Drawing.Size(114, 87)
        Me.Remove_user_btn.TabIndex = 0
        Me.Remove_user_btn.Text = "Remove User"
        Me.Remove_user_btn.UseVisualStyleBackColor = True
        '
        'Logout_btn
        '
        Me.Logout_btn.Location = New System.Drawing.Point(226, 101)
        Me.Logout_btn.Name = "Logout_btn"
        Me.Logout_btn.Size = New System.Drawing.Size(114, 87)
        Me.Logout_btn.TabIndex = 1
        Me.Logout_btn.Text = "Logout"
        Me.Logout_btn.UseVisualStyleBackColor = True
        '
        'Back1_btn
        '
        Me.Back1_btn.Location = New System.Drawing.Point(135, 218)
        Me.Back1_btn.Name = "Back1_btn"
        Me.Back1_btn.Size = New System.Drawing.Size(101, 65)
        Me.Back1_btn.TabIndex = 2
        Me.Back1_btn.Text = "Back"
        Me.Back1_btn.UseVisualStyleBackColor = True
        '
        'settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 346)
        Me.Controls.Add(Me.Back1_btn)
        Me.Controls.Add(Me.Logout_btn)
        Me.Controls.Add(Me.Remove_user_btn)
        Me.Name = "settings"
        Me.Text = "settings"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Remove_user_btn As Button
    Friend WithEvents Logout_btn As Button
    Friend WithEvents Back1_btn As Button
End Class
