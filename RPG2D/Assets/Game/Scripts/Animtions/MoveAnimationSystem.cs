using Entitas;
using System.Collections.Generic;
using RPG.Rendering;
public class MoveAnimationSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<MoveComponent, AnimatorComponent>().GetEntities();
        foreach (var entity in entities)
        {
            if (!entity.HasComponent<AnimatorComponent>()) continue;
            var move = entity.Get<MoveComponent>();
            var animator = entity.GetComponent<AnimatorComponent>();
            if (entity.HasComponent<ForceMoveComponent>())
            {
                animator.value.SetFloat("speed", 0);
                continue;
            }
            if (move.velocity.sqrMagnitude > 0)
            {
                animator.value.SetFloat("speed", move.velocity.magnitude);
            }
            else
            {
                animator.value.SetFloat("speed", 0);
            }
        }
    }
}