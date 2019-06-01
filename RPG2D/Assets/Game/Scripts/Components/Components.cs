using Entitas;
using UnityEngine;

public class TransformComponent: IComponent
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
}

public class InputCompoment: IUniqueComponent
{
    public bool mouseDown;
    public bool mouseUp;
}