using System;
using Desert.Combat.Domain;
using Godot;

namespace Desert.Combat.Godot;

public partial class SharedBattleSignal : Node
{
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