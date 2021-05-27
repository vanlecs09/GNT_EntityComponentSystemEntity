using Entitas;
using UnityEngine;
using RPG.Rendering;
public class KeepSpeedProcessingSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Skill>.AllOf<KeepSpeedComponent, TargetComponent, CountDownComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var targetEntity = entity.GetComponent<TargetComponent>().targetEntity;
            if(GameContext.IsEntityAlive(targetEntity) == false) 
            {
                entity.Destroy();
                continue;
            }
            var beExtraSlow = entity.GetComponent<KeepSpeedComponent>();
            var countDown = entity.GetComponent<CountDownComponent>();
            countDown.currentTime += Time.deltaTime;
            if (targetEntity.HasComponent<SpriteRendererComponent>())
            {
                var spriteRender = targetEntity.GetComponent<SpriteRendererComponent>().spriteRenderer;
                var rate = countDown.currentTime / countDown.time;
                Mathf.Clamp(rate, 0.0f, 1.0f);
                spriteRender.Color = Color.Lerp(Color.blue, Color.white, rate);
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