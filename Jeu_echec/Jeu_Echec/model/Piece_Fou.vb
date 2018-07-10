Public Class Piece_Fou 'x
    Inherits Piece
    Sub New(ByVal couleur As Couleurs, ByVal position As KeyValuePair(Of Integer, Integer))
        MyBase.New(Piece.TypesPiece.Fou, couleur, position)
        Array.Resize(Of KeyValuePair(Of Integer, Integer))(move, 4)
        move(0) = New KeyValuePair(Of Integer, Integer)(1, 1)
        move(1) = New KeyValuePair(Of Integer, Integer)(1, -1)
        move(2) = New KeyValuePair(Of Integer, Integer)(-1, 1)
        move(3) = New KeyValuePair(Of Integer, Integer)(-1, -1)
        MyBase.Iteration = True
        MyBase.FirstMove = False
    End Sub


End Class
