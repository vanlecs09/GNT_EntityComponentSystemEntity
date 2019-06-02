using UnityEngine;

namespace RPG.View
{
    public interface ITransform {
        Vector3 Position {get;set;}
        Vector3 Scale {get;set;}
        Quaternion Rotation {get;set;}
    }
}