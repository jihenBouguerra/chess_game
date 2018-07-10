Imports System.Data.SqlClient

Public Class CSignIn
    Public Shared Property infoCompte As Personne
    Public Shared Property auth


    Public Shared Function connecter(f As Form, pseudo As String, mdp As String) As Boolean
        Dim result As Boolean = False
        ConnexionBD.openConnection()
        Dim cmd = New SqlCommand("select * from Personne
                                    where idPersonne = (select idPersonne 
                                     from Auth where 
                                     password =@password) ")
        cmd.Parameters.AddWithValue("pseudo", pseudo)
        cmd.Parameters.AddWithValue("password", mdp)

        Dim reader As SqlDataReader = ConnexionBD.ExecuteSelect(cmd)
        If (reader.HasRows) Then
            result = True
            reader.Read()
            If (reader("admin")) Then
                infoCompte = New Admin(CInt(reader("idPersonne")))
            Else
                infoCompte = New Joueur(CInt(reader("idPersonne")))
            End If
            reader.Close()
            ConnexionBD.closeConnection()
            auth = infoCompte.getInfoCompteBD()
            f.Hide()

            If infoCompte.isAdmin Then
                Dim gc As New MenuAdmin
                gc.Show()
            Else
                Dim jouer As New MenuJoueur
                jouer.Show()

            End If
        Else
            ConnexionBD.closeConnection()
            MsgBox("La Combinaison Pseudo/Mot de passe est incorrect")
        End If
        reader.Close()

        Return result

    End Function



End Class
