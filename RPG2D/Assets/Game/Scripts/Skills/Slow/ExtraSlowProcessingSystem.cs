using Entitas;
using UnityEngine;
using RPG.Rendering;
public class ExtraSlowProcessingSystem : IExecuteSystem
{

    public void Execute()
    {
        var entities = Context<Game>.AllOf<BeExTraSlowDownMoveComponent, MoveComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var beExtraSlow = entity.GetComponent<BeExTraSlowDownMoveComponent>();
            beExtraSlow.currentTime += Time.deltaTime;
            if (entity.HasComponent<SpriteRendererComponent>())
            {
                var spriteRender = entity.GetComponent<SpriteRendererComponent>().spriteRenderer;
                spriteRender.Color = Color.Lerp(Color.blue, Color.white, beExtraSlow.currentTime / beExtraSlow.limitTime);
            }
            if (beExtraSlow.currentTime > beExtraSlow.limitTime)
            {
                entity.RemoveComponent<BeExTraSlowDownMoveComponent>();
                var move = entity.GetComponent<MoveComponent>();
                move.speed = move.maxSpeed;
            }
        }

    }
}