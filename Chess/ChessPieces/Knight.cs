using System;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.ChessPieces;

public class Knight : ChessPiece
{
    public Knight(PieceColor color, Texture2D texture, Position position) : base(color, texture, position) { }

    public override bool CanMoveTo(Position target)
    {
        int deltaX = Math.Abs(Position.X - target.X);
        int deltaY = Math.Abs(Position.Y - target.Y);
        int totalDistance = deltaX + deltaY;
        bool correctDistance = totalDistance == 3;
        bool correctShape = deltaX >= 1 && deltaY >= 1;

        return correctDistance && correctShape;
    }
}