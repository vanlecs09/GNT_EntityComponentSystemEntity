using Entitas;
using System.Collections.Generic;
using System;
public enum SKILL_TYPE
{
    SIMPLE,
    FIRE_SOULS,
    FIRE_BOMB,
    BUBBLE_PRISON,
    WATER_TSUNAMI,
    WATER_COLD_BREATH,
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

[Game, Skill]
public class SkillWaterColdBreath : IComponent
{

}

[Game, Skill]
public class RadiusRangeComponent : IComponent
{
    public float radius;
    public void Initialize(float radius_)
    {
        this.radius = radius_;
    }
}

[Game, Skill]
public class BubblePrisonComponent : IComponent
{
    public float time;
    public void Initialize(float time_)
    {
        this.time = time_;
    }
}

[Game, Skill]
public class ExplodeComponent : IComponent
{

}

[Game, Skill]
public class CountDownComponent : IComponent
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
public class WallAroundComponent : IComponent
{
}

[Game, Skill]
public class FreezeComponent : IComponent
{
    public float timeFreeze;
    public void Initialize(float timeFreeze_)
    {
        this.timeFreeze = timeFreeze_;
    }
}

[Game]
public class StunComponent : IComponent
{

}

[Game]
public class FrozenComponent : IComponent
{
    public float currentTime;
    public float timeFreeze;
    public void Initialize(float timeFreeze_)
    {
        this.timeFreeze = timeFreeze_;
        this.currentTime = 0;
    }
}

[Game]
public class DataComponent : IComponent
{
    Dictionary<string, int> intDict;
    Dictionary<string, float> floatDict;
    Dictionary<string, double> doubleDict;
    public void Initialize()
    {
        this.intDict = new Dictionary<string, int>();
        this.floatDict = new Dictionary<string, float>();
        this.doubleDict = new Dictionary<string, double>();
    }

    public int GetIntValue<T>(string name)
    {
        int result = 0;
        if (this.intDict.TryGetValue(name, out result) == false)
        {
        }
        return result;
    }

    public float GetFloatValue(string name)
    {

        float result = 0;
        if (this.floatDict.TryGetValue(name, out result) == false)
        {

        }
        return result;
    }


    public double GetDoubleValue(string name)
    {
        double result = 0.0;
        if (this.doubleDict.TryGetValue(name, out result) == false)
        {
            
        }
        return result;
    }
}






