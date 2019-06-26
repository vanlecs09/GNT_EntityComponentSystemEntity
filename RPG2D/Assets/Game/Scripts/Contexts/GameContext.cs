using Entitas;
using UnityEngine;
using RPG.View;
public static class GameContext
{
    public static void CreateMovingEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(Vector3.zero, new Vector3(1, 1, 1), Quaternion.identity);
    }

    public static void CreatePlayerEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(Vector3.zero, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<PlayerComponent>();
    }

    public static void CreateSkillSimpleEntity(Vector3 position, Vector3 direction_)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/Skill_1", LayerMask.NameToLayer("PlayerSkill"));
        entity.AddComponent<TransformComponent>().Initialize(position, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<MoveComponent>().Initialize(direction_ * 2, Vector3.zero);
        entity.AddComponent<DamageComponent>().Initialize(10);
        entity.AddComponent<SkillComponent>().Initialize(SKILL_TYPE.SIMPLE);
    }

    public static void CreateSkillFireSoulsEntity(Entity targetEntity_, Vector3 offsetToTarget_)
    {
        var numerEntity = 3;
        for (var i = 0; i < numerEntity; i++)
        {
            var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
            entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/Skill_1", LayerMask.NameToLayer("PlayerSkill"));
            entity.AddComponent<InRadiusRangeComponent>().Initialize(3.0f);
            FollowAroundTargetComponent followAround = entity.AddComponent<FollowAroundTargetComponent>();
            followAround.Initialize(targetEntity_, offsetToTarget_, 50.0f, 360.0f/numerEntity * i);
            var direction = new Vector3(Mathf.Sin(Mathf.Deg2Rad * followAround.currentAngle), 0, Mathf.Cos(Mathf.Deg2Rad * followAround.currentAngle));
            var targetPos = targetEntity_.Get<TransformComponent>().position;
            entity.AddComponent<TransformComponent>().Initialize(targetPos - offsetToTarget_.magnitude * direction.normalized, new Vector3(1, 1, 1), Quaternion.identity);  
            entity.AddComponent<DamageComponent>().Initialize(10);
            entity.AddComponent<SkillComponent>().Initialize(SKILL_TYPE.FIRE_SOULS);
        }
    }

    public static void CreateSkillFireBombEntity(Vector3 position_, Vector3 direction_)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/Skill_1", LayerMask.NameToLayer("PlayerSkill"));
        entity.AddComponent<InRadiusRangeComponent>().Initialize(5.0f);
        entity.AddComponent<TransformComponent>().Initialize(position_, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<MoveComponent>().Initialize(direction_ * 1, Vector3.zero);
        entity.AddComponent<DamageComponent>().Initialize(10);
        entity.AddComponent<SkillComponent>().Initialize(SKILL_TYPE.FIRE_BOMB);
    }

    public static void CreateSkillBubblePrison(Vector3 position_, Vector3 direction_)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/Skill_1", LayerMask.NameToLayer("PlayerSkill"));
        entity.AddComponent<TransformComponent>().Initialize(position_, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<MoveComponent>().Initialize(direction_ * 2, Vector3.zero);
        entity.AddComponent<FreezeComponent>().Initialize(1);
        entity.AddComponent<SkillComponent>().Initialize(SKILL_TYPE.BUBBLE_PRISON);
    }

    public static void CreateDamageAreaEntity(float radius, float interval)
    {

    }

    public static void CreateBotEntity()
    {

    }
}