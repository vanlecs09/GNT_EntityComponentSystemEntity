using Entitas;
using System.Collections.Generic;
public class HealthSystem : ReactiveSystem
{
    public HealthSystem()
    {
        monitors += Context<Game>.AllOf<HealthComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var health = entity.GetComponent<HealthComponent>();
            if (health.current > 0)
            {
                if (health.Slider != null)
                    health.Slider.Value = health.current / health.max;
            }
            else
            {
                entity.AddComponent<DestroyComponent>();
            }
        }
    }
}