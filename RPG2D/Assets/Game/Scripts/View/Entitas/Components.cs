using UnityEngine;
using Entitas;
using System;

namespace RPG.View
{
    [Game]
    public class ViewComponent : IComponent
    {
        [NonSerialized]
        public ITransform transform;
    }

    [Game]
    public class TransformComponent : IComponent
    {
        public Vector3 position = Vector3.zero;
        public Vector3 scale = Vector3.one;
        public Quaternion rotation = Quaternion.identity;

        public void Initialize(Vector3 position, Vector3 scale, Quaternion rotation)
        {
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
        }
    }
    
    [Game]
    public class PositionComponent : IComponent
    {
        public Vector3 value;
    }

    [Game]
    public class RotationComponent : IComponent
    {
        public Quaternion value;
    }

    [Game]
    public class ScaleComponent : IComponent
    {
        public Vector3 value;
    }
}
