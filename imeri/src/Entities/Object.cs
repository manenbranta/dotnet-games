namespace Imeri.Entities;

public abstract class Object
{
    public int X { get; protected set; }
    public int Y { get; protected set; }
    public int Width { get; protected set; }
    public int Height { get; protected set; }

    public Object(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
}