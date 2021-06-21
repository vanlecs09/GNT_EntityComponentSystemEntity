using Entitas;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using UnityEngine;
using Entitas.Unity;
using RPG.View;
using RPG.Rendering;
using CleverCrow.Fluid.BTs.Trees;

public class BotLoaderSystem : ReactiveSystem
{
    Context _gameContext;
    public BotLoaderSystem(Contexts contexts)
    {
        monitors += Context<Game>.AllOf<AssetComponent>().OnAdded(Process);
        _gameContext = contexts.GetContext("Game");
    }

    protected void Process(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            if(!entity.isEnabled) continue;
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


                if (gameObject.GetComponentInChildren<Animator>())
                {
                    var animatorComp = entity.Add<AnimatorComponent>();
                    animatorComp.value = new UnityAnimator(gameObject.GetComponentInChildren<Animator>());
                }

                var children = gameObject.GetComponentsInChildren<Transform>();
                foreach (var child in children)
                {
                    if (child.name == "fill_area")
                    {
                        var healthBar = new BotHealthSlider(child);
                        var healthView = entity.AddComponent<HeathViewComponent>();
                        healthView.Slider = healthBar;
                        var health = entity.Modify<HealthComponent>();
                    }
                }


                // if (layerMask != -1)
                // {
                gameObject.layer = layerMask != -1 ? layerMask : gameObject.layer;
                // }

                if (entity.HasComponent<BotComponent>())
                {
                    if (entity.Has<ProjectileAttackComponent>())
                    {
                        entity.GetComponent<ProjectileAttackComponent>().fireTrans = gameObject.transform.Find("FirePoint").transform;
                    }
                    entity.AddComponent<AIComponent>().Initiazlize(AIBuilder.CreateNormalBrain(gameObject, entity));
                }

                if (entity.HasComponent<PlayerComponent>())
                {
                    if (entity.Has<ProjectileAttackComponent>())
                    {
                        entity.GetComponent<ProjectileAttackComponent>().fireTrans = gameObject.transform.Find("FirePoint").transform;
                    }

                    entity.AddComponent<AIComponent>().Initiazlize(AIBuilder.CreateNormalBrain2(gameObject, entity));
                }


                if (entity.GetComponent<DumBassBotComponent>() != null)
                    entity.AddComponent<AIComponent>().Initiazlize(AIBuilder.CreateDumbassBrain(gameObject, entity));

                if (entity.HasComponent<VisionComponent>())
                {
                    entity.AddComponent<DebugVisionComponent>();
                }

                // if (entity.Has<ProjectileAttackComponent>())
                // {
                //     entity.GetComponent<ProjectileAttackComponent>().firePoint = gameObject.transform.Find("FirePoint").transform.position;
                // }
            }
            else
            {
                Debug.LogError("Game Object Can not null " + assetName);
            }
        }
    }
}
