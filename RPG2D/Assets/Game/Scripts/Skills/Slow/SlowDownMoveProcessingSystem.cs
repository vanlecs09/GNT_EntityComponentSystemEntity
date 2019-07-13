using Entitas;
using UnityEngine;
using RPG.View;
using RPG.Rendering;
public class SlowDownMoveProcessingSystem : IExecuteSystem
{
    void IExecuteSystem.Execute()
    {
        var entities = Context<Skill>.AllOf<SlowDownMoveComponent, TargetComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var targeEntity = entity.GetComponent<TargetComponent>().targetEntity;
            var beSlow = entity.GetComponent<SlowDownMoveComponent>();
            var move = targeEntity.GetComponent<MoveComponent>();
            beSlow.currentTime += Time.deltaTime;
            if (beSlow.currentTime < beSlow.limitTime)
            {
                beSlow.rate = beSlow.currentTime / beSlow.limitTime;
            }
            else
            {
                entity.Destroy();
                SkillContext.CreateSlowDownEntity(targeEntity, 2.0f);
            }
            
            move.speed = move.maxSpeed - beSlow.rate * move.maxSpeed;
            if(targeEntity.HasComponent<SpriteRendererComponent>())
            {
                var spriteRender = targeEntity.GetComponent<SpriteRendererComponent>().spriteRenderer;
                spriteRender.Color = Color.Lerp(Color.white, Color.blue, beSlow.rate);
            }
        }
    }
}