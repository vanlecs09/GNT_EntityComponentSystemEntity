using Entitas;
[Game]
public class SkillAttackComponent : IComponent
{
    public float damage;
    public float range;
    public void Initialize(float range, float damage)
    {
        this.range = range;
        this.damage = damage;
    }
}
