namespace Life.Entities;

using Utils;

public class Cell: GameObject
{
    public bool Alive { get; set; }

    public Cell(Vector2 pos): base(pos)
    {
        Alive = false;
    }

    public override void Update() 
    {
        Character = Alive ? '█' : ' ';
    }
}