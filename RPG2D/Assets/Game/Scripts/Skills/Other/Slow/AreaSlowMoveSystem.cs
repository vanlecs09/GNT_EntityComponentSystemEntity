using Entitas;
using System.Collections.Generic;
public class AreaSlowDownMoveSystem : ReactiveSystem
{
    public AreaSlowDownMoveSystem()
    {
        monitors += Context<Skill>.AllOf<AreaSlowComponent, TargetsComponent>().OnRemoved(OnExit);
    }

    protected void OnExit(List<Entity> entities)
    {
        var slowDownEntities = Context<Game>.AllOf<SlowDownMoveComponent>();
        foreach (var entity in entities)
        {
            var listTargets = entity.GetComponent<TargetsComponent>().listEntityTarget;
            foreach (var target in listTargets)
            {
                foreach (var slowdownEntity in slowDownEntities)
                {
                    if (slowdownEntity.GetComponent<TargetComponent>().targetEntity == target)
                    {
                        slowdownEntity.Destroy();
                        SkillContext.CreateKeepSpeedEntity(target, 2.0f);
                    }
                }
            }
        }
    }
}