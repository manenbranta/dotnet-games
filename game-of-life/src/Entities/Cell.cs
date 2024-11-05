namespace Life.Entities;

using Utils;

public class Cell: GameObject
{
    public bool Alive { get; set; }
    public bool NextAlive { get; set; } // Valor temporário pra calcular o próximo frame
    public bool IsCursor { get; set; } = false;
    public bool Paused { get; set; }

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