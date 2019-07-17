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


    DRAW_DANGER_SLOW,
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

[Game, Skill]
public class RepeatEffect : IComponent
{

}

[Game, Skill]
public class SlowMoveComponent : IComponent
{
    public float speedToReduce;
    public void Initialize(float speedToReduce_)
    {
        this.speedToReduce = speedToReduce_;
    }
}


[Game, Skill]
public class IntervalEffect : IComponent
{
    public float interval;
    public float currentTime;
    public void Initialize(float interval_, float currentTime_)
    {
        this.interval = interval_;
        this.currentTime = currentTime_;
    }
}

[Game, Skill]
public class AreaEffect : IComponent
{
    public float radius;
    public void Initialize(float radius_)
    {
        this.radius = radius_;
    }
}


[Game, Skill]
public class CacheSkillEffectComponnet : IComponent
{
    public Dictionary<Type, int> value;
    public void Initialize()
    {
        this.value = new Dictionary<Type, int>();
    }

    public void AddSkillEntity(Type type)
    {
        if (this.value.ContainsKey(type))
        {
            this.value[type] += 1;
        }
        else
        {
            this.value.Add(type, 1);
        }
        UnityEngine.Debug.Log("add  " +  this.value[type]);
    }

    public void RemoveSkillEntity(Type type)
    {
        if(this.value.ContainsKey(type))
        {
            this.value[type] -= 1;
            this.value[type] = this.value[type] < 0 ? 0 : this.value[type];
            UnityEngine.Debug.Log("remove  " +  this.value[type]);
        }
    }
    public void SkillType()
    {

    }

    public bool HasSkillEffect(Type type)
    {
        int result = 0;
        if (this.value.TryGetValue(type, out result))
        {
            return result > 0;
        }
        return false;
    }
}


[Game, Skill]
public class StackSkillComponent : IComponent
{
    public int stackNumber;
}

[Game, Skill]
public class PushBackComponent: IComponent
{
    
}

