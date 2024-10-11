namespace Imeri.Entities;

using Components.Interfaces;

public abstract class Entity: Object
{
    private readonly List<IComponent> _components = new List<IComponent>();
    public Entity(int x, int y,int width, int height): base(x,y,width,height) {}

    public void AddComponent(IComponent component)
    {
        _components.Add(component);
    }

    public void RemoveComponent(IComponent component)
    {
        _components.Remove(component);
    }

    public void Update()
    {
        foreach (var component in _components)
        {
            component.Update();
        }
    }

    public abstract void OnCollision(Object other);
}