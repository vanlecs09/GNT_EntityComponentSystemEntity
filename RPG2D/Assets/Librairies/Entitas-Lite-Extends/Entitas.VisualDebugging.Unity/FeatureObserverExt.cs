using UnityEngine;
using Entitas;

namespace Entitas.VisualDebugging.Unity
{
    public class FeatureObserverExt : DebugSystems
    {
        public FeatureObserverExt(string name) : base(name)
        {
            Object.DontDestroyOnLoad(this.gameObject);
        }
    }
}