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
        // return;
        foreach (var colliEntity in entities)
        {

            var entity1 = colliEntity.GetComponent<CollisionInputComponent>().from;
            var entity2 = colliEntity.GetComponent<CollisionInputComponent>().to;
            colliEntity.Destroy();
            var team1 = entity1.GetComponent<TeamComponent>().value;
            var team2 = entity2.GetComponent<TeamComponent>().value;
            if (team1 == team2) return;
            if (entity1.HasComponent<DestroyComponent>() || entity2.HasComponent<DestroyComponent>()) return;

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

                    if (debuff is DeBuffSlowComponent)
                    {
                        var debuff2 = debuff as DeBuffSlowComponent;
                        entity2.AddComponent<SlowModifierComponent>().Initialize(debuff2.value);
                    }
                }

                SkillContext.CreateDamangeEntity(entity2, attack.damage);
            }
            if (entity1.GetComponent<ImmunityCollision>() == null)
                entity1.AddComponent<DestroyComponent>();
        }
    }
}