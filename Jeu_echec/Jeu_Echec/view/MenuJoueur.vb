Public Class MenuJoueur
    Public Property opned As Form

    Private Sub AfficheHistoriqueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfficheHistoriqueToolStripMenuItem.Click
        If Not opned Is Nothing Then
            opned.Close()
        End If
        opned = New VotreHistoriques
        opned.MdiParent = Me
        opned.Show()

    End Sub

    Private Sub ParametresDuCompteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParametresDuCompteToolStripMenuItem.Click
        If Not opned Is Nothing Then
            opned.Close()
        End If

        opned = New ParametresCompte()
        opned.MdiParent = Me
        opned.Show()
    End Sub

    Private Sub MenuJoueur_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CMenuJoueur.loadListeHistorique()
    End Sub

    Private Sub JouerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JouerToolStripMenuItem.Click
        If Not opned Is Nothing Then
            opned.Close()
        End If

        opned = New Jouer()
        opned.MdiParent = Me
        opned.Show()
    End Sub

    Private Sub DeconnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeconnectionToolStripMenuItem.Click
        Close()
        Dim connect As New SignIn
        connect.Show()
    End Sub
End Class