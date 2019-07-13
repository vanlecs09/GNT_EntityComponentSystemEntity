// using Entitas;
// using System.Collections.Generic;
// using RPG.Rendering;
// using UnityEngine;
// public class SlowDownMoveSystem : ReactiveSystem
// {
//     public SlowDownMoveSystem()
//     {
//         monitors += Context<Skill>.AllOf<TargetComponent, SlowDownMoveComponent>().OnRemoved(OnExit);
//     }

//     protected void OnExit(List<Entity> entities)
//     {
//         foreach (var entity in entities)
//         {
//             var targetEntity = entity.GetComponent<TargetComponent>().targetEntity;
//             var move = targetEntity.GetComponent<MoveComponent>();
//             if(targetEntity.HasComponent<SpriteRendererComponent>())
//             {
//                 var spriteRendering = entity.GetComponent<SpriteRendererComponent>().spriteRenderer;
//             }
//         }
//     }
// }