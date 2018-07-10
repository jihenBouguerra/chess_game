Public Class VotreHistoriques



    Private Sub VotreHistorques_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CMenuJoueur.loadListeHistorique()

        For Each historique As Historique In CMenuJoueur.listeHistorique
            ListBox1.Items.Add(historique.toString)
        Next

    End Sub


End Class