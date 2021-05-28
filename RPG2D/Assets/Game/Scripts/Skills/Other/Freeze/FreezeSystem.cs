using Entitas;
using System.Collections.Generic;
public class FreezeSystem : ReactiveSystem
{
    public FreezeSystem()
    {
        monitors += Context<Skill>.AllOf<FreezeComponent, TargetComponent, CoolDownComponent>().OnAdded(OnEnter);
        monitors += Context<Skill>.AllOf<FreezeComponent, TargetComponent, CoolDownComponent>().OnRemoved(OnExit);
    }

    protected void OnEnter(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var freeze = entity.GetComponent<FreezeComponent>();
            var targetEntity = entity.GetComponent<TargetComponent>().targetEntity;
            var freezeTime = freeze.timeFreeze;
            // foreach (var targetEntity in targets)
            // {
                if(targetEntity.HasComponent<MoveComponent>())
                {
                    var move = targetEntity.GetComponent<MoveComponent>();
                    move.speed = 0.0f;
                }
            // }
        }
    }

    protected void OnExit(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var targets = entity.GetComponent<TargetsComponent>().listEntityTarget;
            foreach (var targetEntity in targets)
            {
                if(targetEntity.HasComponent<MoveComponent>())
                {
                    var move = targetEntity.GetComponent<MoveComponent>();
                    move.speed = move.maxSpeed;
                }
            }
            entity.Destroy();
        }
    }
}