using System;
using UnityEngine;
using Entitas;
using RPG.GameEntity;
using RPG.View;
using RPG.Rendering;

namespace RPG.GameEntity
{
    public class UnityCharacterLoader : ICharacterLoader
    {
        public Entity Load (ICharacterData data)
        {
            var entity = GameContextExtension.CreateEntity();
            var go = GameObject.Instantiate((GameObject)data.CharacterPrefab);
            var ch = go.GetComponent<UnityCharacter>();
            entity.Add<ViewComp>().gameObject = go;
            entity.Add<TransformComp>();
            entity.Add<SpriteRendererComp>().spriteRenderer = new UnitySpriteRenderer(ch.spriteRenderer);
            entity.Add<AnimatorComp>().animator = new UnityAnimator(ch.animator);
            entity.Add<CharacterComp>();
            return entity;
        }
    }
}

public partial class GameContextExtension {
    static ICharacterLoader _characterLoader;

    public static ICharacterLoader CharacterLoader {
        get {
            if (_characterLoader == null)
                _characterLoader = new UnityCharacterLoader();
            return _characterLoader;
        }
    }

    public static Entity LoadCharacter (ICharacterData data) {
        return CharacterLoader.Load(data);
    }
}