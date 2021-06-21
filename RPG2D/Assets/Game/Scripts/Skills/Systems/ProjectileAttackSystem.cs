using Entitas;
using UnityEngine;
using RPG.Rendering;
using RPG.View;

public class ProjectileAttackSystem : IExecuteSystem
{
    public void Execute()
    {
        var attackEntities = Context<Game>.AllOf<ProjectileAttackComponent, VisionComponent, AnimatorComponent, StatComponent>().GetEntities();
        foreach (var entity in attackEntities)
        {
            // var countdown = entity.GetComponent<CoolDownComponent>();
            var stat = entity.GetComponent<StatComponent>();
            var attack = entity.GetComponent<ProjectileAttackComponent>();
            if (!attack.enable) continue;
            var targetEntity = entity.GetComponent<VisionComponent>().currentTargetEntity;
            var animator = entity.GetComponent<AnimatorComponent>();
            var coolDown = attack.coolDown;
            if (coolDown.currentTime == 0)
            {
                var transform = entity.GetComponent<TransformComponent>();
                var direction = entity.GetComponent<DirectionComponent>();
                animator.value.SetTrigger("crossbow");
                GameContext.CreateProjectileEntity(attack.fireTrans.position, direction.value, entity.GetComponent<TeamComponent>().value, attack);
                // coolDown.currentTime = 0;
            }

            coolDown.currentTime += Time.deltaTime;
            if (coolDown.currentTime > coolDown.time)
            {
                coolDown.currentTime = 0;
                var vision = entity.GetComponent<VisionComponent>();
                if (!vision.IsCurrentTargetPresent() || !vision.TargetInRangeAttack())
                {
                    attack.enable = false;
                }
            }
        }
    }
}