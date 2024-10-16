namespace Mauro.Entities;

public abstract class GameObject
{
    public int X { get; protected set; }
    public int Y { get; protected set; }
    public int Width { get; protected set; }
    public int Height { get; protected set; }

    public GameObject(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public abstract void Update();
}