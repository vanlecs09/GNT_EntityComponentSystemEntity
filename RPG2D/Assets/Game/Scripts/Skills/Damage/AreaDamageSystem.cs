using Entitas;
using RPG.View;
using System.Collections.Generic;
public class AreaDamageSystem : ReactiveSystem
{
    public AreaDamageSystem()
    {
        monitors += Context<Skill>.AllOf<AreaDamageComponent, PositionComponent>().OnAdded(OnEnter);
    }

    protected void OnEnter(List<Entity> entities)
    {
        var botEntities = Context<Game>.AllOf<BotComponent, TransformComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var skillPos = entity.GetComponent<PositionComponent>().value;
            var areaDamage = entity.GetComponent<AreaDamageComponent>();
            foreach (var botEntity in botEntities)
            {
                var botPos = botEntity.Get<TransformComponent>().position;
                if ((botPos - skillPos).sqrMagnitude < areaDamage.radius * areaDamage.radius)
                {
                    SkillContext.CreateDamangeEntity(botEntity, areaDamage.damage);
                }
            }
            entity.Destroy();
        }
    }
}