using Entitas;
using System.Collections.Generic;

public enum SKILL_TYPE
{
    SIMPLE,
    FIRE_SOULS,
    FIRE_BOMB,
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

public class SimpleSKill: IComponent
{

}

[Game, Input]
public class SkillFireSoulsComponent: IComponent
{
    public float radius;
    public void Initialize(float radius_)
    {
        this.radius = radius_;
    }
}

[Game, Input]
public class SkillFireBombComponent: IComponent
{
    public float radius;
    public bool isTrigger;
    public void Initialize(float radius_)
    {
        this.radius = radius_;
        this.isTrigger = false;
    }
}


[Game]
public class ActiveComponent: IComponent
{
    public bool active;
     public void Initialize(bool active_)
    {
        this.active = active_;
    }
}







