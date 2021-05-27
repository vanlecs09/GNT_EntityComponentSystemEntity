using Entitas;
using System.Collections.Generic;
using RPG.Rendering;
public class AnimBubbleSytem : ReactiveSystem, IExecuteSystem
{
    public AnimBubbleSytem()
    {
        monitors += Context<Skill>.AllOf<BubblePrisonComponent, TargetComponent>().OnAdded(Process);
        monitors += Context<Skill>.AllOf<BubblePrisonComponent, TargetComponent>().OnRemoved(ProcessRemove);
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var enitty in entities)
        {
            var targetEntity = enitty.GetComponent<TargetComponent>().targetEntity;
            // foreach (var target in targets)
            // {
            if (!targetEntity.HasComponent<AnimatorComponent>()) continue;
            var animator = targetEntity.GetComponent<AnimatorComponent>();
            animator.value.SetTrigger("bubble_prison");
            // }
        }
    }

    void ProcessRemove(List<Entity> entities)
    {
        foreach (var enitty in entities)
        {
            var targetEntity = enitty.GetComponent<TargetComponent>().targetEntity;
            // foreach (var target in targets)
            // {
                if (!targetEntity.HasComponent<AnimatorComponent>()) continue;
                var animator = targetEntity.GetComponent<AnimatorComponent>();
                animator.value.PlayClip("Idle");
            // }
            enitty.Destroy();
        }
    }
}