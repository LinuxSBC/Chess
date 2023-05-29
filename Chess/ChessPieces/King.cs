using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.ChessPieces;

public class King : ChessPiece
{
    public King(PieceColor color, Texture2D texture, Position position) : base(color, texture, position) { }

    public override bool CanMoveTo(Position target)
    {
        if (OutOfBounds(target)) return false;
        int deltaX = Math.Abs(Position.X - target.X);
        int deltaY = Math.Abs(Position.Y - target.Y);
        if (deltaX == 0 && deltaY == 0) return false;

        return deltaX <= 1 && deltaY <= 1;
    }
    
    public override List<Position> GetPossibleMoves()
    {
        List<Position> possibleMoves = new List<Position>();
        for (int deltaX = -1; deltaX <= 1; deltaX++)
        {
            for (int deltaY = -1; deltaY <= 1; deltaY++)
            {
                Position newPosition = new Position(Position.X + deltaX, Position.Y + deltaY);
                
                if (CanMoveTo(newPosition)) possibleMoves.Add(newPosition);
            }
        }

        return possibleMoves;
    }
}