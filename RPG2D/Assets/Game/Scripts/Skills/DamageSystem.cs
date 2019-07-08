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
            foreach (var targetEntity in listTargetEntities)
            {
                if (targetEntity.Has<HealthComponent>())
                {
                    if (targetEntity.Has<SpriteRendererComponent>())
                    {
                        UnityEngine.Debug.Log("asdlkjasdlkjsad");
                        targetEntity.Get<SpriteRendererComponent>().ActionDamange();
                    }
                    var health = targetEntity.Modify<HealthComponent>();
                    health.current -= damange;
                }
            }
            listTargetEntities.Clear();
        }
    }
}