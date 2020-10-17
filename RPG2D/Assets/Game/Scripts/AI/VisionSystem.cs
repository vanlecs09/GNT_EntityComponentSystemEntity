using Entitas;
using RPG.View;

public class VisionSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<VisionComponent, TeamComponent, TransformComponent>().GetEntities();
        var otherEntities = Context<Game>.AllOf<BotComponent, TeamComponent, TransformComponent>().GetEntities();
        foreach (var entity in entities)    
        {
            var vision = entity.GetComponent<VisionComponent>();
            var trans = entity.GetComponent<TransformComponent>();
            var team = entity.GetComponent<TeamComponent>();
            foreach (var otherEntity in otherEntities)
            {
                var otherTeam = otherEntity.GetComponent<TeamComponent>();
                if (otherTeam.value == team.value) continue;
                var otherTrans = otherEntity.GetComponent<TransformComponent>();
                var maxDistance = float.MaxValue;
                var distanceToOtherEntity = (otherTrans.position - trans.position).magnitude;
                if (distanceToOtherEntity < vision.range)
                {
                    maxDistance = distanceToOtherEntity;
                    vision.targets.Add(otherEntity);
                }
            }
        }
    }
}