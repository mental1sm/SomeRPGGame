namespace Desert.Combat.Domain;

/// <summary>
/// <para>
/// Предоставляет определения стратегии излучения сигналов.
/// </para>
///
/// <para>
/// Так как излучать сигнал способны только компоненты Godot Engine,
/// необходимо поместить этот метод в делегат и сделать инъекцию делегата
/// как стратегии во все дочерние классы, чтобы дать им возможность использовать
/// сигналы Godot и в то же время не быть связанными с его классами. 
/// </para>
/// </summary>
public static class EmitSignalStrategyDefinitionProvider
{
    public delegate void EmitSignalStrategy(CombatSignal signalType, int selfId);
}