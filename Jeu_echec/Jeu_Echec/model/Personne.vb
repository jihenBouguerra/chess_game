Imports System.Data.SqlClient

Public MustInherit Class Personne
    Public Property idPersonne As Integer
    Public Property nom As String
    Public Property prenom As String
    Public Property dateInscri As String
    Public Property pseudo As String

    Sub New(id As Integer)
        idPersonne = id

    End Sub
    Public Overrides Function ToString() As String
        Return "le nom : " + Trim(nom) + " le prenom :  " + Trim(prenom) + "  pseudo : " + Trim(pseudo)
    End Function
    Sub New(pseudo As String)

        Me.pseudo = pseudo

    End Sub

    Sub New(idPersonne As Integer, nom As String, prenom As String, dateInscri As String, pseudo As String)
        Me.idPersonne = idPersonne
        Me.nom = nom
        Me.prenom = prenom
        Me.dateInscri = dateInscri
        Me.pseudo = pseudo

    End Sub
    Public Function getHistorique() As IList(Of Historique)
        Dim listeHistorique As List(Of Historique) = New List(Of Historique)


        Dim cmd = New SqlCommand("select * from Historique 
                                   where idPersonne =@idPersonne ")
        cmd.Parameters.AddWithValue("idPersonne", idPersonne)
        ConnexionBD.openConnection()
        Dim reader As SqlDataReader = ConnexionBD.ExecuteSelect(cmd)
        Do While reader.Read
            'idHistorique As Integer, idPersonne As Integer, typeJeu As String, dateJeu As String, jeuResultat As String
            Dim h = New Historique(reader("idHistorique"),
                                   reader("idPersonne"),
                                   reader("typeJeu"),
                                   reader("dateJeu"),
                                   reader("jeuResultat"))
            listeHistorique.Add(h)
        Loop
        reader.Close()
        ConnexionBD.closeConnection()
        Return listeHistorique
    End Function
    Sub rendreAdministrateur()
        Dim cmd = New SqlCommand("update personne 
                                    set admin = 'true' 
                                    where idPersonne =@idPersonne")
        cmd.Parameters.AddWithValue("@idPersonne", idPersonne)

        ConnexionBD.openConnection()
        ConnexionBD.ExecuteOrUpdateOrDelete(cmd)
        ConnexionBD.closeConnection()

    End Sub
    Sub updateInfo()
        Dim cmd = New SqlCommand("update personne 
                                    set nom= @nom , prenom=@prenom
                                    where idPersonne =@idPersonne")
        cmd.Parameters.AddWithValue("@idPersonne", idPersonne)
        cmd.Parameters.AddWithValue("@prenom", prenom)
        cmd.Parameters.AddWithValue("@nom", nom)


        ConnexionBD.openConnection()
        ConnexionBD.ExecuteOrUpdateOrDelete(cmd)
        ConnexionBD.closeConnection()

    End Sub
    Sub getIdPersonneFromDB()
        Dim cmd = New SqlCommand("select * from Personne where pseudo =@pseudo ")
        cmd.Parameters.AddWithValue("pseudo", pseudo)
        ConnexionBD.openConnection()
        Dim reader As SqlDataReader = ConnexionBD.ExecuteSelect(cmd)
        reader.Read()
        idPersonne = reader("idPersonne")
        ConnexionBD.closeConnection()


    End Sub
    Sub addPersonneDB()
        ConnexionBD.openConnection()
        Dim cmd = New SqlCommand("INSERT INTO Personne(nom,prenom,dateInscrit,pseudo, admin) 
        VALUES (@nom,@prenom,@dateInscrit,@pseudo,@admin)")
        cmd.Parameters.AddWithValue("nom", nom)
        cmd.Parameters.AddWithValue("prenom", prenom)
        cmd.Parameters.AddWithValue("dateInscrit", dateInscri)
        cmd.Parameters.AddWithValue("pseudo", pseudo)
        cmd.Parameters.AddWithValue("admin", False)
        ConnexionBD.ExecuteOrUpdateOrDelete(cmd)

        ConnexionBD.closeConnection()

    End Sub

    Sub New()


    End Sub
    Sub existeCompte(auth As Auth)
        Dim result = False
        Dim cmd = New SqlCommand("select * from Auth,Personne where pseudo =@pseudo and password =@password")
        cmd.Parameters.AddWithValue("pseudo", pseudo)
        cmd.Parameters.AddWithValue("password", auth.password)
        ConnexionBD.openConnection()
        Dim reader As SqlDataReader = ConnexionBD.ExecuteSelect(cmd)
        If (reader.HasRows) Then
            reader.Read()
            result = True
        End If
        ConnexionBD.closeConnection()

    End Sub
    Public Overridable Function isAdmin() As Boolean
        Return True

    End Function
    Public Sub removeAuthDB()
        Dim cmd = New SqlCommand("delete from Auth where idPersonne =@idPersonne")
        cmd.Parameters.AddWithValue("idPersonne", idPersonne)

        ConnexionBD.openConnection()
        ConnexionBD.ExecuteOrUpdateOrDelete(cmd)
        ConnexionBD.closeConnection()
    End Sub
    Public Sub removeHistoriqueDB()
        Dim cmd = New SqlCommand("delete from Historique where idPersonne= @idPersonne")
        cmd.Parameters.AddWithValue("idPersonne", idPersonne)

        ConnexionBD.openConnection()
        ConnexionBD.ExecuteOrUpdateOrDelete(cmd)
        ConnexionBD.closeConnection()
    End Sub

    Public Sub removeBD()
        removeAuthDB()
        removeHistoriqueDB()

        Dim cmd = New SqlCommand("delete from Personne where idPersonne =@idPersonne")
        cmd.Parameters.AddWithValue("idPersonne", idPersonne)
        ConnexionBD.openConnection()
        ConnexionBD.ExecuteOrUpdateOrDelete(cmd)
        ConnexionBD.closeConnection()


    End Sub
    Public Function pseudoExiste() As Boolean
        Dim Result As Boolean = False
        ConnexionBD.openConnection()

        Dim cmd = New SqlCommand("select * from Personne where pseudo =@pseudo")
        cmd.Parameters.AddWithValue("pseudo", pseudo)
        Dim reader As SqlDataReader = ConnexionBD.ExecuteSelect(cmd)

        If (reader.HasRows) Then

            Result = True
        End If
        ConnexionBD.closeConnection()
        Return Result

    End Function
    Public Function getInfoCompteBD() As Auth
        Dim Result As Boolean = False
        ConnexionBD.openConnection()

        Dim cmd = New SqlCommand("select * from Personne 
                                 where idPersonne =@idPersonne")
        cmd.Parameters.AddWithValue("idPersonne", idPersonne)
        Dim reader As SqlDataReader = ConnexionBD.ExecuteSelect(cmd)
        reader.Read()

        nom = reader("nom")
        prenom = reader("prenom")
        dateInscri = reader("dateInscrit")
        reader.Close()
        ConnexionBD.closeConnection()

        Dim auth As New Auth(idPersonne)
        auth.getInfoBD()
        Return auth
    End Function


    Sub New(nom As String, prenom As String, dateInscri As String, pseudo As String)

        Me.nom = nom
        Me.prenom = prenom
        Me.dateInscri = dateInscri
        Me.pseudo = pseudo

    End Sub

End Class
