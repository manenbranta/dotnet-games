using Mauro.Utils;

namespace Mauro.Interfaces;

public interface IPhysics: ICollidable
{
    Vector2 Velocity { get; set; }

    void ApplyForce(Vector2 force);

    void UpdatePhysics(/*double dt*/);
}