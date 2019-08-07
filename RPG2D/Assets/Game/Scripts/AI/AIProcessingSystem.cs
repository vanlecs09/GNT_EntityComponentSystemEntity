using Entitas;

public class AIProcessingSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<AIComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var ai = entity.GetComponent<AIComponent>();
            ai.brain.Tick();
        }
    }
}