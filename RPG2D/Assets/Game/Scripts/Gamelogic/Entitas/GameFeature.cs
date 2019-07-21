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
        .Add(new AreaDamageSystem())
        .Add(new AreaFreezeSystem())
        .Add(new DamageWhenReachTargetSystem())
        .Add(new FreezeSystem())
        .Add(new FreezeProcessingSystem())
        // .Add(new FrozenSystem())
        .Add(new CollisionInputProcessingSystem())
        // .Add(new CollisionExitInputProcessingSystem())
        .Add(new PushBackSystem())
        .Add(new PushBackProcessingSystem())
        
        .Add(new AreaSlowDownMoveSystem())
        .Add(new AreaSlowMoveProcessingSystem())
        // .Add(new SlowDownMoveSystem())
        .Add(new SlowDownMoveProcessingSystem())

        .Add(new SlowMoveSystem())
        .Add(new SlowMovePeriodOfTimeProcessingSystem())
        .Add(new KeepSpeedProcessingSystem())
        
        .Add(new ApplyForceSystem())
        .Add(new MoveToTargetSystem())
        .Add(new FollowTargetSystem())
        .Add(new FollowAroundTargetSystem())
        .Add(new LeaveOwnerToFollowTargetSystem())
        .Add(new RandomMoveSystem())
        // .Add(new MovementSystem())
        .Add(new MoveSteeringSystem())
        
        
        .Add(new DamageSystem())
        .Add(new HealthSystem())

        .Add(new WallAroundSystem())
        .Add(new BubblePrisonProcessingSystem())

        // .Add(new CollisionCleanUpSystem())
        // rendering system
        .Add(new SpriteRendererSystem(contexts))    
        .Add(new TransformSystem(contexts))
        .Add(new MoveAnimationSystem())
        .Add(new UpdateFacingSystem())
        .Add(new AnimBubbleSytem())

        .Add(new RemoveObjectWhenOutOfMapSystem())
        .Add(new DebugDrawCircleSystem())
        .Add(new DestroySystem());
        // .Add(new CameraSystem());
    }
}