namespace Life.Entities;

using Utils;

public abstract class GameObject
{
    public Vector2 Position { get; set; }
    public char Character {get; protected set;}
    public string Color { get; protected set; }

    public int X => Position.X;
    public int Y => Position.Y;
    public GameObject(Vector2 pos)
    {
        Position = pos;
        Color = Ansi.Reset;
    }

    public void Render(char[,] screen, string[,] colors)
    {
        // Checa os limites da tela pra não tentar acessar caracteres fora da tela.
        if (X >= 0 && X < screen.GetLength(0) && Y >= 0 && Y < screen.GetLength(1))
        {
            screen[X, Y] = Character;
            colors[X, Y] = Color;
        }
    }

    public abstract void Update();
}