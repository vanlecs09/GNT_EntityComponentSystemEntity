using Entitas;
using UnityEngine;

[Game]
public class PlayerComponent: IComponent
{

}

[Game]
public class ManaComponent: IComponent
{
    public int maxMana;
    public int currentMana;
}

[Game]
public class HealthComponent: IComponent
{
    public int minHP;
    public int currentHP;
}

[Game]
public class DamageComponent: IComponent
{

}

[Game]
public class DirectionComponent: IComponent
{
    public Vector3 direction;
}