using UnityEngine;
using Entitas;
using System.Collections;
using RPG.View;
public class GameHUBController : MonoBehaviour
{
    void Start()
    {
    }

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
        {
            SkillEarchSpike();
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.W))
        {
            SkillBubblePrisonComponent();
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            SkillFireSouls();
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.R))
        {
            SkillFireBomb();
        }

        // if (UnityEngine.Input.GetKeyDown(KeyCode.T))
        // {
        //     SkillWaterTSunami();
        // }

        if (UnityEngine.Input.GetKeyDown(KeyCode.F))
        {
            SkillWaterColdBreath();
        }

        if (UnityEngine.Input.GetKeyUp(KeyCode.F))
        {
            RemoveSkillWaterColdBreath();
        }

        // if (UnityEngine.Input.GetKeyDown(KeyCode.Tab))
        // {
        //     _entitySaveLoader.MakeEntityFromtemplate("bot", Contexts.sharedInstance);
        // }

        if (UnityEngine.Input.GetKeyDown(KeyCode.T))
        {
            InputContext.CreateSkillEntity(SKILL_TYPE.DRAW_DANGER_SLOW);
        }



        if (UnityEngine.Input.GetKeyDown(KeyCode.Y))
        {
            var playerEntities = Context<Game>.AllOf<PlayerComponent>().GetEntities();
            var playerEntity = playerEntities[0];
            var playerPos = playerEntity.Get<TransformComponent>().position;
            var playerDir = playerEntity.Get<DirectionComponent>().value;
            SkillContext.CreateSkillPushBackEntity(playerEntity, 0.5f);
        }
    }

    public void SkillWaterTSunami()
    {
        InputContext.CreateSkillEntity(SKILL_TYPE.WATER_TSUNAMI);
    }

    public void SimpleSkill()
    {
        InputContext.CreateSkillEntity(SKILL_TYPE.SIMPLE);
    }

    public void SkillFireSouls()
    {
        InputContext.CreateSkillEntity(SKILL_TYPE.FIRE_SOULS);
    }

    public void SkillFireBomb()
    {
        InputContext.CreateSkillEntity(SKILL_TYPE.FIRE_BOMB);
    }

    public void SkillBubblePrisonComponent()
    {
        InputContext.CreateSkillEntity(SKILL_TYPE.BUBBLE_PRISON);
    }

    public void SkillEarthPrison()
    {
        InputContext.CreateSkillEntity(SKILL_TYPE.EARTH_PRISON);
    }

    public void SkillEarchSpike()
    {
        InputContext.CreateSkillEntity(SKILL_TYPE.EARTH_SPIKE);
    }

    public void SkillWaterColdBreath()
    {
        InputContext.CreateSkillEntity(SKILL_TYPE.WATER_COLD_BREATH);
    }

    public void RemoveSkillWaterColdBreath()
    {
        SkillContext.RemoveSkillWaterColdBreath();
    }
}
