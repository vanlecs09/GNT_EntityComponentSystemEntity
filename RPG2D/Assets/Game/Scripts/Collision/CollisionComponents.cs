using Entitas;
using System.Collections.Generic;

[Input]
public class CollisionInputComponent: IComponent
{
    public Entity from;
    public Entity to;

    public void Initialize(Entity from_, Entity to_)
    {
        from = from_;
        to = to_;
    }
}

[Game]
public class ImmunityCollision: IComponent
{

}

[Input]
public class CollisionExitInputComponent: IComponent
{
    public Entity from;
    public Entity to;

    public void Initialize(Entity from_, Entity to_)
    {
        from = from_;
        to = to_;
    }
}

[Game]

public class CollisionEnterComponent: IComponent
{
    public List<Entity> listColliEntity;
    public void Initialize()
    {
        listColliEntity = new List<Entity>();
    }
}

[Game]
public class CollisionTriggerComponent: IComponent
{
    public List<int> a;
    public void Initialize()
    {
        a = new List<int>();
    }
}
