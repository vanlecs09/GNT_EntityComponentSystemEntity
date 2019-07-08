using Entitas;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
[Game]
public class HealthComponent : IComponent
{
    [JsonIgnore, NonSerialized]
    public ISlider Slider;
    public float current;
    public float max;
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
public class ReturnSpeedComponent: IComponent
{
    
}