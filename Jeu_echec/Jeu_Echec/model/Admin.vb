Public Class Admin
    Inherits Personne
    Public Overrides Function ToString() As String
        Return MyBase.ToString() + " administrateur"
    End Function

    Sub New(idPersonne As Integer, nom As String, prenom As String, dateInscri As String, pseudo As String)
        MyBase.New(idPersonne, nom, prenom, dateInscri, pseudo)

    End Sub

    Sub New(nom As String, prenom As String, dateInscri As Date, pseudo As String)
        MyBase.New(nom, prenom, dateInscri, pseudo)

    End Sub
    Sub New(pseudo As String)

        MyBase.pseudo = pseudo

    End Sub

    Sub New(id As Integer)
        MyBase.New(id)

    End Sub
    Public Overrides Function isAdmin() As Boolean
        Return True
    End Function
End Class
