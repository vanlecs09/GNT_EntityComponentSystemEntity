using CleverCrow.Fluid.BTs.Trees;
using UnityEngine;

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

    public static BehaviorTreeBuilder ConditionFinishWayPoint(this BehaviorTreeBuilder builder, string name = "ConditionFinishWayPoint")
    {
        return builder.AddNode(new ConditionFinishWayPoint
        {
            Name = name
        });
    }

    public static BehaviorTreeBuilder ActionFindNextWayPoint(this BehaviorTreeBuilder builder, string name = "ActionFindNextWayPoint")
    {
        return builder.AddNode(new ActionFindNextWayPoint
        {
            Name = name
        });
    }

    public static BehaviorTreeBuilder ActionTargetInVision(this BehaviorTreeBuilder builder, string name = "ActionTargetInVision")
    {
        return builder.AddNode(new ActionTargetInVision
        {
            Name = name
        });
    }

    public static BehaviorTreeBuilder ActionPursuit(this BehaviorTreeBuilder builder, string name = "ActionPursuit")
    {
        return builder.AddNode(new ActionPursuit
        {
            Name = name
        });
    }
}