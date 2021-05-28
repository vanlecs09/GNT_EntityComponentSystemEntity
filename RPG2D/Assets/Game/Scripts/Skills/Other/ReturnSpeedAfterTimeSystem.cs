using Entitas;
using RPG.View;
using UnityEngine;
public class ReturnSpeedAfterTimeSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Skill>.AllOf<CoolDownComponent, ReturnSpeedComponent, TargetsComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var countDown = entity.GetComponent<CoolDownComponent>();
            countDown.currentTime += Time.deltaTime;
            if(countDown.currentTime > countDown.time)
            {
                var targets = entity.GetComponent<TargetsComponent>().listEntityTarget;
                foreach(var target in targets)
                {
                    if(target.HasComponent<MoveComponent>())
                    {
                        var move = target.GetComponent<MoveComponent>();
                        move.speed = move.maxSpeed;
                    }
                }
                entity.Destroy();
            }
        }
    }
}