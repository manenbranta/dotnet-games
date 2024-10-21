namespace Mauro.Entities;

public abstract class GameObject
{
    public int X { get; protected set; }
    public int Y { get; protected set; }
    public int Width { get; protected set; }
    public int Height { get; protected set; }
    public char Character {get; protected set;}
    public string Color { get; protected set; }

    public GameObject(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Color = Ansi.Reset;
    }

    public void Render(char[,] screen)
    {
        for (int x = X; x < X + Width; x++)
        {
            for (int y = Y; y < Y + Height; y++)
            {
                // Checa os limites da tela pra não tentar acessar caracteres fora da tela.
                if (x >= 0 && x < screen.GetLength(0) && y >= 0 && y < screen.GetLength(1))
                {
                    screen[x, y] = Character;
                }
            }
        }  
    }

    public abstract void Update();
}