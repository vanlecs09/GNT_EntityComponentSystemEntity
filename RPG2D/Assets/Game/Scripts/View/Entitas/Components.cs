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

    [Game, Skill]
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

    [Game, Skill]
    public class PositionComponent : IComponent
    {
        public Vector3 value;
        public void Initialize(Vector3 position)
        {
            this.value = position;
        }
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

    public struct TransformData
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        public TransformData(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }
    }


    [Game]
    public class InterpolateTransformComponent : IComponent
    {
        public TransformData[] m_lastTransforms;
        public int m_newTransformIndex;

        public void Initialize(TransformComponent transComponent)
        {
            m_lastTransforms = new TransformData[2];
            TransformData t = new TransformData(transComponent.position, transComponent.rotation, transComponent.scale);
            m_lastTransforms[0] = t;
            m_lastTransforms[1] = t;
            m_newTransformIndex = 0;
        }
    }
}
