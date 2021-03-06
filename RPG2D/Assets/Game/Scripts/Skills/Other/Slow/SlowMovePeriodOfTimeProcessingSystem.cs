using Entitas;
using UnityEngine;

public class SlowMovePeriodOfTimeProcessingSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Skill>.AllOf<TargetComponent, CoolDownComponent, SlowMoveComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var countDown = entity.GetComponent<CoolDownComponent>();
            var targetEntity = entity.GetComponent<TargetComponent>().targetEntity;
            if (GameContext.IsEntityAlive(targetEntity) == false) continue;
            countDown.currentTime += Time.deltaTime;
            if (countDown.currentTime > countDown.time)
            {
                entity.RemoveComponent<SlowMoveComponent>();
            }
        }
    }
}
