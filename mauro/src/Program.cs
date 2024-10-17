using Mauro.Entities;

namespace Mauro;

class Program
{
    static bool gameIsRunning = true;
    static (int Width, int Height) screen = (80,25);

    static void Main()
    {
        Player plr = new Player(1,1);
        Wall wall = new Wall(1,2,25,5);

        Init([plr, wall]);

        while (gameIsRunning)
        {
            Game.Instance.Update();
            Game.Instance.Render(screen.Width,screen.Height);
        }
    }

    static void Init(GameObject[] obj)
    {
        Console.Clear();
        Console.CursorVisible = false;

        Console.SetWindowSize(screen.Width, screen.Height);

        if (OperatingSystem.IsWindows())
        {
            /*
            * No Windows, o BufferSize pode ser maior que o WindowSize, 
            * o que faz uma scrollbar horizontal aparecer. Fazer isso previne esse bug.
            */
            Console.SetBufferSize(screen.Width, screen.Height);
        }

        // O jogo deve usar UTF8, pois usa caracteres fora do set ASCII
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        foreach (var o in obj)
        {
            Game.Instance.AddObject(o);
        }
    }
}