Imports System.Data.SqlClient


Public Class Historique


    Public Property idHistorique As Integer
    Public Property idPersonne As Integer
    Public Property typeJeu As String
    Public Property dateJeu As String
    Public Property jeuResultat As String


    Public Overrides Function toString() As String

        ' Return "id hist" + idHistorique.ToString + "idPERsonne" + idPersonne.ToString + "date :  " + Trim(dateJeu) + "  type du jeu : " + Trim(typeJeu) + "   resultat :  " + Trim(jeuResultat)
        Return "date :  " + Trim(dateJeu) + "  type du jeu : " + Trim(typeJeu) + "   resultat :  " + Trim(jeuResultat)
    End Function

    Public Sub addHistorique()
        Dim cmd = New SqlCommand("INSERT INTO Historique(idPersonne,typeJeu,dateJeu,jeuResultat) VALUES (@idPersonne,@typeJeu,@dateJeu,@jeuResultat)")
        cmd.Parameters.AddWithValue("idPersonne", idPersonne)
        cmd.Parameters.AddWithValue("typeJeu", typeJeu)
        cmd.Parameters.AddWithValue("dateJeu", dateJeu)
        cmd.Parameters.AddWithValue("jeuResultat", jeuResultat)
        ConnexionBD.openConnection()
        ConnexionBD.ExecuteOrUpdateOrDelete(cmd)
        ConnexionBD.closeConnection()
    End Sub

    Public Sub removeHistorique()
        Dim cmd = New SqlCommand("delete from Historique where idHistorique= @idHistorique")
        cmd.Parameters.AddWithValue("idHistorique", idHistorique)

        ConnexionBD.openConnection()
        ConnexionBD.ExecuteOrUpdateOrDelete(cmd)
        ConnexionBD.closeConnection()
    End Sub





    Sub New(idHistorique As Integer, idPersonne As Integer, typeJeu As String, dateJeu As String, jeuResultat As String)
        Me.idHistorique = idHistorique
        Me.idPersonne = idPersonne
        Me.typeJeu = typeJeu
        Me.dateJeu = Now.ToString
        Me.jeuResultat = jeuResultat
    End Sub
    Sub New(idPersonne As Integer, typeJeu As String, dateJeu As String, jeuResultat As String)

        Me.idPersonne = idPersonne
        Me.typeJeu = typeJeu
        Me.dateJeu = Now.ToString
        Me.jeuResultat = jeuResultat
    End Sub



End Class
