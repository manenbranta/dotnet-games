namespace Imeri.Components.Interfaces;

using Imeri.Entities;

public interface IComponent
{
    void Update();
}

public interface ICollidable: IComponent
{
    void OnCollision(Object other);
}