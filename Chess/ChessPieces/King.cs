using System;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.ChessPieces;

public class King : ChessPiece
{
    public King(PieceColor color, Texture2D texture, Position position) : base(color, texture, position) { }

    public override bool CanMoveTo(Position target)
    {
        int deltaX = Math.Abs(Position.X - target.X);
        int deltaY = Math.Abs(Position.Y - target.Y);

        return deltaX <= 1 && deltaY <= 1;
    }
    
    public Position[] GetPossibleMoves()
    {
        const int minX = 0;
        const int maxX = 7;
        const int minY = 0;
        const int maxY = 7;

        Position[] possibleMoves = new Position[8];
        int index = 0;
        
        for (int deltaX = -1; deltaX <= 1; deltaX++)
        {
            for (int deltaY = -1; deltaY <= 1; deltaY++)
            {
                Position newPosition = new Position(Position.X + deltaX, Position.Y + deltaY);
                
                bool outOfBoundsX = newPosition.X is < minX or > maxX;
                bool outOfBoundsY = newPosition.Y is < minY or > maxY;
                bool outOfBounds = outOfBoundsX || outOfBoundsY;
                bool samePosition = deltaX == 0 && deltaY == 0;
                
                if (outOfBounds || samePosition) continue;
                possibleMoves[index++] = newPosition;
            }
        }

        return possibleMoves;
    }
}