using Entitas;
using UnityEngine;

public class MovementSystem : IExecuteSystem
{

    public MovementSystem()
    {
    }
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, MoveComponent>().GetEntities();
        foreach (var e in entities)
        {
            var trans = e.Get<TransformComponent>();
            var move = e.Modify<MoveComponent>();
            trans.position += move.velocity * Time.deltaTime;
            Debug.Log("position " + trans.position + " velocity " + move.velocity);
        }
    }
}