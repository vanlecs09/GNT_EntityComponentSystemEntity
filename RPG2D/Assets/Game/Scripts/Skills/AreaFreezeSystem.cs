using Entitas;
using System.Collections.Generic;
using RPG.View;
public class AreaFreezeSystem : ReactiveSystem
{
    public AreaFreezeSystem()
    {
        monitors += Context<Game>.AllOf<FreezeComponent, RadiusRangeComponent, TransformComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        var botEntities = Context<Game>.AllOf<BotComponent, TransformComponent>().GetEntities();
        foreach (var skillEntity in entities)
        {
            var skillPos = skillEntity.GetComponent<TransformComponent>().position;
            var freeze = skillEntity.GetComponent<FreezeComponent>();
            var radius = skillEntity.GetComponent<RadiusRangeComponent>().radius;
            foreach (var botEntity in botEntities)
            {
                var targets = new List<Entity>();
                var botPos = botEntity.Get<TransformComponent>().position;
                if ((botPos - skillPos).sqrMagnitude < radius * radius)
                {
                    targets.Add(botEntity);
                }
                if (targets.Count > 0)
                {
                    GameContext.CreateFreezeEntity(targets, freeze.timeFreeze);
                }
            }
            skillEntity.Destroy();
        }
    }
}