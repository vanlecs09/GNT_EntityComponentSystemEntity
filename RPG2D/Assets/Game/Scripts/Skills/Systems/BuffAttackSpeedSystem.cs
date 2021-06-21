using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BuffAttackSpeedSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<BuffAtackSpeedComponent, StatComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var buffAttackSpeed = entity.GetComponent<BuffAtackSpeedComponent>();
            var stat = entity.GetComponent<StatComponent>();
            if (entity.Has<ProjectileAttackComponent>())
            {
                entity.Get<ProjectileAttackComponent>().coolDown.time = stat.baseAttackSpeed / buffAttackSpeed.speedModifier;
            }

            if (entity.Has<MeleeAttackComponent>())
            {
                entity.Get<MeleeAttackComponent>().coolDown.time = stat.baseAttackSpeed / buffAttackSpeed.speedModifier;
            }

            var coolDown = buffAttackSpeed.cooldown;
            coolDown.currentTime += Time.deltaTime;
            if (coolDown.currentTime >= coolDown.time)
            {
                entity.RemoveComponent<BuffAtackSpeedComponent>();
                if (entity.Has<AttackComponent>())
                {
                    entity.Get<AttackComponent>().coolDown.time = stat.baseAttackSpeed;
                }
            }
        }
    }
}