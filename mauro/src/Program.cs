using Mauro.Entities;

namespace Mauro;

class Program
{
    static bool gameIsRunning = true;

    static void Main()
    {
        Player plr = new Player(1,1);

        Game.Instance.AddObject(plr);
        while (gameIsRunning)
        {
            Game.Instance.Update();
        }
    }
}