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
            var targetEntity = entity.GetComponent<VisionComponent>().currentTargetEntity;
            var animator = entity.GetComponent<AnimatorComponent>();
            var coolDown = attack.coolDown;
            coolDown.currentTime += Time.deltaTime;
            coolDown.time = stat.baseAttackSpeed * stat.attackSpeedModifier;

            if (coolDown.currentTime > coolDown.time)
            {
                var transform = entity.GetComponent<TransformComponent>();
                var direction = entity.GetComponent<DirectionComponent>();
                coolDown.currentTime = 0;
                GameContext.CreateProjectileEntity(transform.position + attack.fireTrans.position, direction.value, entity.GetComponent<TeamComponent>().value, attack);
                animator.value.SetTrigger("crossbow");
            }
        }
    }
}