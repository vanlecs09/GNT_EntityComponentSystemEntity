using Entitas;
using System.Collections.Generic;
using RPG.View;
using UnityEngine;
using RPG.Rendering;

public class UpdateFacingSystem : ReactiveSystem
{
    public UpdateFacingSystem()
    {
        monitors += Context<Game>.AllOf<DirectionComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var dir = entity.GetComponent<DirectionComponent>();
            float angle = Utils.Math.Vector2ToDegree(new Vector2(dir.value.z, dir.value.x));
            var spriteRendererComp = entity.GetComponent<SpriteRendererComponent>();
            spriteRendererComp.spriteRenderer.SpriteRenderer.flipX =  angle <= 0;
        }
    }
}