using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public GameObject cityPrefab;
    public GridGenerator gridGenerator;
    public int numberOfCitiesToGenerate = 1;
    public CityManager cityManager;
    public string cityLayerName = "City";
    public float minimumDistanceBetweenCities = 2f; // Минимальное расстояние между городами
	public CityNameList cityNameList;
	public ForestGenerator forestGenerator;
	public EndTurnConfirmation endTurnConfirmation;
	public PlayerControllers playerControllers;
	public Pathfinder pathfinder;
	public WearAI wearAI;
	public ItemsList itemsList;
	public IDCounter iDCounter;
	public MarkTilesInRadius markTilesInRadius;
	public BorderLineManager borderLineManager;

    public void GenerateCities(int cityNumber)
    {
		numberOfCitiesToGenerate = cityNumber;
        List<Vector2> generatedPositions = new List<Vector2>(); // Список для отслеживания уже сгенерированных позиций

        for (int i = 0; i < numberOfCitiesToGenerate; i++)
        {
            Vector2 spawnPosition = GetValidSpawnPosition(generatedPositions);
			GameObject newCity = new GameObject("City");
			newCity.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, 0f);
			SpriteRenderer citySpriteRenderer = newCity.AddComponent<SpriteRenderer>();
			string spritePath = "Sprites/Terrain/City";
			Sprite citySprite = Resources.Load<Sprite>(spritePath);
			citySpriteRenderer.sprite = citySprite;
			citySpriteRenderer.sortingLayerName = "City Layer";
			BoxCollider2D collider = newCity.AddComponent<BoxCollider2D>();

            SetLayerAndSortingLayer(newCity, cityLayerName);

            SmallCity smallCity = newCity.AddComponent<SmallCity>();
            smallCity.cityID = i + 1;
			
			if (i == 0)
			{
				smallCity.ownerPlayerID = 1;
				Camera.main.transform.position = new Vector3(smallCity.transform.position.x, smallCity.transform.position.y, -10);
			}
			else if (i == 1)
			{
				smallCity.ownerPlayerID = 2;
			}
			else if (i == 2)
			{
				smallCity.ownerPlayerID = 3;
			}
			else if (i == 3)
			{
				smallCity.ownerPlayerID = 4;
			}
			
			smallCity.PopulationAge0M = Random.Range(12, 17);
			smallCity.PopulationAge0W = Random.Range(12, 17);
			smallCity.PopulationAge1M = Random.Range(12, 17);
			smallCity.PopulationAge1W = Random.Range(12, 17);
			smallCity.PopulationAge2M = Random.Range(12, 17);
			smallCity.PopulationAge2W = Random.Range(12, 17);
			smallCity.PopulationAge3M = Random.Range(12, 17);
			smallCity.PopulationAge3W = Random.Range(12, 17);
			smallCity.PopulationAge4M = Random.Range(12, 17);
			smallCity.PopulationAge4W = Random.Range(12, 17);
			smallCity.PopulationAge5M = Random.Range(12, 17);
			smallCity.PopulationAge5W = Random.Range(12, 17);
			smallCity.PopulationAge6M = Random.Range(12, 17);
			smallCity.PopulationAge6W = Random.Range(12, 17);
			smallCity.PopulationAge7M = Random.Range(12, 17);
			smallCity.PopulationAge7W = Random.Range(12, 17);
			smallCity.PopulationAge8M = Random.Range(12, 17);
			smallCity.PopulationAge8W = Random.Range(12, 17);
			smallCity.PopulationAge9M = Random.Range(12, 17);
			smallCity.PopulationAge9W = Random.Range(12, 17);
			smallCity.PopulationAge10M = Random.Range(12, 17);
			smallCity.PopulationAge10W = Random.Range(12, 17);
			smallCity.PopulationAge11M = Random.Range(12, 17);
			smallCity.PopulationAge11W = Random.Range(12, 17);
			smallCity.PopulationAge12M = Random.Range(12, 17);
			smallCity.PopulationAge12W = Random.Range(12, 17);
			smallCity.PopulationAge13M = Random.Range(12, 17);
			smallCity.PopulationAge13W = Random.Range(12, 17);
			smallCity.PopulationAge14M = Random.Range(12, 17);
			smallCity.PopulationAge14W = Random.Range(12, 17);
			smallCity.PopulationAge15M = Random.Range(12, 17);
			smallCity.PopulationAge15W = Random.Range(12, 17);
			smallCity.PopulationAge16M = Random.Range(12, 17);
			smallCity.PopulationAge16W = Random.Range(12, 17);
			smallCity.PopulationAge17M = Random.Range(12, 17);
			smallCity.PopulationAge17W = Random.Range(12, 17);
			smallCity.PopulationAge18M = Random.Range(12, 17);
			smallCity.PopulationAge18W = Random.Range(12, 17);
			smallCity.PopulationAge19M = Random.Range(12, 17);
			smallCity.PopulationAge19W = Random.Range(12, 17);
			smallCity.PopulationAge20M = Random.Range(12, 17);
			smallCity.PopulationAge20W = Random.Range(12, 17);
			smallCity.PopulationAge21M = Random.Range(12, 17);
			smallCity.PopulationAge21W = Random.Range(12, 17);
			smallCity.PopulationAge22M = Random.Range(12, 17);
			smallCity.PopulationAge22W = Random.Range(12, 17);
			smallCity.PopulationAge23M = Random.Range(12, 17);
			smallCity.PopulationAge23W = Random.Range(12, 17);
			smallCity.PopulationAge24M = Random.Range(12, 17);
			smallCity.PopulationAge24W = Random.Range(12, 17);
			smallCity.PopulationAge25M = Random.Range(12, 17);
			smallCity.PopulationAge25W = Random.Range(12, 17);
			smallCity.PopulationAge26M = Random.Range(12, 17);
			smallCity.PopulationAge26W = Random.Range(12, 17);
			smallCity.PopulationAge27M = Random.Range(12, 17);
			smallCity.PopulationAge27W = Random.Range(12, 17);
			smallCity.PopulationAge28M = Random.Range(12, 17);
			smallCity.PopulationAge28W = Random.Range(12, 17);
			smallCity.PopulationAge29M = Random.Range(12, 17);
			smallCity.PopulationAge29W = Random.Range(12, 17);
			smallCity.PopulationAge30M = Random.Range(12, 17);
			smallCity.PopulationAge30W = Random.Range(12, 17);
			smallCity.PopulationAge31M = Random.Range(12, 17);
			smallCity.PopulationAge31W = Random.Range(12, 17);
			smallCity.PopulationAge32M = Random.Range(12, 17);
			smallCity.PopulationAge32W = Random.Range(12, 17);
			smallCity.PopulationAge33M = Random.Range(12, 17);
			smallCity.PopulationAge33W = Random.Range(12, 17);
			smallCity.PopulationAge34M = Random.Range(12, 17);
			smallCity.PopulationAge34W = Random.Range(12, 17);
			smallCity.PopulationAge35M = Random.Range(12, 17);
			smallCity.PopulationAge35W = Random.Range(12, 17);
			smallCity.PopulationAge36M = Random.Range(12, 17);
			smallCity.PopulationAge36W = Random.Range(12, 17);
			smallCity.PopulationAge37M = Random.Range(12, 17);
			smallCity.PopulationAge37W = Random.Range(12, 17);
			smallCity.PopulationAge38M = Random.Range(12, 17);
			smallCity.PopulationAge38W = Random.Range(12, 17);
			smallCity.PopulationAge39M = Random.Range(12, 17);
			smallCity.PopulationAge39W = Random.Range(12, 17);
			smallCity.PopulationAge40M = Random.Range(12, 17);
			smallCity.PopulationAge40W = Random.Range(12, 17);
			smallCity.PopulationAge41M = Random.Range(12, 17);
			smallCity.PopulationAge41W = Random.Range(12, 17);
			smallCity.PopulationAge42M = Random.Range(12, 17);
			smallCity.PopulationAge42W = Random.Range(12, 17);
			smallCity.PopulationAge43M = Random.Range(12, 17);
			smallCity.PopulationAge43W = Random.Range(12, 17);
			smallCity.PopulationAge44M = Random.Range(12, 17);
			smallCity.PopulationAge44W = Random.Range(12, 17);
			smallCity.PopulationAge45M = Random.Range(12, 17);
			smallCity.PopulationAge45W = Random.Range(12, 17);
			smallCity.PopulationAge46M = Random.Range(12, 17);
			smallCity.PopulationAge46W = Random.Range(12, 17);
			smallCity.PopulationAge47M = Random.Range(12, 17);
			smallCity.PopulationAge47W = Random.Range(12, 17);
			smallCity.PopulationAge48M = Random.Range(12, 17);
			smallCity.PopulationAge48W = Random.Range(12, 17);
			smallCity.PopulationAge49M = Random.Range(12, 17);
			smallCity.PopulationAge49W = Random.Range(12, 17);
			smallCity.PopulationAge50M = Random.Range(12, 17);
			smallCity.PopulationAge50W = Random.Range(12, 17);
			smallCity.PopulationAge51M = Random.Range(12, 17);
			smallCity.PopulationAge51W = Random.Range(12, 17);
			smallCity.PopulationAge52M = Random.Range(12, 17);
			smallCity.PopulationAge52W = Random.Range(12, 17);
			smallCity.PopulationAge53M = Random.Range(12, 17);
			smallCity.PopulationAge53W = Random.Range(12, 17);
			smallCity.PopulationAge54M = Random.Range(12, 17);
			smallCity.PopulationAge54W = Random.Range(12, 17);
			smallCity.PopulationAge55M = Random.Range(12, 17);
			smallCity.PopulationAge55W = Random.Range(12, 17);
			smallCity.PopulationAge56M = Random.Range(12, 17);
			smallCity.PopulationAge56W = Random.Range(12, 17);
			smallCity.PopulationAge57M = Random.Range(12, 17);
			smallCity.PopulationAge57W = Random.Range(12, 17);
			smallCity.PopulationAge58M = Random.Range(12, 17);
			smallCity.PopulationAge58W = Random.Range(12, 17);
			smallCity.PopulationAge59M = Random.Range(12, 17);
			smallCity.PopulationAge59W = Random.Range(12, 17);
			smallCity.PopulationAge60M = Random.Range(12, 17);
			smallCity.PopulationAge60W = Random.Range(12, 17);
			smallCity.PopulationAge61M = Random.Range(12, 17);
			smallCity.PopulationAge61W = Random.Range(12, 17);
			smallCity.PopulationAge62M = Random.Range(12, 17);
			smallCity.PopulationAge62W = Random.Range(12, 17);
			smallCity.PopulationAge63M = Random.Range(12, 17);
			smallCity.PopulationAge63W = Random.Range(12, 17);
			smallCity.PopulationAge64M = Random.Range(12, 17);
			smallCity.PopulationAge64W = Random.Range(12, 17);
			smallCity.PopulationAge65M = Random.Range(12, 17);
			smallCity.PopulationAge65W = Random.Range(12, 17);
			smallCity.PopulationAge66M = Random.Range(12, 17);
			smallCity.PopulationAge66W = Random.Range(12, 17);
			smallCity.PopulationAge67M = Random.Range(12, 17);
			smallCity.PopulationAge67W = Random.Range(12, 17);
			smallCity.PopulationAge68M = Random.Range(12, 17);
			smallCity.PopulationAge68W = Random.Range(12, 17);
			smallCity.PopulationAge69M = Random.Range(12, 17);
			smallCity.PopulationAge69W = Random.Range(12, 17);
			smallCity.PopulationAge70M = Random.Range(12, 17);
			smallCity.PopulationAge70W = Random.Range(12, 17);
			
			smallCity.Population = smallCity.PopulationAge0M + smallCity.PopulationAge0W + smallCity.PopulationAge1M + smallCity.PopulationAge1W + smallCity.PopulationAge2M + smallCity.PopulationAge2W +
                      smallCity.PopulationAge3M + smallCity.PopulationAge3W +
                      smallCity.PopulationAge4M + smallCity.PopulationAge4W +
                      smallCity.PopulationAge5M + smallCity.PopulationAge5W +
                      smallCity.PopulationAge6M + smallCity.PopulationAge6W +
                      smallCity.PopulationAge7M + smallCity.PopulationAge7W +
                      smallCity.PopulationAge8M + smallCity.PopulationAge8W +
                      smallCity.PopulationAge9M + smallCity.PopulationAge9W +
                      smallCity.PopulationAge10M + smallCity.PopulationAge10W +
                      smallCity.PopulationAge11M + smallCity.PopulationAge11W +
                      smallCity.PopulationAge12M + smallCity.PopulationAge12W +
                      smallCity.PopulationAge13M + smallCity.PopulationAge13W +
                      smallCity.PopulationAge14M + smallCity.PopulationAge14W +
                      smallCity.PopulationAge15M + smallCity.PopulationAge15W +
                      smallCity.PopulationAge16M + smallCity.PopulationAge16W +
                      smallCity.PopulationAge17M + smallCity.PopulationAge17W +
                      smallCity.PopulationAge18M + smallCity.PopulationAge18W +
                      smallCity.PopulationAge19M + smallCity.PopulationAge19W +
                      smallCity.PopulationAge20M + smallCity.PopulationAge20W +
                      smallCity.PopulationAge21M + smallCity.PopulationAge21W +
                      smallCity.PopulationAge22M + smallCity.PopulationAge22W +
                      smallCity.PopulationAge23M + smallCity.PopulationAge23W +
                      smallCity.PopulationAge24M + smallCity.PopulationAge24W +
                      smallCity.PopulationAge25M + smallCity.PopulationAge25W +
                      smallCity.PopulationAge26M + smallCity.PopulationAge26W +
                      smallCity.PopulationAge27M + smallCity.PopulationAge27W +
                      smallCity.PopulationAge28M + smallCity.PopulationAge28W +
                      smallCity.PopulationAge29M + smallCity.PopulationAge29W +
                      smallCity.PopulationAge30M + smallCity.PopulationAge30W +
                      smallCity.PopulationAge31M + smallCity.PopulationAge31W +
                      smallCity.PopulationAge32M + smallCity.PopulationAge32W +
                      smallCity.PopulationAge33M + smallCity.PopulationAge33W +
                      smallCity.PopulationAge34M + smallCity.PopulationAge34W +
                      smallCity.PopulationAge35M + smallCity.PopulationAge35W +
                      smallCity.PopulationAge36M + smallCity.PopulationAge36W +
                      smallCity.PopulationAge37M + smallCity.PopulationAge37W +
                      smallCity.PopulationAge38M + smallCity.PopulationAge38W +
                      smallCity.PopulationAge39M + smallCity.PopulationAge39W +
                      smallCity.PopulationAge40M + smallCity.PopulationAge40W +
                      smallCity.PopulationAge41M + smallCity.PopulationAge41W +
                      smallCity.PopulationAge42M + smallCity.PopulationAge42W +
                      smallCity.PopulationAge43M + smallCity.PopulationAge43W +
                      smallCity.PopulationAge44M + smallCity.PopulationAge44W +
                      smallCity.PopulationAge45M + smallCity.PopulationAge45W +
                      smallCity.PopulationAge46M + smallCity.PopulationAge46W +
                      smallCity.PopulationAge47M + smallCity.PopulationAge47W +
                      smallCity.PopulationAge48M + smallCity.PopulationAge48W +
                      smallCity.PopulationAge49M + smallCity.PopulationAge49W +
                      smallCity.PopulationAge50M + smallCity.PopulationAge50W +
                      smallCity.PopulationAge51M + smallCity.PopulationAge51W +
                      smallCity.PopulationAge52M + smallCity.PopulationAge52W +
                      smallCity.PopulationAge53M + smallCity.PopulationAge53W +
                      smallCity.PopulationAge54M + smallCity.PopulationAge54W +
                      smallCity.PopulationAge55M + smallCity.PopulationAge55W +
                      smallCity.PopulationAge56M + smallCity.PopulationAge56W +
                      smallCity.PopulationAge57M + smallCity.PopulationAge57W +
                      smallCity.PopulationAge58M + smallCity.PopulationAge58W +
                      smallCity.PopulationAge59M + smallCity.PopulationAge59W +
                      smallCity.PopulationAge60M + smallCity.PopulationAge60W +
                      smallCity.PopulationAge61M + smallCity.PopulationAge61W +
                      smallCity.PopulationAge62M + smallCity.PopulationAge62W +
                      smallCity.PopulationAge63M + smallCity.PopulationAge63W +
                      smallCity.PopulationAge64M + smallCity.PopulationAge64W +
                      smallCity.PopulationAge65M + smallCity.PopulationAge65W +
                      smallCity.PopulationAge66M + smallCity.PopulationAge66W +
                      smallCity.PopulationAge67M + smallCity.PopulationAge67W +
                      smallCity.PopulationAge68M + smallCity.PopulationAge68W +
                      smallCity.PopulationAge69M + smallCity.PopulationAge69W +
                      smallCity.PopulationAge70M + smallCity.PopulationAge70W;
					  
					  smallCity.PopulationWorkable = smallCity.PopulationAge18M +
						smallCity.PopulationAge19M +
						smallCity.PopulationAge20M +
						smallCity.PopulationAge21M +
						smallCity.PopulationAge22M +
						smallCity.PopulationAge23M +
						smallCity.PopulationAge24M +
						smallCity.PopulationAge25M +
						smallCity.PopulationAge26M +
						smallCity.PopulationAge27M +
						smallCity.PopulationAge28M +
						smallCity.PopulationAge29M +
						smallCity.PopulationAge30M +
						smallCity.PopulationAge31M +
						smallCity.PopulationAge32M +
						smallCity.PopulationAge33M +
						smallCity.PopulationAge34M +
						smallCity.PopulationAge35M +
						smallCity.PopulationAge36M +
						smallCity.PopulationAge37M +
						smallCity.PopulationAge38M +
						smallCity.PopulationAge39M +
						smallCity.PopulationAge40M +
						smallCity.PopulationAge41M +
						smallCity.PopulationAge42M +
						smallCity.PopulationAge43M +
						smallCity.PopulationAge44M +
						smallCity.PopulationAge45M;
			
			CellData currentCell = gridGenerator.GetCellFromWorldPosition(spawnPosition);
			currentCell.terrainType = TerrainType.City;
			currentCell.IsOccupiedByCity = true;
			currentCell.coverChance = 30f;
			smallCity.spritePath = spritePath;
			smallCity.currentCell = currentCell;
			smallCity.currentNode = currentCell.node;
			smallCity.ThisCity = newCity;
			smallCity.currentCell.smallCity = smallCity;
			smallCity.GlobalID = iDCounter.globalID;
			iDCounter.globalID++;
			currentCell.smallCityGlobalID = smallCity.GlobalID;
			newCity.name = "SmallCity (Cell: " + currentCell.GetCellName() + ")";
			BoxCollider2D cellCollider = currentCell.GetComponent<BoxCollider2D>();
			cellCollider.enabled = false;
			
			// Создаем список для хранения использованных имен
			List<string> usedNames = new List<string>();
			
			// Выбираем уникальное имя для города
            string cityName = GetUniqueCityName(usedNames);
            smallCity.cityName = cityName;
            usedNames.Add(cityName);
			
			SelectedCityInfo selectedCityInfo = newCity.AddComponent<SelectedCityInfo>();
			CityHoverInfo cityHoverInfo = newCity.AddComponent<CityHoverInfo>();
			PlayerScript playerScript = newCity.AddComponent<PlayerScript>();
			smallCity.playerScript = playerScript;
			playerScript.ownerPlayerID = smallCity.ownerPlayerID;
			if (smallCity.ownerPlayerID == 1)
			{
				endTurnConfirmation.player1Script = playerScript;
				if (playerControllers.Player1Controller == 1)
				{
					AIControlled aIControlled = newCity.AddComponent<AIControlled>();
					playerScript.aIControlled = aIControlled;
					aIControlled.playerScript = playerScript;
					aIControlled.ownerPlayerID = playerScript.ownerPlayerID;
					aIControlled.endTurnConfirmation = endTurnConfirmation;
					aIControlled.pathfinder = pathfinder;
					aIControlled.wearAI = wearAI;
					aIControlled.itemsList = itemsList;
				}
				else if (playerControllers.Player1Controller == 2)
				{
					playerScript.Multiplayer =1;
				}
			}
			else if (smallCity.ownerPlayerID == 2)
			{
				endTurnConfirmation.player2Script = playerScript;
				if (playerControllers.Player2Controller == 1)
				{
					AIControlled aIControlled = newCity.AddComponent<AIControlled>();
					playerScript.aIControlled = aIControlled;
					aIControlled.playerScript = playerScript;
					aIControlled.ownerPlayerID = playerScript.ownerPlayerID;
					aIControlled.endTurnConfirmation = endTurnConfirmation;
					aIControlled.pathfinder = pathfinder;
					aIControlled.wearAI = wearAI;
					aIControlled.itemsList = itemsList;
				}
				else if (playerControllers.Player2Controller == 2)
				{
					playerScript.Multiplayer =1;
				}
			}
			else if (smallCity.ownerPlayerID == 3)
			{
				endTurnConfirmation.player3Script = playerScript;
				if (playerControllers.Player3Controller == 1)
				{
					AIControlled aIControlled = newCity.AddComponent<AIControlled>();
					playerScript.aIControlled = aIControlled;
					aIControlled.playerScript = playerScript;
					aIControlled.ownerPlayerID = playerScript.ownerPlayerID;
					aIControlled.endTurnConfirmation = endTurnConfirmation;
					aIControlled.pathfinder = pathfinder;
					aIControlled.wearAI = wearAI;
					aIControlled.itemsList = itemsList;
				}
				else if (playerControllers.Player3Controller == 2)
				{
					playerScript.Multiplayer =1;
				}
			}
			else if (smallCity.ownerPlayerID == 4)
			{
				endTurnConfirmation.player4Script = playerScript;
				if (playerControllers.Player4Controller == 1)
				{
					AIControlled aIControlled = newCity.AddComponent<AIControlled>();
					playerScript.aIControlled = aIControlled;
					aIControlled.playerScript = playerScript;
					aIControlled.ownerPlayerID = playerScript.ownerPlayerID;
					aIControlled.endTurnConfirmation = endTurnConfirmation;
					aIControlled.pathfinder = pathfinder;
					aIControlled.wearAI = wearAI;
					aIControlled.itemsList = itemsList;
				}
				else if (playerControllers.Player4Controller == 2)
				{
					playerScript.Multiplayer =1;
				}
			}

            cityManager.AddCity(smallCity.cityID, smallCity.ownerPlayerID, smallCity);

            CityInventory cityInventory = newCity.AddComponent<CityInventory>();
            cityInventory.cityID = smallCity.cityID;
			smallCity.cityInventory = cityInventory;

			generatedPositions.Add(spawnPosition);
		}
		markTilesInRadius.MarkTiles();
		borderLineManager.CreateBorderLines();
		forestGenerator.GenerateForest();
	}

    private Vector2 GetValidSpawnPosition(List<Vector2> generatedPositions)
    {
        Vector2 spawnPosition;
        do
        {
            spawnPosition = gridGenerator.GetRandomGridPosition();
        } while (!IsValidSpawnPosition(spawnPosition, generatedPositions));
        return spawnPosition;
    }

    private bool IsValidSpawnPosition(Vector2 position, List<Vector2> generatedPositions)
    {
        foreach (Vector2 generatedPosition in generatedPositions)
        {
            float distance = Vector2.Distance(position, generatedPosition);
            if (distance < minimumDistanceBetweenCities)
            {
                return false; // Позиция недопустима, так как слишком близко к другому городу
            }
        }
		
		int x = Mathf.RoundToInt(position.x);
		int y = Mathf.RoundToInt(position.y);
		CellData cellData = gridGenerator.GetCellDataAtPosition(x, y);

		if (cellData != null && cellData.terrainType != TerrainType.None)
		{
			return false;
		}
	
        return true;
    }

    private void SetLayerAndSortingLayer(GameObject obj, string layerName)
    {
        obj.layer = LayerMask.NameToLayer(layerName);

        foreach (Transform child in obj.transform)
        {
            SetLayerAndSortingLayer(child.gameObject, layerName);
        }
    }
	
	string GetUniqueCityName(List<string> usedNames)
    {
        // Пока не будет выбрано уникальное имя
        while (true)
        {
            // Выбираем случайное имя из списка
            string cityName = cityNameList.GetRandomCityName();

            // Проверяем, было ли оно уже использовано
            if (!usedNames.Contains(cityName))
            {
                return cityName;
            }
        }
    }
}