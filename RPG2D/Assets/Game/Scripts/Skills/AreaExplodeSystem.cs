using Entitas;
using RPG.View;
using System.Collections.Generic;
public class AreaExplodeSystem : ReactiveSystem
{
    public AreaExplodeSystem()
    {
        monitors += Context<Skill>.AllOf<DamageComponent, ExplodeComponent, RadiusRangeComponent, PositionComponent>().OnAdded(OnEnter);
    }

    protected void OnEnter(List<Entity> entities)
    {
        var botEntities = Context<Game>.AllOf<BotComponent, TransformComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var skillPos = entity.GetComponent<PositionComponent>().value;
            var damage = entity.GetComponent<DamageComponent>();
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
                SkillContext.CreateDamangeEntity(targets, damage.damage);
            }
            entity.Destroy();
        }
    }
}