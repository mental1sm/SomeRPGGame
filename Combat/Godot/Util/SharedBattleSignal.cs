using System;
using Desert.Combat.Domain;
using Desert.Combat.Domain.Util;
using Godot;

namespace Desert.Combat.Godot.Util;

/// <summary>
/// Разделяемые всей сценой боевые сигналы
/// </summary>
public partial class SharedBattleSignal : Node
{
    private static SharedBattleSignal _instance;

    private SharedBattleSignal() {}

    public static SharedBattleSignal GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SharedBattleSignal();
        }

        return _instance;
    }
    
    [Signal]
    public delegate void EndTurnSignalEventHandler(int emitterId);

    [Signal]
    public delegate void TakeDamageSignalEventHandler(int emitterId);

    [Signal]
    public delegate void DrainedEnergySignalEventHandler(int emitterId);

    public void EmitBattleSignal(CombatSignal signalType, int emitterId)
    {
        switch (signalType)
        {
            case CombatSignal.EndTurn:
            {
                Console.WriteLine($"Emitting signal of turn end with id {emitterId}");
                EmitSignal(SignalName.EndTurnSignal, emitterId);
                break;
            }
            case CombatSignal.DrainedEnergy:
            {
                EmitSignal(SignalName.DrainedEnergySignal, emitterId);
                break;
            }
            case CombatSignal.TakenDamage:
            {
                EmitSignal(SignalName.TakeDamageSignal, emitterId);
                break;
            }
        }
    }
}