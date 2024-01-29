using System.Collections.Generic;

namespace Desert.Combat.Domain;

/// <summary>
/// Класс, представляющий собой энтити
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Уникальный идентификатор сущности
    /// </summary>
    int Id { get; }
    
    /// <summary>
    /// Имя сущности
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// Текущее HP
    /// </summary>
    float CurrentHealth { get; }
    
    /// <summary>
    /// Максимальное HP
    /// </summary>
    float MaxHealth { get; }
    
    /// <summary>
    /// Текущая энергия
    /// </summary>
    float CurrentEnergy { get; }
    
    /// <summary>
    /// Максимальная энергия
    /// </summary>
    float MaxEnergy { get; }
    
    /// <summary>
    /// Скорость регенерации энергии (в ход)
    /// </summary>
    float EnergyRegenSpeed { get; }

    /// <summary>
    /// Скиллсет сущности
    /// </summary>
    ISkillSet SkillSet { get; }
    
    /// <summary>
    /// Получить урон от другой сущности
    /// </summary>
    /// <param name="source">Источник (другая сущность)</param>
    /// <param name="skill">Скилл, с помощью которого атакует другая сущность</param>
    
    void TakeDamage(IEntity source, ISkill skill);
    
    /// <summary>
    /// Совершить атаку против другой сущности
    /// </summary>
    /// <param name="target">Цель атаки</param>
    /// <param name="skill">Скилл</param>
    void Attack(IEntity target, ISkill skill);
    
    /// <summary>
    /// Метод, испускающий сигнал, сообщающий менеджеру сражения о готовности окончить свой ход
    /// </summary>
    void EndTurn();
    
    /// <summary>
    /// Метод, активирующийся, когда сущность начинает новый ход
    /// </summary>
    void OnNewTurn();
}