using Entitas;

[Game, Skill]
public class DeBuffSlowComponent : DebuffComponent
{
    public float value;

    public void Initialize(float speed)
    {
        this.value = speed;
    }
}