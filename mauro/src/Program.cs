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

        Game.Instance.AddObject(plr);
        while (gameIsRunning)
        {
            Game.Instance.Update();
            Game.Instance.Render(screen.Width,screen.Height);
        }
    }
}