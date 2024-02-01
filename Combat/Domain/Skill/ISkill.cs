namespace Desert.Combat.Domain.Skill;

/// <summary>
/// Класс, представляющий скилл
/// </summary>
public interface ISkill
{
    /// <summary>
    /// Уникальный идентификатор скилла
    /// </summary>
    string Id { get; set; }
    
    /// <summary>
    /// Название скилла
    /// </summary>
    string Name { get; set; }
    
    /// <summary>
    /// Урон, наносимый скиллом
    /// </summary>
    float AttackStrength { get; set; }
    
    /// <summary>
    /// Кулдаун скилла (время перезарядки)
    /// </summary>
    int Cooldown { get; set; }
    
    /// <summary>
    /// Стоимость активации скилла
    /// </summary>
    float EnergyCost { get; set; }
}