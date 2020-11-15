using Entitas;

[Game, Input, Damage, Skill]
public class DamagebleComponent : IComponent
{
    public float damage;
    public void Initialize(float damage_)
    {
        this.damage = damage_;
    }
}
