using Entitas;
using UnityEngine;
using RPG.View;
using System.Collections.Generic;

public static class GameContext
{
    public static void CreateSimpleEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Characters/pref_swordman", LayerMask.NameToLayer("Bot"));
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 3.0f, Vector3.right);
        entity.AddComponent<TransformComponent>().Initialize(new Vector3(-2, 0, 2), new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<TeamComponent>().Initialize(TEAM.A);
        var heatth = entity.AddComponent<HealthComponent>();
        heatth.current = 10;
        heatth.max = 10;
        entity.AddComponent<BotComponent>();
        entity.AddComponent<VisionComponent>().Initiazlize(10, 8, 1);
    }


    public static void CreateSimpleEntity2()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Characters/pref_swordman", LayerMask.NameToLayer("Bot"));
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 3.0f, Vector3.left);
        entity.AddComponent<TransformComponent>().Initialize(new Vector3(2, 0, -2), new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<TeamComponent>().Initialize(TEAM.B);
        entity.AddComponent<HealthComponent>().Initialize(10.0f);
        entity.AddComponent<BotComponent>();
        entity.AddComponent<VisionComponent>().Initiazlize(10, 8, 1);
    }

    public static void CreateCrossBowHumanEntity(Vector3 position, TEAM team, List<BuffComponent> buffs, List<DebuffComponent> debuffs)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<ProjectileAttackComponent>().Initialize(5.0f, 1.0f, null, buffs, debuffs);
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Characters/pref_crossbowman", LayerMask.NameToLayer("Human"));
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 3.0f, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(position, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<TeamComponent>().Initialize(team);
        entity.AddComponent<DirectionComponent>().Initialize(Vector3.zero);
        entity.AddComponent<HealthComponent>().Initialize(100.0f);
        entity.AddComponent<PlayerComponent>();
        entity.AddComponent<VisionComponent>().Initiazlize(14, 12, 10);
        entity.AddComponent<HumanComponent>();
        entity.AddComponent<StatComponent>().Initialize(1, 3.0f);
        // entity.AddComponent<ForceMoveComponent>();
        var buff = entity.AddComponent<BuffAtackSpeedComponent>();
    }

    public static void CreateCrossBowBotEntity(Vector3 position, TEAM team, List<BuffComponent> buffs, List<DebuffComponent> debuffs)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<ProjectileAttackComponent>().Initialize(5.0f, 1.0f, null, buffs, debuffs);
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Characters/pref_crossbowman", LayerMask.NameToLayer("Bot"));
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 3.0f, Vector3.zero);
        entity.AddComponent<TransformComponent>().Initialize(position, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<TeamComponent>().Initialize(team);
        entity.AddComponent<DirectionComponent>().Initialize(Vector3.zero);
        entity.AddComponent<HealthComponent>().Initialize(100.0f);
        entity.AddComponent<BotComponent>();
        entity.AddComponent<VisionComponent>().Initiazlize(14, 12, 10);
        entity.AddComponent<HumanComponent>();
        entity.AddComponent<StatComponent>().Initialize(1, 3.0f);
        var buff = entity.AddComponent<BuffAtackSpeedComponent>();
    }


    public static void CreateSwordManBotEntity(Vector3 position, TEAM team, List<BuffComponent> buffs, List<DebuffComponent> debuffss)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Characters/pref_swordman", LayerMask.NameToLayer("Bot"));
        entity.AddComponent<TransformComponent>().Initialize(position, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<TeamComponent>().Initialize(team);
        entity.AddComponent<DirectionComponent>().Initialize(Vector3.zero);
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 2, Vector3.zero);
        entity.AddComponent<HealthComponent>().Initialize(10.0f);
        entity.AddComponent<VisionComponent>().Initiazlize(15, 12, 1);
        entity.AddComponent<BotComponent>();
        entity.AddComponent<MeleeAttackComponent>().Initialize(0.5f, 2.0f, buffs, debuffss);
        entity.AddComponent<HumanComponent>();
        entity.AddComponent<StatComponent>().Initialize(1, 2.0f);
    }


    public static void CreateEasyDummyBotEntity()
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Characters/pref_swordman", LayerMask.NameToLayer("Bot"));
    }

    public static void CreateDummyBotEntity(Vector3 position)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Characters/pref_swordman", LayerMask.NameToLayer("Bot"));
        entity.AddComponent<TransformComponent>().Initialize(position, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<TeamComponent>().Initialize(TEAM.B);
        entity.AddComponent<DirectionComponent>().Initialize(Vector3.zero);
        entity.AddComponent<HealthComponent>().Initialize(10.0f);
        entity.AddComponent<DummyBotComponent>();
    }


    public static void CreateProjectileEntity(Vector3 position, Vector3 direction, TEAM team, ProjectileAttackComponent attack)
    {
        var entity = Contexts.sharedInstance.GetContext<Game>().CreateEntity();
        entity.AddComponent<AssetComponent>().Initialize("Prefabs/Skills/electric", LayerMask.NameToLayer("Skill"));
        entity.AddComponent<TransformComponent>().Initialize(position, new Vector3(1, 1, 1), Quaternion.identity);
        entity.AddComponent<TeamComponent>().Initialize(team);
        entity.AddComponent<MoveComponent>().Initialize(Vector3.zero, Vector3.zero, 10.0f, direction);
        entity.AddComponent<DirectionComponent>().Initialize(direction);
        entity.AddComponent<ProjectileAttackComponent>().Clone(attack);
        entity.AddComponent<ImmunityCollision>();
    }

    public static void CreateSlowProjectileEntity(Vector3 position, Vector3 direction, TEAM team, ProjectileAttackComponent attack)
    {

    }


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
        var steering = entity.AddComponent<SteeringBehaviorComponent>();
        steering.LinearOn();
        entity.AddComponent<SlowMoveComponent>().Initialize(2.0f);
        entity.AddComponent<SkillComponent>().Initialize(SKILL_TYPE.DRAW_DANGER_SLOW);
        entity.AddComponent<CoolDownComponent>().Initialize(2.0f);
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
        var steering = entity.AddComponent<SteeringBehaviorComponent>();
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
        var steering = entity.AddComponent<SteeringBehaviorComponent>();
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
        var steering = entity.AddComponent<SteeringBehaviorComponent>();
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
            entity.AddComponent<CoolDownComponent>().Initialize(countDown);
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