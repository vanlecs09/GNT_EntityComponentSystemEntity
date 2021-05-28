using Entitas;
using UnityEngine;
public class FreezeProcessingSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Skill>.AllOf<FreezeComponent, CoolDownComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var fronzen = entity.GetComponent<FreezeComponent>();
            var countDown = entity.GetComponent<CoolDownComponent>();
            countDown.currentTime += Time.deltaTime;
            if(countDown.currentTime > countDown.time)
            {
                entity.RemoveComponent<FreezeComponent>();
            }
        }
    }
}