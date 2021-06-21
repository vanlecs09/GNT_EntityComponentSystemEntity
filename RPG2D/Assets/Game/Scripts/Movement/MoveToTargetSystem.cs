using Entitas;
using UnityEngine;
using RPG.View;
public class MoveToTargetSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, MoveTargetPosition, MoveComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var targetPosition = entity.GetComponent<MoveTargetPosition>().value;
            var trans = entity.GetComponent<TransformComponent>();
            var transPoint = new Vector3(trans.position.x, targetPosition.y, trans.position.z);
            var targetPoint = targetPosition;
            var move = entity.GetComponent<MoveComponent>();
            move.direction = (targetPoint - transPoint).normalized;
            if ((targetPoint - transPoint).sqrMagnitude <= 0.5 * 0.5)
            {
                entity.RemoveComponent<MoveTargetPosition>();
                entity.AddComponent<ForceMoveComponent>();
            }
            else
            {
                if (entity.HasComponent<ForceMoveComponent>())
                    entity.RemoveComponent<ForceMoveComponent>();
            }
        }
    }
}