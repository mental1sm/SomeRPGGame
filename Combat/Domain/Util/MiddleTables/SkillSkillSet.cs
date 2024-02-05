using Desert.Combat.Domain.Skillset;

namespace Desert.Combat.Domain.Util.MiddleTables;

/// <summary>
/// Промежуточная таблица между Сущностями и Скиллами для создания связи многие-ко-многим
/// </summary>
public class SkillSkillSet
{
    public int Id { get; set; }
    
    public SkillSet SkillSet { get; set; }
    public Skill.Skill Skill { get; set; }
}