// using UnityEngine;
// using RPG.GameEntity;
// using RPG.Asset;
// using Entitas;

// [CreateAssetMenu(fileName = "UnityPlayerData", menuName = "Entity/PlayerData")]
// public class UnityPlayerData : AUnityViewEntityData {
//     public float maxHealthPoint = 100f;
//     public float maxSpeed = 5f;
    
//     public override Entity LoadViewEntity ()
//     {
//         return GameContextExtension.LoadPlayer(this);
//     }
// }