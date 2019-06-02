using System;
using UnityEngine;
using Entitas;
using RPG.GameEntity;

namespace RPG.GameEntity
{
    public class UnityPlayerLoader : IPlayerLoader
    {
        public Entity Load (IPlayerData data)
        {
            var entity = GameContextExtension.LoadCharacter((ICharacterData)data);
            entity.Add<PlayerComp>();
            return entity;
        }
    }
}

public partial class GameContextExtension {
    static UnityPlayerLoader _playerLoader;

    public static UnityPlayerLoader PlayerLoader {
        get {
            if (_playerLoader == null)
                _playerLoader = new UnityPlayerLoader();
            return _playerLoader;
        }
    }

    public static Entity LoadPlayer (IPlayerData data) {
        return PlayerLoader.Load(data);
    }
}