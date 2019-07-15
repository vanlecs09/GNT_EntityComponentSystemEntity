using Entitas;
using UnityEngine;
using RPG.View;
public class RandomMoveSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, MoveComponent, RandomComponent>().GetEntities();
        foreach (var e in entities)
        {
            var trans = e.Modify<TransformComponent>();
            var move = e.Get<MoveComponent>();
            move.direction = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
        }
    }
}