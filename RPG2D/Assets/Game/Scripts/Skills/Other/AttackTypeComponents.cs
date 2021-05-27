using Entitas;

[Game]
public class AttackTypeComponent : IComponent
{
}

[Game]
public class AttackMeleeTypeComponent : AttackTypeComponent
{
}

[Game]
public class AttackProjectileTypeComonent : AttackTypeComponent
{
}