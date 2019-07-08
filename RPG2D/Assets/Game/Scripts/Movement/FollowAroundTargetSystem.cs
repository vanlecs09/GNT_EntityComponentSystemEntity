using Entitas;
using UnityEngine;
using RPG.View;

public class FollowAroundTargetSystem: IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, FollowAroundTargetComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var trans = entity.Modify<TransformComponent>();
            var followAround = entity.Modify<FollowAroundTargetComponent>();

            followAround.currentAngle += followAround.spinSpeed * Time.deltaTime;
            var direction = new Vector3(Mathf.Sin(Mathf.Deg2Rad * followAround.currentAngle), 0, Mathf.Cos(Mathf.Deg2Rad * followAround.currentAngle));
            var offsetToTarget = followAround.offset;
            var targetPos = followAround.targetEntity.Get<TransformComponent>().position;
            trans.position = targetPos - offsetToTarget.magnitude * direction.normalized;
            
        }
    }
}