using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologyImplementer : MonoBehaviour
{
	public CityInventoryUI cityInventoryUI;
	
	public void ImplementTechnolohy(SmallCity smallCity)
	{
		smallCity.turnToResearch --;
		if(smallCity.turnToResearch == 0)
		{
			if(smallCity.playerScript.CurrentResearch == "InfantryLightWeaponResearch1")
			{
				smallCity.playerScript.InfantryLightWeaponResearch1 = 1;
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryLightWeaponResearch2")
			{
				smallCity.playerScript.InfantryLightWeaponResearch2 = 1;
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryLightWeaponResearch3")
			{
				smallCity.playerScript.InfantryLightWeaponResearch3 = 1;
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryLightWeaponResearch4point1")
			{
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
				smallCity.playerScript.InfantryLightWeaponResearch4point1 = 1;
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryLightWeaponResearch4point2")
			{
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
				smallCity.playerScript.InfantryLightWeaponResearch4point2 = 1;
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryLightWeaponResearch11")
			{
				smallCity.playerScript.InfantryLightWeaponResearch11 = 1;
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryHeavyWeaponResearch1")
			{
				smallCity.playerScript.InfantryHeavyWeaponResearch1 = 1;
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryHeavyWeaponResearch2")
			{
				smallCity.playerScript.InfantryHeavyWeaponResearch2 = 1;
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryArmorResearch1")
			{
				smallCity.playerScript.InfantryArmorResearch1 = 1;
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryArmorResearch2")
			{
				smallCity.playerScript.InfantryArmorResearch2 = 1;
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryArmorResearch3")
			{
				smallCity.playerScript.InfantryArmorResearch3 = 1;
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryArmorResearch11")
			{
				smallCity.playerScript.InfantryArmorResearch11 = 1;
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryClothesResearch1")
			{
				smallCity.playerScript.InfantryClothesResearch1 = 1;
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryClothesResearch2")
			{
				smallCity.playerScript.InfantryClothesResearch2 = 1;
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
			}
			else if(smallCity.playerScript.CurrentResearch == "InfantryClothesResearch3")
			{
				smallCity.playerScript.InfantryClothesResearch3 = 1;
				smallCity.playerScript.CurrentResearch = "";
				smallCity.ResearchPanelIsActive = false;
				cityInventoryUI.ResearchPanel.SetActive(false);
			}
		}
	}
}
