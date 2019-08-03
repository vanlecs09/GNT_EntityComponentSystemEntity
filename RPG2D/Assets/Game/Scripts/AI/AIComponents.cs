using Entitas;
using CleverCrow.Fluid.BTs.Trees;
using Newtonsoft.Json;
using SWS;
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