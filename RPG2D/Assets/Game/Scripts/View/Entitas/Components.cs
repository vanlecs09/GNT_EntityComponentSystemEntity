using UnityEngine;
using Entitas;
using Entitas.Unity;

namespace RPG.View
{
    [Game]
    public class ViewComp: IComponent {
        public GameObject gameObject;

        ~ViewComp () {
            if (gameObject != null) {
                gameObject.Unlink();
                GameObject.Destroy(gameObject);
            }
        }
    }

    [Game]
    public class TransformComp: IComponent {
        public ITransform transform;
        public Vector3 position;
        public Vector3 scale;
        public Quaternion rotation;

        // public Vector3 Position {
        //     get => transform.Position;
        //     set {
        //         transform.Position = value;
        //     }
        // }

        // public Vector3 Scale {
        //     get => transform.Scale;
        //     set {
        //         transform.Scale = value;
        //     }
        // }

        // public Quaternion Rotation {
        //     get => transform.Rotation;
        //     set {
        //         transform.Rotation = value;
        //     }
        // }

        public void Set(Vector3 position, Vector3 scale, Quaternion rotation) {
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
        }
    }
}
