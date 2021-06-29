using Entitas;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
[Game]
public class HealthComponent : IComponent
{
    public float current = 1;
    public float max = 1;
    public void Initialize(float max)
    {
        this.max = max;
        this.current = max;
    }
}

[Game]
public class HeathViewComponent : IComponent
{
    [JsonIgnore, NonSerialized]
    public ISlider Slider;
}

[Game]
public class ManaCoponent : IComponent
{
    [JsonIgnore, NonSerialized]
    public ISlider Slider;
    public float current;
    public float max;
}

[Game, Input, Damage, Skill]
public class DamageComponent : IComponent
{
    public float damage;
    public void Initialize(float damage_)
    {
        this.damage = damage_;
    }
}

[Game, Skill]
public class AreaDamageComponent : IComponent
{
    public float damage;
    public float radius;
    public void Initialize(float damage_, float radius_)
    {
        this.damage = damage_;
        this.radius = radius_;
    }
}


[Damage, Skill]
public class TargetsComponent : IComponent
{
    [JsonIgnore]
    public List<Entity> listEntityTarget;
    public void Initialize(List<Entity> targets)
    {
        listEntityTarget = targets;
    }
}

[Game, Skill]
public class TargetComponent : IComponent
{
    [JsonIgnore]
    public Entity targetEntity;
    public void Initialize(Entity targetEntity_)
    {
        this.targetEntity = targetEntity_;
    }
}

[Game, Skill]
public class ReturnSpeedComponent : IComponent
{

}