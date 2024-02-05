using System.Collections.Generic;
using Desert.Combat.Domain.Entity;
using Desert.Combat.Domain.Skill;

namespace Desert.Combat.Godot.Util;

/// <summary>
/// Контроллер, отвечающий за взаимодействие Контроллера игрока или моба и Менеджера Боя.
/// Промежуточный интерфейсный слой.
/// </summary>
public interface IEntityBehaviorController
{
    BattleManager BattleManager { set; }
    
    /// <summary>
    /// Зарегистрировать сущность в Менеджере Боя
    /// </summary>
    void RegisterEntity();
    
    /// <summary>
    /// Получить копию экземпляра другой сущности по игровому ID
    /// </summary>
    /// <param name="entityGameId">Игровой ID цели</param>
    /// <returns>Копия экземпляра класса Entity</returns>
    Entity GetEntityCloneById(int entityGameId);
    
    /// <summary>
    /// Получить полный список сущностей, участвующих в бою
    /// </summary>
    /// <returns>Список сущностей</returns>
    List<Entity> GetAllEntities();
    
    /// <summary>
    /// Получить все скиллы сущности по ее игровому ID
    /// </summary>
    /// <param name="entityGameId"></param>
    /// <returns></returns>
    HashSet<Skill> GetEntitySkillsByGameId(int entityGameId);
    
    /// <summary>
    /// Использовать скилл
    /// </summary>
    /// <param name="targetGameId">Игровой ID цели</param>
    /// <param name="skill">Объект применяемого скилла</param>
    /// <returns>
    /// <para>
    /// true - Атака успешна (Опционально: проиграть анимацию и тд)
    /// </para>
    /// <para>
    /// false - Атака не удалась (По причине того, что сущность не ходит, или у нее не хватает энергии)
    /// </para>
    /// </returns>
    bool UseSkill(int targetGameId, Skill skill);
    
    /// <summary>
    /// Завершить ход
    /// </summary>
    void EndTurn();

    /// <summary>
    /// Уведомить Менеджер Боя о готовности сущности к началу боя
    /// </summary>
    void NotifyReady();
}