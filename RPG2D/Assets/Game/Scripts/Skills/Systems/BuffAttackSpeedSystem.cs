using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BuffAttackSpeedSystem : IExecuteSystem
{
    // public BuffAttackSpeedSystem()
    // {
    //     monitors += Context<Input>.AllOf<BuffAttackComponent>().OnAdded(ProcessAdd);
    //     monitors += Context<Input>.AllOf<BuffAttackComponent>().OnAdded(ProcessRemove);
    // }

    // protected void ProcessAdd(List<Entity> entities)
    // {
    //     foreach (var entity in entities)
    //     {
    //         var buffAttackSpeed = entity.GetComponent<BuffAtackSpeedComponent>();
    //         var stat = entity.GetComponent<StatComponent>();
    //         stat.attackSpeedModifier = buffAttackSpeed.speedModifier;
    //     }
    // }

    // protected void ProcessRemove(List<Entity> entities)
    // {
    //     foreach (var entity in entities)
    //     {
    //         var buffAttackSpeed = entity.GetComponent<BuffAtackSpeedComponent>();
    //         var stat = entity.GetComponent<StatComponent>();
    //         stat.attackSpeedModifier = 1;
    //     }
    // }


    public void Execute()
    {
        var entities = Context<Game>.AllOf<BuffAtackSpeedComponent, StatComponent>().GetEntities();
        foreach (var entity in entities)
        {
            var buffAttackSpeed = entity.GetComponent<BuffAtackSpeedComponent>();
            var stat = entity.GetComponent<StatComponent>();
            stat.attackSpeedModifier = buffAttackSpeed.speedModifier;
            var coolDown = entity.GetComponent<CoolDownComponent>();
            coolDown.currentTime += Time.deltaTime;
            if (coolDown.currentTime >= coolDown.time)
            {
                entity.RemoveComponent<BuffAtackSpeedComponent>();
            }
        }
    }
}