using Entitas;
using UnityEngine;

public class PushBackProcessingSystem : IExecuteSystem
{
    public void Execute()
    {
        var deltaTime = Time.deltaTime;
        var entities = Context<Skill>.AllOf<PushBackComponent, CoolDownComponent>().GetEntities();
        foreach (var entity in entities)
        {   
            var targets = entity.GetComponent<TargetsComponent>();
            var countDown = entity.GetComponent<CoolDownComponent>();
            countDown.currentTime += deltaTime;
            if(countDown.currentTime > countDown.time)
            {
                entity.RemoveComponent<PushBackComponent>();
            }
        }
    }
}