Public Class MenuAdmin

    Public Property opned As Form

    Private Sub GestionComteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestionComteToolStripMenuItem.Click

        If Not opned Is Nothing Then
            opned.Close()
        End If
        opned = New GestionCompte()
        opned.MdiParent = Me
        opned.Show()
    End Sub


    Private Sub GestionHistoriqueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestionHistoriqueToolStripMenuItem.Click
        If Not opned Is Nothing Then
            opned.Close()
        End If
        opned = New GestionHistorique()
        opned.MdiParent = Me
        opned.Show()
        CMenuAdmin.loadListeCompte()
        CMenuAdmin.compteSelectionne = 0
        CMenuAdmin.loadListeHistorique(0)

    End Sub

    Private Sub ParametresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParametresToolStripMenuItem.Click
        If Not opned Is Nothing Then
            opned.Close()
        End If

        opned = New ParametresCompte()
        opned.MdiParent = Me
        opned.Show()
    End Sub

    Private Sub DeconnexionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeconnexionToolStripMenuItem.Click
        Me.Close()
        Dim connect As New SignIn
        connect.Show()

    End Sub

    Private Sub MenuAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class