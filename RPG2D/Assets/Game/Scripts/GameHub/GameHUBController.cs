using UnityEngine;
using Entitas;
using System.Collections;
using RPG.View;
public class GameHUBController : MonoBehaviour
{
    EntitySaveLoader _entitySaveLoader = null;

    void Start()
    {
        _entitySaveLoader = new EntitySaveLoader(new TemplateLoader());
        _entitySaveLoader.ReLoadTemplets();

        StartCoroutine("RepeatingFunction");
    }

    IEnumerator RepeatingFunction()
    {
        while (true)
        {
            //execute code here.
            yield return new WaitForSeconds(2.0f);
            for (var i = 0; i < 10; i++)
            {
                Entity bot  = _entitySaveLoader.MakeEntityFromtemplate("bot", Contexts.sharedInstance) as Entity;
                var offset = new Vector3(-2,0,-2);
                bot.Modify<TransformComponent>().position = new Vector3(Random.Range(-2, 2) + 3, 0, Random.Range(-2, 2) + 3);
            }
        }
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

        if (UnityEngine.Input.GetKeyDown(KeyCode.T))
        {
            SkillWaterTSunami();
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.F))
        {
            SkillWaterColdBreath();
        }

        if (UnityEngine.Input.GetKeyUp(KeyCode.F))
        {
            RemoveSkillWaterColdBreath();
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Tab))
        {
            _entitySaveLoader.MakeEntityFromtemplate("bot", Contexts.sharedInstance);
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
