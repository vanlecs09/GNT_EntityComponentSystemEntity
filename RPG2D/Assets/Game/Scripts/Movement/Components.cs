using Entitas;
using UnityEngine;
using Newtonsoft.Json;



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
public class RandomComponent : IComponent
{

}

[Game]
public class RandomMoveComponent : IComponent
{
    public Vector3 velocity;
    public Vector3 acceleration;

    public void Initialize(Vector3 velocity_, Vector3 acceleration_)
    {
        this.velocity = velocity_;
        this.acceleration = acceleration_;
    }
}


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
public class SlowMoveComponent : IComponent
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
public class TakeExTraSlowDownMoveComponent : IComponent
{
    public float currentTime;
    public float limitTime;
    public void Initialize(float limitTime_)
    {
        this.currentTime = 0.0f;
        this.limitTime = limitTime_;
    }
}

[Game]
public class TakeSlowDownMoveComponent : IComponent
{
    public float rate;
    public float extraTime;
    public float currentTime;
    public float limitTime;
    public void Initialize(float limitTime_, float extraTime_)
    {
        this.currentTime = 0.0f;
        this.limitTime = limitTime_;
        this.extraTime = extraTime_;
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