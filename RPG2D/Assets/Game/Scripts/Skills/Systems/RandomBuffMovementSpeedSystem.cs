// using System.Collections.Generic;
// using Entitas;
// using RPG.View;
// using UnityEngine;

// public class RandomBuffMovementSpeedSystem : ReactiveSystem
// {
//     public RandomBuffMovementSpeedSystem()
//     {
//         monitors += Context<Game>.AllOf<RandomBuffMovementSpeedComponent>().OnAdded(Process);
//     }

//     protected void Process(List<Entity> entities)
//     {
//         var moveEntities = Context<Game>.AllOf<TransformComponent, MoveComponent, StatComponent>().GetEntities();
//         foreach(var moveEntity in moveEntities)
//         {   
//             moveEntity.AddComponent<BuffMovementSpeedComponent>();
//         }
//     }
// }

