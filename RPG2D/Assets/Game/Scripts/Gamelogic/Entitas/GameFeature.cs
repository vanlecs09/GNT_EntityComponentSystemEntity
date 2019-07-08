using Entitas;
using Entitas.VisualDebugging.Unity;
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
        // .Add(new InitializeLevelSystem())
        .Add(new JoyStickInputSystem())


        .Add(new ViewSystem(contexts))
        .Add(new SkillCreateSystem())
        .Add(new AreaExplodeSystem())
        .Add(new AreaFreezeSystem())
        .Add(new DamageWhenReachTargetSystem())
        .Add(new FreezeSystem())
        .Add(new FreezeProcessingSystem())
        // .Add(new FrozenSystem())
        .Add(new CollisionInputProcessingSystem())
        .Add(new CollisionExitInputProcessingSystem())
        .Add(new ColdBreathProcessingSystem())

        
        .Add(new MoveToTargetSystem())
        .Add(new FollowTargetSystem())
        .Add(new FollowAroundTargetSystem())
        .Add(new LeaveOwnerToFollowTargetSystem())
        .Add(new RandomMoveSystem())
        .Add(new MovementSystem())
        .Add(new SlowDownMoveSystem())
        
        .Add(new DamageSystem())
        .Add(new HealthSystem())

        .Add(new WallAroundSystem())
        .Add(new BubblePrisonProcessingSystem())

        // .Add(new CollisionCleanUpSystem())
        .Add(new SpriteRendererSystem(contexts))    
        .Add(new TransformSystem(contexts))
        .Add(new MoveAnimationSystem())
        .Add(new UpdateFacingSystem())

        .Add(new AnimBubbleSytem())

        .Add(new DebugDrawCircleSystem())
        .Add(new DestroySystem());
        // .Add(new CameraSystem());
    }
}