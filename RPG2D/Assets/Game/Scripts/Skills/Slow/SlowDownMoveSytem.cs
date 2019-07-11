using Entitas;
using System.Collections.Generic;
using RPG.Rendering;
using UnityEngine;
public class SlowDownMoveSystem : ReactiveSystem
{
    public SlowDownMoveSystem()
    {
        monitors += Context<Game>.AllOf<BeExTraSlowDownMoveComponent, MoveComponent>().OnRemoved(OnExit);
    }

    protected void OnExit(List<Entity> entities)
    {
        foreach (var entity in entities)
        {

            var move = entity.GetComponent<MoveComponent>();
            if(entity.HasComponent<SpriteRendererComponent>())
            {
                var spriteRendering = entity.GetComponent<SpriteRendererComponent>().spriteRenderer;
            }
        }
    }
}