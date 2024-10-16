namespace Mauro.Entities;

using Mauro.Entities.Interfaces;

class Player: GameObject, ICollidable
{
    public Player(int X,int Y): base(X,Y,1,1) {}

    public override void Update()
    {
        foreach (var obj in Game.Instance.GetObjects())
        {
            if (obj is ICollidable collidable && collidable != this)
            {
                if (CheckCollision(collidable))
                {
                    HandleCollision(collidable);
                }
            }
        }
    }

    public bool CheckCollision(ICollidable other)
    {
        return X < other.X + other.Width && X + Width > other.X &&
           Y < other.Y + other.Height && Y + Height > other.Y;
    }

    public void HandleCollision(ICollidable other)
    {
        Console.WriteLine("Player colidiu com algo!");
    }
}