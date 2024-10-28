namespace Mauro.Entities;

using Mauro.Interfaces;
using Mauro.Utils;

class Player: GameObject, IPhysics
{
    public Vector2 Acceleration { get; set; }
    public Vector2 Velocity { get; set; }
    
    private Vector2 previousPos = new Vector2();
    
    bool onGround = false;

    static double GRAVITY = 0.001;
    static double MAX_Y_VELOCITY = 3;

    public Player(Vector2 pos): base(pos,Vector2.One) 
    {
        Character = '■';
        Color = Ansi.FRed;
    }

    public override void Update(double dt)
    {
        previousPos = Position;

        UpdatePhysics(dt);

        if (Console.KeyAvailable)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D:
                    Position += Vector2.Right;
                    break;
                case ConsoleKey.A:
                    Position += Vector2.Left;
                    break;
                case ConsoleKey.S:
                    Position += Vector2.Down;
                    break;
                case ConsoleKey.W:
                    Position += Vector2.Up;
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
        return Position.X < other.Position.X + other.Scale.X && Position.X + Scale.X > other.Position.X &&
           Position.Y < other.Position.Y + other.Scale.Y && Position.Y + Scale.Y > other.Position.Y;
    }

    public void HandleCollision(ICollidable other)
    {
        switch (other)
        {
            case Wall wall: {
                if (previousPos.X + Scale.X <= wall.Position.X && Position.X + Scale.X > wall.Position.X)
                {
                    Position = new Vector2(wall.Position.X - Scale.X, Position.Y);
                    Velocity = new Vector2(0,Velocity.Y);
                }
                else if (previousPos.X >= wall.Position.X + wall.Scale.X && Position.X < wall.Position.X + wall.Scale.X)
                {
                    Position = new Vector2(wall.Position.X + wall.Scale.X, Position.Y);
                    Velocity = new Vector2(0,Velocity.Y);
                }
                
                if (previousPos.Y + Scale.Y <= wall.Position.Y && Position.Y + Scale.Y > wall.Position.Y)
                {
                    Position = new Vector2(Position.X, wall.Position.Y - Scale.Y);
                    Velocity = new Vector2(Velocity.X,0);
                    onGround = true;
                }
                else if (previousPos.Y >= wall.Position.Y + wall.Scale.Y && Position.Y < wall.Position.Y + wall.Scale.Y)
                {
                    Position = new Vector2(Position.X, wall.Position.Y + Scale.Y);
                    Velocity = new Vector2(Velocity.X,0);
                }

                break;
            }
            default:
                break;
        }
    }

    public void ApplyForce(Vector2 force)
    {
        Velocity += force;
    }

    public void UpdatePhysics(double dt)
    {
        Acceleration = new Vector2(Acceleration.X,GRAVITY);
        Velocity += Acceleration*dt;
        Position += Velocity*dt;

        if (Velocity.Y > MAX_Y_VELOCITY)
        {
            Velocity = new Vector2(Velocity.X, MAX_Y_VELOCITY);
        }
    }
}