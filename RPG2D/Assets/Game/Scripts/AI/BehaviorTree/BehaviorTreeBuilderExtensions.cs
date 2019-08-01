using CleverCrow.Fluid.BTs.Trees;
public static class BehaviorTreeBuilderExtensions
{
    public static BehaviorTreeBuilder ConditionPlayerInRange(this BehaviorTreeBuilder builder, string name = "ConditionPlayerInRange")
    {
        return builder.AddNode(new ConditionPlayerInRange
        {
            Name = name,
        });
    }

     public static BehaviorTreeBuilder ActionEvade(this BehaviorTreeBuilder builder, string name = "ActionEvade")
    {
        return builder.AddNode(new ActionEvade
        {
            Name = name,
        });
    }

    public static BehaviorTreeBuilder ActionGoToPoint(this BehaviorTreeBuilder builder, string name = "ActionGoToPoint")
    {
        return builder.AddNode(new ActionGoToPoint
        {
            Name = name,
        });
    }
}