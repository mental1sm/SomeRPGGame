using System;
using System.Collections.Generic;
using Desert.Combat.Domain.Entity;
using Desert.Combat.Domain.Skill;
using Desert.Combat.Domain.Util;
using Godot;

namespace Desert.Combat.Godot.Util;

/// <summary>
/// Компонент управляет боем на всей сцене
/// </summary>
public partial class BattleManager : Node
{
	private SharedBattleSignal _sharedBattleSignal;
	/// <summary>
	/// Стадия боя
	/// </summary>
	private GameStage _currentStage = GameStage.Initializing;
	private Timer _timer;
	
	/// <summary>
	/// Индекс сущности, которая сейчас ходит
	/// </summary>
	private int _currentTurnEntityIndex = 0;
	/// <summary>
	/// Объект сущности, которая сейчас ходит
	/// </summary>
	private Entity _currentTurnEntity;
	public Entity CurrentTurnEntity { get => _currentTurnEntity;}

	/// <summary>
	/// Полный список участвующих в бою сущностей
	/// </summary>
	private readonly List<Entity> _entities = new List<Entity>();
	public List<Entity> Entities => _entities;
	
	/// <summary>
	/// Карта готовности сущностей начать бой
	/// </summary>
	private readonly Dictionary<Entity, bool> _entitiesReadyMap = new Dictionary<Entity, bool>();
	
	/// <summary>
	/// Зарегистрировать сущность в менеджере
	/// </summary>
	/// <param name="entity">Объект сущности</param>
	public void RegisterEntity(Entity entity)
	{
		if (_currentStage == GameStage.Initializing)
		{
			Console.WriteLine($"Сущность {entity.Name} был зарегестрирован!");
			_entities.Add(entity);
			_entitiesReadyMap.Add(entity, true);
		}
	}

	/// <summary>
	/// Получить объект сущности по игровому ID
	/// </summary>
	/// <param name="gameId">Игровой ID</param>
	/// <returns>Объект сущности</returns>
	public Entity GetEntityById(int gameId)
	{
		Entity matchedEntity = _entities.FindLast(entity => entity.GameId == gameId);
		return matchedEntity ?? null;
	}

	/// <summary>
	/// Уведомить менеджер о готовности сущности начать бой
	/// </summary>
	/// <param name="entity">Объект сущности</param>
	public void NotifyReady(Entity entity)
	{
		Console.WriteLine($"Сущность {entity.Name} сообщает о готовности!");
		_entitiesReadyMap[entity] = true;
	}

	/// <summary>
	/// Вызывается, когда компонент прогружается на сцене
	/// </summary>
	public override void _Ready()
	{
		_sharedBattleSignal = GetNode<SharedBattleSignal>("/root/SharedBattleSignal");
		_timer = new Timer();
		_timer.WaitTime = 1.0F;
		_timer.Connect("timeout", new Callable(this, "OnTimerEnd"));
		_timer.Autostart = true;
		AddChild(_timer);
		Console.WriteLine("Менеджер боя инициализирован!");
	}

	/// <summary>
	/// Вызывается каждую секунду, пока все сущности не подтвердят свою готовность начать бой
	/// </summary>
	private void OnTimerEnd()
	{
		Console.WriteLine($"Ожидание игроков... Осталось {2 - _entities.Count}");
		if (_entities.Count >= 2)
		{
			bool membersReady = true;
			foreach (var pair in _entitiesReadyMap)
			{
				if (!pair.Value)
				{
					membersReady = false;
					break;
				}
			}

			if (membersReady)
			{
				_timer.Stop();
				_currentStage = GameStage.Active;
				StartGame();
			}
		}
	}

	/// <summary>
	/// Начать бой
	/// </summary>
	private void StartGame()
	{
		Console.WriteLine("Игра началась!");
		_currentTurnEntityIndex = 0;
		_currentTurnEntity = _entities[_currentTurnEntityIndex];
		NewTurn();
	}

	/// <summary>
	/// Закончить ход
	/// </summary>
	/// <param name="entity">Объект сущности, которая заканчивает ход</param>
	public void EndTurn(Entity entity)
	{
		Console.WriteLine($"Сущность {entity.Name} сообщает о завершении хода!");
		if (entity == _currentTurnEntity)
		{
			if (_currentTurnEntityIndex == _entities.Count - 1)
			{
				_currentTurnEntityIndex = 0;
			}
			else
			{
				_currentTurnEntityIndex += 1;
			}

			_currentTurnEntity = _entities[_currentTurnEntityIndex];
			NewTurn();
		}
	}

	/// <summary>
	/// Оповестить сущность, которая сейчас ходит, о том что пришло ее время ходить
	/// </summary>
	private void NewTurn()
	{
		Console.WriteLine($"Сущность {_currentTurnEntity.Name} уведомлен о его ходе!");
		_sharedBattleSignal.EmitBattleSignal(CombatSignal.NewTurn, _currentTurnEntity.GameId);
		_currentTurnEntity.OnNewTurn();
	}

	/// <summary>
	/// Использовать скилл
	/// </summary>
	/// <param name="self">Объект сущности (она должна быть ходящей на момент вызова)</param>
	/// <param name="targetGameId">ID цели, против которой будет применена атака</param>
	/// <param name="skill">Объект скилла</param>
	/// <returns></returns>
	public bool UseSkill(Entity self, int targetGameId, Skill skill)
	{
		Console.WriteLine($"Сущность {self.Name} пытается применить навык {skill.Name}!");
		if (self == _currentTurnEntity)
		{
			var target = GetEntityById(targetGameId);
			bool success = self.Attack(target, skill);
			if (success)
			{
				EndTurn(self);
			}
			return success;
		}

		return false;
	}
}
