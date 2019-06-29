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
}