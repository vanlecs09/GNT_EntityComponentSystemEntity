// using System;
// using UnityEngine;
// using Entitas;
// using RPG.Asset;
// using RPG.View;
// using RPG.Rendering;
// using RPG.GameEntity;

// namespace RPG.Asset
// {
//     public partial class UnityCharacterLoader: IViewEntityLoader
//     {
//         public Entity Load (IViewEntityData data)
//         {
//             var entity = GameContextExtension.CreateEntity();
//             var go = GameObject.Instantiate((GameObject)data.GetPrefab());
//             var ch = go.GetComponent<UnityCharacter>();
//             entity.Add<ViewComponent>().transform = new UnityTransform(go.transform);
//             entity.Add<TransformComponent>();
//             entity.Add<SpriteRendererComponent>().spriteRenderer = new UnitySpriteRenderer(ch.spriteRenderer);
//             entity.Add<AnimatorComponent>().value = new UnityAnimator(ch.animator);
//             entity.Add<CharacterComponent>();
//             return entity;
//         }
//     }
// }

// public partial class GameContextExtension {
//     static IViewEntityLoader _characterLoader;

//     public static IViewEntityLoader CharacterLoader {
//         get {
//             if (_characterLoader == null)
//                 _characterLoader = new UnityCharacterLoader();
//             return _characterLoader;
//         }
//     }

//     public static Entity LoadCharacter (IViewEntityData data) {
//         return CharacterLoader.Load(data);
//     }
// }