using Entitas;
[Game]
public class DebuffComponent : IComponent
{
    public int times;
    public float intervalTime;
    public float currentTime;
    public int affactedCount;
}
