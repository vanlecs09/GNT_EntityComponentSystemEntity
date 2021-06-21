using Entitas;
using RPG.View;
using UnityEngine;

public class VisionSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<VisionComponent, TeamComponent, TransformComponent>().GetEntities();
        var otherEntities = Context<Game>.AllOf<TeamComponent, TransformComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var vision = entity.GetComponent<VisionComponent>();
            vision.Reset();
            var trans = entity.GetComponent<TransformComponent>();
            var team = entity.GetComponent<TeamComponent>();
            var maxDistance = float.MaxValue;
            foreach (var otherEntity in otherEntities)
            {
                if (!otherEntity.isEnabled) continue;
                var otherTeam = otherEntity.GetComponent<TeamComponent>();
                if (otherTeam.value == team.value) continue;
                if (otherEntity.HasComponent<HumanComponent>() == false || entity.HasComponent<HumanComponent>() == false) continue;
                var otherTrans = otherEntity.GetComponent<TransformComponent>();
                var distanceToOtherEntity = (otherTrans.position - trans.position).magnitude;
                if (distanceToOtherEntity < vision.range && distanceToOtherEntity < maxDistance )
                {
                    maxDistance = distanceToOtherEntity;
                    vision.UpdateVision(entity, otherEntity);
                    vision.currentTargetEntity = otherEntity;
                }
            }
        }
    }
}