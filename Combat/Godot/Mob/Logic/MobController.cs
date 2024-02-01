using System;
using System.Linq;
using Desert.Combat.Godot.Util;
using Desert.Combat.Infrastructure;
using Godot;

namespace Desert.Combat.Godot.Mob.Logic;

public partial class MobController : CharacterBody3D
{
    public Domain.Mob Entity { get; set; }
    private Util.SharedBattleSignal _sharedBattleSignal;
    private Util.BattleManager _battleManager;

    public override void _Ready()
    {
        _battleManager = (Util.BattleManager)GetTree().Root.GetChildren().Last().GetNode("BattleManager");
        Console.WriteLine("Создаем моба...");
        _sharedBattleSignal = GetNode<Util.SharedBattleSignal>("/root/SharedBattleSignal");
        Entity = TestingEntity.getTestingMobPrefab(_sharedBattleSignal);
        //_battleManager.RegEnemyMob(Entity);
    }

    public void Load()
    {
        using (GameContext context = new GameContext())
        {
			
        }
    }
}