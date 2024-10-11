namespace Imeri.Entities;

public abstract class Object
{
    public uint X { get; protected set; }
    public uint Y { get; protected set; }
    public uint Width { get; protected set; }
    public uint Height { get; protected set; }

    public Object(uint x, uint y, uint width, uint height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public abstract string ToString();
}