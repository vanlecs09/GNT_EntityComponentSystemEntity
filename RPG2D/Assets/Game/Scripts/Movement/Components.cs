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