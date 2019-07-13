using Entitas;
using UnityEngine;
using RPG.Rendering;
public class SlowProcessingSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Skill>.AllOf<SlowMoveComponent, TargetComponent, CountDownComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var beExtraSlow = entity.GetComponent<SlowMoveComponent>();
            var countDown = entity.GetComponent<CountDownComponent>();
            var targetEntity = entity.GetComponent<TargetComponent>().targetEntity;
            countDown.currentTime += Time.deltaTime;
            if (entity.HasComponent<SpriteRendererComponent>())
            {
                var spriteRender = targetEntity.GetComponent<SpriteRendererComponent>().spriteRenderer;
                spriteRender.Color = Color.Lerp(Color.blue, Color.white, countDown.currentTime / countDown.time);
            }
            if (countDown.currentTime > countDown.time)
            {
                entity.Destroy();
                var move = targetEntity.GetComponent<MoveComponent>();
                move.speed = move.maxSpeed;
            }
        }

    }
}