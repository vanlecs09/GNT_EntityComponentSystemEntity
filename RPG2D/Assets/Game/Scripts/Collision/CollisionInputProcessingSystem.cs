using Entitas;
using System.Collections.Generic;
using UnityEngine;
using RPG.View;
public class CollisionInputProcessingSystem : ReactiveSystem
{
    public CollisionInputProcessingSystem()
    {
        monitors += Context<Input>.AllOf<CollisionInputComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var colliEntity in entities)
        {

            var entity1 = colliEntity.GetComponent<CollisionInputComponent>().from;
            var entity2 = colliEntity.GetComponent<CollisionInputComponent>().to;
            colliEntity.Destroy();
            var team1 = entity1.GetComponent<TeamComponent>().value;
            var team2 = entity2.GetComponent<TeamComponent>().value;
            if (team1 == team2) return;
            if (entity1.HasComponent<DestroyComponent>() || entity2.HasComponent<DestroyComponent>()) return;
            Debug.Log("input processing");

            if (entity1.HasComponent<ProjectileAttackComponent>())
            {
                var attack = entity1.GetComponent<ProjectileAttackComponent>();
                foreach (var debuff in attack.debuffs)
                {
                    if (debuff is IntervalDamageComponent)
                    {
                        var debuff2 = debuff as IntervalDamageComponent;
                        entity2.AddComponent<IntervalDamageComponent>().Initialize(debuff2);
                    }

                    if (debuff is SlowBuffComponent)
                    {
                        var debuff2 = debuff as SlowBuffComponent;
                        entity2.AddComponent<SlowModifierComponent>().Initialize(debuff2.value);
                    }
                }

                SkillContext.CreateDamangeEntity(entity2, attack.damage);
            }

            // if (entity1.HasComponent<DamagebleComponent>())
            // {
            //     var damage = entity1.GetComponent<DamagebleComponent>();
            //     SkillContext.CreateDamangeEntity(entity2, damage.damage);
            // }

            // if (entity1.HasComponent<AreaDamageComponent>())
            // {
            //     var pos = entity1.GetComponent<TransformComponent>().position;
            //     var areaDamage = entity1.GetComponent<AreaDamageComponent>();
            //     SkillContext.CreateAreaDamageEntity(areaDamage.damage, areaDamage.radius, pos);
            // }


            // if (entity1.HasComponent<SlowMoveComponent>())
            // {
            //     var slow = entity1.GetComponent<SlowMoveComponent>();
            //     var coutDown = entity1.GetComponent<CountDownComponent>();
            //     SkillContext.CreateSlowEntity(entity2, coutDown.time, slow.speedToReduce);
            // }

            // if (entity1.HasComponent<FreezeComponent>())
            // {
            //     var freeze = entity1.GetComponent<FreezeComponent>();
            //     SkillContext.CreateFreezeEntity(entity2, freeze.timeFreeze);
            // }

            // if (entity1.HasComponent<BubblePrisonComponent>())
            // {
            //     var bublePrison = entity1.GetComponent<BubblePrisonComponent>();
            //     SkillContext.CreatePrisonBubbleEntity(entity2, bublePrison.time);
            // }
            if (entity1.GetComponent<ImmunityCollision>() == null)
                entity1.AddComponent<DestroyComponent>();
            // colliEntity.Destroy();
        }
    }
}