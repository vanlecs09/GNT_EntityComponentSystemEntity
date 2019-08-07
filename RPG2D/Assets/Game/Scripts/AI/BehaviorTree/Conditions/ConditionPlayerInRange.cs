using CleverCrow.Fluid.BTs.Tasks;

using Entitas;
using Entitas.Unity;
using RPG.View;

public class ConditionPlayerInRange : ConditionBase
{
    Entity _entity;
    Entity _playerEntity;
    protected override bool OnUpdate()
    {
        var pos = _entity.GetComponent<TransformComponent>().position;
        var playerEntities = Context<Game>.AllOf<PlayerComponent>().GetEntities();
        var playerEntity = playerEntities[0];
        var playerPos = playerEntity.GetComponent<TransformComponent>().position;

        if ((pos - playerPos).sqrMagnitude < 3.0f * 3.0f)
        {
            return true;
        }
        return false;
    }

    protected override void OnStart()
    {
        _entity = Owner.GetEntityLink().entity as Entity;
        
    }

    protected override void OnExit()
    {

    }

    protected override void OnInit()
    {
    }
}