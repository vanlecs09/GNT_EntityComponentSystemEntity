using System;
using System.Collections.Generic;
using Entitas;
using RPG.Asset;
using UnityEngine;

[CreateAssetMenu(fileName = "UnityAssetLibrary", menuName = "Asset/UnityAssetLibrary")]
public class UnityAssetLibrary : ScriptableObject, IAssetLibrary {
    public AUnityViewEntityData[] gameEntitieDatas;

    private Dictionary<string, AUnityViewEntityData> _dictGameEntity;

    public void GenerateGameEntityDictionary()
    {
        _dictGameEntity = new Dictionary<string, AUnityViewEntityData>();
        for (int i = 0; i < gameEntitieDatas.Length; i++)
        {
            _dictGameEntity[gameEntitieDatas[i].GetId()] = gameEntitieDatas[i];
        }
    }

    public IViewEntityData GetViewEntityData (string id) {
        if (_dictGameEntity.ContainsKey(id))
            return _dictGameEntity[id];
        return null;
    }

    public Entity CreateGameEntity (string id)
    {
        if (_dictGameEntity.ContainsKey(id))
            return _dictGameEntity[id].LoadViewEntity();
        return null;
    }
}