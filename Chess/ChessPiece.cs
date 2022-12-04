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
    
    public bool[] PossibleMoves { get; }

    public PieceType Type { get; set; }
    public PieceColor Color { get;}
    public bool HasMoved { get; set; } // Used for pawns and castling
    public Texture2D Texture { get; }


    public ChessPiece(PieceType type, PieceColor color, Texture2D texture, Vector2 position)
    {
        Type = type;
        Color = color;
        Texture = texture;
        Position = position;
        PossibleMoves = new bool[64];
        HasMoved = false;
        BeingDragged = false;
    }

    public override string ToString()
    {
        return Color + " " + Type;
    }
}