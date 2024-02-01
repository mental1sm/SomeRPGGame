using Desert.Combat.Domain;
using Desert.Combat.Domain.Skill;

namespace Desert.Combat.Godot.Util;

public class TestingEntity
{
    public static Domain.Player getTestingPlayerPrefab(Util.SharedBattleSignal battleSignal)
    {
        Domain.Player player = new Domain.Player(id: "test", gameId: 0 ,name:"Player", emitSignalStrategy: battleSignal.EmitBattleSignal);
        Skill basicAttack = new Skill(id: "basic_attack", name: "Basic Attack", attackStrength: 10F, cooldown: 0, energyCost: 0);
        Skill slice = new Skill(id: "slice", name: "Slice", attackStrength: 30F, cooldown: 2, energyCost: 40);
        player.SkillSet.AddSkill(basicAttack);
        player.SkillSet.AddSkill(slice);
        return player;
    }

    public static Domain.Mob getTestingMobPrefab(Util.SharedBattleSignal battleSignal)
    {
        Domain.Mob mob = new Domain.Mob(id: "test_mob", gameId: 1, name:"Cylinder", maxHealth: 55, emitSignalStrategy: battleSignal.EmitBattleSignal);
        return mob;
    }
}