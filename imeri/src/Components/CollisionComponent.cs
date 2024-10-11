using Imeri.Components.Interfaces;
using Imeri.Entities;

namespace Imeri.Components;

public class CollisionComponent: IComponent
{
    private readonly Entity _entity;

    public CollisionComponent(Entity e)
    {
        _entity = e;
    }

    public void Update()
    {
        throw new NotImplementedException();
        /*Entity other = GetCollidedEntity();

        if (_entity.IsColliding(other) && _entity is ICollidable)
        {

        }*/
    }

    private void GetCollidedEntity()
    {
        throw new NotImplementedException();
    }
}