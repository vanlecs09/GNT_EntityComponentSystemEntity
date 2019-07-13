using Entitas;
using System.Collections.Generic;
using RPG.Rendering;

public class DamageSystem : ReactiveSystem
{
    public DamageSystem()
    {
        monitors += Context<Skill>.AllOf<DamageComponent, TargetComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var targetEntity = entity.GetComponent<TargetComponent>().targetEntity;
            var damange = entity.GetComponent<DamageComponent>().damage;
            var gameContext = Contexts.sharedInstance.GetContext<Game>();

            if (gameContext.GetEntity(targetEntity.creationIndex) != null && targetEntity.Has<HealthComponent>())
            {
                if (targetEntity.Has<SpriteRendererComponent>())
                {
                    targetEntity.Get<SpriteRendererComponent>().ActionDamange();
                }
                var health = targetEntity.Modify<HealthComponent>();
                health.current -= damange;
            }
            entity.Destroy();
        }
    }
}