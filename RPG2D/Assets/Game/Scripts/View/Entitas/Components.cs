using UnityEngine;
using Entitas;
using Entitas.Unity;

namespace RPG.View
{
    [Game]
    public class ViewComp: IComponent {
        public ITransform transform;
    }

    [Game]
    public class TransformComp: IComponent {
        public Vector3 position = Vector3.zero;
        public Vector3 scale = Vector3.one;
        public Quaternion rotation = Quaternion.identity;

        public void Initialize(Vector3 position, Vector3 scale, Quaternion rotation) {
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
        }
    }

    [Game]
    public class PositionComp: IComponent {
        public Vector3 value;
    }

    [Game]
    public class RotationComp: IComponent {
        public Quaternion value;
    }

    [Game]
    public class ScaleComp: IComponent {
        public Vector3 value;
    }
}
