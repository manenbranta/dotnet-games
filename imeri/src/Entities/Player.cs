namespace Imeri.Entities;

public class Player: Entity
{
    public Player(uint startX, uint startY) : base(startX,startY,1,1) {}

    public override void Update()
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return $"□:{X}:{Y}";
    }
}