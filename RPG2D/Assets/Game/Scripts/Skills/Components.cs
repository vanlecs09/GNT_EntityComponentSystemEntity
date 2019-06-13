using Entitas;
using System.Collections.Generic;

public enum SKILL_TYPE
{
    SIMPLE,
    FIRE_SOULS,
    FIRE_BURN,
}

[Game, Input]

public class SkillComponent: IComponent
{   
    public SKILL_TYPE skillType;
    public void Initialize(SKILL_TYPE skillType_)
    {
        this.skillType = skillType_;
    }
}

[Game, Input]
public class SkillFireComponent: IComponent
{
}

[Game]
public class RadiusAffectComponent: IComponent // after explode
{
    public float radius;
}

[Game]
public class TargetEffectComponent: IComponent // who is affected by skill
{
    public List<IComponent> targetList; 
}

public class IntervalComponent: IComponent
{

}








