
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using RPG.View;
using CleverCrow.Fluid.BTs.Trees;


public class ActionGoToPoint : ActionBase
{
    Entity _entity;
    Vector3 _targetPos;
    protected override void OnInit()
    {
        _entity = Owner.GetEntityLink().entity as Entity;
    }

    // Triggers every time this node starts running. Does not trigger if TaskStatus.Continue was last returned by this node
    protected override void OnStart()
    {
        var steering = _entity.GetComponent<SteeringBehaviorComponent>();
        steering.SeekOn();
        steering.vTarget = new Vector3(Random.Range(-1, 1) * 3, 0, Random.Range(-1, 1) * 3);
        Debug.Log(" go to point " + steering.vTarget);
        _targetPos = steering.vTarget;
    }

    // Triggers every time `Tick()` is called on the tree and this node is run
    protected override TaskStatus OnUpdate()
    {
        // Points to the GameObject of whoever owns the behavior tree
        // Debug.Log(Owner.name);
        var position = _entity.GetComponent<TransformComponent>().position;
        if((position - _targetPos).sqrMagnitude < 0.2f * 0.2f)
        {
            Debug.Log("success");
            return TaskStatus.Success;
        }
        return TaskStatus.Continue;
    }

    // Triggers whenever this node exits after running
    protected override void OnExit()
    {
    }
}
