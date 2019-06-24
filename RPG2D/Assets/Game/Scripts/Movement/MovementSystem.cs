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
            var trans = e.Modify<TransformComponent>();
            var move = e.Get<MoveComponent>();
            trans.position += move.velocity.normalized * 5 * Time.smoothDeltaTime;
            // trans.position = Vector3.Lerp(trans.position, trans.position + move.velocity.normalized * 5 * Time.deltaTime, 5 * Time.deltaTime);
        }
    }
}