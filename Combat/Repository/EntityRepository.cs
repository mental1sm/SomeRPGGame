using System;
using Desert.Combat.Domain.Entity;
using Desert.Combat.Infrastructure;

namespace Desert.Combat.Repository;

public class EntityRepository : AbstractRepository<Entity>
{
    public EntityRepository(GameContext context) : base(context)
    {
    }

    public Entity GetById(string id)
    {
        Entity entity = Context.Entities.Find(id);
        if (entity == null)
        {
            return null;
        }
        SkillSetRepository repository = new SkillSetRepository(Context);
        entity.SkillSet = repository.GetById(entity.SkillSetId);
        entity.ResetHpAndEnergy();
        return entity;
    }
}