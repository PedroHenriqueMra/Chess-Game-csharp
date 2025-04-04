using ChessGame.Table;

namespace ChessGame.Piece.Entity
{
    using System.Dynamic;
    using System.Reflection.Metadata;
    using ChessGame.Logic.PositionGame;
    using ChessGame.Piece.PieceModel;
    using ChessGame.Game.main;
    using System.Security.Cryptography.X509Certificates;
    using System.Runtime.InteropServices;
    using System.Reflection.Metadata.Ecma335;

    public class Pawn : Piece
    {
        public bool InPassant { get; set; } = default;
        public Pawn(Board board, bool isWhite, Position position)
        : base(board, isWhite, position) { }

        // plus line = get down on the board
        // minus line = get up on the board
        public override bool[,] GetPositionsToMove()
        {
            var oneAhead = new Func<Position, Position>(pos => {
                Position newPosition = new Position(0,0);
                return IsWhite
                ? newPosition.ChangePosition(pos.Line -= 1, pos.Column)
                : newPosition.ChangePosition(pos.Line += 1, pos.Column);
            });

            var twoAhead = new Func<Position, Position>(pos => {
                Position newPosition = new Position(0,0);
                return IsWhite
                ? newPosition.ChangePosition(pos.Line -= 2, pos.Column)
                : newPosition.ChangePosition(pos.Line += 2, pos.Column);
            });

            var rightDiagonal = new Func<Position, Position>(pos => {
                Position newPosition = new Position(0,0);
                return IsWhite
                ? newPosition.ChangePosition(pos.Line -= 1, pos.Column += 1)
                : newPosition.ChangePosition(pos.Line += 1, pos.Column -= 1);
            });
            

            var leftDiagonal = new Func<Position, Position>(pos => {
                Position newPosition = new Position(0,0);
                return IsWhite
                ? newPosition.ChangePosition(pos.Line -= 1, pos.Column -= 1)
                : newPosition.ChangePosition(pos.Line += 1, pos.Column += 1);
            });
    
            
            bool[,] steps = new bool[Board.Lenght[0], Board.Lenght[1]];
            Position pos = new Position(0,0);

            // Positions to move piece
            pos = oneAhead(Position);
            if (Board.IsValidPosition(pos) && Board.GetPieceByPosition(pos) == null)
            {
                steps[pos.Line, pos.Column] = true;
            }
            if (Moves == 0)
            {
                pos = twoAhead(Position);
                if (Board.IsValidPosition(pos) && Board.GetPieceByPosition(pos) == null)
                {
                    steps[pos.Line, pos.Column] = true;
                }
            }

            // Positions to catch enemy piece to right
            pos = rightDiagonal(Position);
            if (Board.IsValidPosition(pos) && Board.GetPieceByPosition(pos) != null && Board.GetPieceByPosition(pos).IsWhite != IsWhite)
            {
                steps[pos.Line, pos.Column] = true;
            }
            // Position to catch enemy piece to left
            pos = leftDiagonal(Position);
            if (Board.IsValidPosition(pos) && Board.GetPieceByPosition(pos) != null! && Board.GetPieceByPosition(pos).IsWhite != IsWhite)
            {
                steps[pos.Line, pos.Column] = true;
            }

            // En passant to right
            pos = rightDiagonal(Position);
            Pawn? piece = Board.GetPieceByPosition(pos) as Pawn;
            if (piece != null && piece is Pawn && Board.IsValidPosition(pos) && piece.IsWhite != IsWhite)
            {
                if (piece.InPassant)
                {
                    steps[pos.Line, pos.Column] = true;
                }
            }

            // En passant to left
            pos = leftDiagonal(Position);
            piece = Board.GetPieceByPosition(pos) as Pawn;
            if (piece != null && piece is Pawn && Board.IsValidPosition(pos) && piece.IsWhite != IsWhite)
            {
                if (piece.InPassant)
                {
                    steps[pos.Line, pos.Column] = true;
                }
            }

            return steps;
        }

        public override string ToString()
        {
            if (this.IsWhite) return "P";

            return "p";
        }
    }
}
