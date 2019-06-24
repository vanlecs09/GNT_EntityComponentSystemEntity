using Entitas;
using Entitas.VisualDebugging.Unity;
using RPG.View;
using RPG.Rendering;
public class FixedUpdateFeature :
#if UNITY_EDITOR
FeatureObserverExt
#else
FeatureExt
#endif
{
    public FixedUpdateFeature(Contexts contexts) : base("FixedUpdateFeature")
    {

        // Add(new MovementSystem())
        // .Add(new TransformSystem(contexts));
    }
}