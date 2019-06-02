using Entitas;

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
public class CollisionComponent: IComponent
{
    
}