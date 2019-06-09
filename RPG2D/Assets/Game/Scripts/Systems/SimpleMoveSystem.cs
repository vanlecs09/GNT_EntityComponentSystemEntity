// using Entitas;
// using UnityEngine;

// public class SimpleMovementSystem : IExecuteSystem
// {
//     IGroup monitors;
//     public  SimpleMovementSystem()
//     {
//         monitors = Context<Default>.AllOf<TransformComponent>();
//         // monitors += Context<Default>.AllOf<TransformComponent>().OnAdded(Process);
//     }
//     public void Execute()
//     {
//         // Debug.Log("simple movement system exeucte");
//     }
// }