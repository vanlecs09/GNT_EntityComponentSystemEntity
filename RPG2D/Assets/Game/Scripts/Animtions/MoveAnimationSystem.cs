using Entitas;
using System.Collections.Generic;
using RPG.Rendering;
public class MoveAnimationSystem : ReactiveSystem
{
    public MoveAnimationSystem()
    {
        monitors += Context<Game>.AllOf<MoveComponent, AnimatorComponent>().OnAdded(Process);
    }
    public void Process(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            if(!e.HasComponent<AnimatorComponent>()) continue;
            var move = e.Get<MoveComponent>();
            var animator = e.GetComponent<AnimatorComponent>();
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