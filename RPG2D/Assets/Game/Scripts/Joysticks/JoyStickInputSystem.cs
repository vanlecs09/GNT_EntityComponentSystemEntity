using Entitas;
using UnityEngine;
using System.Collections.Generic;
public class JoyStickInputSystem : ReactiveSystem
{
    Entity[] _players;
    public JoyStickInputSystem()
    {
        monitors += Context<Input>.AllOf<JoyStickInputComponent>().OnAdded(Process);

        _players = Context<Game>.AllOf<PlayerComponent>().GetEntities();
    }

    protected void Process(List<Entity> entities)
    {
        var e = entities[0];
        var input = e.Get<JoyStickInputComponent>();
        _players = Context<Game>.AllOf<PlayerComponent>().GetEntities();
        var joyStickDirection = input.joyStickDirection;
        foreach (var player in _players)
        {
            var move = player.Modify<MoveComponent>();
            move.direction = new Vector3(joyStickDirection.x, 0, joyStickDirection.y);
        };
        foreach(var entity in entities)
        {
            entity.Destroy();
        }
    }
}