using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class BuildingList : MonoBehaviour
{
	public GameObject BuildingPanel;
	public Button BuildingForge;
	public Button digTrench;
	public Button Building3;
	public Button Building4;
	public Button Building5;
	public Button Building6;
	public Button Building7;
	public CharacterData builder;
	public CellData buildingCell;
	public GameObject buildSitePrefab;
	
	public GameObject MaintainingBuildingPanel;
	public TextMeshProUGUI LeftedWood;
	public TextMeshProUGUI LeftedStone;
	public TextMeshProUGUI LeftedIron;
	public TextMeshProUGUI LeftedTurns;
	public Button OK;

	public Button Exit;
	public BuildData buildData;
	
	public GameObject CostToBuild;
	public TextMeshProUGUI NameOfBuilding;
	public TextMeshProUGUI WoodAndStone;
	public Button Back;
	public Button Continiue;
	public SelectedCharacterInfo selectedCharacterInfo;
	public IDCounter iDCounter;
	public TextMeshProUGUI DebugInfoPanel;
	public GameObject DebugInfoPanelObj;
	public CharacterSelection characterSelection;
	
	private void Start()
	{
		BuildingPanel.SetActive(false);
		CostToBuild.SetActive(false);
		MaintainingBuildingPanel.SetActive(false);
	}
	
	public void Build()
	{
		NameOfBuilding.text = null;
		WoodAndStone.text = null;
		buildData.characterData = null;
		buildData.cellData = null;
		builder = FindObjectsOfType<CharacterData>().FirstOrDefault(characterData => characterData.isSelected);
		if (builder != null)
		{
			buildingCell = builder.currentCell;
			if (buildingCell.terrainType == TerrainType.None)
			{
				if (builder.usableAP > 0)
				{
					buildData.characterData = builder;
					buildData.cellData = buildingCell;
					BuildingPanel.SetActive(true);
				}
				else
				{
					if (!DebugInfoPanelObj.activeSelf)
					{
						DebugInfoPanelObj.SetActive(true);
					}
					DebugInfoPanel.text = "Too tired to build.";
				}
			}
			else if (buildingCell.terrainType == TerrainType.Building)
			{
				if (buildingCell.buildingSite != null)
				{
					if (builder.usableAP > 0)
					{
						buildData.characterData = builder;
						buildData.cellData = buildingCell;
						if (buildData.cellData.buildingSite.TurnToBuild > 0)
						{
							buildData.cellData.buildingSite.TurnToBuild--;
							builder.usableAP -= 1;
							if(builder.usableAP == 0)
							{
								characterSelection.FirearmGO.SetActive(false);
								characterSelection.HandAttackGO.SetActive(false);
								characterSelection.MeleeAttackGO.SetActive(false);
							}
							selectedCharacterInfo.UpdateCharacterUsableAP(builder);
						}
						if (buildData.cellData.buildingSite.WoodToBuild > 0)
						{
							if (builder.characterInventory.CheckItemWithIDInInventoryCharacter(1001))
							{
								buildData.cellData.buildingSite.WoodToBuild--;
								builder.characterInventory.RemoveItemWithIDFromInventoryCharacter(1001);
							}
						}
						if (buildData.cellData.buildingSite.StoneToBuild > 0)
						{
							if (builder.characterInventory.CheckItemWithIDInInventoryCharacter(1004))
							{
								buildData.cellData.buildingSite.StoneToBuild--;
								builder.characterInventory.RemoveItemWithIDFromInventoryCharacter(1004);
							}
						}
						if (buildData.cellData.buildingSite.IronToBuild > 0)
						{
							if (builder.characterInventory.CheckItemWithIDInInventoryCharacter(1002))
							{
								buildData.cellData.buildingSite.IronToBuild--;
								builder.characterInventory.RemoveItemWithIDFromInventoryCharacter(1002);
							}
						}
						if (buildData.cellData.buildingSite.StoneToBuild == 0 && buildData.cellData.buildingSite.WoodToBuild == 0 && buildData.cellData.buildingSite.IronToBuild == 0 && buildData.cellData.buildingSite.TurnToBuild == 0 && buildData.cellData.buildingSite.mashineFactory != null)
						{
							int slotIndex = buildData.cellData.buildingSite.cellData.mashineFactory.GetFreeCharacterObjectIndexMashineFactory();
							if (slotIndex != -1)
							{
								buildData.cellData.buildingSite.cellData.mashineFactory.AddCharacterToMashineFactoryInventory(buildData.characterData.thisCharacter, slotIndex);
							}
							Destroy(buildData.cellData.buildingSite);
							buildData.cellData.buildingSite = null;
							Sprite newSprite = Resources.Load<Sprite>("Sprites/Building/MashineFactory");
							BoxCollider2D collider = buildData.cellData.Building.AddComponent<BoxCollider2D>();
							SpriteRenderer spriteRenderer = buildData.cellData.Building.GetComponent<SpriteRenderer>();
							SelectedMashineFactoryInfo selectedMashineFactoryInfo = buildData.cellData.Building.AddComponent<SelectedMashineFactoryInfo>();
							MashineFactoryHoverInfo mashineFactoryHoverInfo = buildData.cellData.Building.AddComponent<MashineFactoryHoverInfo>();
							buildData.cellData.coverChance = 30f;
							spriteRenderer.sprite = newSprite;
							CharacterVisibility characterVisibility = buildData.characterData.thisCharacter.GetComponent<CharacterVisibility>();
							characterVisibility.SetNotVisibile();
							characterSelection.DeselectCharacter();
						}
						else if (buildData.cellData.buildingSite.StoneToBuild == 0 && buildData.cellData.buildingSite.WoodToBuild == 0 && buildData.cellData.buildingSite.IronToBuild == 0 && buildData.cellData.buildingSite.TurnToBuild == 0 && buildData.cellData.buildingSite.forge != null)
						{
							Destroy(buildData.cellData.buildingSite);
							buildData.cellData.buildingSite = null;
							Sprite newSprite = Resources.Load<Sprite>("Sprites/Building");
							SpriteRenderer spriteRenderer = buildData.cellData.Building.GetComponent<SpriteRenderer>();
							spriteRenderer.sprite = newSprite;
						}
						else if (buildData.cellData.buildingSite.StoneToBuild == 0 && buildData.cellData.buildingSite.WoodToBuild == 0 && buildData.cellData.buildingSite.IronToBuild == 0 && buildData.cellData.buildingSite.TurnToBuild == 0 && buildData.cellData.buildingSite.mine != null)
						{
							Destroy(buildData.cellData.buildingSite);
							buildData.cellData.buildingSite = null;
							Sprite newSprite = Resources.Load<Sprite>("Sprites/Mine");
							SpriteRenderer spriteRenderer = buildData.cellData.Building.GetComponent<SpriteRenderer>();
							spriteRenderer.sprite = newSprite;
						}
						else if (buildData.cellData.buildingSite.StoneToBuild == 0 && buildData.cellData.buildingSite.WoodToBuild == 0 && buildData.cellData.buildingSite.IronToBuild == 0 && buildData.cellData.buildingSite.TurnToBuild == 0 && buildData.cellData.buildingSite.preTrench != null)
						{
							Destroy(buildData.cellData.buildingSite);
							buildData.cellData.buildingSite = null;
							Sprite newSprite = Resources.Load<Sprite>("Sprites/Trench");
							SpriteRenderer spriteRenderer = buildData.cellData.Building.GetComponent<SpriteRenderer>();
							spriteRenderer.sprite = newSprite;
							Trench trenchComponent = buildData.cellData.Building.AddComponent<Trench>();
							buildData.cellData.trench = trenchComponent;
							buildData.cellData.coverChance = 50f;
							buildData.cellData.node.baseCost = 2;
						}
						else if (buildData.cellData.buildingSite.StoneToBuild == 0 && buildData.cellData.buildingSite.WoodToBuild == 0 && buildData.cellData.buildingSite.IronToBuild == 0 && buildData.cellData.buildingSite.TurnToBuild == 0 && buildData.cellData.buildingSite.farm != null)
						{
							Destroy(buildData.cellData.buildingSite);
							buildData.cellData.buildingSite = null;
							Sprite newSprite = Resources.Load<Sprite>("Sprites/Farm");
							buildData.cellData.buildingSite.farm.finished = 1;
							SpriteRenderer spriteRenderer = buildData.cellData.Building.GetComponent<SpriteRenderer>();
							spriteRenderer.sprite = newSprite;
						}
						else if (buildData.cellData.buildingSite != null && buildData.cellData.buildingSite.StoneToBuild >= 0 && buildData.cellData.buildingSite.WoodToBuild >= 0 && buildData.cellData.buildingSite.IronToBuild >= 0  && buildData.cellData.buildingSite.TurnToBuild >= 0)
						{
							MaintainingBuildingPanel.SetActive(true);
							LeftedWood.text = buildData.cellData.buildingSite.WoodToBuild.ToString();
							LeftedStone.text = buildData.cellData.buildingSite.StoneToBuild.ToString();
							LeftedIron.text = buildData.cellData.buildingSite.IronToBuild.ToString();
							LeftedTurns.text = buildData.cellData.buildingSite.TurnToBuild.ToString();
						}
					}
					else
					{
						if (!DebugInfoPanelObj.activeSelf)
						{
							DebugInfoPanelObj.SetActive(true);
						}
						DebugInfoPanel.text = "Too tired to build.";
					}
				}
				else
				{
					if (!DebugInfoPanelObj.activeSelf)
					{
						DebugInfoPanelObj.SetActive(true);
					}
					DebugInfoPanel.text = "Alredy has a building.";
				}
			}
			else
			{
				if (!DebugInfoPanelObj.activeSelf)
				{
					DebugInfoPanelObj.SetActive(true);
				}
				DebugInfoPanel.text = "It's not possible to build here.";
			}
		}
	}
	
	public void BuildForgeQuestion()
	{
		CostToBuild.SetActive(true);
		BuildingPanel.SetActive(false);
		NameOfBuilding.text = "Forge";
		WoodAndStone.text = "4 turn, 4 wood, 4 stone";
		Continiue.onClick.AddListener(BuildForge);
		Continiue.onClick.AddListener(Cancel);
	}
	
	public void BuildForge()
	{
		if(buildData.characterData.ownerPlayerID == buildData.cellData.ownerPlayerID)
		{
			buildData.characterData.usableAP -= 1;
			if(buildData.characterData.usableAP == 0)
			{
				characterSelection.FirearmGO.SetActive(false);
				characterSelection.HandAttackGO.SetActive(false);
				characterSelection.MeleeAttackGO.SetActive(false);
			}
			GameObject buildingForge = new GameObject("Building Forge");
			buildingForge.transform.position = buildData.cellData.transform.position;
			SpriteRenderer forgeSpriteRenderer = buildingForge.AddComponent<SpriteRenderer>();
			string spritePath = "Sprites/Terrain/BuildingSite";
			Sprite forgeSprite = Resources.Load<Sprite>(spritePath);
			forgeSpriteRenderer.sprite = forgeSprite;
			forgeSpriteRenderer.sortingLayerName = "City Layer";
			BuildingSite buildingComponent = buildingForge.AddComponent<BuildingSite>();
			buildData.cellData.buildingSite = buildingComponent;
			buildData.cellData.Building = buildingForge;
			buildingComponent.WoodToBuild = 4;
			buildingComponent.StoneToBuild = 4;
			buildingComponent.IronToBuild = 0;
			buildingComponent.TurnToBuild = 3;
			buildData.cellData.terrainType = TerrainType.Building;
			buildingComponent.cellData = buildData.cellData;
			Forge forgeComponent = buildingForge.AddComponent<Forge>();
			forgeComponent.GlobalID = iDCounter.globalID;
			iDCounter.globalID++;
			forgeComponent.ownerPlayerID = buildData.characterData.ownerPlayerID;
			forgeComponent.forgeObject = buildingForge;
			buildingComponent.cellData.forge = forgeComponent;
			buildingComponent.cellData.forge.cellData = buildingComponent.cellData;
			buildingComponent.forge = forgeComponent;
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			if (!DebugInfoPanelObj.activeSelf)
			{
				DebugInfoPanelObj.SetActive(true);
			}
			DebugInfoPanel.text = "Not your territory.";
		}
	}
	
	public void BuildMashineFactoryQuestion()
	{
		CostToBuild.SetActive(true);
		BuildingPanel.SetActive(false);
		NameOfBuilding.text = "Forge";
		WoodAndStone.text = "12 turn, 12 stone, 8 iron";
		Continiue.onClick.AddListener(BuildMashineFactory);
		Continiue.onClick.AddListener(Cancel);
	}
	
	public void BuildMashineFactory()
	{
		if(buildData.characterData.ownerPlayerID == buildData.cellData.ownerPlayerID)
		{
			buildData.characterData.usableAP -= 1;
			if(buildData.characterData.usableAP == 0)
			{
				characterSelection.FirearmGO.SetActive(false);
				characterSelection.HandAttackGO.SetActive(false);
				characterSelection.MeleeAttackGO.SetActive(false);
			}
			GameObject buildingMashineFactory = new GameObject("Building Machine Factory");
			buildingMashineFactory.transform.position = buildData.cellData.transform.position;
			SpriteRenderer forgeSpriteRenderer = buildingMashineFactory.AddComponent<SpriteRenderer>();
			string spritePath = "Sprites/Terrain/BuildingSite";
			Sprite forgeSprite = Resources.Load<Sprite>(spritePath);
			forgeSpriteRenderer.sprite = forgeSprite;
			forgeSpriteRenderer.sortingLayerName = "City Layer";
			BuildingSite buildingComponent = buildingMashineFactory.AddComponent<BuildingSite>();
			buildData.cellData.buildingSite = buildingComponent;
			buildData.cellData.Building = buildingMashineFactory;
			buildingComponent.WoodToBuild = 0;
			buildingComponent.StoneToBuild = 12;
			buildingComponent.IronToBuild = 8;
			buildingComponent.TurnToBuild = 11;
			buildData.cellData.terrainType = TerrainType.Building;
			buildingComponent.cellData = buildData.cellData;
			MashineFactory mashineFactoryComponent = buildingMashineFactory.AddComponent<MashineFactory>();
			mashineFactoryComponent.GlobalID = iDCounter.globalID;
			iDCounter.globalID++;
			mashineFactoryComponent.ownerPlayerID = buildData.characterData.ownerPlayerID;
			mashineFactoryComponent.mashineFactoryObject = buildingMashineFactory;
			buildingComponent.cellData.mashineFactory = mashineFactoryComponent;
			buildingComponent.cellData.mashineFactory.cellData = buildingComponent.cellData;
			buildingComponent.mashineFactory = mashineFactoryComponent;
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			if (!DebugInfoPanelObj.activeSelf)
			{
				DebugInfoPanelObj.SetActive(true);
			}
			DebugInfoPanel.text = "Not your territory.";
		}
	}
	
	public void DigTrenchQuestion()
	{
		CostToBuild.SetActive(true);
		BuildingPanel.SetActive(false);
		NameOfBuilding.text = "Trench";
		WoodAndStone.text = "3 turn, 2 wood";
		Continiue.onClick.AddListener(DigTrench);
		Continiue.onClick.AddListener(Cancel);
	}
	
	public void DigTrench()
	{
		buildData.characterData.usableAP -= 1;
		if(buildData.characterData.usableAP == 0)
		{
			characterSelection.FirearmGO.SetActive(false);
			characterSelection.HandAttackGO.SetActive(false);
			characterSelection.MeleeAttackGO.SetActive(false);
		}
		GameObject buildingTrench = new GameObject("Building Trench");
		buildingTrench.transform.position = buildData.cellData.transform.position;
		SpriteRenderer trenchSpriteRenderer = buildingTrench.AddComponent<SpriteRenderer>();
		string spritePath = "Sprites/Terrain/BuildingSite";
		Sprite trenchSprite = Resources.Load<Sprite>(spritePath);
		trenchSpriteRenderer.sprite = trenchSprite;
		trenchSpriteRenderer.sortingLayerName = "City Layer";
		BuildingSite buildingComponent = buildingTrench.AddComponent<BuildingSite>();
		buildData.cellData.buildingSite = buildingComponent;
		buildData.cellData.Building = buildingTrench;
		buildingComponent.WoodToBuild = 2;
		buildingComponent.StoneToBuild = 0;
		buildingComponent.IronToBuild = 0;
		buildingComponent.TurnToBuild = 2;
		buildData.cellData.terrainType = TerrainType.Building;
		buildingComponent.cellData = buildData.cellData;
		PreTrench preTrench = buildingTrench.AddComponent<PreTrench>();
		buildData.cellData.preTrench = preTrench;
		buildData.cellData.buildingSite.preTrench = preTrench;
		Continiue.onClick.RemoveAllListeners();
	}
	
	public void BuildMineQuestion()
	{
		CostToBuild.SetActive(true);
		BuildingPanel.SetActive(false);
		NameOfBuilding.text = "Mine";
		WoodAndStone.text = "8 turn, 8 wood, 8 stone, 4 iron";
		Continiue.onClick.AddListener(BuildMine);
		Continiue.onClick.AddListener(Cancel);
	}
	
	public void BuildMine()
	{
		buildData.characterData.usableAP -= 1;
		if(buildData.characterData.usableAP == 0)
		{
			characterSelection.FirearmGO.SetActive(false);
			characterSelection.HandAttackGO.SetActive(false);
			characterSelection.MeleeAttackGO.SetActive(false);
		}
		GameObject buildingMine = new GameObject("Building Mine");
		buildingMine.transform.position = buildData.cellData.transform.position;
		SpriteRenderer mineSpriteRenderer = buildingMine.AddComponent<SpriteRenderer>();
		string spritePath = "Sprites/Terrain/BuildingSite";
		Sprite mineSprite = Resources.Load<Sprite>(spritePath);
		mineSpriteRenderer.sprite = mineSprite;
		mineSpriteRenderer.sortingLayerName = "City Layer";
		BuildingSite buildingComponent = buildingMine.AddComponent<BuildingSite>();
		buildData.cellData.buildingSite = buildingComponent;
		buildData.cellData.Building = buildingMine;
		buildingComponent.WoodToBuild = 8;
		buildingComponent.StoneToBuild = 8;
		buildingComponent.IronToBuild = 8;
		buildingComponent.TurnToBuild = 7;
		buildData.cellData.terrainType = TerrainType.Building;
		buildingComponent.cellData = buildData.cellData;
		Mine mine = buildingMine.AddComponent<Mine>();
		buildingComponent.cellData.mine = mine;
		buildData.cellData.buildingSite.mine = mine;
		Continiue.onClick.RemoveAllListeners();
	}
	
	public void BuildFarmQuestion()
	{
		CostToBuild.SetActive(true);
		BuildingPanel.SetActive(false);
		NameOfBuilding.text = "Mine";
		WoodAndStone.text = "4 turn, 4 wood, 2 stone";
		Continiue.onClick.AddListener(BuildFarm);
		Continiue.onClick.AddListener(Cancel);
	}
	
	public void BuildFarm()
	{
		buildData.characterData.usableAP -= 1;
		if(buildData.characterData.usableAP == 0)
		{
			characterSelection.FirearmGO.SetActive(false);
			characterSelection.HandAttackGO.SetActive(false);
			characterSelection.MeleeAttackGO.SetActive(false);
		}
		GameObject buildingFarm = new GameObject("Building Farm");
		buildingFarm.transform.position = buildData.cellData.transform.position;
		SpriteRenderer farmSpriteRenderer = buildingFarm.AddComponent<SpriteRenderer>();
		string spritePath = "Sprites/Terrain/BuildingSite";
		Sprite farmSprite = Resources.Load<Sprite>(spritePath);
		farmSpriteRenderer.sprite = farmSprite;
		farmSpriteRenderer.sortingLayerName = "City Layer";
		BuildingSite buildingComponent = buildingFarm.AddComponent<BuildingSite>();
		buildData.cellData.buildingSite = buildingComponent;
		buildData.cellData.Building = buildingFarm;
		buildingComponent.WoodToBuild = 4;
		buildingComponent.StoneToBuild = 2;
		buildingComponent.IronToBuild = 0;
		buildingComponent.TurnToBuild = 3;
		buildingComponent.spritePath = spritePath;
		buildData.cellData.terrainType = TerrainType.Building;
		buildingComponent.cellData = buildData.cellData;
		Farm farm = buildingFarm.AddComponent<Farm>();
		buildingComponent.cellData.farm = farm;
		buildData.cellData.buildingSite.farm = farm;
		farm.ownerPlayerID = buildData.characterData.ownerPlayerID;
		farm.cellData = buildingComponent.cellData;
		Continiue.onClick.RemoveAllListeners();
	}
	
	public void Cancel()
	{
		CostToBuild.SetActive(false);
		Continiue.onClick.RemoveAllListeners();
	}
	
	public void CancelBuildingMaintenance()
	{
		MaintainingBuildingPanel.SetActive(false);
	}
	
	public void ExitButton()
	{
		BuildingPanel.SetActive(false);
	}
}
