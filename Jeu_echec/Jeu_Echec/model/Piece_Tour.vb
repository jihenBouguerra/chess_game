Public Class Piece_Tour
    Inherits Piece
    Sub New(ByVal couleur As Couleurs, ByVal position As KeyValuePair(Of Integer, Integer))
        MyBase.New(TypesPiece.Tour, couleur, position)
        Array.Resize(Of KeyValuePair(Of Integer, Integer))(move, 4)
        move(0) = New KeyValuePair(Of Integer, Integer)(0, 1)
        move(1) = New KeyValuePair(Of Integer, Integer)(0, -1)
        move(2) = New KeyValuePair(Of Integer, Integer)(-1, 0)
        move(3) = New KeyValuePair(Of Integer, Integer)(1, 0)

        MyBase.Iteration = True
        MyBase.FirstMove = False
    End Sub
End Class
