using Entitas;
using UnityEngine;
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
                Debug.Log(targetEntity);
                if (targetEntity.GetComponent<HealthComponent>() != null && targetEntity.GetComponent<SpriteRendererComponent>() != null)
                {
                    targetEntity.Get<SpriteRendererComponent>().ActionDamange();

                }
            }

            listTargetEntities.Clear();
        }
    }
}