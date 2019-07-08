using Entitas;
using UnityEngine;

public class BubblePrisonProcessingSystem : IExecuteSystem
{
    public void Execute()
    {
        var skillEntities = Context<Skill>.AllOf<BubblePrisonComponent, CountDownComponent>().GetEntities();
        foreach (var entity in skillEntities)
        {
            var countdown = entity.GetComponent<CountDownComponent>();
            countdown.currentTime += Time.deltaTime;
            if(countdown.currentTime > countdown.time)
            {
                entity.RemoveComponent<BubblePrisonComponent>();
            }
        }
    }
}