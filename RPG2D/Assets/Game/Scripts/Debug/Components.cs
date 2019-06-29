using Entitas;
using UnityEngine;
[Game]
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