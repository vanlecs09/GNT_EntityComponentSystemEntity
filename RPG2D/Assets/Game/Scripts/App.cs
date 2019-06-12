using UnityEngine;
using Entitas;
using Entitas.VisualDebugging.Unity;
using RPG.View;
using RPG.Asset;

public class App : MonoBehaviour
{
    // public UnityAssetLibrary assetLibrary;

    private Contexts _contexts;
    private Systems _feature;
    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
#if UNITY_EDITOR
        ContextObserverHelper.ObserveAll(_contexts);
#endif
        // assetLibrary.GenerateGameEntityDictionary();

        // GameContext.CreatePlayerEntity();
    }

    private void Start()
    {

        // _feature =  new Feature("Systems")
        #if UNITY_EDITOR
        _feature = new FeatureObserverExt("Game Features")
        #else
        _feature = new FeatureExt("Game Features")
        #endif
       .Add(new TestFeature(_contexts));
        _feature.Initialize();

        for(var i = 0; i < 10000 ;i++)
        {
            TestContext.CreateTestEntity1();
            TestContext.CreateTestEntity2();
            TestContext.CreateTestEntity3();
        }
    }

    private void Update()
    {
        _feature.Execute();
        _feature.Cleanup();
    }
}