using Entitas;
using UnityEngine;
using RPG.View;
public class MovementSystem : IExecuteSystem
{
    public void Execute()
    {
        var deltaTime = Time.deltaTime;
        var entities = Context<Game>.AllOf<TransformComponent, MoveComponent, DirectionComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var trans = entity.Modify<TransformComponent>();
            var move = entity.Modify<MoveComponent>();
            move.speed = Mathf.Clamp(move.speed, 0.0f, move.maxSpeed);
            move.velocity = move.direction.normalized * move.speed + move.acceleration * deltaTime;
            Vector3.ClampMagnitude(move.velocity, move.speed);
            trans.position += move.velocity * deltaTime;
        }
    }
}