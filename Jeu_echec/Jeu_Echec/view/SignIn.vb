Imports System.IO
Imports System.Text

Public Class SignIn




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text.Equals("") Or TextBox2.Text.Equals("")) Then
            MsgBox("Veuillez remplir tous les champs")
        Else
            CSignIn.connecter(Me, Trim(TextBox1.Text), Trim(TextBox2.Text))


        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim signup As New SignUp()
        signup.Show()
        Me.Hide()
    End Sub

    Private Sub SignIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim path As String = "MyTest.txt"

        ' Create or overwrite the file.
        'Dim fs As FileStream = File.Create(path)

        ' Add text to the file.
        'Dim info As Byte() = New UTF8Encoding(True).GetBytes("This is some text in the file.")
        'fs.Write(info, 0, info.Length)
        'fs.Close()
    End Sub
End Class