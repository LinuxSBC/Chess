using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.ChessPieces;

public class Bishop : ChessPiece
{
    public Bishop(PieceColor color, Texture2D texture, Position position) : base(color, texture, position) { }

    public override bool CanMoveTo(Position target)
    {
        if (OutOfBounds(target)) return false;
        int deltaX = Math.Abs(Position.X - target.X);
        int deltaY = Math.Abs(Position.Y - target.Y);
        bool movingDiagonally = deltaX == deltaY && deltaX != 0;

        return movingDiagonally;
    }

    public override List<Position> GetPossibleMoves()
    {
        List<Position> possibleMoves = new List<Position>();
        
        for (int x = MinX; x <= MaxX; x++)
        {
            Position move = new Position(x, x);
            if (CanMoveTo(move)) possibleMoves.Add(move);
        }
        
        return possibleMoves;
    }
}