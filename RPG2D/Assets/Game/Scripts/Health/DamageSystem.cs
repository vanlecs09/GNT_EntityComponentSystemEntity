using Entitas;
using System.Collections.Generic;
using RPG.Rendering;

public class DamageSystem : ReactiveSystem
{
    public DamageSystem()
    {
        monitors += Context<Game>.AllOf<DamageComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var listTargetEntities = entity.GetComponent<DamageComponent>().listEntityTarget;
            foreach (var targetEntity in listTargetEntities)
            {
                if (targetEntity.Has<HealthComponent>())
                {
                    if (targetEntity.Has<SpriteRendererComponent>())
                    {
                        targetEntity.Get<SpriteRendererComponent>().ActionDamange();
                    }
                    var health = targetEntity.Modify<HealthComponent>();
                    health.current -= 20;
                }
            }
            listTargetEntities.Clear();

        }
    }
}