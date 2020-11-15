using Entitas;
using System.Collections.Generic;
using UnityEngine;
[Game]
public class ProjectileAttackComponent : AttackComponent
{
    public float damage;
    public float range;
    public Vector3 firePoint;

    public List<DebuffComponent> debuffs;
    public void Initialize(float range, float damage, Vector3 firePoint)
    {
        this.range = range;
        this.damage = damage;
        this.debuffs = new List<DebuffComponent>();
        this.firePoint = firePoint;
    }

    public void Clone(ProjectileAttackComponent attack)
    {
        this.damage = attack.damage;
        this.range = attack.range;
        this.debuffs = attack.debuffs;
    }
}
