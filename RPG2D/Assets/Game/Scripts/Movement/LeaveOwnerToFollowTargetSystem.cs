using Entitas;
using RPG.View;
using UnityEngine;
public class LeaveOwnerToFollowTargetSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<RadiusRangeComponent, FollowAroundTargetComponent>().GetEntities();
        var botEntities = Context<Game>.AllOf<BotComponent, TransformComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var skillPos = entity.GetComponent<TransformComponent>().position;
            var radiusRange = entity.GetComponent<RadiusRangeComponent>();
            var radius = radiusRange.radius;
            foreach(var bot in botEntities)
            {
                var botPos = bot.Get<TransformComponent>().position;
                if((botPos - skillPos).sqrMagnitude < radius * radius)
                {
                    entity.RemoveComponent<FollowAroundTargetComponent>();
                    if(entity.HasComponent<SteeringBehaviorComponent>() == false)
                    {
                        entity.AddComponent<SteeringBehaviorComponent>();
                    }
                    var steering = entity.GetComponent<SteeringBehaviorComponent>();
                    steering.PursuitOn(bot);
                    entity.AddComponent<TargetComponent>().Initialize(bot);
                    entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 5.0f, Vector3.zero);
                }
            }   
        }
    }
}