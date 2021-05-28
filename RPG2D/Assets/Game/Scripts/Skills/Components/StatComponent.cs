using Entitas;

[Game]
public class StatComponent : IComponent
{
    public float baseAttackSpeed = 1.0f;
    public float attackSpeedModifier = 1.0f;
    public float baseHp;
}