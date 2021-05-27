using Entitas;
using RPG.View;

public class RemoveObjectWhenOutOfMapSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent>().GetEntities();
        foreach (var e in entities)
        {
            if(e.HasComponent<PlayerComponent>()) continue;
            var pos = e.GetComponent<TransformComponent>().position;
            if(pos.x < -10 || pos.x > 10 || pos.z > 10 || pos.z < -10)
                e.AddComponent<DestroyComponent>();
        }
    }
}