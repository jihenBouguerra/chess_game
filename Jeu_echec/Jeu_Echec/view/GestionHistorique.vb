Public Class GestionHistorique


    Private Sub GestionHistorique_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMenuAdmin.loadListeCompte()
        For Each personne As Personne In CMenuAdmin.listeCompte
            ComboBox1.Items.Add(personne.ToString)

        Next
        ComboBox1.SelectedIndex = CMenuAdmin.compteSelectionne

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListBox1.Items.Clear()

        If Not CMenuAdmin.listeCompte.ElementAt(ComboBox1.SelectedIndex).isAdmin Then
            CMenuAdmin.loadListeHistorique(ComboBox1.SelectedIndex)
            For Each historique As Historique In CMenuAdmin.listeHistorique
                ListBox1.Items.Add(historique.toString)
            Next

        Else
            ListBox1.Items.Add("Il s'agit d'un compte administrateur")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (Not ListBox1.SelectedIndex = -1 And Not ListBox1.SelectedIndex > CMenuAdmin.listeCompte.Capacity) Then
            If (Not CMenuAdmin.listeCompte.ElementAt(ComboBox1.SelectedIndex).isAdmin) Then

                CMenuAdmin.removeHist(ListBox1.SelectedIndex)
                ListBox1.Items.Clear()

                For Each histo As Historique In CMenuAdmin.listeHistorique
                    ListBox1.Items.Add(histo.toString)
                Next

            End If
        End If
    End Sub


End Class