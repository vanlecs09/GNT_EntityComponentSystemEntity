using Entitas;
using UnityEngine;
using RPG.View;
public class MovementSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, MoveComponent>().GetEntities();
        foreach (var e in entities)
        {
            if(e.Has<FrozenComponent>()) continue;
            var trans = e.Modify<TransformComponent>();
            var move = e.Modify<MoveComponent>();
            move.velocity = move.direction.normalized * move.speed;
            trans.position += move.velocity * Time.smoothDeltaTime;
            if(e.HasComponent<DirectionComponent>() == true && (move.direction.sqrMagnitude != 0))
            {
                e.Modify<DirectionComponent>().value =  move.direction;
            }
        }
    }
}