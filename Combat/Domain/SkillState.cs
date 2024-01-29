namespace Desert.Combat.Domain;

/// <summary>
/// Перечисление состояний, в которых может находится навык.
/// </summary>
public enum SkillState
{
    /// <summary>
    /// На перезарядке
    /// </summary>
    OnReload,
    
    /// <summary>
    /// Не изучено (нет в скиллсете)
    /// </summary>
    NotLearned,
    
    /// <summary>
    /// Доступно для использования
    /// </summary>
    Available
}