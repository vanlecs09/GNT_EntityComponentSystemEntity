using Entitas;
using UnityEngine;
using System.Collections.Generic;
using RPG.View;
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
            var playerPos = player.GetComponent<TransformComponent>().position;
            var steering = player.Modify<SteeringBehaviorComponent>();
            var joyDir =  new Vector3(joyStickDirection.x, 0, joyStickDirection.y);
            steering.vTarget = joyDir + playerPos;
            if(joyDir.x == 0 && joyDir.y == 0)
            {
                var move = player.GetComponent<MoveComponent>();
                move.velocity = Vector3.zero;
            }
            // Debug.Log(steering.vTarget);
            // var move = player.Modify<MoveComponent>();
            // move.direction = new Vector3(joyStickDirection.x, 0, joyStickDirection.y);
        };
        foreach(var entity in entities)
        {
            entity.Destroy();
        }
    }
}