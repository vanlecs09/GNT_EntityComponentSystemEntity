using System.Collections.Generic;
using Entitas;
using UnityEngine;
using RPG.View;
public class SkillContext
{
    public static void CreateFreezeEntity(Entity target, float time)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<FreezeComponent>().Initialize(time);
        entity.AddComponent<TargetComponent>().Initialize(target);
        entity.AddComponent<CountDownComponent>().Initialize(time);
    }


    public static void CreatePrisonBubbleEntity(Entity target, float time)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<BubblePrisonComponent>();
        entity.AddComponent<CountDownComponent>().Initialize(time);
        entity.AddComponent<TargetComponent>().Initialize(target);
    }

    public static void CreateAreaDamageEntity(float damage, float range, Vector3 position)
    {
        Debug.Log("create area damage");
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<AreaDamageComponent>().Initialize(damage, range);
        entity.AddComponent<ExplodeComponent>();
        entity.AddComponent<PositionComponent>().Initialize(position);
    }

    public static void CreateDamangeEntity(Entity target, float damange)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<DamageComponent>().Initialize(damange);
        entity.AddComponent<TargetComponent>().Initialize(target);
    }

    public static void CreateReturnSpeedEntity(Entity target, float time)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<CountDownComponent>().Initialize(time);
        entity.AddComponent<TargetComponent>().Initialize(target);
        entity.AddComponent<ReturnSpeedComponent>();
    }

    public static void CreateSlowDownEntity(Entity target, float time)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<CountDownComponent>().Initialize(time);
        entity.AddComponent<SlowDownMoveComponent>().Initialize(time);
        entity.AddComponent<TargetComponent>().Initialize(target);
    }

    public static void CreateKeepSpeedEntity(Entity target, float time)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<CountDownComponent>().Initialize(time);
        entity.AddComponent<KeepSpeedComponent>();
        entity.AddComponent<TargetComponent>().Initialize(target);
    }

    public static void CreateSlowEntity(Entity target, float time, float speedReduce)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<CountDownComponent>().Initialize(time);
        entity.AddComponent<SlowMoveComponent>().Initialize(speedReduce);
        entity.AddComponent<TargetComponent>().Initialize(target);
    }

    public static void CreaeteSkillWaterColdBreath(Entity ownerEntity, Vector3 position_, Vector3 direction_)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<TransformComponent>().Initialize(position_, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<OwnerComponent>().Initialize(ownerEntity);
        entity.AddComponent<TargetsComponent>().Initialize(new List<Entity>());
        // entity.AddComponent<SkillComponent>().Initialize(SKILL_TYPE.WATER_COLD_BREATH);
        entity.AddComponent<AreaSlowComponent>().Initialize(4.0f, 2.0f);
        entity.AddComponent<DebugDrawCircleComponent>().Initialize(2.0f, Color.red);
    }

    public static void CreateSkillPushBackEntity(Entity ownerEntity, float countDown_)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<OwnerComponent>().Initialize(ownerEntity);
        entity.AddComponent<PushBackComponent>();
        entity.AddComponent<CountDownComponent>().Initialize(countDown_);
        entity.AddComponent<RadiusRangeComponent>().Initialize(3.0f);
        entity.AddComponent<DebugDrawCircleComponent>().Initialize(3.0f, Color.green);
    }

    public static void RemoveSkillWaterColdBreath()
    {
        var entities = Context<Skill>.AllOf<SlowDownMoveComponent>().GetEntities();
        foreach (var entity in entities)
        {
            entity.RemoveComponent<SlowDownMoveComponent>();
            entity.Destroy();
        }
    }

}