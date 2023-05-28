using System;
using Microsoft.Xna.Framework;

namespace Chess;

public class Position : IEquatable<Vector2>
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    private bool Equals(Position other)
    {
        return X == other.X && Y == other.Y;
    }

    public bool Equals(Vector2 other)
    {
        return X == (int) other.X && Y == (int) other.Y;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj is Vector2) return Equals((Vector2) obj);
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Position) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}