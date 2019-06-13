using Entitas;
using UnityEngine;
using System.Collections.Generic;
using RPG.View;
public class SkillFireSoulSystem: ReactiveSystem
{
    public SkillFireSoulSystem()
    {
        monitors += Context<Input>.AllOf<SkillFireComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        var playerEntities = Context<Game>.AllOf<PlayerComponent>().GetEntities();
        var playerEntity = playerEntities[0];
        foreach (var entity in entities)
        {
            GameContext.CreateSkillFireEntity(playerEntity, new Vector3(2, 0, 2));
            entity.Destroy();
        }
    
    }
}