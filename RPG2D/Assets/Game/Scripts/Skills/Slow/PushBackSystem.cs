using Entitas;
using System.Collections.Generic;
using RPG.View;
public class PushBackSystem : ReactiveSystem
{
    public PushBackSystem()
    {
        monitors += Context<Skill>.AllOf<RadiusRangeComponent, PushBackComponent, OwnerComponent>().OnAdded(OnEnter);
        monitors += Context<Skill>.AllOf<RadiusRangeComponent, PushBackComponent, OwnerComponent>().OnRemoved(OnExit);
    }

    protected void OnEnter(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var owner = entity.GetComponent<OwnerComponent>().value;
            var ownerPos = owner.GetComponent<TransformComponent>().position;
            var botEntities = Context<Game>.AllOf<BotComponent>().GetEntities();
            var radius = entity.GetComponent<RadiusRangeComponent>().radius;
            var listTargetEntity = new List<Entity>();
            foreach (var botEntity in botEntities)
            {
                var botPos = botEntity.GetComponent<TransformComponent>().position;
                if ((ownerPos - botPos).sqrMagnitude < radius)
                {
                    var targetpos = botEntity.GetComponent<TransformComponent>().position;
                    botEntity.AddComponent<ApplyForceComponent>().Initialize((targetpos - ownerPos).normalized * 300.0f);
                    listTargetEntity.Add(botEntity);
                }
            }
            entity.AddComponent<TargetsComponent>().Initialize(listTargetEntity);
        }
    }

    protected void OnExit(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var listTarget = entity.GetComponent<TargetsComponent>().listEntityTarget;
            foreach (var target in listTarget)
            {
                if (GameContext.IsEntityAlive(target))
                {
                    target.RemoveComponent<ApplyForceComponent>();
                    target.GetComponent<MoveComponent>().acceleration = UnityEngine.Vector3.zero;
                }
            }
            entity.Destroy();
        }
    }
}