using System;
using System.Linq;
using Desert.Combat.Domain.Skill;
using Desert.Combat.Domain.Skillset;
using Desert.Combat.Infrastructure;

namespace Desert.Combat.Repository;

public class SkillSetRepository : AbstractRepository<SkillSet>
{
    public SkillSetRepository(GameContext context) : base(context)
    {
    }

    public SkillSet GetById(int id)
    {
        Console.WriteLine("Loading skillset...");
        SkillSet skillSet = Context.SkillSets.Find(id);
        if (skillSet == null)
        {
            Console.WriteLine("Skillset not found!");
            return null;
        }
        Console.WriteLine("Skillset was found! Loading skills...");
        IQueryable<Skill> skills = from skill in Context.Skills
            join s in Context.SkillSkillSets on skill.Id equals s.Skill.Id
            where s.SkillSet.Id == skillSet.Id select skill;
        Console.WriteLine("Skills loaded!");
        foreach (var skill in skills)
        {
            skillSet.AddSkill(skill: skill);
        }

        return skillSet;
    }
}