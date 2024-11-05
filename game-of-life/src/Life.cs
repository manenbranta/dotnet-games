namespace Life;

using Entities;
using Utils;

class Life
{
    Cell[,] cells;
    Cell[,] nextCells;

    public int Rows { get {return cells.GetLength(0);} }
    public int Cols { get {return cells.GetLength(1);} }

    public bool Paused { get; set; }

    public int cursorRow, cursorCol;

    public Life(int rows, int cols)
    {
        cells = new Cell[rows,cols];
        nextCells = new Cell[rows,cols];

        Init();
        Paused = true;
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

        cells[cursorRow, cursorCol].IsCursor = true;

        cells[1, 2].Alive = true;
        cells[2, 3].Alive = true;
        cells[3, 1].Alive = true;
        cells[3, 2].Alive = true;
        cells[3, 3].Alive = true;
    }

    public void Update()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
                int liveNeighbors = CountLiveNeighbors(row, col);
                bool isAlive = cells[row, col].Alive;

                nextCells[row, col].Alive = isAlive ? (liveNeighbors == 2 || liveNeighbors == 3) : (liveNeighbors == 3);
            }
        }

        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
                cells[row, col].Alive = nextCells[row, col].Alive;
            }
        }
    }

    public void MoveCursor(int dRow, int dCol)
    {
        if (Paused)
        {
            cells[cursorRow, cursorCol].IsCursor = false;

            cursorCol = (cursorCol + dCol + Cols) % Cols;
            cursorRow = (cursorRow + dRow + Rows) % Rows;

            cells[cursorRow, cursorCol].IsCursor = true;
        }
    }

    public void ToggleCell()
    {
        if (Paused)
        {
            cells[cursorRow,cursorCol].Alive = !cells[cursorRow,cursorCol].Alive;
        }
    }

    public void AddFromString(string str)
    {
        string[] lines = str.Split(new[] { '\n' }, StringSplitOptions.None);

        for (int line = 0; line<lines.Length; line++)
        {
            string sub = lines[line];

            for (int i=0; i<sub.Length; i++)
            {
                int wrap = (cursorCol+i) % Cols;

                cells[cursorRow, wrap].Alive = sub[i] == '█';
            }
        }
    }

    public void Pause()
    {
        Paused = true;

        cells[cursorRow, cursorCol].IsCursor = true;
    }

    public void Unpause()
    {
        Paused = false;

        cells[cursorRow, cursorCol].IsCursor = false;
    }

    Random rng = new Random();
    public void Randomize(double density)
    {   
        if (Paused)
        {
            foreach (var c in cells)
            {
                c.Alive = rng.NextDouble() < density;
            }
        }
    }

    public void Clear()
    {   
        if (Paused)
        {
            foreach (var c in cells)
            {
                c.Alive = false;
            }
        }
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