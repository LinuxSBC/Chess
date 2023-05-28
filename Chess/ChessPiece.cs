using System;
using Microsoft.Xna.Framework.Graphics;

namespace Chess;

public abstract class ChessPiece
{
    public enum PieceColor
    {
        White,
        Black
    }

    public bool BeingDragged { get; set; }
    public Position Position { get; set; }
    public PieceColor Color { get; }
    public bool HasMoved { get; set; } // Used for pawns and castling
    public Texture2D Texture { get; set; }


    protected ChessPiece(PieceColor color, Texture2D texture, Position position)
    {
        Color = color;
        Texture = texture;
        Position = position;
        HasMoved = false;
        BeingDragged = false;
    }

    public abstract bool CanMoveTo(Position target);

    public override string ToString() // TODO: See if this works
    {
        String pieceType = GetType().Name;
        return Color + " " + pieceType + " at " + Position;
    }
}