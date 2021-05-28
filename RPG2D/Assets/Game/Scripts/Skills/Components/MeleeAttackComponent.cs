using System.Collections.Generic;
using Entitas;

[Game]
public class MeleeAttackComponent : AttackComponent
{
    public float damage;
    public float range;
    public void Initialize(float range, float damage, List<BuffComponent> buffs, List<DebuffComponent> debuffs)
    {
        this.range = range;
        this.damage = damage;
        this.buffs = buffs;
        this.debuffs = debuffs;
    }
}
