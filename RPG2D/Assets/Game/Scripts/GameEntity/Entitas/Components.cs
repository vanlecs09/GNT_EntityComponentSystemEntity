using Entitas;
using UnityEngine;

namespace RPG.GameEntity
{
    [Game]
    public class CharacterComponent: IComponent {

    }

    [Game]
    public class PlayerComponent: IComponent {

    }

    [Game]
    public class BotComponent: IComponent {

    }

    [Game]
    public class TeamComponent: IComponent {
        public int value;
    }

    [Game]
    public class HeathComponent: IComponent {
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