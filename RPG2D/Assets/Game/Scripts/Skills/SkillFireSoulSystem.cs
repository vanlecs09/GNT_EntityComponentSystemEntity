using Entitas;
using UnityEngine;
using System.Collections.Generic;
using RPG.View;
public class SkillFireSoulSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<SkillFireComponent, FollowAroundTargetComponent>().GetEntities();
        var botEntities = Context<Game>.AllOf<BotComponent, TransformComponent>().GetEntities();
        var playerPos = Context<Game>.AllOf<PlayerComponent>().GetEntities()[0].GetComponent<TransformComponent>().position;
        foreach (var skill in entities)
        {
            foreach(var bot in botEntities)
            {
                var botPos = bot.Get<TransformComponent>().position;
                if((botPos - playerPos).sqrMagnitude < 2.0f * 2.0f)
                {
                    skill.RemoveComponent<FollowAroundTargetComponent>();
                    skill.AddComponent<MoveToTargetComponent>().Initialize(bot);
                }
            }   
        }
    }
}