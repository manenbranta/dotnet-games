namespace Mauro.Entities;

using Mauro.Interfaces;

class Wall: GameObject, ICollidable
{
    public Wall(int X,int Y,int Width,int Height): base(X,Y,Width,Height) 
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
        return X < other.X + other.Width && X + Width > other.X &&
           Y < other.Y + other.Height && Y + Height > other.Y;
    }

    /// <summary>
    /// As paredes não precisam lidar com a colisão.
    /// </summary>
    public void HandleCollision(ICollidable other) {}
}