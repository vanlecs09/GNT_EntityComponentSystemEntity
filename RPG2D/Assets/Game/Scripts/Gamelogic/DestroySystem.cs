using Entitas;
using System.Collections.Generic;
using RPG.View;
public class DestroySystem : ReactiveSystem
{
    public DestroySystem()
    {
        monitors += Context<Game>.AllOf<DestroyComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
             if(entity.Has<ViewComponent>())
            {
                entity.GetComponent<ViewComponent>().transform.Destroy();
            }
            UnityEngine.Debug.Log("destroy eneity " + entity.creationIndex);
            entity.Destroy();
        }
    }
}