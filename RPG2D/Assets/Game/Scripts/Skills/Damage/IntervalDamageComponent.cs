using Entitas;

[Game]
public class BuffComponent : IComponent
{
    public float deltaTime;
    public float intervalTime;
}

[Game]
public class DebuffComponent : IComponent
{
    public int times;
    public float intervalTime;
    public float currentTime;
    public int affactedCount;
}


[Game]
public class IntervalDamageComponent : DebuffComponent
{
    public float damage = 1;
    public void Initialize(float damage, int times, float intervalTime)
    {
        // this.Initialize()
        this.currentTime = 0;
        this.times = times;
        this.damage = damage;
        this.intervalTime = intervalTime;
    }

    public void Initialize(IntervalDamageComponent otherComponent)
    {
        this.currentTime = 0;
        this.times = otherComponent.times;
        this.damage = otherComponent.damage;
        this.intervalTime = otherComponent.intervalTime;
    }
}