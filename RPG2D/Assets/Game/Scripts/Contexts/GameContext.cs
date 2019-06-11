using Entitas;
using UnityEngine;
using RPG.View;
public static class GameContext
{
    public static void CreateMovingEntity() 
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(Vector3.zero, new Vector3(1,1,1), Quaternion.identity);
    }

    public static void CreatePlayerEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(Vector3.zero, new Vector3(1,1,1), Quaternion.identity);
        entity.AddComponent<PlayerComponent>();
    }


    public static void CreateCollisionEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<CollisionComponent>();
    }

    public static void CreateSkillEntity(Vector3 fromPosition, Vector3 direction_)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/Skill_1");
        entity.AddComponent<SkillComponent>();
        entity.AddComponent<MoveComponent>().Initialize(direction_* 2, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(fromPosition, new Vector3(1,1,1), Quaternion.identity);
    }

    public static void CreateSkillFireEntity(Vector3 fromPosition, Vector3 direction_)
    {
          var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/Skill_1");
        entity.AddComponent<SkillComponent>();
        entity.AddComponent<MoveComponent>().Initialize(direction_* 10, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(fromPosition, new Vector3(1,1,1), Quaternion.identity);
    }

    public static void CreateBotEntity()
    {

    }
}