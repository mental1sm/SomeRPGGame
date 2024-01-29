using System;

namespace Desert.Combat.Domain;

public class Mob : Entity
{
    public Mob(
        int id,
        string name = "Unnamed",
        float maxHealth = 100,
        float maxEnergy = 100,
        float energyRegenSpeed = 10,
        SkillSet skillSet = null,
        EmitSignalStrategyDefinitionProvider.EmitSignalStrategy emitSignalStrategy = null
    )
        : base(
            id: id,
            name: name,
            maxHealth: maxHealth,
            maxEnergy: maxEnergy,
            energyRegenSpeed: energyRegenSpeed,
            skillSet: skillSet,
            emitSignalStrategy: emitSignalStrategy
        )
    {
        Console.WriteLine($"Моб с ID {id} был инициализирован!");
    }
    
}