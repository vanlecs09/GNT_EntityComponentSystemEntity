using UnityEngine;
using Entitas;
using Entitas.VisualDebugging.Unity;

public class App : MonoBehaviour
{
    private Contexts _contexts;
    private Systems _feature;

    private Systems _fixedUpdateFeature;

    long m_LastTick;
    uint    m_FrameTick;
    static float   m_Delta;
    public static float GetDeltaTime()
    {
        return m_Delta;
    }

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
#if UNITY_EDITOR
        ContextObserverHelper.ObserveAll(_contexts);
#endif
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        // QualitySettings.vSyncCount = 0;
#if UNITY_EDITOR
        _feature = new FeatureObserverExt("Game Features")
#else
        _feature = new FeatureExt("Game Features")
#endif
       .Add(new GameFeature(_contexts));
        _feature.Initialize();


#if UNITY_EDITOR
        _fixedUpdateFeature = new FeatureObserverExt("Fixed Update Features")
#else
        _fixedUpdateFeature = new FeatureExt("Fixed Update Features")
#endif
        .Add(new FixedUpdateFeature(_contexts));

        _fixedUpdateFeature.Initialize();
    }
    private void Update()
    {
        _feature.Execute();
        _feature.Cleanup();
    }

    private void FixedUpdate()
    {
        _fixedUpdateFeature.Execute();
    }
}