Public Class Piece
    Implements ICloneable

    Public Enum Couleurs
        Blanc
        Noir
    End Enum
    Public Enum TypesPiece
        Fou
        Chevalier
        Dame
        Roi
        Tour
        Pion
        Vide
    End Enum

    Public Property couleur As Couleurs
    Public Property type As TypesPiece
    Public Property imagePiece As Image
    Public move(8) As KeyValuePair(Of Integer, Integer)
    Public Property Iteration As Boolean = False
    Public Property FirstMove As Boolean = False
    Public Property position As KeyValuePair(Of Integer, Integer)
    Public Property dataDirectory As String = "..\\..\\Img\\Piece\\"
    Sub New(ByVal type As TypesPiece, ByVal couleur As Couleurs, ByVal position As KeyValuePair(Of Integer, Integer))
        Dim CouleurCase As Couleurs = getCouleurCase(position)
        Me.position = position
        Me.type = type
        Me.couleur = couleur
        If (type = TypesPiece.Vide) Then
            imagePiece = Image.FromFile(dataDirectory & type.ToString & "_" & CouleurCase.ToString & ".png")
        Else
            imagePiece = Image.FromFile(dataDirectory & type.ToString & "_" & couleur.ToString & "_" & CouleurCase.ToString & ".png")
        End If
    End Sub

    Public Function moves() As List(Of KeyValuePair(Of Integer, Integer))
        Dim retour As New List(Of KeyValuePair(Of Integer, Integer))
        If (Not Iteration) Then
            For index = 0 To move.Length - 1

                If (move(index).Key + position.Key <= 8 And move(index).Value + position.Value <= 8 _
                    And move(index).Key + position.Key > 0 And move(index).Value + position.Value > 0) Then
                    'MsgBox("move: " & move(index).Key + position.Key & " " & move(index).Value + position.Value)
                    retour.Add(New KeyValuePair(Of Integer, Integer)(move(index).Key + position.Key, move(index).Value + position.Value))
                End If
            Next
        Else
            For index = 0 To move.Length - 1
                If (move(index).Key + position.Key <= 8 And move(index).Value + position.Value <= 8 _
                    And move(index).Key + position.Key > 0 And move(index).Value + position.Value > 0) Then
                    Dim i As Integer = 0
                    While move(index).Key + position.Key + i <= 8 And move(index).Value + position.Value + i <= 8 _
                        And move(index).Key + position.Key + i > 0 And move(index).Value + position.Value + i > 0

                        retour.Add(New KeyValuePair(Of Integer, Integer)(move(index).Key + i + position.Key, move(index).Value + position.Value + i))
                        i = i + 1
                    End While
                End If
            Next
        End If
        'MsgBox("size moves: " & retour.Count)
        Return retour
    End Function

    Public Function getCouleurCase(ByVal position As KeyValuePair(Of Integer, Integer)) As Couleurs
        If position.Key Mod 2 = 1 Then
            If position.Value Mod 2 = 1 Then
                Return Couleurs.Noir
            Else
                Return Couleurs.Blanc
            End If
        Else
            If position.Value Mod 2 = 0 Then
                Return Couleurs.Noir
            Else
                Return Couleurs.Blanc
            End If
        End If
    End Function

    Public Sub switchToGreen()
        imagePiece = Image.FromFile(dataDirectory & "Selected\\" & type.ToString & "_" & couleur.ToString & "_" & getCouleurCase(position).ToString & "_True.png")
    End Sub

    Public Sub switchToRed()
        imagePiece = Image.FromFile(dataDirectory & "Selected\\" & type.ToString & "_" & couleur.ToString & "_" & getCouleurCase(position).ToString & "_False.png")
    End Sub

    Public Sub switchToNeutral()
        imagePiece = Image.FromFile(dataDirectory & type.ToString & "_" & couleur.ToString & "_" & getCouleurCase(position).ToString & ".png")
    End Sub

    Public Function Clone() As Object Implements ICloneable.Clone
        Dim retour As Piece
        If (Me.GetType = GetType(Piece_Chevalier)) Then
            retour = New Piece_Chevalier(couleur, New KeyValuePair(Of Integer, Integer)(position.Key, position.Value))
        ElseIf (Me.GetType = GetType(Piece_Dame)) Then
            retour = New Piece_Dame(couleur, New KeyValuePair(Of Integer, Integer)(position.Key, position.Value))
        ElseIf (Me.GetType = GetType(Piece_Fou)) Then
            retour = New Piece_Fou(couleur, New KeyValuePair(Of Integer, Integer)(position.Key, position.Value))
        ElseIf (Me.GetType = GetType(Piece_Pion)) Then
            retour = New Piece_Pion(couleur, New KeyValuePair(Of Integer, Integer)(position.Key, position.Value))
        ElseIf (Me.GetType = GetType(Piece_Roi)) Then
            retour = New Piece_Roi(couleur, New KeyValuePair(Of Integer, Integer)(position.Key, position.Value))
        ElseIf (Me.GetType = GetType(Piece_Tour)) Then
            retour = New Piece_Tour(couleur, New KeyValuePair(Of Integer, Integer)(position.Key, position.Value))
        Else
            retour = New Piece(type, couleur, New KeyValuePair(Of Integer, Integer)(position.Key, position.Value))

        End If
        'Dim retour As New Piece(type, couleur, New KeyValuePair(Of Integer, Integer)(position.Key, position.Value))
        retour.couleur = Me.couleur
        retour.dataDirectory = Me.dataDirectory
        retour.type = Me.type
        retour.imagePiece = Me.imagePiece
        For index = 0 To move.Length - 1
            retour.move(index) = New KeyValuePair(Of Integer, Integer)(move(index).Key, move(index).Value)
        Next
        retour.Iteration = Me.Iteration
        retour.FirstMove = Me.FirstMove
        retour.position = New KeyValuePair(Of Integer, Integer)(Me.position.Key, Me.position.Value)
        Return retour
    End Function
End Class
