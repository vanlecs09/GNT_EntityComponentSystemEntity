using UnityEngine;
using Entitas;

public class GameHUBController : MonoBehaviour
{
    void Start()
    {

    }

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.F))
        {
            FireSkill();
        }
    }

    public void SimpleSkill()
    {
        InputContext.CreateSkillEntity(SKILL_TYPE.SIMPLE);
    }

    public void FireSkill()
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