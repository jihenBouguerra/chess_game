Public Class SignUp



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text.Equals("") Or TextBox2.Text.Equals("") Or TextBox3.Text.Equals("") Or TextBox4.Text.Equals("") Or TextBox5.Text.Equals("")) Then
            MsgBox("Veuillez remplir tous les champs")

        ElseIf (Not TextBox5.Text.Equals(TextBox2.Text)) Then
            MsgBox("veuillez vérifier votre mot de passe ")
        ElseIf (Not CheckBox1.Checked) Then
            MsgBox("veuillez cocher la case de confirmation")
        ElseIf (CSignup.AjouterPersonne(TextBox3.Text, TextBox4.Text, TextBox1.Text, TextBox2.Text)) Then
            Me.Hide()

            Dim s As New SignIn()
                s.Show()





        End If

    End Sub

    Private Sub SignUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class