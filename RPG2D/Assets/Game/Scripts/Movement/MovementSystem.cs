using Entitas;
using UnityEngine;
using RPG.View;
using RPG.Rendering;
public class MovementSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, MoveComponent>().GetEntities();
        foreach (var e in entities)
        {
            if(e.Has<FrozenComponent>()) continue;
            var trans = e.Modify<TransformComponent>();
            var move = e.Get<MoveComponent>();
            trans.position += move.velocity.normalized * move.speed * Time.smoothDeltaTime;
        }
    }
}