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
            // var countdown = entity.GetComponent<CountDownComponent>();
            var stat = entity.GetComponent<StatComponent>();
            var attack = entity.GetComponent<MeleeAttackComponent>();
            var coolDown = attack.coolDown;
            var targetEntity = entity.GetComponent<VisionComponent>().currentTargetEntity;
            var animator = entity.GetComponent<AnimatorComponent>();
            coolDown.currentTime += Time.deltaTime;
            coolDown.time = stat.baseAttackSpeed * stat.attackSpeedModifier;

            if (coolDown.currentTime >= coolDown.time)
            {
                coolDown.currentTime = 0;
                SkillContext.CreateDamangeEntity(targetEntity, attack.damage);
                animator.value.SetTrigger("sword");
            }
        }
    }
}