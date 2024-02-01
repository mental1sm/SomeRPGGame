using Desert.Combat.Domain.Skill;
using Desert.Combat.Infrastructure;

namespace Desert.Combat.Repository;

public class SkillRepository : AbstractRepository<Skill>
{
    public SkillRepository(GameContext context) : base(context)
    {
    }
}