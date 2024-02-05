using System.ComponentModel.DataAnnotations.Schema;
using Desert.Combat.Domain.Skillset;

namespace Desert.Combat.Domain.Entity;

public class EntityModel : IEntity
{
    /// <inheritdoc/>
    public string Id { get; set; }

    /// <inheritdoc/>
    [NotMapped]
    public int GameId { get; set; }

    /// <inheritdoc/>
    public string Name { get; set; }
    
    /// <inheritdoc/>
    [NotMapped]
    public float CurrentHealth { get; set; }
    
    /// <inheritdoc/>
    public float MaxHealth { get; set; }
    
    /// <inheritdoc/>
    [NotMapped]
    public float CurrentEnergy { get; set; }
    
    /// <inheritdoc/>
    public float MaxEnergy { get; set; }
    
    /// <inheritdoc/>
    public float EnergyRegenSpeed { get; set; }

    /// <inheritdoc/>
    public SkillSet SkillSet { get; set; }
    
    /// <inheritdoc/>
    public int SkillSetId { get; set; }
}