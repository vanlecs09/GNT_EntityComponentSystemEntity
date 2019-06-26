using Entitas;
using UnityEngine;
public class FrozenSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<FrozenComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var fronzen = entity.GetComponent<FrozenComponent>();
            fronzen.currentTime += Time.deltaTime;
            if(fronzen.currentTime > fronzen.timeFreeze)
            {
                entity.RemoveComponent<FrozenComponent>();
            }
        }
    }
}