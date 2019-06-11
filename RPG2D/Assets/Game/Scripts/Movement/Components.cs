using Entitas;
using UnityEngine;

[Game]
public class MoveComponent : IComponent
{
    public Vector3 velocity;
    public Vector3 acceleration;

    public void Initialize(Vector3 velocity_, Vector3 acceleration_)
    {
        this.velocity = velocity_;
        this.acceleration = acceleration_;
    }
}

public class MoveAroundTarget: IComponent
{
    
}