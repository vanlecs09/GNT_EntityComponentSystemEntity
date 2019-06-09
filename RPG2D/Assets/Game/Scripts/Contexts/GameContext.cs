using Entitas;
using UnityEngine;
using RPG.View;
public static class GameContext
{
    public static void CreateMovingEntity() 
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<MoveComponent>().Initiazlize(Vector3.zero, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(Vector3.zero, new Vector3(1,1,1), Quaternion.identity);
    }

    public static void CreatePlayerEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<MoveComponent>().Initiazlize(Vector3.zero, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(Vector3.zero, new Vector3(1,1,1), Quaternion.identity);
        entity.AddComponent<PlayerComponent>();
    }


    public static void CreateCollisionEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<CollisionComponent>();
    }
}