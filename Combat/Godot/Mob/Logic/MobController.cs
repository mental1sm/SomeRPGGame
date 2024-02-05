using System;
using System.Linq;
using Desert.Combat.Domain.Entity;
using Desert.Combat.Godot.Util;
using Desert.Combat.Infrastructure;
using Desert.Combat.Repository;
using Godot;

namespace Desert.Combat.Godot.Mob.Logic;

/// <summary>
/// Компонент, отвечающий за характеристики и поведение моба
/// </summary>
public partial class MobController : CharacterBody3D
{
    private SharedBattleSignal _sharedBattleSignal;
    
    /// <summary>
    /// Все характеристики сущности будут импортированы по этому ID из БД
    /// </summary>
    [Export]
    public string EntityId { get; set; }
    public Entity Entity { get; set; }
    public EntityBehaviorController EntityBehaviorController { get; set; }

    private Timer _delayTimer;

    public override void _Ready()
    {
        Console.WriteLine("Создаем моба...");
        _sharedBattleSignal = GetNode<SharedBattleSignal>("/root/SharedBattleSignal");
        _sharedBattleSignal.NewTurnSignal += OnNewTurn;
        LoadEntity();
        BattleManager battleManager = (BattleManager)GetTree().Root.GetChildren().Last().GetNode("BattleManager");
        EntityBehaviorController = new EntityBehaviorController(battleManager, Entity);
        EntityBehaviorController.RegisterEntity();
        EntityBehaviorController.NotifyReady();
    }
    
    private void LoadEntity()
    {
        GameContext context = Infrastructure.DatabaseManager.GetInstance().GetContext();
        Entity = new EntityRepository(context).GetById(EntityId);
        Entity.EmitSignalStrategy = _sharedBattleSignal.EmitBattleSignal;
        Entity.GameId = 1;
    }

    private void OnNewTurn(int currentTurnEntityId)
    {
        if (currentTurnEntityId == Entity.GameId)
        {
            _delayTimer = new Timer();
            _delayTimer.WaitTime = 1.5F;
            _delayTimer.OneShot = true;
            _delayTimer.Connect("timeout", new Callable(this, "MakeTurn"));
            _delayTimer.Autostart = true;
            AddChild(_delayTimer);
        }
    }

    private void MakeTurn()
    {
        RemoveChild(_delayTimer);
        EntityBehaviorController.UseSkill(0, Entity.SkillSet.Skills.First());
    }
    
}