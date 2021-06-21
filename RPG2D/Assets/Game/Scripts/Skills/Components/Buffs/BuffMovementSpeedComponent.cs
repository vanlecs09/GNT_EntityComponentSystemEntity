using Entitas;
[Game]
public class BuffMovementSpeedComponent : BuffComponent
{
    public float speedModifierRate = 1.4f;
    public CoolDownComponent cooldown = new CoolDownComponent();
    public BuffMovementSpeedComponent()
    {
        this.cooldown = new CoolDownComponent();
        cooldown.time = 2.0f;
    }
}