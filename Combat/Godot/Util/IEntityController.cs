using System.Collections.Generic;
using Desert.Combat.Domain.Entity;
using Desert.Combat.Domain.Skill;

namespace Desert.Combat.Godot.Util;

public interface IEntityController
{
    void RegisterSerializedEntity(Entity entity);
    Entity GetEntityCloneById(int entityId);
    List<Entity> GetAllEntities();
    List<Skill> GetEntitySkillsById(int entityId);
    bool UseSkill(Entity self, int targetId, Skill skill);
    void EndTurn(Entity self);
}