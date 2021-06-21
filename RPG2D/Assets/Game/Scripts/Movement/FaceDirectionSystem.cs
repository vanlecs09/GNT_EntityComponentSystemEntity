using Entitas;
using UnityEngine;
using RPG.View;

public class FaceDirectionSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, DirectionComponent>().GetEntities();
        foreach (var entity in entities)
        {
            if(entity.GetComponent<DirectionComponent>().value == Vector3.zero) continue;
            var trans = entity.Modify<TransformComponent>();
            entity.Modify<TransformComponent>().rotation = Quaternion.LookRotation(entity.GetComponent<DirectionComponent>().value, Vector3.up);
        }
    }
}