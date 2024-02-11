using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TechnologyReserch : MonoBehaviour
{
	public GameObject technologyReserchPanel;
	public CityInventoryUI cityInventoryUI;
	public CitySelectedData citySelectedData;
	public SmallCity chosenCity;
	
	public GameObject ReserchInfantryLightWeaponButtonGO;
	public GameObject ReserchInfantryHeavyWeaponButtonGO;
	public GameObject ReserchInfantryClothesButtonGO;
	public GameObject ReserchInfantryArmorButtonGO;
	private int BookID = 1015;
	
	private void Start()
	{
		technologyReserchPanel.SetActive(false);
	}
	
	public void OpenTechnologyList()
	{
		technologyReserchPanel.SetActive(true);
		cityInventoryUI.CloseInventoryUI();
		cityInventoryUI.characterInventoryUI.CityOrForgeInvButtonObj.SetActive(false);
		cityInventoryUI.characterInventoryUI.characterInventoryPanel.SetActive(false);
	}
	
	public void CloseTechnologyList()
	{
		technologyReserchPanel.SetActive(false);
	}
	
	public void ReserchInfantryLightWeapon()
	{
		if(chosenCity.cityInventory.CheckNumberOfItemsWithIDInCityInventory(BookID, 2))
		{
			if(chosenCity.playerScript.InfantryLightWeaponResearch1 == 0 || chosenCity.playerScript.InfantryLightWeaponResearch2 == 0 || chosenCity.playerScript.InfantryLightWeaponResearch3 == 0 || chosenCity.playerScript.InfantryLightWeaponResearch4point1 == 0 || chosenCity.playerScript.InfantryLightWeaponResearch4point2 == 0)
			{
				int randomResearchNumber = Random.Range(1,5);
				if(randomResearchNumber == 1 && chosenCity.playerScript.InfantryLightWeaponResearch1 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 3;
					chosenCity.playerScript.CurrentResearch = "InfantryLightWeaponResearch1";
				}
				else if(randomResearchNumber == 1 && chosenCity.playerScript.InfantryLightWeaponResearch1 == 1)
				{
					if(chosenCity.playerScript.InfantryLightWeaponResearch2 == 0)
					{
						randomResearchNumber = 2;
					}
					else if(chosenCity.playerScript.InfantryLightWeaponResearch3 == 0)
					{
						randomResearchNumber = 3;
					}
					else if(chosenCity.playerScript.InfantryLightWeaponResearch4point1 == 0 || chosenCity.playerScript.InfantryLightWeaponResearch4point2 == 0)
					{
						randomResearchNumber = 4;
					}
				}
				if(randomResearchNumber == 2 && chosenCity.playerScript.InfantryLightWeaponResearch2 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 3;
					chosenCity.playerScript.CurrentResearch = "InfantryLightWeaponResearch2";
				}
				else if(randomResearchNumber == 2 && chosenCity.playerScript.InfantryLightWeaponResearch2 == 1)
				{
					if(chosenCity.playerScript.InfantryLightWeaponResearch1 == 0)
					{
						randomResearchNumber = 1;
					}
					else if(chosenCity.playerScript.InfantryLightWeaponResearch3 == 0)
					{
						randomResearchNumber = 3;
					}
					else if(chosenCity.playerScript.InfantryLightWeaponResearch4point1 == 0 || chosenCity.playerScript.InfantryLightWeaponResearch4point2 == 0)
					{
						randomResearchNumber = 4;
					}
				}
				if(randomResearchNumber == 3 && chosenCity.playerScript.InfantryLightWeaponResearch3 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 3;
					chosenCity.playerScript.CurrentResearch = "InfantryLightWeaponResearch3";
				}
				else if(randomResearchNumber == 3 && chosenCity.playerScript.InfantryLightWeaponResearch3 == 1)
				{
					if(chosenCity.playerScript.InfantryLightWeaponResearch1 == 0)
					{
						randomResearchNumber = 1;
					}
					else if(chosenCity.playerScript.InfantryLightWeaponResearch2 == 0)
					{
						randomResearchNumber = 2;
					}
					else if(chosenCity.playerScript.InfantryLightWeaponResearch4point1 == 0 || chosenCity.playerScript.InfantryLightWeaponResearch4point2 == 0)
					{
						randomResearchNumber = 4;
					}
				}
				if(randomResearchNumber == 4 && chosenCity.playerScript.InfantryLightWeaponResearch4point1 == 0 || chosenCity.playerScript.InfantryLightWeaponResearch4point2 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 3;
					int randomNumber = Random.Range(1,3);
					if(randomNumber == 1)
					{
						chosenCity.playerScript.InfantryLightWeaponResearch4point1 = 1;
					}
					else if(randomNumber == 2)
					{
						chosenCity.playerScript.InfantryLightWeaponResearch4point2 = 1;
					}
					chosenCity.playerScript.CurrentResearch = "InfantryLightWeaponResearch4";
				}
				else if(randomResearchNumber == 4 && chosenCity.playerScript.InfantryLightWeaponResearch4point1 == 1 || chosenCity.playerScript.InfantryLightWeaponResearch4point2 == 1)
				{
					if(chosenCity.playerScript.InfantryLightWeaponResearch1 == 0)
					{
						randomResearchNumber = 1;
					}
					else if(chosenCity.playerScript.InfantryLightWeaponResearch2 == 0)
					{
						randomResearchNumber = 2;
					}
					else if(chosenCity.playerScript.InfantryLightWeaponResearch3 == 0)
					{
						randomResearchNumber = 3;
					}
				}
			}
			else if(chosenCity.playerScript.InfantryLightWeaponResearch11 == 0)
			{
				int randomResearchNumber = Random.Range(1,2);
				if(randomResearchNumber == 1 && chosenCity.playerScript.InfantryLightWeaponResearch11 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 3;
					chosenCity.playerScript.CurrentResearch = "InfantryLightWeaponResearch11";
				}
			}
			else
			{
				ReserchInfantryLightWeaponButtonGO.SetActive(false);
			}
		}
		technologyReserchPanel.SetActive(false);
	}
	
	public void ReserchInfantryHeavyWeapon()
	{
		if(chosenCity.cityInventory.CheckNumberOfItemsWithIDInCityInventory(BookID, 3))
		{
			if(chosenCity.playerScript.InfantryHeavyWeaponResearch1 == 0 || chosenCity.playerScript.InfantryHeavyWeaponResearch2 == 0)
			{
				int randomResearchNumber = Random.Range(1,3);
				if(randomResearchNumber == 1 && chosenCity.playerScript.InfantryHeavyWeaponResearch1 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 4;
					chosenCity.playerScript.CurrentResearch = "InfantryHeavyWeaponResearch1";
				}
				else if(randomResearchNumber == 1 && chosenCity.playerScript.InfantryHeavyWeaponResearch1 == 1)
				{
					if(chosenCity.playerScript.InfantryHeavyWeaponResearch2 == 0)
					{
						randomResearchNumber = 2;
					}
				}
				if(randomResearchNumber == 2 && chosenCity.playerScript.InfantryHeavyWeaponResearch2 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 4;
					chosenCity.playerScript.CurrentResearch = "InfantryHeavyWeaponResearch2";
				}
				else if(randomResearchNumber == 2 && chosenCity.playerScript.InfantryHeavyWeaponResearch2 == 1)
				{
					if(chosenCity.playerScript.InfantryHeavyWeaponResearch1 == 0)
					{
						randomResearchNumber = 1;
					}
				}
			}
			else
			{
				ReserchInfantryHeavyWeaponButtonGO.SetActive(false);
			}
		}
		technologyReserchPanel.SetActive(false);
	}
	
	public void ReserchInfantryClothes()
	{
		if(chosenCity.cityInventory.CheckNumberOfItemsWithIDInCityInventory(BookID, 2))
		{
			if(chosenCity.playerScript.InfantryClothesResearch1 == 0 || chosenCity.playerScript.InfantryClothesResearch2 == 0 || chosenCity.playerScript.InfantryClothesResearch3 == 0)
			{
				int randomResearchNumber = Random.Range(1,4);
				if(randomResearchNumber == 1 && chosenCity.playerScript.InfantryClothesResearch1 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 3;
					chosenCity.playerScript.CurrentResearch = "InfantryClothesResearch1";
				}
				else if(randomResearchNumber == 1 && chosenCity.playerScript.InfantryClothesResearch1 == 1)
				{
					if(chosenCity.playerScript.InfantryClothesResearch2 == 0)
					{
						randomResearchNumber = 2;
					}
					else if(chosenCity.playerScript.InfantryClothesResearch3 == 0)
					{
						randomResearchNumber = 3;
					}
				}
				if(randomResearchNumber == 2 && chosenCity.playerScript.InfantryClothesResearch2 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 3;
					chosenCity.playerScript.CurrentResearch = "InfantryClothesResearch2";
				}
				else if(randomResearchNumber == 2 && chosenCity.playerScript.InfantryClothesResearch2 == 1)
				{
					if(chosenCity.playerScript.InfantryClothesResearch1 == 0)
					{
						randomResearchNumber = 1;
					}
					else if(chosenCity.playerScript.InfantryClothesResearch3 == 0)
					{
						randomResearchNumber = 3;
					}
				}
				if(randomResearchNumber == 3 && chosenCity.playerScript.InfantryClothesResearch3 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 3;
					chosenCity.playerScript.CurrentResearch = "InfantryClothesResearch3";
				}
				else if(randomResearchNumber == 3 && chosenCity.playerScript.InfantryClothesResearch3 == 1)
				{
					if(chosenCity.playerScript.InfantryClothesResearch1 == 0)
					{
						randomResearchNumber = 1;
					}
					else if(chosenCity.playerScript.InfantryClothesResearch2 == 0)
					{
						randomResearchNumber = 2;
					}
				}
			}
			else
			{
				ReserchInfantryClothesButtonGO.SetActive(false);
			}
		}
		technologyReserchPanel.SetActive(false);
	}
	
	public void ReserchInfantryArmor()
	{
		if(chosenCity.cityInventory.CheckNumberOfItemsWithIDInCityInventory(BookID, 3))
		{
			if(chosenCity.playerScript.InfantryArmorResearch1 == 0 || chosenCity.playerScript.InfantryArmorResearch2 == 0 || chosenCity.playerScript.InfantryArmorResearch3 == 0)
			{
				int randomResearchNumber = Random.Range(1,4);
				if(randomResearchNumber == 1 && chosenCity.playerScript.InfantryArmorResearch1 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 4;
					chosenCity.playerScript.CurrentResearch = "InfantryArmorResearch1";
				}
				else if(randomResearchNumber == 1 && chosenCity.playerScript.InfantryArmorResearch1 == 1)
				{
					if(chosenCity.playerScript.InfantryArmorResearch2 == 0)
					{
						randomResearchNumber = 2;
					}
					else if(chosenCity.playerScript.InfantryArmorResearch3 == 0)
					{
						randomResearchNumber = 3;
					}
				}
				if(randomResearchNumber == 2 && chosenCity.playerScript.InfantryArmorResearch2 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 4;
					chosenCity.playerScript.CurrentResearch = "InfantryArmorResearch2";
				}
				else if(randomResearchNumber == 2 && chosenCity.playerScript.InfantryArmorResearch2 == 1)
				{
					if(chosenCity.playerScript.InfantryArmorResearch1 == 0)
					{
						randomResearchNumber = 1;
					}
					else if(chosenCity.playerScript.InfantryArmorResearch3 == 0)
					{
						randomResearchNumber = 3;
					}
				}
				if(randomResearchNumber == 3 && chosenCity.playerScript.InfantryArmorResearch3 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 4;
					chosenCity.playerScript.CurrentResearch = "InfantryArmorResearch3";
				}
				else if(randomResearchNumber == 3 && chosenCity.playerScript.InfantryArmorResearch3 == 1)
				{
					if(chosenCity.playerScript.InfantryArmorResearch1 == 0)
					{
						randomResearchNumber = 1;
					}
					else if(chosenCity.playerScript.InfantryArmorResearch2 == 0)
					{
						randomResearchNumber = 2;
					}
				}
			}
			else if(chosenCity.playerScript.InfantryArmorResearch11 == 0)
			{
				int randomResearchNumber = Random.Range(1,2);
				if(randomResearchNumber == 1 && chosenCity.playerScript.InfantryArmorResearch11 == 0)
				{
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					chosenCity.cityInventory.RemoveItemWithIDFromInventory(BookID);
					cityInventoryUI.ResearchPanel.SetActive(true);
					chosenCity.ResearchPanelIsActive = true;
					chosenCity.turnToResearch = 4;
					chosenCity.playerScript.CurrentResearch = "InfantryArmorResearch11";
				}
			}
			else
			{
				ReserchInfantryArmorButtonGO.SetActive(false);
			}
		}
		technologyReserchPanel.SetActive(false);
	}
	
	public void ReserchInfantryConsumables()
	{
		if(chosenCity.cityInventory.CheckNumberOfItemsWithIDInCityInventory(BookID, 2))
		{
			
		}
	}
	
	public void ReserchInfantryAmmo()
	{
		if(chosenCity.cityInventory.CheckNumberOfItemsWithIDInCityInventory(BookID, 2))
		{
			
		}
	}
}
