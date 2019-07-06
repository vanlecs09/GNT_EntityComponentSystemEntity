using UnityEngine;
using Entitas;

public class GameHUBController : MonoBehaviour
{
    void Start()
    {

    }

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
        {
            UnityEngine.Debug.Log("q press ");
            // SkillFireBome();
            // GameContext.CreateWallEntity(Vector3.zero, 2.0f, 5.0f);
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
    }

    public void SimpleSkill()
    {
        InputContext.CreateSkillEntity(SKILL_TYPE.SIMPLE);
    }

    public void SkillFireSouls()
    {
        InputContext.CreateSkillEntity(SKILL_TYPE.FIRE_SOULS);
    }

    public void SkillFireBome()
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
}

internal class UnityEnDebug
{
}