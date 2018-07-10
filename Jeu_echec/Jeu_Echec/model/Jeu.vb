Public Class Jeu
    Public tableDeJeu(8, 8) As Integer
    Public Property ia As Boolean = False
    Public Property pieceBlanche As List(Of Piece)
    Public Property pieceNoire As List(Of Piece)
    Public Property pieceBlancheMorte As List(Of Piece)
    Public Property pieceNoireMorte As List(Of Piece)
    Public Property Turn As Piece.Couleurs

    Sub New(isIA As Boolean)
        ia = isIA
        pieceBlanche = New List(Of Piece)
        pieceBlanche.Add(New Piece_Tour(Piece.Couleurs.Blanc, New KeyValuePair(Of Integer, Integer)(1, 1)))
        pieceBlanche.Add(New Piece_Chevalier(Piece.Couleurs.Blanc, New KeyValuePair(Of Integer, Integer)(1, 2)))
        pieceBlanche.Add(New Piece_Fou(Piece.Couleurs.Blanc, New KeyValuePair(Of Integer, Integer)(1, 3)))
        pieceBlanche.Add(New Piece_Dame(Piece.Couleurs.Blanc, New KeyValuePair(Of Integer, Integer)(1, 4)))
        pieceBlanche.Add(New Piece_Roi(Piece.Couleurs.Blanc, New KeyValuePair(Of Integer, Integer)(1, 5)))
        pieceBlanche.Add(New Piece_Fou(Piece.Couleurs.Blanc, New KeyValuePair(Of Integer, Integer)(1, 6)))
        pieceBlanche.Add(New Piece_Chevalier(Piece.Couleurs.Blanc, New KeyValuePair(Of Integer, Integer)(1, 7)))
        pieceBlanche.Add(New Piece_Tour(Piece.Couleurs.Blanc, New KeyValuePair(Of Integer, Integer)(1, 8)))
        For index = 1 To 8
            pieceBlanche.Add(New Piece_Pion(Piece.Couleurs.Blanc, New KeyValuePair(Of Integer, Integer)(2, index)))
        Next

        pieceNoire = New List(Of Piece)
        pieceNoire.Add(New Piece_Tour(Piece.Couleurs.Noir, New KeyValuePair(Of Integer, Integer)(8, 1)))
        pieceNoire.Add(New Piece_Chevalier(Piece.Couleurs.Noir, New KeyValuePair(Of Integer, Integer)(8, 2)))
        pieceNoire.Add(New Piece_Fou(Piece.Couleurs.Noir, New KeyValuePair(Of Integer, Integer)(8, 3)))
        pieceNoire.Add(New Piece_Dame(Piece.Couleurs.Noir, New KeyValuePair(Of Integer, Integer)(8, 4)))
        pieceNoire.Add(New Piece_Roi(Piece.Couleurs.Noir, New KeyValuePair(Of Integer, Integer)(8, 5)))
        pieceNoire.Add(New Piece_Fou(Piece.Couleurs.Noir, New KeyValuePair(Of Integer, Integer)(8, 6)))
        pieceNoire.Add(New Piece_Chevalier(Piece.Couleurs.Noir, New KeyValuePair(Of Integer, Integer)(8, 7)))
        pieceNoire.Add(New Piece_Tour(Piece.Couleurs.Noir, New KeyValuePair(Of Integer, Integer)(8, 8)))

        For index = 1 To 8
            pieceNoire.Add(New Piece_Pion(Piece.Couleurs.Noir, New KeyValuePair(Of Integer, Integer)(7, index)))
        Next
        Turn = Piece.Couleurs.Blanc

        pieceBlancheMorte = New List(Of Piece)
        pieceNoireMorte = New List(Of Piece)

        For index1 = 1 To 8
            For index2 = 1 To 8
                tableDeJeu(index1, index2) = 0
            Next
        Next

        For index = 1 To 8
            tableDeJeu(1, index) = 100 + index - 1 '100 is the color white
        Next
        For index = 9 To 16
            tableDeJeu(2, index - 8) = 100 + index - 1
        Next
        For index = 1 To 8
            tableDeJeu(8, index) = 200 + index - 1 '200 is the color black
        Next
        For index = 9 To 16
            tableDeJeu(7, index - 8) = 200 + index - 1
        Next

    End Sub

    Public Function cloneJeu() As Jeu
        Dim clone As New Jeu(False)
        For index = 0 To pieceBlanche.Count - 1
            clone.pieceBlanche.Add(Me.pieceBlanche(index).Clone)
        Next
        For index = 0 To pieceNoire.Count - 1
            clone.pieceNoire.Add(Me.pieceNoire(index).Clone)
        Next
        For index = 0 To pieceBlancheMorte.Count - 1
            clone.pieceBlancheMorte.Add(Me.pieceBlancheMorte(index).Clone)
        Next
        For index = 0 To pieceNoireMorte.Count - 1
            clone.pieceNoireMorte.Add(Me.pieceNoireMorte(index).Clone)
        Next
        clone.Turn = Me.Turn
        For i = 1 To 8
            For j = 1 To 8
                clone.tableDeJeu(i, j) = Me.tableDeJeu(i, j)
            Next
        Next
        Return clone
    End Function

    Public Sub initPositions()
        For i = 1 To 8
            For j = 1 To 8
                tableDeJeu(i, j) = 0
            Next
        Next
        For i = 0 To pieceBlanche.Count - 1
            tableDeJeu(pieceBlanche(i).position.Key, pieceBlanche(i).position.Value) = 100 + i
        Next

        For i = 0 To pieceNoire.Count - 1
            tableDeJeu(pieceNoire(i).position.Key, pieceNoire(i).position.Value) = 200 + i
        Next
    End Sub

    Public Function createPiece(ByVal type As Piece.TypesPiece, ByVal couleur As Piece.Couleurs, ByVal position As KeyValuePair(Of Integer, Integer)) As Piece
        Select Case type
            Case Piece.TypesPiece.Pion
                Return New Piece_Pion(couleur, position)
            Case Piece.TypesPiece.Chevalier
                Return New Piece_Chevalier(couleur, position)
            Case Piece.TypesPiece.Dame
                Return New Piece_Dame(couleur, position)
            Case Piece.TypesPiece.Fou
                Return New Piece_Fou(couleur, position)
            Case Piece.TypesPiece.Roi
                Return New Piece_Roi(couleur, position)
            Case Piece.TypesPiece.Tour
                Return New Piece_Tour(couleur, position)
        End Select
        Return New Piece(type, couleur, position)
    End Function

    Public Function RandomMoveIAEasy() As Boolean
        Dim resultat As KeyValuePair(Of Integer, KeyValuePair(Of Integer, Integer))
        Randomize()
        Dim random As New Random()
        Dim color As Piece.Couleurs
        Dim list As New List(Of KeyValuePair(Of Integer, KeyValuePair(Of Integer, Integer)))
        Dim tmp As New List(Of KeyValuePair(Of Integer, Integer))
        For i = 0 To pieceNoire.Count - 1
            tmp = moves(pieceNoire(i))
            For j = 0 To tmp.Count - 1
                If canMoveToPos(200 + i, tmp(j)) Then
                    list.Add(New KeyValuePair(Of Integer, KeyValuePair(Of Integer, Integer))(200 + i, New KeyValuePair(Of Integer, Integer)(tmp(j).Key, tmp(j).Value)))
                End If
            Next
        Next
        If list.Count = 0 Then
            Return False
        End If
        Dim choix = random.Next(0, list.Count - 1)
        resultat = list(choix)
        moveToPos(resultat.Key, resultat.Value)
        Return True
    End Function

    Public Function getPiece(position As KeyValuePair(Of Integer, Integer)) As Piece 'get piece from matrix
        Dim pos As Integer = tableDeJeu(position.Key, position.Value)
        'MsgBox("getpiece: " & position.Key & " " & position.Value)
        'MsgBox("piece: " & pieceBlanche(pos Mod 100).ToString)
        If (Math.Floor(pos / 100) = 1) Then
            Return pieceBlanche(pos Mod 100)
        ElseIf (math.Floor(pos / 100) = 2) Then
            Return pieceNoire(pos Mod 100)
        Else
            Return Nothing
        End If
    End Function

    Public Function searchPiece(piece As Piece, couleur As Piece.Couleurs) As Integer 'search piece indice in lists
        If (couleur = Piece.Couleurs.Blanc) Then
            For i = 0 To pieceBlanche.Count - 1
                If piece.GetType = pieceBlanche(i).GetType And piece.position.Key = pieceBlanche(i).position.Key And piece.position.Value = pieceBlanche(i).position.Value Then
                    Return 100 + i
                End If
            Next
        Else
            For i = 0 To pieceNoire.Count - 1
                If piece.GetType = pieceNoire(i).GetType And piece.position.Key = pieceNoire(i).position.Key And piece.position.Value = pieceNoire(i).position.Value Then
                    Return 200 + i
                End If
            Next
        End If
        Return 0
    End Function

    Public Function dangerZone(opposingColor As Piece.Couleurs) As List(Of KeyValuePair(Of Integer, Integer)) 'dangerzone
        Dim resultat As New List(Of KeyValuePair(Of Integer, Integer))
        Dim couleurNumber As Integer
        Dim numeroPiece As Integer
        Dim opposeCouleurNumber As Integer
        If (opposingColor = Piece.Couleurs.Blanc) Then
            couleurNumber = 1
            opposeCouleurNumber = 2
        Else
            couleurNumber = 2
            opposeCouleurNumber = 1
        End If
        If (opposingColor = Piece.Couleurs.Blanc) Then
            For ii = 1 To 8
                For jj = 1 To 8
                    If (Math.Floor(tableDeJeu(ii, jj) / 100) = 1) Then
                        Dim index2 = tableDeJeu(ii, jj) Mod 100
                        numeroPiece = 1 * 100 + index2
                        If (pieceBlanche(index2).GetType = GetType(Piece_Chevalier)) Then
                            Dim ls As List(Of KeyValuePair(Of Integer, Integer))
                            ls = pieceBlanche(index2).moves()
                            For index = 0 To ls.Count - 1
                                If (Not (Math.Floor(tableDeJeu(ls(index).Key, ls(index).Value) / 100) = couleurNumber)) Then
                                    resultat.Add(New KeyValuePair(Of Integer, Integer)(ls(index).Key, ls(index).Value))
                                End If
                            Next
                        ElseIf (pieceBlanche(index2).GetType = GetType(Piece_Dame)) Then
                            Dim i, j As Integer
                            For index = 0 To pieceBlanche(index2).move.Length - 1
                                i = pieceBlanche(index2).position.Key
                                j = pieceBlanche(index2).position.Value
                                Dim verif As Boolean = False
                                While (Not verif)
                                    If Not (tableDeJeu(i, j) = numeroPiece) Then
                                        If (Math.Floor(tableDeJeu(i, j) / 100) = couleurNumber) Then
                                            verif = True
                                        ElseIf (Not (tableDeJeu(i, j) Mod 100 = 0)) Then
                                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                                            verif = True
                                        Else
                                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                                        End If
                                    End If
                                    i = i + pieceBlanche(index2).move(index).Key
                                    j = j + pieceBlanche(index2).move(index).Value
                                    If (i > 8 Or i < 1 Or j > 8 Or j < 1) Then
                                        verif = True
                                    End If
                                End While
                            Next
                        ElseIf (pieceBlanche(index2).GetType = GetType(Piece_Fou)) Then
                            Dim i, j As Integer
                            For index = 0 To pieceBlanche(index2).move.Length - 1
                                i = pieceBlanche(index2).position.Key
                                j = pieceBlanche(index2).position.Value
                                Dim verif As Boolean = False
                                While (Not verif)
                                    If Not (tableDeJeu(i, j) = numeroPiece) Then
                                        If (Math.Floor(tableDeJeu(i, j) / 100) = couleurNumber) Then
                                            verif = True
                                        ElseIf (Not (tableDeJeu(i, j) Mod 100 = 0)) Then
                                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                                            verif = True
                                        Else
                                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                                        End If
                                    End If
                                    i = i + pieceBlanche(index2).move(index).Key
                                    j = j + pieceBlanche(index2).move(index).Value
                                    If (i > 8 Or i < 1 Or j > 8 Or j < 1) Then
                                        verif = True
                                    End If
                                End While
                            Next
                        ElseIf (pieceBlanche(index2).GetType = GetType(Piece_Pion)) Then
                            Dim i, j As Integer
                            i = pieceBlanche(index2).position.Key
                            j = pieceBlanche(index2).position.Value
                            If (j + pieceBlanche(index2).move(0).Value > 0 And j + pieceBlanche(index2).move(0).Value < 9 And i + pieceBlanche(index2).move(0).Key > 0 And i + pieceBlanche(index2).move(0).Key < 9) Then
                                If (j + pieceBlanche(index2).move(0).Value + 1 > 0 And j + pieceBlanche(index2).move(0).Value + 1 < 9) Then
                                    If (Math.Floor(tableDeJeu(i + pieceBlanche(index2).move(0).Key, j + pieceBlanche(index2).move(0).Value + 1)) / 100 = opposeCouleurNumber) Then
                                        resultat.Add(New KeyValuePair(Of Integer, Integer)(i + pieceBlanche(index2).move(0).Key, j + pieceBlanche(index2).move(0).Value + 1))
                                    End If
                                End If
                                If (j + pieceBlanche(index2).move(0).Value - 1 > 0 And j + pieceBlanche(index2).move(0).Value - 1 < 9) Then
                                    If (Math.Floor(tableDeJeu(i + pieceBlanche(index2).move(0).Key, j + pieceBlanche(index2).move(0).Value - 1)) / 100 = opposeCouleurNumber) Then
                                        resultat.Add(New KeyValuePair(Of Integer, Integer)(i + pieceBlanche(index2).move(0).Key, j + pieceBlanche(index2).move(0).Value - 1))
                                    End If
                                End If
                            End If
                        ElseIf (pieceBlanche(index2).GetType = GetType(Piece_Roi)) Then
                            resultat = pieceBlanche(index2).moves()
                        ElseIf (pieceBlanche(index2).GetType = GetType(Piece_Tour)) Then
                            Dim i, j As Integer
                            For index = 0 To pieceBlanche(index2).move.Length - 1
                                i = pieceBlanche(index2).position.Key
                                j = pieceBlanche(index2).position.Value
                                Dim verif As Boolean = False
                                While (Not verif)
                                    If Not (tableDeJeu(i, j) = numeroPiece) Then
                                        If (Math.Floor(tableDeJeu(i, j) / 100) = couleurNumber) Then
                                            verif = True
                                        ElseIf (Not (tableDeJeu(i, j) Mod 100 = 0)) Then
                                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                                            verif = True
                                        Else
                                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                                        End If
                                    End If
                                    i = i + pieceBlanche(index2).move(index).Key
                                    j = j + pieceBlanche(index2).move(index).Value
                                    If (i > 8 Or i < 1 Or j > 8 Or j < 1) Then
                                        verif = True
                                    End If
                                End While
                            Next
                        End If
                    End If
                Next
            Next
        Else
            For ii = 1 To 8
                For jj = 1 To 8
                    If (Math.Floor(tableDeJeu(ii, jj) / 100) = 2) Then
                        Dim index2 = tableDeJeu(ii, jj) Mod 100
                        numeroPiece = 2 * 100 + index2
                        If (pieceNoire(index2).GetType = GetType(Piece_Chevalier)) Then
                            resultat = pieceNoire(index2).moves()
                        ElseIf (pieceNoire(index2).GetType = GetType(Piece_Dame)) Then
                            Dim i, j As Integer
                            For index = 0 To pieceNoire(index2).move.Length - 1
                                i = pieceNoire(index2).position.Key
                                j = pieceNoire(index2).position.Value
                                Dim verif As Boolean = False
                                While (Not verif)
                                    If Not (tableDeJeu(i, j) = numeroPiece) Then
                                        If (Math.Floor(tableDeJeu(i, j) / 100) = couleurNumber) Then
                                            verif = True
                                        ElseIf (Not (tableDeJeu(i, j) Mod 100 = 0)) Then
                                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                                            verif = True
                                        Else
                                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                                        End If
                                    End If
                                    i = i + pieceNoire(index2).move(index).Key
                                    j = j + pieceNoire(index2).move(index).Value
                                    If (i > 8 Or i < 1 Or j > 8 Or j < 1) Then
                                        verif = True
                                    End If
                                End While
                            Next
                        ElseIf (pieceNoire(index2).GetType = GetType(Piece_Fou)) Then
                            Dim i, j As Integer
                            For index = 0 To pieceNoire(index2).move.Length - 1
                                i = pieceNoire(index2).position.Key
                                j = pieceNoire(index2).position.Value
                                Dim verif As Boolean = False
                                While (Not verif)
                                    If Not (tableDeJeu(i, j) = numeroPiece) Then
                                        If (Math.Floor(tableDeJeu(i, j) / 100) = couleurNumber) Then
                                            verif = True
                                        ElseIf (Not (tableDeJeu(i, j) Mod 100 = 0)) Then
                                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                                            verif = True
                                        Else
                                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                                        End If
                                    End If
                                    i = i + pieceNoire(index2).move(index).Key
                                    j = j + pieceNoire(index2).move(index).Value
                                    If (i > 8 Or i < 1 Or j > 8 Or j < 1) Then
                                        verif = True
                                    End If
                                End While
                            Next
                        ElseIf (pieceNoire(index2).GetType = GetType(Piece_Pion)) Then
                            Dim i, j As Integer
                            i = pieceNoire(index2).position.Key
                            j = pieceNoire(index2).position.Value
                            If (j + pieceNoire(index2).move(0).Value > 0 And j + pieceNoire(index2).move(0).Value < 9 And i + pieceNoire(index2).move(0).Key > 0 And i + pieceNoire(index2).move(0).Key) Then
                                If (tableDeJeu(i + pieceNoire(index2).move(0).Key, j + pieceNoire(index2).move(0).Value) = 0) Then
                                    resultat.Add(New KeyValuePair(Of Integer, Integer)(i + pieceNoire(index2).move(0).Key, j + pieceNoire(index2).move(0).Value))
                                End If
                                If (j + pieceNoire(index2).move(0).Value + 1 > 0 And j + pieceNoire(index2).move(0).Value + 1 < 9) Then
                                    If (Math.Floor(tableDeJeu(i + pieceNoire(index2).move(0).Key, j + pieceNoire(index2).move(0).Value + 1)) / 100 = opposeCouleurNumber) Then
                                        resultat.Add(New KeyValuePair(Of Integer, Integer)(i + pieceNoire(index2).move(0).Key, j + pieceNoire(index2).move(0).Value + 1))
                                    End If
                                End If
                                If (j + pieceNoire(index2).move(0).Value + 1 > 0 And j + pieceNoire(index2).move(0).Value - 1 < 9) Then
                                    If (Math.Floor(tableDeJeu(i + pieceNoire(index2).move(0).Key, j + pieceNoire(index2).move(0).Value - 1)) / 100 = opposeCouleurNumber) Then
                                        resultat.Add(New KeyValuePair(Of Integer, Integer)(i + pieceNoire(index2).move(0).Key, j + pieceNoire(index2).move(0).Value - 1))
                                    End If
                                End If
                            End If
                        ElseIf (pieceNoire(index2).GetType = GetType(Piece_Roi)) Then
                            resultat = pieceNoire(index2).moves()
                        ElseIf (pieceNoire(index2).GetType = GetType(Piece_Tour)) Then
                            Dim i, j As Integer
                            For index = 0 To pieceNoire(index2).move.Length - 1
                                i = pieceNoire(index2).position.Key
                                j = pieceNoire(index2).position.Value
                                Dim verif As Boolean = False
                                While (Not verif)
                                    If Not (tableDeJeu(i, j) = numeroPiece) Then
                                        If (Math.Floor(tableDeJeu(i, j) / 100) = couleurNumber) Then
                                            verif = True
                                        ElseIf (Not (tableDeJeu(i, j) Mod 100 = 0)) Then
                                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                                            verif = True
                                        Else
                                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                                        End If
                                    End If
                                    i = i + pieceNoire(index2).move(index).Key
                                    j = j + pieceNoire(index2).move(index).Value
                                    If (i > 8 Or i < 1 Or j > 8 Or j < 1) Then
                                        verif = True
                                    End If
                                End While
                            Next
                        End If
                    End If
                Next
            Next
        End If
        Return resultat
    End Function

    Public Function moves(piece As Piece) As List(Of KeyValuePair(Of Integer, Integer)) 'possible moves of piece
        Dim resultat As New List(Of KeyValuePair(Of Integer, Integer))
        Dim numeroPiece As Integer = searchPiece(piece, piece.couleur)
        Dim couleurNumber As Integer
        Dim opposingColor As Piece.Couleurs
        Dim opposeCouleurNumber As Integer
        Dim passOtherColor As Boolean = False
        If (piece.couleur = Piece.Couleurs.Blanc) Then
            couleurNumber = 1
            opposingColor = Piece.Couleurs.Noir
            opposeCouleurNumber = 2
        Else
            couleurNumber = 2
            opposingColor = Piece.Couleurs.Blanc
            opposeCouleurNumber = 1
        End If
        If (piece.GetType = GetType(Piece_Chevalier)) Then
            Dim ls As List(Of KeyValuePair(Of Integer, Integer))
            ls = piece.moves()

            For index = 0 To ls.Count - 1
                If (Not (Math.Floor(tableDeJeu(ls(index).Key, ls(index).Value) / 100) = couleurNumber)) Then
                    resultat.Add(New KeyValuePair(Of Integer, Integer)(ls(index).Key, ls(index).Value))
                End If
            Next

            Return resultat
        ElseIf (piece.GetType = GetType(Piece_Dame)) Then
            Dim i, j As Integer
            For index = 0 To piece.move.Length - 1
                i = piece.position.Key
                j = piece.position.Value
                Dim verif As Boolean = False
                While (Not verif)
                    If Not (tableDeJeu(i, j) = numeroPiece) Then
                        If (Math.Floor(tableDeJeu(i, j) / 100) = couleurNumber) Then
                            verif = True
                        ElseIf (Not (Math.Floor(tableDeJeu(i, j) / 100) = 0)) Then
                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                            verif = True
                        Else
                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                        End If
                    End If
                    i = i + piece.move(index).Key
                    j = j + piece.move(index).Value
                    If (i > 8 Or i < 1 Or j > 8 Or j < 1) Then
                        verif = True
                    End If
                End While
            Next
            Return resultat
        ElseIf (piece.GetType = GetType(Piece_Fou)) Then
            Dim i, j As Integer
            For index = 0 To piece.move.Length - 1
                i = piece.position.Key
                j = piece.position.Value
                Dim verif As Boolean = False
                While (Not verif)
                    If Not (tableDeJeu(i, j) = numeroPiece) Then
                        If (Math.Floor(tableDeJeu(i, j) / 100) = couleurNumber) Then
                            verif = True
                        ElseIf (Not (tableDeJeu(i, j) Mod 100 = 0)) Then
                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                            verif = True
                        Else
                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                        End If
                    End If
                    i = i + piece.move(index).Key
                    j = j + piece.move(index).Value
                    If (i > 8 Or i < 1 Or j > 8 Or j < 1) Then
                        verif = True
                    End If
                End While
            Next
            Return resultat
        ElseIf (piece.GetType = GetType(Piece_Pion)) Then
            Dim i, j As Integer
            i = piece.position.Key
            j = piece.position.Value
            If (j + piece.move(0).Value > 0 And j + piece.move(0).Value < 9 And i + piece.move(0).Key > 0 And i + piece.move(0).Key) Then
                If (tableDeJeu(i + piece.move(0).Key, j + piece.move(0).Value) = 0) Then
                    resultat.Add(New KeyValuePair(Of Integer, Integer)(i + piece.move(0).Key, j + piece.move(0).Value))
                End If
                If (j + piece.move(0).Value + 1 > 0 And j + piece.move(0).Value + 1 < 9) Then
                    If (Math.Floor(tableDeJeu(i + piece.move(0).Key, j + piece.move(0).Value + 1) / 100) = opposeCouleurNumber) Then
                        resultat.Add(New KeyValuePair(Of Integer, Integer)(i + piece.move(0).Key, j + piece.move(0).Value + 1))
                    End If
                End If
                If (j + piece.move(0).Value - 1 > 0 And j + piece.move(0).Value - 1 < 9) Then
                    If (Math.Floor(tableDeJeu(i + piece.move(0).Key, j + piece.move(0).Value - 1) / 100) = opposeCouleurNumber) Then
                        resultat.Add(New KeyValuePair(Of Integer, Integer)(i + piece.move(0).Key, j + piece.move(0).Value - 1))
                    End If
                End If
            End If
            If (Not piece.FirstMove) Then
                If (tableDeJeu(i + piece.move(0).Key * 2, j + piece.move(0).Value) = 0 And tableDeJeu(i + piece.move(0).Key, j + piece.move(0).Value) = 0) Then
                    resultat.Add(New KeyValuePair(Of Integer, Integer)(i + piece.move(0).Key * 2, j + piece.move(0).Value))
                End If
            End If
            Return resultat

        ElseIf (piece.GetType = GetType(Piece_Roi)) Then
            Dim danger(8, 8) As Boolean
            For index = 1 To 8
                For index2 = 1 To 8
                    danger(index, index2) = False
                Next
            Next
            Dim dangerList As List(Of KeyValuePair(Of Integer, Integer))
            dangerList = dangerZone(opposingColor)
            For index = 0 To dangerList.Count - 1
                danger(dangerList(index).Key, dangerList(index).Value) = True
            Next
            Dim moveallowed As List(Of KeyValuePair(Of Integer, Integer)) = piece.moves()
            For index = 0 To moveallowed.Count - 1
                If (Not danger(moveallowed(index).Key, moveallowed(index).Value) And Not (Math.Floor(tableDeJeu(moveallowed(index).Key, moveallowed(index).Value) / 100) = couleurNumber)) Then
                    'MsgBox(moveallowed(index).Key & " " & moveallowed(index).Value)
                    'MsgBox(Math.Floor(tableDeJeu(moveallowed(index).Key, moveallowed(index).Value) / 100) & " = " & couleurNumber)
                    resultat.Add(moveallowed(index))
                End If
            Next
            Return resultat
        ElseIf (piece.GetType = GetType(Piece_Tour)) Then
            Dim i, j As Integer
            For index = 0 To piece.move.Length - 1
                i = piece.position.Key
                j = piece.position.Value
                Dim verif As Boolean = False
                While (Not verif)
                    If Not (tableDeJeu(i, j) = numeroPiece) Then
                        If (math.Floor(tableDeJeu(i, j) / 100) = couleurNumber) Then
                            verif = True
                        ElseIf (Not (tableDeJeu(i, j) Mod 100 = 0)) Then
                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                            verif = True
                        Else
                            resultat.Add(New KeyValuePair(Of Integer, Integer)(i, j))
                        End If
                    End If
                    i = i + piece.move(index).Key
                    j = j + piece.move(index).Value
                    If (i > 8 Or i < 1 Or j > 8 Or j < 1) Then
                        verif = True
                    End If
                End While
            Next
            Return resultat
        End If
        Return resultat
    End Function

    Public Function echec(color As Piece.Couleurs) As Boolean 'if color is in danger (echec)
        If (color = Piece.Couleurs.Blanc) Then
            For i = 1 To 8
                For j = 1 To 8
                    If (Math.Floor(tableDeJeu(i, j) / 100) = 1) Then
                        If (pieceBlanche(tableDeJeu(i, j) Mod 100).GetType = GetType(Piece_Roi)) Then
                            Dim dangerList As List(Of KeyValuePair(Of Integer, Integer))
                            dangerList = dangerZone(Piece.Couleurs.Noir)
                            For index = 0 To dangerList.Count - 1
                                If (dangerList(index).Key = i And dangerList(index).Value = j) Then
                                    Return True
                                End If
                            Next
                            Return False
                        End If
                    End If
                Next
            Next
        Else
            For i = 1 To 8
                For j = 1 To 8
                    If (Math.Floor(tableDeJeu(i, j) / 100) = 2) Then
                        If (pieceNoire(tableDeJeu(i, j) Mod 100).GetType = GetType(Piece_Roi)) Then
                            Dim dangerList As List(Of KeyValuePair(Of Integer, Integer))
                            dangerList = dangerZone(Piece.Couleurs.Blanc)
                            For index = 0 To dangerList.Count - 1
                                If (dangerList(index).Key = i And dangerList(index).Value = j) Then
                                    Return True
                                End If
                            Next
                            Return False
                        End If
                    End If
                Next
            Next
        End If
        Return Nothing
    End Function

    Public Function isTherePiece(i As Integer, j As Integer)
        If (tableDeJeu(i, j) = 0) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function canMoveToPos(piece As Integer, position As KeyValuePair(Of Integer, Integer))
        If (Math.Floor(piece / 100) = 1) Then
            Dim p = pieceBlanche(piece Mod 100)
            If (tableDeJeu(position.Key, position.Value) = 0 Or Math.Floor(tableDeJeu(position.Key, position.Value) / 100) = 2) Then
                Dim save As Integer = tableDeJeu(position.Key, position.Value)
                tableDeJeu(position.Key, position.Value) = piece
                tableDeJeu(p.position.Key, p.position.Value) = 0
                If Not echec(Jeu_Echec.Piece.Couleurs.Blanc) Then
                    tableDeJeu(position.Key, position.Value) = save
                    tableDeJeu(p.position.Key, p.position.Value) = piece
                    Return True
                Else
                    tableDeJeu(position.Key, position.Value) = save
                    tableDeJeu(p.position.Key, p.position.Value) = piece
                End If
            End If
        Else
            Dim p = pieceNoire(piece Mod 100)
            If (tableDeJeu(position.Key, position.Value) = 0 Or Math.Floor(tableDeJeu(position.Key, position.Value) / 100) = 1) Then
                Dim save As Integer = tableDeJeu(position.Key, position.Value)
                tableDeJeu(position.Key, position.Value) = piece
                tableDeJeu(p.position.Key, p.position.Value) = 0
                If Not echec(Jeu_Echec.Piece.Couleurs.Noir) Then
                    tableDeJeu(position.Key, position.Value) = save
                    tableDeJeu(p.position.Key, p.position.Value) = piece
                    Return True
                Else
                    tableDeJeu(position.Key, position.Value) = save
                    tableDeJeu(p.position.Key, p.position.Value) = piece
                End If
            End If
        End If
        Return False
    End Function

    Public Function canMove(piece As Integer) As Boolean
        If (Math.Floor(piece / 100) = 1) Then
            Dim p = pieceBlanche(piece Mod 100)
            Dim ls = moves(p)
            'MsgBox("size of moves: " & ls.Count)
            For i = 0 To ls.Count - 1
                If (tableDeJeu(ls(i).Key, ls(i).Value) = 0 Or Math.Floor(tableDeJeu(ls(i).Key, ls(i).Value) / 100) = 2) Then
                    Dim save As Integer = tableDeJeu(ls(i).Key, ls(i).Value)
                    tableDeJeu(ls(i).Key, ls(i).Value) = piece
                    tableDeJeu(p.position.Key, p.position.Value) = 0
                    If Not echec(Jeu_Echec.Piece.Couleurs.Blanc) Then
                        tableDeJeu(ls(i).Key, ls(i).Value) = save
                        tableDeJeu(p.position.Key, p.position.Value) = piece
                        Return True
                    Else
                        tableDeJeu(ls(i).Key, ls(i).Value) = save
                        tableDeJeu(p.position.Key, p.position.Value) = piece
                    End If
                End If
            Next
            'MsgBox("can't move")
            Return False

        Else
            Dim p = pieceNoire(piece Mod 100)
            Dim ls = moves(p)
            'MsgBox("size of moves: " & ls.Count)
            'MsgBox("table: " & tableDeJeu(ls(0).Key, ls(0).Value))
            'MsgBox("indice: " & ls(0).Key & " " & ls(0).Value)
            For i = 0 To ls.Count - 1
                If (tableDeJeu(ls(i).Key, ls(i).Value) = 0 Or Math.Floor(tableDeJeu(ls(i).Key, ls(i).Value) / 100) = 1) Then

                    Dim save As Integer = tableDeJeu(ls(i).Key, ls(i).Value)
                    tableDeJeu(ls(i).Key, ls(i).Value) = piece
                    tableDeJeu(p.position.Key, p.position.Value) = 0
                    If Not echec(Jeu_Echec.Piece.Couleurs.Noir) Then
                        tableDeJeu(ls(i).Key, ls(i).Value) = save
                        tableDeJeu(p.position.Key, p.position.Value) = piece
                        Return True
                    Else
                        tableDeJeu(ls(i).Key, ls(i).Value) = save
                        tableDeJeu(p.position.Key, p.position.Value) = piece
                    End If
                End If
            Next
            Return False
        End If
    End Function

    Public Function moveToPos(piece As Integer, position As KeyValuePair(Of Integer, Integer)) As Boolean
        Dim listAllowerPos As List(Of KeyValuePair(Of Integer, Integer))
        If (Math.Floor(piece / 100) = 1) Then
            listAllowerPos = moves(pieceBlanche(piece Mod 100))

            For index = 0 To listAllowerPos.Count - 1
                'MsgBox("allowed: " & listAllowerPos(index).Key & " " & listAllowerPos(index).Value)
                If (position.Key = listAllowerPos(index).Key And position.Value = listAllowerPos(index).Value) Then

                    If (Not canMoveToPos(piece, position)) Then
                        Return False
                    End If
                    Dim p = createPiece(pieceBlanche(piece Mod 100).type, pieceBlanche(piece Mod 100).couleur, position)
                    'MsgBox(p.position.Key & " " & p.position.Value)
                    If Not (tableDeJeu(position.Key, position.Value) = 0) Then
                        pieceNoireMorte.Add(pieceNoire(tableDeJeu(position.Key, position.Value) Mod 100))
                        pieceNoire.RemoveAt(tableDeJeu(position.Key, position.Value) Mod 100)

                    End If
                    tableDeJeu(pieceBlanche(piece Mod 100).position.Key, pieceBlanche(piece Mod 100).position.Value) = 0
                    pieceBlanche(piece Mod 100) = p
                    'MsgBox(pieceBlanche(piece Mod 100).position.Key & " " & pieceBlanche(piece Mod 100).position.Value)
                    tableDeJeu(p.position.Key, p.position.Value) = piece
                    Turn = Jeu_Echec.Piece.Couleurs.Noir
                    initPositions()
                    pieceBlanche(piece Mod 100).FirstMove = True
                    Return True
                End If
            Next
            Return False
        ElseIf (math.Floor(piece / 100) = 2) Then
            listAllowerPos = moves(pieceNoire(piece Mod 100))
            For index = 0 To listAllowerPos.Count - 1
                If (position.Key = listAllowerPos(index).Key And position.Value = listAllowerPos(index).Value) Then
                    If (Not canMoveToPos(piece, position)) Then
                        Return False
                    End If
                    Dim p = createPiece(pieceNoire(piece Mod 100).type, pieceNoire(piece Mod 100).couleur, position)
                    If Not (tableDeJeu(position.Key, position.Value) = 0) Then
                        pieceBlancheMorte.Add(pieceBlanche(tableDeJeu(position.Key, position.Value) Mod 100))
                        pieceBlanche.RemoveAt(tableDeJeu(position.Key, position.Value) Mod 100)
                    End If
                    tableDeJeu(pieceNoire(piece Mod 100).position.Key, pieceNoire(piece Mod 100).position.Value) = 0
                    pieceNoire(piece Mod 100) = p
                    tableDeJeu(p.position.Key, p.position.Value) = piece
                    Turn = Jeu_Echec.Piece.Couleurs.Blanc
                    initPositions()
                    pieceNoire(piece Mod 100).FirstMove = True
                    Return True
                End If
            Next
            Return False
        Else
            Return False
        End If
    End Function

    Public Function moveToPosNoVerif(piece As Integer, position As KeyValuePair(Of Integer, Integer)) As Boolean
        Dim listAllowerPos As List(Of KeyValuePair(Of Integer, Integer))
        If (Math.Floor(piece / 100) = 1) Then
            'MsgBox(pieceBlanche(piece Mod 100).position.Key & " " & pieceBlanche(piece Mod 100).position.Value)
            listAllowerPos = moves(pieceBlanche(piece Mod 100))
            'MsgBox(pieceBlanche(piece Mod 100).position.Key & " " & pieceBlanche(piece Mod 100).position.Key)
            'MsgBox("listallowed: " & listAllowerPos.Count)
            For index = 0 To listAllowerPos.Count - 1
                If (position.Key = listAllowerPos(index).Key And position.Value = listAllowerPos(index).Value) Then
                    Dim p = createPiece(pieceBlanche(piece Mod 100).type, pieceBlanche(piece Mod 100).couleur, position)
                    If Not (tableDeJeu(position.Key, position.Value) = 0) Then
                        pieceNoireMorte.Add(pieceNoire(tableDeJeu(position.Key, position.Value) Mod 100))
                        pieceNoire.RemoveAt(tableDeJeu(position.Key, position.Value) Mod 100)
                    End If
                    pieceBlanche(piece Mod 100) = p
                    Turn = Jeu_Echec.Piece.Couleurs.Noir
                    Return True
                End If
            Next
            'MsgBox("false1")
            Return False
        ElseIf (Math.Floor(piece / 100) = 2) Then
            listAllowerPos = moves(pieceNoire(piece Mod 100))
            For index = 0 To listAllowerPos.Count - 1
                If (position.Key = listAllowerPos(index).Key And position.Value = listAllowerPos(index).Value) Then
                    Dim p = createPiece(pieceNoire(piece Mod 100).type, pieceNoire(piece Mod 100).couleur, position)
                    If Not (tableDeJeu(position.Key, position.Value) = 0) Then
                        pieceBlancheMorte.Add(pieceBlanche(tableDeJeu(position.Key, position.Value) Mod 100))
                        pieceBlanche.RemoveAt(tableDeJeu(position.Key, position.Value) Mod 100)
                    End If
                    pieceNoire(piece Mod 100) = p
                    Turn = Jeu_Echec.Piece.Couleurs.Blanc
                    Return True
                End If
            Next

            'MsgBox("false2")
            Return False
        Else

            'MsgBox("false3")
            Return False
        End If
    End Function

    Public Function echecMat(color As Piece.Couleurs) As Boolean
        If (Not echec(color)) Then
            Return False
        Else
            If (color = Piece.Couleurs.Blanc) Then
                For i = 0 To pieceBlanche.Count - 1
                    If (canMove(100 + i)) Then
                        'MsgBox("not echec")
                        'MsgBox(pieceBlanche(i).position.Key & pieceBlanche(i).position.Value)
                        Return False
                    End If
                Next
            Else
                For i = 0 To pieceNoire.Count - 1
                    If (canMove(200 + i)) Then
                        'MsgBox("not echec")
                        'MsgBox(pieceNoire(i).position.Key & pieceNoire(i).position.Value)
                        Return False
                    End If
                Next
            End If
        End If
        Return True
    End Function
End Class
