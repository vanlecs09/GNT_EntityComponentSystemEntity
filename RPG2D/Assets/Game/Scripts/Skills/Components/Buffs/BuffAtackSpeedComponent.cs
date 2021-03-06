using Entitas;

[Game]
public class BuffAtackSpeedComponent : BuffComponent
{
    public float speedModifier = 2.0f;
    public CoolDownComponent cooldown = new CoolDownComponent();

    public BuffAtackSpeedComponent()
    {
        this.cooldown = new CoolDownComponent();
        cooldown.time = 10;
    }
}