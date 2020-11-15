using Entitas;
using UnityEngine;
[Game]
public class PlayerComponent: IComponent
{

}

[Game]
public class DirectionComponent: IComponent
{
    public Vector3 value;
    public void Initialize(Vector3 dir) {
        value = dir;
    }
}

[Game, Skill]
public class DestroyComponent: IComponent
{
}