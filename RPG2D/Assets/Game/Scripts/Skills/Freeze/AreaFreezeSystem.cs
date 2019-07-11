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
        foreach (var entity in entities)
        {
            var skillPos = entity.GetComponent<TransformComponent>().position;
            var freeze = entity.GetComponent<FreezeComponent>();
            var radius = entity.GetComponent<RadiusRangeComponent>().radius;
            var targets = new List<Entity>();
            foreach (var botEntity in botEntities)
            {

                var botPos = botEntity.Get<TransformComponent>().position;
                if ((botPos - skillPos).sqrMagnitude < radius * radius)
                {
                    targets.Add(botEntity);
                }
            }
            if (targets.Count > 0)
            {
                SkillContext.CreateFreezeEntity(targets, freeze.timeFreeze);
            }
            entity.Destroy();
        }
    }
}