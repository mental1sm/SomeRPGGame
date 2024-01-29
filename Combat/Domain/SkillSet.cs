using System;
using System.Collections.Generic;
using System.Linq;

namespace Desert.Combat.Domain;

/// <inheritdoc/>
public class SkillSet : ISkillSet
{
	/// <summary>
	/// Конструктор для импорта данных из Базы Данных.
	/// Обязательно требуется затем переконструировать объект при помощи другого конструктора с указанием ID родителя.
	/// </summary>
	public SkillSet()
	{
		ParentId = -9999;
	}
	
	/// <summary>
	/// Конструктор для создания пустого скиллсета
	/// </summary>
	/// <param name="parentId">ID родительской сущности</param>
	/// <param name="emitSignalStrategy">Стратегия излучения сигналов</param>
	public SkillSet(int parentId, EmitSignalStrategyDefinitionProvider.EmitSignalStrategy emitSignalStrategy = null)
	{
		ParentId = parentId;
		_emitStrategy = emitSignalStrategy;
	}

	/// <summary>
	/// Конструктор для иъекции загруженного из Базы Данных скиллсета в сущность персонажа.
	/// </summary>
	/// <param name="parentId"></param>
	/// <param name="skillSet"></param>
	/// <param name="emitSignalStrategy"></param>
	public SkillSet(int parentId, SkillSet skillSet, EmitSignalStrategyDefinitionProvider.EmitSignalStrategy emitSignalStrategy = null)
	{
		ParentId = parentId;
		Skills = skillSet.Skills;
		_emitStrategy = emitSignalStrategy;
	}

	/// <inheritdoc/>
	public int ParentId { get; }

	/// <inheritdoc/>
	public HashSet<ISkill> Skills { get; } = new HashSet<ISkill>();

	/// <inheritdoc/>
	public void AddSkill(ISkill skill)
	{
		this.Skills.Add(skill);
	}

	/// <inheritdoc/>
	public void RemoveSkill(string id)
	{
		this.Skills.RemoveWhere(skill => skill.Id == id);
	}

	/// <summary>
	/// Вспомогательный метод для поиска объекта скилла в скиллсете
	/// </summary>
	/// <param name="id">ID искомого скилла</param>
	/// <returns>Объект скилла</returns>
	private ISkill FindSkill(string id)
	{
		try
		{
			return Skills.FirstOrDefault(skill => skill.Id == id);
		}
		catch (ArgumentNullException e)
		{
			return null;
		}
	}

	/// <inheritdoc/>
	public int? GetSkillCooldown(string id)
	{
		try
		{
			return SkillsOnCooldown.FirstOrDefault(pair => pair.Key == id).Value;
		}
		catch (ArgumentNullException e)
		{
			return null;
		}
	}

	/// <inheritdoc/>
	public SkillState GetSkillStatus(string id)
	{
		ISkill skill = FindSkill(id);
		
		if (skill == null)
		{
			return SkillState.NotLearned;
		}

		float? skillCooldown = GetSkillCooldown(id);
		if (skillCooldown == null)
		{
			return SkillState.Available;
		}
		return SkillState.OnReload;
	}

	/// <inheritdoc/>
	public Dictionary<string, int> SkillsOnCooldown { get; } = new Dictionary<string, int>();

	/// <inheritdoc/>
	public bool UseSkill(string id)
	{
		SkillState status = GetSkillStatus(id);
		if (status != SkillState.Available) return false;
		
		ISkill usingSkill = FindSkill(id);
		if (usingSkill.Cooldown != 0)
		{
			this.SkillsOnCooldown.Add(usingSkill.Id, usingSkill.Cooldown);
		}

		return true;
	}
	
	/// <inheritdoc/>
	public void UpdateCooldowns()
	{
		Dictionary<string, int> skillsOnCooldownClone = new Dictionary<string, int>(SkillsOnCooldown);
		
		foreach (KeyValuePair<string, int> pair in skillsOnCooldownClone)
		{
			if (pair.Value - Constants.CooldownOnTurn <= 0)
			{
				SkillsOnCooldown.Remove(pair.Key);
				// emitting signal "cooldown_finished"
			}
			else
			{
				SkillsOnCooldown[pair.Key] = pair.Value - Constants.CooldownOnTurn;
				// emitting signal "cooldown_progress"
			}
		}
	}
	
	
	private EmitSignalStrategyDefinitionProvider.EmitSignalStrategy _emitStrategy;

	/// <summary>
	/// Излучает сигнал, используя стратегию излучения.
	/// </summary>
	/// <param name="signalType">Тип сигнала (CombatSignals.cs)</param>
	private void EmitSignal(CombatSignal signalType)
	{
		_emitStrategy?.Invoke(signalType: signalType, this.ParentId);
	}
}
