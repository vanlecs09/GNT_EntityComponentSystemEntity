using Entitas;
using UnityEngine;

public class BuffMovementSpeedSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<BuffMovementSpeedComponent, MoveComponent, HealthComponent, StatComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var buffSpeed = entity.Modify<BuffMovementSpeedComponent>();
            var move = entity.Modify<MoveComponent>();
            var stat = entity.GetComponent<StatComponent>();
            move.speed = stat.baseMoveSpeed * buffSpeed.speedModifierRate;
            var cooldown = buffSpeed.cooldown;
            cooldown.currentTime += Time.deltaTime;
            if (cooldown.currentTime >= cooldown.time)
            { 
                entity.RemoveComponent<BuffMovementSpeedComponent>();
                move.speed = stat.baseMoveSpeed;
            }
        }
    }
}