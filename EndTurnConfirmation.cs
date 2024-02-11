using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndTurnConfirmation : MonoBehaviour
{
    public Button EndTurnButton;
	public SelectedCharacterInfo SelectedCharacterInfo;
	public CityManager cityManager;
	public TurnCounter turnCounter;
	public MarkTilesInRadius markTilesInRadius;
	public ResetOwnerPlayerID resetOwnerPlayerID;
	public BorderLineManager borderLineManager;
	public TechnologyImplementer technologyImplementer;
	public int ownerPlayerID;
	public GameObject VictoryScene;
	public GameObject NotYourTurn;
	public GameObject SaveAndSendTheGame;
	public Button OKButton;
	public TextMeshProUGUI VictoryPlayer;
	public PlayerScript player1Script;
	public PlayerScript player2Script;
	public PlayerScript player3Script;
	public PlayerScript player4Script;
	public int PlayerIs = 2;
	public NetworkGameManager networkGameManager;
	public Camera mainCamera;
	public TextMeshProUGUI DebugInfoPanel;
	public GameObject DebugInfoPanelObj;
	public CitySelectedData citySelectedData;
	public SelectedCharacterInfo selectedCharacterInfo;

    private void Start()
    {
        EndTurnButton.onClick.AddListener(EndTurn);
		VictoryScene.SetActive(false);
		NotYourTurn.SetActive(false);
		SaveAndSendTheGame.SetActive(false);
    }
	
	public void SetupGame()
	{
		if(player1Script.aIControlled != null)
		{
			NotYourTurn.SetActive(true);
			player1Script.aIControlled.AITurn();
		}
	}

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndTurn();
        }
		SmallCity[] cities = FindObjectsOfType<SmallCity>();
		if (player1Script == null)
		{
			foreach (SmallCity city in cities)
			{
				if(city.playerScript != null)
				{
					if(city.playerScript.ownerPlayerID == 1)
					{
						player1Script = city.playerScript;
					}
				}
			}
		}
		if (player2Script == null)
		{
			foreach (SmallCity city in cities)
			{
				if(city.playerScript != null)
				{
					if(city.playerScript.ownerPlayerID == 2)
					{
						player2Script = city.playerScript;
					}
				}
			}
		}
		if (player3Script == null)
		{
			foreach (SmallCity city in cities)
			{
				if(city.playerScript != null)
				{
					if(city.playerScript.ownerPlayerID == 3)
					{
						player3Script = city.playerScript;
					}
				}
			}
		}
		if (player4Script == null)
		{
			foreach (SmallCity city in cities)
			{
				if(city.playerScript != null)
				{
					if(city.playerScript.ownerPlayerID == 4)
					{
						player4Script = city.playerScript;
					}
				}
			}
		}
    }

	public void EndTurn()
	{		
		//if (TileInfoController.characterHoverInfo != null)
		//{
		//	SelectedCityInfo selectedCityInfo = citySelectedData.smallCity.ThisCity.GetComponent<SelectedCityInfo>();
		//	selectedCityInfo.ActivateCityInfoPanelManually(citySelectedData.smallCity);
		//}
		selectedCharacterInfo.DeactivateInfoPanel();
		if (DebugInfoPanelObj.activeSelf)
		{
			DebugInfoPanel.text = "";
			DebugInfoPanelObj.SetActive(false);
		}
		ItemObject[] items = FindObjectsOfType<ItemObject>();
		foreach (ItemObject item in items)
		{
			if (item.inventorySlot == null)
			{
				Destroy(item.gameObject);
			}
		}
		SmallCity[] cities = FindObjectsOfType<SmallCity>();
		int player1CityCount = 0;
		int player2CityCount = 0;
		int player3CityCount = 0;
		int player4CityCount = 0;

		foreach (SmallCity city in cities)
		{
			if (city.ownerPlayerID == 1)
			{
				player1CityCount++;
			}
			if (city.ownerPlayerID == 2)
			{
				player2CityCount++;
			}
			if (city.ownerPlayerID == 3)
			{
				player3CityCount++;
			}
			if (city.ownerPlayerID == 4)
			{
				player4CityCount++;
			}
		}
		if (player1CityCount == 0 && player3CityCount == 0 && player4CityCount == 0)
		{
			VictoryScene.SetActive(true);
			VictoryPlayer.text = "Player 2 is a Winner!";
		}
		else if (player2CityCount == 0 && player3CityCount == 0 && player4CityCount == 0)
		{
			VictoryScene.SetActive(true);
			VictoryPlayer.text = "Player 1 is a Winner!";
		}
		else if (player2CityCount == 0 && player1CityCount == 0 && player4CityCount == 0)
		{
			VictoryScene.SetActive(true);
			VictoryPlayer.text = "Player 3 is a Winner!";
		}
		else if (player2CityCount == 0 && player1CityCount == 0 && player3CityCount == 0)
		{
			VictoryScene.SetActive(true);
			VictoryPlayer.text = "Player 4 is a Winner!";
		}
		else
		{
			if (ownerPlayerID == 2)
			{
				resetOwnerPlayerID.ResetIDs();
				markTilesInRadius.MarkTiles();
				borderLineManager.CreateBorderLines();
				if(ownerPlayerID == 2 && player2Script.Multiplayer == 1)
				{
					MultiplayerMessage message = new MultiplayerMessage
					{
						MessageType = "SendToEnemy.LoadGame"
					};
					SaveLoadManager.LoadGame(message.MessageType);
					networkGameManager.SendSaveFileToClient(message);
				}
				
				if ( player3Script == null)
				{
					ownerPlayerID = 1;
					turnCounter.NextTurn();
				}
				else
				{
					ownerPlayerID = 3;
					turnCounter.NextPlayer();
				}
				SmallCity[] cities2 = FindObjectsOfType<SmallCity>();
				
				CharacterData[] characters = FindObjectsOfType<CharacterData>();
				Forge[] forges = FindObjectsOfType<Forge>();
				MashineFactory[] mashineFactorys = FindObjectsOfType<MashineFactory>();
				foreach (Forge forge in forges)
				{
					if(forge.ownerPlayerID == ownerPlayerID)
					{
						if(forge.Population >= 100 && forge.Population < 200)
						{
							forge.PopulationMaxAP = 1;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 200 && forge.Population < 300)
						{
							forge.PopulationMaxAP = 2;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 300 && forge.Population < 400)
						{
							forge.PopulationMaxAP = 3;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 400 && forge.Population < 500)
						{
							forge.PopulationMaxAP = 4;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 500 && forge.Population < 600)
						{
							forge.PopulationMaxAP = 5;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 600 && forge.Population < 700)
						{
							forge.PopulationMaxAP = 6;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 700 && forge.Population < 800)
						{
							forge.PopulationMaxAP = 7;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 800 && forge.Population < 900)
						{
							forge.PopulationMaxAP = 8;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 900 && forge.Population < 1000)
						{
							forge.PopulationMaxAP = 9;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 1000)
						{
							forge.PopulationMaxAP = 10;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
					}
				}
				foreach (MashineFactory mashineFactory in mashineFactorys)
				{
					if(mashineFactory.ownerPlayerID == ownerPlayerID)
					{
						if(mashineFactory.Population >= 100 && mashineFactory.Population < 200)
						{
							mashineFactory.PopulationMaxAP = 1;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 200 && mashineFactory.Population < 300)
						{
							mashineFactory.PopulationMaxAP = 2;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 300 && mashineFactory.Population < 400)
						{
							mashineFactory.PopulationMaxAP = 3;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 400 && mashineFactory.Population < 500)
						{
							mashineFactory.PopulationMaxAP = 4;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 500 && mashineFactory.Population < 600)
						{
							mashineFactory.PopulationMaxAP = 5;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 600 && mashineFactory.Population < 700)
						{
							mashineFactory.PopulationMaxAP = 6;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 700 && mashineFactory.Population < 800)
						{
							mashineFactory.PopulationMaxAP = 7;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 800 && mashineFactory.Population < 900)
						{
							mashineFactory.PopulationMaxAP = 8;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 900 && mashineFactory.Population < 1000)
						{
							mashineFactory.PopulationMaxAP = 9;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 1000)
						{
							mashineFactory.PopulationMaxAP = 10;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						
					}
				}
				foreach (CharacterData character in characters)
				{
					if(character.ownerPlayerID == ownerPlayerID)
					{
						character.usableMP = character.maxMP;
						character.usableAP = character.maxAP;
						if(character.health < character.maxhealth)
						{
							character.health++;
						}
						if(character.aIDefendDrone == null)
						{
							character.WeaponSlotChanges = 0;
							character.AmmoSlotChanges = 0;
							character.HelmetSlotChanges = 0;
							character.VestSlotChanges = 0;
							character.ShirtSlotChanges = 0;
							character.isSelected = false;
							CharacterHoverInfo characterHoverInfo = character.thisCharacter.GetComponent<CharacterHoverInfo>();
							characterHoverInfo.UpdateHoverInfo();
						}
						
						if(character.transformTo >= 1)
						{
							character.transformTo--;
							if(character.transformTo == 0)
							{
								character.characterType = "Regular";
								character.spritePath = "Sprites/Units/Regular";
								character.maxhealth = +10;
								character.health++;
								character.usableMP++;
								character.maxMP++;
								character.UpdateSprite();
							}
						}
					}
				}
				
				Farm[] farms = FindObjectsOfType<Farm>();
				foreach (Farm farm in farms)
				{
					if(farm.ownerPlayerID == ownerPlayerID)
					{
						if(farm.CurrentFarm == "Flax")
						{
							farm.FlaxCount++;
							farm.cellData.Flax = farm.FlaxCount;
						}
						if(farm.CurrentFarm == "Tomato")
						{
							farm.TomatoCount++;
						}
						if(farm.CurrentFarm == "Carrot")
						{
							farm.CarrotCount++;
						}
						if(farm.CurrentFarm == "Grain")
						{
							farm.GrainCount++;
						}
					}
				}

				foreach (SmallCity city in cities2)
				{
					if(city.ownerPlayerID == ownerPlayerID)
					{
						if(city.playerScript.aIControlled == null)
						{
							Camera.main.transform.position = new Vector3(city.transform.position.x, city.transform.position.y, -10);
						}
						if (city.MobilizationInProgress)
						{
							if (city.cityInventory != null && city.cityInventory.GetFreeCharacterObjectIndex() != -1)
							{
								cityManager.MobilizeCity(city.cityID);
							}
						}
						if(city.ResearchPanelIsActive)
						{
							technologyImplementer.ImplementTechnolohy(city);
						}
					}
				}
				// Проходимся по всем городам и увеличиваем их население
				foreach (SmallCity city in cities2)
				{
					if(city.ownerPlayerID == ownerPlayerID)
					{
						int PossibleToHaveChild = city.PopulationAge18M + city.PopulationAge18W +
						city.PopulationAge19M + city.PopulationAge19W +
						city.PopulationAge20M + city.PopulationAge20W +
						city.PopulationAge21M + city.PopulationAge21W +
						city.PopulationAge22M + city.PopulationAge22W +
						city.PopulationAge23M + city.PopulationAge23W +
						city.PopulationAge24M + city.PopulationAge24W +
						city.PopulationAge25M + city.PopulationAge25W +
						city.PopulationAge26M + city.PopulationAge26W +
						city.PopulationAge27M + city.PopulationAge27W +
						city.PopulationAge28M + city.PopulationAge28W +
						city.PopulationAge29M + city.PopulationAge29W +
						city.PopulationAge30M + city.PopulationAge30W +
						city.PopulationAge31M + city.PopulationAge31W +
						city.PopulationAge32M + city.PopulationAge32W +
						city.PopulationAge33M + city.PopulationAge33W +
						city.PopulationAge34M + city.PopulationAge34W +
						city.PopulationAge35M + city.PopulationAge35W +
						city.PopulationAge36M + city.PopulationAge36W +
						city.PopulationAge37M + city.PopulationAge37W +
						city.PopulationAge38M + city.PopulationAge38W +
						city.PopulationAge39M + city.PopulationAge39W +
						city.PopulationAge40M + city.PopulationAge40W +
						city.PopulationAge41M + city.PopulationAge41W +
						city.PopulationAge42M + city.PopulationAge42W +
						city.PopulationAge43M + city.PopulationAge43W +
						city.PopulationAge44M + city.PopulationAge44W +
						city.PopulationAge45M + city.PopulationAge45W;
						
						int newChild = (int)((float)PossibleToHaveChild * Random.Range(city.minBirthRateJung, city.maxBirthRateJung)); 
						//float maxDeathRateJung1 = city.maxDeathRateJung++;
						//float maxDeathRateOld1 = city.maxDeathRateOld++;
						//float DeathRateJung = Random.Range(city.minDeathRateJung, city.maxDeathRateJung); 
						//float DeathRateOld = Random.Range(city.minDeathRateOld, city.maxDeathRateOld); 
						//city.PopulationAge1M -= (int)((float)city.PopulationAge1M * DeathRateJung);
						//city.PopulationAge1W -= (int)((float)city.PopulationAge1W * DeathRateJung);
						//city.PopulationAge2M -= (int)((float)city.PopulationAge2M * DeathRateJung);
						//city.PopulationAge2W -= (int)((float)city.PopulationAge2W * DeathRateJung);
						//city.PopulationAge3M -= (int)((float)city.PopulationAge3M * DeathRateJung);
						//city.PopulationAge3W -= (int)((float)city.PopulationAge3W * DeathRateJung);
						//city.PopulationAge4M -= (int)((float)city.PopulationAge4M * DeathRateJung);
						//city.PopulationAge4W -= (int)((float)city.PopulationAge4W * DeathRateJung);
						//city.PopulationAge5M -= (int)((float)city.PopulationAge5M * DeathRateJung);
						//city.PopulationAge5W -= (int)((float)city.PopulationAge5W * DeathRateJung);
						//city.PopulationAge6M -= (int)((float)city.PopulationAge6M * DeathRateJung);
						//city.PopulationAge6W -= (int)((float)city.PopulationAge6W * DeathRateJung);
						//city.PopulationAge7M -= (int)((float)city.PopulationAge7M * DeathRateJung);
						//city.PopulationAge7W -= (int)((float)city.PopulationAge7W * DeathRateJung);
						//city.PopulationAge8M -= (int)((float)city.PopulationAge8M * DeathRateJung);
						//city.PopulationAge8W -= (int)((float)city.PopulationAge8W * DeathRateJung);
						//city.PopulationAge9M -= (int)((float)city.PopulationAge9M * DeathRateJung);
						//city.PopulationAge9W -= (int)((float)city.PopulationAge9W * DeathRateJung);
						//city.PopulationAge10M -= (int)((float)city.PopulationAge10M * DeathRateJung);
						//city.PopulationAge10W -= (int)((float)city.PopulationAge10W * DeathRateJung);
						//city.PopulationAge11M -= (int)((float)city.PopulationAge11M * DeathRateJung);
						//city.PopulationAge11W -= (int)((float)city.PopulationAge11W * DeathRateJung);
						//city.PopulationAge12M -= (int)((float)city.PopulationAge12M * DeathRateJung);
						//city.PopulationAge12W -= (int)((float)city.PopulationAge12W * DeathRateJung);
						//city.PopulationAge13M -= (int)((float)city.PopulationAge13M * DeathRateJung);
						//city.PopulationAge13W -= (int)((float)city.PopulationAge13W * DeathRateJung);
						//city.PopulationAge14M -= (int)((float)city.PopulationAge14M * DeathRateJung);
						//city.PopulationAge14W -= (int)((float)city.PopulationAge14W * DeathRateJung);
						//city.PopulationAge15M -= (int)((float)city.PopulationAge15M * DeathRateJung);
						//city.PopulationAge15W -= (int)((float)city.PopulationAge15W * DeathRateJung);
						//city.PopulationAge16M -= (int)((float)city.PopulationAge16M * DeathRateJung);
						//city.PopulationAge16W -= (int)((float)city.PopulationAge16W * DeathRateJung);
						//city.PopulationAge17M -= (int)((float)city.PopulationAge17M * DeathRateJung);
						//city.PopulationAge17W -= (int)((float)city.PopulationAge17W * DeathRateJung);
						//city.PopulationAge18M -= (int)((float)city.PopulationAge18M * DeathRateJung);
						//city.PopulationAge18W -= (int)((float)city.PopulationAge18W * DeathRateJung);
						//city.PopulationAge19M -= (int)((float)city.PopulationAge19M * DeathRateJung);
						//city.PopulationAge19W -= (int)((float)city.PopulationAge19W * DeathRateJung);
						//city.PopulationAge20M -= (int)((float)city.PopulationAge20M * DeathRateJung);
						//city.PopulationAge20W -= (int)((float)city.PopulationAge20W * DeathRateJung);
						//city.PopulationAge21M -= (int)((float)city.PopulationAge21M * DeathRateJung);
						//city.PopulationAge21W -= (int)((float)city.PopulationAge21W * DeathRateJung);
						//city.PopulationAge22M -= (int)((float)city.PopulationAge22M * DeathRateJung);
						//city.PopulationAge22W -= (int)((float)city.PopulationAge22W * DeathRateJung);
						//city.PopulationAge23M -= (int)((float)city.PopulationAge23M * DeathRateJung);
						//city.PopulationAge23W -= (int)((float)city.PopulationAge23W * DeathRateJung);
						//city.PopulationAge24M -= (int)((float)city.PopulationAge24M * DeathRateJung);
						//city.PopulationAge24W -= (int)((float)city.PopulationAge24W * DeathRateJung);
						//city.PopulationAge25M -= (int)((float)city.PopulationAge25M * DeathRateJung);
						//city.PopulationAge25W -= (int)((float)city.PopulationAge25W * DeathRateJung);
						//city.PopulationAge26M -= (int)((float)city.PopulationAge26M * DeathRateJung);
						//city.PopulationAge26W -= (int)((float)city.PopulationAge26W * DeathRateJung);
						//city.PopulationAge27M -= (int)((float)city.PopulationAge27M * DeathRateJung);
						//city.PopulationAge27W -= (int)((float)city.PopulationAge27W * DeathRateJung);
						//city.PopulationAge28M -= (int)((float)city.PopulationAge28M * DeathRateJung);
						//city.PopulationAge28W -= (int)((float)city.PopulationAge28W * DeathRateJung);
						//city.PopulationAge29M -= (int)((float)city.PopulationAge29M * DeathRateJung);
						//city.PopulationAge29W -= (int)((float)city.PopulationAge29W * DeathRateJung);
						//city.PopulationAge30M -= (int)((float)city.PopulationAge30M * DeathRateJung);
						//city.PopulationAge30W -= (int)((float)city.PopulationAge30W * DeathRateJung);
						//city.PopulationAge31M -= (int)((float)city.PopulationAge31M * DeathRateJung);
						//city.PopulationAge31W -= (int)((float)city.PopulationAge31W * DeathRateJung);
						//city.PopulationAge32M -= (int)((float)city.PopulationAge32M * DeathRateJung);
						//city.PopulationAge32W -= (int)((float)city.PopulationAge32W * DeathRateJung);
						//city.PopulationAge33M -= (int)((float)city.PopulationAge33M * DeathRateJung);
						//city.PopulationAge33W -= (int)((float)city.PopulationAge33W * DeathRateJung);
						//city.PopulationAge34M -= (int)((float)city.PopulationAge34M * DeathRateJung);
						//city.PopulationAge34W -= (int)((float)city.PopulationAge34W * DeathRateJung);
						//city.PopulationAge35M -= (int)((float)city.PopulationAge35M * DeathRateJung);
						//city.PopulationAge35W -= (int)((float)city.PopulationAge35W * DeathRateJung);
						//city.PopulationAge36M -= (int)((float)city.PopulationAge36M * DeathRateJung);
						//city.PopulationAge36W -= (int)((float)city.PopulationAge36W * DeathRateJung);
						//city.PopulationAge37M -= (int)((float)city.PopulationAge37M * DeathRateJung);
						//city.PopulationAge37W -= (int)((float)city.PopulationAge37W * DeathRateJung);
						//city.PopulationAge38M -= (int)((float)city.PopulationAge38M * DeathRateJung);
						//city.PopulationAge38W -= (int)((float)city.PopulationAge38W * DeathRateJung);
						//city.PopulationAge39M -= (int)((float)city.PopulationAge39M * DeathRateJung);
						//city.PopulationAge39W -= (int)((float)city.PopulationAge39W * DeathRateJung);
						//city.PopulationAge40M -= (int)((float)city.PopulationAge40M * DeathRateJung);
						//city.PopulationAge40W -= (int)((float)city.PopulationAge40W * DeathRateJung);
						//city.PopulationAge41M -= (int)((float)city.PopulationAge41M * DeathRateJung);
						//city.PopulationAge41W -= (int)((float)city.PopulationAge41W * DeathRateJung);
						//city.PopulationAge42M -= (int)((float)city.PopulationAge42M * DeathRateJung);
						//city.PopulationAge42W -= (int)((float)city.PopulationAge42W * DeathRateJung);
						//city.PopulationAge43M -= (int)((float)city.PopulationAge43M * DeathRateJung);
						//city.PopulationAge43W -= (int)((float)city.PopulationAge43W * DeathRateJung);
						//city.PopulationAge44M -= (int)((float)city.PopulationAge44M * DeathRateJung);
						//city.PopulationAge44W -= (int)((float)city.PopulationAge44W * DeathRateJung);
						//city.PopulationAge45M -= (int)((float)city.PopulationAge45M * DeathRateJung);
						//city.PopulationAge45W -= (int)((float)city.PopulationAge45W * DeathRateJung);
						//city.PopulationAge46M -= (int)((float)city.PopulationAge46M * DeathRateJung);
						//city.PopulationAge46W -= (int)((float)city.PopulationAge46W * DeathRateJung);
						//city.PopulationAge47M -= (int)((float)city.PopulationAge47M * DeathRateJung);
						//city.PopulationAge47W -= (int)((float)city.PopulationAge47W * DeathRateJung);
						//city.PopulationAge48M -= (int)((float)city.PopulationAge48M * DeathRateJung);
						//city.PopulationAge48W -= (int)((float)city.PopulationAge48W * DeathRateJung);
						//city.PopulationAge49M -= (int)((float)city.PopulationAge49M * DeathRateJung);
						//city.PopulationAge49W -= (int)((float)city.PopulationAge49W * DeathRateJung);
						//city.PopulationAge50M -= (int)((float)city.PopulationAge50M * DeathRateJung);
						//city.PopulationAge50W -= (int)((float)city.PopulationAge50W * DeathRateJung);
						//city.PopulationAge51M -= (int)((float)city.PopulationAge51M * DeathRateJung);
						//city.PopulationAge51W -= (int)((float)city.PopulationAge51W * DeathRateJung);
						//city.PopulationAge52M -= (int)((float)city.PopulationAge52M * DeathRateJung);
						//city.PopulationAge52W -= (int)((float)city.PopulationAge52W * DeathRateJung);
						//city.PopulationAge53M -= (int)((float)city.PopulationAge53M * DeathRateJung);
						//city.PopulationAge53W -= (int)((float)city.PopulationAge53W * DeathRateJung);
						//city.PopulationAge54M -= (int)((float)city.PopulationAge54M * DeathRateJung);
						//city.PopulationAge54W -= (int)((float)city.PopulationAge54W * DeathRateJung);
						//city.PopulationAge55M -= (int)((float)city.PopulationAge55M * DeathRateJung);
						//city.PopulationAge55W -= (int)((float)city.PopulationAge55W * DeathRateJung);
						//city.PopulationAge56M -= (int)((float)city.PopulationAge56M * DeathRateJung);
						//city.PopulationAge56W -= (int)((float)city.PopulationAge56W * DeathRateJung);
						//city.PopulationAge57M -= (int)((float)city.PopulationAge57M * DeathRateJung);
						//city.PopulationAge57W -= (int)((float)city.PopulationAge57W * DeathRateJung);
						//city.PopulationAge58M -= (int)((float)city.PopulationAge58M * DeathRateJung);
						//city.PopulationAge58W -= (int)((float)city.PopulationAge58W * DeathRateJung);
						//city.PopulationAge59M -= (int)((float)city.PopulationAge59M * DeathRateJung);
						//city.PopulationAge59W -= (int)((float)city.PopulationAge59W * DeathRateJung);
						//city.PopulationAge60M -= (int)((float)city.PopulationAge60M * DeathRateJung);
						//city.PopulationAge60W -= (int)((float)city.PopulationAge60W * DeathRateJung);
						//city.PopulationAge61M -= (int)((float)city.PopulationAge61M * DeathRateOld);
						//city.PopulationAge61W -= (int)((float)city.PopulationAge61W * DeathRateOld);
						//city.PopulationAge62M -= (int)((float)city.PopulationAge62M * DeathRateOld);
						//city.PopulationAge62W -= (int)((float)city.PopulationAge62W * DeathRateOld);
						//city.PopulationAge63M -= (int)((float)city.PopulationAge63M * DeathRateOld);
						//city.PopulationAge63W -= (int)((float)city.PopulationAge63W * DeathRateOld);
						//city.PopulationAge64M -= (int)((float)city.PopulationAge64M * DeathRateOld);
						//city.PopulationAge64W -= (int)((float)city.PopulationAge64W * DeathRateOld);
						//city.PopulationAge65M -= (int)((float)city.PopulationAge65M * DeathRateOld);
						//city.PopulationAge65W -= (int)((float)city.PopulationAge65W * DeathRateOld);
						//city.PopulationAge66M -= (int)((float)city.PopulationAge66M * DeathRateOld);
						//city.PopulationAge66W -= (int)((float)city.PopulationAge66W * DeathRateOld);
						//city.PopulationAge67M -= (int)((float)city.PopulationAge67M * DeathRateOld);
						//city.PopulationAge67W -= (int)((float)city.PopulationAge67W * DeathRateOld);
						//city.PopulationAge68M -= (int)((float)city.PopulationAge68M * DeathRateOld);
						//city.PopulationAge68W -= (int)((float)city.PopulationAge68W * DeathRateOld);
						//city.PopulationAge69M -= (int)((float)city.PopulationAge69M * DeathRateOld);
						//city.PopulationAge69W -= (int)((float)city.PopulationAge69W * DeathRateOld);
						//city.PopulationAge70M -= (int)((float)city.PopulationAge70M * DeathRateOld);
						//city.PopulationAge70W -= (int)((float)city.PopulationAge70W * DeathRateOld);
						
						city.PopulationAge70M = city.PopulationAge69M;
						city.PopulationAge70W = city.PopulationAge69W;
						city.PopulationAge69M = city.PopulationAge68M;
						city.PopulationAge69W = city.PopulationAge68W;
						city.PopulationAge68M = city.PopulationAge67M;
						city.PopulationAge68W = city.PopulationAge67W;
						city.PopulationAge67M = city.PopulationAge66M;
						city.PopulationAge67W = city.PopulationAge66W;
						city.PopulationAge66M = city.PopulationAge65M;
						city.PopulationAge66W = city.PopulationAge65W;
						city.PopulationAge65M = city.PopulationAge64M;
						city.PopulationAge65W = city.PopulationAge64W;
						city.PopulationAge64M = city.PopulationAge63M;
						city.PopulationAge64W = city.PopulationAge63W;
						city.PopulationAge63M = city.PopulationAge62M;
						city.PopulationAge63W = city.PopulationAge62W;
						city.PopulationAge62M = city.PopulationAge61M;
						city.PopulationAge62W = city.PopulationAge61W;
						city.PopulationAge61M = city.PopulationAge60M;
						city.PopulationAge61W = city.PopulationAge60W;
						city.PopulationAge60M = city.PopulationAge59M;
						city.PopulationAge60W = city.PopulationAge59W;
						city.PopulationAge59M = city.PopulationAge58M;
						city.PopulationAge59W = city.PopulationAge58W;
						city.PopulationAge58M = city.PopulationAge57M;
						city.PopulationAge58W = city.PopulationAge57W;
						city.PopulationAge57M = city.PopulationAge56M;
						city.PopulationAge57W = city.PopulationAge56W;
						city.PopulationAge56M = city.PopulationAge55M;
						city.PopulationAge56W = city.PopulationAge55W;
						city.PopulationAge55M = city.PopulationAge54M;
						city.PopulationAge55W = city.PopulationAge54W;
						city.PopulationAge54M = city.PopulationAge53M;
						city.PopulationAge54W = city.PopulationAge53W;
						city.PopulationAge53M = city.PopulationAge52M;
						city.PopulationAge53W = city.PopulationAge52W;
						city.PopulationAge52M = city.PopulationAge51M;
						city.PopulationAge52W = city.PopulationAge51W;
						city.PopulationAge51M = city.PopulationAge50M;
						city.PopulationAge51W = city.PopulationAge50W;
						city.PopulationAge50M = city.PopulationAge49M;
						city.PopulationAge50W = city.PopulationAge49W;
						city.PopulationAge49M = city.PopulationAge48M;
						city.PopulationAge49W = city.PopulationAge48W;
						city.PopulationAge48M = city.PopulationAge47M;
						city.PopulationAge48W = city.PopulationAge47W;
						city.PopulationAge47M = city.PopulationAge46M;
						city.PopulationAge47W = city.PopulationAge46W;
						city.PopulationAge46M = city.PopulationAge45M;
						city.PopulationAge46W = city.PopulationAge45W;
						city.PopulationAge45M = city.PopulationAge44M;
						city.PopulationAge45W = city.PopulationAge44W;
						city.PopulationAge44M = city.PopulationAge43M;
						city.PopulationAge44W = city.PopulationAge43W;
						city.PopulationAge43M = city.PopulationAge42M;
						city.PopulationAge43W = city.PopulationAge42W;
						city.PopulationAge42M = city.PopulationAge41M;
						city.PopulationAge42W = city.PopulationAge41W;
						city.PopulationAge41M = city.PopulationAge40M;
						city.PopulationAge41W = city.PopulationAge40W;
						city.PopulationAge40M = city.PopulationAge39M;
						city.PopulationAge40W = city.PopulationAge39W;
						city.PopulationAge39M = city.PopulationAge38M;
						city.PopulationAge39W = city.PopulationAge38W;
						city.PopulationAge38M = city.PopulationAge37M;
						city.PopulationAge38W = city.PopulationAge37W;
						city.PopulationAge37M = city.PopulationAge36M;
						city.PopulationAge37W = city.PopulationAge36W;
						city.PopulationAge36M = city.PopulationAge35M;
						city.PopulationAge36W = city.PopulationAge35W;
						city.PopulationAge35M = city.PopulationAge34M;
						city.PopulationAge35W = city.PopulationAge34W;
						city.PopulationAge34M = city.PopulationAge33M;
						city.PopulationAge34W = city.PopulationAge33W;
						city.PopulationAge33M = city.PopulationAge32M;
						city.PopulationAge33W = city.PopulationAge32W;
						city.PopulationAge32M = city.PopulationAge31M;
						city.PopulationAge32W = city.PopulationAge31W;
						city.PopulationAge31M = city.PopulationAge30M;
						city.PopulationAge31W = city.PopulationAge30W;
						city.PopulationAge30M = city.PopulationAge29M;
						city.PopulationAge30W = city.PopulationAge29W;
						city.PopulationAge29M = city.PopulationAge28M;
						city.PopulationAge29W = city.PopulationAge28W;
						city.PopulationAge28M = city.PopulationAge27M;
						city.PopulationAge28W = city.PopulationAge27W;
						city.PopulationAge27M = city.PopulationAge26M;
						city.PopulationAge27W = city.PopulationAge26W;
						city.PopulationAge26M = city.PopulationAge25M;
						city.PopulationAge26W = city.PopulationAge25W;
						city.PopulationAge25M = city.PopulationAge24M;
						city.PopulationAge25W = city.PopulationAge24W;
						city.PopulationAge24M = city.PopulationAge23M;
						city.PopulationAge24W = city.PopulationAge23W;
						city.PopulationAge23M = city.PopulationAge22M;
						city.PopulationAge23W = city.PopulationAge22W;
						city.PopulationAge22M = city.PopulationAge21M;
						city.PopulationAge22W = city.PopulationAge21W;
						city.PopulationAge21M = city.PopulationAge20M;
						city.PopulationAge21W = city.PopulationAge20W;
						city.PopulationAge20M = city.PopulationAge19M;
						city.PopulationAge20W = city.PopulationAge19W;
						city.PopulationAge19M = city.PopulationAge18M;
						city.PopulationAge19W = city.PopulationAge18W;
						city.PopulationAge18M = city.PopulationAge17M;
						city.PopulationAge18W = city.PopulationAge17W;
						city.PopulationAge17M = city.PopulationAge16M;
						city.PopulationAge17W = city.PopulationAge16W;
						city.PopulationAge16M = city.PopulationAge15M;
						city.PopulationAge16W = city.PopulationAge15W;
						city.PopulationAge15M = city.PopulationAge14M;
						city.PopulationAge15W = city.PopulationAge14W;
						city.PopulationAge14M = city.PopulationAge13M;
						city.PopulationAge14W = city.PopulationAge13W;
						city.PopulationAge13M = city.PopulationAge12M;
						city.PopulationAge13W = city.PopulationAge12W;
						city.PopulationAge12M = city.PopulationAge11M;
						city.PopulationAge12W = city.PopulationAge11W;
						city.PopulationAge11M = city.PopulationAge10M;
						city.PopulationAge11W = city.PopulationAge10W;
						city.PopulationAge10M = city.PopulationAge9M;
						city.PopulationAge10W = city.PopulationAge9W;
						city.PopulationAge9M = city.PopulationAge8M;
						city.PopulationAge9W = city.PopulationAge8W;
						city.PopulationAge8M = city.PopulationAge7M;
						city.PopulationAge8W = city.PopulationAge7W;
						city.PopulationAge7M = city.PopulationAge6M;
						city.PopulationAge7W = city.PopulationAge6W;
						city.PopulationAge6M = city.PopulationAge5M;
						city.PopulationAge6W = city.PopulationAge5W;
						city.PopulationAge5M = city.PopulationAge4M;
						city.PopulationAge5W = city.PopulationAge4W;
						city.PopulationAge4M = city.PopulationAge3M;
						city.PopulationAge4W = city.PopulationAge3W;
						city.PopulationAge3M = city.PopulationAge2M;
						city.PopulationAge3W = city.PopulationAge2W;
						city.PopulationAge2M = city.PopulationAge1M;
						city.PopulationAge2W = city.PopulationAge1W;
						city.PopulationAge1M = city.PopulationAge0M;
						city.PopulationAge1W = city.PopulationAge0W;
						city.PopulationAge0M = (int)((float)newChild / (3f / 2f));
						city.PopulationAge0W = (int)((float)newChild / (3f / 1f));

						city.Population = city.PopulationAge0M + city.PopulationAge0W + city.PopulationAge1M + city.PopulationAge1W + city.PopulationAge2M + city.PopulationAge2W +
						city.PopulationAge3M + city.PopulationAge3W +
						city.PopulationAge4M + city.PopulationAge4W +
						city.PopulationAge5M + city.PopulationAge5W +
						city.PopulationAge6M + city.PopulationAge6W +
						city.PopulationAge7M + city.PopulationAge7W +
						city.PopulationAge8M + city.PopulationAge8W +
						city.PopulationAge9M + city.PopulationAge9W +
						city.PopulationAge10M + city.PopulationAge10W +
						city.PopulationAge11M + city.PopulationAge11W +
						city.PopulationAge12M + city.PopulationAge12W +
						city.PopulationAge13M + city.PopulationAge13W +
						city.PopulationAge14M + city.PopulationAge14W +
						city.PopulationAge15M + city.PopulationAge15W +
						city.PopulationAge16M + city.PopulationAge16W +
						city.PopulationAge17M + city.PopulationAge17W +
						city.PopulationAge18M + city.PopulationAge18W +
						city.PopulationAge19M + city.PopulationAge19W +
						city.PopulationAge20M + city.PopulationAge20W +
						city.PopulationAge21M + city.PopulationAge21W +
						city.PopulationAge22M + city.PopulationAge22W +
						city.PopulationAge23M + city.PopulationAge23W +
						city.PopulationAge24M + city.PopulationAge24W +
						city.PopulationAge25M + city.PopulationAge25W +
						city.PopulationAge26M + city.PopulationAge26W +
						city.PopulationAge27M + city.PopulationAge27W +
						city.PopulationAge28M + city.PopulationAge28W +
						city.PopulationAge29M + city.PopulationAge29W +
						city.PopulationAge30M + city.PopulationAge30W +
						city.PopulationAge31M + city.PopulationAge31W +
						city.PopulationAge32M + city.PopulationAge32W +
						city.PopulationAge33M + city.PopulationAge33W +
						city.PopulationAge34M + city.PopulationAge34W +
						city.PopulationAge35M + city.PopulationAge35W +
						city.PopulationAge36M + city.PopulationAge36W +
						city.PopulationAge37M + city.PopulationAge37W +
						city.PopulationAge38M + city.PopulationAge38W +
						city.PopulationAge39M + city.PopulationAge39W +
						city.PopulationAge40M + city.PopulationAge40W +
						city.PopulationAge41M + city.PopulationAge41W +
						city.PopulationAge42M + city.PopulationAge42W +
						city.PopulationAge43M + city.PopulationAge43W +
						city.PopulationAge44M + city.PopulationAge44W +
						city.PopulationAge45M + city.PopulationAge45W +
						city.PopulationAge46M + city.PopulationAge46W +
						city.PopulationAge47M + city.PopulationAge47W +
						city.PopulationAge48M + city.PopulationAge48W +
						city.PopulationAge49M + city.PopulationAge49W +
						city.PopulationAge50M + city.PopulationAge50W +
						city.PopulationAge51M + city.PopulationAge51W +
						city.PopulationAge52M + city.PopulationAge52W +
						city.PopulationAge53M + city.PopulationAge53W +
						city.PopulationAge54M + city.PopulationAge54W +
						city.PopulationAge55M + city.PopulationAge55W +
						city.PopulationAge56M + city.PopulationAge56W +
						city.PopulationAge57M + city.PopulationAge57W +
						city.PopulationAge58M + city.PopulationAge58W +
						city.PopulationAge59M + city.PopulationAge59W +
						city.PopulationAge60M + city.PopulationAge60W +
						city.PopulationAge61M + city.PopulationAge61W +
						city.PopulationAge62M + city.PopulationAge62W +
						city.PopulationAge63M + city.PopulationAge63W +
						city.PopulationAge64M + city.PopulationAge64W +
						city.PopulationAge65M + city.PopulationAge65W +
						city.PopulationAge66M + city.PopulationAge66W +
						city.PopulationAge67M + city.PopulationAge67W +
						city.PopulationAge68M + city.PopulationAge68W +
						city.PopulationAge69M + city.PopulationAge69W +
						city.PopulationAge70M + city.PopulationAge70W;
						
						city.PopulationWorkable = city.PopulationAge18M +
						city.PopulationAge19M +
						city.PopulationAge20M +
						city.PopulationAge21M +
						city.PopulationAge22M +
						city.PopulationAge23M +
						city.PopulationAge24M +
						city.PopulationAge25M +
						city.PopulationAge26M +
						city.PopulationAge27M +
						city.PopulationAge28M +
						city.PopulationAge29M +
						city.PopulationAge30M +
						city.PopulationAge31M +
						city.PopulationAge32M +
						city.PopulationAge33M +
						city.PopulationAge34M +
						city.PopulationAge35M +
						city.PopulationAge36M +
						city.PopulationAge37M +
						city.PopulationAge38M +
						city.PopulationAge39M +
						city.PopulationAge40M +
						city.PopulationAge41M +
						city.PopulationAge42M +
						city.PopulationAge43M +
						city.PopulationAge44M +
						city.PopulationAge45M;
					  
						if(city.PopulationWorkable <= 500)
						{
							city.PopulationMaxAP = 1;
							city.PopulationAP = city.PopulationMaxAP;
						}
						else if(city.PopulationWorkable <= 750 && city.PopulationWorkable > 500)
						{
							city.PopulationMaxAP = 2;
							city.PopulationAP = city.PopulationMaxAP;
						}
						else if(city.PopulationWorkable <= 1000 && city.PopulationWorkable > 750)
						{
							city.PopulationMaxAP = 3;
							city.PopulationAP = city.PopulationMaxAP;
						}
						else if(city.PopulationWorkable > 1000)
						{
							city.PopulationMaxAP = 4;
							city.PopulationAP = city.PopulationMaxAP;
						}
					}
				}
				SmallCity smallCity = GetSmallCityUnderMouse();
				if(smallCity != null)
				{
					SelectedCityInfo selectedCityInfo = smallCity.ThisCity.GetComponent<SelectedCityInfo>();
					if (smallCity.isSelected && selectedCityInfo.infoPanel)
					{
						selectedCityInfo.cityPopulationText.text = "";
						selectedCityInfo.ActivateCityInfoPanelManually(smallCity);
					}
					else 
					{
						CityHoverInfo cityHoverInfo = smallCity.ThisCity.GetComponent<CityHoverInfo>();
						cityHoverInfo.cityPopulationText.text = "";
						cityHoverInfo.CityInfoActivate();
					}
				}
				else if (citySelectedData.smallCity != null)
				{
					SelectedCityInfo selectedCityInfo = citySelectedData.smallCity.ThisCity.GetComponent<SelectedCityInfo>();
					selectedCityInfo.ActivateCityInfoPanelManually(citySelectedData.smallCity);
				}
				
				if(ownerPlayerID == 1 && player1Script.aIControlled != null && player1Script.Multiplayer == 0)
				{
					NotYourTurn.SetActive(true);
					player1Script.aIControlled.AITurn();
				}
				else if(ownerPlayerID == 3 && player3Script.aIControlled != null && player3Script.Multiplayer == 0)
				{
					NotYourTurn.SetActive(true);
					player3Script.aIControlled.AITurn();
				}
				else if (ownerPlayerID == 1 && player1Script.Multiplayer == 1)
				{
					NotYourTurn.SetActive(true);
					MultiplayerMessage message = new MultiplayerMessage
					{
						MessageType = "SendToEnemy.LoadGame"
					};
					SaveLoadManager.LoadGame(message.MessageType);
				}
				else if(ownerPlayerID == 3 && player3Script.Multiplayer == 1)
				{
					NotYourTurn.SetActive(true);
					MultiplayerMessage message = new MultiplayerMessage
					{
						MessageType = "SendToEnemy.LoadGame"
					};
					SaveLoadManager.LoadGame(message.MessageType);
				}
			}
			else if (ownerPlayerID == 1)
			{
				resetOwnerPlayerID.ResetIDs();
				markTilesInRadius.MarkTiles();
				borderLineManager.CreateBorderLines();
				ownerPlayerID = 2;
				turnCounter.NextPlayer();
				if (PlayerIs > 1 && player2Script.aIControlled == null)
				{
					SaveAndSendTheGame.SetActive(true);
				}
				
				SmallCity[] cities2 = FindObjectsOfType<SmallCity>();

				// Находим все персонажи в сцене
				CharacterData[] characters = FindObjectsOfType<CharacterData>();
				Forge[] forges = FindObjectsOfType<Forge>();
				MashineFactory[] mashineFactorys = FindObjectsOfType<MashineFactory>();
				foreach (Forge forge in forges)
				{
					if(forge.ownerPlayerID == ownerPlayerID)
					{
						if(forge.Population >= 100 && forge.Population < 200)
						{
							forge.PopulationMaxAP = 1;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 200 && forge.Population < 300)
						{
							forge.PopulationMaxAP = 2;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 300 && forge.Population < 400)
						{
							forge.PopulationMaxAP = 3;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 400 && forge.Population < 500)
						{
							forge.PopulationMaxAP = 4;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 500 && forge.Population < 600)
						{
							forge.PopulationMaxAP = 5;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 600 && forge.Population < 700)
						{
							forge.PopulationMaxAP = 6;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 700 && forge.Population < 800)
						{
							forge.PopulationMaxAP = 7;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 800 && forge.Population < 900)
						{
							forge.PopulationMaxAP = 8;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 900 && forge.Population < 1000)
						{
							forge.PopulationMaxAP = 9;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 1000)
						{
							forge.PopulationMaxAP = 10;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
					}
				}
				foreach (MashineFactory mashineFactory in mashineFactorys)
				{
					if(mashineFactory.ownerPlayerID == ownerPlayerID)
					{
						if(mashineFactory.Population >= 100 && mashineFactory.Population < 200)
						{
							mashineFactory.PopulationMaxAP = 1;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 200 && mashineFactory.Population < 300)
						{
							mashineFactory.PopulationMaxAP = 2;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 300 && mashineFactory.Population < 400)
						{
							mashineFactory.PopulationMaxAP = 3;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 400 && mashineFactory.Population < 500)
						{
							mashineFactory.PopulationMaxAP = 4;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 500 && mashineFactory.Population < 600)
						{
							mashineFactory.PopulationMaxAP = 5;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 600 && mashineFactory.Population < 700)
						{
							mashineFactory.PopulationMaxAP = 6;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 700 && mashineFactory.Population < 800)
						{
							mashineFactory.PopulationMaxAP = 7;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 800 && mashineFactory.Population < 900)
						{
							mashineFactory.PopulationMaxAP = 8;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 900 && mashineFactory.Population < 1000)
						{
							mashineFactory.PopulationMaxAP = 9;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 1000)
						{
							mashineFactory.PopulationMaxAP = 10;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						
					}
				}
				foreach (CharacterData character in characters)
				{
					if(character.ownerPlayerID == ownerPlayerID)
					{
						character.usableMP = character.maxMP;
						character.usableAP = character.maxAP;
						if(character.health < character.maxhealth)
						{
							character.health++;
						}
						if(character.aIDefendDrone == null)
						{
							character.WeaponSlotChanges = 0;
							character.AmmoSlotChanges = 0;
							character.HelmetSlotChanges = 0;
							character.VestSlotChanges = 0;
							character.ShirtSlotChanges = 0;
							character.isSelected = false;
							CharacterHoverInfo characterHoverInfo = character.thisCharacter.GetComponent<CharacterHoverInfo>();
							characterHoverInfo.UpdateHoverInfo();
						}
						
						if(character.transformTo >= 1)
						{
							character.transformTo--;
							if(character.transformTo == 0)
							{
								character.characterType = "Regular";
								character.spritePath = "Sprites/Units/Regular";
								character.maxhealth = +10;
								character.health++;
								character.usableMP++;
								character.maxMP++;
								character.UpdateSprite();
							}
						}
					}
				}
				
				Farm[] farms = FindObjectsOfType<Farm>();
				foreach (Farm farm in farms)
				{
					if(farm.ownerPlayerID == ownerPlayerID)
					{
						if(farm.CurrentFarm == "Flax")
						{
							farm.FlaxCount++;
							farm.cellData.Flax = farm.FlaxCount;
						}
						if(farm.CurrentFarm == "Tomato")
						{
							farm.TomatoCount++;
						}
						if(farm.CurrentFarm == "Carrot")
						{
							farm.CarrotCount++;
						}
						if(farm.CurrentFarm == "Grain")
						{
							farm.GrainCount++;
						}
					}
				}

				foreach (SmallCity city in cities2)
				{
					if (city.ownerPlayerID == ownerPlayerID)
					{
						if(city.playerScript.aIControlled == null)
						{
							Camera.main.transform.position = new Vector3(city.transform.position.x, city.transform.position.y, -10);
						}
						if (city.MobilizationInProgress)
						{
							if (city.cityInventory != null && city.cityInventory.GetFreeCharacterObjectIndex() != -1)
							{
								cityManager.MobilizeCity(city.cityID);
							}
						}
						if(city.ResearchPanelIsActive)
						{
							technologyImplementer.ImplementTechnolohy(city);
						}
					}
				}
				// Проходимся по всем городам и увеличиваем их население
				foreach (SmallCity city in cities2)
				{
					if (city.ownerPlayerID == ownerPlayerID)
					{
						int PossibleToHaveChild = city.PopulationAge18M + city.PopulationAge18W +
						city.PopulationAge19M + city.PopulationAge19W +
						city.PopulationAge20M + city.PopulationAge20W +
						city.PopulationAge21M + city.PopulationAge21W +
						city.PopulationAge22M + city.PopulationAge22W +
						city.PopulationAge23M + city.PopulationAge23W +
						city.PopulationAge24M + city.PopulationAge24W +
						city.PopulationAge25M + city.PopulationAge25W +
						city.PopulationAge26M + city.PopulationAge26W +
						city.PopulationAge27M + city.PopulationAge27W +
						city.PopulationAge28M + city.PopulationAge28W +
						city.PopulationAge29M + city.PopulationAge29W +
						city.PopulationAge30M + city.PopulationAge30W +
						city.PopulationAge31M + city.PopulationAge31W +
						city.PopulationAge32M + city.PopulationAge32W +
						city.PopulationAge33M + city.PopulationAge33W +
						city.PopulationAge34M + city.PopulationAge34W +
						city.PopulationAge35M + city.PopulationAge35W +
						city.PopulationAge36M + city.PopulationAge36W +
						city.PopulationAge37M + city.PopulationAge37W +
						city.PopulationAge38M + city.PopulationAge38W +
						city.PopulationAge39M + city.PopulationAge39W +
						city.PopulationAge40M + city.PopulationAge40W +
						city.PopulationAge41M + city.PopulationAge41W +
						city.PopulationAge42M + city.PopulationAge42W +
						city.PopulationAge43M + city.PopulationAge43W +
						city.PopulationAge44M + city.PopulationAge44W +
						city.PopulationAge45M + city.PopulationAge45W;
						
						int newChild = (int)((float)PossibleToHaveChild * Random.Range(city.minBirthRateJung, city.maxBirthRateJung)); 
						//float maxDeathRateJung1 = city.maxDeathRateJung++;
						//float maxDeathRateOld1 = city.maxDeathRateOld++;
						//float DeathRateJung = Random.Range(city.minDeathRateJung, city.maxDeathRateJung); 
						//float DeathRateOld = Random.Range(city.minDeathRateOld, city.maxDeathRateOld); 
						//city.PopulationAge1M -= (int)((float)city.PopulationAge1M * DeathRateJung);
						//city.PopulationAge1W -= (int)((float)city.PopulationAge1W * DeathRateJung);
						//city.PopulationAge2M -= (int)((float)city.PopulationAge2M * DeathRateJung);
						//city.PopulationAge2W -= (int)((float)city.PopulationAge2W * DeathRateJung);
						//city.PopulationAge3M -= (int)((float)city.PopulationAge3M * DeathRateJung);
						//city.PopulationAge3W -= (int)((float)city.PopulationAge3W * DeathRateJung);
						//city.PopulationAge4M -= (int)((float)city.PopulationAge4M * DeathRateJung);
						//city.PopulationAge4W -= (int)((float)city.PopulationAge4W * DeathRateJung);
						//city.PopulationAge5M -= (int)((float)city.PopulationAge5M * DeathRateJung);
						//city.PopulationAge5W -= (int)((float)city.PopulationAge5W * DeathRateJung);
						//city.PopulationAge6M -= (int)((float)city.PopulationAge6M * DeathRateJung);
						//city.PopulationAge6W -= (int)((float)city.PopulationAge6W * DeathRateJung);
						//city.PopulationAge7M -= (int)((float)city.PopulationAge7M * DeathRateJung);
						//city.PopulationAge7W -= (int)((float)city.PopulationAge7W * DeathRateJung);
						//city.PopulationAge8M -= (int)((float)city.PopulationAge8M * DeathRateJung);
						//city.PopulationAge8W -= (int)((float)city.PopulationAge8W * DeathRateJung);
						//city.PopulationAge9M -= (int)((float)city.PopulationAge9M * DeathRateJung);
						//city.PopulationAge9W -= (int)((float)city.PopulationAge9W * DeathRateJung);
						//city.PopulationAge10M -= (int)((float)city.PopulationAge10M * DeathRateJung);
						//city.PopulationAge10W -= (int)((float)city.PopulationAge10W * DeathRateJung);
						//city.PopulationAge11M -= (int)((float)city.PopulationAge11M * DeathRateJung);
						//city.PopulationAge11W -= (int)((float)city.PopulationAge11W * DeathRateJung);
						//city.PopulationAge12M -= (int)((float)city.PopulationAge12M * DeathRateJung);
						//city.PopulationAge12W -= (int)((float)city.PopulationAge12W * DeathRateJung);
						//city.PopulationAge13M -= (int)((float)city.PopulationAge13M * DeathRateJung);
						//city.PopulationAge13W -= (int)((float)city.PopulationAge13W * DeathRateJung);
						//city.PopulationAge14M -= (int)((float)city.PopulationAge14M * DeathRateJung);
						//city.PopulationAge14W -= (int)((float)city.PopulationAge14W * DeathRateJung);
						//city.PopulationAge15M -= (int)((float)city.PopulationAge15M * DeathRateJung);
						//city.PopulationAge15W -= (int)((float)city.PopulationAge15W * DeathRateJung);
						//city.PopulationAge16M -= (int)((float)city.PopulationAge16M * DeathRateJung);
						//city.PopulationAge16W -= (int)((float)city.PopulationAge16W * DeathRateJung);
						//city.PopulationAge17M -= (int)((float)city.PopulationAge17M * DeathRateJung);
						//city.PopulationAge17W -= (int)((float)city.PopulationAge17W * DeathRateJung);
						//city.PopulationAge18M -= (int)((float)city.PopulationAge18M * DeathRateJung);
						//city.PopulationAge18W -= (int)((float)city.PopulationAge18W * DeathRateJung);
						//city.PopulationAge19M -= (int)((float)city.PopulationAge19M * DeathRateJung);
						//city.PopulationAge19W -= (int)((float)city.PopulationAge19W * DeathRateJung);
						//city.PopulationAge20M -= (int)((float)city.PopulationAge20M * DeathRateJung);
						//city.PopulationAge20W -= (int)((float)city.PopulationAge20W * DeathRateJung);
						//city.PopulationAge21M -= (int)((float)city.PopulationAge21M * DeathRateJung);
						//city.PopulationAge21W -= (int)((float)city.PopulationAge21W * DeathRateJung);
						//city.PopulationAge22M -= (int)((float)city.PopulationAge22M * DeathRateJung);
						//city.PopulationAge22W -= (int)((float)city.PopulationAge22W * DeathRateJung);
						//city.PopulationAge23M -= (int)((float)city.PopulationAge23M * DeathRateJung);
						//city.PopulationAge23W -= (int)((float)city.PopulationAge23W * DeathRateJung);
						//city.PopulationAge24M -= (int)((float)city.PopulationAge24M * DeathRateJung);
						//city.PopulationAge24W -= (int)((float)city.PopulationAge24W * DeathRateJung);
						//city.PopulationAge25M -= (int)((float)city.PopulationAge25M * DeathRateJung);
						//city.PopulationAge25W -= (int)((float)city.PopulationAge25W * DeathRateJung);
						//city.PopulationAge26M -= (int)((float)city.PopulationAge26M * DeathRateJung);
						//city.PopulationAge26W -= (int)((float)city.PopulationAge26W * DeathRateJung);
						//city.PopulationAge27M -= (int)((float)city.PopulationAge27M * DeathRateJung);
						//city.PopulationAge27W -= (int)((float)city.PopulationAge27W * DeathRateJung);
						//city.PopulationAge28M -= (int)((float)city.PopulationAge28M * DeathRateJung);
						//city.PopulationAge28W -= (int)((float)city.PopulationAge28W * DeathRateJung);
						//city.PopulationAge29M -= (int)((float)city.PopulationAge29M * DeathRateJung);
						//city.PopulationAge29W -= (int)((float)city.PopulationAge29W * DeathRateJung);
						//city.PopulationAge30M -= (int)((float)city.PopulationAge30M * DeathRateJung);
						//city.PopulationAge30W -= (int)((float)city.PopulationAge30W * DeathRateJung);
						//city.PopulationAge31M -= (int)((float)city.PopulationAge31M * DeathRateJung);
						//city.PopulationAge31W -= (int)((float)city.PopulationAge31W * DeathRateJung);
						//city.PopulationAge32M -= (int)((float)city.PopulationAge32M * DeathRateJung);
						//city.PopulationAge32W -= (int)((float)city.PopulationAge32W * DeathRateJung);
						//city.PopulationAge33M -= (int)((float)city.PopulationAge33M * DeathRateJung);
						//city.PopulationAge33W -= (int)((float)city.PopulationAge33W * DeathRateJung);
						//city.PopulationAge34M -= (int)((float)city.PopulationAge34M * DeathRateJung);
						//city.PopulationAge34W -= (int)((float)city.PopulationAge34W * DeathRateJung);
						//city.PopulationAge35M -= (int)((float)city.PopulationAge35M * DeathRateJung);
						//city.PopulationAge35W -= (int)((float)city.PopulationAge35W * DeathRateJung);
						//city.PopulationAge36M -= (int)((float)city.PopulationAge36M * DeathRateJung);
						//city.PopulationAge36W -= (int)((float)city.PopulationAge36W * DeathRateJung);
						//city.PopulationAge37M -= (int)((float)city.PopulationAge37M * DeathRateJung);
						//city.PopulationAge37W -= (int)((float)city.PopulationAge37W * DeathRateJung);
						//city.PopulationAge38M -= (int)((float)city.PopulationAge38M * DeathRateJung);
						//city.PopulationAge38W -= (int)((float)city.PopulationAge38W * DeathRateJung);
						//city.PopulationAge39M -= (int)((float)city.PopulationAge39M * DeathRateJung);
						//city.PopulationAge39W -= (int)((float)city.PopulationAge39W * DeathRateJung);
						//city.PopulationAge40M -= (int)((float)city.PopulationAge40M * DeathRateJung);
						//city.PopulationAge40W -= (int)((float)city.PopulationAge40W * DeathRateJung);
						//city.PopulationAge41M -= (int)((float)city.PopulationAge41M * DeathRateJung);
						//city.PopulationAge41W -= (int)((float)city.PopulationAge41W * DeathRateJung);
						//city.PopulationAge42M -= (int)((float)city.PopulationAge42M * DeathRateJung);
						//city.PopulationAge42W -= (int)((float)city.PopulationAge42W * DeathRateJung);
						//city.PopulationAge43M -= (int)((float)city.PopulationAge43M * DeathRateJung);
						//city.PopulationAge43W -= (int)((float)city.PopulationAge43W * DeathRateJung);
						//city.PopulationAge44M -= (int)((float)city.PopulationAge44M * DeathRateJung);
						//city.PopulationAge44W -= (int)((float)city.PopulationAge44W * DeathRateJung);
						//city.PopulationAge45M -= (int)((float)city.PopulationAge45M * DeathRateJung);
						//city.PopulationAge45W -= (int)((float)city.PopulationAge45W * DeathRateJung);
						//city.PopulationAge46M -= (int)((float)city.PopulationAge46M * DeathRateJung);
						//city.PopulationAge46W -= (int)((float)city.PopulationAge46W * DeathRateJung);
						//city.PopulationAge47M -= (int)((float)city.PopulationAge47M * DeathRateJung);
						//city.PopulationAge47W -= (int)((float)city.PopulationAge47W * DeathRateJung);
						//city.PopulationAge48M -= (int)((float)city.PopulationAge48M * DeathRateJung);
						//city.PopulationAge48W -= (int)((float)city.PopulationAge48W * DeathRateJung);
						//city.PopulationAge49M -= (int)((float)city.PopulationAge49M * DeathRateJung);
						//city.PopulationAge49W -= (int)((float)city.PopulationAge49W * DeathRateJung);
						//city.PopulationAge50M -= (int)((float)city.PopulationAge50M * DeathRateJung);
						//city.PopulationAge50W -= (int)((float)city.PopulationAge50W * DeathRateJung);
						//city.PopulationAge51M -= (int)((float)city.PopulationAge51M * DeathRateJung);
						//city.PopulationAge51W -= (int)((float)city.PopulationAge51W * DeathRateJung);
						//city.PopulationAge52M -= (int)((float)city.PopulationAge52M * DeathRateJung);
						//city.PopulationAge52W -= (int)((float)city.PopulationAge52W * DeathRateJung);
						//city.PopulationAge53M -= (int)((float)city.PopulationAge53M * DeathRateJung);
						//city.PopulationAge53W -= (int)((float)city.PopulationAge53W * DeathRateJung);
						//city.PopulationAge54M -= (int)((float)city.PopulationAge54M * DeathRateJung);
						//city.PopulationAge54W -= (int)((float)city.PopulationAge54W * DeathRateJung);
						//city.PopulationAge55M -= (int)((float)city.PopulationAge55M * DeathRateJung);
						//city.PopulationAge55W -= (int)((float)city.PopulationAge55W * DeathRateJung);
						//city.PopulationAge56M -= (int)((float)city.PopulationAge56M * DeathRateJung);
						//city.PopulationAge56W -= (int)((float)city.PopulationAge56W * DeathRateJung);
						//city.PopulationAge57M -= (int)((float)city.PopulationAge57M * DeathRateJung);
						//city.PopulationAge57W -= (int)((float)city.PopulationAge57W * DeathRateJung);
						//city.PopulationAge58M -= (int)((float)city.PopulationAge58M * DeathRateJung);
						//city.PopulationAge58W -= (int)((float)city.PopulationAge58W * DeathRateJung);
						//city.PopulationAge59M -= (int)((float)city.PopulationAge59M * DeathRateJung);
						//city.PopulationAge59W -= (int)((float)city.PopulationAge59W * DeathRateJung);
						//city.PopulationAge60M -= (int)((float)city.PopulationAge60M * DeathRateJung);
						//city.PopulationAge60W -= (int)((float)city.PopulationAge60W * DeathRateJung);
						//city.PopulationAge61M -= (int)((float)city.PopulationAge61M * DeathRateOld);
						//city.PopulationAge61W -= (int)((float)city.PopulationAge61W * DeathRateOld);
						//city.PopulationAge62M -= (int)((float)city.PopulationAge62M * DeathRateOld);
						//city.PopulationAge62W -= (int)((float)city.PopulationAge62W * DeathRateOld);
						//city.PopulationAge63M -= (int)((float)city.PopulationAge63M * DeathRateOld);
						//city.PopulationAge63W -= (int)((float)city.PopulationAge63W * DeathRateOld);
						//city.PopulationAge64M -= (int)((float)city.PopulationAge64M * DeathRateOld);
						//city.PopulationAge64W -= (int)((float)city.PopulationAge64W * DeathRateOld);
						//city.PopulationAge65M -= (int)((float)city.PopulationAge65M * DeathRateOld);
						//city.PopulationAge65W -= (int)((float)city.PopulationAge65W * DeathRateOld);
						//city.PopulationAge66M -= (int)((float)city.PopulationAge66M * DeathRateOld);
						//city.PopulationAge66W -= (int)((float)city.PopulationAge66W * DeathRateOld);
						//city.PopulationAge67M -= (int)((float)city.PopulationAge67M * DeathRateOld);
						//city.PopulationAge67W -= (int)((float)city.PopulationAge67W * DeathRateOld);
						//city.PopulationAge68M -= (int)((float)city.PopulationAge68M * DeathRateOld);
						//city.PopulationAge68W -= (int)((float)city.PopulationAge68W * DeathRateOld);
						//city.PopulationAge69M -= (int)((float)city.PopulationAge69M * DeathRateOld);
						//city.PopulationAge69W -= (int)((float)city.PopulationAge69W * DeathRateOld);
						//city.PopulationAge70M -= (int)((float)city.PopulationAge70M * DeathRateOld);
						//city.PopulationAge70W -= (int)((float)city.PopulationAge70W * DeathRateOld);
						
						city.PopulationAge70M = city.PopulationAge69M;
						city.PopulationAge70W = city.PopulationAge69W;
						city.PopulationAge69M = city.PopulationAge68M;
						city.PopulationAge69W = city.PopulationAge68W;
						city.PopulationAge68M = city.PopulationAge67M;
						city.PopulationAge68W = city.PopulationAge67W;
						city.PopulationAge67M = city.PopulationAge66M;
						city.PopulationAge67W = city.PopulationAge66W;
						city.PopulationAge66M = city.PopulationAge65M;
						city.PopulationAge66W = city.PopulationAge65W;
						city.PopulationAge65M = city.PopulationAge64M;
						city.PopulationAge65W = city.PopulationAge64W;
						city.PopulationAge64M = city.PopulationAge63M;
						city.PopulationAge64W = city.PopulationAge63W;
						city.PopulationAge63M = city.PopulationAge62M;
						city.PopulationAge63W = city.PopulationAge62W;
						city.PopulationAge62M = city.PopulationAge61M;
						city.PopulationAge62W = city.PopulationAge61W;
						city.PopulationAge61M = city.PopulationAge60M;
						city.PopulationAge61W = city.PopulationAge60W;
						city.PopulationAge60M = city.PopulationAge59M;
						city.PopulationAge60W = city.PopulationAge59W;
						city.PopulationAge59M = city.PopulationAge58M;
						city.PopulationAge59W = city.PopulationAge58W;
						city.PopulationAge58M = city.PopulationAge57M;
						city.PopulationAge58W = city.PopulationAge57W;
						city.PopulationAge57M = city.PopulationAge56M;
						city.PopulationAge57W = city.PopulationAge56W;
						city.PopulationAge56M = city.PopulationAge55M;
						city.PopulationAge56W = city.PopulationAge55W;
						city.PopulationAge55M = city.PopulationAge54M;
						city.PopulationAge55W = city.PopulationAge54W;
						city.PopulationAge54M = city.PopulationAge53M;
						city.PopulationAge54W = city.PopulationAge53W;
						city.PopulationAge53M = city.PopulationAge52M;
						city.PopulationAge53W = city.PopulationAge52W;
						city.PopulationAge52M = city.PopulationAge51M;
						city.PopulationAge52W = city.PopulationAge51W;
						city.PopulationAge51M = city.PopulationAge50M;
						city.PopulationAge51W = city.PopulationAge50W;
						city.PopulationAge50M = city.PopulationAge49M;
						city.PopulationAge50W = city.PopulationAge49W;
						city.PopulationAge49M = city.PopulationAge48M;
						city.PopulationAge49W = city.PopulationAge48W;
						city.PopulationAge48M = city.PopulationAge47M;
						city.PopulationAge48W = city.PopulationAge47W;
						city.PopulationAge47M = city.PopulationAge46M;
						city.PopulationAge47W = city.PopulationAge46W;
						city.PopulationAge46M = city.PopulationAge45M;
						city.PopulationAge46W = city.PopulationAge45W;
						city.PopulationAge45M = city.PopulationAge44M;
						city.PopulationAge45W = city.PopulationAge44W;
						city.PopulationAge44M = city.PopulationAge43M;
						city.PopulationAge44W = city.PopulationAge43W;
						city.PopulationAge43M = city.PopulationAge42M;
						city.PopulationAge43W = city.PopulationAge42W;
						city.PopulationAge42M = city.PopulationAge41M;
						city.PopulationAge42W = city.PopulationAge41W;
						city.PopulationAge41M = city.PopulationAge40M;
						city.PopulationAge41W = city.PopulationAge40W;
						city.PopulationAge40M = city.PopulationAge39M;
						city.PopulationAge40W = city.PopulationAge39W;
						city.PopulationAge39M = city.PopulationAge38M;
						city.PopulationAge39W = city.PopulationAge38W;
						city.PopulationAge38M = city.PopulationAge37M;
						city.PopulationAge38W = city.PopulationAge37W;
						city.PopulationAge37M = city.PopulationAge36M;
						city.PopulationAge37W = city.PopulationAge36W;
						city.PopulationAge36M = city.PopulationAge35M;
						city.PopulationAge36W = city.PopulationAge35W;
						city.PopulationAge35M = city.PopulationAge34M;
						city.PopulationAge35W = city.PopulationAge34W;
						city.PopulationAge34M = city.PopulationAge33M;
						city.PopulationAge34W = city.PopulationAge33W;
						city.PopulationAge33M = city.PopulationAge32M;
						city.PopulationAge33W = city.PopulationAge32W;
						city.PopulationAge32M = city.PopulationAge31M;
						city.PopulationAge32W = city.PopulationAge31W;
						city.PopulationAge31M = city.PopulationAge30M;
						city.PopulationAge31W = city.PopulationAge30W;
						city.PopulationAge30M = city.PopulationAge29M;
						city.PopulationAge30W = city.PopulationAge29W;
						city.PopulationAge29M = city.PopulationAge28M;
						city.PopulationAge29W = city.PopulationAge28W;
						city.PopulationAge28M = city.PopulationAge27M;
						city.PopulationAge28W = city.PopulationAge27W;
						city.PopulationAge27M = city.PopulationAge26M;
						city.PopulationAge27W = city.PopulationAge26W;
						city.PopulationAge26M = city.PopulationAge25M;
						city.PopulationAge26W = city.PopulationAge25W;
						city.PopulationAge25M = city.PopulationAge24M;
						city.PopulationAge25W = city.PopulationAge24W;
						city.PopulationAge24M = city.PopulationAge23M;
						city.PopulationAge24W = city.PopulationAge23W;
						city.PopulationAge23M = city.PopulationAge22M;
						city.PopulationAge23W = city.PopulationAge22W;
						city.PopulationAge22M = city.PopulationAge21M;
						city.PopulationAge22W = city.PopulationAge21W;
						city.PopulationAge21M = city.PopulationAge20M;
						city.PopulationAge21W = city.PopulationAge20W;
						city.PopulationAge20M = city.PopulationAge19M;
						city.PopulationAge20W = city.PopulationAge19W;
						city.PopulationAge19M = city.PopulationAge18M;
						city.PopulationAge19W = city.PopulationAge18W;
						city.PopulationAge18M = city.PopulationAge17M;
						city.PopulationAge18W = city.PopulationAge17W;
						city.PopulationAge17M = city.PopulationAge16M;
						city.PopulationAge17W = city.PopulationAge16W;
						city.PopulationAge16M = city.PopulationAge15M;
						city.PopulationAge16W = city.PopulationAge15W;
						city.PopulationAge15M = city.PopulationAge14M;
						city.PopulationAge15W = city.PopulationAge14W;
						city.PopulationAge14M = city.PopulationAge13M;
						city.PopulationAge14W = city.PopulationAge13W;
						city.PopulationAge13M = city.PopulationAge12M;
						city.PopulationAge13W = city.PopulationAge12W;
						city.PopulationAge12M = city.PopulationAge11M;
						city.PopulationAge12W = city.PopulationAge11W;
						city.PopulationAge11M = city.PopulationAge10M;
						city.PopulationAge11W = city.PopulationAge10W;
						city.PopulationAge10M = city.PopulationAge9M;
						city.PopulationAge10W = city.PopulationAge9W;
						city.PopulationAge9M = city.PopulationAge8M;
						city.PopulationAge9W = city.PopulationAge8W;
						city.PopulationAge8M = city.PopulationAge7M;
						city.PopulationAge8W = city.PopulationAge7W;
						city.PopulationAge7M = city.PopulationAge6M;
						city.PopulationAge7W = city.PopulationAge6W;
						city.PopulationAge6M = city.PopulationAge5M;
						city.PopulationAge6W = city.PopulationAge5W;
						city.PopulationAge5M = city.PopulationAge4M;
						city.PopulationAge5W = city.PopulationAge4W;
						city.PopulationAge4M = city.PopulationAge3M;
						city.PopulationAge4W = city.PopulationAge3W;
						city.PopulationAge3M = city.PopulationAge2M;
						city.PopulationAge3W = city.PopulationAge2W;
						city.PopulationAge2M = city.PopulationAge1M;
						city.PopulationAge2W = city.PopulationAge1W;
						city.PopulationAge1M = city.PopulationAge0M;
						city.PopulationAge1W = city.PopulationAge0W;
						city.PopulationAge0M = (int)((float)newChild / 2f);
						city.PopulationAge0W = (int)((float)newChild / 2f);

						city.Population = city.PopulationAge0M + city.PopulationAge0W + city.PopulationAge1M + city.PopulationAge1W + city.PopulationAge2M + city.PopulationAge2W +
						city.PopulationAge3M + city.PopulationAge3W +
						city.PopulationAge4M + city.PopulationAge4W +
						city.PopulationAge5M + city.PopulationAge5W +
						city.PopulationAge6M + city.PopulationAge6W +
						city.PopulationAge7M + city.PopulationAge7W +
						city.PopulationAge8M + city.PopulationAge8W +
						city.PopulationAge9M + city.PopulationAge9W +
						city.PopulationAge10M + city.PopulationAge10W +
						city.PopulationAge11M + city.PopulationAge11W +
						city.PopulationAge12M + city.PopulationAge12W +
						city.PopulationAge13M + city.PopulationAge13W +
						city.PopulationAge14M + city.PopulationAge14W +
						city.PopulationAge15M + city.PopulationAge15W +
						city.PopulationAge16M + city.PopulationAge16W +
						city.PopulationAge17M + city.PopulationAge17W +
						city.PopulationAge18M + city.PopulationAge18W +
						city.PopulationAge19M + city.PopulationAge19W +
						city.PopulationAge20M + city.PopulationAge20W +
						city.PopulationAge21M + city.PopulationAge21W +
						city.PopulationAge22M + city.PopulationAge22W +
						city.PopulationAge23M + city.PopulationAge23W +
						city.PopulationAge24M + city.PopulationAge24W +
						city.PopulationAge25M + city.PopulationAge25W +
						city.PopulationAge26M + city.PopulationAge26W +
						city.PopulationAge27M + city.PopulationAge27W +
						city.PopulationAge28M + city.PopulationAge28W +
						city.PopulationAge29M + city.PopulationAge29W +
						city.PopulationAge30M + city.PopulationAge30W +
						city.PopulationAge31M + city.PopulationAge31W +
						city.PopulationAge32M + city.PopulationAge32W +
						city.PopulationAge33M + city.PopulationAge33W +
						city.PopulationAge34M + city.PopulationAge34W +
						city.PopulationAge35M + city.PopulationAge35W +
						city.PopulationAge36M + city.PopulationAge36W +
						city.PopulationAge37M + city.PopulationAge37W +
						city.PopulationAge38M + city.PopulationAge38W +
						city.PopulationAge39M + city.PopulationAge39W +
						city.PopulationAge40M + city.PopulationAge40W +
						city.PopulationAge41M + city.PopulationAge41W +
						city.PopulationAge42M + city.PopulationAge42W +
						city.PopulationAge43M + city.PopulationAge43W +
						city.PopulationAge44M + city.PopulationAge44W +
						city.PopulationAge45M + city.PopulationAge45W +
						city.PopulationAge46M + city.PopulationAge46W +
						city.PopulationAge47M + city.PopulationAge47W +
						city.PopulationAge48M + city.PopulationAge48W +
						city.PopulationAge49M + city.PopulationAge49W +
						city.PopulationAge50M + city.PopulationAge50W +
						city.PopulationAge51M + city.PopulationAge51W +
						city.PopulationAge52M + city.PopulationAge52W +
						city.PopulationAge53M + city.PopulationAge53W +
						city.PopulationAge54M + city.PopulationAge54W +
						city.PopulationAge55M + city.PopulationAge55W +
						city.PopulationAge56M + city.PopulationAge56W +
						city.PopulationAge57M + city.PopulationAge57W +
						city.PopulationAge58M + city.PopulationAge58W +
						city.PopulationAge59M + city.PopulationAge59W +
						city.PopulationAge60M + city.PopulationAge60W +
						city.PopulationAge61M + city.PopulationAge61W +
						city.PopulationAge62M + city.PopulationAge62W +
						city.PopulationAge63M + city.PopulationAge63W +
						city.PopulationAge64M + city.PopulationAge64W +
						city.PopulationAge65M + city.PopulationAge65W +
						city.PopulationAge66M + city.PopulationAge66W +
						city.PopulationAge67M + city.PopulationAge67W +
						city.PopulationAge68M + city.PopulationAge68W +
						city.PopulationAge69M + city.PopulationAge69W +
						city.PopulationAge70M + city.PopulationAge70W;
						
						city.PopulationWorkable = city.PopulationAge18M +
						city.PopulationAge19M +
						city.PopulationAge20M +
						city.PopulationAge21M +
						city.PopulationAge22M +
						city.PopulationAge23M +
						city.PopulationAge24M +
						city.PopulationAge25M +
						city.PopulationAge26M +
						city.PopulationAge27M +
						city.PopulationAge28M +
						city.PopulationAge29M +
						city.PopulationAge30M +
						city.PopulationAge31M +
						city.PopulationAge32M +
						city.PopulationAge33M +
						city.PopulationAge34M +
						city.PopulationAge35M +
						city.PopulationAge36M +
						city.PopulationAge37M +
						city.PopulationAge38M +
						city.PopulationAge39M +
						city.PopulationAge40M +
						city.PopulationAge41M +
						city.PopulationAge42M +
						city.PopulationAge43M +
						city.PopulationAge44M +
						city.PopulationAge45M;
					  
						if(city.PopulationWorkable <= 500)
						{
							city.PopulationMaxAP = 1;
							city.PopulationAP = city.PopulationMaxAP;
						}
						else if(city.PopulationWorkable <= 750 && city.PopulationWorkable > 500)
						{
							city.PopulationMaxAP = 2;
							city.PopulationAP = city.PopulationMaxAP;
						}
						else if(city.PopulationWorkable <= 1000 && city.PopulationWorkable > 750)
						{
							city.PopulationMaxAP = 3;
							city.PopulationAP = city.PopulationMaxAP;
						}
						else if(city.PopulationWorkable > 1000)
						{
							city.PopulationMaxAP = 4;
							city.PopulationAP = city.PopulationMaxAP;
						}
					}
				}
				SmallCity smallCity = GetSmallCityUnderMouse();
				if(smallCity != null)
				{
					SelectedCityInfo selectedCityInfo = smallCity.ThisCity.GetComponent<SelectedCityInfo>();
					if (smallCity.isSelected && selectedCityInfo.infoPanel)
					{
						selectedCityInfo.cityPopulationText.text = "";
						selectedCityInfo.ActivateCityInfoPanelManually(smallCity);
					}
					else 
					{
						CityHoverInfo cityHoverInfo = smallCity.ThisCity.GetComponent<CityHoverInfo>();
						cityHoverInfo.cityPopulationText.text = "";
						cityHoverInfo.CityInfoActivate();
					}
				}
				else if (citySelectedData.smallCity != null)
				{
					SelectedCityInfo selectedCityInfo = citySelectedData.smallCity.ThisCity.GetComponent<SelectedCityInfo>();
					selectedCityInfo.ActivateCityInfoPanelManually(citySelectedData.smallCity);
				}
				
				
				if(player2Script.aIControlled != null)
				{
					NotYourTurn.SetActive(true);
					player2Script.aIControlled.AITurn();
				}
			}
			else if (ownerPlayerID == 3)
			{
				resetOwnerPlayerID.ResetIDs();
				markTilesInRadius.MarkTiles();
				borderLineManager.CreateBorderLines();
				if ( player4Script == null)
				{
					ownerPlayerID = 1;
					turnCounter.NextTurn();
				}
				else
				{
					ownerPlayerID = 4;
					turnCounter.NextPlayer();
				}
				turnCounter.NextPlayer();
				
				SmallCity[] cities2 = FindObjectsOfType<SmallCity>();

				// Находим все персонажи в сцене
				CharacterData[] characters = FindObjectsOfType<CharacterData>();
				Forge[] forges = FindObjectsOfType<Forge>();
				MashineFactory[] mashineFactorys = FindObjectsOfType<MashineFactory>();
				foreach (Forge forge in forges)
				{
					if(forge.ownerPlayerID == ownerPlayerID)
					{
						if(forge.Population >= 100 && forge.Population < 200)
						{
							forge.PopulationMaxAP = 1;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 200 && forge.Population < 300)
						{
							forge.PopulationMaxAP = 2;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 300 && forge.Population < 400)
						{
							forge.PopulationMaxAP = 3;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 400 && forge.Population < 500)
						{
							forge.PopulationMaxAP = 4;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 500 && forge.Population < 600)
						{
							forge.PopulationMaxAP = 5;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 600 && forge.Population < 700)
						{
							forge.PopulationMaxAP = 6;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 700 && forge.Population < 800)
						{
							forge.PopulationMaxAP = 7;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 800 && forge.Population < 900)
						{
							forge.PopulationMaxAP = 8;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 900 && forge.Population < 1000)
						{
							forge.PopulationMaxAP = 9;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 1000)
						{
							forge.PopulationMaxAP = 10;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
					}
				}
				foreach (MashineFactory mashineFactory in mashineFactorys)
				{
					if(mashineFactory.ownerPlayerID == ownerPlayerID)
					{
						if(mashineFactory.Population >= 100 && mashineFactory.Population < 200)
						{
							mashineFactory.PopulationMaxAP = 1;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 200 && mashineFactory.Population < 300)
						{
							mashineFactory.PopulationMaxAP = 2;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 300 && mashineFactory.Population < 400)
						{
							mashineFactory.PopulationMaxAP = 3;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 400 && mashineFactory.Population < 500)
						{
							mashineFactory.PopulationMaxAP = 4;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 500 && mashineFactory.Population < 600)
						{
							mashineFactory.PopulationMaxAP = 5;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 600 && mashineFactory.Population < 700)
						{
							mashineFactory.PopulationMaxAP = 6;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 700 && mashineFactory.Population < 800)
						{
							mashineFactory.PopulationMaxAP = 7;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 800 && mashineFactory.Population < 900)
						{
							mashineFactory.PopulationMaxAP = 8;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 900 && mashineFactory.Population < 1000)
						{
							mashineFactory.PopulationMaxAP = 9;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 1000)
						{
							mashineFactory.PopulationMaxAP = 10;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						
					}
				}
				foreach (CharacterData character in characters)
				{
					if(character.ownerPlayerID == ownerPlayerID)
					{
						character.usableMP = character.maxMP;
						character.usableAP = character.maxAP;
						if(character.health < character.maxhealth)
						{
							character.health++;
						}
						if(character.aIDefendDrone == null)
						{
							character.WeaponSlotChanges = 0;
							character.AmmoSlotChanges = 0;
							character.HelmetSlotChanges = 0;
							character.VestSlotChanges = 0;
							character.ShirtSlotChanges = 0;
							character.isSelected = false;
							CharacterHoverInfo characterHoverInfo = character.thisCharacter.GetComponent<CharacterHoverInfo>();
							characterHoverInfo.UpdateHoverInfo();
						}
						
						if(character.transformTo >= 1)
						{
							character.transformTo--;
							if(character.transformTo == 0)
							{
								character.characterType = "Regular";
								character.spritePath = "Sprites/Units/Regular";
								character.maxhealth = +10;
								character.health++;
								character.usableMP++;
								character.maxMP++;
								character.UpdateSprite();
							}
						}
					}
				}
				
				Farm[] farms = FindObjectsOfType<Farm>();
				foreach (Farm farm in farms)
				{
					if(farm.ownerPlayerID == ownerPlayerID)
					{
						if(farm.CurrentFarm == "Flax")
						{
							farm.FlaxCount++;
							farm.cellData.Flax = farm.FlaxCount;
						}
						if(farm.CurrentFarm == "Tomato")
						{
							farm.TomatoCount++;
						}
						if(farm.CurrentFarm == "Carrot")
						{
							farm.CarrotCount++;
						}
						if(farm.CurrentFarm == "Grain")
						{
							farm.GrainCount++;
						}
					}
				}

				foreach (SmallCity city in cities2)
				{
					if (city.ownerPlayerID == ownerPlayerID)
					{
						if(city.playerScript.aIControlled == null)
						{
							Camera.main.transform.position = new Vector3(city.transform.position.x, city.transform.position.y, -10);
						}
						if (city.MobilizationInProgress)
						{
							if (city.cityInventory != null && city.cityInventory.GetFreeCharacterObjectIndex() != -1)
							{
								cityManager.MobilizeCity(city.cityID);
							}
						}
						if(city.ResearchPanelIsActive)
						{
							technologyImplementer.ImplementTechnolohy(city);
						}
					}
				}
				// Проходимся по всем городам и увеличиваем их население
				foreach (SmallCity city in cities2)
				{
					if (city.ownerPlayerID == ownerPlayerID)
					{
						int PossibleToHaveChild = city.PopulationAge18M + city.PopulationAge18W +
						city.PopulationAge19M + city.PopulationAge19W +
						city.PopulationAge20M + city.PopulationAge20W +
						city.PopulationAge21M + city.PopulationAge21W +
						city.PopulationAge22M + city.PopulationAge22W +
						city.PopulationAge23M + city.PopulationAge23W +
						city.PopulationAge24M + city.PopulationAge24W +
						city.PopulationAge25M + city.PopulationAge25W +
						city.PopulationAge26M + city.PopulationAge26W +
						city.PopulationAge27M + city.PopulationAge27W +
						city.PopulationAge28M + city.PopulationAge28W +
						city.PopulationAge29M + city.PopulationAge29W +
						city.PopulationAge30M + city.PopulationAge30W +
						city.PopulationAge31M + city.PopulationAge31W +
						city.PopulationAge32M + city.PopulationAge32W +
						city.PopulationAge33M + city.PopulationAge33W +
						city.PopulationAge34M + city.PopulationAge34W +
						city.PopulationAge35M + city.PopulationAge35W +
						city.PopulationAge36M + city.PopulationAge36W +
						city.PopulationAge37M + city.PopulationAge37W +
						city.PopulationAge38M + city.PopulationAge38W +
						city.PopulationAge39M + city.PopulationAge39W +
						city.PopulationAge40M + city.PopulationAge40W +
						city.PopulationAge41M + city.PopulationAge41W +
						city.PopulationAge42M + city.PopulationAge42W +
						city.PopulationAge43M + city.PopulationAge43W +
						city.PopulationAge44M + city.PopulationAge44W +
						city.PopulationAge45M + city.PopulationAge45W;
						
						int newChild = (int)((float)PossibleToHaveChild * Random.Range(city.minBirthRateJung, city.maxBirthRateJung)); 
						//float maxDeathRateJung1 = city.maxDeathRateJung++;
						//float maxDeathRateOld1 = city.maxDeathRateOld++;
						//float DeathRateJung = Random.Range(city.minDeathRateJung, city.maxDeathRateJung); 
						//float DeathRateOld = Random.Range(city.minDeathRateOld, city.maxDeathRateOld); 
						//city.PopulationAge1M -= (int)((float)city.PopulationAge1M * DeathRateJung);
						//city.PopulationAge1W -= (int)((float)city.PopulationAge1W * DeathRateJung);
						//city.PopulationAge2M -= (int)((float)city.PopulationAge2M * DeathRateJung);
						//city.PopulationAge2W -= (int)((float)city.PopulationAge2W * DeathRateJung);
						//city.PopulationAge3M -= (int)((float)city.PopulationAge3M * DeathRateJung);
						//city.PopulationAge3W -= (int)((float)city.PopulationAge3W * DeathRateJung);
						//city.PopulationAge4M -= (int)((float)city.PopulationAge4M * DeathRateJung);
						//city.PopulationAge4W -= (int)((float)city.PopulationAge4W * DeathRateJung);
						//city.PopulationAge5M -= (int)((float)city.PopulationAge5M * DeathRateJung);
						//city.PopulationAge5W -= (int)((float)city.PopulationAge5W * DeathRateJung);
						//city.PopulationAge6M -= (int)((float)city.PopulationAge6M * DeathRateJung);
						//city.PopulationAge6W -= (int)((float)city.PopulationAge6W * DeathRateJung);
						//city.PopulationAge7M -= (int)((float)city.PopulationAge7M * DeathRateJung);
						//city.PopulationAge7W -= (int)((float)city.PopulationAge7W * DeathRateJung);
						//city.PopulationAge8M -= (int)((float)city.PopulationAge8M * DeathRateJung);
						//city.PopulationAge8W -= (int)((float)city.PopulationAge8W * DeathRateJung);
						//city.PopulationAge9M -= (int)((float)city.PopulationAge9M * DeathRateJung);
						//city.PopulationAge9W -= (int)((float)city.PopulationAge9W * DeathRateJung);
						//city.PopulationAge10M -= (int)((float)city.PopulationAge10M * DeathRateJung);
						//city.PopulationAge10W -= (int)((float)city.PopulationAge10W * DeathRateJung);
						//city.PopulationAge11M -= (int)((float)city.PopulationAge11M * DeathRateJung);
						//city.PopulationAge11W -= (int)((float)city.PopulationAge11W * DeathRateJung);
						//city.PopulationAge12M -= (int)((float)city.PopulationAge12M * DeathRateJung);
						//city.PopulationAge12W -= (int)((float)city.PopulationAge12W * DeathRateJung);
						//city.PopulationAge13M -= (int)((float)city.PopulationAge13M * DeathRateJung);
						//city.PopulationAge13W -= (int)((float)city.PopulationAge13W * DeathRateJung);
						//city.PopulationAge14M -= (int)((float)city.PopulationAge14M * DeathRateJung);
						//city.PopulationAge14W -= (int)((float)city.PopulationAge14W * DeathRateJung);
						//city.PopulationAge15M -= (int)((float)city.PopulationAge15M * DeathRateJung);
						//city.PopulationAge15W -= (int)((float)city.PopulationAge15W * DeathRateJung);
						//city.PopulationAge16M -= (int)((float)city.PopulationAge16M * DeathRateJung);
						//city.PopulationAge16W -= (int)((float)city.PopulationAge16W * DeathRateJung);
						//city.PopulationAge17M -= (int)((float)city.PopulationAge17M * DeathRateJung);
						//city.PopulationAge17W -= (int)((float)city.PopulationAge17W * DeathRateJung);
						//city.PopulationAge18M -= (int)((float)city.PopulationAge18M * DeathRateJung);
						//city.PopulationAge18W -= (int)((float)city.PopulationAge18W * DeathRateJung);
						//city.PopulationAge19M -= (int)((float)city.PopulationAge19M * DeathRateJung);
						//city.PopulationAge19W -= (int)((float)city.PopulationAge19W * DeathRateJung);
						//city.PopulationAge20M -= (int)((float)city.PopulationAge20M * DeathRateJung);
						//city.PopulationAge20W -= (int)((float)city.PopulationAge20W * DeathRateJung);
						//city.PopulationAge21M -= (int)((float)city.PopulationAge21M * DeathRateJung);
						//city.PopulationAge21W -= (int)((float)city.PopulationAge21W * DeathRateJung);
						//city.PopulationAge22M -= (int)((float)city.PopulationAge22M * DeathRateJung);
						//city.PopulationAge22W -= (int)((float)city.PopulationAge22W * DeathRateJung);
						//city.PopulationAge23M -= (int)((float)city.PopulationAge23M * DeathRateJung);
						//city.PopulationAge23W -= (int)((float)city.PopulationAge23W * DeathRateJung);
						//city.PopulationAge24M -= (int)((float)city.PopulationAge24M * DeathRateJung);
						//city.PopulationAge24W -= (int)((float)city.PopulationAge24W * DeathRateJung);
						//city.PopulationAge25M -= (int)((float)city.PopulationAge25M * DeathRateJung);
						//city.PopulationAge25W -= (int)((float)city.PopulationAge25W * DeathRateJung);
						//city.PopulationAge26M -= (int)((float)city.PopulationAge26M * DeathRateJung);
						//city.PopulationAge26W -= (int)((float)city.PopulationAge26W * DeathRateJung);
						//city.PopulationAge27M -= (int)((float)city.PopulationAge27M * DeathRateJung);
						//city.PopulationAge27W -= (int)((float)city.PopulationAge27W * DeathRateJung);
						//city.PopulationAge28M -= (int)((float)city.PopulationAge28M * DeathRateJung);
						//city.PopulationAge28W -= (int)((float)city.PopulationAge28W * DeathRateJung);
						//city.PopulationAge29M -= (int)((float)city.PopulationAge29M * DeathRateJung);
						//city.PopulationAge29W -= (int)((float)city.PopulationAge29W * DeathRateJung);
						//city.PopulationAge30M -= (int)((float)city.PopulationAge30M * DeathRateJung);
						//city.PopulationAge30W -= (int)((float)city.PopulationAge30W * DeathRateJung);
						//city.PopulationAge31M -= (int)((float)city.PopulationAge31M * DeathRateJung);
						//city.PopulationAge31W -= (int)((float)city.PopulationAge31W * DeathRateJung);
						//city.PopulationAge32M -= (int)((float)city.PopulationAge32M * DeathRateJung);
						//city.PopulationAge32W -= (int)((float)city.PopulationAge32W * DeathRateJung);
						//city.PopulationAge33M -= (int)((float)city.PopulationAge33M * DeathRateJung);
						//city.PopulationAge33W -= (int)((float)city.PopulationAge33W * DeathRateJung);
						//city.PopulationAge34M -= (int)((float)city.PopulationAge34M * DeathRateJung);
						//city.PopulationAge34W -= (int)((float)city.PopulationAge34W * DeathRateJung);
						//city.PopulationAge35M -= (int)((float)city.PopulationAge35M * DeathRateJung);
						//city.PopulationAge35W -= (int)((float)city.PopulationAge35W * DeathRateJung);
						//city.PopulationAge36M -= (int)((float)city.PopulationAge36M * DeathRateJung);
						//city.PopulationAge36W -= (int)((float)city.PopulationAge36W * DeathRateJung);
						//city.PopulationAge37M -= (int)((float)city.PopulationAge37M * DeathRateJung);
						//city.PopulationAge37W -= (int)((float)city.PopulationAge37W * DeathRateJung);
						//city.PopulationAge38M -= (int)((float)city.PopulationAge38M * DeathRateJung);
						//city.PopulationAge38W -= (int)((float)city.PopulationAge38W * DeathRateJung);
						//city.PopulationAge39M -= (int)((float)city.PopulationAge39M * DeathRateJung);
						//city.PopulationAge39W -= (int)((float)city.PopulationAge39W * DeathRateJung);
						//city.PopulationAge40M -= (int)((float)city.PopulationAge40M * DeathRateJung);
						//city.PopulationAge40W -= (int)((float)city.PopulationAge40W * DeathRateJung);
						//city.PopulationAge41M -= (int)((float)city.PopulationAge41M * DeathRateJung);
						//city.PopulationAge41W -= (int)((float)city.PopulationAge41W * DeathRateJung);
						//city.PopulationAge42M -= (int)((float)city.PopulationAge42M * DeathRateJung);
						//city.PopulationAge42W -= (int)((float)city.PopulationAge42W * DeathRateJung);
						//city.PopulationAge43M -= (int)((float)city.PopulationAge43M * DeathRateJung);
						//city.PopulationAge43W -= (int)((float)city.PopulationAge43W * DeathRateJung);
						//city.PopulationAge44M -= (int)((float)city.PopulationAge44M * DeathRateJung);
						//city.PopulationAge44W -= (int)((float)city.PopulationAge44W * DeathRateJung);
						//city.PopulationAge45M -= (int)((float)city.PopulationAge45M * DeathRateJung);
						//city.PopulationAge45W -= (int)((float)city.PopulationAge45W * DeathRateJung);
						//city.PopulationAge46M -= (int)((float)city.PopulationAge46M * DeathRateJung);
						//city.PopulationAge46W -= (int)((float)city.PopulationAge46W * DeathRateJung);
						//city.PopulationAge47M -= (int)((float)city.PopulationAge47M * DeathRateJung);
						//city.PopulationAge47W -= (int)((float)city.PopulationAge47W * DeathRateJung);
						//city.PopulationAge48M -= (int)((float)city.PopulationAge48M * DeathRateJung);
						//city.PopulationAge48W -= (int)((float)city.PopulationAge48W * DeathRateJung);
						//city.PopulationAge49M -= (int)((float)city.PopulationAge49M * DeathRateJung);
						//city.PopulationAge49W -= (int)((float)city.PopulationAge49W * DeathRateJung);
						//city.PopulationAge50M -= (int)((float)city.PopulationAge50M * DeathRateJung);
						//city.PopulationAge50W -= (int)((float)city.PopulationAge50W * DeathRateJung);
						//city.PopulationAge51M -= (int)((float)city.PopulationAge51M * DeathRateJung);
						//city.PopulationAge51W -= (int)((float)city.PopulationAge51W * DeathRateJung);
						//city.PopulationAge52M -= (int)((float)city.PopulationAge52M * DeathRateJung);
						//city.PopulationAge52W -= (int)((float)city.PopulationAge52W * DeathRateJung);
						//city.PopulationAge53M -= (int)((float)city.PopulationAge53M * DeathRateJung);
						//city.PopulationAge53W -= (int)((float)city.PopulationAge53W * DeathRateJung);
						//city.PopulationAge54M -= (int)((float)city.PopulationAge54M * DeathRateJung);
						//city.PopulationAge54W -= (int)((float)city.PopulationAge54W * DeathRateJung);
						//city.PopulationAge55M -= (int)((float)city.PopulationAge55M * DeathRateJung);
						//city.PopulationAge55W -= (int)((float)city.PopulationAge55W * DeathRateJung);
						//city.PopulationAge56M -= (int)((float)city.PopulationAge56M * DeathRateJung);
						//city.PopulationAge56W -= (int)((float)city.PopulationAge56W * DeathRateJung);
						//city.PopulationAge57M -= (int)((float)city.PopulationAge57M * DeathRateJung);
						//city.PopulationAge57W -= (int)((float)city.PopulationAge57W * DeathRateJung);
						//city.PopulationAge58M -= (int)((float)city.PopulationAge58M * DeathRateJung);
						//city.PopulationAge58W -= (int)((float)city.PopulationAge58W * DeathRateJung);
						//city.PopulationAge59M -= (int)((float)city.PopulationAge59M * DeathRateJung);
						//city.PopulationAge59W -= (int)((float)city.PopulationAge59W * DeathRateJung);
						//city.PopulationAge60M -= (int)((float)city.PopulationAge60M * DeathRateJung);
						//city.PopulationAge60W -= (int)((float)city.PopulationAge60W * DeathRateJung);
						//city.PopulationAge61M -= (int)((float)city.PopulationAge61M * DeathRateOld);
						//city.PopulationAge61W -= (int)((float)city.PopulationAge61W * DeathRateOld);
						//city.PopulationAge62M -= (int)((float)city.PopulationAge62M * DeathRateOld);
						//city.PopulationAge62W -= (int)((float)city.PopulationAge62W * DeathRateOld);
						//city.PopulationAge63M -= (int)((float)city.PopulationAge63M * DeathRateOld);
						//city.PopulationAge63W -= (int)((float)city.PopulationAge63W * DeathRateOld);
						//city.PopulationAge64M -= (int)((float)city.PopulationAge64M * DeathRateOld);
						//city.PopulationAge64W -= (int)((float)city.PopulationAge64W * DeathRateOld);
						//city.PopulationAge65M -= (int)((float)city.PopulationAge65M * DeathRateOld);
						//city.PopulationAge65W -= (int)((float)city.PopulationAge65W * DeathRateOld);
						//city.PopulationAge66M -= (int)((float)city.PopulationAge66M * DeathRateOld);
						//city.PopulationAge66W -= (int)((float)city.PopulationAge66W * DeathRateOld);
						//city.PopulationAge67M -= (int)((float)city.PopulationAge67M * DeathRateOld);
						//city.PopulationAge67W -= (int)((float)city.PopulationAge67W * DeathRateOld);
						//city.PopulationAge68M -= (int)((float)city.PopulationAge68M * DeathRateOld);
						//city.PopulationAge68W -= (int)((float)city.PopulationAge68W * DeathRateOld);
						//city.PopulationAge69M -= (int)((float)city.PopulationAge69M * DeathRateOld);
						//city.PopulationAge69W -= (int)((float)city.PopulationAge69W * DeathRateOld);
						//city.PopulationAge70M -= (int)((float)city.PopulationAge70M * DeathRateOld);
						//city.PopulationAge70W -= (int)((float)city.PopulationAge70W * DeathRateOld);
						
						city.PopulationAge70M = city.PopulationAge69M;
						city.PopulationAge70W = city.PopulationAge69W;
						city.PopulationAge69M = city.PopulationAge68M;
						city.PopulationAge69W = city.PopulationAge68W;
						city.PopulationAge68M = city.PopulationAge67M;
						city.PopulationAge68W = city.PopulationAge67W;
						city.PopulationAge67M = city.PopulationAge66M;
						city.PopulationAge67W = city.PopulationAge66W;
						city.PopulationAge66M = city.PopulationAge65M;
						city.PopulationAge66W = city.PopulationAge65W;
						city.PopulationAge65M = city.PopulationAge64M;
						city.PopulationAge65W = city.PopulationAge64W;
						city.PopulationAge64M = city.PopulationAge63M;
						city.PopulationAge64W = city.PopulationAge63W;
						city.PopulationAge63M = city.PopulationAge62M;
						city.PopulationAge63W = city.PopulationAge62W;
						city.PopulationAge62M = city.PopulationAge61M;
						city.PopulationAge62W = city.PopulationAge61W;
						city.PopulationAge61M = city.PopulationAge60M;
						city.PopulationAge61W = city.PopulationAge60W;
						city.PopulationAge60M = city.PopulationAge59M;
						city.PopulationAge60W = city.PopulationAge59W;
						city.PopulationAge59M = city.PopulationAge58M;
						city.PopulationAge59W = city.PopulationAge58W;
						city.PopulationAge58M = city.PopulationAge57M;
						city.PopulationAge58W = city.PopulationAge57W;
						city.PopulationAge57M = city.PopulationAge56M;
						city.PopulationAge57W = city.PopulationAge56W;
						city.PopulationAge56M = city.PopulationAge55M;
						city.PopulationAge56W = city.PopulationAge55W;
						city.PopulationAge55M = city.PopulationAge54M;
						city.PopulationAge55W = city.PopulationAge54W;
						city.PopulationAge54M = city.PopulationAge53M;
						city.PopulationAge54W = city.PopulationAge53W;
						city.PopulationAge53M = city.PopulationAge52M;
						city.PopulationAge53W = city.PopulationAge52W;
						city.PopulationAge52M = city.PopulationAge51M;
						city.PopulationAge52W = city.PopulationAge51W;
						city.PopulationAge51M = city.PopulationAge50M;
						city.PopulationAge51W = city.PopulationAge50W;
						city.PopulationAge50M = city.PopulationAge49M;
						city.PopulationAge50W = city.PopulationAge49W;
						city.PopulationAge49M = city.PopulationAge48M;
						city.PopulationAge49W = city.PopulationAge48W;
						city.PopulationAge48M = city.PopulationAge47M;
						city.PopulationAge48W = city.PopulationAge47W;
						city.PopulationAge47M = city.PopulationAge46M;
						city.PopulationAge47W = city.PopulationAge46W;
						city.PopulationAge46M = city.PopulationAge45M;
						city.PopulationAge46W = city.PopulationAge45W;
						city.PopulationAge45M = city.PopulationAge44M;
						city.PopulationAge45W = city.PopulationAge44W;
						city.PopulationAge44M = city.PopulationAge43M;
						city.PopulationAge44W = city.PopulationAge43W;
						city.PopulationAge43M = city.PopulationAge42M;
						city.PopulationAge43W = city.PopulationAge42W;
						city.PopulationAge42M = city.PopulationAge41M;
						city.PopulationAge42W = city.PopulationAge41W;
						city.PopulationAge41M = city.PopulationAge40M;
						city.PopulationAge41W = city.PopulationAge40W;
						city.PopulationAge40M = city.PopulationAge39M;
						city.PopulationAge40W = city.PopulationAge39W;
						city.PopulationAge39M = city.PopulationAge38M;
						city.PopulationAge39W = city.PopulationAge38W;
						city.PopulationAge38M = city.PopulationAge37M;
						city.PopulationAge38W = city.PopulationAge37W;
						city.PopulationAge37M = city.PopulationAge36M;
						city.PopulationAge37W = city.PopulationAge36W;
						city.PopulationAge36M = city.PopulationAge35M;
						city.PopulationAge36W = city.PopulationAge35W;
						city.PopulationAge35M = city.PopulationAge34M;
						city.PopulationAge35W = city.PopulationAge34W;
						city.PopulationAge34M = city.PopulationAge33M;
						city.PopulationAge34W = city.PopulationAge33W;
						city.PopulationAge33M = city.PopulationAge32M;
						city.PopulationAge33W = city.PopulationAge32W;
						city.PopulationAge32M = city.PopulationAge31M;
						city.PopulationAge32W = city.PopulationAge31W;
						city.PopulationAge31M = city.PopulationAge30M;
						city.PopulationAge31W = city.PopulationAge30W;
						city.PopulationAge30M = city.PopulationAge29M;
						city.PopulationAge30W = city.PopulationAge29W;
						city.PopulationAge29M = city.PopulationAge28M;
						city.PopulationAge29W = city.PopulationAge28W;
						city.PopulationAge28M = city.PopulationAge27M;
						city.PopulationAge28W = city.PopulationAge27W;
						city.PopulationAge27M = city.PopulationAge26M;
						city.PopulationAge27W = city.PopulationAge26W;
						city.PopulationAge26M = city.PopulationAge25M;
						city.PopulationAge26W = city.PopulationAge25W;
						city.PopulationAge25M = city.PopulationAge24M;
						city.PopulationAge25W = city.PopulationAge24W;
						city.PopulationAge24M = city.PopulationAge23M;
						city.PopulationAge24W = city.PopulationAge23W;
						city.PopulationAge23M = city.PopulationAge22M;
						city.PopulationAge23W = city.PopulationAge22W;
						city.PopulationAge22M = city.PopulationAge21M;
						city.PopulationAge22W = city.PopulationAge21W;
						city.PopulationAge21M = city.PopulationAge20M;
						city.PopulationAge21W = city.PopulationAge20W;
						city.PopulationAge20M = city.PopulationAge19M;
						city.PopulationAge20W = city.PopulationAge19W;
						city.PopulationAge19M = city.PopulationAge18M;
						city.PopulationAge19W = city.PopulationAge18W;
						city.PopulationAge18M = city.PopulationAge17M;
						city.PopulationAge18W = city.PopulationAge17W;
						city.PopulationAge17M = city.PopulationAge16M;
						city.PopulationAge17W = city.PopulationAge16W;
						city.PopulationAge16M = city.PopulationAge15M;
						city.PopulationAge16W = city.PopulationAge15W;
						city.PopulationAge15M = city.PopulationAge14M;
						city.PopulationAge15W = city.PopulationAge14W;
						city.PopulationAge14M = city.PopulationAge13M;
						city.PopulationAge14W = city.PopulationAge13W;
						city.PopulationAge13M = city.PopulationAge12M;
						city.PopulationAge13W = city.PopulationAge12W;
						city.PopulationAge12M = city.PopulationAge11M;
						city.PopulationAge12W = city.PopulationAge11W;
						city.PopulationAge11M = city.PopulationAge10M;
						city.PopulationAge11W = city.PopulationAge10W;
						city.PopulationAge10M = city.PopulationAge9M;
						city.PopulationAge10W = city.PopulationAge9W;
						city.PopulationAge9M = city.PopulationAge8M;
						city.PopulationAge9W = city.PopulationAge8W;
						city.PopulationAge8M = city.PopulationAge7M;
						city.PopulationAge8W = city.PopulationAge7W;
						city.PopulationAge7M = city.PopulationAge6M;
						city.PopulationAge7W = city.PopulationAge6W;
						city.PopulationAge6M = city.PopulationAge5M;
						city.PopulationAge6W = city.PopulationAge5W;
						city.PopulationAge5M = city.PopulationAge4M;
						city.PopulationAge5W = city.PopulationAge4W;
						city.PopulationAge4M = city.PopulationAge3M;
						city.PopulationAge4W = city.PopulationAge3W;
						city.PopulationAge3M = city.PopulationAge2M;
						city.PopulationAge3W = city.PopulationAge2W;
						city.PopulationAge2M = city.PopulationAge1M;
						city.PopulationAge2W = city.PopulationAge1W;
						city.PopulationAge1M = city.PopulationAge0M;
						city.PopulationAge1W = city.PopulationAge0W;
						city.PopulationAge0M = (int)((float)newChild / 2f);
						city.PopulationAge0W = (int)((float)newChild / 2f);

						city.Population = city.PopulationAge0M + city.PopulationAge0W + city.PopulationAge1M + city.PopulationAge1W + city.PopulationAge2M + city.PopulationAge2W +
						city.PopulationAge3M + city.PopulationAge3W +
						city.PopulationAge4M + city.PopulationAge4W +
						city.PopulationAge5M + city.PopulationAge5W +
						city.PopulationAge6M + city.PopulationAge6W +
						city.PopulationAge7M + city.PopulationAge7W +
						city.PopulationAge8M + city.PopulationAge8W +
						city.PopulationAge9M + city.PopulationAge9W +
						city.PopulationAge10M + city.PopulationAge10W +
						city.PopulationAge11M + city.PopulationAge11W +
						city.PopulationAge12M + city.PopulationAge12W +
						city.PopulationAge13M + city.PopulationAge13W +
						city.PopulationAge14M + city.PopulationAge14W +
						city.PopulationAge15M + city.PopulationAge15W +
						city.PopulationAge16M + city.PopulationAge16W +
						city.PopulationAge17M + city.PopulationAge17W +
						city.PopulationAge18M + city.PopulationAge18W +
						city.PopulationAge19M + city.PopulationAge19W +
						city.PopulationAge20M + city.PopulationAge20W +
						city.PopulationAge21M + city.PopulationAge21W +
						city.PopulationAge22M + city.PopulationAge22W +
						city.PopulationAge23M + city.PopulationAge23W +
						city.PopulationAge24M + city.PopulationAge24W +
						city.PopulationAge25M + city.PopulationAge25W +
						city.PopulationAge26M + city.PopulationAge26W +
						city.PopulationAge27M + city.PopulationAge27W +
						city.PopulationAge28M + city.PopulationAge28W +
						city.PopulationAge29M + city.PopulationAge29W +
						city.PopulationAge30M + city.PopulationAge30W +
						city.PopulationAge31M + city.PopulationAge31W +
						city.PopulationAge32M + city.PopulationAge32W +
						city.PopulationAge33M + city.PopulationAge33W +
						city.PopulationAge34M + city.PopulationAge34W +
						city.PopulationAge35M + city.PopulationAge35W +
						city.PopulationAge36M + city.PopulationAge36W +
						city.PopulationAge37M + city.PopulationAge37W +
						city.PopulationAge38M + city.PopulationAge38W +
						city.PopulationAge39M + city.PopulationAge39W +
						city.PopulationAge40M + city.PopulationAge40W +
						city.PopulationAge41M + city.PopulationAge41W +
						city.PopulationAge42M + city.PopulationAge42W +
						city.PopulationAge43M + city.PopulationAge43W +
						city.PopulationAge44M + city.PopulationAge44W +
						city.PopulationAge45M + city.PopulationAge45W +
						city.PopulationAge46M + city.PopulationAge46W +
						city.PopulationAge47M + city.PopulationAge47W +
						city.PopulationAge48M + city.PopulationAge48W +
						city.PopulationAge49M + city.PopulationAge49W +
						city.PopulationAge50M + city.PopulationAge50W +
						city.PopulationAge51M + city.PopulationAge51W +
						city.PopulationAge52M + city.PopulationAge52W +
						city.PopulationAge53M + city.PopulationAge53W +
						city.PopulationAge54M + city.PopulationAge54W +
						city.PopulationAge55M + city.PopulationAge55W +
						city.PopulationAge56M + city.PopulationAge56W +
						city.PopulationAge57M + city.PopulationAge57W +
						city.PopulationAge58M + city.PopulationAge58W +
						city.PopulationAge59M + city.PopulationAge59W +
						city.PopulationAge60M + city.PopulationAge60W +
						city.PopulationAge61M + city.PopulationAge61W +
						city.PopulationAge62M + city.PopulationAge62W +
						city.PopulationAge63M + city.PopulationAge63W +
						city.PopulationAge64M + city.PopulationAge64W +
						city.PopulationAge65M + city.PopulationAge65W +
						city.PopulationAge66M + city.PopulationAge66W +
						city.PopulationAge67M + city.PopulationAge67W +
						city.PopulationAge68M + city.PopulationAge68W +
						city.PopulationAge69M + city.PopulationAge69W +
						city.PopulationAge70M + city.PopulationAge70W;
						
						city.PopulationWorkable = city.PopulationAge18M +
						city.PopulationAge19M +
						city.PopulationAge20M +
						city.PopulationAge21M +
						city.PopulationAge22M +
						city.PopulationAge23M +
						city.PopulationAge24M +
						city.PopulationAge25M +
						city.PopulationAge26M +
						city.PopulationAge27M +
						city.PopulationAge28M +
						city.PopulationAge29M +
						city.PopulationAge30M +
						city.PopulationAge31M +
						city.PopulationAge32M +
						city.PopulationAge33M +
						city.PopulationAge34M +
						city.PopulationAge35M +
						city.PopulationAge36M +
						city.PopulationAge37M +
						city.PopulationAge38M +
						city.PopulationAge39M +
						city.PopulationAge40M +
						city.PopulationAge41M +
						city.PopulationAge42M +
						city.PopulationAge43M +
						city.PopulationAge44M +
						city.PopulationAge45M;
					  
						if(city.PopulationWorkable <= 500)
						{
							city.PopulationMaxAP = 1;
							city.PopulationAP = city.PopulationMaxAP;
						}
						else if(city.PopulationWorkable <= 750 && city.PopulationWorkable > 500)
						{
							city.PopulationMaxAP = 2;
							city.PopulationAP = city.PopulationMaxAP;
						}
						else if(city.PopulationWorkable <= 1000 && city.PopulationWorkable > 750)
						{
							city.PopulationMaxAP = 3;
							city.PopulationAP = city.PopulationMaxAP;
						}
						else if(city.PopulationWorkable > 1000)
						{
							city.PopulationMaxAP = 4;
							city.PopulationAP = city.PopulationMaxAP;
						}
					}
				}
				SmallCity smallCity = GetSmallCityUnderMouse();
				if(smallCity != null)
				{
					SelectedCityInfo selectedCityInfo = smallCity.ThisCity.GetComponent<SelectedCityInfo>();
					if (smallCity.isSelected && selectedCityInfo.infoPanel)
					{
						selectedCityInfo.cityPopulationText.text = "";
						selectedCityInfo.ActivateCityInfoPanelManually(smallCity);
					}
					else 
					{
						CityHoverInfo cityHoverInfo = smallCity.ThisCity.GetComponent<CityHoverInfo>();
						cityHoverInfo.cityPopulationText.text = "";
						cityHoverInfo.CityInfoActivate();
					}
				}
				else if (citySelectedData.smallCity != null)
				{
					SelectedCityInfo selectedCityInfo = citySelectedData.smallCity.ThisCity.GetComponent<SelectedCityInfo>();
					selectedCityInfo.ActivateCityInfoPanelManually(citySelectedData.smallCity);
				}
				
				if(ownerPlayerID == 1 && player1Script.aIControlled != null)
				{
					NotYourTurn.SetActive(true);
					player1Script.aIControlled.AITurn();
				}
				else if(ownerPlayerID == 4 && player4Script.aIControlled != null)
				{
					NotYourTurn.SetActive(true);
					player4Script.aIControlled.AITurn();
				}
			}
			else if (ownerPlayerID == 4)
			{
				resetOwnerPlayerID.ResetIDs();
				markTilesInRadius.MarkTiles();
				borderLineManager.CreateBorderLines();
				ownerPlayerID = 1;
				turnCounter.NextTurn();
				
				SmallCity[] cities2 = FindObjectsOfType<SmallCity>();

				// Находим все персонажи в сцене
				CharacterData[] characters = FindObjectsOfType<CharacterData>();
				Forge[] forges = FindObjectsOfType<Forge>();
				MashineFactory[] mashineFactorys = FindObjectsOfType<MashineFactory>();
				foreach (Forge forge in forges)
				{
					if(forge.ownerPlayerID == ownerPlayerID)
					{
						if(forge.Population >= 100 && forge.Population < 200)
						{
							forge.PopulationMaxAP = 1;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 200 && forge.Population < 300)
						{
							forge.PopulationMaxAP = 2;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 300 && forge.Population < 400)
						{
							forge.PopulationMaxAP = 3;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 400 && forge.Population < 500)
						{
							forge.PopulationMaxAP = 4;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 500 && forge.Population < 600)
						{
							forge.PopulationMaxAP = 5;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 600 && forge.Population < 700)
						{
							forge.PopulationMaxAP = 6;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 700 && forge.Population < 800)
						{
							forge.PopulationMaxAP = 7;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 800 && forge.Population < 900)
						{
							forge.PopulationMaxAP = 8;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 900 && forge.Population < 1000)
						{
							forge.PopulationMaxAP = 9;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
						else if(forge.Population >= 1000)
						{
							forge.PopulationMaxAP = 10;
							forge.PopulationAP = forge.PopulationMaxAP;
						}
					}
				}
				foreach (MashineFactory mashineFactory in mashineFactorys)
				{
					if(mashineFactory.ownerPlayerID == ownerPlayerID)
					{
						if(mashineFactory.Population >= 100 && mashineFactory.Population < 200)
						{
							mashineFactory.PopulationMaxAP = 1;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 200 && mashineFactory.Population < 300)
						{
							mashineFactory.PopulationMaxAP = 2;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 300 && mashineFactory.Population < 400)
						{
							mashineFactory.PopulationMaxAP = 3;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 400 && mashineFactory.Population < 500)
						{
							mashineFactory.PopulationMaxAP = 4;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 500 && mashineFactory.Population < 600)
						{
							mashineFactory.PopulationMaxAP = 5;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 600 && mashineFactory.Population < 700)
						{
							mashineFactory.PopulationMaxAP = 6;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 700 && mashineFactory.Population < 800)
						{
							mashineFactory.PopulationMaxAP = 7;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 800 && mashineFactory.Population < 900)
						{
							mashineFactory.PopulationMaxAP = 8;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 900 && mashineFactory.Population < 1000)
						{
							mashineFactory.PopulationMaxAP = 9;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						else if(mashineFactory.Population >= 1000)
						{
							mashineFactory.PopulationMaxAP = 10;
							mashineFactory.PopulationAP = mashineFactory.PopulationMaxAP;
						}
						
					}
				}
				foreach (CharacterData character in characters)
				{
					if(character.ownerPlayerID == ownerPlayerID)
					{
						character.usableMP = character.maxMP;
						character.usableAP = character.maxAP;
						if(character.health < character.maxhealth)
						{
							character.health++;
						}
						if(character.aIDefendDrone == null)
						{
							character.WeaponSlotChanges = 0;
							character.AmmoSlotChanges = 0;
							character.HelmetSlotChanges = 0;
							character.VestSlotChanges = 0;
							character.ShirtSlotChanges = 0;
							character.isSelected = false;
							CharacterHoverInfo characterHoverInfo = character.thisCharacter.GetComponent<CharacterHoverInfo>();
							characterHoverInfo.UpdateHoverInfo();
						}
						
						if(character.transformTo >= 1)
						{
							character.transformTo--;
							if(character.transformTo == 0)
							{
								character.characterType = "Regular";
								character.spritePath = "Sprites/Units/Regular";
								character.maxhealth = +10;
								character.health++;
								character.usableMP++;
								character.maxMP++;
								character.UpdateSprite();
							}
						}
					}
				}
				
				Farm[] farms = FindObjectsOfType<Farm>();
				foreach (Farm farm in farms)
				{
					if(farm.ownerPlayerID == ownerPlayerID)
					{
						if(farm.CurrentFarm == "Flax")
						{
							farm.FlaxCount++;
							farm.cellData.Flax = farm.FlaxCount;
						}
						if(farm.CurrentFarm == "Tomato")
						{
							farm.TomatoCount++;
						}
						if(farm.CurrentFarm == "Carrot")
						{
							farm.CarrotCount++;
						}
						if(farm.CurrentFarm == "Grain")
						{
							farm.GrainCount++;
						}
					}
				}

				foreach (SmallCity city in cities2)
				{
					if (city.ownerPlayerID == ownerPlayerID)
					{
						if(city.playerScript.aIControlled == null)
						{
							Camera.main.transform.position = new Vector3(city.transform.position.x, city.transform.position.y, -10);
						}
						if (city.MobilizationInProgress)
						{
							if (city.cityInventory != null && city.cityInventory.GetFreeCharacterObjectIndex() != -1)
							{
								cityManager.MobilizeCity(city.cityID);
							}
						}
						if(city.ResearchPanelIsActive)
						{
							technologyImplementer.ImplementTechnolohy(city);
						}
					}
				}
				// Проходимся по всем городам и увеличиваем их население
				foreach (SmallCity city in cities2)
				{
					if (city.ownerPlayerID == ownerPlayerID)
					{
						int PossibleToHaveChild = city.PopulationAge18M + city.PopulationAge18W +
						city.PopulationAge19M + city.PopulationAge19W +
						city.PopulationAge20M + city.PopulationAge20W +
						city.PopulationAge21M + city.PopulationAge21W +
						city.PopulationAge22M + city.PopulationAge22W +
						city.PopulationAge23M + city.PopulationAge23W +
						city.PopulationAge24M + city.PopulationAge24W +
						city.PopulationAge25M + city.PopulationAge25W +
						city.PopulationAge26M + city.PopulationAge26W +
						city.PopulationAge27M + city.PopulationAge27W +
						city.PopulationAge28M + city.PopulationAge28W +
						city.PopulationAge29M + city.PopulationAge29W +
						city.PopulationAge30M + city.PopulationAge30W +
						city.PopulationAge31M + city.PopulationAge31W +
						city.PopulationAge32M + city.PopulationAge32W +
						city.PopulationAge33M + city.PopulationAge33W +
						city.PopulationAge34M + city.PopulationAge34W +
						city.PopulationAge35M + city.PopulationAge35W +
						city.PopulationAge36M + city.PopulationAge36W +
						city.PopulationAge37M + city.PopulationAge37W +
						city.PopulationAge38M + city.PopulationAge38W +
						city.PopulationAge39M + city.PopulationAge39W +
						city.PopulationAge40M + city.PopulationAge40W +
						city.PopulationAge41M + city.PopulationAge41W +
						city.PopulationAge42M + city.PopulationAge42W +
						city.PopulationAge43M + city.PopulationAge43W +
						city.PopulationAge44M + city.PopulationAge44W +
						city.PopulationAge45M + city.PopulationAge45W;
						
						int newChild = (int)((float)PossibleToHaveChild * Random.Range(city.minBirthRateJung, city.maxBirthRateJung)); 
						//float maxDeathRateJung1 = city.maxDeathRateJung++;
						//float maxDeathRateOld1 = city.maxDeathRateOld++;
						//float DeathRateJung = Random.Range(city.minDeathRateJung, city.maxDeathRateJung); 
						//float DeathRateOld = Random.Range(city.minDeathRateOld, city.maxDeathRateOld); 
						//city.PopulationAge1M -= (int)((float)city.PopulationAge1M * DeathRateJung);
						//city.PopulationAge1W -= (int)((float)city.PopulationAge1W * DeathRateJung);
						//city.PopulationAge2M -= (int)((float)city.PopulationAge2M * DeathRateJung);
						//city.PopulationAge2W -= (int)((float)city.PopulationAge2W * DeathRateJung);
						//city.PopulationAge3M -= (int)((float)city.PopulationAge3M * DeathRateJung);
						//city.PopulationAge3W -= (int)((float)city.PopulationAge3W * DeathRateJung);
						//city.PopulationAge4M -= (int)((float)city.PopulationAge4M * DeathRateJung);
						//city.PopulationAge4W -= (int)((float)city.PopulationAge4W * DeathRateJung);
						//city.PopulationAge5M -= (int)((float)city.PopulationAge5M * DeathRateJung);
						//city.PopulationAge5W -= (int)((float)city.PopulationAge5W * DeathRateJung);
						//city.PopulationAge6M -= (int)((float)city.PopulationAge6M * DeathRateJung);
						//city.PopulationAge6W -= (int)((float)city.PopulationAge6W * DeathRateJung);
						//city.PopulationAge7M -= (int)((float)city.PopulationAge7M * DeathRateJung);
						//city.PopulationAge7W -= (int)((float)city.PopulationAge7W * DeathRateJung);
						//city.PopulationAge8M -= (int)((float)city.PopulationAge8M * DeathRateJung);
						//city.PopulationAge8W -= (int)((float)city.PopulationAge8W * DeathRateJung);
						//city.PopulationAge9M -= (int)((float)city.PopulationAge9M * DeathRateJung);
						//city.PopulationAge9W -= (int)((float)city.PopulationAge9W * DeathRateJung);
						//city.PopulationAge10M -= (int)((float)city.PopulationAge10M * DeathRateJung);
						//city.PopulationAge10W -= (int)((float)city.PopulationAge10W * DeathRateJung);
						//city.PopulationAge11M -= (int)((float)city.PopulationAge11M * DeathRateJung);
						//city.PopulationAge11W -= (int)((float)city.PopulationAge11W * DeathRateJung);
						//city.PopulationAge12M -= (int)((float)city.PopulationAge12M * DeathRateJung);
						//city.PopulationAge12W -= (int)((float)city.PopulationAge12W * DeathRateJung);
						//city.PopulationAge13M -= (int)((float)city.PopulationAge13M * DeathRateJung);
						//city.PopulationAge13W -= (int)((float)city.PopulationAge13W * DeathRateJung);
						//city.PopulationAge14M -= (int)((float)city.PopulationAge14M * DeathRateJung);
						//city.PopulationAge14W -= (int)((float)city.PopulationAge14W * DeathRateJung);
						//city.PopulationAge15M -= (int)((float)city.PopulationAge15M * DeathRateJung);
						//city.PopulationAge15W -= (int)((float)city.PopulationAge15W * DeathRateJung);
						//city.PopulationAge16M -= (int)((float)city.PopulationAge16M * DeathRateJung);
						//city.PopulationAge16W -= (int)((float)city.PopulationAge16W * DeathRateJung);
						//city.PopulationAge17M -= (int)((float)city.PopulationAge17M * DeathRateJung);
						//city.PopulationAge17W -= (int)((float)city.PopulationAge17W * DeathRateJung);
						//city.PopulationAge18M -= (int)((float)city.PopulationAge18M * DeathRateJung);
						//city.PopulationAge18W -= (int)((float)city.PopulationAge18W * DeathRateJung);
						//city.PopulationAge19M -= (int)((float)city.PopulationAge19M * DeathRateJung);
						//city.PopulationAge19W -= (int)((float)city.PopulationAge19W * DeathRateJung);
						//city.PopulationAge20M -= (int)((float)city.PopulationAge20M * DeathRateJung);
						//city.PopulationAge20W -= (int)((float)city.PopulationAge20W * DeathRateJung);
						//city.PopulationAge21M -= (int)((float)city.PopulationAge21M * DeathRateJung);
						//city.PopulationAge21W -= (int)((float)city.PopulationAge21W * DeathRateJung);
						//city.PopulationAge22M -= (int)((float)city.PopulationAge22M * DeathRateJung);
						//city.PopulationAge22W -= (int)((float)city.PopulationAge22W * DeathRateJung);
						//city.PopulationAge23M -= (int)((float)city.PopulationAge23M * DeathRateJung);
						//city.PopulationAge23W -= (int)((float)city.PopulationAge23W * DeathRateJung);
						//city.PopulationAge24M -= (int)((float)city.PopulationAge24M * DeathRateJung);
						//city.PopulationAge24W -= (int)((float)city.PopulationAge24W * DeathRateJung);
						//city.PopulationAge25M -= (int)((float)city.PopulationAge25M * DeathRateJung);
						//city.PopulationAge25W -= (int)((float)city.PopulationAge25W * DeathRateJung);
						//city.PopulationAge26M -= (int)((float)city.PopulationAge26M * DeathRateJung);
						//city.PopulationAge26W -= (int)((float)city.PopulationAge26W * DeathRateJung);
						//city.PopulationAge27M -= (int)((float)city.PopulationAge27M * DeathRateJung);
						//city.PopulationAge27W -= (int)((float)city.PopulationAge27W * DeathRateJung);
						//city.PopulationAge28M -= (int)((float)city.PopulationAge28M * DeathRateJung);
						//city.PopulationAge28W -= (int)((float)city.PopulationAge28W * DeathRateJung);
						//city.PopulationAge29M -= (int)((float)city.PopulationAge29M * DeathRateJung);
						//city.PopulationAge29W -= (int)((float)city.PopulationAge29W * DeathRateJung);
						//city.PopulationAge30M -= (int)((float)city.PopulationAge30M * DeathRateJung);
						//city.PopulationAge30W -= (int)((float)city.PopulationAge30W * DeathRateJung);
						//city.PopulationAge31M -= (int)((float)city.PopulationAge31M * DeathRateJung);
						//city.PopulationAge31W -= (int)((float)city.PopulationAge31W * DeathRateJung);
						//city.PopulationAge32M -= (int)((float)city.PopulationAge32M * DeathRateJung);
						//city.PopulationAge32W -= (int)((float)city.PopulationAge32W * DeathRateJung);
						//city.PopulationAge33M -= (int)((float)city.PopulationAge33M * DeathRateJung);
						//city.PopulationAge33W -= (int)((float)city.PopulationAge33W * DeathRateJung);
						//city.PopulationAge34M -= (int)((float)city.PopulationAge34M * DeathRateJung);
						//city.PopulationAge34W -= (int)((float)city.PopulationAge34W * DeathRateJung);
						//city.PopulationAge35M -= (int)((float)city.PopulationAge35M * DeathRateJung);
						//city.PopulationAge35W -= (int)((float)city.PopulationAge35W * DeathRateJung);
						//city.PopulationAge36M -= (int)((float)city.PopulationAge36M * DeathRateJung);
						//city.PopulationAge36W -= (int)((float)city.PopulationAge36W * DeathRateJung);
						//city.PopulationAge37M -= (int)((float)city.PopulationAge37M * DeathRateJung);
						//city.PopulationAge37W -= (int)((float)city.PopulationAge37W * DeathRateJung);
						//city.PopulationAge38M -= (int)((float)city.PopulationAge38M * DeathRateJung);
						//city.PopulationAge38W -= (int)((float)city.PopulationAge38W * DeathRateJung);
						//city.PopulationAge39M -= (int)((float)city.PopulationAge39M * DeathRateJung);
						//city.PopulationAge39W -= (int)((float)city.PopulationAge39W * DeathRateJung);
						//city.PopulationAge40M -= (int)((float)city.PopulationAge40M * DeathRateJung);
						//city.PopulationAge40W -= (int)((float)city.PopulationAge40W * DeathRateJung);
						//city.PopulationAge41M -= (int)((float)city.PopulationAge41M * DeathRateJung);
						//city.PopulationAge41W -= (int)((float)city.PopulationAge41W * DeathRateJung);
						//city.PopulationAge42M -= (int)((float)city.PopulationAge42M * DeathRateJung);
						//city.PopulationAge42W -= (int)((float)city.PopulationAge42W * DeathRateJung);
						//city.PopulationAge43M -= (int)((float)city.PopulationAge43M * DeathRateJung);
						//city.PopulationAge43W -= (int)((float)city.PopulationAge43W * DeathRateJung);
						//city.PopulationAge44M -= (int)((float)city.PopulationAge44M * DeathRateJung);
						//city.PopulationAge44W -= (int)((float)city.PopulationAge44W * DeathRateJung);
						//city.PopulationAge45M -= (int)((float)city.PopulationAge45M * DeathRateJung);
						//city.PopulationAge45W -= (int)((float)city.PopulationAge45W * DeathRateJung);
						//city.PopulationAge46M -= (int)((float)city.PopulationAge46M * DeathRateJung);
						//city.PopulationAge46W -= (int)((float)city.PopulationAge46W * DeathRateJung);
						//city.PopulationAge47M -= (int)((float)city.PopulationAge47M * DeathRateJung);
						//city.PopulationAge47W -= (int)((float)city.PopulationAge47W * DeathRateJung);
						//city.PopulationAge48M -= (int)((float)city.PopulationAge48M * DeathRateJung);
						//city.PopulationAge48W -= (int)((float)city.PopulationAge48W * DeathRateJung);
						//city.PopulationAge49M -= (int)((float)city.PopulationAge49M * DeathRateJung);
						//city.PopulationAge49W -= (int)((float)city.PopulationAge49W * DeathRateJung);
						//city.PopulationAge50M -= (int)((float)city.PopulationAge50M * DeathRateJung);
						//city.PopulationAge50W -= (int)((float)city.PopulationAge50W * DeathRateJung);
						//city.PopulationAge51M -= (int)((float)city.PopulationAge51M * DeathRateJung);
						//city.PopulationAge51W -= (int)((float)city.PopulationAge51W * DeathRateJung);
						//city.PopulationAge52M -= (int)((float)city.PopulationAge52M * DeathRateJung);
						//city.PopulationAge52W -= (int)((float)city.PopulationAge52W * DeathRateJung);
						//city.PopulationAge53M -= (int)((float)city.PopulationAge53M * DeathRateJung);
						//city.PopulationAge53W -= (int)((float)city.PopulationAge53W * DeathRateJung);
						//city.PopulationAge54M -= (int)((float)city.PopulationAge54M * DeathRateJung);
						//city.PopulationAge54W -= (int)((float)city.PopulationAge54W * DeathRateJung);
						//city.PopulationAge55M -= (int)((float)city.PopulationAge55M * DeathRateJung);
						//city.PopulationAge55W -= (int)((float)city.PopulationAge55W * DeathRateJung);
						//city.PopulationAge56M -= (int)((float)city.PopulationAge56M * DeathRateJung);
						//city.PopulationAge56W -= (int)((float)city.PopulationAge56W * DeathRateJung);
						//city.PopulationAge57M -= (int)((float)city.PopulationAge57M * DeathRateJung);
						//city.PopulationAge57W -= (int)((float)city.PopulationAge57W * DeathRateJung);
						//city.PopulationAge58M -= (int)((float)city.PopulationAge58M * DeathRateJung);
						//city.PopulationAge58W -= (int)((float)city.PopulationAge58W * DeathRateJung);
						//city.PopulationAge59M -= (int)((float)city.PopulationAge59M * DeathRateJung);
						//city.PopulationAge59W -= (int)((float)city.PopulationAge59W * DeathRateJung);
						//city.PopulationAge60M -= (int)((float)city.PopulationAge60M * DeathRateJung);
						//city.PopulationAge60W -= (int)((float)city.PopulationAge60W * DeathRateJung);
						//city.PopulationAge61M -= (int)((float)city.PopulationAge61M * DeathRateOld);
						//city.PopulationAge61W -= (int)((float)city.PopulationAge61W * DeathRateOld);
						//city.PopulationAge62M -= (int)((float)city.PopulationAge62M * DeathRateOld);
						//city.PopulationAge62W -= (int)((float)city.PopulationAge62W * DeathRateOld);
						//city.PopulationAge63M -= (int)((float)city.PopulationAge63M * DeathRateOld);
						//city.PopulationAge63W -= (int)((float)city.PopulationAge63W * DeathRateOld);
						//city.PopulationAge64M -= (int)((float)city.PopulationAge64M * DeathRateOld);
						//city.PopulationAge64W -= (int)((float)city.PopulationAge64W * DeathRateOld);
						//city.PopulationAge65M -= (int)((float)city.PopulationAge65M * DeathRateOld);
						//city.PopulationAge65W -= (int)((float)city.PopulationAge65W * DeathRateOld);
						//city.PopulationAge66M -= (int)((float)city.PopulationAge66M * DeathRateOld);
						//city.PopulationAge66W -= (int)((float)city.PopulationAge66W * DeathRateOld);
						//city.PopulationAge67M -= (int)((float)city.PopulationAge67M * DeathRateOld);
						//city.PopulationAge67W -= (int)((float)city.PopulationAge67W * DeathRateOld);
						//city.PopulationAge68M -= (int)((float)city.PopulationAge68M * DeathRateOld);
						//city.PopulationAge68W -= (int)((float)city.PopulationAge68W * DeathRateOld);
						//city.PopulationAge69M -= (int)((float)city.PopulationAge69M * DeathRateOld);
						//city.PopulationAge69W -= (int)((float)city.PopulationAge69W * DeathRateOld);
						//city.PopulationAge70M -= (int)((float)city.PopulationAge70M * DeathRateOld);
						//city.PopulationAge70W -= (int)((float)city.PopulationAge70W * DeathRateOld);
						
						city.PopulationAge70M = city.PopulationAge69M;
						city.PopulationAge70W = city.PopulationAge69W;
						city.PopulationAge69M = city.PopulationAge68M;
						city.PopulationAge69W = city.PopulationAge68W;
						city.PopulationAge68M = city.PopulationAge67M;
						city.PopulationAge68W = city.PopulationAge67W;
						city.PopulationAge67M = city.PopulationAge66M;
						city.PopulationAge67W = city.PopulationAge66W;
						city.PopulationAge66M = city.PopulationAge65M;
						city.PopulationAge66W = city.PopulationAge65W;
						city.PopulationAge65M = city.PopulationAge64M;
						city.PopulationAge65W = city.PopulationAge64W;
						city.PopulationAge64M = city.PopulationAge63M;
						city.PopulationAge64W = city.PopulationAge63W;
						city.PopulationAge63M = city.PopulationAge62M;
						city.PopulationAge63W = city.PopulationAge62W;
						city.PopulationAge62M = city.PopulationAge61M;
						city.PopulationAge62W = city.PopulationAge61W;
						city.PopulationAge61M = city.PopulationAge60M;
						city.PopulationAge61W = city.PopulationAge60W;
						city.PopulationAge60M = city.PopulationAge59M;
						city.PopulationAge60W = city.PopulationAge59W;
						city.PopulationAge59M = city.PopulationAge58M;
						city.PopulationAge59W = city.PopulationAge58W;
						city.PopulationAge58M = city.PopulationAge57M;
						city.PopulationAge58W = city.PopulationAge57W;
						city.PopulationAge57M = city.PopulationAge56M;
						city.PopulationAge57W = city.PopulationAge56W;
						city.PopulationAge56M = city.PopulationAge55M;
						city.PopulationAge56W = city.PopulationAge55W;
						city.PopulationAge55M = city.PopulationAge54M;
						city.PopulationAge55W = city.PopulationAge54W;
						city.PopulationAge54M = city.PopulationAge53M;
						city.PopulationAge54W = city.PopulationAge53W;
						city.PopulationAge53M = city.PopulationAge52M;
						city.PopulationAge53W = city.PopulationAge52W;
						city.PopulationAge52M = city.PopulationAge51M;
						city.PopulationAge52W = city.PopulationAge51W;
						city.PopulationAge51M = city.PopulationAge50M;
						city.PopulationAge51W = city.PopulationAge50W;
						city.PopulationAge50M = city.PopulationAge49M;
						city.PopulationAge50W = city.PopulationAge49W;
						city.PopulationAge49M = city.PopulationAge48M;
						city.PopulationAge49W = city.PopulationAge48W;
						city.PopulationAge48M = city.PopulationAge47M;
						city.PopulationAge48W = city.PopulationAge47W;
						city.PopulationAge47M = city.PopulationAge46M;
						city.PopulationAge47W = city.PopulationAge46W;
						city.PopulationAge46M = city.PopulationAge45M;
						city.PopulationAge46W = city.PopulationAge45W;
						city.PopulationAge45M = city.PopulationAge44M;
						city.PopulationAge45W = city.PopulationAge44W;
						city.PopulationAge44M = city.PopulationAge43M;
						city.PopulationAge44W = city.PopulationAge43W;
						city.PopulationAge43M = city.PopulationAge42M;
						city.PopulationAge43W = city.PopulationAge42W;
						city.PopulationAge42M = city.PopulationAge41M;
						city.PopulationAge42W = city.PopulationAge41W;
						city.PopulationAge41M = city.PopulationAge40M;
						city.PopulationAge41W = city.PopulationAge40W;
						city.PopulationAge40M = city.PopulationAge39M;
						city.PopulationAge40W = city.PopulationAge39W;
						city.PopulationAge39M = city.PopulationAge38M;
						city.PopulationAge39W = city.PopulationAge38W;
						city.PopulationAge38M = city.PopulationAge37M;
						city.PopulationAge38W = city.PopulationAge37W;
						city.PopulationAge37M = city.PopulationAge36M;
						city.PopulationAge37W = city.PopulationAge36W;
						city.PopulationAge36M = city.PopulationAge35M;
						city.PopulationAge36W = city.PopulationAge35W;
						city.PopulationAge35M = city.PopulationAge34M;
						city.PopulationAge35W = city.PopulationAge34W;
						city.PopulationAge34M = city.PopulationAge33M;
						city.PopulationAge34W = city.PopulationAge33W;
						city.PopulationAge33M = city.PopulationAge32M;
						city.PopulationAge33W = city.PopulationAge32W;
						city.PopulationAge32M = city.PopulationAge31M;
						city.PopulationAge32W = city.PopulationAge31W;
						city.PopulationAge31M = city.PopulationAge30M;
						city.PopulationAge31W = city.PopulationAge30W;
						city.PopulationAge30M = city.PopulationAge29M;
						city.PopulationAge30W = city.PopulationAge29W;
						city.PopulationAge29M = city.PopulationAge28M;
						city.PopulationAge29W = city.PopulationAge28W;
						city.PopulationAge28M = city.PopulationAge27M;
						city.PopulationAge28W = city.PopulationAge27W;
						city.PopulationAge27M = city.PopulationAge26M;
						city.PopulationAge27W = city.PopulationAge26W;
						city.PopulationAge26M = city.PopulationAge25M;
						city.PopulationAge26W = city.PopulationAge25W;
						city.PopulationAge25M = city.PopulationAge24M;
						city.PopulationAge25W = city.PopulationAge24W;
						city.PopulationAge24M = city.PopulationAge23M;
						city.PopulationAge24W = city.PopulationAge23W;
						city.PopulationAge23M = city.PopulationAge22M;
						city.PopulationAge23W = city.PopulationAge22W;
						city.PopulationAge22M = city.PopulationAge21M;
						city.PopulationAge22W = city.PopulationAge21W;
						city.PopulationAge21M = city.PopulationAge20M;
						city.PopulationAge21W = city.PopulationAge20W;
						city.PopulationAge20M = city.PopulationAge19M;
						city.PopulationAge20W = city.PopulationAge19W;
						city.PopulationAge19M = city.PopulationAge18M;
						city.PopulationAge19W = city.PopulationAge18W;
						city.PopulationAge18M = city.PopulationAge17M;
						city.PopulationAge18W = city.PopulationAge17W;
						city.PopulationAge17M = city.PopulationAge16M;
						city.PopulationAge17W = city.PopulationAge16W;
						city.PopulationAge16M = city.PopulationAge15M;
						city.PopulationAge16W = city.PopulationAge15W;
						city.PopulationAge15M = city.PopulationAge14M;
						city.PopulationAge15W = city.PopulationAge14W;
						city.PopulationAge14M = city.PopulationAge13M;
						city.PopulationAge14W = city.PopulationAge13W;
						city.PopulationAge13M = city.PopulationAge12M;
						city.PopulationAge13W = city.PopulationAge12W;
						city.PopulationAge12M = city.PopulationAge11M;
						city.PopulationAge12W = city.PopulationAge11W;
						city.PopulationAge11M = city.PopulationAge10M;
						city.PopulationAge11W = city.PopulationAge10W;
						city.PopulationAge10M = city.PopulationAge9M;
						city.PopulationAge10W = city.PopulationAge9W;
						city.PopulationAge9M = city.PopulationAge8M;
						city.PopulationAge9W = city.PopulationAge8W;
						city.PopulationAge8M = city.PopulationAge7M;
						city.PopulationAge8W = city.PopulationAge7W;
						city.PopulationAge7M = city.PopulationAge6M;
						city.PopulationAge7W = city.PopulationAge6W;
						city.PopulationAge6M = city.PopulationAge5M;
						city.PopulationAge6W = city.PopulationAge5W;
						city.PopulationAge5M = city.PopulationAge4M;
						city.PopulationAge5W = city.PopulationAge4W;
						city.PopulationAge4M = city.PopulationAge3M;
						city.PopulationAge4W = city.PopulationAge3W;
						city.PopulationAge3M = city.PopulationAge2M;
						city.PopulationAge3W = city.PopulationAge2W;
						city.PopulationAge2M = city.PopulationAge1M;
						city.PopulationAge2W = city.PopulationAge1W;
						city.PopulationAge1M = city.PopulationAge0M;
						city.PopulationAge1W = city.PopulationAge0W;
						city.PopulationAge0M = (int)((float)newChild / 2f);
						city.PopulationAge0W = (int)((float)newChild / 2f);

						city.Population = city.PopulationAge0M + city.PopulationAge0W + city.PopulationAge1M + city.PopulationAge1W + city.PopulationAge2M + city.PopulationAge2W +
						city.PopulationAge3M + city.PopulationAge3W +
						city.PopulationAge4M + city.PopulationAge4W +
						city.PopulationAge5M + city.PopulationAge5W +
						city.PopulationAge6M + city.PopulationAge6W +
						city.PopulationAge7M + city.PopulationAge7W +
						city.PopulationAge8M + city.PopulationAge8W +
						city.PopulationAge9M + city.PopulationAge9W +
						city.PopulationAge10M + city.PopulationAge10W +
						city.PopulationAge11M + city.PopulationAge11W +
						city.PopulationAge12M + city.PopulationAge12W +
						city.PopulationAge13M + city.PopulationAge13W +
						city.PopulationAge14M + city.PopulationAge14W +
						city.PopulationAge15M + city.PopulationAge15W +
						city.PopulationAge16M + city.PopulationAge16W +
						city.PopulationAge17M + city.PopulationAge17W +
						city.PopulationAge18M + city.PopulationAge18W +
						city.PopulationAge19M + city.PopulationAge19W +
						city.PopulationAge20M + city.PopulationAge20W +
						city.PopulationAge21M + city.PopulationAge21W +
						city.PopulationAge22M + city.PopulationAge22W +
						city.PopulationAge23M + city.PopulationAge23W +
						city.PopulationAge24M + city.PopulationAge24W +
						city.PopulationAge25M + city.PopulationAge25W +
						city.PopulationAge26M + city.PopulationAge26W +
						city.PopulationAge27M + city.PopulationAge27W +
						city.PopulationAge28M + city.PopulationAge28W +
						city.PopulationAge29M + city.PopulationAge29W +
						city.PopulationAge30M + city.PopulationAge30W +
						city.PopulationAge31M + city.PopulationAge31W +
						city.PopulationAge32M + city.PopulationAge32W +
						city.PopulationAge33M + city.PopulationAge33W +
						city.PopulationAge34M + city.PopulationAge34W +
						city.PopulationAge35M + city.PopulationAge35W +
						city.PopulationAge36M + city.PopulationAge36W +
						city.PopulationAge37M + city.PopulationAge37W +
						city.PopulationAge38M + city.PopulationAge38W +
						city.PopulationAge39M + city.PopulationAge39W +
						city.PopulationAge40M + city.PopulationAge40W +
						city.PopulationAge41M + city.PopulationAge41W +
						city.PopulationAge42M + city.PopulationAge42W +
						city.PopulationAge43M + city.PopulationAge43W +
						city.PopulationAge44M + city.PopulationAge44W +
						city.PopulationAge45M + city.PopulationAge45W +
						city.PopulationAge46M + city.PopulationAge46W +
						city.PopulationAge47M + city.PopulationAge47W +
						city.PopulationAge48M + city.PopulationAge48W +
						city.PopulationAge49M + city.PopulationAge49W +
						city.PopulationAge50M + city.PopulationAge50W +
						city.PopulationAge51M + city.PopulationAge51W +
						city.PopulationAge52M + city.PopulationAge52W +
						city.PopulationAge53M + city.PopulationAge53W +
						city.PopulationAge54M + city.PopulationAge54W +
						city.PopulationAge55M + city.PopulationAge55W +
						city.PopulationAge56M + city.PopulationAge56W +
						city.PopulationAge57M + city.PopulationAge57W +
						city.PopulationAge58M + city.PopulationAge58W +
						city.PopulationAge59M + city.PopulationAge59W +
						city.PopulationAge60M + city.PopulationAge60W +
						city.PopulationAge61M + city.PopulationAge61W +
						city.PopulationAge62M + city.PopulationAge62W +
						city.PopulationAge63M + city.PopulationAge63W +
						city.PopulationAge64M + city.PopulationAge64W +
						city.PopulationAge65M + city.PopulationAge65W +
						city.PopulationAge66M + city.PopulationAge66W +
						city.PopulationAge67M + city.PopulationAge67W +
						city.PopulationAge68M + city.PopulationAge68W +
						city.PopulationAge69M + city.PopulationAge69W +
						city.PopulationAge70M + city.PopulationAge70W;
						
						city.PopulationWorkable = city.PopulationAge18M +
						city.PopulationAge19M +
						city.PopulationAge20M +
						city.PopulationAge21M +
						city.PopulationAge22M +
						city.PopulationAge23M +
						city.PopulationAge24M +
						city.PopulationAge25M +
						city.PopulationAge26M +
						city.PopulationAge27M +
						city.PopulationAge28M +
						city.PopulationAge29M +
						city.PopulationAge30M +
						city.PopulationAge31M +
						city.PopulationAge32M +
						city.PopulationAge33M +
						city.PopulationAge34M +
						city.PopulationAge35M +
						city.PopulationAge36M +
						city.PopulationAge37M +
						city.PopulationAge38M +
						city.PopulationAge39M +
						city.PopulationAge40M +
						city.PopulationAge41M +
						city.PopulationAge42M +
						city.PopulationAge43M +
						city.PopulationAge44M +
						city.PopulationAge45M;
					  
						if(city.PopulationWorkable <= 500)
						{
							city.PopulationMaxAP = 1;
							city.PopulationAP = city.PopulationMaxAP;
						}
						else if(city.PopulationWorkable <= 750 && city.PopulationWorkable > 500)
						{
							city.PopulationMaxAP = 2;
							city.PopulationAP = city.PopulationMaxAP;
						}
						else if(city.PopulationWorkable <= 1000 && city.PopulationWorkable > 750)
						{
							city.PopulationMaxAP = 3;
							city.PopulationAP = city.PopulationMaxAP;
						}
						else if(city.PopulationWorkable > 1000)
						{
							city.PopulationMaxAP = 4;
							city.PopulationAP = city.PopulationMaxAP;
						}
					}
				}
				SmallCity smallCity = GetSmallCityUnderMouse();
				if(smallCity != null)
				{
					SelectedCityInfo selectedCityInfo = smallCity.ThisCity.GetComponent<SelectedCityInfo>();
					if (smallCity.isSelected && selectedCityInfo.infoPanel)
					{
						selectedCityInfo.cityPopulationText.text = "";
						selectedCityInfo.ActivateCityInfoPanelManually(smallCity);
					}
					else 
					{
						CityHoverInfo cityHoverInfo = smallCity.ThisCity.GetComponent<CityHoverInfo>();
						selectedCityInfo.cityPopulationText.text = "";
						cityHoverInfo.CityInfoActivate();
					}
				}
				else if (citySelectedData.smallCity != null)
				{
					SelectedCityInfo selectedCityInfo = citySelectedData.smallCity.ThisCity.GetComponent<SelectedCityInfo>();
					selectedCityInfo.ActivateCityInfoPanelManually(citySelectedData.smallCity);
				}
			}
			if(player1Script.aIControlled != null)
			{
				NotYourTurn.SetActive(true);
				player1Script.aIControlled.AITurn();
			}
		}
	}
	
	public CityInventory FindCityInventory(int cityID)
	{
		// Находим все объекты CityInventory в сцене
		CityInventory[] cityInventories = FindObjectsOfType<CityInventory>();

		// Ищем CityInventory с заданным CityID
		foreach (CityInventory cityInventory in cityInventories)
		{
			if (cityInventory.cityID == cityID)
			{
				return cityInventory;
			}
		}
		return null;
	}
	
	private SmallCity GetSmallCityUnderMouse()
	{
		// Получите позицию мыши в мировых координатах
		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// Пускаем луч к точке нажатия мыши и получаем информацию о столкновении
		RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, LayerMask.GetMask("City"));

		if (hit.collider != null)
		{
			GameObject hitObject = hit.collider.gameObject;
			SmallCity smallCity = hitObject.GetComponent<SmallCity>();
			return smallCity;
		}

		return null; // Если мышь не указывает на персонажа, возвращаем null
	}
	
	private CharacterData GetCharacterDataUnderMouse()
	{
		// Получите позицию мыши в мировых координатах
		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// Пускаем луч к точке нажатия мыши и получаем информацию о столкновении
		RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, LayerMask.GetMask("Units"));

		if (hit.collider != null)
		{
			GameObject hitObject = hit.collider.gameObject;
			CharacterData characterData = hitObject.GetComponent<CharacterData>();
			return characterData;
		}
		return null;
	}
}