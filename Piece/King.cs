namespace ChessGame.Piece.Entity
{
    using ChessGame.Logic.PositionGame;
    using ChessGame.Piece.PieceModel;
    using ChessGame.Table;

    public class King : Piece
    {
        public King(Board board, bool isWhite, Position position)
        : base (board, isWhite, position) {}

        public override bool[,] GetPositionsToMove()
        {
            return new bool[1,1];
        }
    }
}
