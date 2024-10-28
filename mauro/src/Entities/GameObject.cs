namespace Mauro.Entities;

using Mauro.Utils;

public abstract class GameObject
{
    public Vector2 Position { get; set; }
    public Vector2 Scale { get; set; }
    public char Character {get; protected set;}
    public string Color { get; protected set; }

    public int IntX => (int)Position.X;
    public int IntY => (int)Position.Y;
    public int IntWidth => (int)Scale.X;
    public int IntHeight => (int)Scale.Y;
    public GameObject(Vector2 pos, Vector2 sca)
    {
        Position = pos;
        Scale = sca;
        Color = Ansi.Reset;
    }

    public void Render(char[,] screen)
    {
        for (int x = IntX; x < IntX + IntWidth; x++)
        {
            for (int y = IntY; y < IntY + IntHeight; y++)
            {
                // Checa os limites da tela pra não tentar acessar caracteres fora da tela.
                if (x >= 0 && x < screen.GetLength(0) && y >= 0 && y < screen.GetLength(1))
                {
                    screen[x, y] = Character;
                }
            }
        }  
    }

    public abstract void Update(double deltaTime);
}