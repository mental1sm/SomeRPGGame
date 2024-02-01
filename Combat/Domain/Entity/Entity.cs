using System;
using Desert.Combat.Domain.Skillset;
using Desert.Combat.Domain.Util;

namespace Desert.Combat.Domain.Entity;

/// <inheritdoc cref="IEntity"/>
public class Entity : EntityModel, IEntityActions
{
    public Entity()
    {
        
    }
    
    protected Entity(
        int gameId,
        string id,
        string name = "Unnamed", 
        float maxHealth = 100, 
        float maxEnergy = 100, 
        float energyRegenSpeed = 10,
        SkillSet skillSet = null,
        EmitSignalStrategyDefinitionProvider.EmitSignalStrategy emitSignalStrategy = null
        )
    {
        GameId = gameId;
        Id = id;
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        MaxEnergy = maxEnergy;
        CurrentEnergy = maxEnergy;
        EnergyRegenSpeed = energyRegenSpeed;
        if (skillSet != null)
        {
            SkillSet = new SkillSet(parentId: GameId, skillSet: skillSet, emitSignalStrategy: emitSignalStrategy);
        }
        else
        {
            SkillSet = new SkillSet(parentGameId: GameId, emitSignalStrategy: emitSignalStrategy);
        }

        _emitStrategy = emitSignalStrategy;
    }
    
    
    
    /// <inheritdoc/>
    public void TakeDamage(Entity source, Skill.Skill skill)
    {
        CurrentHealth -= skill.AttackStrength;
        EmitSignal(CombatSignal.TakenDamage);
        Console.WriteLine(
            $"Entity with name {this.Name} taken {skill.AttackStrength} damage from entity with name {source.Name}");
    }

    /// <inheritdoc/>
    public void Attack(Entity target, Skill.Skill skill)
    {
        if (SkillSet.UseSkill(skill.Id))
        {
            target.TakeDamage(source: this, skill: skill);
            this.CurrentEnergy -= skill.EnergyCost;
            EmitSignal(CombatSignal.DrainedEnergy);
        }
    }
    
    /// <inheritdoc/>
    public virtual void EndTurn()
    {
        EmitSignal(CombatSignal.EndTurn);
    }

    /// <inheritdoc/>
    public virtual void OnNewTurn()
    {
        SkillSet.UpdateCooldowns();
    }
    

    private EmitSignalStrategyDefinitionProvider.EmitSignalStrategy _emitStrategy;

    /// <summary>
    /// Излучает сигнал, используя стратегию излучения.
    /// </summary>
    /// <param name="signalType">Тип сигнала (CombatSignals.cs)</param>
    private void EmitSignal(CombatSignal signalType)
    {
        Console.WriteLine($"Entity with id:{Id} and name:{Name} is emitting signal {signalType}.");
        _emitStrategy?.Invoke(signalType: signalType, this.GameId);
    }
    
}