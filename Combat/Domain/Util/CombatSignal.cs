namespace Desert.Combat.Domain.Util;

/// <summary>
/// Предопределенные сигналы, предназначенные для функционирования боевой системы.
/// </summary>
public enum CombatSignal
{
    /// <summary>
    /// Сигнал о конце хода определенной сущности
    /// </summary>
    EndTurn,
    /// <summary>
    /// Сигнал о получении урона определенной сущность.
    /// </summary>
    TakenDamage,
    /// <summary>
    /// Сигнал о потраченной энергии от определенной сущности
    /// </summary>
    DrainedEnergy
}