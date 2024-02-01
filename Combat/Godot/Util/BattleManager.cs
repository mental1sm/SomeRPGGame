using System.Collections.Generic;
using Desert.Combat.Domain;
using Desert.Combat.Domain.Entity;
using Godot;
using Newtonsoft.Json;

namespace Desert.Combat.Godot.Util;

public partial class BattleManager : Node
{
	private GameStage _currentStage = GameStage.Initializing;

	private readonly List<Entity> _entities = new List<Entity>();

	public string Entities => JsonConvert.SerializeObject(_entities);
	
	public void RegisterSerializedEntity(string entity)
	{
		if (_currentStage == GameStage.Initializing)
		{
			_entities.Add(JsonConvert.DeserializeObject<Entity>(entity));
		}
	}

	public string GetSerializedEntityById(int gameId)
	{
		Entity matchedEntity = _entities.FindLast(entity => entity.GameId == gameId);
		if (matchedEntity == null)
		{
			return "NONE";
		}

		return JsonConvert.SerializeObject(matchedEntity);
	}
	
	
}
