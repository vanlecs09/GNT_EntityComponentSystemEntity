using Entitas;
using UnityEngine;
using RPG.View;

public class FollowTargetSystem: IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, FollowTargetComponent>().GetEntities();
        foreach (var e in entities)
        {
            var trans = e.Modify<TransformComponent>();
            var target = e.Get<FollowTargetComponent>();

            var offsetToTarget = target.offset;
            var targetPos = target.targetEntity.Get<TransformComponent>().position;
            trans.position = targetPos - offsetToTarget;   
        }
    }
}