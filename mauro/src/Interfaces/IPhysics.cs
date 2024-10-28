using Mauro.Utils;

namespace Mauro.Interfaces;

public interface IPhysics: ICollidable
{
    Vector2 Acceleration { get; }
    Vector2 Velocity { get; }

    void ApplyForce(Vector2 force);

    void UpdatePhysics(double dt);
}