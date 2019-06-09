using Entitas;
using UnityEngine;

public static class InputContext
{
    public static void CreateJoyStickEntity(Vector2 joyStickDirection) 
    {
        Entity entity = Contexts.sharedInstance.GetContext<Input>().CreateEntity();
        entity.AddComponent<JoyStickInputComponent>().Initialize(joyStickDirection);
    }

    public static void CreateCollisionInputEntity(string name)
    {
        Entity entity = Contexts.sharedInstance.GetContext<Input>().CreateEntity();
        entity.AddComponent<CollisionInputComponent>().Initialize(null, null);
    }
}