using Mauro.Entities;

public class Game
{
    private List<GameObject> _objects = new List<GameObject>();

    private static readonly Game _instance = new Game();

    private Game() {}

    public static Game Instance
    {
        get
        {
            return _instance;
        }
    }

    public void AddObject(GameObject obj)
    {
        _objects.Add(obj);
    }

    public void RemoveObject(GameObject obj)
    {
        _objects.Remove(obj);
    }

    public IEnumerable<GameObject> GetObjects()
    {
        return _objects;
    }

    public void Update()
    {
        foreach (var obj in _objects)
        {
            obj.Update();
        }
    }
}