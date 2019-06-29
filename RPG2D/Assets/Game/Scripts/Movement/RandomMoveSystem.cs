using Entitas;
using UnityEngine;
using RPG.View;
public class RandomMoveSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, RandomMoveComponent>().GetEntities();
        foreach (var e in entities)
        {
            if(e.HasComponent<FrozenComponent>()) continue;
            var trans = e.Modify<TransformComponent>();
            var move = e.Get<RandomMoveComponent>();
            move.velocity = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
            trans.position += move.velocity.normalized * 1 * Time.smoothDeltaTime;
        }
    }
}