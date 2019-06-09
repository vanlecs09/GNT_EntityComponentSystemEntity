using UnityEngine;
using Entitas;

namespace RPG.Asset
{
    public abstract class AUnityViewEntityData: ScriptableObject, IViewEntityData {
        public string id;
        public GameObject prefab;

        public string GetId() => id;

        public object GetPrefab() => (object)prefab;

        public abstract Entity LoadViewEntity (); 
    }
}