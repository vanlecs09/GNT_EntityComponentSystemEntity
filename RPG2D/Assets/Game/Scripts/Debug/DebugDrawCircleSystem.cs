using Entitas;
using RPG.View;
public class DebugDrawCircleSystem : IExecuteSystem
{
    public void Execute()
    {
        {
            var entities = Context<Game>.AllOf<DebugDrawCircleComponent, TransformComponent>().GetEntities();
            foreach (var e in entities)
            {
                var debugDrawCirle = e.GetComponent<DebugDrawCircleComponent>();
                var position = e.GetComponent<TransformComponent>().position;
                DebugExtension.DebugCircle(position, debugDrawCirle.color, debugDrawCirle.radius);
            }

        }

        {
            var entities = Context<Skill>.AllOf<DebugDrawCircleComponent, TransformComponent>().GetEntities();
            foreach (var e in entities)
            {
                var debugDrawCirle = e.GetComponent<DebugDrawCircleComponent>();
                var position = e.GetComponent<TransformComponent>().position;
                DebugExtension.DebugCircle(position, debugDrawCirle.color, debugDrawCirle.radius);
            }
        }
    }
}