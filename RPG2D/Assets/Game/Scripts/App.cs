using UnityEngine;
using Entitas;
using Entitas.VisualDebugging.Unity;
using RPG.View;

public class App : MonoBehaviour
{
    private Contexts _contexts;
    private Systems _feature;
    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
#if UNITY_EDITOR
        ContextObserverHelper.ObserveAll(_contexts);
#endif
    }

    private void Start()
    {
        _feature = new FeatureObserverExt("Game Feature")
        .Add(new TestViewFeature(_contexts));

        _feature.Initialize();
    }

    private void Update()
    {
        _feature.Execute();
        _feature.Cleanup();
    }
}