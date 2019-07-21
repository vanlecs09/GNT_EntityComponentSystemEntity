using UnityEngine;
using Entitas;
using RPG.View;
public class SteeringService
{
    public static Vector3 Calculate(SteeringBehaviorComponent steering, Entity owner)
    {
        Vector3 steeringForce = Vector3.zero;
        var ownerPos = owner.GetComponent<TransformComponent>().position;
        var move = owner.GetComponent<MoveComponent>();
        if (steering.IsSeekOn())
        {
            steeringForce += Seek(ownerPos, move, steering.vTarget);
        }

        if (steering.isPursuitOn())
        {
            steeringForce += Pursuit(steering, owner, steering.targetEntity);
        }
        return steeringForce;
    }
    public static Vector3 Seek(Vector3 ownerPos, MoveComponent move, Vector3 targetPos)
    {
        Vector3 desiredVelocity = (targetPos - ownerPos).normalized * move.maxSpeed;
        return desiredVelocity - move.velocity;
    }

    public static Vector3 Pursuit(SteeringBehaviorComponent steering, Entity owner, Entity targetEntity)
    {
        if(targetEntity.isEnabled == false) return Vector3.zero;
        var targetPos = targetEntity.GetComponent<TransformComponent>().position;
        var ownerPos = owner.GetComponent<TransformComponent>().position;
        var onwerMove = owner.GetComponent<MoveComponent>();
        var targetMove = targetEntity.GetComponent<MoveComponent>();
        Vector3 toTarget = targetPos - ownerPos;
        float relativeHeading = Vector3.Dot(onwerMove.direction, targetMove.direction);
        if ((Vector3.Dot(toTarget, onwerMove.direction) > 0) && relativeHeading < -0.95)
        {
            return Seek(ownerPos, onwerMove, targetPos);
        }

        float lookAheadTime = toTarget.magnitude / (onwerMove.maxSpeed + targetMove.velocity.magnitude);
        return Seek(ownerPos, onwerMove, targetPos + targetMove.velocity * lookAheadTime);
    }
}