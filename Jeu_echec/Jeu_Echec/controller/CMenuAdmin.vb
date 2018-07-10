Imports System.Data.SqlClient

Public Class CMenuAdmin
    Public Shared Property listeCompte As List(Of Personne)
    Public Shared Property listeHistorique As List(Of Historique)
    Public Shared Property compteSelectionne As Integer

    Public Shared Sub loadListeHistorique(index As Integer)
        If Not listeCompte.ElementAt(index).isAdmin Then
            listeHistorique = listeCompte.ElementAt(index).getHistorique()
        End If

    End Sub

    Public Shared Sub loadListeCompte()
        Dim personne As Personne
        Dim query As String = "Select * from Personne "
        listeCompte = New List(Of Personne)
        ConnexionBD.openConnection()
        Dim reader As SqlDataReader = ConnexionBD.ExecuteSelect(query)
        While (reader.Read)

            If (reader("admin")) Then
                personne = New Admin(reader("idPersonne"), reader("nom"), reader("prenom"), reader("dateInscrit"), reader("pseudo"))
            Else
                personne = New Joueur(reader("idPersonne"), reader("nom"), reader("prenom"), reader("dateInscrit"), reader("pseudo"))
            End If
            listeCompte.Add(personne)

        End While

        ConnexionBD.closeConnection()
    End Sub
    Public Shared Sub remove(index As Integer)

        listeCompte.ElementAt(index).removeBD()
        listeCompte.RemoveAt(index)

    End Sub
    Public Shared Sub removeHist(index As Integer)
        listeHistorique.ElementAt(index).removeHistorique()
        listeHistorique.RemoveAt(index)


    End Sub
    Public Shared Sub rendreAdmin(index As Integer)
        listeCompte.ElementAt(index).rendreAdministrateur()
    End Sub

End Class
