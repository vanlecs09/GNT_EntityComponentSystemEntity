using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using RPG.View;
using CleverCrow.Fluid.BTs.Trees;


public class ActionAttackPlayer : ActionBase
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
        
    }

    // Triggers every time `Tick()` is called on the tree and this node is run
    protected override TaskStatus OnUpdate()
    {
        // Points to the GameObject of whoever owns the behavior tree
        // Debug.Log(Owner.name);
        return TaskStatus.Success;
        
    }

    // Triggers whenever this node exits after running
    protected override void OnExit()
    {
    }
}
