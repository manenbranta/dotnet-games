using System.Text;
using Mauro.Entities;

public class Game
{
    private List<GameObject> _objects = new List<GameObject>();

    private static readonly Game _instance = new Game();

    public bool ColorRendering = true;

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
        char[,] screen = new char[screenWidth, screenHeight];

        // String que representa o frame atual.
        StringBuilder sb = new StringBuilder(screenWidth*screenHeight);

        for (int x = 0; x < screenWidth; x++)
        {
            for (int y = 0; y < screenHeight; y++)
            {
                screen[x, y] = ' ';
            }
        }

        foreach (var obj in _objects)
        {
            obj.Render(screen);
        }

        for (int y = 0; y < screenHeight; y++)
        {
            for (int x = 0; x < screenWidth; x++)
            {
                var obj = _objects.FirstOrDefault(o => o.X <= x && o.X + o.Width > x && o.Y <= y && o.Y + o.Height > y);
                if (obj != null && ColorRendering)
                {
                    sb.Append(obj.Color);
                    sb.Append(screen[x, y]);
                    sb.Append("\u001b[0m");
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