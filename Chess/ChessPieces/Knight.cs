using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.ChessPieces;

public class Knight : ChessPiece
{
    public Knight(PieceColor color, Texture2D texture, Position position) : base(color, texture, position) { }

    public override bool CanMoveTo(Position target)
    {
        if (OutOfBounds(target)) return false;
        int deltaX = Math.Abs(Position.X - target.X);
        int deltaY = Math.Abs(Position.Y - target.Y);
        int totalDistance = deltaX + deltaY;
        bool correctDistance = totalDistance == 3;
        bool correctShape = deltaX >= 1 && deltaY >= 1;

        return correctDistance && correctShape;
    }

    public override List<Position> GetPossibleMoves()
    {
        List<Position> possibleMoves = new List<Position>();
        for (int deltaX = -2; deltaX <= 2; deltaX++)
        {
            for (int deltaY = -2; deltaY <= 2; deltaY++)
            {
                Position newPosition = new Position(Position.X + deltaX, Position.Y + deltaY);
                
                if (CanMoveTo(newPosition)) possibleMoves.Add(newPosition);
            }
        }

        return possibleMoves;
    }
}