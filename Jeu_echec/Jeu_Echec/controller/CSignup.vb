Imports System.Data.SqlClient

Public Class CSignup
    Shared personne As Personne
    Shared auth As Auth





    Public Shared Function AjouterPersonne(nom As String, prenom As String, pseudo As String, mdp As String) As Boolean
        Dim result As Boolean = True
        personne = New Joueur(Trim(nom), Trim(prenom), Now.ToString, Trim(pseudo))
        Dim auth As New Auth(Trim(mdp))
        If Personne.pseudoExiste() Then
            MsgBox("Désolé mais ce pseudo est déjà utilisé")
            result = False
        Else
            Personne.addPersonneDB()
            Auth.addAuthDB(Personne.pseudo)
            MsgBox("Votre inscription a bien été enregistrée, bienvenue Mr. " & Trim(nom))


        End If
        Return result
    End Function


End Class
