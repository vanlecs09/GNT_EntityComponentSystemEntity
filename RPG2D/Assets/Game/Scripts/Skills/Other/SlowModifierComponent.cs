using Entitas;

[Game, Skill]
public class SlowModifierComponent : IComponent
{
    public float value;

    public void Initialize(float speed)
    {
        this.value = speed;
    }
}