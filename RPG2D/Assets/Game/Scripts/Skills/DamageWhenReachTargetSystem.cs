using Entitas;
using RPG.View;
using System.Collections.Generic;
public class DamageWhenReachTargetSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TargetComponent, TransformComponent, DamageComponent>().GetEntities();
        foreach(var entity in entities)
        {
            var pos = entity.GetComponent<TransformComponent>().position;
            var targetEntity = entity.GetComponent<TargetComponent>().targetEntity;
            if(targetEntity == null)
            {
                entity.AddComponent<DestroyComponent>();
                continue;
            }
            var damage = entity.GetComponent<DamageComponent>();
            var targetPos = targetEntity.GetComponent<TransformComponent>().position;
            if((pos - targetPos).sqrMagnitude < 0.2f)
            {
                List<Entity> listTarget = new List<Entity>();
                listTarget.Add(targetEntity);
                SkillContext.CreateDamangeEntity(listTarget, damage.damage);
                entity.AddComponent<DestroyComponent>();
            }
        }
    }
}