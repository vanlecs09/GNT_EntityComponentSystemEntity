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
        if (steering.isLinearOn())
        {
            steeringForce += Linear(move) * 100.0f;
        }

        if (steering.IsSeekOn())
        {
            steeringForce += Seek(ownerPos, move, steering.vTarget) * 3.0f;
        }

        if (steering.isPursuitOn())
        {
            steeringForce += Pursuit(steering, owner);
            
        }

        if(steering.isEvadeOn())
        {
            steeringForce += Evade(steering, owner) * 5.0f;
        }
        return steeringForce;
    }
    public static Vector3 Linear(MoveComponent move)
    {
        return move.direction *  move.maxSpeed;
    }

    public static Vector3 Seek(Vector3 ownerPos, MoveComponent move, Vector3 targetPos)
    {
        Vector3 desiredVelocity = (targetPos - ownerPos).normalized * move.maxSpeed;
        
        return desiredVelocity - move.velocity;
    }

    public static Vector3 Flee(Vector3 ownerPos, MoveComponent move, Vector3 targetPos)
    {
        Vector3 desiredVelocity = (ownerPos - targetPos).normalized * move.maxSpeed;
        return desiredVelocity - move.velocity;
    }


    public static Vector3 Pursuit(SteeringBehaviorComponent steering, Entity owner)
    {
        var targetEntity = steering.targetEntity;
        if (targetEntity.isEnabled == false) return Vector3.zero;
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

    public static Vector3 Evade(SteeringBehaviorComponent steering, Entity owner)
    {
        var targetEntity = steering.targetEntity;
        if (targetEntity.isEnabled == false) return Vector3.zero;
        var pursuerPos = targetEntity.GetComponent<TransformComponent>().position;
        var onwerPos = owner.GetComponent<TransformComponent>().position;
        var ownerMove = owner.GetComponent<MoveComponent>();
        var pursuerSpeed = targetEntity.GetComponent<MoveComponent>().velocity.magnitude;
        var pursuerVelocity = targetEntity.GetComponent<MoveComponent>().velocity;
        Vector3 toPursuer = pursuerPos - onwerPos;

        var threathenRange = 5.0f;

        if (toPursuer.sqrMagnitude > threathenRange * threathenRange) return Vector3.zero;

        float lookAheadTime = toPursuer.magnitude / (ownerMove.maxSpeed + pursuerSpeed);
        return Flee(onwerPos, ownerMove, pursuerPos + pursuerVelocity * lookAheadTime);
    }
}


// Vector2D SteeringBehavior::Evade(const Vehicle* pursuer)
// {
//   /* Not necessary to include the check for facing direction this time */

//   Vector2D ToPursuer = pursuer->Pos() - m_pVehicle->Pos();

//   //uncomment the following two lines to have Evade only consider pursuers 
//   //within a 'threat range'
//   const double ThreatRange = 100.0;
//   if (ToPursuer.LengthSq() > ThreatRange * ThreatRange) return Vector2D();

//   //the lookahead time is propotional to the distance between the pursuer
//   //and the pursuer; and is inversely proportional to the sum of the
//   //agents' velocities
//   double LookAheadTime = ToPursuer.Length() / 
//                          (m_pVehicle->MaxSpeed() + pursuer->Speed());

//   //now flee away from predicted future position of the pursuer
//   return Flee(pursuer->Pos() + pursuer->Velocity() * LookAheadTime);
// }

