Imports System.Data.SqlClient

Public Class Auth
    Public Property idAuth As Integer
    Public Property idPersonne As Integer
    Public Property password As String

    Sub New(idPersonne As Integer)

        Me.idPersonne = idPersonne

    End Sub
    Sub New(idAuth As Integer, idPersonne As Integer, password As String)
        Me.idAuth = idAuth
        Me.idPersonne = idPersonne
        Me.password = password
    End Sub
    Public Sub updateInfo()
        Dim cmd = New SqlCommand("update Auth 
                                    set password= @password 
                                    where idPersonne =@idPersonne")
        cmd.Parameters.AddWithValue("@idPersonne", idPersonne)
        cmd.Parameters.AddWithValue("@password", password)

        ConnexionBD.openConnection()
        ConnexionBD.ExecuteOrUpdateOrDelete(cmd)
        ConnexionBD.closeConnection()

    End Sub
    Sub New(mdp As String)
        password = mdp

    End Sub

    Public Sub removeBD()
        Dim cmd = New SqlCommand("delete from Auth where idPersonne =@idPersonne")
        cmd.Parameters.AddWithValue("idPersonne", idPersonne)

        ConnexionBD.openConnection()
        ConnexionBD.ExecuteOrUpdateOrDelete(cmd)
        ConnexionBD.closeConnection()

    End Sub
    Public Sub getInfoBD()
        ConnexionBD.openConnection()

        Dim cmd = New SqlCommand("select * from  Auth where idPersonne =@idPersonne")
        cmd.Parameters.AddWithValue("idPersonne", idPersonne)
        Dim reader As SqlDataReader = ConnexionBD.ExecuteSelect(cmd)
        reader.Read()
        idAuth = reader("idAuth")
        password = reader("password")
        reader.Close()
        ConnexionBD.closeConnection()

    End Sub

    Sub addAuthDB(pseudo As String)
        ConnexionBD.openConnection()

        Dim cmd = New SqlCommand("select * from Personne where pseudo =@pseudo")
        cmd.Parameters.AddWithValue("pseudo", pseudo)

        Dim reader As SqlDataReader = ConnexionBD.ExecuteSelect(cmd)
        reader.Read()
        Dim id As Integer = reader("idPersonne")

        reader.Close()
        Dim cmd3 = New SqlCommand("INSERT INTO Auth(idPersonne,password) 
        VALUES (@idPeronne,@password)")
        cmd3.Parameters.AddWithValue("idPeronne", id)
        cmd3.Parameters.AddWithValue("password", password)

        ConnexionBD.ExecuteOrUpdateOrDelete(cmd3)

        ConnexionBD.closeConnection()
    End Sub
End Class
