namespace Mauro.Entities;

using Mauro.Interfaces;
using Mauro.Utils;

class Wall: GameObject, ICollidable
{
    public Wall(Vector2 pos,Vector2 sca): base(pos,sca) 
    {
        Character = '█';
        Color = Ansi.FYellow;
    }

    /// <summary>
    /// As paredes são imóveis, então elas não precisam de <c>Update()</c>.
    /// </summary>
    public override void Update() {}

    public bool CheckCollision(ICollidable other)
    {
        return Position.X < other.Position.X + other.Scale.X && Position.X + Scale.X > other.Position.X &&
           Position.Y < other.Position.Y + other.Scale.Y && Position.Y + Scale.Y > other.Position.Y;
    }

    /// <summary>
    /// As paredes não precisam lidar com a colisão.
    /// </summary>
    public void HandleCollision(ICollidable other) {}
}