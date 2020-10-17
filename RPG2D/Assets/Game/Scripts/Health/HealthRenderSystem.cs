using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class HealthRenderSystem : ReactiveSystem
{
    public HealthRenderSystem()
    {
        monitors += Context<Game>.AllOf<HealthComponent, HeathViewComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        Debug.Log("update health render");
        foreach (var entity in entities)
        {
            var health = entity.GetComponent<HealthComponent>();
            var healthView = entity.GetComponent<HeathViewComponent>();
            if (health.current > 0)
            {
                healthView.Slider.Value = health.current / health.max;
            }
            else
            {
                entity.AddComponent<DestroyComponent>();
            }
        }
    }
}