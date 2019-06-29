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
                            var damange = entity1.GetComponent<DamageComponent>();
                            var listTarget = new List<Entity>();
                            listTarget.Add(entity2);
                            GameContext.CreateDamangeEntity(listTarget, damange.damage);
                            entity1.AddComponent<DestroyComponent>();
                            break;
                        }
                    case SKILL_TYPE.FIRE_SOULS:
                        {
                            var damange = entity1.Modify<DamageComponent>();
                            var listTarget = new List<Entity>();
                            listTarget.Add(entity2);
                            GameContext.CreateDamangeEntity(listTarget, damange.damage);
                            entity1.AddComponent<DestroyComponent>();
                            break;
                        }
                    case SKILL_TYPE.FIRE_BOMB:
                        {
                            var damage = entity1.GetComponent<DamageComponent>();
                            var range = entity1.GetComponent<RadiusRangeComponent>();
                            var position = entity1.GetComponent<TransformComponent>().position;
                            GameContext.CreateExplodeEntity(damage.damage, range.radius, position);
                            entity1.AddComponent<DestroyComponent>();
                            break;
                        }
                    case SKILL_TYPE.BUBBLE_PRISON:
                        {

                            var freeze = entity1.GetComponent<FreezeComponent>();
                            var listTarget = new List<Entity>();
                            listTarget.Add(entity2);
                            GameContext.CreateFreezeEntity(listTarget, freeze.timeFreeze);
                            entity1.AddComponent<DestroyComponent>();
                            break;
                        }
                }
            }
            colliEntity.Destroy();
        }
    }
}