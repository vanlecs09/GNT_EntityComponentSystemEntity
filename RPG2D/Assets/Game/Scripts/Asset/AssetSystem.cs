using Entitas;
using System.Collections.Generic;
using UnityEngine;
using Entitas.Unity;
using RPG.View;
public class AssetSystem: ReactiveSystem
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
            var assetName = entity.Get<AssetComponent>().assetName;
            var assetObject = Resources.Load<GameObject>(assetName);
            
            if(assetObject != null)
            {
                var gameObject = GameObject.Instantiate(assetObject);
                gameObject.Link(entity, _gameContext);
                entity.Add<ViewComponent>().transform = new UnityTransform(gameObject.transform);
                // entity.li
                var unityCompoenntCache = gameObject.GetComponent<UnityComponentsCache>();
                if(unityCompoenntCache)
                {
                    
                }
            }
            else
            {
                Debug.LogError("Game Object Can not null");
            }


        }
    }
}
