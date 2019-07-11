using Entitas;
using UnityEngine;
using RPG.View;
public class AreaSlowMoveProcessingSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<RadiusRangeComponent, SlowDownMoveComponent>().GetEntities();
        var botEntities = Context<Game>.AllOf<BotComponent>();
        foreach (var entity in entities)
        {
            // Debug.Log("AreaSlowMoveProcessingSystem process");
            // var owner = entity.GetComponent<OwnerComponent>().value;
            var radius = entity.GetComponent<RadiusRangeComponent>().radius;
            // var direction = owner.GetComponent<DirectionComponent>().value;
            var pos = entity.GetComponent<TransformComponent>().position;
            var slowDown = entity.GetComponent<SlowDownMoveComponent>();
            foreach (var botEntity in botEntities)
            {
                var botPos = botEntity.GetComponent<TransformComponent>().position;
                var botMove = botEntity.GetComponent<MoveComponent>();
                if ((botPos - pos).sqrMagnitude < radius * radius)
                {
                    if (botEntity.HasComponent<BeSlowDownMoveComponent>())
                    {
                    }
                    else
                    {
                        botEntity.AddComponent<BeSlowDownMoveComponent>().Initialize(4.0f, 1.0f);
                    }
                }
                else
                {
                    if (botEntity.HasComponent<BeSlowDownMoveComponent>())
                    {
                        botEntity.RemoveComponent<BeSlowDownMoveComponent>();
                        botEntity.AddComponent<BeExTraSlowDownMoveComponent>().Initialize(2.0f);
                    }
                }
            }
        }
    }
}