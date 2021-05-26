using Entitas;

[Game, Skill]
public class SlowBuffComponent : DebuffComponent
{
    public float value;

    public void Initialize(float speed)
    {
        this.value = speed;
    }
}