using Entitas;

public class AIComponent: IComponent
{
    public GoalThink brain;
    public void Initialize(Entity onwer, int type)
    {
        brain = new GoalThink(onwer, type);
    }
}