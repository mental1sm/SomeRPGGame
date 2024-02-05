using System.Collections.Generic;
using Desert.Combat.Domain.Entity;
using Desert.Combat.Domain.Skill;

namespace Desert.Combat.Godot.Util;

/// <inheritdoc/>
public class EntityBehaviorController : IEntityBehaviorController
{
    private Entity _entity;
    public EntityBehaviorController(BattleManager battleManager, Entity entity)
    {
        _battleManager = battleManager;
        _entity = entity;
    }
    public BattleManager BattleManager
    {
        set => _battleManager = value;
    }
    private BattleManager _battleManager;

    /// <inheritdoc/>
    public void RegisterEntity()
    {
        _battleManager.RegisterEntity(_entity);
    }

    /// <inheritdoc/>
    public Entity GetEntityCloneById(int entityGameId)
    {
       return _battleManager.GetEntityById(entityGameId);
    }

    /// <inheritdoc/>
    public List<Entity> GetAllEntities()
    {
        return _battleManager.Entities;
    }

    /// <inheritdoc/>
    public HashSet<Skill> GetEntitySkillsByGameId(int entityGameId)
    {
        return _battleManager.GetEntityById(entityGameId).SkillSet.Skills;
    }

    /// <inheritdoc/>
    public bool UseSkill(int targetGameId, Skill skill)
    {
        return _battleManager.UseSkill(_entity, targetGameId, skill);
    }

    /// <inheritdoc/>
    public void EndTurn()
    {
        _battleManager.EndTurn(_entity);
    }

    /// <inheritdoc/>
    public void NotifyReady()
    {
        _battleManager.NotifyReady(_entity);
    }
}