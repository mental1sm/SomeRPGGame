using Desert.Combat.Domain.Skillset;

namespace Desert.Combat.Domain.Skill;

/// <inheritdoc/>
public class Skill : ISkill
{

    public Skill(string id, string name, float attackStrength, int cooldown, float energyCost)
    {
        this.Id = id;
        this.Name = name;
        this.AttackStrength = attackStrength;
        this.Cooldown = cooldown;
        this.EnergyCost = energyCost;
    }
    
    /// <inheritdoc/>
    public string Id { get; set; }
    
    /// <inheritdoc/>
    public string Name { get; set; }
    
    /// <inheritdoc/>
    public float AttackStrength { get; set; }
    
    /// <inheritdoc/>
    public int Cooldown { get; set; }
    
    /// <inheritdoc/>
    public float EnergyCost { get; set; }
}