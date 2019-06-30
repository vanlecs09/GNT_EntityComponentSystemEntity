using Entitas;
using System.Collections.Generic;
using UnityEngine;
using RPG.View;
public class CollisionExitInputProcessingSystem : ReactiveSystem
{
    public CollisionExitInputProcessingSystem()
    {
        monitors += Context<Input>.AllOf<CollisionExitInputComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        Debug.Log("colliison");
        foreach (var colliEntity in entities)
        {
            var entity1 = colliEntity.GetComponent<CollisionExitInputComponent>().from;
            var entity2 = colliEntity.GetComponent<CollisionExitInputComponent>().to;
            if(entity1.HasComponent<WallAroundComponent>() && entity2.HasComponent<BotComponent>())
            {
                if(entity1.HasComponent<FrozenComponent>())
                {
                    entity1.RemoveComponent<FrozenComponent>();
                }
            }
        }
    }
}