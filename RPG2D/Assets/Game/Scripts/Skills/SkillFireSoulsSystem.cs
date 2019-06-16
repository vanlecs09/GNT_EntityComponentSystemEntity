using Entitas;
using RPG.View;
public class SkillFireSoulsSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<SkillFireSoulsComponent, FollowAroundTargetComponent>().GetEntities();
        var botEntities = Context<Game>.AllOf<BotComponent, TransformComponent>().GetEntities();
        foreach (var skillEntity in entities)
        {
            var skillPos = skillEntity.GetComponent<TransformComponent>().position;
            var skillFireSouls = skillEntity.GetComponent<SkillFireSoulsComponent>();
            var radius = skillFireSouls.radius;
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