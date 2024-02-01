using Desert.Combat.Domain.Skill;
using Desert.Combat.Domain.Skillset;

namespace Desert.Domain.Util.MiddleTables;

public class SkillSkillSet
{
    public int Id { get; set; }
    
    public SkillSet SkillSet { get; set; }
    public Skill Skill { get; set; }
}