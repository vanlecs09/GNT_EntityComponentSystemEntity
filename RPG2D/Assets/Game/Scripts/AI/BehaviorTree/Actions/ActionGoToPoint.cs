
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using RPG.View;


public class ActionGoToPoint : ActionBase
{
    Entity _entity;
    private Vector3 _detinatePos;
    public Vector3 DestinatePos
    {
        get { return _detinatePos; }
        set { _detinatePos = value; }
    }

    protected override void OnInit()
    {
        _entity = Owner.GetEntityLink().entity as Entity;
    }

    protected override void OnStart()
    {
        var steering = _entity.GetComponent<SteeringBehaviorComponent>();
        steering.SeekOn();
        // steering.vTarget = new Vector3(Random.Range(-1, 1) * 3, 0, Random.Range(-1, 1) * 3);
        steering.vTarget = DestinatePos;
    }
    protected override TaskStatus OnUpdate()
    {
        var position = _entity.GetComponent<TransformComponent>().position;
        if((position - DestinatePos).sqrMagnitude < 0.2f * 0.2f)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Continue;
    }

    protected override void OnExit()
    {
    }
}
