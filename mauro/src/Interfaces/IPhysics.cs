namespace Mauro.Interfaces;

public interface IPhysics: ICollidable
{
    double VelocityX { get; set; }
    double VelocityY { get; set; }

    void ApplyForce(double forceX, double forceY);

    void UpdatePhysics(/*double dt*/);
}