using Entitas;
using UnityEngine;
using RPG.View;
using RPG.Rendering;

public class MeeleeAttackSystem : IExecuteSystem
{
    public void Execute()
    {
        var attackEntities = Context<Game>.AllOf<MeleeAttackComponent, VisionComponent, AnimatorComponent, StatComponent>().GetEntities();
        foreach (var entity in attackEntities)
        {
            var stat = entity.GetComponent<StatComponent>();
            var attack = entity.GetComponent<MeleeAttackComponent>();
            if (!attack.enable) continue;
            var coolDown = attack.coolDown;
            var targetEntity = entity.GetComponent<VisionComponent>().currentTargetEntity;
            var animator = entity.GetComponent<AnimatorComponent>();
            if (coolDown.currentTime == 0)
            {
                animator.value.SetTrigger("sword");
                SkillContext.CreateDamangeEntity(targetEntity, attack.damage);
            }
            coolDown.currentTime += Time.deltaTime;
            if (coolDown.currentTime >= coolDown.time)
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