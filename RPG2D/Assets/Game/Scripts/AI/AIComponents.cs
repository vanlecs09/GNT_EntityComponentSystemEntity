using Entitas;
using CleverCrow.Fluid.BTs.Trees;
using Newtonsoft.Json;
using System.Collections.Generic;
using SWS;
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

[Game]
public class PathComponent : IComponent
{
    [JsonIgnore]
    public PathManager value;
    public string name;
    public void Initiazlize(PathManager pathMgr_)
    {
        this.value = pathMgr_;
    }
}

[Game]
public class QueuePointCompnent : IComponent
{
    public Queue<Vector3> value;
}

[Game]
public class VisionTargetComponent : IComponent
{
    public float limitAngle;
    public float visionRange;
    public List<Entity> targets;
    public void Initiazlize(List<Entity> targets_)
    {
        this.targets = targets_;
    }
}