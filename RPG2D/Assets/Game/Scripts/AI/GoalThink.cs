using Entitas;

public class GoalThink : GoalComposite
{
    public GoalThink(Entity owner, int type) : base(owner, type)
    {

    }

    public override GOAL_STATE Process()
    {
        ActivateIfInactive();
        var subGoalStatus = ProcessSubgoals();

        if(subGoalStatus == GOAL_STATE.COMPLETED || subGoalStatus == GOAL_STATE.FAILED)
        {
            _status = GOAL_STATE.INACTIVE;
        }
        return _status;
    }

    void Arbitrate()
    {

    }

    public void AddGoalWander()
    {
        
    }
}