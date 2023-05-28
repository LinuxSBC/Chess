using System;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.ChessPieces;

public class Queen : ChessPiece
{
    public Queen(PieceColor color, Texture2D texture, Position position) : base(color, texture, position) { }

    public override bool CanMoveTo(Position target)
    {
        int deltaX = Math.Abs(Position.X - target.X);
        int deltaY = Math.Abs(Position.Y - target.Y);
        bool movingDiagonally = deltaX == deltaY;
        bool movingHorizontal = Position.Y == target.Y;
        bool movingVertical = Position.X == target.X;
        bool movingStraight = movingVertical || movingHorizontal;
        
        return movingDiagonally || movingStraight;
    }
}