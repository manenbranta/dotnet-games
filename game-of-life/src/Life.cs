namespace Life;

using Entities;
using Utils;

class Life
{
    Cell[,] cells;
    Cell[,] nextCells;

    public int Rows { get {return cells.GetLength(0);} }
    public int Cols { get {return cells.GetLength(1);} }

    public Life(int rows, int cols)
    {
        cells = new Cell[rows,cols];
        nextCells = new Cell[rows,cols];

        Init();
    }

    public void Init()
    {
        for (int row=0; row<Rows; row++)
        {
            for (int col=0; col<Cols; col++)
            {
                cells[row, col] = new Cell(new Vector2(row, col));
                nextCells[row, col] = new Cell(new Vector2(row, col));

                Game.Instance.AddObject(cells[row, col]);
            }
        }

        cells[1, 2].Alive = true;
        cells[2, 3].Alive = true;
        cells[3, 1].Alive = true;
        cells[3, 2].Alive = true;
        cells[3, 3].Alive = true;
    }

    public void Update()
    {
        for (int row=0; row < Rows; row++)
        {
            for (int col=0; col < Cols; col++)
            {
                int liveNeighbors = CountLiveNeighbors(row, col);
                bool isAlive = cells[row, col].Alive;

                if (isAlive)
                    nextCells[row, col].Alive = liveNeighbors == 2 || liveNeighbors == 3;
                else
                    nextCells[row, col].Alive = liveNeighbors == 3;
            }
        }

        Cell[,] temp = cells;
        cells = nextCells;
        nextCells = temp;
    }

    int CountLiveNeighbors(int row, int col)
    {
        int liveNeighbors = 0;

        for (int x=-1; x <= 1; x++)
        {
            for (int y=-1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;

                int neighborRow = row + x;
                int neighborCol = col + y;

                // Apply wrapping only at borders
                if (neighborRow < 0) neighborRow = Rows - 1;
                else if (neighborRow >= Rows) neighborRow = 0;

                if (neighborCol < 0) neighborCol = Cols - 1;
                else if (neighborCol >= Cols) neighborCol = 0;

                if (cells[neighborRow, neighborCol].Alive)
                {
                    liveNeighbors++;
                }
            }
        }

        return liveNeighbors;
    }
}