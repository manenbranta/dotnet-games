using Mauro.Entities;

namespace Mauro;

class Program
{
    static bool gameIsRunning = true;
    static (int Width, int Height) screen = (80,25);

    static string[] args;

    static void Main(string[] Args)
    {
        Player plr = new Player(0,1);
        Wall wall = new Wall(0,2,25,5);
        Wall wall2 = new Wall(25,0,3,2);

        args = Args;

        Init(new GameObject[] {plr, wall, wall2});

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

            /*
            * No Windows, as escape sequences ANSI não são ativadas por padrão,
            * então é preciso manualmente ativá-las para poder usar elas. Elas foram
            * escolhidas no lugar da classe `System.ConsoleColor` por ser mais simples
            * de renderizar e estarem disponíveis em todas as maiores plataformas
            * (Linux, MacOS, e Windows, caso ativado)
            */
            Windows.WindowsConsoleConfigurer config = new Windows.WindowsConsoleConfigurer();
            config.SetupConsole();
        }

        // O jogo deve usar UTF8, pois usa caracteres fora do set ASCII
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        foreach (string str in args)
        {
            if (str == "-nc" || str == "--no-color")
            {
                Game.Instance.ColorRendering = false;
            }
        }

        // O framerate em que a simulação do jogo roda
        //Game.Instance.DeltaTime = 60;
        
        foreach (var o in obj)
        {
            Game.Instance.AddObject(o);
        }
    }
}