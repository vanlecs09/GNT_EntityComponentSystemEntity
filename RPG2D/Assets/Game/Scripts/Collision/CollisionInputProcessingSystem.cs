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
            Debug.Log("colliison ");
            var enitty1 = colliEntity.GetComponent<CollisionInputComponent>().from;
            var entity2 = colliEntity.GetComponent<CollisionInputComponent>().to;
            var collisionEnter = enitty1.Modify<CollisionEnterComponent>();
            if (collisionEnter != null)
            {
                collisionEnter.listColliEntity.Add(entity2);
                colliEntity.Destroy();
            }

        }
    }
}