using UnityEngine;
using RPG.View;
using Entitas.Unity;
namespace RPG.View
{
    public class UnityTransform: ITransform {
        Transform _transform;

        public UnityTransform (Transform transform) {
            _transform = transform;
        }

        public Vector3 Position {
            get => _transform.position;
            set { _transform.position = value; }
        }

        public Vector3 Scale {
            get => _transform.localScale;
            set { _transform.localScale = value; }
        }

        public Quaternion Rotation {
            get => _transform.rotation;
            set { _transform.rotation = value; }
        }

        public void Destroy() {
            _transform.gameObject.Unlink();
            GameObject.Destroy(_transform.gameObject);
        }
    }
}

public partial class GameContextExtension {
    public static ITransform InstantiateViewTransform () {
        return new UnityTransform(new GameObject().transform);
    }
}