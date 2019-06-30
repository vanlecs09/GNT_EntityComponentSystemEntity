using Entitas;
using UnityEngine;

public static class InputContext
{
    public static void CreateJoyStickEntity(Vector2 joyStickDirection)
    {
        Entity entity = Contexts.sharedInstance.GetContext<Input>().CreateEntity();
        entity.AddComponent<JoyStickInputComponent>().Initialize(joyStickDirection);
    }

    public static void CreateCollisionInputEntity(Entity from, Entity to)
    {
        Entity entity = Contexts.sharedInstance.GetContext<Input>().CreateEntity();
        entity.AddComponent<CollisionInputComponent>().Initialize(from, to);
    }

    public static void CreateCollisionExitInputEntity(Entity from, Entity to)
    {
         Entity entity = Contexts.sharedInstance.GetContext<Input>().CreateEntity();
        entity.AddComponent<CollisionExitInputComponent>().Initialize(from, to);
    }

    public static void CreateSkillEntity(SKILL_TYPE skillType)
    {
        var entity = Contexts.sharedInstance.GetContext<Input>().CreateEntity();
        entity.AddComponent<SkillComponent>().Initialize(skillType);
    }
}