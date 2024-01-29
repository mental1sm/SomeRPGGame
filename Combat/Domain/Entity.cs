using System;
using Godot;

namespace Desert.Combat.Domain;

/// <inheritdoc/>
public abstract class Entity : IEntity
{
    protected Entity(
        int id,
        string name = "Unnamed", 
        float maxHealth = 100, 
        float maxEnergy = 100, 
        float energyRegenSpeed = 10,
        SkillSet skillSet = null,
        EmitSignalStrategyDefinitionProvider.EmitSignalStrategy emitSignalStrategy = null
        )
    {
        Id = id;
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        MaxEnergy = maxEnergy;
        CurrentEnergy = maxEnergy;
        EnergyRegenSpeed = energyRegenSpeed;
        if (skillSet != null)
        {
            SkillSet = new SkillSet(parentId: Id, skillSet: skillSet, emitSignalStrategy: emitSignalStrategy);
        }
        else
        {
            SkillSet = new SkillSet(parentId: Id, emitSignalStrategy: emitSignalStrategy);
        }

        _emitStrategy = emitSignalStrategy;
    }
    

    /// <inheritdoc/>
    public int Id { get; }

    /// <inheritdoc/>
    public string Name { get; set; }
    
    /// <inheritdoc/>
    public float CurrentHealth { get; set; }
    
    /// <inheritdoc/>
    public float MaxHealth { get; set; }
    
    /// <inheritdoc/>
    public float CurrentEnergy { get; set; }
    
    /// <inheritdoc/>
    public float MaxEnergy { get; set; }
    
    /// <inheritdoc/>
    public float EnergyRegenSpeed { get; set; }

    /// <inheritdoc/>
    public ISkillSet SkillSet { get; }
    
    /// <inheritdoc/>
    public void TakeDamage(IEntity source, ISkill skill)
    {
        this.CurrentHealth -= skill.AttackStrength;
        Console.WriteLine(
            $"Entity with name {this.Name} taken {skill.AttackStrength} damage from entity with name {source.Name}");
    }

    /// <inheritdoc/>
    public void Attack(IEntity target, ISkill skill)
    {
        if (SkillSet.UseSkill(skill.Id))
        {
            target.TakeDamage(source: this, skill: skill);    
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
        _emitStrategy?.Invoke(signalType: signalType, this.Id);
    }
    
}