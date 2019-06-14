using Entitas;
using UnityEngine;
using RPG.View;
public class MoveToTargetSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, MoveToTargetComponent>().GetEntities();
        foreach (var e in entities)
        {
            var targetEntity = e.Get<MoveToTargetComponent>().targetEntity;
            var targetPosition = targetEntity.GetComponent<TransformComponent>().position;
            var myTrans = e.Modify<TransformComponent>();
            myTrans.position +=  (targetPosition - myTrans.position).normalized  * 2 * Time.deltaTime;
            if((myTrans.position  - targetPosition).magnitude < 0.1)
            {
                e.RemoveComponent<MoveToTargetComponent>();
            }
        }
    }
}