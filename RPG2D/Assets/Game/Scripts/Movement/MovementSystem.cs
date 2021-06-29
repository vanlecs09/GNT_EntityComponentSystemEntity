using Entitas;
using UnityEngine;
using RPG.View;
public class MovementSystem : IExecuteSystem
{
    public void Execute()
    {
        var deltaTime = Time.deltaTime;
        var entities = Context<Game>.AllOf<TransformComponent, MoveComponent>().GetEntities();
        foreach (var entity in entities)
        {
            if (entity.Has<ForceMoveComponent>()) continue;
            var trans = entity.Modify<TransformComponent>();
            var move = entity.Modify<MoveComponent>();
            move.velocity = move.direction.normalized * move.speed;
            Vector3.ClampMagnitude(move.velocity, move.speed);
            trans.position += move.velocity * deltaTime;
        }
    }
}