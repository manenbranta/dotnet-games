using Imeri.Entities;

namespace Imeri;

class Program
{
    Player plr = new Player(0,0);
    static List<Entity> Entities = new List<Entity> {
        plr
    };

    bool gameIsRunning = true;

    static void Main()
    {
        while (gameIsRunning)
        {
            foreach (Entity e in Entities)
            {
                e.Update();
            }
        }
    }
}