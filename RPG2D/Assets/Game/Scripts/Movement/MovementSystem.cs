using Entitas;
using UnityEngine;
using RPG.View;
public class MovementSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, MoveComponent>().GetEntities();
        foreach (var entity in entities)
        {
            // if(entity.Has<FrozenComponent>()) continue;
            var trans = entity.Modify<TransformComponent>();
            var move = entity.Modify<MoveComponent>();
            move.speed = Mathf.Clamp(move.speed, 0.0f, move.maxSpeed);
            move.velocity = move.direction.normalized * move.speed;
            trans.position += move.velocity * Time.smoothDeltaTime;
            if(entity.HasComponent<DirectionComponent>() == true && (move.direction.sqrMagnitude != 0))
            {
                entity.Modify<DirectionComponent>().value =  move.direction;
            }
        }
    }
}