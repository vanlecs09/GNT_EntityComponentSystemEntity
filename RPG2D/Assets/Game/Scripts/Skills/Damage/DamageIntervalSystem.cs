using Entitas;
using UnityEngine;

public class DamageIntervalSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<IntervalDamageComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var damageInterval = entity.GetComponent<IntervalDamageComponent>();
            damageInterval.currentTime += Time.deltaTime;
            if (damageInterval.currentTime >= damageInterval.intervalTime)
            {
                damageInterval.currentTime = 0;
                damageInterval.affactedCount += 1;
                SkillContext.CreateDamangeEntity(entity, damageInterval.damage);
            }
        }
    }
}