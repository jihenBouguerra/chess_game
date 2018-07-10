Public Class Jouer

    Public Property firstclick = False
    Public Property finJeu = False
    Public Property isGreen = False
    Public Property posClick As New KeyValuePair(Of Integer, Integer)
    'Public Property secondclick = False
    Public Property jeu1 As Jeu

    Private Function typeFromName(r As String) As Piece.TypesPiece
        If (r.ToUpper.Trim = "DAME") Then
            Return Piece.TypesPiece.Dame
        ElseIf (r.ToUpper.Trim = "CHEVALIER") Then
            Return Piece.TypesPiece.Chevalier
        ElseIf (r.ToUpper.Trim = "FOU") Then
            Return Piece.TypesPiece.Fou
        ElseIf (r.ToUpper.Trim = "TOUR") Then
            Return Piece.TypesPiece.Tour
        End If
    End Function

    Private Function reponseVoulu(r As String) As Boolean
        If (r.ToUpper.Trim = "DAME") Then
            Return True
        ElseIf (r.ToUpper.Trim = "CHEVALIER") Then
            Return True
        ElseIf (r.ToUpper.Trim = "FOU") Then
            Return True
        ElseIf (r.ToUpper.Trim = "TOUR") Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Jouer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim cube_blanc As String = "..\..\\Img\\Piece\\Vide_Blanc.png"
        'Dim cube_noir As String = "..\..\\Img\\Piece\\Vide_Noir.png"





        For i = 1 To 8
            'For ind = 65 To 72
            For j = 1 To 8
                getPictureBox(i, j).Image = New Piece(Piece.TypesPiece.Vide, Piece.Couleurs.Blanc, New KeyValuePair(Of Integer, Integer)(i, j)).imagePiece
            Next
        Next
    End Sub

    Public Function getPictureBox(i As Integer, j As Integer) As PictureBox
        Select Case "" & j & i
            Case "11"
                Return PB_A1
            Case "12"
                Return PB_A2
            Case "13"
                Return PB_A3
            Case "14"
                Return PB_A4
            Case "15"
                Return PB_A5
            Case "16"
                Return PB_A6
            Case "17"
                Return PB_A7
            Case "18"
                Return PB_A8
            Case "21"
                Return PB_B1
            Case "22"
                Return PB_B2
            Case "23"
                Return PB_B3
            Case "24"
                Return PB_B4
            Case "25"
                Return PB_B5
            Case "26"
                Return PB_B6
            Case "27"
                Return PB_B7
            Case "28"
                Return PB_B8
            Case "31"
                Return PB_C1
            Case "32"
                Return PB_C2
            Case "33"
                Return PB_C3
            Case "34"
                Return PB_C4
            Case "35"
                Return PB_C5
            Case "36"
                Return PB_C6
            Case "37"
                Return PB_C7
            Case "38"
                Return PB_C8
            Case "41"
                Return PB_D1
            Case "42"
                Return PB_D2
            Case "43"
                Return PB_D3
            Case "44"
                Return PB_D4
            Case "45"
                Return PB_D5
            Case "46"
                Return PB_D6
            Case "47"
                Return PB_D7
            Case "48"
                Return PB_D8
            Case "51"
                Return PB_E1
            Case "52"
                Return PB_E2
            Case "53"
                Return PB_E3
            Case "54"
                Return PB_E4
            Case "55"
                Return PB_E5
            Case "56"
                Return PB_E6
            Case "57"
                Return PB_E7
            Case "58"
                Return PB_E8
            Case "61"
                Return PB_F1
            Case "62"
                Return PB_F2
            Case "63"
                Return PB_F3
            Case "64"
                Return PB_F4
            Case "65"
                Return PB_F5
            Case "66"
                Return PB_F6
            Case "67"
                Return PB_F7
            Case "68"
                Return PB_F8
            Case "71"
                Return PB_G1
            Case "72"
                Return PB_G2
            Case "73"
                Return PB_G3
            Case "74"
                Return PB_G4
            Case "75"
                Return PB_G5
            Case "76"
                Return PB_G6
            Case "77"
                Return PB_G7
            Case "78"
                Return PB_G8
            Case "81"
                Return PB_H1
            Case "82"
                Return PB_H2
            Case "83"
                Return PB_H3
            Case "84"
                Return PB_H4
            Case "85"
                Return PB_H5
            Case "86"
                Return PB_H6
            Case "87"
                Return PB_H7
            Case "88"
                Return PB_H8
        End Select
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        jeu1 = New Jeu(False)
        finJeu = False
        firstclick = False
        isGreen = False
        actualiserJeu(jeu1)
        'Dim changerPion As New PionToPiece(Me, New KeyValuePair(Of Integer, Integer)(1, 1), Piece.Couleurs.Blanc)
        'changerPion.Show()
    End Sub

    Sub actualiserJeu(jeu As Jeu)
        For i = 1 To 8
            'For ind = 65 To 72
            For j = 1 To 8
                getPictureBox(i, j).Image = New Piece(Piece.TypesPiece.Vide, Piece.Couleurs.Blanc, New KeyValuePair(Of Integer, Integer)(i, j)).imagePiece
            Next
        Next
        For index = 0 To jeu.pieceBlanche.Count - 1
            getPictureBox(jeu.pieceBlanche(index).position.Key, jeu.pieceBlanche(index).position.Value).Image = jeu.pieceBlanche(index).imagePiece
        Next

        For index = 0 To jeu.pieceNoire.Count - 1
            getPictureBox(jeu.pieceNoire(index).position.Key, jeu.pieceNoire(index).position.Value).Image = jeu.pieceNoire(index).imagePiece
        Next
    End Sub

    Private Sub PB_Click(sender As Object, e As EventArgs) Handles _
            PB_A8.Click, PB_A7.Click, PB_A6.Click, PB_A5.Click,
            PB_A4.Click, PB_A3.Click, PB_A2.Click, PB_A1.Click,
            PB_B8.Click, PB_B7.Click, PB_B6.Click, PB_B5.Click,
            PB_B4.Click, PB_B3.Click, PB_B2.Click, PB_B1.Click,
            PB_C8.Click, PB_C7.Click, PB_C6.Click, PB_C5.Click,
            PB_C4.Click, PB_C3.Click, PB_C2.Click, PB_C1.Click,
            PB_D8.Click, PB_D7.Click, PB_D6.Click, PB_D5.Click,
            PB_D4.Click, PB_D3.Click, PB_D2.Click, PB_D1.Click,
            PB_E8.Click, PB_E7.Click, PB_E6.Click, PB_E5.Click,
            PB_E4.Click, PB_E3.Click, PB_E2.Click, PB_E1.Click,
            PB_F8.Click, PB_F7.Click, PB_F6.Click, PB_F5.Click,
            PB_F4.Click, PB_F3.Click, PB_F2.Click, PB_F1.Click,
            PB_G8.Click, PB_G7.Click, PB_G6.Click, PB_G5.Click,
            PB_G4.Click, PB_G3.Click, PB_G2.Click, PB_G1.Click,
            PB_H8.Click, PB_H7.Click, PB_H6.Click, PB_H5.Click,
            PB_H4.Click, PB_H3.Click, PB_H2.Click, PB_H1.Click
        Dim j As Integer = Asc(CType(sender, PictureBox).Name.Chars(3)) - 64
        Dim i As Integer = Asc(CType(sender, PictureBox).Name.Chars(4)) - 48
        Dim position As New KeyValuePair(Of Integer, Integer)(i, j)
        Dim numberPlayer As Integer
        Dim opposingColor As Piece.Couleurs
        Dim couleurPlayer As Piece.Couleurs
        If (Not jeu1.ia) Then
            If (jeu1.Turn = Piece.Couleurs.Blanc) Then
                couleurPlayer = Piece.Couleurs.Blanc
                opposingColor = Piece.Couleurs.Noir
            Else
                couleurPlayer = Piece.Couleurs.Noir
                opposingColor = Piece.Couleurs.Blanc
            End If
            If (jeu1.Turn = Piece.Couleurs.Blanc) Then
                numberPlayer = 1
            Else
                numberPlayer = 2
            End If
            'If (Not jeu1.echec(jeu1.Turn)) Then
            If (Not finJeu) Then
                If (Not firstclick) Then
                    If (Math.Floor(jeu1.tableDeJeu(i, j) / 100) = numberPlayer) Then
                        If (jeu1.canMove(jeu1.tableDeJeu(i, j))) Then
                            'MsgBox("can move")
                            jeu1.getPiece(position).switchToGreen()
                            'actualiserJeu(videjeu)
                            actualiserJeu(jeu1)
                            isGreen = True
                            posClick = New KeyValuePair(Of Integer, Integer)(i, j)
                            firstclick = True
                        Else
                            jeu1.getPiece(position).switchToRed()
                            'actualiserJeu(videjeu)
                            actualiserJeu(jeu1)
                            isGreen = False
                            posClick = New KeyValuePair(Of Integer, Integer)(i, j)
                            firstclick = True
                        End If
                    End If
                Else
                    If (isGreen And jeu1.moveToPos(jeu1.tableDeJeu(posClick.Key, posClick.Value), New KeyValuePair(Of Integer, Integer)(i, j))) Then
                        firstclick = False
                        isGreen = False
                        'actualiserJeu(videjeu)
                        If (jeu1.getPiece(New KeyValuePair(Of Integer, Integer)(i, j)).type = Piece.TypesPiece.Pion) Then
                            If (couleurPlayer = Piece.Couleurs.Blanc And i = 8) Then
                                Dim reponse As String = ""
                                While (Not reponseVoulu(reponse))
                                    'boucler
                                    reponse = InputBox("ecrire: DAME,TOUR,CHEVALIER,FOU", "choisir piece")
                                    'MsgBox(reponse)
                                End While
                                Dim p = jeu1.createPiece(typeFromName(reponse), Piece.Couleurs.Blanc, New KeyValuePair(Of Integer, Integer)(i, j))
                                jeu1.pieceBlanche(jeu1.tableDeJeu(i, j) Mod 100) = p
                                'Dim changerPion As New PionToPiece(Me, New KeyValuePair(Of Integer, Integer)(i, j), Piece.Couleurs.Blanc)
                                'changerPion.Show()

                                'sleep()
                                'While (changerPion.wait)
                                'nothing
                                'End While

                            ElseIf (couleurPlayer = Piece.Couleurs.Noir And i = 1) Then
                                Dim reponse As String = ""
                                While (Not reponseVoulu(reponse))
                                    reponse = InputBox("ecrire: DAME,TOUR,CHEVALIER,FOU", "choisir piece")
                                    'boucler
                                    'MsgBox(reponse)
                                End While
                                Dim p = jeu1.createPiece(typeFromName(reponse), Piece.Couleurs.Noir, New KeyValuePair(Of Integer, Integer)(i, j))
                                jeu1.pieceNoire(jeu1.tableDeJeu(i, j) Mod 100) = p
                                'Dim changerPion As New PionToPiece(Me, New KeyValuePair(Of Integer, Integer)(i, j), Piece.Couleurs.Noir)
                                'changerPion.Show()
                                'sleep()
                                'If (changerPion.wait) Then

                                'End If
                                'jeu1.pieceNoire(jeu1.tableDeJeu(i, j) Mod 100) = getFromPionToPiece
                            End If
                        End If
                            actualiserJeu(jeu1)
                        If (jeu1.echec(opposingColor) And jeu1.echecMat(opposingColor)) Then
                            If (couleurPlayer = Piece.Couleurs.Blanc) Then

                                Dim historique As New Historique(CSignIn.infoCompte.idPersonne, "JVSJ", Now().ToString, "WIN")
                                historique.addHistorique()
                            Else

                                Dim historique As New Historique(CSignIn.infoCompte.idPersonne, "JVSJ", Now().ToString, "LOOSE")
                                historique.addHistorique()
                                'HERE THE SAVE OF JOUEUR VS JOUEUR LOOSE'
                                'HERE THE SAVE OF JOUEUR VS JOUEUR LOOSE'
                                'HERE THE SAVE OF JOUEUR VS JOUEUR LOOSE'
                                'HERE THE SAVE OF JOUEUR VS JOUEUR LOOSE'
                                'HERE THE SAVE OF JOUEUR VS JOUEUR LOOSE'
                                'HERE THE SAVE OF JOUEUR VS JOUEUR LOOSE'
                                'HERE THE SAVE OF JOUEUR VS JOUEUR LOOSE'
                                'HERE THE SAVE OF JOUEUR VS JOUEUR LOOSE'
                                'HERE THE SAVE OF JOUEUR VS JOUEUR LOOSE'
                                'HERE THE SAVE OF JOUEUR VS JOUEUR LOOSE'
                                'HERE THE SAVE OF JOUEUR VS JOUEUR LOOSE'
                                'HERE THE SAVE OF JOUEUR VS JOUEUR LOOSE'
                                'HERE THE SAVE OF JOUEUR VS JOUEUR LOOSE'
                            End If

                            finJeu = True
                            MsgBox("le joueur " & couleurPlayer.ToString & " a gagné la partie")
                        End If
                    ElseIf (isGreen) Then
                        jeu1.getPiece(posClick).switchToNeutral()
                        firstclick = False
                        isGreen = False
                        'actualiserJeu(videjeu)
                        actualiserJeu(jeu1)
                    ElseIf (Not isGreen) Then
                        jeu1.getPiece(posClick).switchToNeutral()
                        If (Math.Floor(jeu1.tableDeJeu(i, j) / 100) = numberPlayer) Then
                            If (jeu1.canMove(jeu1.tableDeJeu(i, j))) Then
                                jeu1.getPiece(position).switchToGreen()
                                'actualiserJeu(videjeu)
                                actualiserJeu(jeu1)
                                isGreen = True
                                posClick = New KeyValuePair(Of Integer, Integer)(i, j)
                                firstclick = True
                            Else
                                jeu1.getPiece(position).switchToRed()
                                'actualiserJeu(videjeu)
                                actualiserJeu(jeu1)
                                isGreen = False
                                posClick = New KeyValuePair(Of Integer, Integer)(i, j)
                                firstclick = True
                            End If
                        Else
                            'actualiserJeu(videjeu)
                            actualiserJeu(jeu1)
                            firstclick = False
                            isGreen = False
                        End If
                    End If
                End If

            End If
        Else
            If (jeu1.Turn = Piece.Couleurs.Blanc) Then
                couleurPlayer = Piece.Couleurs.Blanc
                opposingColor = Piece.Couleurs.Noir
            Else
                couleurPlayer = Piece.Couleurs.Noir
                opposingColor = Piece.Couleurs.Blanc
            End If
            If (jeu1.Turn = Piece.Couleurs.Blanc) Then
                numberPlayer = 1
            Else
                '
                '
                '
            End If
            'If (Not jeu1.echec(jeu1.Turn)) Then
            If (Not finJeu) Then
                If (Not firstclick) Then
                    If (Math.Floor(jeu1.tableDeJeu(i, j) / 100) = numberPlayer) Then
                        If (jeu1.canMove(jeu1.tableDeJeu(i, j))) Then
                            'MsgBox("can move")
                            jeu1.getPiece(position).switchToGreen()
                            'actualiserJeu(videjeu)
                            actualiserJeu(jeu1)
                            isGreen = True
                            posClick = New KeyValuePair(Of Integer, Integer)(i, j)
                            firstclick = True
                        Else
                            jeu1.getPiece(position).switchToRed()
                            'actualiserJeu(videjeu)
                            actualiserJeu(jeu1)
                            isGreen = False
                            posClick = New KeyValuePair(Of Integer, Integer)(i, j)
                            firstclick = True
                        End If
                    End If
                Else
                    If (isGreen And jeu1.moveToPos(jeu1.tableDeJeu(posClick.Key, posClick.Value), New KeyValuePair(Of Integer, Integer)(i, j))) Then
                        firstclick = False
                        isGreen = False
                        'actualiserJeu(videjeu)
                        actualiserJeu(jeu1)
                        If (jeu1.echec(opposingColor) And jeu1.echecMat(opposingColor)) Then
                            Dim historique As New Historique(CSignIn.infoCompte.idPersonne, "IA EASY", Now().ToString, "WIN")
                            historique.addHistorique()
                            'HERE THE SAVE FOR IA EASY'
                            'HERE THE SAVE FOR IA EASY'
                            'HERE THE SAVE FOR IA EASY'
                            'HERE THE SAVE FOR IA EASY'
                            'HERE THE SAVE FOR IA EASY'
                            'HERE THE SAVE FOR IA EASY'
                            'HERE THE SAVE FOR IA EASY'
                            'HERE THE SAVE FOR IA EASY'
                            'HERE THE SAVE FOR IA EASY'
                            'HERE THE SAVE FOR IA EASY'
                            'HERE THE SAVE FOR IA EASY'
                            'HERE THE SAVE FOR IA EASY'
                            finJeu = True
                            MsgBox("le joueur " & couleurPlayer.ToString & " a gagné la partie")
                        Else
                            jeu1.RandomMoveIAEasy()
                            actualiserJeu(jeu1)
                            If (jeu1.echec(opposingColor) And jeu1.echecMat(opposingColor)) Then

                                Dim historique As New Historique(CSignIn.infoCompte.idPersonne, "IA EASY", Now().ToString, "LOOSE")
                                historique.addHistorique()
                                finJeu = True
                                MsgBox("le joueur " & couleurPlayer.ToString & " a gagné la partie")
                            End If
                        End If

                    ElseIf (isGreen) Then
                        jeu1.getPiece(posClick).switchToNeutral()
                        firstclick = False
                        isGreen = False
                        'actualiserJeu(videjeu)
                        actualiserJeu(jeu1)
                    ElseIf (Not isGreen) Then
                        jeu1.getPiece(posClick).switchToNeutral()
                        If (Math.Floor(jeu1.tableDeJeu(i, j) / 100) = numberPlayer) Then
                            If (jeu1.canMove(jeu1.tableDeJeu(i, j))) Then
                                jeu1.getPiece(position).switchToGreen()
                                'actualiserJeu(videjeu)
                                actualiserJeu(jeu1)
                                isGreen = True
                                posClick = New KeyValuePair(Of Integer, Integer)(i, j)
                                firstclick = True
                            Else
                                jeu1.getPiece(position).switchToRed()
                                'actualiserJeu(videjeu)
                                actualiserJeu(jeu1)
                                isGreen = False
                                posClick = New KeyValuePair(Of Integer, Integer)(i, j)
                                firstclick = True
                            End If
                        Else
                            'actualiserJeu(videjeu)
                            actualiserJeu(jeu1)
                            firstclick = False
                            isGreen = False
                        End If
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        jeu1 = New Jeu(True)
        finJeu = False
        firstclick = False
        isGreen = False
        actualiserJeu(jeu1)
    End Sub
End Class