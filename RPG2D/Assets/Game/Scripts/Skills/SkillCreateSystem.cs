using Entitas;
using UnityEngine;
using System.Collections.Generic;
using RPG.View;
public class SkillCreateSystem : ReactiveSystem
{
    public SkillCreateSystem()
    {
        monitors += Context<Input>.AllOf<SkillComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        var playerEntities = Context<Game>.AllOf<PlayerComponent>().GetEntities();
        var playerEntity = playerEntities[0];
        var playerPos = playerEntity.Get<TransformComponent>().position;
        var playerDir = playerEntity.Get<DirectionComponent>().direction;
        foreach (var entity in entities)
        {
            var skill = entity.GetComponent<SkillComponent>();
            switch (skill.skillType)
            {
                case SKILL_TYPE.SIMPLE:
                    {
                        GameContext.CreateSkillSimpleEntity(playerPos, playerDir);
                        break;
                    }
                case SKILL_TYPE.FIRE_SOULS:
                    {
                        GameContext.CreateSkillFireSoulsEntity(playerEntity, new Vector3(0.5f, 0, 0.5f));
                        break;
                    }
                case SKILL_TYPE.FIRE_BOMB:
                    {
                        GameContext.CreateSkillFireBombEntity(playerPos, playerDir);
                        break;
                    }
            }
            entity.Destroy();
        }

    }
}