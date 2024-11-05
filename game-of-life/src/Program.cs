namespace Life;

using System;

class Program
{
    static bool gameIsRunning = true;
    public static (int Width, int Height) screen = (80,25);

    static string[] args = {};

    const int SLEEP_TIME = 60;

    static string[] patterns =
    {
        #region PATTERNS
        // Blinker
        "███",
        // Toad
        "  █ " + "\n" +
        "█  █" + "\n" +
        "█  █" + "\n" +
        " █  ",
        // Beacon
        "██  " + "\n" +
        "██  " + "\n" +
        "  ██" + "\n" +
        "  ██"
        #endregion
    };

    static void Main(string[] Args)
    {
        args = Args;

        Init();

        Life life = new Life(screen.Width,screen.Height);
        Dictionary<string, Action<string[]>> commands = new Dictionary<string, Action<string[]>>()
        {
            {"clear", (string[] args) => {life.Clear();}},
            {"glider", (string[] args) => {life.AddFromString(patterns[0]);}}
        };

        while (gameIsRunning)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        life.MoveCursor(-1,0);
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        life.MoveCursor(1,0);
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        life.MoveCursor(0,-1);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        life.MoveCursor(0,1);
                        break;
                    case ConsoleKey.C:
                        life.Clear();
                        break;
                    case ConsoleKey.R:
                        life.Randomize(new Random().NextDouble());
                        break;
                    case ConsoleKey.Spacebar:
                        life.ToggleCell();
                        break;
                    case ConsoleKey.P:
                    case ConsoleKey.E:
                    case ConsoleKey.Enter:
                        if (life.Paused)
                            life.Unpause();
                        else
                            life.Pause();
                        break;
                    case ConsoleKey.Q:
                        gameIsRunning = false;
                        break;
                }
            }
            if (!life.Paused)
                life.Update();
            Game.Instance.Update();
            Game.Instance.Render(screen.Width,screen.Height);

            clearLine(screen.Height+1);
            Console.SetCursorPosition(0,screen.Height+1);
            if (!life.Paused)
                Console.WriteLine($"{Ansi.FGreen}Press E to enter edit mode{Ansi.Reset}");
            else 
                Console.WriteLine($"Press R to get a random grid // Press C to clear the grid // Press SPACE to toggle a cell // Use the arrow keys to move // Press Q to Quit");

            Thread.Sleep(SLEEP_TIME);
        }
        Console.Clear();
    }

    static void Init()
    {
        Console.Clear();
        Console.CursorVisible = false;

        Console.CancelKeyPress += (sender, e) =>
        {
            gameIsRunning = false;
            Console.Clear();
            e.Cancel = true; 
        };

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
    }

    static void clearLine(int y)
    {
        Console.SetCursorPosition(0,y);
        Console.Write(new string(' ', Console.BufferWidth));
    }
}