using System.Collections.Generic;
using Desert.Combat.Domain.Skill;

namespace Desert.Combat.Domain.Skillset;

/// <summary>
/// Класс, представляющий скиллсет для сущностей
/// </summary>
public interface ISkillSet
{
    /// <summary>
    /// ID скиллсета
    /// </summary>
    int Id { get; set; }
    
    /// <summary>
    /// ID родительской сущности
    /// </summary>
    int ParentGameId { get; set; }
    
    /// <summary>
    /// Набор изученных сущностью скиллов
    /// </summary>
    HashSet<Skill.Skill> Skills { get; set; }
    
    /// <summary>
    /// Метод для добавления нового скилла к скиллсету
    /// </summary>
    /// <param name="skill">Объект скилла</param>
    void AddSkill(Skill.Skill skill);
    
    /// <summary>
    /// Удаляет скилл из скиллсета, если он в нем существует
    /// </summary>
    /// <param name="id">ID скилла</param>
    void RemoveSkill(string id);

    /// <summary>
    /// Возвращает текущий статус скилла в данном скиллсете
    /// </summary>
    /// <param name="id">ID скилла</param>
    /// <returns>Текущий статус скилла</returns>
    SkillState GetSkillStatus(string id);

    /// <summary>
    /// Возвращает количество оставшихся ходов до перезарядки скилла
    /// </summary>
    /// <param name="id">ID скилла</param>
    /// <returns>Количество оставшихся ходов до перезарядки скилла</returns>
    int? GetSkillCooldown(string id);
    
    /// <summary>
    /// Хеш-таблица для хранения информации о скиллах, находящихся на перезарядке
    /// </summary>
    Dictionary<string, int> SkillsOnCooldown { get; set; }
    
    /// <summary>
    /// Использовать скилл (помещает скилл в список на перезарядку)
    /// </summary>
    /// <param name="id">ID скилла</param>
    /// <returns>
    /// <para>
    /// true => скилл использован успешно
    /// </para>
    /// <para>
    /// false => использование скилла провалено (отсутствует в скиллсете, либо находится не перезарядке)
    /// </para>
    /// </returns>
    bool UseSkill(string id);
    
    /// <summary>
    /// Вызывается каждый ход.
    /// Обновляет кулдаун скиллов, находящихся на перезарядке.
    /// </summary>
    void UpdateCooldowns();
}