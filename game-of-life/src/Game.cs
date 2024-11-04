using Mauro;
using System.Text;
using Mauro.Utils;
using Mauro.Entities;

public class Game
{
    public Cell[,] Cells;
    char[,] screen;
    string[,] colors;

    public int Columns { get { return Cells.GetLength(0); } }
    public int Rows { get { return Cells.GetLength(1); } }

    private static readonly Game _instance = new Game();

    public bool ColorRendering = true;

    private Game() 
    {
        Cells = new Cell[Program.screen.Width, Program.screen.Height];
        for (int x = 0; x < Columns; x++)
            for (int y = 0; y < Rows; y++)
                Cells[x, y] = new Cell(new Vector2(x,y));

        PopulateNeighbors();
        Randomize(.1);
    }

    public static Game Instance
    {
        get
        {
            return _instance;
        }
    }

    public IEnumerable<GameObject> GetObjects()
    {
        return Cells.Cast<GameObject>();
    }

    private void PopulateNeighbors()
    {
        for (int x = 0; x < Columns; x++)
        {
            for (int y = 0; y < Rows; y++)
            {
                int xL = (x > 0) ? x - 1 : Columns - 1;
                int xR = (x < Columns - 1) ? x + 1 : 0;

                int yT = (y > 0) ? y - 1 : Rows - 1;
                int yB = (y < Rows - 1) ? y + 1 : 0;

                Cells[x, y].neighbors.Add(Cells[xL, yT]);
                Cells[x, y].neighbors.Add(Cells[x, yT]);
                Cells[x, y].neighbors.Add(Cells[xR, yT]);
                Cells[x, y].neighbors.Add(Cells[xL, y]);
                Cells[x, y].neighbors.Add(Cells[xR, y]);
                Cells[x, y].neighbors.Add(Cells[xL, yB]);
                Cells[x, y].neighbors.Add(Cells[x, yB]);
                Cells[x, y].neighbors.Add(Cells[xR, yB]);
            }
        }
    }

    private Random rng = new Random();
    public void Randomize(double density)
    {
        foreach (var c in Cells)
            c.State = rng.NextDouble() < density ? State.ALIVE : State.DEAD;
    }

    public void Update()
    {
        foreach (var obj in Cells)
        {
            obj.Update();
        }
    }

    public void Render(int screenWidth, int screenHeight)
    {
        screen = new char[screenWidth, screenHeight];
        colors = new string[screenWidth, screenHeight];

        // String que representa o frame atual.
        StringBuilder sb = new StringBuilder(screenWidth*screenHeight);

        for (int x = 0; x < screenWidth; x++)
        {
            for (int y = 0; y < screenHeight; y++)
            {
                screen[x, y] = ' ';
                colors[x, y] = Ansi.Reset;
            }
        }

        foreach (var obj in Cells)
        {
            obj.Render(screen,colors);
        }

        for (int y = 0; y < screenHeight; y++)
        {
            for (int x = 0; x < screenWidth; x++)
            {
                sb.Append(colors[x, y]);
                sb.Append(screen[x, y]);
                sb.Append(Ansi.Reset);
            }
            sb.AppendLine();
        }

        Console.SetCursorPosition(0,0);
        Console.Write(sb.ToString());
    }
}