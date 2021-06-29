using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class AIInitializeSystem : ReactiveSystem
{
    public AIInitializeSystem()
    {
        monitors += Context<Game>.AnyOf<EasyBrainComponent, NormalBrainComponent, PlayrBrainComponent>().OnAdded(OnEnter);
    }

    protected void OnEnter(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var gameObject = this.FindGameObject(entity);
            if (gameObject == null) continue;
            if (entity.HasComponent<EasyBrainComponent>())
            {
                entity.AddComponent<AIComponent>().Initiazlize(AIBuilder.CreateDumbassBrain(gameObject, entity));
            }

            if (entity.HasComponent<PlayrBrainComponent>())
            {
                entity.AddComponent<AIComponent>().Initiazlize(AIBuilder.CreateNormalBrain2(gameObject, entity));
            }

            if (entity.HasComponent<NormalBrainComponent>())
            {
                entity.AddComponent<AIComponent>().Initiazlize(AIBuilder.CreateNormalBrain(gameObject, entity));
            }

        }
    }

    public GameObject FindGameObject(Entity entity)
    {
        var entityLinks = GameObject.FindObjectsOfType<EntityLink>();
        foreach (var link in entityLinks)
        {
            if (link.entity == entity)
            {
                return link.gameObject;
            }
        }
        return null;
    }
}