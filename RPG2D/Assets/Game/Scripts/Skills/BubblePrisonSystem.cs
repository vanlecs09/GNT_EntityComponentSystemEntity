using Entitas;
using UnityEngine;

public class BubblePrisonSystem : IExecuteSystem
{
    public void Execute()
    {
        var skillEntities = Context<Skill>.AllOf<BubblePrisonComponent, CountDownComponent>().GetEntities();
        foreach (var skillEntity in skillEntities)
        {
            var countdown = skillEntity.GetComponent<CountDownComponent>();
            countdown.currentTime += Time.deltaTime;
            if(countdown.currentTime > countdown.time)
            {
                skillEntity.RemoveComponent<BubblePrisonComponent>();
                // skillEntity.RemoveComponent<TargetsComponent>();
            }
        }
    }
}