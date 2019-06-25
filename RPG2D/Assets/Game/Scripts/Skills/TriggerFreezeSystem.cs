using Entitas;
using System.Collections.Generic;
using UnityEngine;
public class TriggerFreezeSystem : ReactiveSystem
{
    public TriggerFreezeSystem()
    {
        monitors += Context<Game>.AllOf<TriggerComponent, FreezeComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {

        foreach (var skillEntity in entities)
        {
            var freeze = skillEntity.Get<FreezeComponent>();
            var targetFreezeEntities = freeze.targetEntities;
            var freezeTime = freeze.timeFreeze;
            foreach (var targetEntity in targetFreezeEntities)
            {
                targetEntity.AddComponent<FrozenComponent>().Initialize(freezeTime);
            }
            skillEntity.AddComponent<DestroyComponent>();
        }
    }
}