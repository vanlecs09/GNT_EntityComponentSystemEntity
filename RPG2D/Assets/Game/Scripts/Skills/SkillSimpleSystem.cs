using Entitas;
using UnityEngine;
using System.Collections.Generic;
using RPG.View;
public class SkillSimpleSystem: ReactiveSystem
{
    public SkillSimpleSystem()
    {
        monitors += Context<Input>.AllOf<SkillComponent>().OnAdded(Process);
    }

    protected void Process(List<Entity> entities)
    {
      
    }
}