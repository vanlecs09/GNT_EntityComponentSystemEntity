using Entitas;
using UnityEngine;
using RPG.View;
using System.Linq;
public class AreaSlowMoveProcessingSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Skill>.AllOf<AreaSlowComponent, TargetsComponent, OwnerComponent>().GetEntities();
        
        var botEntities = Context<Game>.AllOf<BotComponent>();
        foreach (var entity in entities)
        {
            Debug.Log("processing slowdown area");
            var owner  = entity.GetComponent<OwnerComponent>().value;
            var ownerPos = owner.GetComponent<TransformComponent>().position;
            entity.GetComponent<TransformComponent>().position = ownerPos;

            var radius = entity.GetComponent<AreaSlowComponent>().radius;
            var pos = entity.GetComponent<TransformComponent>().position;
            var areaslowDown = entity.GetComponent<AreaSlowComponent>();
            var listTargets = entity.GetComponent<TargetsComponent>().listEntityTarget;
            foreach (var botEntity in botEntities)
            {
                var botPos = botEntity.GetComponent<TransformComponent>().position;
                var botMove = botEntity.GetComponent<MoveComponent>();
                if ((botPos - pos).sqrMagnitude < radius * radius)
                {
                    if (listTargets.Find(x => x == botEntity) == null)
                        continue;
                    listTargets.Add(botEntity);
                    SkillContext.CreateSlowDownEntity(botEntity, 2.0f);
                }
                else
                {
                    listTargets.Remove(botEntity);
                    SkillContext.CreateSlowDownEntity(botEntity, 2.0f);
                }
            }
        }
    }
}