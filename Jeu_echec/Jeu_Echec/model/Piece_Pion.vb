Public Class Piece_Pion
    Inherits Piece
    Sub New(ByVal couleur As Couleurs, ByVal position As KeyValuePair(Of Integer, Integer))
        MyBase.New(Piece.TypesPiece.Pion, couleur, position)
        Array.Resize(Of KeyValuePair(Of Integer, Integer))(move, 1)
        If (MyBase.couleur = Piece.Couleurs.Blanc) Then
            move(0) = New KeyValuePair(Of Integer, Integer)(1, 0)
        Else
            move(0) = New KeyValuePair(Of Integer, Integer)(-1, 0)
        End If


        MyBase.Iteration = False
        MyBase.FirstMove = False
    End Sub
End Class
