using Entitas;
using UnityEngine;
using RPG.View;
public class RandomMoveSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, MoveComponent, RandomMoveComponent>().GetEntities();
        foreach (var e in entities)
        {
            var trans = e.Modify<TransformComponent>();
            var move = e.Get<MoveComponent>();
            var randomMove = e.GetComponent<RandomMoveComponent>();
            var cooldown = randomMove.coolDown;

            cooldown.currentTime += Time.deltaTime;
            if (cooldown.currentTime >= cooldown.time)
            {
                cooldown.currentTime = 0;
                move.direction = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
            }
        }
    }
}