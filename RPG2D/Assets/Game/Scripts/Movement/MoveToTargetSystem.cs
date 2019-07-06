using Entitas;
using UnityEngine;
using RPG.View;
public class MoveToTargetSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, MoveToTargetComponent, MoveComponent>().GetEntities();
        foreach (var e in entities)
        {
            var targetEntity = e.Get<MoveToTargetComponent>().targetEntity;
            if (targetEntity.isEnabled)
            {
                var targetPosition = targetEntity.GetComponent<TransformComponent>().position;
                var myTrans = e.GetComponent<TransformComponent>();
                var move = e.GetComponent<MoveComponent>();
                move.direction = targetPosition - myTrans.position;
                if ((myTrans.position - targetPosition).magnitude < 0.1)
                {
                    e.RemoveComponent<MoveToTargetComponent>();
                    e.RemoveComponent<MoveComponent>();
                }
            }
            else
            {
                e.AddComponent<DestroyComponent>();
            }

        }
    }
}