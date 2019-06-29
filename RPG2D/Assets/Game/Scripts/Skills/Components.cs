using Entitas;
using System.Collections.Generic;

public enum SKILL_TYPE
{
    SIMPLE,
    FIRE_SOULS,
    FIRE_BOMB,
    BUBBLE_PRISON,
}

[Game, Input]

public class SkillComponent : IComponent
{
    public SKILL_TYPE skillType;
    public void Initialize(SKILL_TYPE skillType_)
    {
        this.skillType = skillType_;
    }
}

public class SimpleSKill : IComponent
{

}

[Game, Input, Damage, Skill]
public class RadiusRangeComponent : IComponent
{
    public float radius;
    public void Initialize(float radius_)
    {
        this.radius = radius_;
    }
}

[Game, Input]
public class TriggerComponent : IComponent
{
}

[Game, Skill]
public class ExplodeComponent: IComponent
{
    
}

[Game, Skill]
public class FreezeComponent: IComponent
{
    public float timeFreeze;
    public void Initialize(float timeFreeze_)
    {
        this.timeFreeze = timeFreeze_;
    }
}

[Game]
public class FrozenComponent: IComponent
{
    public float currentTime;
    public float timeFreeze;
    public void Initialize(float timeFreeze_)
    {
        this.timeFreeze = timeFreeze_;
        this.currentTime = 0;
    }
}






