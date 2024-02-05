namespace Desert.Combat.Domain.Entity;

public interface IEntityActions
{
    /// <summary>
    /// Получить урон от другой сущности
    /// </summary>
    /// <param name="source">Источник (другая сущность)</param>
    /// <param name="skill">Скилл, с помощью которого атакует другая сущность</param>
    
    void TakeDamage(Entity source, Skill.Skill skill);

    /// <summary>
    /// Совершить атаку против другой сущности
    /// </summary>
    /// <param name="target">Цель атаки</param>
    /// <param name="skill">Скилл</param>
    bool Attack(Entity target, Skill.Skill skill);
    
    /// <summary>
    /// Метод, испускающий сигнал, сообщающий менеджеру сражения о готовности окончить свой ход
    /// </summary>
    void EndTurn();
    
    /// <summary>
    /// Метод, активирующийся, когда сущность начинает новый ход
    /// </summary>
    void OnNewTurn();
}