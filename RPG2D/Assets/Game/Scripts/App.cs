using UnityEngine;
using Entitas;
using Entitas.VisualDebugging.Unity;
using RPG.View;
using RPG.Asset;

public class App : MonoBehaviour
{
    public UnityAssetLibrary assetLibrary;

    private Contexts _contexts;
    private Systems _feature;
    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
#if UNITY_EDITOR
        ContextObserverHelper.ObserveAll(_contexts);
#endif
        assetLibrary.GenerateGameEntityDictionary();
    }

    private void Start()
    {
        #if UNITY_EDITOR
        _feature = new FeatureObserverExt("Game Features")
        #else
        _feature = new FeatureExt("Game Features")
        #endif
        .Add(new TestSceneFeature(_contexts, assetLibrary))
        .Add(new ViewFeature(_contexts));

        _feature.Initialize();
    }

    private void Update()
    {
        _feature.Execute();
        _feature.Cleanup();
    }
}