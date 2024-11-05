namespace Life.Entities;

using Utils;

public class Cell: GameObject
{
    public bool Alive { get; set; }
    public bool IsCursor { get; set; } = false;

    public Cell(Vector2 pos): base(pos)
    {
        Alive = false;
    }

    public override void Update() 
    {
        if (IsCursor)
        {
            Character = Alive ? '▓' : '+';
            Color = Ansi.FGreen;
        }
        else
        {
            Character = Alive ? '█' : ' ';
            Color = Alive ? Ansi.FWhite : Ansi.Reset;
        }
    }
}