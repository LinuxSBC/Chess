using System;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.ChessPieces;

public class Bishop : ChessPiece
{
    public Bishop(PieceColor color, Texture2D texture, Position position) : base(color, texture, position) { }

    public override bool CanMoveTo(Position target)
    {
        int deltaX = Math.Abs(Position.X - target.X);
        int deltaY = Math.Abs(Position.Y - target.Y);
        bool movingDiagonally = deltaX == deltaY;

        return movingDiagonally;
    }
}