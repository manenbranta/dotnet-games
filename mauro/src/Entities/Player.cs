namespace Mauro.Entities;

using Mauro.Interfaces;

class Player: GameObject, IPhysics
{
    public double VelocityX { get; set; }
    public double VelocityY { get; set; }
    
    private int previousX = 0;
    private int previousY = 0;
    
    bool onGround = false;
    public Player(int X,int Y): base(X,Y,1,1) 
    {
        Character = '■';
        Color = Ansi.FRed;
    }

    public override void Update()
    {
        previousX = X;
        previousY = Y;

        UpdatePhysics();

        if (Console.KeyAvailable)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D:
                    X++;
                    break;
                case ConsoleKey.A:
                    X--;
                    break;
                case ConsoleKey.S:
                    Y++;
                    break;
                case ConsoleKey.W:
                    Y--;
                    break;
            }
        }

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
        switch (other)
        {
            case Wall wall: {
                if (previousX + Width <= wall.X && X + Width > wall.X)
                {
                    X = wall.X - Width;
                    VelocityX = 0;
                }
                else if (previousX >= wall.X + wall.Width && X < wall.X + wall.Width)
                {
                    X = wall.X + wall.Width;
                    VelocityX = 0;
                }
                
                if (previousY + Height <= wall.Y && Y + Height > wall.Y)
                {
                    Y = wall.Y - Height;
                    VelocityY = 0;
                    onGround = true;
                }
                else if (previousY >= wall.Y + wall.Height && Y < wall.Y + wall.Height)
                {
                    Y = wall.Y + wall.Height;
                    VelocityY = 0;
                }

                break;
            }
            default:
                break;
        }
    }

    public void ApplyForce(double forceX, double forceY)
    {
        VelocityX += forceX;
        VelocityY += forceY;
    }

    public void UpdatePhysics()
    {
        X += (int)VelocityX;
        Y += (int)VelocityY;
    }
}