using Imeri.Entities;

namespace Imeri;

class Program
{
    public static Game Game = new();
    static bool gameIsRunning = true;

    static void Main()
    {
        Player plr = new Player(0,0);

        Game.AddEntity(plr);
        while (gameIsRunning)
        {
            Game.Update();
        }
    }
}