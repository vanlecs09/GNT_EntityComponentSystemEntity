using Entitas;
using UnityEngine;

[Input]
public class JoyStickInputComponent: IComponent
{
    public Vector2 joyStickDirection;
    public void Initialize(Vector2 joyStickDirection_)
    {
        this.joyStickDirection = joyStickDirection_;
    }
}