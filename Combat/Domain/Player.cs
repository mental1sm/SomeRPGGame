using System;
using Desert.Combat.Domain.Skillset;
using Desert.Combat.Domain.Util;

namespace Desert.Combat.Domain;

public sealed class Player : Entity.Entity
{

    public Player(
        int gameId,
        string id,
        string name = "Unnamed",
        float maxHealth = 100,
        float maxEnergy = 100,
        float energyRegenSpeed = 10,
        SkillSet skillSet = null,
        EmitSignalStrategyDefinitionProvider.EmitSignalStrategy emitSignalStrategy = null
    )
        : base(
            gameId: gameId,
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