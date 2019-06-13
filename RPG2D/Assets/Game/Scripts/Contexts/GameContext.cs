using Entitas;
using UnityEngine;
using RPG.View;
public static class GameContext
{
    public static void CreateMovingEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(Vector3.zero, new Vector3(1, 1, 1), Quaternion.identity);
    }

    public static void CreatePlayerEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(Vector3.zero, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<PlayerComponent>();
    }


    public static void CreateCollisionEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<CollisionComponent>();
    }

    public static void CreateSkillSimpleEntity(Vector3 position, Vector3 direction_)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/Skill_1");
        entity.AddComponent<SkillComponent>();
        entity.AddComponent<TransformComponent>().Initialize(position, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<MoveComponent>().Initialize(direction_ * 2, Vector3.zero);
    }

    public static void CreateSkillFireEntity(Entity targetEntity_, Vector3 offsetToTarget)
    {
        var numerEntity = 3;
        for (var i = 0; i < numerEntity; i++)
        {
            var targetPosition = targetEntity_.GetComponent<TransformComponent>().position;
            var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
            entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/Skill_1");
            entity.AddComponent<SkillFireComponent>();
            entity.AddComponent<FollowAroundTargetComponent>().Initialize(targetEntity_, new Vector3(1, 0, 1), 50.0f, 360.0f/numerEntity * i);
            entity.AddComponent<TransformComponent>().Initialize(targetPosition - offsetToTarget, new Vector3(1, 1, 1), Quaternion.identity);
        }
    }

    public static void CreateBotEntity()
    {

    }
}