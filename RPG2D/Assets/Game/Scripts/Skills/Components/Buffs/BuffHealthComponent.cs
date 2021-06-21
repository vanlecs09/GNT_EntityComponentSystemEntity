using Entitas;

[Game]
public class BuffHealthComponent : BuffComponent
{
    public float value = 2.0f;
    public CoolDownComponent cooldown = new CoolDownComponent();

    public BuffHealthComponent()
    {
        this.cooldown = new CoolDownComponent();
        cooldown.time = 10;
    }
}