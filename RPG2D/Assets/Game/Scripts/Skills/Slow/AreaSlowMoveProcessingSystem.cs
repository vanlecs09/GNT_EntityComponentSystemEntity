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
            var owner = entity.GetComponent<OwnerComponent>().value;
            var ownerPos = owner.GetComponent<TransformComponent>().position;
            entity.GetComponent<TransformComponent>().position = ownerPos;

            var radius = entity.GetComponent<AreaSlowComponent>().radius;
            var pos = entity.GetComponent<TransformComponent>().position;
            var areaslowDown = entity.GetComponent<AreaSlowComponent>();
            var listTargets = entity.GetComponent<TargetsComponent>().listEntityTarget;
            var slowDownEntities = Context<Skill>.AllOf<SlowDownMoveComponent>();
            var slowEntities = Context<Skill>.AllOf<KeepSpeedComponent>();
            foreach (var botEntity in botEntities)
            {
                var botPos = botEntity.GetComponent<TransformComponent>().position;
                var botMove = botEntity.GetComponent<MoveComponent>();
                if ((botPos - pos).sqrMagnitude < radius * radius)
                {
                    if (listTargets.Find(x => x == botEntity) == null)
                    {
                        listTargets.Add(botEntity);
                        foreach (var slowEnity in slowEntities.ToList())
                        {
                            if (slowEnity.GetComponent<TargetComponent>().targetEntity == botEntity)
                            {
                                slowEnity.Destroy();
                            }
                        }
                        SkillContext.CreateSlowDownEntity(botEntity, 2.0f);
                    }
                }
                else
                {
                    if (listTargets.Find(x => x == botEntity) != null)
                    {
                        foreach (var slowdownEntity in slowDownEntities.ToList())
                        {
                            if (slowdownEntity.GetComponent<TargetComponent>().targetEntity == botEntity)
                            {
                                slowdownEntity.Destroy();
                            }
                        }

                        listTargets.Remove(botEntity);
                        SkillContext.CreateKeepSpeedEntity(botEntity, 2.0f);
                    }
                }

                // remove all null component
                foreach (var target in listTargets)
                {
                    if (target == null)
                    {
                        listTargets.Remove(target);
                    }
                }
            }
        }
    }
}