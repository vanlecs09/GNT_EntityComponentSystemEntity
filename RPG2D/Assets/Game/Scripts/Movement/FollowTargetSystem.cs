using Entitas;
using RPG.View;

public class FollowTargetSystem: IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, FollowTargetComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var trans = entity.Modify<TransformComponent>();
            var target = entity.Get<FollowTargetComponent>();
        
            var offsetToTarget = target.offset;
            var targetPos = target.targetEntity.Get<TransformComponent>().position;
            trans.position = targetPos - offsetToTarget;
        }
    }
}