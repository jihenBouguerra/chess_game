Public Class ParametresCompte
    Private Sub ParametresCompte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = CSignIn.infoCompte.nom
        TextBox2.Text = CSignIn.infoCompte.prenom



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        CSignIn.infoCompte.nom = TextBox1.Text
        CSignIn.infoCompte.prenom = TextBox2.Text
        CSignIn.infoCompte.updateInfo()
        MsgBox("Les informations ont été changé")
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim mmdp As New modifierMdp
        mmdp.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class