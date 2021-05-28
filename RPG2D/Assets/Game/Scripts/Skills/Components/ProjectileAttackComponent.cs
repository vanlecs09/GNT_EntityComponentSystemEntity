using Entitas;
using System.Collections.Generic;
using UnityEngine;
[Game]
public class ProjectileAttackComponent : AttackComponent
{
    public float damage;
    public float range;
    public Transform fireTrans;


    public void Initialize(float range, float damage, Transform firePoint, List<BuffComponent> buffs, List<DebuffComponent> debuffs)
    {
        this.range = range;
        this.damage = damage;
        this.buffs = buffs;
        this.debuffs = debuffs;
        this.fireTrans = firePoint;
    }

    public void Clone(ProjectileAttackComponent attack)
    {
        this.damage = attack.damage;
        this.range = attack.range;
        this.debuffs = attack.debuffs;
        this.buffs = attack.buffs;
    }
}
