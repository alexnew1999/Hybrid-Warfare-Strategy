using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ForgeCrafts : MonoBehaviour
{
	public GameObject CraftingPanel;
	public Button craftIronIgnot;
	public Button craftGunpowder;
	public Button craftAluminiumIgnot;
	public Button Building4;
	public Button Building5;
	public Button Building6;
	public Button Building7;
	
	public CrafterData crafterData;
	public ItemsList itemsList;
	public ForgeUI forgeUI;
	public CharacterInventoryUI characterInventoryUI;
	
	public GameObject CostToCraft;
	public TextMeshProUGUI NameOfCraft;
	public TextMeshProUGUI Costs;
	public Button Back;
	public Button Continiue;
	
	public GameObject SabreResearch;
	public GameObject NaganResearch;
	public GameObject NaganAmmoResearch;
	public GameObject MosinResearch;
	public GameObject MosinAmmoResearch;
	public GameObject PPSHResearch;
	public GameObject PPDResearch;
	public GameObject PPAmmoResearch;
	public GameObject PMResearch;
	public GameObject PMAmmoResearch;
	public GameObject Mortar82Research;
	public GameObject Mortar82AmmoResearch;
	public GameObject MaximGunResearch;
	public GameObject AltynResearch;
	
	private void Start()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(false);
		
		SabreResearch.SetActive(false);
		NaganResearch.SetActive(false);
		NaganAmmoResearch.SetActive(false);
		MosinResearch.SetActive(false);
		MosinAmmoResearch.SetActive(false);
		PPSHResearch.SetActive(false);
		PPDResearch.SetActive(false);
		PPAmmoResearch.SetActive(false);
		PMResearch.SetActive(false);
		PMAmmoResearch.SetActive(false);
		Mortar82Research.SetActive(false);
		Mortar82AmmoResearch.SetActive(false);
		MaximGunResearch.SetActive(false);
		AltynResearch.SetActive(false);
	}
	
	public void ForgeCraft()
	{
		SmallCity[] citys = FindObjectsOfType<SmallCity>();
		foreach (SmallCity city in citys)
		{
			if(city.ownerPlayerID == crafterData.forge.ownerPlayerID)
			{
				if (crafterData.forge.PopulationAP > 0)
				{
					CraftingPanel.SetActive(true);
					if(city.playerScript.InfantryLightWeaponResearch1 == 1)
					{
						SabreResearch.SetActive(true);
					}
					if(city.playerScript.InfantryLightWeaponResearch2 == 1)
					{
						NaganResearch.SetActive(true);
						NaganAmmoResearch.SetActive(true);
					}
					if(city.playerScript.InfantryLightWeaponResearch3 == 1)
					{
						MosinResearch.SetActive(true);
						MosinAmmoResearch.SetActive(true);
					}
					if(city.playerScript.InfantryLightWeaponResearch4point1 == 1)
					{
						PPSHResearch.SetActive(true);
						PPAmmoResearch.SetActive(true);
					}
					if(city.playerScript.InfantryLightWeaponResearch4point2 == 1)
					{
						PPDResearch.SetActive(true);
						PPAmmoResearch.SetActive(true);
					}
					if(city.playerScript.InfantryLightWeaponResearch11 == 1)
					{
						PMResearch.SetActive(true);
						PMAmmoResearch.SetActive(true);
					}
					if(city.playerScript.InfantryHeavyWeaponResearch1 == 1)
					{
						Mortar82Research.SetActive(true);
						Mortar82AmmoResearch.SetActive(true);
					}
					if(city.playerScript.InfantryHeavyWeaponResearch2 == 1)
					{
						MaximGunResearch.SetActive(true);
						MosinAmmoResearch.SetActive(true);
					}
					if(city.playerScript.InfantryArmorResearch11 == 1)
					{
						AltynResearch.SetActive(true);
					}
				}
			}
		}
	}
	
	public void CraftCharcoalQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Charcoal";
		Costs.text = "2 wooden log";
		Continiue.onClick.AddListener(CraftCharcoal);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftCharcoal()
	{
		if (crafterData.forge.CheckNumberOfItemsWithIDInInventoryForge(1001, 2))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			GameObject ExistedItemGameObject = crafterData.forge.FindItemWithIDInInventoryForge(1006);
			if(ExistedItemGameObject == null && freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				ItemObject Coal = itemsList.CreateItemObject("Coal", 1006, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Coal");
				crafterData.forge.AddItemToForgeInventory(Coal.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			else if (ExistedItemGameObject != null)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				ItemObject Coal = ExistedItemGameObject.GetComponent<ItemObject>();
				Coal.quantity++;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftIronIgnotQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Iron Ignot";
		Costs.text = "1 iron ore, 1 coal";
		Continiue.onClick.AddListener(CraftIronIgnot);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftIronIgnot()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1006) && crafterData.forge.CheckItemWithIDInInventoryForge(1003))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			GameObject ExistedItemGameObject = crafterData.forge.FindItemWithIDInInventoryForge(1002);
			if(ExistedItemGameObject == null && freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1006);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1003);
				ItemObject IronIgnot = itemsList.CreateItemObject("Iron Ignot", 1002, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Iron Ignot");
				crafterData.forge.AddItemToForgeInventory(IronIgnot.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			else if (ExistedItemGameObject != null)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1006);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1003);
				ItemObject IronIgnot = ExistedItemGameObject.GetComponent<ItemObject>();
				IronIgnot.quantity++;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftGunpowderQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Gunpowder";
		Costs.text = "1 saltpeter, 1 coal";
		Continiue.onClick.AddListener(CraftGunpowder);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftGunpowder()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1005) && crafterData.forge.CheckItemWithIDInInventoryForge(1006))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			GameObject ExistedItemGameObject = crafterData.forge.FindItemWithIDInInventoryForge(1007);
			if(ExistedItemGameObject == null && freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1005);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1006);
				ItemObject Gunpowder = itemsList.CreateItemObject("Gunpowder", 1007, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Gunpowder");
				crafterData.forge.AddItemToForgeInventory(Gunpowder.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			else if (ExistedItemGameObject != null)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1005);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1006);
				ItemObject Gunpowder = ExistedItemGameObject.GetComponent<ItemObject>();
				Gunpowder.quantity++;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftAluminiumIgnotQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Aluminium Ignot";
		Costs.text = "1 aluninium ore, 1 coal";
		Continiue.onClick.AddListener(CraftAluminiumIgnot);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftAluminiumIgnot()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1006) && crafterData.forge.CheckItemWithIDInInventoryForge(1008))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			GameObject ExistedItemGameObject = crafterData.forge.FindItemWithIDInInventoryForge(1010);
			if(ExistedItemGameObject == null && freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1006);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1008);
				ItemObject Aluminium = itemsList.CreateItemObject("Aluminium Ignot", 1010, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Aluminium");
				crafterData.forge.AddItemToForgeInventory(Aluminium.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			else if(ExistedItemGameObject != null)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1006);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1008);
				ItemObject Aluminium = ExistedItemGameObject.GetComponent<ItemObject>();
				Aluminium.quantity++;
			}
			forgeUI.UpdateItemSpritesForge();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftPMQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "PM";
		Costs.text = "2 aluninium ignot";
		Continiue.onClick.AddListener(CraftPM);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftPM()
	{
		if (crafterData.forge.CheckNumberOfItemsWithIDInInventoryForge(1010, 2))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1010);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1010);
				ItemObject PM = itemsList.CreateItemObject("PM", 3, 1, 1, 8, 0, 3, 0, 0, 0, 3, 0, 80, 0, 0, "9x18mm", 3, ItemType.weapon, "Sprites/PM");
				crafterData.forge.AddItemToForgeInventory(PM.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void Craft9x18mmAmmoQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "10 units of 9x18 mm rounds";
		Costs.text = "1 copper ignot, 1 gunpowder";
		Continiue.onClick.AddListener(Craft9x18mmAmmo);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void Craft9x18mmAmmo()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1007) && crafterData.forge.CheckItemWithIDInInventoryForge(1014))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			GameObject ExistedItemGameObject = crafterData.forge.FindItemWithIDInInventoryForge(401);
			if(ExistedItemGameObject == null && freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1007);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1014);
				ItemObject mm9 = itemsList.CreateItemObject("9x18mm", 401, 10, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.ammo, "Sprites/9mm");
				crafterData.forge.AddItemToForgeInventory(mm9.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			else if (ExistedItemGameObject != null)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1007);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1014);
				ItemObject mm9 = ExistedItemGameObject.GetComponent<ItemObject>();
				mm9.quantity = mm9.quantity + 10;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftCopperIgnotQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Copper Ignot";
		Costs.text = "1 copper ore, 1 coal";
		Continiue.onClick.AddListener(CraftCopperIgnot);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftCopperIgnot()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1006) && crafterData.forge.CheckItemWithIDInInventoryForge(1011))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			GameObject ExistedItemGameObject = crafterData.forge.FindItemWithIDInInventoryForge(1014);
			if(ExistedItemGameObject == null && freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1006);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1011);
				ItemObject CopperIgnot = itemsList.CreateItemObject("Copper Ignot", 1014, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Copper Ignot");
				crafterData.forge.AddItemToForgeInventory(CopperIgnot.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			else if (ExistedItemGameObject != null)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1006);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1011);
				ItemObject CopperIgnot = ExistedItemGameObject.GetComponent<ItemObject>();
				CopperIgnot.quantity++;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftMosinRifleQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Mosin Rifle";
		Costs.text = "2 iron ignot, 1 wood";
		Continiue.onClick.AddListener(CraftMosinRifle);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftMosinRifle()
	{
		if (crafterData.forge.CheckNumberOfItemsWithIDInInventoryForge(1002, 2) && crafterData.forge.CheckItemWithIDInInventoryForge(1001))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				ItemObject MosinRifle = itemsList.CreateItemObject("Mosin Rifle", 4, 1, 1, 12, 0, 5, 0, 0, 0, 4, 0, 95, 0, 0, "7.62x54mmR", 1, ItemType.weapon, "Sprites/MosinRifle");
				crafterData.forge.AddItemToForgeInventory(MosinRifle.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}

			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void Craftmm762x54RAmmoQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "10 7.62x54mmR rounds";
		Costs.text = "1 copper ignot, 1 gunpowder";
		Continiue.onClick.AddListener(Craftmm762x54RAmmo);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void Craftmm762x54RAmmo()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1007) && crafterData.forge.CheckItemWithIDInInventoryForge(1014))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			GameObject ExistedItemGameObject = crafterData.forge.FindItemWithIDInInventoryForge(402);
			if(ExistedItemGameObject == null && freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1007);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1014);
				ItemObject mm762x54R = itemsList.CreateItemObject("7.62x54mmR", 402, 10, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.ammo, "Sprites/mm762x54R");
				crafterData.forge.AddItemToForgeInventory(mm762x54R.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			else if (ExistedItemGameObject != null)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1007);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1014);
				ItemObject mm762x54R = ExistedItemGameObject.GetComponent<ItemObject>();
				mm762x54R.quantity = mm762x54R.quantity + 10;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftMaximGunQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Maxim Gun";
		Costs.text = "4 iron ignot";
		Continiue.onClick.AddListener(CraftMaximGun);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftMaximGun()
	{
		if (crafterData.forge.CheckNumberOfItemsWithIDInInventoryForge(1002, 4))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				ItemObject MaximGun = itemsList.CreateItemObject("Maxim Gun", 5, 1, 1, 10, 0, 3, 0, 0, 0, 4, 0, 50, 0, 2, "7.62x54mmR", 10, ItemType.weapon, "Sprites/MaximGun");
				crafterData.forge.AddItemToForgeInventory(MaximGun.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}

			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftMortar82BM37Question()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Mortar 82-BM-37";
		Costs.text = "4 iron ignot";
		Continiue.onClick.AddListener(CraftMortar82BM37);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftMortar82BM37()
	{
		if (crafterData.forge.CheckNumberOfItemsWithIDInInventoryForge(1002, 4))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				ItemObject Mortar82BM37 = itemsList.CreateItemObject("Mortar 82-BM-37", 6, 1, 1, 15, 0, 0, 0, 0, 0, 6, 0, 40, 0, 0, "82 mm Mortar Shell", 1, ItemType.weapon, "Sprites/Mortar82BM37");
				crafterData.forge.AddItemToForgeInventory(Mortar82BM37.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}

			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void Craft82mmMortarShellQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "One 82 mm Mortar Shell";
		Costs.text = "1 copper ignot, 1 gunpowder";
		Continiue.onClick.AddListener(Craft82mmMortarShell);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void Craft82mmMortarShell()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1007) && crafterData.forge.CheckItemWithIDInInventoryForge(1014))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			GameObject ExistedItemGameObject = crafterData.forge.FindItemWithIDInInventoryForge(403);
			if(ExistedItemGameObject == null && freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1007);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1014);
				ItemObject mm82MortarShell = itemsList.CreateItemObject("82 mm Mortar Shell", 403, 01, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.ammo, "Sprites/82mmMortarShell");
				crafterData.forge.AddItemToForgeInventory(mm82MortarShell.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			else if (ExistedItemGameObject != null)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1007);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1014);
				ItemObject mm82MortarShell = ExistedItemGameObject.GetComponent<ItemObject>();
				mm82MortarShell.quantity = mm82MortarShell.quantity + 1;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftPPSh41Question()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "PPSh-41";
		Costs.text = "2 iron ignot, 1 wood";
		Continiue.onClick.AddListener(CraftPPSh41);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftPPSh41()
	{
		if (crafterData.forge.CheckNumberOfItemsWithIDInInventoryForge(1002, 2) && crafterData.forge.CheckItemWithIDInInventoryForge(1001))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				ItemObject PPSh41 = itemsList.CreateItemObject("PPSh-41", 7, 1, 1, 8, 0, 0, 0, 0, 0, 3, 0, 65, 0, 0, "7.62x25mm", 5, ItemType.weapon, "Sprites/PPSh41");
				crafterData.forge.AddItemToForgeInventory(PPSh41.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}

			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftPPD34Question()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "PPD-34";
		Costs.text = "3 iron ignot, 1 wood";
		Continiue.onClick.AddListener(CraftPPD34);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftPPD34()
	{
		if (crafterData.forge.CheckNumberOfItemsWithIDInInventoryForge(1002, 3) && crafterData.forge.CheckItemWithIDInInventoryForge(1001))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				ItemObject PPD34 = itemsList.CreateItemObject("PPD-34", 8, 1, 1, 10, 0, 0, 0, 0, 0, 3, 0, 75, 0, 0, "7.62x25mm", 5, ItemType.weapon, "Sprites/PPD34");
				crafterData.forge.AddItemToForgeInventory(PPD34.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}

			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void Craftmm762x25AmmoQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "10 7.62x25mm rounds";
		Costs.text = "1 copper ignot, 1 gunpowder";
		Continiue.onClick.AddListener(Craftmm762x25Ammo);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void Craftmm762x25Ammo()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1007) && crafterData.forge.CheckItemWithIDInInventoryForge(1014))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			GameObject ExistedItemGameObject = crafterData.forge.FindItemWithIDInInventoryForge(402);
			if(ExistedItemGameObject == null && freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1007);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1014);
				ItemObject mm762x25 = itemsList.CreateItemObject("7.62x25mm", 404, 10, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.ammo, "Sprites/mm762x25");
				crafterData.forge.AddItemToForgeInventory(mm762x25.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			else if (ExistedItemGameObject != null)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1007);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1014);
				ItemObject mm762x25 = ExistedItemGameObject.GetComponent<ItemObject>();
				mm762x25.quantity = mm762x25.quantity + 10;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
		
	public void CraftNaganRevolverQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Nagan Revolver";
		Costs.text = "1 iron ignot, 1 wood log";
		Continiue.onClick.AddListener(CraftNaganRevolver);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftNaganRevolver()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1002) && crafterData.forge.CheckItemWithIDInInventoryForge(1001))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				ItemObject NaganRevolver = itemsList.CreateItemObject("Nagan Revolver", 9, 1, 1, 8, 0, 0, 0, 0, 0, 2, 0, 65, 0, 0, "11,2 mm", 2, ItemType.weapon, "Sprites/Nagan1917");
				crafterData.forge.AddItemToForgeInventory(NaganRevolver.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void Craft11mmAmmoQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "10 units of 11,2 mm rounds";
		Costs.text = "1 copper ignot, 1 gunpowder";
		Continiue.onClick.AddListener(Craft11mmAmmo);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void Craft11mmAmmo()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1007) && crafterData.forge.CheckItemWithIDInInventoryForge(1014))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			GameObject ExistedItemGameObject = crafterData.forge.FindItemWithIDInInventoryForge(405);
			if(ExistedItemGameObject == null && freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1007);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1014);
				ItemObject mm11 = itemsList.CreateItemObject("11,2 mm", 405, 10, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.ammo, "Sprites/11mm");
				crafterData.forge.AddItemToForgeInventory(mm11.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			else if (ExistedItemGameObject != null)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1007);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1014);
				ItemObject mm11 = ExistedItemGameObject.GetComponent<ItemObject>();
				mm11.quantity = mm11.quantity + 10;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftSabreQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Sabre";
		Costs.text = "2 iron ignot, 1 wood log";
		Continiue.onClick.AddListener(CraftSabre);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftSabre()
	{
		if (crafterData.forge.CheckNumberOfItemsWithIDInInventoryForge(1002, 2) && crafterData.forge.CheckItemWithIDInInventoryForge(1001))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				ItemObject Sabre = itemsList.CreateItemObject("Sabre", 10, 1, 1, 12, 0, 0, 0, 0, 0, 1, 0, 65, 0, 0, "None", 0, ItemType.weapon, "Sprites/Sabre");
				crafterData.forge.AddItemToForgeInventory(Sabre.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftAltynQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Altyn";
		Costs.text = "2 aluminium ignot, 1 iron ignot";
		Continiue.onClick.AddListener(CraftAltyn);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftAltyn()
	{
		if (crafterData.forge.CheckNumberOfItemsWithIDInInventoryForge(1010, 2) && crafterData.forge.CheckItemWithIDInInventoryForge(1002))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1010);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1010);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				ItemObject Altyn = itemsList.CreateItemObject("Altyn", 104, 1, 1, 0, 0, 0, 20, 5, 5, 0, 0, 0, 0, 1, "None", 0, ItemType.helmet, "Sprites/Altyn");
				crafterData.forge.AddItemToForgeInventory(Altyn.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftCobaltIgnotQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Cobalt Ignot";
		Costs.text = "1 cobalt ore, 1 coal";
		Continiue.onClick.AddListener(CraftCobaltIgnot);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftCobaltIgnot()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1006) && crafterData.forge.CheckItemWithIDInInventoryForge(1016))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			GameObject ExistedItemGameObject = crafterData.forge.FindItemWithIDInInventoryForge(1017);
			if(ExistedItemGameObject == null && freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1006);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1016);
				ItemObject CobaltIgnot = itemsList.CreateItemObject("Cobalt Ignot", 1017, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/CobaltIgnot");
				crafterData.forge.AddItemToForgeInventory(CobaltIgnot.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			else if (ExistedItemGameObject != null)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1006);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1016);
				ItemObject CobaltIgnot = ExistedItemGameObject.GetComponent<ItemObject>();
				CobaltIgnot.quantity++;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftPetrolQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Petrol";
		Costs.text = "1 oil";
		Continiue.onClick.AddListener(CraftPetrol);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftPetrol()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1009))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			GameObject ExistedItemGameObject = crafterData.forge.FindItemWithIDInInventoryForge(1018);
			if(ExistedItemGameObject == null && freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1009);
				ItemObject Petrol = itemsList.CreateItemObject("Petrol", 1018, 5, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Petrol");
				crafterData.forge.AddItemToForgeInventory(Petrol.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			else if (ExistedItemGameObject != null)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1009);
				ItemObject Petrol = ExistedItemGameObject.GetComponent<ItemObject>();
				Petrol.quantity++;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftPlasticQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Plastic";
		Costs.text = "1 oil, 1 cobalt ignot";
		Continiue.onClick.AddListener(CraftPlastic);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftPlastic()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1009) && crafterData.forge.CheckItemWithIDInInventoryForge(1017))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			GameObject ExistedItemGameObject = crafterData.forge.FindItemWithIDInInventoryForge(1019);
			if(ExistedItemGameObject == null && freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1009);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1017);
				ItemObject Plastic = itemsList.CreateItemObject("Plastic", 1019, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Plastic");
				crafterData.forge.AddItemToForgeInventory(Plastic.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			else if (ExistedItemGameObject != null)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1009);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1017);
				ItemObject Plastic = ExistedItemGameObject.GetComponent<ItemObject>();
				Plastic.quantity++;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftLumberAxeQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Lumber Axe";
		Costs.text = "1 iron ignot, 1 wood log";
		Continiue.onClick.AddListener(CraftLumberAxe);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftLumberAxe()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1002) && crafterData.forge.CheckItemWithIDInInventoryForge(1001))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				ItemObject LumberAxe = itemsList.CreateItemObject("Lumber Axe", 11, 1, 1, 5, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, "None", 0, ItemType.weapon, "Sprites/LumberAxe");
				crafterData.forge.AddItemToForgeInventory(LumberAxe.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftPixAxeQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "PixAxe";
		Costs.text = "1 iron ignot, 1 wood log";
		Continiue.onClick.AddListener(CraftPixAxe);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftPixAxe()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1002) && crafterData.forge.CheckItemWithIDInInventoryForge(1001))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				ItemObject PixAxe = itemsList.CreateItemObject("PixAxe", 12, 1, 1, 5, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, "None", 0, ItemType.weapon, "Sprites/PixAxe");
				crafterData.forge.AddItemToForgeInventory(PixAxe.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftShowelQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Showel";
		Costs.text = "1 iron ignot, 1 wood log";
		Continiue.onClick.AddListener(CraftShowel);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftShowel()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1002) && crafterData.forge.CheckItemWithIDInInventoryForge(1001))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				ItemObject Showel = itemsList.CreateItemObject("Showel", 13, 1, 1, 5, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, "None", 0, ItemType.weapon, "Sprites/Showel");
				crafterData.forge.AddItemToForgeInventory(Showel.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftSickleQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Sickle";
		Costs.text = "1 iron ignot, 1 wood log";
		Continiue.onClick.AddListener(CraftSickle);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftSickle()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1002) && crafterData.forge.CheckItemWithIDInInventoryForge(1001))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				ItemObject Sickle = itemsList.CreateItemObject("Sickle", 14, 1, 1, 5, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, "None", 0, ItemType.weapon, "Sprites/Sickle");
				crafterData.forge.AddItemToForgeInventory(Sickle.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void CraftHoeQuestion()
	{
		CraftingPanel.SetActive(false);
		CostToCraft.SetActive(true);
		NameOfCraft.text = "Hoe";
		Costs.text = "1 iron ignot, 1 wood log";
		Continiue.onClick.AddListener(CraftHoe);
		Continiue.onClick.AddListener(Cancel);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
	}
	
	public void CraftHoe()
	{
		if (crafterData.forge.CheckItemWithIDInInventoryForge(1002) && crafterData.forge.CheckItemWithIDInInventoryForge(1001))
		{
			int freeSlotIndex = crafterData.forge.GetFreeItemObjectIndexForge();
			if(freeSlotIndex != -1)
			{
				crafterData.forge.PopulationAP --;
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1002);
				crafterData.forge.RemoveItemWithIDFromInventoryForge(1001);
				ItemObject Hoe = itemsList.CreateItemObject("Hoe", 15, 1, 1, 5, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, "None", 0, ItemType.weapon, "Sprites/Hoe");
				crafterData.forge.AddItemToForgeInventory(Hoe.gameObject, freeSlotIndex);
				InventorySlot newSlot = crafterData.forge.GetInventorySlotForge(freeSlotIndex);
				newSlot.isOccupied = true;
			}
			forgeUI.UpdateItemSpritesForge();
			Continiue.onClick.RemoveAllListeners();
		}
		else
		{
			Debug.Log("Not enough recources.");
		}
	}
	
	public void Cancel()
	{
		CostToCraft.SetActive(false);
		Continiue.onClick.RemoveAllListeners();
	}
	
	public void ExitButton()
	{
		CraftingPanel.SetActive(false);
		
		SabreResearch.SetActive(false);
		NaganResearch.SetActive(false);
		NaganAmmoResearch.SetActive(false);
		MosinResearch.SetActive(false);
		MosinAmmoResearch.SetActive(false);
		PPSHResearch.SetActive(false);
		PPDResearch.SetActive(false);
		PPAmmoResearch.SetActive(false);
		PMResearch.SetActive(false);
		PMAmmoResearch.SetActive(false);
		Mortar82Research.SetActive(false);
		Mortar82AmmoResearch.SetActive(false);
		MaximGunResearch.SetActive(false);
		AltynResearch.SetActive(false);
	}
}
