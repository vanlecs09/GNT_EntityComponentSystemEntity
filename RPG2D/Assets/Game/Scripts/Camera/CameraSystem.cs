using Entitas;
using UnityEngine;
using RPG.View;
public class CameraSystem: IExecuteSystem
{
    Transform _cameraTrans;
    Vector3 _offSet;
    public CameraSystem()
    {
        _cameraTrans = Camera.main.transform;
    }

    public void Execute()
    {
        var entities = Context<Game>.AllOf<PlayerComponent>().GetEntities();
        var playerPosition = entities[0].GetComponent<TransformComponent>().position;
        var oldPos = _cameraTrans.position;
        _cameraTrans.position = new Vector3(playerPosition.x, oldPos.y, playerPosition.z);
    }
}