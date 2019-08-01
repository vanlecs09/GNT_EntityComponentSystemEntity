using Entitas;
using CleverCrow.Fluid.BTs.Trees;
using Newtonsoft.Json;
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


public class BotAIComponent: IComponent
{
    
}