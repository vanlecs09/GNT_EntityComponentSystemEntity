using Entitas;
using UnityEngine;
using System.Collections.Generic;
using RPG.Rendering;

public class DamageSystem: ReactiveSystem
{
    public DamageSystem()
    {
        monitors += Context<Game>.AllOf<DamageComponent, CollisionEnterComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var listColliEnity = entity.GetComponent<CollisionEnterComponent>().listColliEntity;
            foreach(var coliEntity in listColliEnity)
            {
                Debug.Log("damanage 1 ");
                Debug.Log(coliEntity);
                if(coliEntity.GetComponent<HealthComponent>() != null)
                {
                    
                    if(coliEntity.GetComponent<SpriteRendererComponent>() != null)
                    {
                        coliEntity.Get<SpriteRendererComponent>().ActionDamange();
                    }
                        
                }   
            }
        }
    }
}