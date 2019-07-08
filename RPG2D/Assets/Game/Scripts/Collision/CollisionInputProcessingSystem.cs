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
            if (entity1.HasComponent<DestroyComponent>() || entity2.HasComponent<DestroyComponent>())
                return;

            if (entity1.HasComponent<WallAroundComponent>() && entity2.HasComponent<BotComponent>())
            {
                entity2.AddComponent<FrozenComponent>().Initialize(entity1.GetComponent<CountDownComponent>().time);
            }

            if (entity1.HasComponent<SkillComponent>())
            {
                Debug.Log("collision");
                var skill = entity1.GetComponent<SkillComponent>();
                switch (skill.skillType)
                {
                    case SKILL_TYPE.SIMPLE:
                        {
                            var damange = entity1.GetComponent<DamageComponent>();
                            var listTarget = new List<Entity>();
                            listTarget.Add(entity2);
                            SkillContext.CreateDamangeEntity(listTarget, damange.damage);
                            entity1.AddComponent<DestroyComponent>();
                            break;
                        }
                    case SKILL_TYPE.FIRE_BOMB:
                        {
                            var damage = entity1.GetComponent<DamageComponent>();
                            var range = entity1.GetComponent<RadiusRangeComponent>();
                            var position = entity1.GetComponent<TransformComponent>().position;
                            SkillContext.CreateExplodeEntity(damage.damage, range.radius, position);
                            entity1.AddComponent<DestroyComponent>();
                            break;
                        }
                    case SKILL_TYPE.BUBBLE_PRISON:
                        {
                            var freeze = entity1.GetComponent<FreezeComponent>();
                            var listTarget = new List<Entity>();
                            listTarget.Add(entity2);
                            SkillContext.CreateFreezeEntity(listTarget, freeze.timeFreeze);
                            SkillContext.CreatePrisonBubbleEntity(listTarget, freeze.timeFreeze);
                            entity1.AddComponent<DestroyComponent>();
                            break;
                        }
                    case SKILL_TYPE.WATER_TSUNAMI:
                        {
                            var damange = entity1.GetComponent<DamageComponent>();
                            var listTarget = new List<Entity>();
                            listTarget.Add(entity2);
                            SkillContext.CreateDamangeEntity(listTarget, damange.damage);
                            break;
                        }
                }
            }
            colliEntity.Destroy();
        }
    }
}