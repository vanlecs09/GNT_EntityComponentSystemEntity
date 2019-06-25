using Entitas;
using RPG.View;
using System.Collections.Generic;
using UnityEngine;
public class TriggerAreaExplodeSystem : ReactiveSystem
{
    public TriggerAreaExplodeSystem()
    {
        monitors += Context<Game>.AllOf<TriggerComponent, DamageComponent, InRadiusRangeComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        Debug.Log("TriggerAreaExplodeSystem react");
        var botEntities = Context<Game>.AllOf<BotComponent, TransformComponent>().GetEntities();
        foreach (var skillEntity in entities)
        {
            var skillPos = skillEntity.GetComponent<TransformComponent>().position;
            var skillFireBomb = skillEntity.GetComponent<TriggerComponent>();
            var damage = skillEntity.GetComponent<DamageComponent>();
            var radius = skillEntity.GetComponent<InRadiusRangeComponent>().radius;
            foreach (var botEntity in botEntities)
            {
                var botPos = botEntity.Get<TransformComponent>().position;
                if ((botPos - skillPos).sqrMagnitude < radius * radius)
                {
                    if (!damage.listEntityTarget.Contains(botEntity))
                        damage.listEntityTarget.Add(botEntity);
                }

            }
            skillEntity.Destroy();
        }
    }
}