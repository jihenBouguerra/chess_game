Imports System.Data.SqlClient

Public Class Joueur
    Inherits Personne
    Public Overrides Function ToString() As String
        Return MyBase.ToString() + " joueur"
    End Function

    Sub New(idPersonne As Integer, nom As String, prenom As String, dateInscri As String, pseudo As String)
        MyBase.New(idPersonne, nom, prenom, dateInscri, pseudo)

    End Sub
    Sub New(nom As String, prenom As String, dateInscri As String, pseudo As String)
        MyBase.New(nom, prenom, dateInscri, pseudo)

    End Sub
    Sub New(id As Integer)
        MyBase.New(id)

    End Sub
    Sub New(pseudo As String)

        MyBase.pseudo = pseudo

    End Sub
    Public Overrides Function isAdmin() As Boolean
        Return False
    End Function



End Class
