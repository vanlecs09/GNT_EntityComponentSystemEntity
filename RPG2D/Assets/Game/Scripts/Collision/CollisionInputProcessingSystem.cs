using Entitas;
using System.Collections.Generic;
using UnityEngine;
public class CollisionInputProcessingSystem : ReactiveSystem
{
    public CollisionInputProcessingSystem()
    {
        monitors += Context<Input>.AllOf<CollisionInputComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
        Debug.Log("colliison");
        foreach (var colliEntity in entities)
        {
            var entity1 = colliEntity.GetComponent<CollisionInputComponent>().from;
            var entity2 = colliEntity.GetComponent<CollisionInputComponent>().to;
            if (entity1.HasComponent<DestroyComponent>() || entity2.HasComponent<DestroyComponent>())
                return;
            if (entity1.HasComponent<SkillComponent>())
            {
                var skill = entity1.GetComponent<SkillComponent>();
                switch (skill.skillType)
                {
                    case SKILL_TYPE.SIMPLE:
                        {
                            var damange = entity1.Modify<DamageComponent>();
                            damange.listEntityTarget.Add(entity2);
                            entity1.AddComponent<DestroyComponent>();
                            break;
                        }
                    case SKILL_TYPE.FIRE_SOULS:
                        {
                            var damange = entity1.Modify<DamageComponent>();
                            damange.listEntityTarget.Add(entity2);
                            entity1.AddComponent<DestroyComponent>();
                            break;
                        }
                    case SKILL_TYPE.FIRE_BOMB:
                        {
                            entity1.Add<TriggerComponent>();
                            break;
                        }
                    case SKILL_TYPE.BUBBLE_PRISON:
                        {
                            var freeze = entity1.Modify<FreezeComponent>();
                            freeze.targetEntities.Add(entity2);
                            entity1.Add<TriggerComponent>();
                            break;
                        }
                }
            }
            colliEntity.Destroy();
        }
    }
}