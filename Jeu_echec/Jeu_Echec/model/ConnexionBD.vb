Imports System.Data.SqlClient
Public Class ConnexionBD
    'ta9rib chaine houni besh tetbadel andek just netfaker nbadalha get mylocation  haja haka =P 
    'fil dossier ta3 jeu_Echec fama 2 fichies myGame.mdf w myGame_log.ldf hekom lbase 
    'Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MohamedAli\Dropbox\Jeu_echec\Jeu_Echec\myGame.mdf;Integrated Security=True;Connect Timeout=30
    'Jihen DATASOURCE:
    'Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bouguerra\Dropbox\Jeu_echec\myGame.mdf;Integrated Security=True;Connect Timeout=30
    Private Shared path_db As String = My.Application.Info.DirectoryPath.Remove(My.Application.Info.DirectoryPath.IndexOf("Jeu_Echec\bin\Debug"), "Jeu_Echec\bin\Debug".Length) & "myGame.mdf"
    Private Shared chaineConection As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" & path_db & ";Integrated Security=True;Connect Timeout=30"

    Private Shared connexion As New SqlConnection(chaineConection)
    Private cmd As SqlCommand
    Public Shared Sub openConnection()

        connexion.Open()
    End Sub
    Public Shared Sub closeConnection()
        connexion.Close()
    End Sub


    Public Overloads Shared Function ExecuteSelect(req As String) As SqlDataReader
        Dim dataReader As SqlDataReader = Nothing
        Try

            Dim cmd = New SqlCommand(req)
            cmd.Connection = connexion
            dataReader = cmd.ExecuteReader()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If connexion.State = ConnectionState.Open Then

            End If

        End Try
        Return dataReader
    End Function
    Public Overloads Shared Function ExecuteSelect(cmd As SqlCommand) As SqlDataReader
        Dim dataReader As SqlDataReader = Nothing
        Try
            ' connexion.Open()
            cmd.Connection = connexion
            dataReader = cmd.ExecuteReader()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If connexion.State = ConnectionState.Open Then

            End If

        End Try
        Return dataReader
    End Function

    Public Overloads Shared Sub ExecuteOrUpdateOrDelete(cmd As SqlCommand)

        Try
            'connexion.Open()
            cmd.Connection = connexion
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If connexion.State = ConnectionState.Open Then
                'connexion.Close()
            End If

        End Try

    End Sub
    Public Overloads Shared Sub ExecuteOrUpdateOrDelete(req As String)

        Try
            Dim cmd = New SqlCommand()
            'connexion.Open()
            cmd.Connection = connexion
            cmd.CommandText = req
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If connexion.State = ConnectionState.Open Then

            End If

        End Try
    End Sub



End Class
