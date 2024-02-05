using Desert.Combat.Domain.Entity;
using Desert.Combat.Domain.Skill;
using Desert.Combat.Domain.Skillset;
using Desert.Combat.Domain.Util.MiddleTables;
using Microsoft.EntityFrameworkCore;

namespace Desert.Combat.Infrastructure;

public sealed class GameContext : DbContext
{
	/// <summary>
	/// Таблица Скиллов
	/// </summary>
	public DbSet<Skill> Skills { get; set; }
	
	/// <summary>
	/// Таблица Скиллсетов
	/// </summary>
	public DbSet<SkillSet> SkillSets { get; set; }
	
	/// <summary>
	/// Таблица сущностей
	/// </summary>
	public DbSet<Entity> Entities { get; set; }
	
	/// <summary>
	/// Промежуточная таблица для создания связи многие-ко-многим между Скиллсетами и Скиллами
	/// </summary>
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
