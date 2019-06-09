using Entitas;
using Entitas.VisualDebugging.Unity;
using RPG.Asset;

public class TestSceneFeature:
#if UNITY_EDITOR
FeatureObserverExt
#else
FeatureExt
#endif
{
    public TestSceneFeature (Contexts contexts, IAssetLibrary assetLibrary): base("TestScene")
    {
        Add(new TestSceneInitSystem(contexts, assetLibrary));
    }
}