using System.Collections.Generic;
using System.Linq;
using Desert.Combat.Domain.Skill;
using Desert.Combat.Domain.Skillset;
using Desert.Combat.Domain.Util.MiddleTables;
using Desert.Combat.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Desert.Combat.Repository;

public class SkillSkillSetRepository : AbstractRepository<SkillSkillSet>
{
    public SkillSkillSetRepository(GameContext context) : base(context)
    {
    }

    public void AddSkillPermanent(Skill skill, SkillSet skillSet)
    {
        SkillSkillSet relation = Context.SkillSkillSets.First(rel => rel.SkillSet.Id == skillSet.Id || rel.Skill.Id == skill.Id);
        if (relation == null)
        {
            SkillSkillSet newRelation = new SkillSkillSet();
            newRelation.Skill = skill;
            newRelation.SkillSet = skillSet;
            Context.SkillSkillSets.Add(newRelation);
        }
    }

    public void RemoveSkillPermanent(Skill skill, SkillSet skillSet)
    {
        SkillSkillSet relation = Context.SkillSkillSets.First(rel => rel.SkillSet.Id == skillSet.Id || rel.Skill.Id == skill.Id);
        if (relation != null)
        {
            Context.SkillSkillSets.Remove(relation);
        }
    }
}