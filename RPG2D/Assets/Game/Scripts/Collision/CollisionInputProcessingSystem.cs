using Entitas;
using System.Collections.Generic;
using UnityEngine;
public class CollisionInputProcessingSystem : ReactiveSystem
{
    Entity[] _collisionEntities;
    public CollisionInputProcessingSystem()
    {
        monitors += Context<Input>.AllOf<CollisionInputComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var colliEntity in entities)
        {
            Debug.Log("colliison ");
            colliEntity.Destroy();
        }
        

    }
}