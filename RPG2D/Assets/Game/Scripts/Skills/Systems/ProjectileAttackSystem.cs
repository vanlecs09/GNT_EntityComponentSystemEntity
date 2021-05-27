using Entitas;
using UnityEngine;
using RPG.Rendering;
using RPG.View;

public class ProjectileAttackSystem : IExecuteSystem
{
    public void Execute()
    {
        var attackEntities = Context<Game>.AllOf<ProjectileAttackComponent, CountDownComponent, VisionComponent, AnimatorComponent>().GetEntities();
        foreach (var entity in attackEntities)
        {
            var countdown = entity.GetComponent<CountDownComponent>();
            var attack = entity.GetComponent<ProjectileAttackComponent>();
            var targetEntity = entity.GetComponent<VisionComponent>().currentTargetEntity;
            var animator = entity.GetComponent<AnimatorComponent>();
            countdown.currentTime += Time.deltaTime;

            if (countdown.currentTime > countdown.time)
            {
                var transform = entity.GetComponent<TransformComponent>();
                var direction = entity.GetComponent<DirectionComponent>();
                countdown.currentTime = 0;
                GameContext.CreateProjectileEntity(transform.position + attack.firePoint, direction.value, entity.GetComponent<TeamComponent>().value, attack);
                animator.value.SetTrigger("crossbow");
            }
        }
    }
}