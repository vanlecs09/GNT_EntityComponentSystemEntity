using Entitas;
using UnityEngine;

public class WallAroundSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<WallAroundComponent, CoolDownComponent>().GetEntities();
        foreach (var e in entities)
        {
            var countdown = e.GetComponent<CoolDownComponent>();
            countdown.currentTime += Time.deltaTime;
            if(countdown.currentTime > countdown.time)
            {
                e.AddComponent<DestroyComponent>();
            }
        }
    }
}