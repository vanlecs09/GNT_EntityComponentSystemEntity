using System.Collections.Generic;
using Entitas;
using UnityEngine;
using RPG.View;
public class SkillContext
{
    public static void CreateFreezeEntity(List<Entity> targets, float time)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<FreezeComponent>().Initialize(time);
        entity.AddComponent<TargetsComponent>().Initialize(targets);
        entity.AddComponent<CountDownComponent>().Initialize(time);
    }

    public static void CreatePrisonBubbleEntity(List<Entity> targets, float time)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<BubblePrisonComponent>();
        entity.AddComponent<CountDownComponent>().Initialize(time);
        entity.AddComponent<TargetsComponent>().Initialize(targets);
    }

    public static void CreateExplodeEntity(float damange, float range, Vector3 position)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<DamageComponent>().Initialize(damange);
        entity.AddComponent<RadiusRangeComponent>().Initialize(range);
        entity.AddComponent<ExplodeComponent>();
        entity.AddComponent<PositionComponent>().Initialize(position);
    }

    public static void CreateDamangeEntity(List<Entity> targets, float damange)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<DamageComponent>().Initialize(damange);
        entity.AddComponent<TargetsComponent>().Initialize(targets);
    }

    public static void CreateReturnSpeedEntity(List<Entity> targets, float time)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<CountDownComponent>().Initialize(time);
        entity.AddComponent<TargetsComponent>().Initialize(targets);
        entity.AddComponent<ReturnSpeedComponent>();
    }

    public static void CreateSlowDownEntity(List<Entity> listTargets, float time)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<CountDownComponent>().Initialize(time);
        entity.AddComponent<SlowDownMoveComponent>();
        entity.AddComponent<TargetsComponent>().Initialize(listTargets);
    }
}