using Entitas;
using CleverCrow.Fluid.BTs.Trees;
using Newtonsoft.Json;
using System.Collections.Generic;
using RPG.View;

// using SWS;
using UnityEngine;
[Game]
public class AIComponent : IComponent
{
    [JsonIgnore]
    public BehaviorTree brain;
    public void Initiazlize(BehaviorTree brain_)
    {
        this.brain = brain_;
    }
}

// [Game]
// public class PathComponent : IComponent
// {
//     [JsonIgnore]
//     public PathManager value;
//     public string name;
//     public void Initiazlize(PathManager pathMgr_)
//     {
//         this.value = pathMgr_;
//     }
// }

[Game]
public class QueuePointCompnent : IComponent
{
    public Queue<Vector3> value;
}

public class MemoryRecord
{
    public bool isAttackable;
    public bool isShootable;
    public bool isWithintFOV;
    public bool isDetected;
    public bool isChasable;

    public void Reset()
    {
        isAttackable = false;
        isShootable = false;
        isDetected = false;
        isChasable = false;
    }
}

[Game]
public class DebugVisionComponent : IComponent
{
    internal void Initialize(float range, float limitAngle)
    {
        throw new System.NotImplementedException();
    }
}

[Game]
public class VisionComponent : IComponent
{
    public float limitAngle;
    public float range;
    public float attackRange;
    public float chaseRange;
    public HashSet<Entity> targets;
    public Entity currentTargetEntity;

    Dictionary<Entity, MemoryRecord> mapMemory;
    public void Initiazlize(float range, float chaseRange, float attackRange)
    {
        this.range = range;
        this.chaseRange = chaseRange;
        this.attackRange = attackRange;
        // this.targets = targets_;
        this.targets = new HashSet<Entity>();
        this.currentTargetEntity = null;
        mapMemory = new Dictionary<Entity, MemoryRecord>();
    }

    public bool IsCurrentTargetPresent()
    {
        return currentTargetEntity != null;
    }

    public void Reset()
    {
        mapMemory.Clear();
    }

    public void UpdateVision(Entity thisEntity, Entity otherEntity)
    {
        MakeRecordIfNotPresent(otherEntity);
        MemoryRecord memoryRecord = null;
        mapMemory.TryGetValue(otherEntity, out memoryRecord);
        memoryRecord.Reset();
        var distanceToTarget = (thisEntity.GetComponent<TransformComponent>().position - otherEntity.GetComponent<TransformComponent>().position).magnitude;
        if (!otherEntity.HasComponent<HumanComponent>())
        {
            memoryRecord.isAttackable = false;
            return;
        }

        if (distanceToTarget <= chaseRange)
        {
            memoryRecord.isChasable = true;
        }
        if (distanceToTarget <= attackRange)
        {
            memoryRecord.isAttackable = true;
        }
    }

    public void MakeRecordIfNotPresent(Entity otherGameObject)
    {
        if (!mapMemory.ContainsKey(otherGameObject))
        {
            mapMemory.Add(otherGameObject, new MemoryRecord());
        }
    }

    public bool TargetInRangeAttack()
    {
        if (!mapMemory.ContainsKey(currentTargetEntity)) return false;
        MemoryRecord record = null;
        mapMemory.TryGetValue(currentTargetEntity, out record);
        return record.isAttackable;
    }

    public bool TargetInRangeChase()
    {
        if (!mapMemory.ContainsKey(currentTargetEntity)) return false;
        MemoryRecord record = null;
        mapMemory.TryGetValue(currentTargetEntity, out record);
        return record.isChasable;
    }
}

public enum TEAM
{
    A,
    B,
}

[Game]
public class TeamComponent : IComponent
{
    public TEAM value;

    public void Initialize(TEAM value)
    {
        this.value = value;
    }
}