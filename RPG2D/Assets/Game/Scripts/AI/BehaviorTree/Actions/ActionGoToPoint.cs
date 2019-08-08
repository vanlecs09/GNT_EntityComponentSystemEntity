
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using RPG.View;
using System.Collections.Generic;

public class ActionGoToPoint : ActionBase
{
    Entity _entity;
    private Vector3 _detinatePos;

    private Queue<Vector3> _pointsQueue;
    public Vector3 DestinatePos
    {
        get { return _detinatePos; }
        set { _detinatePos = value; }
    }

    protected override void OnInit()
    {
        _entity = Owner.GetEntityLink().entity as Entity;
        _pointsQueue = _entity.GetComponent<QueuePointCompnent>().value;
    }

    protected override void OnStart()
    {

    }
    protected override TaskStatus OnUpdate()
    {
        var steering = _entity.GetComponent<SteeringBehaviorComponent>();
        steering.Reset();
        steering.SeekOn();
        steering.vTarget = _pointsQueue.Peek();
        return TaskStatus.Success;
    }

    protected override void OnExit()
    {
        // var steering = _entity.GetComponent<SteeringBehaviorComponent>();
        // steering.SeekOff();
    }
}
