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
        foreach (var player in _players)
        {
            Debug.Log("modifire");
            player.ReplaceNewComponent<MoveComponent>().Initiazlize(new Vector3(input.joyStickDirection.x * 10, input.joyStickDirection.y * 10, 0), Vector3.zero);
        }

        // Debug.Log(
        //     "Entity" + e.creationIndex + ": input joystick direction =" + input.joyStickDirection);

        e.Destroy();


    }
}