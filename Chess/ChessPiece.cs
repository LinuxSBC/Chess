using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Chess;

public abstract class ChessPiece
{
    protected const int MinX = 0;
    protected const int MaxX = 7;
    protected const int MinY = 0;
    protected const int MaxY = 7;

    public enum PieceColor
    {
        White,
        Black
    }

    public bool BeingDragged { get; set; }
    public Position Position { get; set; }
    public PieceColor Color { get; }
    public bool HasMoved { get; set; } // Used for pawns and castling
    public Texture2D Texture { get; }


    protected ChessPiece(PieceColor color, Texture2D texture, Position position)
    {
        Color = color;
        Texture = texture;
        Position = position;
        HasMoved = false;
        BeingDragged = false;
    }

    public abstract bool CanMoveTo(Position target);

    public abstract List<Position> GetPossibleMoves();
    
    protected static bool OutOfBounds(Position position)
    {
        return position.X is < MinX or > MaxX || 
               position.Y is < MinY or > MaxY;
    }

    public override string ToString() // TODO: See if this works
    {
        String pieceType = GetType().Name;
        return Color + " " + pieceType + " at " + Position;
    }
}