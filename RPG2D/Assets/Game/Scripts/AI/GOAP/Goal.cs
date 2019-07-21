using Entitas;


public class Goal
{
    protected int _type;
    protected Entity _onwer;
    protected GOAL_STATE _status;
    public void ActivateIfInactive()
    {
        if (isInactive())
        {
            Active();
        }
    }

    public void ReactivateIfFailed()
    {
        if (hasFailed())
        {
            _status = GOAL_STATE.INACTIVE;
        }
    }

    public Goal(Entity entity, int type)
    {
        _onwer = entity;
        _type = type;
        _status = GOAL_STATE.INACTIVE;
    }

    public virtual void Active()
    {

    }

    public virtual void InActive()
    {

    }

    public virtual void Terminated()
    {

    }

    public virtual void AddSubGoal(Goal goal)
    {

    }

    public virtual GOAL_STATE Process()
    {
        return GOAL_STATE.COMPLETED;
    }

    public bool isComplete() { return _status == GOAL_STATE.COMPLETED; }
    public bool isActive() { return _status == GOAL_STATE.ACTIVE; }
    public bool isInactive() { return _status == GOAL_STATE.INACTIVE; }
    public bool hasFailed() { return _status == GOAL_STATE.FAILED; }
    public int GetType() { return _type; }

}