using Entitas;
using RPG.View;
using UnityEngine;

public class DebugVisionSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<VisionComponent, DebugVisionComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var vision = entity.GetComponent<VisionComponent>();
            var transfrom = entity.GetComponent<TransformComponent>();
            DebugExtension.DebugVision(transfrom.position, Vector3.forward, Color.red, vision.attackRange, 360);
            DebugExtension.DebugVision(transfrom.position, Vector3.forward, Color.red, vision.chaseRange, 360);
        }
    }
}