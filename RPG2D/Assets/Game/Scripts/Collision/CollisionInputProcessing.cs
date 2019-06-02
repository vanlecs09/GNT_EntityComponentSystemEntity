using Entitas;
using System.Collections.Generic;
using UnityEngine;
public class CollisionInputProcessing : ReactiveSystem
{
    Entity[] _collisionEntities;
    public CollisionInputProcessing()
    {
        monitors += Context<Input>.AllOf<CollisionInputComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var colliEntity in entities)
        {
            Debug.Log("collision occur");
            colliEntity.Destroy();
        }
        

    }
}