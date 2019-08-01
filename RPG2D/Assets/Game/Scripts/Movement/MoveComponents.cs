using Entitas;
using UnityEngine;
using Newtonsoft.Json;

[Game]
public class SteeringBehaviorComponent : IComponent
{
    public enum BehaviorTypes
    {
        none = 0x00000,
        seek = 0x00002,
        flee = 0x00004,
        arrive = 0x00008,
        wander = 0x00010,
        cohesion = 0x00020,
        separation = 0x00040,
        allignment = 0x00080,
        obstacle_avoidance = 0x00100,
        wall_avoidance = 0x00200,
        follow_path = 0x00400,
        pursuit = 0x00800,
        evade = 0x01000,
        interpose = 0x02000,
        hide = 0x04000,
        flock = 0x08000,
        offset_pursuit = 0x10000,
        linear = 0x10002,
    };

    public Vector3 steeringForce;
    public Vector3 vTarget;

    [JsonIgnore]
    public Entity targetEntity;
    public int Flag;
    public bool On(BehaviorTypes bt) { return (this.Flag & (int)bt) == (int)bt; }
    public void FleeOn() { this.Flag |= (int)BehaviorTypes.flee; }
    public void SeekOn() { this.Flag |= (int)BehaviorTypes.seek; }
    public void ArriveOn() { this.Flag |= (int)BehaviorTypes.arrive; }
    public void WanderOn() { this.Flag |= (int)BehaviorTypes.wander; }
    public bool IsSeekOn() { return On(BehaviorTypes.seek); }
    public void PursuitOn(Entity targetEntity_) { this.Flag |= (int)BehaviorTypes.pursuit; targetEntity = targetEntity_; }
    public void EvadeOn(Entity v) { this.Flag |= (int)BehaviorTypes.evade; targetEntity = v; }
    // public void CohesionOn() { this.Flag |= (int)BehaviorTypes.cohesion; }
    // public void SeparationOn() { this.Flag |= (int)BehaviorTypes.separation; }
    // public void AlignmentOn() { this.Flag |= (int)BehaviorTypes.allignment; }
    // public void ObstacleAvoidanceOn() { this.Flag |= (int)BehaviorTypes.obstacle_avoidance; }
    // public void WallAvoidanceOn() { this.Flag |= (int)BehaviorTypes.wall_avoidance; }
    // public void FollowPathOn() { this.Flag |= (int)BehaviorTypes.follow_path; }
    // // void InterposeOn(MovingEntity v1, MovingEntity v2){this.Flag |= (int)BehaviorTypes.interpose; m_pTargetAgent1 = v1; m_pTargetAgent2 = v2;}
    // // void HideOn(MovingEntity v){this.Flag |= (int)BehaviorTypes.hide; m_pTargetAgent1 = v;}
    // // public void OffsetPursuitOn(MovingEntity v1, Vector3 offset) { this.Flag |= (int)BehaviorTypes.offset_pursuit; m_vOffset = offset; m_pTargetAgent1 = v1; }
    // // void FlockingOn(){CohesionOn(); AlignmentOn(); SeparationOn(); WanderOn();}

    public void LinearOn() { this.Flag |= (int)BehaviorTypes.linear; }

    // public void FleeOff() { if (On(BehaviorTypes.flee)) this.Flag ^= (int)BehaviorTypes.flee; }
    public void SeekOff() { if (On(BehaviorTypes.seek)) this.Flag ^= (int)BehaviorTypes.seek; }
    // public void ArriveOff() { if (On(BehaviorTypes.arrive)) this.Flag ^= (int)BehaviorTypes.arrive; }
    // public void WanderOff() { if (On(BehaviorTypes.wander)) this.Flag ^= (int)BehaviorTypes.wander; }
    public void PursuitOff() { if (On(BehaviorTypes.pursuit)) this.Flag ^= (int)BehaviorTypes.pursuit; }
    public void EvadeOff() { if (On(BehaviorTypes.evade)) this.Flag ^= (int)BehaviorTypes.evade; }
    // public void CohesionOff() { if (On(BehaviorTypes.cohesion)) this.Flag ^= (int)BehaviorTypes.cohesion; }
    // public void SeparationOff() { if (On(BehaviorTypes.separation)) this.Flag ^= (int)BehaviorTypes.separation; }
    // public void AlignmentOff() { if (On(BehaviorTypes.allignment)) this.Flag ^= (int)BehaviorTypes.allignment; }
    // public void ObstacleAvoidanceOff() { if (On(BehaviorTypes.obstacle_avoidance)) this.Flag ^= (int)BehaviorTypes.obstacle_avoidance; }
    // public void WallAvoidanceOff() { if (On(BehaviorTypes.wall_avoidance)) this.Flag ^= (int)BehaviorTypes.wall_avoidance; }
    // public void FollowPathOff() { if (On(BehaviorTypes.follow_path)) this.Flag ^= (int)BehaviorTypes.follow_path; }
    // public void InterposeOff() { if (On(BehaviorTypes.interpose)) this.Flag ^= (int)BehaviorTypes.interpose; }
    // public void HideOff() { if (On(BehaviorTypes.hide)) this.Flag ^= (int)BehaviorTypes.hide; }
    // public void OffsetPursuitOff() { if (On(BehaviorTypes.offset_pursuit)) this.Flag ^= (int)BehaviorTypes.offset_pursuit; }
    // public void FlockingOff() { CohesionOff(); AlignmentOff(); SeparationOff(); WanderOff(); }
    public void LinearOff()  { if (On(BehaviorTypes.linear)) this.Flag ^= (int)BehaviorTypes.linear; }

