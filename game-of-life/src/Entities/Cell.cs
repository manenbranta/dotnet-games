using Mauro.Utils;

namespace Mauro.Entities;

public class Cell: GameObject
{
    public State State = State.DEAD;
    public readonly List<Cell> neighbors = new List<Cell>();
    public Cell(Vector2 pos): base(pos) {}

    public override void Update() 
    {
        Step();
        Character = State == State.ALIVE ? '■' : ' ';
    }

    public int GetLiveNeighbors() 
    {
        int lNeighbors = neighbors.Where(c => c.State == State.ALIVE).Count();
        return lNeighbors;
    }

    public void Step()
    {
        int liveNeighbors = GetLiveNeighbors();

        if (State == State.ALIVE)
            State = liveNeighbors == 2 || liveNeighbors == 3 ? State.ALIVE : State.DEAD;
        else 
            State = liveNeighbors == 3 ? State.ALIVE : State.DEAD;
    }
}

public enum State
{
    DEAD = 0,
    ALIVE = 1
}