using Entitas;
using UnityEngine;
using RPG.View;
public static class GameContext
{
    public static void CreateMovingEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 3.0f, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(Vector3.zero, new Vector3(1, 1, 1), Quaternion.identity);
    }

    public static void CreatePlayerEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 3.0f, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(Vector3.zero, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<PlayerComponent>();
    }

    public static void CreateSkillSimpleEntity(Vector3 position, Vector3 direction_)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/Skill_1", LayerMask.NameToLayer("PlayerSkill"));
        entity.AddComponent<TransformComponent>().Initialize(position, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 2.0f, direction_);
        // entity.AddComponent<DamageComponent>().Initialize(10);
        entity.AddComponent<SkillComponent>().Initialize(SKILL_TYPE.SIMPLE);
    }

    public static void CreateSkillSlowEntity(Vector3 position, Vector3 direction_)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/fire", LayerMask.NameToLayer("PlayerSkill"));
        entity.AddComponent<TransformComponent>().Initialize(position, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 5.0f, direction_);
        var steering  = entity.AddComponent<SteeringBehaviorComponent>();
        steering.LinearOn();
        entity.AddComponent<SlowMoveComponent>().Initialize(2.0f);
        entity.AddComponent<SkillComponent>().Initialize(SKILL_TYPE.DRAW_DANGER_SLOW);
        entity.AddComponent<CountDownComponent>().Initialize(2.0f);
    }

    public static void CreateSkillFireSoulsEntity(Entity targetEntity_, Vector3 offsetToTarget_)
    {
        var numerEntity = 3;
        for (var i = 0; i < numerEntity; i++)
        {
            var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
            entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/fire", LayerMask.NameToLayer("PlayerSkill"));
            entity.AddComponent<RadiusRangeComponent>().Initialize(3.0f);
            FollowAroundTargetComponent followAround = entity.AddComponent<FollowAroundTargetComponent>();
            followAround.Initialize(targetEntity_, offsetToTarget_, 50.0f, 360.0f / numerEntity * i);
            var direction = new Vector3(Mathf.Sin(Mathf.Deg2Rad * followAround.currentAngle), 0, Mathf.Cos(Mathf.Deg2Rad * followAround.currentAngle));
            var targetPos = targetEntity_.Get<TransformComponent>().position;
            entity.AddComponent<TransformComponent>().Initialize(targetPos - offsetToTarget_.magnitude * direction.normalized, new Vector3(1, 1, 1), Quaternion.identity);
            entity.AddComponent<DamageComponent>().Initialize(10);
            entity.AddComponent<SkillComponent>().Initialize(SKILL_TYPE.FIRE_SOULS);
        }
    }

    public static void CreateSkillWaterTsunami(Vector3 position_, Vector3 direction_)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/Skill_1", LayerMask.NameToLayer("PlayerSkill"));
        entity.AddComponent<TransformComponent>().Initialize(position_, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 5.0f, direction_);
        var steering  = entity.AddComponent<SteeringBehaviorComponent>();
        steering.LinearOn();
        entity.AddComponent<DamageComponent>().Initialize(10.0f);
        entity.AddComponent<SkillComponent>().Initialize(SKILL_TYPE.WATER_TSUNAMI);
    }



    public static void CreateSkillFireBombEntity(Vector3 position_, Vector3 direction_)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/Skill_1", LayerMask.NameToLayer("PlayerSkill"));
        entity.AddComponent<TransformComponent>().Initialize(position_, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 3.0f, direction_);
        var steering  = entity.AddComponent<SteeringBehaviorComponent>();
        steering.LinearOn();
        entity.AddComponent<AreaDamageComponent>().Initialize(10.0f, 2.0f);
        entity.AddComponent<SkillComponent>().Initialize(SKILL_TYPE.FIRE_BOMB);
        entity.AddComponent<DebugDrawCircleComponent>().Initialize(2.0f, Color.red);
    }

    public static void CreateSkillBubblePrisonComponent(Vector3 position_, Vector3 direction_)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/Skill_1", LayerMask.NameToLayer("PlayerSkill"));
        entity.AddComponent<TransformComponent>().Initialize(position_, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 10.0f, direction_);
        var steering  = entity.AddComponent<SteeringBehaviorComponent>();
        steering.LinearOn();
        entity.AddComponent<FreezeComponent>().Initialize(3.0f);
        entity.AddComponent<SkillComponent>().Initialize(SKILL_TYPE.BUBBLE_PRISON);
    }

    public static void CreateSkillEarthSpike(Vector3 position_, float range)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<TransformComponent>().Initialize(position_, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<DamageComponent>().Initialize(10.0f);
        entity.AddComponent<FreezeComponent>().Initialize(range);
        entity.AddComponent<RadiusRangeComponent>().Initialize(range);
        entity.AddComponent<DebugDrawCircleComponent>().Initialize(range, Color.red);
    }


    public static void CreateWallEntity(Vector3 position_, float radius_, float countDown)
    {
        for (int i = 0; i < 20; i++)
        {
            var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
            entity.AddComponent<AssetComponent>().Initialize("Prefabs/uls/skill_earth_prison", LayerMask.NameToLayer("PlayerSkill"));
            Vector2 dir2D = Utils.Math.DegreeToVector2(360.0f / 20.0f * (i + 1));
            Vector3 dir3D = new Vector3(dir2D.x, 0, dir2D.y);
            var position = position_ + dir3D * radius_;
            entity.AddComponent<TransformComponent>().Initialize(position, new Vector3(1, 1, 1), Quaternion.identity);
            entity.AddComponent<WallAroundComponent>();
            entity.AddComponent<CountDownComponent>().Initialize(countDown);
        }
    }

    public static void CreateArrowSlowEntity(Vector3 position_)
    {
    }


    public static void CreateBotEntity()
    {

    }

    public static bool IsEntityAlive(Entity entity)
    {
        return Contexts.sharedInstance.GetContext<Game>().GetEntity(entity.creationIndex) != null;
    }
}