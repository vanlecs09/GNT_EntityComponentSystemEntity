using Entitas;
using System.Collections.Generic;
using UnityEngine;
using RPG.View;
using RPG.Rendering;
public class SlowMoveSystem : ReactiveSystem
{
    public SlowMoveSystem()
    {
        monitors += Context<Skill>.AllOf<TargetComponent, SlowMoveComponent>().OnAdded(OnEnter);
        monitors += Context<Skill>.AllOf<TargetComponent, SlowMoveComponent>().OnRemoved(OnExit);
    }

    protected void OnEnter(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var targetEntity = entity.GetComponent<TargetComponent>().targetEntity;
            if (GameContext.IsEntityAlive(targetEntity) == false) continue;
            var cacheskil = targetEntity.GetComponent<CacheSkillEffectComponnet>();

            if (entity.HasComponent<StackSkillComponent>() || cacheskil.HasSkillEffect(typeof(SlowMoveComponent)) == false)
            {
                var move = targetEntity.GetComponent<MoveComponent>();
                var slowMove = entity.GetComponent<SlowMoveComponent>();
                move.speed -= slowMove.speedToReduce;
                if (targetEntity.HasComponent<SpriteRendererComponent>())
                {
                    var render = targetEntity.GetComponent<SpriteRendererComponent>();
                    render.spriteRenderer.Color = new Color(0.0f, 0.0f, 1.0f, 0.5f);
                }
            }
            cacheskil.AddSkillEntity(typeof(SlowMoveComponent));
        }
    }

    protected void OnExit(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var targetEntity = entity.GetComponent<TargetComponent>().targetEntity;
            if (targetEntity.isEnabled == false) continue;

            var cacheskil = targetEntity.GetComponent<CacheSkillEffectComponnet>();
            cacheskil.RemoveSkillEntity(typeof(SlowMoveComponent));
            if (cacheskil.HasSkillEffect(typeof(SlowMoveComponent)) == false)
            {
                var move = targetEntity.GetComponent<MoveComponent>();
                move.speed = move.maxSpeed;
                if (targetEntity.HasComponent<SpriteRendererComponent>())
                {
                    var render = targetEntity.GetComponent<SpriteRendererComponent>();
                    render.spriteRenderer.Color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
            }
            entity.Destroy();
        }
    }
}
