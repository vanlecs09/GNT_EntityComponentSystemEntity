using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BuffHealthSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<BuffHealthComponent, StatComponent, HealthComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var buffHealth = entity.Modify<BuffHealthComponent>();
            // var stat = entity.GetComponent<StatComponent>();
            var health = entity.GetComponent<HealthComponent>();
            health.current += buffHealth.value;
            entity.RemoveComponent<BuffHealthComponent>();
        }
    }
}