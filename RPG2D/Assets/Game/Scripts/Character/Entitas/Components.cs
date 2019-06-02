using Entitas;
using UnityEngine;

namespace RPG.GameEntity
{
    [Game]
    public class CharacterComp: IComponent {

    }

    [Game]
    public class PlayerComp: IComponent {
        public void Load(IPlayerLoader loader, IPlayerData data) {
            loader.Load(data);
        }
    }

    [Game]
    public class EnemyComp: IComponent {

    }

    [Game]
    public class TeamComp: IComponent {
        public int value;
    }

    [Game]
    public class HeathComp: IComponent {
        public float maxHealthPoint;
        public float healthPoint;

        public void Initialize (float maxHP) {
            maxHealthPoint = maxHP;
            healthPoint = maxHP;
        }

        public void SetMaxHealthPoint (float maxHP) {
            maxHealthPoint = maxHP;
            healthPoint = Mathf.Min(maxHP, healthPoint);
        }

        public void TakeDamage (float value) {
            healthPoint = Mathf.Max(0f, healthPoint - value);
        }

        public void Heal (float value) {
            healthPoint = Mathf.Min(maxHealthPoint, healthPoint + value);
        }
    }
}