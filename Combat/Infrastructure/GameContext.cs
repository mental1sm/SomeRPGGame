using Desert.Combat.Domain.Entity;
using Desert.Combat.Domain.Skill;
using Desert.Combat.Domain.Skillset;
using Desert.Domain.Util.MiddleTables;
using Microsoft.EntityFrameworkCore;

namespace Desert.Combat.Infrastructure;

public class GameContext : DbContext
{
	public DbSet<Skill> Skills { get; set; }
	public DbSet<SkillSet> SkillSets { get; set; }
	public DbSet<Entity> Entities { get; set; }
	public DbSet<SkillSkillSet> SkillSkillSets { get; set; }

	public GameContext()
	{
		Database.EnsureCreated();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source=game.db");
		optionsBuilder.EnableDetailedErrors();
	}
	
}
