using UnityEngine;
using RPG.View;
using Entitas.Unity;
namespace RPG.View
{
    public class UnityTransform : ITransform
    {
        Transform _transform;

        public UnityTransform(Transform transform)
        {
            _transform = transform;
        }

        public Vector3 Position
        {
            get => _transform.position;
            set
            {
                if (_transform != null)
                    _transform.position = value;
            }
        }

        public Vector3 Scale
        {
            get => _transform.localScale;
            set
            {
                if (_transform != null)
                    _transform.localScale = value;
            }
        }

        public Quaternion Rotation
        {
            get => _transform.rotation;
            set
            {
                if (_transform != null)
                    _transform.rotation = value;
            }
        }

        public void Destroy()
        {
            if (_transform == null)
            {
                return;
            }
            _transform.gameObject.Unlink();
            GameObject.Destroy(_transform.gameObject);
        }
    }
}

public partial class GameContextExtension
{
    public static ITransform InstantiateViewTransform()
    {
        return new UnityTransform(new GameObject().transform);
    }
}