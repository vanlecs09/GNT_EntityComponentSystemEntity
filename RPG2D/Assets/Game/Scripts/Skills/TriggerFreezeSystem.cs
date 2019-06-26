using Entitas;
using System.Collections.Generic;
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
            UnityEngine.Debug.Log("frezze react "  + skillEntity.creationIndex);
            var freeze = skillEntity.Get<FreezeComponent>();
            if(freeze == null){
                // UnityEngine.Debug.LogWarning("freeze component is null " + skillEntity.creationIndex);
            }
            var targetFreezeEntities = freeze.targetEntities;
            var freezeTime = freeze.timeFreeze;
            foreach (var targetEntity in targetFreezeEntities)
            {
                if (targetEntity.HasComponent<FrozenComponent>())
                {
                    targetEntity.Modify<FrozenComponent>().Initialize(freezeTime);
                }
                else
                {
                    targetEntity.AddComponent<FrozenComponent>().Initialize(freezeTime);
                }
            }
            skillEntity.AddComponent<DestroyComponent>();
        }
    }
}