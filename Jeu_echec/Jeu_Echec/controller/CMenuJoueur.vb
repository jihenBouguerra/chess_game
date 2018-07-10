Public Class CMenuJoueur
    Public Shared Property listeHistorique As List(Of Historique)


    Public Shared Sub loadListeHistorique()
        listeHistorique = CSignIn.infoCompte.getHistorique()

    End Sub

End Class
