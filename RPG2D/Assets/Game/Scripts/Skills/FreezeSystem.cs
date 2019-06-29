using Entitas;
using System.Collections.Generic;
public class FreezeSystem : ReactiveSystem
{
    public FreezeSystem()
    {
        monitors += Context<Skill>.AllOf<FreezeComponent, TargetsComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        
        foreach (var skillEntity in entities)
        {
            UnityEngine.Debug.Log("frezze react "  + skillEntity.creationIndex);
            var freeze = skillEntity.Get<FreezeComponent>();
            var targets = skillEntity.GetComponent<TargetsComponent>().listEntityTarget;
            if(freeze == null){
                UnityEngine.Debug.LogWarning("freeze component is null " + skillEntity.creationIndex);
            }
            // var targetFreezeEntities = freeze.targetEntities;
            var freezeTime = freeze.timeFreeze;
            foreach (var targetEntity in targets)
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
            skillEntity.Destroy();
        }
    }
}