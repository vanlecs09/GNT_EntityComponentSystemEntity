using Entitas;
using UnityEngine;
using RPG.View;
using RPG.Rendering;

public class AttackSystem : IExecuteSystem
{
    public void Execute()
    {
        var attackEntities = Context<Game>.AllOf<MeleeAttackComponent, CountDownComponent, VisionComponent, AnimatorComponent>().GetEntities();
        foreach (var entity in attackEntities)
        {
            var countdown = entity.GetComponent<CountDownComponent>();
            var attack = entity.GetComponent<MeleeAttackComponent>();
            var targetEntity = entity.GetComponent<VisionComponent>().currentTargetEntity;
            var animator = entity.GetComponent<AnimatorComponent>();
            countdown.currentTime += Time.deltaTime;

            if (countdown.currentTime > countdown.time)
            {
                countdown.currentTime = 0;
                SkillContext.CreateDamangeEntity(targetEntity, attack.damage);
                animator.value.SetTrigger("sword");
                Debug.Log("attacck melee");
            }
        }
    }
}