    public bool isFleeOn() { return On(BehaviorTypes.flee); }

    public bool isArriveOn() { return On(BehaviorTypes.arrive); }
    public bool isWanderOn() { return On(BehaviorTypes.wander); }
    public bool isPursuitOn() { return On(BehaviorTypes.pursuit); }
    public bool isEvadeOn() { return On(BehaviorTypes.evade); }
    public bool isCohesionOn() { return On(BehaviorTypes.cohesion); }
    public bool isSeparationOn() { return On(BehaviorTypes.separation); }
    public bool isAlignmentOn() { return On(BehaviorTypes.allignment); }
    public bool isObstacleAvoidanceOn() { return On(BehaviorTypes.obstacle_avoidance); }
    public bool isWallAvoidanceOn() { return On(BehaviorTypes.wall_avoidance); }
    public bool isFollowPathOn() { return On(BehaviorTypes.follow_path); }
    public bool isInterposeOn() { return On(BehaviorTypes.interpose); }
    public bool isHideOn() { return On(BehaviorTypes.hide); }
    public bool isOffsetPursuitOn() { return On(BehaviorTypes.offset_pursuit); }
    public bool isLinearOn() { return On(BehaviorTypes.linear);}

    public void Initialize()
    {
        this.Flag = 0;
        this.vTarget = Vector3.zero;
        this.targetEntity = null;
    }
}

[Game]
public class MoveComponent : IComponent
{
    public Vector3 direction;
    public Vector3 velocity;
    public Vector3 acceleration;
    public float speed;
    public float maxSpeed;

    public void Initialize(Vector3 velocity_, Vector3 acceleration_, float speed_, Vector3 direction_)
    {
        this.velocity = velocity_;
        this.acceleration = acceleration_;
        this.speed = speed_;
        this.maxSpeed = speed_;
        this.direction = direction_;
    }
}

[Game]
public class ApplyForceComponent : IComponent
{
    public Vector3 value;
    public void Initialize(Vector3 value_)
    {
        this.value = value_;
    }
}

[Game]
public class RandomMoveComponent : IComponent
{

}

// [Game]
// public class RandomMoveComponent : IComponent
// {
//     public Vector3 velocity;
//     public Vector3 acceleration;

//     public void Initialize(Vector3 velocity_, Vector3 acceleration_)
//     {
//         this.velocity = velocity_;
//         this.acceleration = acceleration_;
//     }
// }


[Game, Skill]
public class OwnerComponent : IComponent
{
    public Entity value;
    public void Initialize(Entity owner_)
    {
        this.value = owner_;
    }
}


[Game, Skill]
public class FollowTargetComponent : IComponent
{
    public Entity targetEntity;
    public Vector3 offset;

    public void Initialize(Entity targetEntity_, Vector3 offset_)
    {
        this.targetEntity = targetEntity_;
        this.offset = offset_;
    }
}


[Game, Skill]
public class AreaSlowComponent : IComponent
{
    public float radius;
    public float currentTime;
    public float limitTime;
    public void Initialize(float limitTime_, float radius_)
    {
        this.currentTime = 0.0f;
        this.limitTime = limitTime_;
        this.radius = radius_;
    }
}

[Game, Skill]
public class KeepSpeedComponent : IComponent
{

}

[Game, Skill]
public class SlowDownMoveComponent : IComponent
{
    public float rate;
    public float currentTime;
    public float limitTime;
    public void Initialize(float limitTime_)
    {
        this.currentTime = 0.0f;
        this.limitTime = limitTime_;
        this.rate = 0.0f;
    }
}



[Game]
public class FollowAroundTargetComponent : IComponent
{
    [JsonIgnore]
    public Entity targetEntity;
    public Vector3 offset;
    public float spinSpeed;

    public float currentAngle;

    public void Initialize(Entity targetEntity_, Vector3 offset_, float spinSpeed_, float angle_)
    {
        this.targetEntity = targetEntity_;
        this.offset = offset_;
        this.spinSpeed = spinSpeed_;
        this.currentAngle = angle_;
    }
}