using System.ComponentModel.DataAnnotations.Schema;
using Desert.Combat.Domain;
using Desert.Combat.Domain.Skillset;

namespace Desert.Combat.Domain.Entity;

/// <summary>
/// Класс, представляющий собой энтити
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Уникальный идентификатор сущности
    /// </summary>
    string Id { get; set; }
    
    /// <summary>
    /// Внутренний ID, присвоенный игрой. Все время меняется.
    /// </summary>
    [NotMapped]
    int GameId { get; set; }
    
    /// <summary>
    /// Имя сущности
    /// </summary>
    string Name { get; set; }
    
    /// <summary>
    /// Текущее HP
    /// </summary>
    float CurrentHealth { get; set; }
    
    /// <summary>
    /// Максимальное HP
    /// </summary>
    float MaxHealth { get; set; }
    
    /// <summary>
    /// Текущая энергия
    /// </summary>
    float CurrentEnergy { get; set; }
    
    /// <summary>
    /// Максимальная энергия
    /// </summary>
    float MaxEnergy { get; set; }
    
    /// <summary>
    /// Скорость регенерации энергии (в ход)
    /// </summary>
    float EnergyRegenSpeed { get; set; }

    /// <summary>
    /// Скиллсет сущности
    /// </summary>
    [NotMapped]
    SkillSet SkillSet { get; set; }
    
    /// <summary>
    /// ID скиллсета (для FK)
    /// </summary>
    int SkillSetId { get; set; }
    
}