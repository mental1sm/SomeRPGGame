using System;
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

    [Signal]
    public delegate void NewTurnSignalEventHandler(int currentTurnEntityId);

    public void EmitBattleSignal(CombatSignal signalType, int arg)
    {
        switch (signalType)
        {
            case CombatSignal.EndTurn:
            {
                Console.WriteLine($"Emitting signal of turn end with id {arg}");
                EmitSignal(SignalName.EndTurnSignal, arg);
                break;
            }
            case CombatSignal.DrainedEnergy:
            {
                EmitSignal(SignalName.DrainedEnergySignal, arg);
                break;
            }
            case CombatSignal.TakenDamage:
            {
                EmitSignal(SignalName.TakeDamageSignal, arg);
                break;
            }

            case CombatSignal.NewTurn:
            {
                EmitSignal(SignalName.NewTurnSignal, arg);
                break;
            }
           
        }
    }
    
}