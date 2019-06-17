using Entitas;
using RPG.View;
using System.Collections.Generic;
using UnityEngine;
public class SkillFireBombSystem : ReactiveSystem
{
    public SkillFireBombSystem()
    {
        monitors += Context<Game>.AnyOf<TriggerComponent, DamageComponent, InRadiusRangeComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        var botEntities = Context<Game>.AllOf<BotComponent, TransformComponent>().GetEntities();
        foreach (var skillEntity in entities)
        {
            if (!skillEntity.HasComponent<TriggerComponent>() || !skillEntity.HasComponent<DamageComponent>() || !skillEntity.HasComponent<InRadiusRangeComponent>())
            {

            }
            else if (skillEntity.HasComponent<TriggerComponent>() && skillEntity.GetComponent<TriggerComponent>().isTrigger == false)
            {

            }
            else
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
}