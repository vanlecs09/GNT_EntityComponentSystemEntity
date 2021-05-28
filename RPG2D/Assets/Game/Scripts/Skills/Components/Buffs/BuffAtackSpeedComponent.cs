using Entitas;

[Game]
public class BuffAtackSpeedComponent : IComponent
{
    public float speedModifier;
    public CoolDownComponent cooldown;
}