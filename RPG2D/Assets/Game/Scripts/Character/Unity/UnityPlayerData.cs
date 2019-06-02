using UnityEngine;
using RPG.GameEntity;

[CreateAssetMenu(fileName = "UnityPlayerData", menuName = "Entity/PlayerData")]
public class UnityPlayerData : ScriptableObject, IPlayerData, ICharacterData {
    public GameObject playerPrefab;
    public float maxHealthPoint = 100f;
    public float maxSpeed = 5f;

    public object CharacterPrefab => playerPrefab;
}