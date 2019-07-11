using Entitas;
using UnityEngine;
using RPG.View;
using RPG.Rendering;
public class SlowDownMoveProcessingSystem : IExecuteSystem
{
    void IExecuteSystem.Execute()
    {
        var entities = Context<Game>.AllOf<BeSlowDownMoveComponent, MoveComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var beSlow = entity.GetComponent<BeSlowDownMoveComponent>();
            var move = entity.GetComponent<MoveComponent>();
            beSlow.currentTime += Time.deltaTime;
            if (beSlow.currentTime < beSlow.limitTime)
            {
                beSlow.rate = beSlow.currentTime / beSlow.limitTime;
            }
            
            move.speed = move.maxSpeed - beSlow.rate * move.maxSpeed;
            if(entity.HasComponent<SpriteRendererComponent>())
            {
                var spriteRender = entity.GetComponent<SpriteRendererComponent>().spriteRenderer;
                spriteRender.Color = Color.Lerp(Color.white, Color.blue, beSlow.rate);
            }
        }
    }
}