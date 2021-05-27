using Entitas;
using UnityEngine;

public class WallAroundSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<WallAroundComponent, CountDownComponent>().GetEntities();
        foreach (var e in entities)
        {
            var countdown = e.GetComponent<CountDownComponent>();
            countdown.currentTime += Time.deltaTime;
            if(countdown.currentTime > countdown.time)
            {
                e.AddComponent<DestroyComponent>();
            }
        }
    }
}