Public Class Piece_Chevalier
    Inherits Piece
    Sub New(ByVal couleur As Couleurs, ByVal position As KeyValuePair(Of Integer, Integer))
        MyBase.New(Piece.TypesPiece.Chevalier, couleur, position)
        Array.Resize(Of KeyValuePair(Of Integer, Integer))(move, 8)
        move(0) = New KeyValuePair(Of Integer, Integer)(2, 1)
        move(1) = New KeyValuePair(Of Integer, Integer)(2, -1)
        move(2) = New KeyValuePair(Of Integer, Integer)(-2, 1)
        move(3) = New KeyValuePair(Of Integer, Integer)(-2, -1)
        move(4) = New KeyValuePair(Of Integer, Integer)(1, 2)
        move(5) = New KeyValuePair(Of Integer, Integer)(1, -2)
        move(6) = New KeyValuePair(Of Integer, Integer)(-1, 2)
        move(7) = New KeyValuePair(Of Integer, Integer)(-1, -2)

        MyBase.Iteration = False
        MyBase.FirstMove = False
    End Sub
End Class
