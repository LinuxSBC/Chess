using Microsoft.Xna.Framework.Graphics;

namespace Chess.ChessPieces;

public class Rook : ChessPiece
{
    public Rook(PieceColor color, Texture2D texture, Position position) : base(color, texture, position) { }

    public override bool CanMoveTo(Position target)
    {
        bool movingHorizontal = Position.Y == target.Y;
        bool movingVertical = Position.X == target.X;
        bool movingStraight = movingVertical || movingHorizontal;

        return movingStraight;
    }
}