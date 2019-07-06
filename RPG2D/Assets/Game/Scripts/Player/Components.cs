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
}

[Game, Skill]
public class DestroyComponent: IComponent
{
}