namespace Imeri.Entities;

public abstract class Entity: Object
{
    public bool IsColliding(Object other)
    {
        return X < other.X + other.Width &&
               X + Width > other.X &&
               Y < other.Y + other.Height &&
               Y + Height > other.Y;
    }

    public abstract void Update();

    public abstract void OnCollision(Object other);
}