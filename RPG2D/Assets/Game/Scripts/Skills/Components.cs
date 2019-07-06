using Entitas;
using System.Collections.Generic;

public enum SKILL_TYPE
{
    SIMPLE,
    FIRE_SOULS,
    FIRE_BOMB,
    BUBBLE_PRISON,
    EARTH_SPIKE,
    EARTH_PRISON,
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

[Game, Skill]
public class BubblePrisonComponent: IComponent
{
}

[Game, Skill]
public class ExplodeComponent: IComponent
{
    
}

[Game, Skill]
public class CountDownComponent: IComponent
{
    public float currentTime;
    public float time;
    public void Initialize(float time_)
    {
        this.time = time_;
        currentTime = 0;
    }
}

[Game, Skill]
public class WallAroundComponent: IComponent
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
public class StunComponent: IComponent
{
    
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






