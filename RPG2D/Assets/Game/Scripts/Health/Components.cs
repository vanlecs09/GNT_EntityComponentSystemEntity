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

[Game, Input]
public class DamageComponent : IComponent
{
    public float damage;
    [JsonIgnore]
    public List<Entity> listEntityTarget;
    public void Initialize(float damage_)
    {
        this.damage = damage_;
        listEntityTarget = new List<Entity>();
    }
}