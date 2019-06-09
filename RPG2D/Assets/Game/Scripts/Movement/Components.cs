using Entitas;
using UnityEngine;

[Game]
public class MoveComponent : IComponent
{
    public Vector3 velocity;
    public Vector3 acceleration;

    public void Initiazlize(Vector3 velocity_, Vector3 acceleration_)
    {
        this.velocity = velocity_;
        this.acceleration = acceleration_;
    }
}

[Game]
public class TransformComponent : IComponent
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    
     public void Initiazlize(Vector3 position_, Quaternion rotation_, Vector3 scale_)
    {
        this.position = position_;
        this.rotation = rotation_;
        this.scale = scale_;
    }
}
