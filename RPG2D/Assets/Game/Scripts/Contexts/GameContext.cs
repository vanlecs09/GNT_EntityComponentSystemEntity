using Entitas;
using UnityEngine;

public static class GameContext
{
    public static void CreateMovingEntity() 
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<MoveComponent>().Initiazlize(Vector3.zero, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initiazlize(Vector3.zero, Quaternion.identity, new Vector3(1,1,1));
    }

    public static void CreatePlayerEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<MoveComponent>().Initiazlize(Vector3.zero, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initiazlize(Vector3.zero, Quaternion.identity, new Vector3(1,1,1));
        entity.AddComponent<PlayerComponent>();
    }


    public static void CreateCollisionEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<CollisionComponent>();
    }
}