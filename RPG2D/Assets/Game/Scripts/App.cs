using UnityEngine;
using Entitas;
using Entitas.VisualDebugging.Unity;

public class App : MonoBehaviour
{

    private Systems _feature;
    private void Awake()
    {
#if UNITY_EDITOR
        var contexts = Contexts.sharedInstance;
        ContextObserverHelper.ObserveAll(contexts);
#endif
    }

    private void Start()
    {
#if UNITY_EDITOR
        _feature = FeatureObserverHelper.CreateFeature(null);
#else
        _feature = new Feature(null);
#endif
        _feature.Initialize();

   
        GameContext.CreatePlayerEntity();
      
    }

    private void Update()
    {
        _feature.Execute();
        _feature.Cleanup();
    }
}