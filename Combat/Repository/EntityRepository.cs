using System;
using Desert.Combat.Domain.Entity;
using Desert.Combat.Infrastructure;

namespace Desert.Combat.Repository;

public class EntityRepository : AbstractRepository<Entity>
{
    public EntityRepository(GameContext context) : base(context)
    {
        Console.WriteLine("Repo loaded!");
    }

    public Entity GetById(string id)
    {
        Console.WriteLine("Searching entity...");
        Entity entity = Context.Entities.Find(id);
        if (entity == null)
        {
            Console.WriteLine("Entity not found!");
            return null;
        }
        Console.WriteLine("Entity was found! Loading skillset...");
        SkillSetRepository repository = new SkillSetRepository(Context);
        Console.WriteLine("Skillset was loaded!");
        entity.SkillSet = repository.GetById(entity.SkillSetId);
        return entity;
    }
}