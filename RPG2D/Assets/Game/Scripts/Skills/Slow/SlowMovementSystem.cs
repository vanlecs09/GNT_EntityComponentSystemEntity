using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class SlowMovementSystem : ReactiveSystem
{
    public SlowMovementSystem()
    {
        monitors += Context<Game>.AllOf<MoveComponent, SlowModifierComponent>().OnAdded(OnEnter);
        monitors += Context<Game>.AllOf<MoveComponent, SlowModifierComponent>().OnRemoved(OnExit);
    }

    protected void OnEnter(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            if(entity.isEnabled == false) continue;
            var move = entity.GetComponent<MoveComponent>();
            var slow = entity.GetComponent<SlowModifierComponent>();
            move.speed -= slow.value;
            Debug.Log(move.speed);
        }
    }

    protected void OnExit(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            if(entity.isEnabled == false) continue;
            var move = entity.GetComponent<MoveComponent>();
            var slow = entity.GetComponent<SlowModifierComponent>();
            move.speed += slow.value;
        }
    }
}
