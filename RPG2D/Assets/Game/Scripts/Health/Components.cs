using Entitas;
using System.Collections.Generic;
using Newtonsoft.Json;
[Game]
public class HealthComponent : IComponent
{
    public float currentHealth;
    public float maxHealth;
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