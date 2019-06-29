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
            SkillFireBome();
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.W))
        {
            SkillBubblePrison();
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

    public void SkillBubblePrison()
    {
        InputContext.CreateSkillEntity(SKILL_TYPE.BUBBLE_PRISON);
    }
}