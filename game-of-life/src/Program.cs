namespace Life;

class Program
{
    static bool gameIsRunning = true;
    public static (int Width, int Height) screen = (80,25);

    static string[] args = {};

    const int SLEEP_TIME = 60;

    static void Main(string[] Args)
    {
        args = Args;

        Init();

        Life life = new Life(screen.Width,screen.Height);

        while (gameIsRunning)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        life.MoveCursor(-1,0);
                        break;
                    case ConsoleKey.RightArrow:
                        life.MoveCursor(1,0);
                        break;
                    case ConsoleKey.UpArrow:
                        life.MoveCursor(0,-1);
                        break;
                    case ConsoleKey.DownArrow:
                        life.MoveCursor(0,1);
                        break;
                    case ConsoleKey.Spacebar:
                        life.ToggleCell();
                        break;
                    case ConsoleKey.P:
                        life.Paused = !life.Paused;
                        break;
                }
            }
            if (!life.Paused)
                life.Update();
            Game.Instance.Update();
            Game.Instance.Render(screen.Width,screen.Height);

            Thread.Sleep(SLEEP_TIME);
        }
    }

    static void Init()
    {
        Console.Clear();
        Console.CursorVisible = false;

        if (OperatingSystem.IsWindows())
        {
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
    }
}