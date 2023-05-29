using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.ChessPieces;

public class Rook : ChessPiece
{
    public Rook(PieceColor color, Texture2D texture, Position position) : base(color, texture, position) { }

    public override bool CanMoveTo(Position target)
    {
        if (OutOfBounds(target)) return false;
        bool movingHorizontal = Position.Y == target.Y;
        bool movingVertical = Position.X == target.X;
        bool movingStraight = movingVertical != movingHorizontal;

        return movingStraight;
    }

    public override List<Position> GetPossibleMoves()
    {
        List<Position> possibleMoves = new List<Position>();
        
        for (int x = MinX; x <= MaxX; x++)
        {
            if (x == Position.X) continue;
            Position move = new Position(x, Position.Y);
            bool moving = !move.Equals(Position);
            if (moving) possibleMoves.Add(move);
        }
        
        for (int y = MinY; y <= MaxY; y++)
        {
            if (y == Position.Y) continue;
            Position move = new Position(Position.X, y);
            bool moving = !move.Equals(Position);
            if (moving) possibleMoves.Add(move);
        }

        return possibleMoves;
    }
}