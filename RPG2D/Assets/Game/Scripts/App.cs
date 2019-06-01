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


        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<MoveComponent>().Initiazlize(new Vector3(1,1,1), Vector3.zero);
        entity.AddComponent<TransformComponent>().Initiazlize(Vector3.zero, Quaternion.identity, new Vector3(1,1,1));
    }

    private void Update()
    {
        _feature.Execute();
        _feature.Cleanup();
    }
}