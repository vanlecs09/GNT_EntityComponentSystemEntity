using Entitas;
using System.Collections.Generic;
using UnityEngine;
using Entitas.Unity;
using RPG.View;
using RPG.Rendering;
using UnityEngine.UI;
using CleverCrow.Fluid.BTs.Trees;
using SWS;
public class AssetSystem : ReactiveSystem
{
    Context _gameContext;
    public AssetSystem(Contexts contexts)
    {
        monitors += Context<Game>.AllOf<AssetComponent>().OnAdded(Process);
        _gameContext = contexts.GetContext("Game");
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var assetName = entity.GetComponent<AssetComponent>().assetName;
            var assetObject = Resources.Load<GameObject>(assetName);
            var layerMask = entity.GetComponent<AssetComponent>().layerMask;

            if (assetObject != null)
            {
                var gameObject = GameObject.Instantiate(assetObject);
                gameObject.Link(entity, _gameContext);
                entity.Add<ViewComponent>().transform = new UnityTransform(gameObject.transform);
                if (entity.HasComponent<TransformComponent>())
                    entity.Modify<TransformComponent>();
                var unityCompoenntCache = gameObject.GetComponent<UnityComponentsCache>();
                if (unityCompoenntCache)
                {
                    if (unityCompoenntCache.HasSpriteRenderer())
                    {
                        var spriteRendererComp = entity.Add<SpriteRendererComponent>();
                        spriteRendererComp.spriteRenderer = unityCompoenntCache.GetSpriteRender();
                        spriteRendererComp.color = Color.white;
                    }

                    if (unityCompoenntCache.HasAnimator())
                    {
                        var animatorComp = entity.Add<AnimatorComponent>();
                        animatorComp.value = unityCompoenntCache.GetAnimator();
                    }
                }


                if (entity.HasComponent<SteeringBehaviorComponent>())
                {
                    var steering = entity.GetComponent<SteeringBehaviorComponent>();
                    steering.Initialize();
                    if (entity.HasComponent<PlayerComponent>())
                        steering.SeekOn();
                }

                if (entity.Has<HealthComponent>() && entity.Has<PlayerComponent>())
                {
                    var healthSlider = GameObject.Find("health_bar").GetComponent<Slider>();
                    var health = entity.Modify<HealthComponent>();
                    health.Slider = new UnitySlider(healthSlider);

                }

                if (entity.Has<HealthComponent>() && entity.Has<BotComponent>())
                {
                    var children = gameObject.GetComponentsInChildren<Transform>();
                    foreach (var child in children)
                        if (child.name == "fill_area")
                        {
                            var health = entity.Modify<HealthComponent>();
                            health.Slider = new BotHealthSlider(child);
                        }
                }

                if (entity.HasComponent<PlayerComponent>() || entity.HasComponent<BotComponent>())
                {
                    entity.AddComponent<CacheSkillEffectComponnet>().Initialize();
                }

                if (layerMask != -1)
                {
                    gameObject.layer = layerMask;
                }

                if (entity.HasComponent<AIComponent>())
                {
                    // var tree = new BehaviorTreeBuilder(gameObject)
                    // .Sequence("move forever")
                    //     // .RepeatForever("move")
                    //         .ConditionPlayerInRange()
                    //         .ActionGoToPoint()
                    //         .ActionGoToPoint()
                    //     // .End()
                    // .Build();


                    // var tree = new BehaviorTreeBuilder(gameObject)
                    // .Sequence("evade")
                    //     .ConditionPlayerInRange()
                    //     .ActionEvade()
                    // .End()

                    // .Selector("selector")
                    //     .Sequence("attack player")
                    //         .ConditionPlayerInRange()
                    //     .End()
                    //     .Sequence("move around")
                    //     .End()
                    // .End()
                    // .Build();
                    var tree = new BehaviorTreeBuilder(gameObject).Build();
                    if (entity.HasComponent<PathComponent>())
                    {
                        var pathName = entity.GetComponent<PathComponent>().name;
                        entity.GetComponent<PathComponent>().Initiazlize(GameObject.Find("Waypoint Manager/" + pathName).GetComponent<PathManager>());
                        gameObject.AddComponent<ActionFollowPath>();
                        // tree = new BehaviorTreeBuilder(gameObject)
                        //     // .Sequence("FollowPath")
                        //     .ActionFollowPath()
                        //     .End()
                        // .Build();
                    }
                    var ai = entity.GetComponent<AIComponent>();
                    ai.brain = tree;
                }

                if (entity.HasComponent<VisionTargetComponent>())
                {
                    var vision = entity.GetComponent<VisionTargetComponent>();
                    vision.Initiazlize();
                    entity.AddComponent<DebugVisionComponent>().Initialize(vision.visionRange, vision.limitAngle);
                }
            }
            else
            {
                Debug.LogError("Game Object Can not null " + assetName);
            }
        }
    }
}
