using Entitas;
using RPG.View;
using UnityEngine;
public class MoveSteeringSystem : IExecuteSystem
{
    public void Execute()
    {
        var entities = Context<Game>.AllOf<TransformComponent, MoveComponent, SteeringBehaviorComponent>().GetEntities();
        var deltaTime = Time.smoothDeltaTime;
        foreach (var entity in entities)
        {
            var steering = entity.GetComponent<SteeringBehaviorComponent>();
            var move = entity.Modify<MoveComponent>();
            var trans = entity.Modify<TransformComponent>();
            var steeringForce = SteeringService.Calculate(steering, entity);
            move.acceleration = steeringForce * 3.0f;
            move.velocity += move.acceleration * deltaTime;
            Vector3.ClampMagnitude(move.velocity, move.maxSpeed);
            trans.position += move.velocity * deltaTime;
            move.direction = move.velocity.normalized;

            if (entity.HasComponent<DirectionComponent>() == true && (move.direction.sqrMagnitude != 0))
            {
                entity.Modify<DirectionComponent>().value = move.direction;
            }
        }
    }
}