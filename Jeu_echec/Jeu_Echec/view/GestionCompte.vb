Public Class GestionCompte

    Private Sub GestionCompte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMenuAdmin.loadListeCompte()
        'ListeCompte.DataSource = CMenuAdmin.listeCompte
        For Each personne As Personne In CMenuAdmin.listeCompte
            ListeCompte.Items.Add(personne.ToString)
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        If (Not ListeCompte.SelectedIndex = -1 And Not ListeCompte.SelectedIndex > CMenuAdmin.listeCompte.Capacity) Then
            CMenuAdmin.remove(ListeCompte.SelectedIndex())
            ListeCompte.Items.Clear()

            For Each personne As Personne In CMenuAdmin.listeCompte
                ListeCompte.Items.Add(personne.ToString)
            Next

        End If

    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ListeCompte.SelectedIndex = -1 Then
            MsgBox("Veuillez selectionner un compte")
        Else
            CMenuAdmin.compteSelectionne = ListeCompte.SelectedIndex
            Dim gH As New GestionHistorique()
            gH.Show()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListeCompte.SelectedIndex = -1 Then
            MsgBox("Veuillez selectionner un compte")
        Else
            CMenuAdmin.rendreAdmin(ListeCompte.SelectedIndex)
            ListeCompte.Items.Clear()

            For Each personne As Personne In CMenuAdmin.listeCompte
                ListeCompte.Items.Add(personne.ToString)
            Next
        End If
    End Sub

    Private Sub ListeCompte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListeCompte.SelectedIndexChanged

    End Sub
End Class