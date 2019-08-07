using Entitas;
using UnityEngine;
public class ApplyForceSystem : IExecuteSystem
{
    public void Execute()
    {
        var deltaTime = Time.deltaTime;
        var entities = Context<Game>.AllOf<MoveComponent, ApplyForceComponent>().GetEntities();
        foreach(var entity in entities)
        {
            var force = entity.GetComponent<ApplyForceComponent>();
            var move = entity.GetComponent<MoveComponent>();
            move.acceleration = force.value;
        }
    }
}