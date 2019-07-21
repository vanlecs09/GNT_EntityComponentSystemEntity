using Entitas;

public class GoalWander: Goal
{
    public GoalWander(Entity owner, int type):base(owner, type)
    {

    }


    public override GOAL_STATE Process()
    {
        ActivateIfInactive();
        return _status;
    }

    public override void Active()
    {
        _status = GOAL_STATE.ACTIVE;
        this._onwer.AddComponent<RandomMoveComponent>();
    }

    public override void Terminated()
    {
        this._onwer.RemoveComponent<RandomMoveComponent>();
    }
}   