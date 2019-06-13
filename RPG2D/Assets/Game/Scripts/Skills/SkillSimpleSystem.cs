// using Entitas;
// using UnityEngine;
// using System.Collections.Generic;
// using RPG.View;
// public class SkillSimpleSystem: ReactiveSystem
// {
//     public SkillSimpleSystem()
//     {
//         monitors += Context<Input>.AllOf<SkillComponent>().OnAdded(Process);
//     }

//     protected void Process(List<Entity> entities)
//     {
//         var playerEntities = Context<Game>.AllOf<PlayerComponent>().GetEntities();
//         var playerEntity = playerEntities[0];
//         var playerPos = playerEntity.Get<TransformComponent>();
//         var playerDir = playerEntity.Get<DirectionComponent>();
//         foreach (var entity in entities)
//         {
//             GameContext.CreateSkillEntity(playerPos.position, playerDir.direction);
//             entity.Destroy();
//         }
    
//     }
// }