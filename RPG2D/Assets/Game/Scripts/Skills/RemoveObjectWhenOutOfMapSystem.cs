using Entitas;
using RPG.View;

public class RemoveObjectWhenOutOfMapSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent>().GetEntities();
        foreach (var e in entities)
        {
            var pos = e.GetComponent<TransformComponent>().position;
            if(pos.x < -5 || pos.x > 5 || pos.z > 5 || pos.z < -5)
                e.AddComponent<DestroyComponent>();
        }
    }
}