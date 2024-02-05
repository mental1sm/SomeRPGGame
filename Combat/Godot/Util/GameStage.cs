namespace Desert.Combat.Godot.Util;

/// <summary>
/// Стадии боя
/// </summary>
public enum GameStage
{
    /// <summary>
    /// Инициализация (Ожидание готовности участников)
    /// </summary>
    Initializing,
    /// <summary>
    /// Непосредственно сцена боя
    /// </summary>
    Active,
    /// <summary>
    /// Завершение боя
    /// </summary>
    Ended
}