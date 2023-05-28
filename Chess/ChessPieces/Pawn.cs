using System;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.ChessPieces;

public class Pawn : ChessPiece
{
    public Pawn(PieceColor color, Texture2D texture, Position position) : base(color, texture, position) { }

    public override bool CanMoveTo(Position target)
    {
        int deltaX = Math.Abs(Position.X - target.X);
        int deltaY = Math.Abs(Position.Y - target.Y);

        bool movingForward;
        if (Color == PieceColor.White)
            movingForward = target.Y < Position.Y;
        else
            movingForward = target.Y > Position.Y;
        
        bool movingStraight = deltaX == 0 && deltaY == 1;
        bool movingDiagonally = deltaX == 1 && deltaY == 1;
        bool movingTwoSquares = deltaX == 0 && deltaY == 2 && !HasMoved;

        return movingForward && (movingStraight || movingDiagonally || movingTwoSquares);
    }
}