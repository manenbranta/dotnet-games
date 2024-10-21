namespace Mauro.Interfaces;

/// <summary>
/// Essa é uma interface que representa todas as coisas no jogo que tem colisão.
/// </summary>
public interface ICollidable
{
    int X { get; }
    int Y { get; }
    int Width { get; }
    int Height { get; }
    bool CheckCollision(ICollidable other);
    void HandleCollision(ICollidable other);
}