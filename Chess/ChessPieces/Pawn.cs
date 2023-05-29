using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.ChessPieces;

public class Pawn : ChessPiece
{
    public Pawn(PieceColor color, Texture2D texture, Position position) : base(color, texture, position) { }

    public override bool CanMoveTo(Position target)
    {
        if (OutOfBounds(target)) return false;
        
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

    public override List<Position> GetPossibleMoves()
    {
        var possibleMoves = new List<Position>();
        int direction = Color == PieceColor.White ? 1 : -1;
        
        var oneForward = new Position(Position.X, Position.Y + direction);
        if (CanMoveTo(oneForward))
            possibleMoves.Add(oneForward);

        var twoForward = new Position(Position.X, Position.Y + 2 * direction);
        if (CanMoveTo(twoForward))
            possibleMoves.Add(twoForward);
        
        var leftDiagonal = new Position(Position.X - 1, Position.Y + direction);
        if (CanMoveTo(leftDiagonal))
            possibleMoves.Add(leftDiagonal);
        
        var rightDiagonal = new Position(Position.X + 1, Position.Y + direction);
        if (CanMoveTo(rightDiagonal))
            possibleMoves.Add(rightDiagonal);

        return possibleMoves;
    }
}