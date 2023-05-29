using System;
using Microsoft.Xna.Framework;

namespace Chess;

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public Position(Vector2 vector)
    {
        X = (int) vector.X;
        Y = (int) vector.Y;
    }
    
    public Position Copy()
    {
        return new Position(X, Y);
    }

    public override string ToString()
    {
        return X + ", " + Y;
    }

    public Vector2 ToVector2()
    {
        return new Vector2(X, Y);
    }

    private bool Equals(Position other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Position) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}