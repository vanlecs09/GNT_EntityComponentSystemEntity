using Entitas;

[Game]
public class MeleeAttackComponent : AttackComponent
{
    public float damage;
    public float range;
    public void Initialize(float range, float damage)
    {
        this.range = range;
        this.damage = damage;
    }
}
