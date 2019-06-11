using UnityEngine;
using Entitas;

public class GameHUBController: MonoBehaviour
{
    void Start()
    {

    }

    private void Update() {
        if(UnityEngine.Input.GetKeyDown(KeyCode.F))
        {
            FireSkill();
        }
    }

    public void FireSkill()
    {
        InputContext.CreateFireSkillEntity();
    }
}