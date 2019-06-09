using Entitas;
using System.Collections.Generic;
using UnityEngine;
using RPG.View;
public class AssetSystem: ReactiveSystem
{
    public AssetSystem()
    {
        monitors += Context<Game>.AllOf<AssetComponent>().OnAdded(Process);
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
                entity.Add<ViewComponent>().transform = new UnityTransform(gameObject.transform);
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
