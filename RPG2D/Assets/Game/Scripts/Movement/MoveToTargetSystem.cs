using Entitas;
using UnityEngine;
using RPG.View;
public class MoveToTargetSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, TargetComponent, MoveComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var targetEntity = entity.Get<TargetComponent>().targetEntity;
            if (targetEntity.isEnabled == false)
            {
                // var targetPos = targetEntity.GetComponent<TransformComponent>().position;
                // var entityPos = entity.GetComponent<TransformComponent>().position;
                // var move = entity.GetComponent<MoveComponent>();
                // move.direction = targetPos - entityPos;
                // if ((entityPos - targetPos).magnitude < 0.2f)
                // {
                //     entity.RemoveComponent<TargetComponent>();
                //     entity.RemoveComponent<MoveComponent>();
                // }
                entity.AddComponent<DestroyComponent>();
            }
        }
    }
}