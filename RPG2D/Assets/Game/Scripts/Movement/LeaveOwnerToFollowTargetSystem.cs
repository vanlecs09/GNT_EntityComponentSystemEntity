using Entitas;
using RPG.View;
public class LeaveOwnerToFollowTargetSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<RadiusRangeComponent, FollowAroundTargetComponent>().GetEntities();
        var botEntities = Context<Game>.AllOf<BotComponent, TransformComponent>().GetEntities();
        foreach (var skillEntity in entities)
        {
            var skillPos = skillEntity.GetComponent<TransformComponent>().position;
            var radiusRange = skillEntity.GetComponent<RadiusRangeComponent>();
            var radius = radiusRange.radius;
            foreach(var bot in botEntities)
            {
                var botPos = bot.Get<TransformComponent>().position;
                if((botPos - skillPos).sqrMagnitude < radius * radius)
                {
                    skillEntity.RemoveComponent<FollowAroundTargetComponent>();
                    skillEntity.AddComponent<MoveToTargetComponent>().Initialize(bot);
                }
            }   
        }
    }
}