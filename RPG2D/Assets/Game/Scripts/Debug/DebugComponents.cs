using Entitas;
using UnityEngine;
[Game, Skill]
public class DebugDrawCircleComponent : IComponent
{
    public float radius;
    public Color color;

    public void Initialize(float radius_, Color color_)
    {
        this.radius = radius_;
        this.color = color_;
    }
}

// [Game]
// public class DebugVisionComponent: IComponent
// {
//     public float radius;
//     public float limitAngle;
//     public void Initialize(float radius_, float angleLimit_)
//     {
//         this.radius = radius_;
//         this.limitAngle = angleLimit_;
//     }
// }