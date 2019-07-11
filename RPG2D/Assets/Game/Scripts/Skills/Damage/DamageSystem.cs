using Entitas;
using System.Collections.Generic;
using RPG.Rendering;

public class DamageSystem : ReactiveSystem
{
    public DamageSystem()
    {
        monitors += Context<Skill>.AllOf<DamageComponent, TargetsComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var listTargetEntities = entity.GetComponent<TargetsComponent>().listEntityTarget;
            var damange = entity.GetComponent<DamageComponent>().damage;
             var gameContext = Contexts.sharedInstance.GetContext<Game>();
            foreach (var targetEntity in listTargetEntities)
            {
                if (gameContext.GetEntity(targetEntity.creationIndex) != null && targetEntity.Has<HealthComponent>())
                {
                    if (targetEntity.Has<SpriteRendererComponent>())
                    {
                        targetEntity.Get<SpriteRendererComponent>().ActionDamange();
                    }
                    var health = targetEntity.Modify<HealthComponent>();
                    health.current -= damange;
                }
            }
            listTargetEntities.Clear();
            entity.Destroy();
        }
    }
}