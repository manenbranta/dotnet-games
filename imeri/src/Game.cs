using Imeri.Entities;

public class Game
{
    private List<Entity> _entities = new List<Entity>();

    public void AddEntity(Entity entity)
    {
        _entities.Add(entity);
    }

    public void RemoveEntity(Entity entity)
    {
        _entities.Remove(entity);
    }

    public IEnumerable<Entity> GetEntities()
    {
        return _entities;
    }

    public void Update()
    {
        foreach (var entity in _entities)
        {
            entity.Update(); // Call update on all entities
        }
    }
}