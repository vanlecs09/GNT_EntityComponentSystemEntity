using Entitas;
using System.Collections.Generic;

public class PushBackSystem: ReactiveSystem
{
    public PushBackSystem()
    {
        monitors += Context<Skill>.AllOf<TargetComponent, PushBackComponent, OwnerComponent>().OnAdded(OnEnter);
        monitors += Context<Skill>.AllOf<TargetComponent, PushBackComponent, OwnerComponent>().OnRemoved(OnExit);
    }

    protected void OnEnter(List<Entity> entities)
    {
        foreach (var entity in entities)
        {

        }
    }

    protected void OnExit(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
           
            entity.Destroy();
        }
    }
}