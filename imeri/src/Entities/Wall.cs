namespace Imeri.Entities;

class Wall: Object
{
    public Wall(uint x, uint y): base(x,y,1,1) {}

    public override string ToString()
    {
        return $"█:{X}:{Y}";
    }
}