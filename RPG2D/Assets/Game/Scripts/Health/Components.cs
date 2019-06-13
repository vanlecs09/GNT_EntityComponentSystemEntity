using Entitas;

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
    // public Entity applyEntity;
    public void Initialize(float damage_)
    {
        this.damage = damage_;
    }
}