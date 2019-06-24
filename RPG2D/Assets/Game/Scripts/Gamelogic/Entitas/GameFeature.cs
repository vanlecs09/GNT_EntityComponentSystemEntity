using Entitas;
using Entitas.VisualDebugging.Unity;
using RPG.Asset;
using RPG.View;
using RPG.Rendering;
public class GameFeature :
#if UNITY_EDITOR
FeatureObserverExt
#else
FeatureExt
#endif
{
    public GameFeature(Contexts contexts) : base("GameFeature")
    {
        Add(new AssetSystem(contexts))
        .Add(new InitializeLevelSystem())
        .Add(new JoyStickInputSystem())
        .Add(new MovementSystem())
        .Add(new MoveToTargetSystem())
        .Add(new FollowTargetSystem())
        .Add(new FollowAroundTargetSystem())
        .Add(new ViewSystem(contexts))
        .Add(new SkillCreateSystem())
        .Add(new LeaveOwnerToFollowTargetSystem())
        .Add(new SkillFireBombSystem())
        .Add(new CollisionInputProcessingSystem())

        .Add(new DamageSystem())

        // .Add(new CollisionCleanUpSystem())
        .Add(new SpriteRendererSystem(contexts))
        .Add(new TransformSystem(contexts));
        // .Add(new CameraSystem());
    }
}