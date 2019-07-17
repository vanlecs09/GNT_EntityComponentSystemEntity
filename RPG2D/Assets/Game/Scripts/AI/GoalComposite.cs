using Entitas;
using System.Collections.Generic;
public class GoalComposite : Goal
{
    public List<Goal> _listSubGoals;
    public GoalComposite(Entity owner, int type) : base(owner, type)
    {

    }

    protected GOAL_STATE ProcessSubgoals()
    {
        foreach (var subGoal in _listSubGoals)
        {
            if (subGoal.isComplete() || subGoal.hasFailed())
            {
                subGoal.Terminated();
            }
        }

        if (_listSubGoals.Count > 0)
        {
            var goalState = GOAL_STATE.ACTIVE;
            var subGoal = _listSubGoals[0];
            goalState = subGoal.Process();

            if (goalState == GOAL_STATE.COMPLETED && _listSubGoals.Count > 1)
            {
                return GOAL_STATE.ACTIVE;
            }

            return GOAL_STATE.COMPLETED;
        }
        else
        {
            return GOAL_STATE.COMPLETED;
        }

    }

    public void RemoveAllSubGoals()
    {
        foreach (var subGoal in _listSubGoals)
        {
            subGoal.Terminated();
        }

        _listSubGoals.Clear();
    }
}