using Entitas;
using UnityEngine;
using RPG.View;
public class SlowDownMoveSystem: IExecuteSystem
{
    void IExecuteSystem.Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, SlowDownMoveComponent, MoveComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var slowDown = entity.GetComponent<SlowDownMoveComponent>();
            var move = entity.GetComponent<MoveComponent>();
            slowDown.currentTime += Time.deltaTime;
            move.speed = move.maxSpeed - slowDown.currentTime / slowDown.limitTime * move.maxSpeed;
        }
    }
}