
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
                        entity.AddComponent<ForceMoveComponent>();
                        if (entity.Has<MeleeAttackComponent>())
                        {
                            entity.GetComponent<MeleeAttackComponent>().enable = true;
                        }

                        if (entity.Has<ProjectileAttackComponent>())
                        {
                            entity.GetComponent<ProjectileAttackComponent>().enable = true;
                        }
                        return TaskStatus.Success;
                    })
                    .Do("OnUpdate", () =>
                    {
                        var vision = entity.GetComponent<VisionComponent>();
                        var attack = entity.GetComponent<MeleeAttackComponent>();
                        var projectielAttack = entity.GetComponent<ProjectileAttackComponent>();
                        if (!vision.IsCurrentTargetPresent() || !vision.TargetInRangeAttack()
                                 && ((attack != null && attack.enable == false) || (projectielAttack != null && projectielAttack.enable == false)))
                        {
                            return TaskStatus.Success;
                        }
                        var trans = entity.GetComponent<TransformComponent>();
                        var target = vision.currentTargetEntity;
                        if (target.isEnabled == false) return TaskStatus.Continue;
                        var targetTrans = target.GetComponent<TransformComponent>();
                        entity.GetComponent<MoveComponent>().direction = (targetTrans.position - trans.position).normalized;
                        entity.GetComponent<DirectionComponent>().value = (targetTrans.position - trans.position).normalized;
                        return TaskStatus.Continue;
                    })
                    .Do("OnEnd", () =>
                    {
                        entity.Remove<ForceMoveComponent>();
                        // entity.GetComponent<MoveComponent>().speed = entity.GetComponent<MoveComponent>().
                        if (entity.Has<MeleeAttackComponent>())
                        {
                            entity.GetComponent<MeleeAttackComponent>().enable = false;
                        }

                        if (entity.Has<ProjectileAttackComponent>())
                        {
                            entity.GetComponent<ProjectileAttackComponent>().enable = false;
                        }
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
                        entity.GetComponent<MoveComponent>().direction = (targetTrans.position - trans.position).normalized;
                        entity.GetComponent<DirectionComponent>().value = (targetTrans.position - trans.position).normalized;
                        return TaskStatus.Success;
                    })
                .End()
            .Build();

        return tree;
    }


    public static BehaviorTree CreateNormalBrain2(GameObject gameObject, Entity entity)
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
                        if (entity.Has<MeleeAttackComponent>())
                        {
                            entity.GetComponent<MeleeAttackComponent>().enable = true;
                        }

                        if (entity.Has<ProjectileAttackComponent>())
                        {
                            entity.GetComponent<ProjectileAttackComponent>().enable = true;
                        }
                        return TaskStatus.Success;
                    })
                    .Do("OnUpdate", () =>
                    {
                        var vision = entity.GetComponent<VisionComponent>();
                        var attack = entity.GetComponent<MeleeAttackComponent>();
                        var projectielAttack = entity.GetComponent<ProjectileAttackComponent>();
                        if (!vision.IsCurrentTargetPresent() || !vision.TargetInRangeAttack()
                                && ((attack != null && attack.enable == false) || (projectielAttack != null && projectielAttack.enable == false)))
                        {
                            return TaskStatus.Success;
                        }
                        var trans = entity.GetComponent<TransformComponent>();
                        var target = vision.currentTargetEntity;
                        if (target.isEnabled == false) return TaskStatus.Continue;
                        var targetTrans = target.GetComponent<TransformComponent>();
                        // entity.GetComponent<MoveComponent>().direction = (targetTrans.position - trans.position).normalized;
                        entity.GetComponent<DirectionComponent>().value = (targetTrans.position - trans.position).normalized;
                        return TaskStatus.Continue;
                    })
                    .Do("OnEnd", () =>
                    {
                        if (entity.Has<MeleeAttackComponent>())
                        {
                            entity.GetComponent<MeleeAttackComponent>().enable = false;
                        }

                        if (entity.Has<ProjectileAttackComponent>())
                        {
                            entity.GetComponent<ProjectileAttackComponent>().enable = false;
                        }
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