using Entitas;
using RPG.View;
using System.Collections.Generic;
public class AreaExplodeSystem : ReactiveSystem
{
    public AreaExplodeSystem()
    {
        monitors += Context<Skill>.AllOf<DamageComponent, ExplodeComponent, RadiusRangeComponent, PositionComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        UnityEngine.Debug.Log("Area explode system");
        var botEntities = Context<Game>.AllOf<BotComponent, TransformComponent>().GetEntities();
        foreach (var skillEntity in entities)
        {
            var skillPos = skillEntity.GetComponent<PositionComponent>().value;
            var damage = skillEntity.GetComponent<DamageComponent>();
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
                    GameContext.CreateDamangeEntity(targets, damage.damage);
                }
            }
            skillEntity.Destroy();
        }
    }
}