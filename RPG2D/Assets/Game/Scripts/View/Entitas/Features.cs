using Entitas;
using Entitas.VisualDebugging.Unity;
using RPG.View;

public class ViewFeature:
#if UNITY_EDITOR
FeatureObserverExt
#else
FeatureExt
#endif
{
    public ViewFeature (Contexts contexts): base("ViewFeature")
    {
        Add(new ViewSystem(contexts));
        Add(new TransformSystem(contexts));
    }
}

public class TestViewFeature:
#if UNITY_EDITOR
FeatureObserverExt
#else
FeatureExt
#endif
{
    public TestViewFeature(Contexts contexts): base("TestViewFeature")
    {
        Add(new TestViewSystem(contexts));
    }
}