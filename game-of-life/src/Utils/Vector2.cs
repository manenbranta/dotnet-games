namespace Mauro.Utils;

public struct Vector2
{
    public int X { get; }
    public int Y { get; }

    public static Vector2 Left { get => new Vector2(-1,0); }
    public static Vector2 Right { get => new Vector2(1,0); }
    public static Vector2 Up { get => new Vector2(0,-1); }
    public static Vector2 Down { get => new Vector2(0,1); }
    public static Vector2 One { get => new Vector2(1,1); }

    public Vector2(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
    }

    public static Vector2 operator+ (Vector2 a, Vector2 b)
    {
        return new Vector2(a.X + b.X, a.Y + b.Y);
    }

    public static Vector2 operator- (Vector2 a)
    {
        return new Vector2(-a.X,-a.Y);
    }

    public static Vector2 operator- (Vector2 a, Vector2 b)
    {
        return new Vector2(a.X - b.X, a.Y - b.Y);
    }

    public static Vector2 operator* (Vector2 vec, int scalar)
    {
        return new Vector2(vec.X * scalar, vec.Y * scalar);
    }

    public static Vector2 operator/ (Vector2 vec, int divisor)
    {
        return new Vector2(vec.X / divisor, vec.Y / divisor);
    }
    
    public Vector2 Dot(Vector2 other)
    {
        return new Vector2(X * other.X, Y * other.Y);
    }

    public static Vector2 Dot(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X * b.X, a.Y * b.Y);
    }

    public int Distance(Vector2 other)
    {
        return (int)Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
    }

    public static int Distance(Vector2 a, Vector2 b)
    {
        return (int)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }
}