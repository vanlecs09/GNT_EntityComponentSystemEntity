using Entitas;
using RPG.View;
using System.Collections.Generic;
public class DamageWhenReachTargetSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TargetComponent, TransformComponent, DamageComponent>().GetEntities();
        var gameContext = Contexts.sharedInstance.GetContext<Game>();
        foreach(var entity in entities)
        {
            var pos = entity.GetComponent<TransformComponent>().position;
            var targetEntity = entity.GetComponent<TargetComponent>().targetEntity;
            if(gameContext.GetEntity(targetEntity.creationIndex) == null)
            {
                entity.AddComponent<DestroyComponent>();
                continue;
            }
            var damage = entity.GetComponent<DamageComponent>();
            var targetPos = targetEntity.GetComponent<TransformComponent>().position;
            if((pos - targetPos).sqrMagnitude < 0.2f)
            {
                SkillContext.CreateDamangeEntity(targetEntity, damage.damage);
                entity.AddComponent<DestroyComponent>();
            }
        }
    }
}