namespace Mauro.Entities.Interfaces;

public interface ICollidable
{
    int X { get; }
    int Y { get; }
    int Width { get; }
    int Height { get; }
    bool CheckCollision(ICollidable other);
    void HandleCollision(ICollidable other);
}