using Entitas;

[Game]
public class StatComponent : IComponent
{
    public float baseMoveSpeed = 5.0f;
    public float baseAttackSpeed = 1.0f;
    public float attackSpeedModifier = 1.0f;
    public float baseHp;

    public void Initialize(float baseAttackSpeed, float baseMoveSpeed)
    {   
        this.baseMoveSpeed = baseMoveSpeed;
        this.baseAttackSpeed = baseAttackSpeed;
    }
}