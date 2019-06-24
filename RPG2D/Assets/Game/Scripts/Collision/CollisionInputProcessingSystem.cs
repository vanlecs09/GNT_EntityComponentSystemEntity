using Entitas;
using System.Collections.Generic;
using UnityEngine;
public class CollisionInputProcessingSystem : ReactiveSystem
{
    public CollisionInputProcessingSystem()
    {
        monitors += Context<Input>.AllOf<CollisionInputComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var colliEntity in entities)
        {
            var enitty1 = colliEntity.GetComponent<CollisionInputComponent>().from;
            var entity2 = colliEntity.GetComponent<CollisionInputComponent>().to;
            if (enitty1.HasComponent<DamageComponent>())
            {
                var damange = enitty1.Modify<DamageComponent>();
                damange.listEntityTarget.Add(entity2);
                enitty1.AddComponent<DestroyComponent>();
            }

            if (enitty1.HasComponent<TriggerComponent>())
            {
                var skillFireBomb = enitty1.Modify<TriggerComponent>();
                skillFireBomb.isTrigger = true;
            }
        }
    }
}