using Entitas;
using UnityEngine;

public static class InputContext
{
    public static void CreateJoyStickEntity(Vector2 joyStickDirection) 
    {
        Entity entity = Contexts.sharedInstance.GetContext<Input>().CreateEntity();
        entity.AddComponent<JoyStickInputComponent>().Initialize(joyStickDirection);
    }
}