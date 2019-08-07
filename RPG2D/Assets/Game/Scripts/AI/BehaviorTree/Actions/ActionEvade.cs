
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using RPG.View;
using CleverCrow.Fluid.BTs.Trees;


public class ActionEvade : ActionBase
{
    Entity _entity;
    Entity _target;
    protected override void OnInit()
    {
        _entity = Owner.GetEntityLink().entity as Entity;
    }

    protected override void OnStart()
    {
        var steering = _entity.GetComponent<SteeringBehaviorComponent>();
        var playerEntities = Context<Game>.AllOf<PlayerComponent>().GetEntities();
        var playerEntity = playerEntities[0];
        steering.EvadeOn(playerEntity);
        _target = playerEntity;
    }

    protected override TaskStatus OnUpdate()
    {
        var targetPos = _target.GetComponent<TransformComponent>().position;
        var position = _entity.GetComponent<TransformComponent>().position;
        if((position - targetPos).sqrMagnitude < 10.0f * 10.0f)
        {
            return TaskStatus.Continue;
        }
        return TaskStatus.Success;
    }

    protected override void OnExit()
    {
        var steering = _entity.GetComponent<SteeringBehaviorComponent>();
        steering.EvadeOff();
    }
}
