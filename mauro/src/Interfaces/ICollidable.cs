namespace Mauro.Interfaces;

using Mauro.Utils;

/// <summary>
/// Essa é uma interface que representa todas as coisas no jogo que tem colisão.
/// </summary>
public interface ICollidable
{
    Vector2 Position { get; set; }
    Vector2 Scale { get; set; }
    bool CheckCollision(ICollidable other);
    void HandleCollision(ICollidable other);
}