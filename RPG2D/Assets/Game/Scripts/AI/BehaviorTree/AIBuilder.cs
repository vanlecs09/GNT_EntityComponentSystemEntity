
using CleverCrow.Fluid.BTs.Trees;
using CleverCrow.Fluid.BTs.Tasks;
using Entitas;
using UnityEngine;
using RPG.View;
using RPG.Rendering;

public static class AIBuilder
{

    public static BehaviorTree CreateBrain(GameObject gameObject, Entity entity)
    {
        var builder = new BehaviorTreeBuilder(gameObject);
        var tree = builder.Build();
        return tree;
    }

    public static BehaviorTree CreateNormalBrain(GameObject gameObject, Entity entity)
    {
        var builder = new BehaviorTreeBuilder(gameObject);
        var tree = builder
            .Selector()
                .Sequence("attack")
                    .Condition("target_in_range_attack", () =>
                    {
                        var vision = entity.GetComponent<VisionComponent>();
                        return vision.IsCurrentTargetPresent() && vision.TargetInRangeAttack();
                    })
                    .Do("OnBegin", () =>
                    {
                        var move = entity.GetComponent<MoveComponent>();
                        move.speed = 0;
                        // SkillBuilder.CreateAttack(entity, gameObject);
                        return TaskStatus.Success;
                    })
                    .Do("OnUpdate", () =>
                    {
                        var vision = entity.GetComponent<VisionComponent>();
                        var trans = entity.GetComponent<TransformComponent>();
                        var target = vision.currentTargetEntity;
                        if (target.isEnabled == false) return TaskStatus.Continue;
                        var targetTrans = target.GetComponent<TransformComponent>();
                        entity.GetComponent<DirectionComponent>().value = (targetTrans.position - trans.position).normalized;
                        return TaskStatus.Continue;
                    })
                    .Do("OnEnd", () =>
                    {
                        // entity.RemoveComponent<ProjectileAttackComponent>();
                        return TaskStatus.Success;
                    })
                .End()
            .Sequence("chase_target")
                .Condition("TargetInRangeChase", () =>
                {
                    var vision = entity.GetComponent<VisionComponent>();
                    return vision.IsCurrentTargetPresent() && vision.TargetInRangeChase();
                })
                .Do("chase_target", () =>
                {
                    var target = entity.GetComponent<VisionComponent>().currentTargetEntity;
                    var targetTransform = target.GetComponent<TransformComponent>();
                    var trans = entity.GetComponent<TransformComponent>();
                    if (target.isEnabled == false) return TaskStatus.Continue;
                    var targetTrans = target.GetComponent<TransformComponent>();
                    entity.GetComponent<DirectionComponent>().value = (targetTrans.position - trans.position).normalized;
                    return TaskStatus.Success;
                })
            .End()
        .Build();

        return tree;
    }

    public static BehaviorTree CreateDumbassBrain(GameObject gameObject, Entity entity)
    {
        var builder = new BehaviorTreeBuilder(gameObject);
        var tree = builder
            .Sequence("RandomMove")
                .Do("OnBegin", () =>
                {
                    entity.AddComponent<RandomMoveComponent>();
                    return TaskStatus.Success;
                })
                .Do("OnUpdate", () =>
                {
                    return TaskStatus.Continue;
                })
            .End()
            .Build();

        return tree;
    }
}