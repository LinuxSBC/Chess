using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess;

public class ChessPiece
{
    public enum PieceType
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King
    }

    public enum PieceColor
    {
        White,
        Black
    }
    
    public Boolean BeingDragged { get; set; }
    
    public Vector2 Position { get; set; }
    
    public PieceType Type { get; set; }
    public PieceColor Color { get;}
    public bool HasMoved { get; set; } // Used for pawns and castling
    public Texture2D Texture { get; set; }


    public ChessPiece(PieceType type, PieceColor color, Texture2D texture, Vector2 position)
    {
        Type = type;
        Color = color;
        Texture = texture;
        Position = position;
        HasMoved = false;
        BeingDragged = false;
    }

    public bool CanMoveTo(Vector2 position)
    {
        var newX = (int) position.X;
        var newY = (int) position.Y;
        var x = (int) Position.X;
        var y = (int) Position.Y;
        var deltaX = Math.Abs(newX - x);
        var deltaY = Math.Abs(newY - y);

        if (Type == PieceType.Rook)
        {
            if ((int) position.X == (int) Position.X || 
                (int) position.Y == (int) Position.Y)
                return true;
        }
        else if (Type == PieceType.Knight)
        {
            if (deltaX + deltaY == 3 && deltaY >= 1 && deltaX >= 1)
                return true;
        }
        else if (Type == PieceType.Bishop)
        {
            if (deltaX == deltaY)
                return true;
        }
        else if (Type == PieceType.Queen)
        {
            if ((int) position.X == (int) Position.X || 
                (int) position.Y == (int) Position.Y || 
                deltaX == deltaY)
                return true;
        }
        else if (Type == PieceType.King)
        {
            if (deltaX <= 1 && deltaY <= 1)
                return true;
        }
        else if (Type == PieceType.Pawn)
        {
            if (Color == PieceColor.White)
            {
                if (deltaX == 0 && deltaY == 1 && newY < y)
                    return true;
                if (deltaX == 1 && deltaY == 1 && newY < y)
                    return true;
                if (deltaX == 0 && deltaY == 2 && newY < y && !HasMoved)
                    return true;
            }
            else
            {
                if (deltaX == 0 && deltaY == 1 && newY > y)
                    return true;
                if (deltaX == 1 && deltaY == 1 && newY > y)
                    return true;
                if (deltaX == 0 && deltaY == 2 && newY > y && !HasMoved)
                    return true;
            }
        }
        return false;
    }

    public override string ToString()
    {
        return Color + " " + Type;
    }
}