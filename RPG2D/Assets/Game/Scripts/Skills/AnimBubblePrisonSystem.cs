using Entitas;
using System.Collections.Generic;
using RPG.Rendering;
public class AnimBubbleSytem : ReactiveSystem
{
    public AnimBubbleSytem()
    {
        monitors += Context<Skill>.AllOf<BubblePrisonComponent, TargetsComponent>().OnAdded(Process);
        monitors += Context<Skill>.AllOf<BubblePrisonComponent, TargetsComponent>().OnRemoved(ProcessRemove);
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var enitty in entities)
        {
            var targets = enitty.GetComponent<TargetsComponent>().listEntityTarget;
            foreach (var target in targets)
            {
                if (!target.HasComponent<AnimatorComponent>()) continue;
                var animator = target.GetComponent<AnimatorComponent>();
                animator.value.SetTrigger("bubble_prison");
            }
        }
    }

    void ProcessRemove(List<Entity> entities)
    {
        foreach (var enitty in entities)
        {
            UnityEngine.Debug.Log(("excute1"));
            var targets = enitty.GetComponent<TargetsComponent>().listEntityTarget;
            UnityEngine.Debug.Log(("excute2"));
            foreach (var target in targets)
            {
                if (!target.HasComponent<AnimatorComponent>()) continue;
                var animator = target.GetComponent<AnimatorComponent>();
                animator.value.PlayClip("Idle");
            }
            enitty.Destroy();
        }
    }
}