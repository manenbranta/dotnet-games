namespace Mauro.Entities;

using Mauro.Entities.Interfaces;

class Wall: GameObject, ICollidable
{
    public Wall(int X,int Y,int Width,int Height): base(X,Y,Width,Height) {}

    /**
    * As paredes são imóveis, então elas não precisam de Update().
    */
    public override void Update() {}

    public bool CheckCollision(ICollidable other)
    {
        return X < other.X + other.Width && X + Width > other.X &&
           Y < other.Y + other.Height && Y + Height > other.Y;
    }

    /**
    * As paredes não precisam lidar com a colisão.
    */
    public void HandleCollision(ICollidable other) {}
}