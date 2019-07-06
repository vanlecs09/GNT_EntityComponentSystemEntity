using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SkillContext
{
    public static void CreateFreezeEntity(List<Entity> targets, float time)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<FreezeComponent>().Initialize(time);
        entity.AddComponent<TargetsComponent>().Initialize(targets);
    }

    public static void CreatePrisonBubbleEntity(List<Entity> targets, float time)
    {
        var entity = Contexts.sharedInstance.GetContext<Skill>().CreateEntity();
        entity.AddComponent<BubblePrisonComponent>();
        entity.AddComponent<CountDownComponent>().Initialize(time);
        entity.AddComponent<TargetsComponent>().Initialize(targets);
    }
}