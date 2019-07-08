using Entitas;
using UnityEngine;
using RPG.View;
public class ColdBreathProcessingSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<SkillWaterColdBreath, OwnerComponent, RadiusRangeComponent>().GetEntities();
        var botEntities = Context<Game>.AllOf<BotComponent>();
        foreach (var entity in entities)
        {
            var owner = entity.GetComponent<OwnerComponent>().value;
            var radius = entity.GetComponent<RadiusRangeComponent>().radius;
            var direction = owner.GetComponent<DirectionComponent>().value;
            var pos = entity.GetComponent<TransformComponent>().position;
            foreach (var botEntity in botEntities)
            {
                var botPos = botEntity.GetComponent<TransformComponent>().position;
                if ((botPos - pos).sqrMagnitude < radius * radius)
                {
                    if(botEntity.HasComponent<SlowDownMoveComponent>())
                    {
                        botEntity.RemoveComponent<SlowDownMoveComponent>();
                        
                    }
                    else
                    {
                        botEntity.AddComponent<SlowDownMoveComponent>().Initialize(2.0f);
                    }
                }   
                else
                {
                    if(botEntity.HasComponent<SlowDownMoveComponent>())
                    {
                        botEntity.RemoveComponent<SlowDownMoveComponent>();
                    }
                }
            }
        }
    }
}