Public Class modifierMdp
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If (TextBox1.Text.Equals("") Or TextBox2.Text.Equals("")) Then
            MsgBox("Veuillez saisir votre ancien et nouveau mot de passe")
        ElseIf (TextBox1.Text.Equals(trim(CSignIn.auth.password))) Then
            CSignIn.auth.password = TextBox2.Text
            CSignIn.auth.updateInfo()
            MsgBox("Le mot de passe a été changé")
            Me.Close()
        Else
            MsgBox("L'ancien mot de passe invalide")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub modifierMdp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class