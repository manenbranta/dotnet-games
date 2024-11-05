using System.Text;
using Life.Entities;

public class Game
{
    private List<GameObject> _objects = new List<GameObject>();

    private static readonly Game _instance = new Game();

    public bool ColorRendering = true;

    char[,] screen;
    string[,] colors;

    private Game() {}

    public static Game Instance
    {
        get
        {
            return _instance;
        }
    }

    public void AddObject(GameObject obj)
    {
        _objects.Add(obj);
    }

    public void RemoveObject(GameObject obj)
    {
        _objects.Remove(obj);
    }

    public IEnumerable<GameObject> GetObjects()
    {
        return _objects;
    }

    public void Update()
    {
        foreach (var obj in _objects)
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

        foreach (var obj in _objects)
        {
            obj.Render(screen, colors);
        }

        for (int y = 0; y < screenHeight; y++)
        {
            for (int x = 0; x < screenWidth; x++)
            {
                if (ColorRendering)
                {
                    sb.Append(colors[x,y]);
                    sb.Append(screen[x, y]);
                    sb.Append(Ansi.Reset);
                }
                else
                {
                    sb.Append(screen[x, y]);
                }
            }
            sb.AppendLine();
        }

        Console.SetCursorPosition(0,0);
        Console.Write(sb.ToString());
    }
}