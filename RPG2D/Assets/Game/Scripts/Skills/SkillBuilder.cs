
using CleverCrow.Fluid.BTs.Trees;
using CleverCrow.Fluid.BTs.Tasks;
using Entitas;
using UnityEngine;
using RPG.View;
using RPG.Rendering;

public static class SkillBuilder
{
    public static void CreateProjectileAttack(Entity entity, GameObject gameObject)
    {
        entity.AddComponent<CountDownComponent>().Initialize(0.5f);
        var projectileAttack = entity.AddComponent<ProjectileAttackComponent>();
        projectileAttack.Initialize(5.0f, 1.0f, gameObject.transform.Find("FirePoint").transform.position);
        var intervalDamageDebuff = new IntervalDamageComponent();
        intervalDamageDebuff.Initialize(0.2f, 10, 0.2f);
        projectileAttack.debuffs.Add(intervalDamageDebuff);
        var slowDebuff = new SlowBuffComponent();
        slowDebuff.Initialize(1);
        projectileAttack.debuffs.Add(slowDebuff);
    }

    public static void CreateMeleeAttack(Entity entity, GameObject gameObject)
    {
        entity.AddComponent<CountDownComponent>().Initialize(0.5f);
        entity.AddComponent<MeleeAttackComponent>().Initialize(0.5f, 2.0f);
    }

    public static void CreateAttack(Entity entity, GameObject gameObject)
    {
        if (entity.HasComponent<AttackProjectileTypeComonent>())
        {
            SkillBuilder.CreateProjectileAttack(entity, gameObject);
        } else if (entity.HasComponent<AttackMeleeTypeComponent>())
        {
            SkillBuilder.CreateMeleeAttack(entity, gameObject);
        } else {
            SkillBuilder.CreateMeleeAttack(entity, gameObject);
        }

    }
}