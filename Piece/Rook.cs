namespace ChessGame.Piece.Entity
{
    using ChessGame.Logic.PositionGame;
    using ChessGame.Piece.PieceModel;
    using ChessGame.Logic.Game;
    using ChessGame.Logic.Player.Color;

    public class Rook : Piece
    {
        public Rook(Game game, PlayerColor color, Position position)
        : base (game, color, position) {}

        public override bool[,] GetPositionsToMove()
        {
            bool[,] steps = new bool[Game.Board.NumColumn, Game.Board.NumLine];
            Position pos = new Position();

            // up steps
            pos.ChangePosition(this.Position.Column,this.Position.Line);
            for (int i = 0;i < 8;i++)
            {
                pos.Line--;
                if (Game.Board.IsValidPosition(pos))
                {
                    Piece? enemyPiece = Game.Board.GetPieceByPosition(pos);
                    if (enemyPiece == null)
                    {
                        steps[pos.Column, pos.Line] = true;
                        continue;
                    }

                    if (enemyPiece.Color != this.Color)
                    {
                        steps[pos.Column, pos.Line] = true;
                    }
                }

                break;
            }

            // bottom steps
            pos.ChangePosition(this.Position.Column,this.Position.Line);
            for (int i = 0;i < 8;i++)
            {
                pos.Line++;
                if (Game.Board.IsValidPosition(pos))
                {
                    Piece? enemyPiece = Game.Board.GetPieceByPosition(pos);
                    if (enemyPiece == null)
                    {
                        steps[pos.Column, pos.Line] = true;
                        continue;
                    }

                    if (enemyPiece.Color != this.Color)
                    {
                        steps[pos.Column, pos.Line] = true;
                    }
                }

                break;
            }

            // right steps
            pos.ChangePosition(this.Position.Column,this.Position.Line);
            for (int i = 0;i < 8;i++)
            {
                pos.Column++;
                if (Game.Board.IsValidPosition(pos))
                {
                    Piece? enemyPiece = Game.Board.GetPieceByPosition(pos);
                    if (enemyPiece == null)
                    {
                        steps[pos.Column, pos.Line] = true;
                        continue;
                    }

                    if (enemyPiece.Color != this.Color)
                    {
                        steps[pos.Column, pos.Line] = true;
                    }
                }

                break;
            }

            // left steps
            pos.ChangePosition(this.Position.Column,this.Position.Line);
            for (int i = 0;i < 8;i++)
            {
                pos.Column--;
                if (Game.Board.IsValidPosition(pos))
                {
                    Piece? enemyPiece = Game.Board.GetPieceByPosition(pos);
                    if (enemyPiece == null)
                    {
                        steps[pos.Column, pos.Line] = true;
                        continue;
                    }

                    if (enemyPiece.Color != this.Color)
                    {
                        steps[pos.Column, pos.Line] = true;
                    }
                }

                break;
            }

            return steps;
        }

        public override Piece Clone()
        {
            Rook clone = new Rook(
                Game = this.Game,
                Color = this.Color,
                Position = new Position(this.Position.Column, this.Position.Line)
            );
            clone.Movements = this.Movements;
            
            return clone;
        }

        public override string ToString()
        {
            if (this.Color == PlayerColor.White) return "R";

            return "r";
        }
    }
}
