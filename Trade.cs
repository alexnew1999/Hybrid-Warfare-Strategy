using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Trade : MonoBehaviour
{
	public GameObject resourceTradePanel;
	public CityInventoryUI cityInventoryUI;
	public CitySelectedData citySelectedData;
	public ItemsList itemsList;
	
	public int WoodCount = 0;
	public int WoodSellPrice = 10;
	public int WoodBuyPrice = 20;
	public GameObject WoodSellButton;
	public GameObject WoodBuyButton;
	public TextMeshProUGUI WoodCountText;
	public TextMeshProUGUI WoodSellPriceText;
	public TextMeshProUGUI WoodBuyPriceText;
	
	public int CoalCount = 0;
	public int CoalSellPrice = 10;
	public int CoalBuyPrice = 20;
	public GameObject CoalSellButton;
	public GameObject CoalBuyButton;
	public TextMeshProUGUI CoalCountText;
	public TextMeshProUGUI CoalSellPriceText;
	public TextMeshProUGUI CoalBuyPriceText;
	
	public int IronOreCount = 0;
	public int IronOreSellPrice = 10;
	public int IronOreBuyPrice = 20;
	public GameObject IronOreSellButton;
	public GameObject IronOreBuyButton;
	public TextMeshProUGUI IronOreCountText;
	public TextMeshProUGUI IronOreSellPriceText;
	public TextMeshProUGUI IronOreBuyPriceText;
	
	public int IronIgnotCount = 0;
	public int IronIgnotSellPrice = 20;
	public int IronIgnotBuyPrice = 40;
	public GameObject IronIgnotSellButton;
	public GameObject IronIgnotBuyButton;
	public TextMeshProUGUI IronIgnotCountText;
	public TextMeshProUGUI IronIgnotSellPriceText;
	public TextMeshProUGUI IronIgnotBuyPriceText;
	
	public int StoneCount = 0;
	public int StoneSellPrice = 10;
	public int StoneBuyPrice = 20;
	public GameObject StoneSellButton;
	public GameObject StoneBuyButton;
	public TextMeshProUGUI StoneCountText;
	public TextMeshProUGUI StoneSellPriceText;
	public TextMeshProUGUI StoneBuyPriceText;
	
	public int SaltpeterCount = 0;
	public int SaltpeterSellPrice = 10;
	public int SaltpeterBuyPrice = 20;
	public GameObject SaltpeterSellButton;
	public GameObject SaltpeterBuyButton;
	public TextMeshProUGUI SaltpeterCountText;
	public TextMeshProUGUI SaltpeterSellPriceText;
	public TextMeshProUGUI SaltpeterBuyPriceText;
	
	public int GunpowderCount = 0;
	public int GunpowderSellPrice = 20;
	public int GunpowderBuyPrice = 40;
	public GameObject GunpowderSellButton;
	public GameObject GunpowderBuyButton;
	public TextMeshProUGUI GunpowderCountText;
	public TextMeshProUGUI GunpowderSellPriceText;
	public TextMeshProUGUI GunpowderBuyPriceText;
	
	public int AluminiumOreCount = 0;
	public int AluminiumOreSellPrice = 15;
	public int AluminiumOreBuyPrice = 30;
	public GameObject AluminiumOreSellButton;
	public GameObject AluminiumOreBuyButton;
	public TextMeshProUGUI AluminiumOreCountText;
	public TextMeshProUGUI AluminiumOreSellPriceText;
	public TextMeshProUGUI AluminiumOreBuyPriceText;
	
	public int AluminiumIgnotCount = 0;
	public int AluminiumIgnotSellPrice = 25;
	public int AluminiumIgnotBuyPrice = 50;
	public GameObject AluminiumIgnotSellButton;
	public GameObject AluminiumIgnotBuyButton;
	public TextMeshProUGUI AluminiumIgnotCountText;
	public TextMeshProUGUI AluminiumIgnotSellPriceText;
	public TextMeshProUGUI AluminiumIgnotBuyPriceText;
	
	public int CopperOreCount = 0;
	public int CopperOreSellPrice = 10;
	public int CopperOreBuyPrice = 20;
	public GameObject CopperOreSellButton;
	public GameObject CopperOreBuyButton;
	public TextMeshProUGUI CopperOreCountText;
	public TextMeshProUGUI CopperOreSellPriceText;
	public TextMeshProUGUI CopperOreBuyPriceText;
	
	public int CopperIgnotCount = 0;
	public int CopperIgnotSellPrice = 20;
	public int CopperIgnotBuyPrice = 40;
	public GameObject CopperIgnotSellButton;
	public GameObject CopperIgnotBuyButton;
	public TextMeshProUGUI CopperIgnotCountText;
	public TextMeshProUGUI CopperIgnotSellPriceText;
	public TextMeshProUGUI CopperIgnotBuyPriceText;
	
	public int FlaxCount = 0;
	public int FlaxSellPrice = 10;
	public int FlaxBuyPrice = 20;
	public GameObject FlaxSellButton;
	public GameObject FlaxBuyButton;
	public TextMeshProUGUI FlaxCountText;
	public TextMeshProUGUI FlaxSellPriceText;
	public TextMeshProUGUI FlaxBuyPriceText;
	
	public int FlaxFabricCount = 0;
	public int FlaxFabricSellPrice = 20;
	public int FlaxFabricBuyPrice = 40;
	public GameObject FlaxFabricSellButton;
	public GameObject FlaxFabricBuyButton;
	public TextMeshProUGUI FlaxFabricCountText;
	public TextMeshProUGUI FlaxFabricSellPriceText;
	public TextMeshProUGUI FlaxFabricBuyPriceText;
	
	public int ResearchDataSellPrice = 25;
	public int ResearchDataBuyPrice = 50;
	public TextMeshProUGUI ResearchDataSellPriceText;
	public TextMeshProUGUI ResearchDataBuyPriceText;
	
	public int OilCount = 0;
	public int OilSellPrice = 15;
	public int OilBuyPrice = 30;
	public GameObject OilSellButton;
	public GameObject OilBuyButton;
	public TextMeshProUGUI OilCountText;
	public TextMeshProUGUI OilSellPriceText;
	public TextMeshProUGUI OilBuyPriceText;
	
	public int PetrolCount = 0;
	public int PetrolSellPrice = 5;
	public int PetrolBuyPrice = 10;
	public GameObject PetrolSellButton;
	public GameObject PetrolBuyButton;
	public TextMeshProUGUI PetrolCountText;
	public TextMeshProUGUI PetrolSellPriceText;
	public TextMeshProUGUI PetrolBuyPriceText;
	
	public int CobaltOreCount = 0;
	public int CobaltOreSellPrice = 15;
	public int CobaltOreBuyPrice = 30;
	public GameObject CobaltOreSellButton;
	public GameObject CobaltOreBuyButton;
	public TextMeshProUGUI CobaltOreCountText;
	public TextMeshProUGUI CobaltOreSellPriceText;
	public TextMeshProUGUI CobaltOreBuyPriceText;
	
	public int CobaltIgnotCount = 0;
	public int CobaltIgnotSellPrice = 25;
	public int CobaltIgnotBuyPrice = 50;
	public GameObject CobaltIgnotSellButton;
	public GameObject CobaltIgnotBuyButton;
	public TextMeshProUGUI CobaltIgnotCountText;
	public TextMeshProUGUI CobaltIgnotSellPriceText;
	public TextMeshProUGUI CobaltIgnotBuyPriceText;
	
	public int PlasticCount = 0;
	public int PlasticSellPrice = 40;
	public int PlasticBuyPrice = 80;
	public GameObject PlasticSellButton;
	public GameObject PlasticBuyButton;
	public TextMeshProUGUI PlasticCountText;
	public TextMeshProUGUI PlasticSellPriceText;
	public TextMeshProUGUI PlasticBuyPriceText;
	
	public int GrainCount = 0;
	public int GrainSellPrice = 10;
	public int GrainBuyPrice = 20;
	public GameObject GrainSellButton;
	public GameObject GrainBuyButton;
	public TextMeshProUGUI GrainCountText;
	public TextMeshProUGUI GrainSellPriceText;
	public TextMeshProUGUI GrainBuyPriceText;
	
	public int CarrotCount = 0;
	public int CarrotSellPrice = 10;
	public int CarrotBuyPrice = 20;
	public GameObject CarrotSellButton;
	public GameObject CarrotBuyButton;
	public TextMeshProUGUI CarrotCountText;
	public TextMeshProUGUI CarrotSellPriceText;
	public TextMeshProUGUI CarrotBuyPriceText;
	
	public int TomatoCount = 0;
	public int TomatoSellPrice = 10;
	public int TomatoBuyPrice = 20;
	public GameObject TomatoSellButton;
	public GameObject TomatoBuyButton;
	public TextMeshProUGUI TomatoCountText;
	public TextMeshProUGUI TomatoSellPriceText;
	public TextMeshProUGUI TomatoBuyPriceText;
	
	public int DoveCount = 0;
	public int DoveSellPrice = 15;
	public int DoveBuyPrice = 30;
	public GameObject DoveSellButton;
	public GameObject DoveBuyButton;
	public TextMeshProUGUI DoveCountText;
	public TextMeshProUGUI DoveSellPriceText;
	public TextMeshProUGUI DoveBuyPriceText;
	
	public int BreadCount = 0;
	public int BreadSellPrice = 25;
	public int BreadBuyPrice = 50;
	public GameObject BreadSellButton;
	public GameObject BreadBuyButton;
	public TextMeshProUGUI BreadCountText;
	public TextMeshProUGUI BreadSellPriceText;
	public TextMeshProUGUI BreadBuyPriceText;
	
	private void Start()
	{
		resourceTradePanel.SetActive(false);
	}
	
	public void OpenTradeList()
	{
		resourceTradePanel.SetActive(true);
		cityInventoryUI.characterInventoryUI.CityOrForgeInvButtonObj.SetActive(false);
		cityInventoryUI.characterInventoryUI.characterInventoryPanel.SetActive(false);
		WoodCountText.text = "Wood(" + WoodCount.ToString() + ")";
		WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
		WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
		CoalCountText.text = "Coal(" + CoalCount.ToString() + ")";
		CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
		CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
		IronOreCountText.text = "IronOre(" + IronOreCount.ToString() + ")";
		IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
		IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
		IronIgnotCountText.text = "IronIgnot(" + IronIgnotCount.ToString() + ")";
		IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
		IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
		StoneCountText.text = "Stone(" + StoneCount.ToString() + ")";
		StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
		StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
		SaltpeterCountText.text = "Saltpeter(" + SaltpeterCount.ToString() + ")";
		SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
		SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
		GunpowderCountText.text = "Gunpowder(" + GunpowderCount.ToString() + ")";
		GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
		GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
		AluminiumOreCountText.text = "AluminiumOre(" + AluminiumOreCount.ToString() + ")";
		AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
		AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
		AluminiumIgnotCountText.text = "AluminiumIgnot(" + AluminiumIgnotCount.ToString() + ")";
		AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
		AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
		CopperOreCountText.text = "CopperOre(" + CopperOreCount.ToString() + ")";
		CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
		CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
		CopperIgnotCountText.text = "CopperIgnot(" + CopperIgnotCount.ToString() + ")";
		CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
		CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
		FlaxCountText.text = "Flax(" + FlaxCount.ToString() + ")";
		FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
		FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
		FlaxFabricCountText.text = "FlaxFabric(" + FlaxFabricCount.ToString() + ")";
		FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
		FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
		OilCountText.text = "Oil(" + OilCount.ToString() + ")";
		OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
		OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
		ResearchDataSellPriceText.text = "Sell(" + ResearchDataSellPrice.ToString() + ")";
		ResearchDataBuyPriceText.text = "Buy(" + ResearchDataBuyPrice.ToString() + ")";
		GrainCountText.text = "Grain(" + GrainCount.ToString() + ")";
		GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
		GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
		CarrotCountText.text = "Carrot(" + CarrotCount.ToString() + ")";
		CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
		CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
		TomatoCountText.text = "Tomato(" + TomatoCount.ToString() + ")";
		TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
		TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
		CobaltOreCountText.text = "CobaltOre(" + CobaltOreCount.ToString() + ")";
		CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
		CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
		CobaltIgnotCountText.text = "CobaltIgnot(" + CobaltIgnotCount.ToString() + ")";
		CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
		CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
		PetrolCountText.text = "Petrol(" + PetrolCount.ToString() + ")";
		PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
		PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
		PlasticCountText.text = "Plastic(" + PlasticCount.ToString() + ")";
		PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
		PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
		DoveCountText.text = "Dove(" + DoveCount.ToString() + ")";
		DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
		DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
		BreadCountText.text = "Bread(" + BreadCount.ToString() + ")";
		BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
		BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
	}
	
	public void CloseTradeList()
	{
		resourceTradePanel.SetActive(false);
	}
	
	public void BuyWood()
	{
		if(WoodCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= WoodBuyPrice)
			{
				int itemIDToAdd = 1001;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject WoodenLog = itemsList.CreateItemObject("Wooden Log", 1001, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Wooden Log");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(WoodenLog.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - WoodBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					WoodCount --;
					WoodCountText.text = "Wood(" + WoodCount.ToString() + ")";
					if(WoodCount == 0)
					{
						WoodBuyPrice = 20;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 10;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 0 && WoodCount <= 10)
					{
						WoodBuyPrice = 18;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 9;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 10 && WoodCount <= 20)
					{
						WoodBuyPrice = 16;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 8;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 20 && WoodCount <= 30)
					{
						WoodBuyPrice = 14;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 7;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 30 && WoodCount <= 40)
					{
						WoodBuyPrice = 12;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 6;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 40 && WoodCount <= 50)
					{
						WoodBuyPrice = 10;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 5;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 50 && WoodCount <= 60)
					{
						WoodBuyPrice = 8;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 4;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 60 && WoodCount <= 70)
					{
						WoodBuyPrice = 6;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 3;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 70 && WoodCount <= 80)
					{
						WoodBuyPrice = 4;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 2;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 80 && WoodCount <= 99)
					{
						WoodBuyPrice = 2;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 1;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject WoodenLog = ExistedItem.GetComponent<ItemObject>();
					WoodenLog.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - WoodBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					WoodCount --;
					WoodCountText.text = "Wood(" + WoodCount.ToString() + ")";
					if(WoodCount == 0)
					{
						WoodBuyPrice = 20;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 10;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 0 && WoodCount <= 10)
					{
						WoodBuyPrice = 18;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 9;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 10 && WoodCount <= 20)
					{
						WoodBuyPrice = 16;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 8;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 20 && WoodCount <= 30)
					{
						WoodBuyPrice = 14;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 7;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 30 && WoodCount <= 40)
					{
						WoodBuyPrice = 12;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 6;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 40 && WoodCount <= 50)
					{
						WoodBuyPrice = 10;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 5;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 50 && WoodCount <= 60)
					{
						WoodBuyPrice = 8;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 4;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 60 && WoodCount <= 70)
					{
						WoodBuyPrice = 6;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 3;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 70 && WoodCount <= 80)
					{
						WoodBuyPrice = 4;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 2;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					else if(WoodCount > 80 && WoodCount <= 99)
					{
						WoodBuyPrice = 2;
						WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
						WoodSellPrice = 1;
						WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellWood()
	{
		if(WoodCount < 100)
		{
			int itemIDToRemove = 1001;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + WoodSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				WoodCount ++;
				WoodCountText.text = "Wood(" + WoodCount.ToString() + ")";
				if(WoodCount == 0)
				{
					WoodBuyPrice = 20;
					WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
					WoodSellPrice = 10;
					WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
				}
				else if(WoodCount > 0 && WoodCount <= 10)
				{
					WoodBuyPrice = 18;
					WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
					WoodSellPrice = 9;
					WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
				}
				else if(WoodCount > 10 && WoodCount <= 20)
				{
					WoodBuyPrice = 16;
					WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
					WoodSellPrice = 8;
					WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
				}
				else if(WoodCount > 20 && WoodCount <= 30)
				{
					WoodBuyPrice = 14;
					WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
					WoodSellPrice = 7;
					WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
				}
				else if(WoodCount > 30 && WoodCount <= 40)
				{
					WoodBuyPrice = 12;
					WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
					WoodSellPrice = 6;
					WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
				}
				else if(WoodCount > 40 && WoodCount <= 50)
				{
					WoodBuyPrice = 10;
					WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
					WoodSellPrice = 5;
					WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
				}
				else if(WoodCount > 50 && WoodCount <= 60)
				{
					WoodBuyPrice = 8;
					WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
					WoodSellPrice = 4;
					WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
				}
				else if(WoodCount > 60 && WoodCount <= 70)
				{
					WoodBuyPrice = 6;
					WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
					WoodSellPrice = 3;
					WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
				}
				else if(WoodCount > 70 && WoodCount <= 80)
				{
					WoodBuyPrice = 4;
					WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
					WoodSellPrice = 2;
					WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
				}
				else if(WoodCount > 80 && WoodCount <= 99)
				{
					WoodBuyPrice = 2;
					WoodBuyPriceText.text = "Buy(" + WoodBuyPrice.ToString() + ")";
					WoodSellPrice = 1;
					WoodSellPriceText.text = "Sell(" + WoodSellPrice.ToString() + ")";
				}
				ItemObject WoodenLog = ExistedItem.GetComponent<ItemObject>();
				WoodenLog.quantity --;
				if(WoodenLog.quantity == 0)
				{
					WoodenLog.inventorySlot.itemGameObject = null;
					WoodenLog.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyCoal()
	{
		if(CoalCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= CoalBuyPrice)
			{
				int itemIDToAdd = 1006;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject Coal = itemsList.CreateItemObject("Coal", 1006, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Coal");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(Coal.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - CoalBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					CoalCount --;
					CoalCountText.text = "Coal(" + CoalCount.ToString() + ")";
					if(CoalCount == 0)
					{
						CoalBuyPrice = 20;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 10;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 0 && CoalCount <= 10)
					{
						CoalBuyPrice = 18;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 9;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 10 && CoalCount <= 20)
					{
						CoalBuyPrice = 16;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 8;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 20 && CoalCount <= 30)
					{
						CoalBuyPrice = 14;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 7;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 30 && CoalCount <= 40)
					{
						CoalBuyPrice = 12;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 6;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 40 && CoalCount <= 50)
					{
						CoalBuyPrice = 10;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 5;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 50 && CoalCount <= 60)
					{
						CoalBuyPrice = 8;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 4;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 60 && CoalCount <= 70)
					{
						CoalBuyPrice = 6;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 3;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 70 && CoalCount <= 80)
					{
						CoalBuyPrice = 4;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 2;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 80 && CoalCount <= 99)
					{
						CoalBuyPrice = 2;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 1;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject Coal = ExistedItem.GetComponent<ItemObject>();
					Coal.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - CoalBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					CoalCount --;
					CoalCountText.text = "Coal(" + CoalCount.ToString() + ")";
					if(CoalCount == 0)
					{
						CoalBuyPrice = 20;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 10;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 0 && CoalCount <= 10)
					{
						CoalBuyPrice = 18;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 9;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 10 && CoalCount <= 20)
					{
						CoalBuyPrice = 16;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 8;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 20 && CoalCount <= 30)
					{
						CoalBuyPrice = 14;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 7;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 30 && CoalCount <= 40)
					{
						CoalBuyPrice = 12;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 6;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 40 && CoalCount <= 50)
					{
						CoalBuyPrice = 10;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 5;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 50 && CoalCount <= 60)
					{
						CoalBuyPrice = 8;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 4;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 60 && CoalCount <= 70)
					{
						CoalBuyPrice = 6;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 3;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 70 && CoalCount <= 80)
					{
						CoalBuyPrice = 4;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 2;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					else if(CoalCount > 80 && CoalCount <= 99)
					{
						CoalBuyPrice = 2;
						CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
						CoalSellPrice = 1;
						CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellCoal()
	{
		if(CoalCount < 100)
		{
			int itemIDToRemove = 1006;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + CoalSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				CoalCount ++;
				CoalCountText.text = "Coal(" + CoalCount.ToString() + ")";
				if(CoalCount == 0)
				{
					CoalBuyPrice = 20;
					CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
					CoalSellPrice = 10;
					CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
				}
				else if(CoalCount > 0 && CoalCount <= 10)
				{
					CoalBuyPrice = 18;
					CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
					CoalSellPrice = 9;
					CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
				}
				else if(CoalCount > 10 && CoalCount <= 20)
				{
					CoalBuyPrice = 16;
					CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
					CoalSellPrice = 8;
					CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
				}
				else if(CoalCount > 20 && CoalCount <= 30)
				{
					CoalBuyPrice = 14;
					CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
					CoalSellPrice = 7;
					CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
				}
				else if(CoalCount > 30 && CoalCount <= 40)
				{
					CoalBuyPrice = 12;
					CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
					CoalSellPrice = 6;
					CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
				}
				else if(CoalCount > 40 && CoalCount <= 50)
				{
					CoalBuyPrice = 10;
					CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
					CoalSellPrice = 5;
					CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
				}
				else if(CoalCount > 50 && CoalCount <= 60)
				{
					CoalBuyPrice = 8;
					CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
					CoalSellPrice = 4;
					CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
				}
				else if(CoalCount > 60 && CoalCount <= 70)
				{
					CoalBuyPrice = 6;
					CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
					CoalSellPrice = 3;
					CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
				}
				else if(CoalCount > 70 && CoalCount <= 80)
				{
					CoalBuyPrice = 4;
					CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
					CoalSellPrice = 2;
					CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
				}
				else if(CoalCount > 80 && CoalCount <= 99)
				{
					CoalBuyPrice = 2;
					CoalBuyPriceText.text = "Buy(" + CoalBuyPrice.ToString() + ")";
					CoalSellPrice = 1;
					CoalSellPriceText.text = "Sell(" + CoalSellPrice.ToString() + ")";
				}
				ItemObject Coal = ExistedItem.GetComponent<ItemObject>();
				Coal.quantity --;
				if(Coal.quantity == 0)
				{
					Coal.inventorySlot.itemGameObject = null;
					Coal.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyIronOre()
	{
		if(IronOreCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= IronOreBuyPrice)
			{
				int itemIDToAdd = 1003;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject IronOre = itemsList.CreateItemObject("Iron Ore", 1003, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Iron Ore");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(IronOre.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - IronOreBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					IronOreCount --;
					IronOreCountText.text = "IronOre(" + IronOreCount.ToString() + ")";
					if(IronOreCount == 0)
					{
						IronOreBuyPrice = 20;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 10;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 0 && IronOreCount <= 10)
					{
						IronOreBuyPrice = 18;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 9;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 10 && IronOreCount <= 20)
					{
						IronOreBuyPrice = 16;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 8;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 20 && IronOreCount <= 30)
					{
						IronOreBuyPrice = 14;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 7;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 30 && IronOreCount <= 40)
					{
						IronOreBuyPrice = 12;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 6;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 40 && IronOreCount <= 50)
					{
						IronOreBuyPrice = 10;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 5;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 50 && IronOreCount <= 60)
					{
						IronOreBuyPrice = 8;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 4;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 60 && IronOreCount <= 70)
					{
						IronOreBuyPrice = 6;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 3;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 70 && IronOreCount <= 80)
					{
						IronOreBuyPrice = 4;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 2;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 80 && IronOreCount <= 99)
					{
						IronOreBuyPrice = 2;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 1;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject IronOre = ExistedItem.GetComponent<ItemObject>();
					IronOre.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - IronOreBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					IronOreCount --;
					IronOreCountText.text = "IronOre(" + IronOreCount.ToString() + ")";
					if(IronOreCount == 0)
					{
						IronOreBuyPrice = 20;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 10;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 0 && IronOreCount <= 10)
					{
						IronOreBuyPrice = 18;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 9;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 10 && IronOreCount <= 20)
					{
						IronOreBuyPrice = 16;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 8;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 20 && IronOreCount <= 30)
					{
						IronOreBuyPrice = 14;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 7;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 30 && IronOreCount <= 40)
					{
						IronOreBuyPrice = 12;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 6;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 40 && IronOreCount <= 50)
					{
						IronOreBuyPrice = 10;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 5;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 50 && IronOreCount <= 60)
					{
						IronOreBuyPrice = 8;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 4;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 60 && IronOreCount <= 70)
					{
						IronOreBuyPrice = 6;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 3;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 70 && IronOreCount <= 80)
					{
						IronOreBuyPrice = 4;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 2;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					else if(IronOreCount > 80 && IronOreCount <= 99)
					{
						IronOreBuyPrice = 2;
						IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
						IronOreSellPrice = 1;
						IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellIronOre()
	{
		if(IronOreCount < 100)
		{
			int itemIDToRemove = 1003;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + IronOreSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				IronOreCount ++;
				IronOreCountText.text = "IronOre(" + IronOreCount.ToString() + ")";
				if(IronOreCount == 0)
				{
					IronOreBuyPrice = 20;
					IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
					IronOreSellPrice = 10;
					IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
				}
				else if(IronOreCount > 0 && IronOreCount <= 10)
				{
					IronOreBuyPrice = 18;
					IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
					IronOreSellPrice = 9;
					IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
				}
				else if(IronOreCount > 10 && IronOreCount <= 20)
				{
					IronOreBuyPrice = 16;
					IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
					IronOreSellPrice = 8;
					IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
				}
				else if(IronOreCount > 20 && IronOreCount <= 30)
				{
					IronOreBuyPrice = 14;
					IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
					IronOreSellPrice = 7;
					IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
				}
				else if(IronOreCount > 30 && IronOreCount <= 40)
				{
					IronOreBuyPrice = 12;
					IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
					IronOreSellPrice = 6;
					IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
				}
				else if(IronOreCount > 40 && IronOreCount <= 50)
				{
					IronOreBuyPrice = 10;
					IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
					IronOreSellPrice = 5;
					IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
				}
				else if(IronOreCount > 50 && IronOreCount <= 60)
				{
					IronOreBuyPrice = 8;
					IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
					IronOreSellPrice = 4;
					IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
				}
				else if(IronOreCount > 60 && IronOreCount <= 70)
				{
					IronOreBuyPrice = 6;
					IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
					IronOreSellPrice = 3;
					IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
				}
				else if(IronOreCount > 70 && IronOreCount <= 80)
				{
					IronOreBuyPrice = 4;
					IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
					IronOreSellPrice = 2;
					IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
				}
				else if(IronOreCount > 80 && IronOreCount <= 99)
				{
					IronOreBuyPrice = 2;
					IronOreBuyPriceText.text = "Buy(" + IronOreBuyPrice.ToString() + ")";
					IronOreSellPrice = 1;
					IronOreSellPriceText.text = "Sell(" + IronOreSellPrice.ToString() + ")";
				}
				ItemObject IronOre = ExistedItem.GetComponent<ItemObject>();
				IronOre.quantity --;
				if(IronOre.quantity == 0)
				{
					IronOre.inventorySlot.itemGameObject = null;
					IronOre.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyIronIgnot()
	{
		if(IronIgnotCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= IronIgnotBuyPrice)
			{
				int itemIDToAdd = 1002;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject IronIgnot = itemsList.CreateItemObject("Iron Ignot", 1002, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Iron Ignot");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(IronIgnot.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - IronIgnotBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					IronIgnotCount --;
					IronIgnotCountText.text = "Iron Ignot(" + IronIgnotCount.ToString() + ")";
					if(IronIgnotCount == 0)
					{
						IronIgnotBuyPrice = 40;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 20;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 0 && IronIgnotCount <= 10)
					{
						IronIgnotBuyPrice = 38;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 19;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 10 && IronIgnotCount <= 20)
					{
						IronIgnotBuyPrice = 36;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 18;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 20 && IronIgnotCount <= 30)
					{
						IronIgnotBuyPrice = 34;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 17;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 30 && IronIgnotCount <= 40)
					{
						IronIgnotBuyPrice = 32;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 16;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 40 && IronIgnotCount <= 50)
					{
						IronIgnotBuyPrice = 30;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 15;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 50 && IronIgnotCount <= 60)
					{
						IronIgnotBuyPrice = 28;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 14;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 60 && IronIgnotCount <= 70)
					{
						IronIgnotBuyPrice = 26;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 13;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 70 && IronIgnotCount <= 80)
					{
						IronIgnotBuyPrice = 24;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 12;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 80 && IronIgnotCount <= 90)
					{
						IronIgnotBuyPrice = 22;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 11;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 90 && IronIgnotCount <= 99)
					{
						IronIgnotBuyPrice = 20;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 10;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject IronIgnot = ExistedItem.GetComponent<ItemObject>();
					IronIgnot.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - IronIgnotBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					IronIgnotCount --;
					IronIgnotCountText.text = "Iron Ignot(" + IronIgnotCount.ToString() + ")";
					if(IronIgnotCount == 0)
					{
						IronIgnotBuyPrice = 40;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 20;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 0 && IronIgnotCount <= 10)
					{
						IronIgnotBuyPrice = 38;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 19;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 10 && IronIgnotCount <= 20)
					{
						IronIgnotBuyPrice = 36;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 18;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 20 && IronIgnotCount <= 30)
					{
						IronIgnotBuyPrice = 34;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 17;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 30 && IronIgnotCount <= 40)
					{
						IronIgnotBuyPrice = 32;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 16;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 40 && IronIgnotCount <= 50)
					{
						IronIgnotBuyPrice = 30;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 15;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 50 && IronIgnotCount <= 60)
					{
						IronIgnotBuyPrice = 28;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 14;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 60 && IronIgnotCount <= 70)
					{
						IronIgnotBuyPrice = 26;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 13;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 70 && IronIgnotCount <= 80)
					{
						IronIgnotBuyPrice = 24;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 12;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 80 && IronIgnotCount <= 99)
					{
						IronIgnotBuyPrice = 22;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 11;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					else if(IronIgnotCount > 90 && IronIgnotCount <= 99)
					{
						IronIgnotBuyPrice = 20;
						IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
						IronIgnotSellPrice = 10;
						IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellIronIgnot()
	{
		if(IronIgnotCount < 100)
		{
			int itemIDToRemove = 1002;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + IronIgnotSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				IronIgnotCount ++;
				IronIgnotCountText.text = "Iron Ignot(" + IronIgnotCount.ToString() + ")";
				if(IronIgnotCount == 0)
				{
					IronIgnotBuyPrice = 40;
					IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
					IronIgnotSellPrice = 20;
					IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
				}
				else if(IronIgnotCount > 0 && IronIgnotCount <= 10)
				{
					IronIgnotBuyPrice = 38;
					IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
					IronIgnotSellPrice = 19;
					IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
				}
				else if(IronIgnotCount > 10 && IronIgnotCount <= 20)
				{
					IronIgnotBuyPrice = 36;
					IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
					IronIgnotSellPrice = 18;
					IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
				}
				else if(IronIgnotCount > 20 && IronIgnotCount <= 30)
				{
					IronIgnotBuyPrice = 34;
					IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
					IronIgnotSellPrice = 17;
					IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
				}
				else if(IronIgnotCount > 30 && IronIgnotCount <= 40)
				{
					IronIgnotBuyPrice = 32;
					IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
					IronIgnotSellPrice = 16;
					IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
				}
				else if(IronIgnotCount > 40 && IronIgnotCount <= 50)
				{
					IronIgnotBuyPrice = 30;
					IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
					IronIgnotSellPrice = 15;
					IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
				}
				else if(IronIgnotCount > 50 && IronIgnotCount <= 60)
				{
					IronIgnotBuyPrice = 28;
					IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
					IronIgnotSellPrice = 14;
					IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
				}
				else if(IronIgnotCount > 60 && IronIgnotCount <= 70)
				{
					IronIgnotBuyPrice = 26;
					IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
					IronIgnotSellPrice = 13;
					IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
				}
				else if(IronIgnotCount > 70 && IronIgnotCount <= 80)
				{
					IronIgnotBuyPrice = 24;
					IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
					IronIgnotSellPrice = 12;
					IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
				}
				else if(IronIgnotCount > 80 && IronIgnotCount <= 99)
				{
					IronIgnotBuyPrice = 22;
					IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
					IronIgnotSellPrice = 11;
					IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
				}
				else if(IronIgnotCount > 90 && IronIgnotCount <= 99)
				{
					IronIgnotBuyPrice = 20;
					IronIgnotBuyPriceText.text = "Buy(" + IronIgnotBuyPrice.ToString() + ")";
					IronIgnotSellPrice = 10;
					IronIgnotSellPriceText.text = "Sell(" + IronIgnotSellPrice.ToString() + ")";
				}
				ItemObject IronIgnot = ExistedItem.GetComponent<ItemObject>();
				IronIgnot.quantity --;
				if(IronIgnot.quantity == 0)
				{
					IronIgnot.inventorySlot.itemGameObject = null;
					IronIgnot.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
		
	public void BuyStone()
	{
		if(StoneCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= StoneBuyPrice)
			{
				int itemIDToAdd = 1004;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject Stone = itemsList.CreateItemObject("Stone", 1004, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Stone");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(Stone.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - StoneBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					StoneCount --;
					StoneCountText.text = "Stone(" + StoneCount.ToString() + ")";
					if(StoneCount == 0)
					{
						StoneBuyPrice = 20;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 10;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 0 && StoneCount <= 10)
					{
						StoneBuyPrice = 18;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 9;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 10 && StoneCount <= 20)
					{
						StoneBuyPrice = 16;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 8;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 20 && StoneCount <= 30)
					{
						StoneBuyPrice = 14;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 7;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 30 && StoneCount <= 40)
					{
						StoneBuyPrice = 12;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 6;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 40 && StoneCount <= 50)
					{
						StoneBuyPrice = 10;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 5;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 50 && StoneCount <= 60)
					{
						StoneBuyPrice = 8;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 4;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 60 && StoneCount <= 70)
					{
						StoneBuyPrice = 6;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 3;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 70 && StoneCount <= 80)
					{
						StoneBuyPrice = 4;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 2;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 80 && StoneCount <= 99)
					{
						StoneBuyPrice = 2;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 1;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject Stone = ExistedItem.GetComponent<ItemObject>();
					Stone.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - StoneBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					StoneCount --;
					StoneCountText.text = "Stone(" + StoneCount.ToString() + ")";
					if(StoneCount == 0)
					{
						StoneBuyPrice = 20;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 10;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 0 && StoneCount <= 10)
					{
						StoneBuyPrice = 18;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 9;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 10 && StoneCount <= 20)
					{
						StoneBuyPrice = 16;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 8;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 20 && StoneCount <= 30)
					{
						StoneBuyPrice = 14;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 7;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 30 && StoneCount <= 40)
					{
						StoneBuyPrice = 12;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 6;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 40 && StoneCount <= 50)
					{
						StoneBuyPrice = 10;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 5;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 50 && StoneCount <= 60)
					{
						StoneBuyPrice = 8;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 4;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 60 && StoneCount <= 70)
					{
						StoneBuyPrice = 6;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 3;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 70 && StoneCount <= 80)
					{
						StoneBuyPrice = 4;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 2;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					else if(StoneCount > 80 && StoneCount <= 99)
					{
						StoneBuyPrice = 2;
						StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
						StoneSellPrice = 1;
						StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellStone()
	{
		if(StoneCount < 100)
		{
			int itemIDToRemove = 1004;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + StoneSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				StoneCount ++;
				StoneCountText.text = "Stone(" + StoneCount.ToString() + ")";
				if(StoneCount == 0)
				{
					StoneBuyPrice = 20;
					StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
					StoneSellPrice = 10;
					StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
				}
				else if(StoneCount > 0 && StoneCount <= 10)
				{
					StoneBuyPrice = 18;
					StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
					StoneSellPrice = 9;
					StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
				}
				else if(StoneCount > 10 && StoneCount <= 20)
				{
					StoneBuyPrice = 16;
					StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
					StoneSellPrice = 8;
					StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
				}
				else if(StoneCount > 20 && StoneCount <= 30)
				{
					StoneBuyPrice = 14;
					StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
					StoneSellPrice = 7;
					StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
				}
				else if(StoneCount > 30 && StoneCount <= 40)
				{
					StoneBuyPrice = 12;
					StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
					StoneSellPrice = 6;
					StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
				}
				else if(StoneCount > 40 && StoneCount <= 50)
				{
					StoneBuyPrice = 10;
					StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
					StoneSellPrice = 5;
					StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
				}
				else if(StoneCount > 50 && StoneCount <= 60)
				{
					StoneBuyPrice = 8;
					StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
					StoneSellPrice = 4;
					StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
				}
				else if(StoneCount > 60 && StoneCount <= 70)
				{
					StoneBuyPrice = 6;
					StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
					StoneSellPrice = 3;
					StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
				}
				else if(StoneCount > 70 && StoneCount <= 80)
				{
					StoneBuyPrice = 4;
					StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
					StoneSellPrice = 2;
					StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
				}
				else if(StoneCount > 80 && StoneCount <= 99)
				{
					StoneBuyPrice = 2;
					StoneBuyPriceText.text = "Buy(" + StoneBuyPrice.ToString() + ")";
					StoneSellPrice = 1;
					StoneSellPriceText.text = "Sell(" + StoneSellPrice.ToString() + ")";
				}
				ItemObject Stone = ExistedItem.GetComponent<ItemObject>();
				Stone.quantity --;
				if(Stone.quantity == 0)
				{
					Stone.inventorySlot.itemGameObject = null;
					Stone.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyGunpowder()
	{
		if(GunpowderCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= GunpowderBuyPrice)
			{
				int itemIDToAdd = 1007;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject Gunpowder = itemsList.CreateItemObject("Gunpowder", 1007, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Gunpowder");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(Gunpowder.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - GunpowderBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					GunpowderCount --;
					GunpowderCountText.text = "Gunpowder(" + GunpowderCount.ToString() + ")";
					if(GunpowderCount == 0)
					{
						GunpowderBuyPrice = 40;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 20;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 0 && GunpowderCount <= 10)
					{
						GunpowderBuyPrice = 38;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 19;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 10 && GunpowderCount <= 20)
					{
						GunpowderBuyPrice = 36;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 18;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 20 && GunpowderCount <= 30)
					{
						GunpowderBuyPrice = 34;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 17;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 30 && GunpowderCount <= 40)
					{
						GunpowderBuyPrice = 32;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 16;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 40 && GunpowderCount <= 50)
					{
						GunpowderBuyPrice = 30;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 15;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 50 && GunpowderCount <= 60)
					{
						GunpowderBuyPrice = 28;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 14;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 60 && GunpowderCount <= 70)
					{
						GunpowderBuyPrice = 26;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 13;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 70 && GunpowderCount <= 80)
					{
						GunpowderBuyPrice = 24;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 12;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 80 && GunpowderCount <= 90)
					{
						GunpowderBuyPrice = 22;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 11;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 90 && GunpowderCount <= 99)
					{
						GunpowderBuyPrice = 20;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 10;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject Gunpowder = ExistedItem.GetComponent<ItemObject>();
					Gunpowder.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - GunpowderBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					GunpowderCount --;
					GunpowderCountText.text = "Gunpowder(" + GunpowderCount.ToString() + ")";
					if(GunpowderCount == 0)
					{
						GunpowderBuyPrice = 40;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 20;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 0 && GunpowderCount <= 10)
					{
						GunpowderBuyPrice = 38;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 19;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 10 && GunpowderCount <= 20)
					{
						GunpowderBuyPrice = 36;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 18;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 20 && GunpowderCount <= 30)
					{
						GunpowderBuyPrice = 34;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 17;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 30 && GunpowderCount <= 40)
					{
						GunpowderBuyPrice = 32;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 16;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 40 && GunpowderCount <= 50)
					{
						GunpowderBuyPrice = 30;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 15;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 50 && GunpowderCount <= 60)
					{
						GunpowderBuyPrice = 28;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 14;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 60 && GunpowderCount <= 70)
					{
						GunpowderBuyPrice = 26;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 13;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 70 && GunpowderCount <= 80)
					{
						GunpowderBuyPrice = 24;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 12;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 80 && GunpowderCount <= 99)
					{
						GunpowderBuyPrice = 22;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 11;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					else if(GunpowderCount > 90 && GunpowderCount <= 99)
					{
						GunpowderBuyPrice = 20;
						GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
						GunpowderSellPrice = 10;
						GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellGunpowder()
	{
		if(GunpowderCount < 100)
		{
			int itemIDToRemove = 1007;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + GunpowderSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				GunpowderCount ++;
				GunpowderCountText.text = "Gunpowder(" + GunpowderCount.ToString() + ")";
				if(GunpowderCount == 0)
				{
					GunpowderBuyPrice = 40;
					GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
					GunpowderSellPrice = 20;
					GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
				}
				else if(GunpowderCount > 0 && GunpowderCount <= 10)
				{
					GunpowderBuyPrice = 38;
					GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
					GunpowderSellPrice = 19;
					GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
				}
				else if(GunpowderCount > 10 && GunpowderCount <= 20)
				{
					GunpowderBuyPrice = 36;
					GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
					GunpowderSellPrice = 18;
					GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
				}
				else if(GunpowderCount > 20 && GunpowderCount <= 30)
				{
					GunpowderBuyPrice = 34;
					GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
					GunpowderSellPrice = 17;
					GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
				}
				else if(GunpowderCount > 30 && GunpowderCount <= 40)
				{
					GunpowderBuyPrice = 32;
					GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
					GunpowderSellPrice = 16;
					GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
				}
				else if(GunpowderCount > 40 && GunpowderCount <= 50)
				{
					GunpowderBuyPrice = 30;
					GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
					GunpowderSellPrice = 15;
					GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
				}
				else if(GunpowderCount > 50 && GunpowderCount <= 60)
				{
					GunpowderBuyPrice = 28;
					GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
					GunpowderSellPrice = 14;
					GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
				}
				else if(GunpowderCount > 60 && GunpowderCount <= 70)
				{
					GunpowderBuyPrice = 26;
					GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
					GunpowderSellPrice = 13;
					GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
				}
				else if(GunpowderCount > 70 && GunpowderCount <= 80)
				{
					GunpowderBuyPrice = 24;
					GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
					GunpowderSellPrice = 12;
					GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
				}
				else if(GunpowderCount > 80 && GunpowderCount <= 99)
				{
					GunpowderBuyPrice = 22;
					GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
					GunpowderSellPrice = 11;
					GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
				}
				else if(GunpowderCount > 90 && GunpowderCount <= 99)
				{
					GunpowderBuyPrice = 20;
					GunpowderBuyPriceText.text = "Buy(" + GunpowderBuyPrice.ToString() + ")";
					GunpowderSellPrice = 10;
					GunpowderSellPriceText.text = "Sell(" + GunpowderSellPrice.ToString() + ")";
				}
				ItemObject Gunpowder = ExistedItem.GetComponent<ItemObject>();
				Gunpowder.quantity --;
				if(Gunpowder.quantity == 0)
				{
					Gunpowder.inventorySlot.itemGameObject = null;
					Gunpowder.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
		
	public void BuySaltpeter()
	{
		if(SaltpeterCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= SaltpeterBuyPrice)
			{
				int itemIDToAdd = 1005;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject Saltpeter = itemsList.CreateItemObject("Saltpeter", 1005, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Saltpeter");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(Saltpeter.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - SaltpeterBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					SaltpeterCount --;
					SaltpeterCountText.text = "Saltpeter(" + SaltpeterCount.ToString() + ")";
					if(SaltpeterCount == 0)
					{
						SaltpeterBuyPrice = 20;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 10;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 0 && SaltpeterCount <= 10)
					{
						SaltpeterBuyPrice = 18;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 9;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 10 && SaltpeterCount <= 20)
					{
						SaltpeterBuyPrice = 16;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 8;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 20 && SaltpeterCount <= 30)
					{
						SaltpeterBuyPrice = 14;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 7;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 30 && SaltpeterCount <= 40)
					{
						SaltpeterBuyPrice = 12;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 6;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 40 && SaltpeterCount <= 50)
					{
						SaltpeterBuyPrice = 10;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 5;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 50 && SaltpeterCount <= 60)
					{
						SaltpeterBuyPrice = 8;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 4;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 60 && SaltpeterCount <= 70)
					{
						SaltpeterBuyPrice = 6;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 3;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 70 && SaltpeterCount <= 80)
					{
						SaltpeterBuyPrice = 4;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 2;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 80 && SaltpeterCount <= 99)
					{
						SaltpeterBuyPrice = 2;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 1;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject Saltpeter = ExistedItem.GetComponent<ItemObject>();
					Saltpeter.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - SaltpeterBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					SaltpeterCount --;
					SaltpeterCountText.text = "Saltpeter(" + SaltpeterCount.ToString() + ")";
					if(SaltpeterCount == 0)
					{
						SaltpeterBuyPrice = 20;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 10;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 0 && SaltpeterCount <= 10)
					{
						SaltpeterBuyPrice = 18;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 9;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 10 && SaltpeterCount <= 20)
					{
						SaltpeterBuyPrice = 16;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 8;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 20 && SaltpeterCount <= 30)
					{
						SaltpeterBuyPrice = 14;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 7;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 30 && SaltpeterCount <= 40)
					{
						SaltpeterBuyPrice = 12;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 6;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 40 && SaltpeterCount <= 50)
					{
						SaltpeterBuyPrice = 10;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 5;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 50 && SaltpeterCount <= 60)
					{
						SaltpeterBuyPrice = 8;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 4;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 60 && SaltpeterCount <= 70)
					{
						SaltpeterBuyPrice = 6;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 3;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 70 && SaltpeterCount <= 80)
					{
						SaltpeterBuyPrice = 4;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 2;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					else if(SaltpeterCount > 80 && SaltpeterCount <= 99)
					{
						SaltpeterBuyPrice = 2;
						SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
						SaltpeterSellPrice = 1;
						SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellSaltpeter()
	{
		if(SaltpeterCount < 100)
		{
			int itemIDToRemove = 1005;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + SaltpeterSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				SaltpeterCount ++;
				SaltpeterCountText.text = "Saltpeter(" + SaltpeterCount.ToString() + ")";
				if(SaltpeterCount == 0)
				{
					SaltpeterBuyPrice = 20;
					SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
					SaltpeterSellPrice = 10;
					SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
				}
				else if(SaltpeterCount > 0 && SaltpeterCount <= 10)
				{
					SaltpeterBuyPrice = 18;
					SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
					SaltpeterSellPrice = 9;
					SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
				}
				else if(SaltpeterCount > 10 && SaltpeterCount <= 20)
				{
					SaltpeterBuyPrice = 16;
					SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
					SaltpeterSellPrice = 8;
					SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
				}
				else if(SaltpeterCount > 20 && SaltpeterCount <= 30)
				{
					SaltpeterBuyPrice = 14;
					SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
					SaltpeterSellPrice = 7;
					SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
				}
				else if(SaltpeterCount > 30 && SaltpeterCount <= 40)
				{
					SaltpeterBuyPrice = 12;
					SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
					SaltpeterSellPrice = 6;
					SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
				}
				else if(SaltpeterCount > 40 && SaltpeterCount <= 50)
				{
					SaltpeterBuyPrice = 10;
					SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
					SaltpeterSellPrice = 5;
					SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
				}
				else if(SaltpeterCount > 50 && SaltpeterCount <= 60)
				{
					SaltpeterBuyPrice = 8;
					SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
					SaltpeterSellPrice = 4;
					SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
				}
				else if(SaltpeterCount > 60 && SaltpeterCount <= 70)
				{
					SaltpeterBuyPrice = 6;
					SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
					SaltpeterSellPrice = 3;
					SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
				}
				else if(SaltpeterCount > 70 && SaltpeterCount <= 80)
				{
					SaltpeterBuyPrice = 4;
					SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
					SaltpeterSellPrice = 2;
					SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
				}
				else if(SaltpeterCount > 80 && SaltpeterCount <= 99)
				{
					SaltpeterBuyPrice = 2;
					SaltpeterBuyPriceText.text = "Buy(" + SaltpeterBuyPrice.ToString() + ")";
					SaltpeterSellPrice = 1;
					SaltpeterSellPriceText.text = "Sell(" + SaltpeterSellPrice.ToString() + ")";
				}
				ItemObject Saltpeter = ExistedItem.GetComponent<ItemObject>();
				Saltpeter.quantity --;
				if(Saltpeter.quantity == 0)
				{
					Saltpeter.inventorySlot.itemGameObject = null;
					Saltpeter.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyAluminiumOre()
	{
		if(AluminiumOreCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= AluminiumOreBuyPrice)
			{
				int itemIDToAdd = 1008;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject AluminiumOre = itemsList.CreateItemObject("Aluminium Ore", 1008, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Aluminium Ore");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(AluminiumOre.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - AluminiumOreBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					AluminiumOreCount --;
					AluminiumOreCountText.text = "Aluminium Ore(" + AluminiumOreCount.ToString() + ")";
					if(AluminiumOreCount == 0)
					{
						AluminiumOreBuyPrice = 30;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 15;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 0 && AluminiumOreCount <= 10)
					{
						AluminiumOreBuyPrice = 28;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 14;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 10 && AluminiumOreCount <= 20)
					{
						AluminiumOreBuyPrice = 26;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 13;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 20 && AluminiumOreCount <= 30)
					{
						AluminiumOreBuyPrice = 24;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 12;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 30 && AluminiumOreCount <= 40)
					{
						AluminiumOreBuyPrice = 22;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 11;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 40 && AluminiumOreCount <= 50)
					{
						AluminiumOreBuyPrice = 20;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 10;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 50 && AluminiumOreCount <= 60)
					{
						AluminiumOreBuyPrice = 18;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 9;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 60 && AluminiumOreCount <= 70)
					{
						AluminiumOreBuyPrice = 16;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 8;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 70 && AluminiumOreCount <= 80)
					{
						AluminiumOreBuyPrice = 14;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 7;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 80 && AluminiumOreCount <= 90)
					{
						AluminiumOreBuyPrice = 12;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 6;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 90 && AluminiumOreCount <= 99)
					{
						AluminiumOreBuyPrice = 10;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 5;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject AluminiumOre = ExistedItem.GetComponent<ItemObject>();
					AluminiumOre.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - AluminiumOreBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					AluminiumOreCount --;
					AluminiumOreCountText.text = "AluminiumOre(" + AluminiumOreCount.ToString() + ")";
					if(AluminiumOreCount == 0)
					{
						AluminiumOreBuyPrice = 30;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 15;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 0 && AluminiumOreCount <= 10)
					{
						AluminiumOreBuyPrice = 28;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 14;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 10 && AluminiumOreCount <= 20)
					{
						AluminiumOreBuyPrice = 26;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 13;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 20 && AluminiumOreCount <= 30)
					{
						AluminiumOreBuyPrice = 24;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 12;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 30 && AluminiumOreCount <= 40)
					{
						AluminiumOreBuyPrice = 22;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 11;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 40 && AluminiumOreCount <= 50)
					{
						AluminiumOreBuyPrice = 20;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 10;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 50 && AluminiumOreCount <= 60)
					{
						AluminiumOreBuyPrice = 18;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 9;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 60 && AluminiumOreCount <= 70)
					{
						AluminiumOreBuyPrice = 16;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 8;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 70 && AluminiumOreCount <= 80)
					{
						AluminiumOreBuyPrice = 14;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 7;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 80 && AluminiumOreCount <= 90)
					{
						AluminiumOreBuyPrice = 12;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 6;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					else if(AluminiumOreCount > 90 && AluminiumOreCount <= 99)
					{
						AluminiumOreBuyPrice = 10;
						AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
						AluminiumOreSellPrice = 5;
						AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellAluminiumOre()
	{
		if(AluminiumOreCount < 100)
		{
			int itemIDToRemove = 1008;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + AluminiumOreSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				AluminiumOreCount ++;
				AluminiumOreCountText.text = "AluminiumOre(" + AluminiumOreCount.ToString() + ")";
				if(AluminiumOreCount == 0)
				{
					AluminiumOreBuyPrice = 30;
					AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
					AluminiumOreSellPrice = 15;
					AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
				}
				else if(AluminiumOreCount > 0 && AluminiumOreCount <= 10)
				{
					AluminiumOreBuyPrice = 28;
					AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
					AluminiumOreSellPrice = 14;
					AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
				}
				else if(AluminiumOreCount > 10 && AluminiumOreCount <= 20)
				{
					AluminiumOreBuyPrice = 26;
					AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
					AluminiumOreSellPrice = 13;
					AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
				}
				else if(AluminiumOreCount > 20 && AluminiumOreCount <= 30)
				{
					AluminiumOreBuyPrice = 24;
					AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
					AluminiumOreSellPrice = 12;
					AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
				}
				else if(AluminiumOreCount > 30 && AluminiumOreCount <= 40)
				{
					AluminiumOreBuyPrice = 22;
					AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
					AluminiumOreSellPrice = 11;
					AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
				}
				else if(AluminiumOreCount > 40 && AluminiumOreCount <= 50)
				{
					AluminiumOreBuyPrice = 20;
					AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
					AluminiumOreSellPrice = 10;
					AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
				}
				else if(AluminiumOreCount > 50 && AluminiumOreCount <= 60)
				{
					AluminiumOreBuyPrice = 18;
					AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
					AluminiumOreSellPrice = 9;
					AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
				}
				else if(AluminiumOreCount > 60 && AluminiumOreCount <= 70)
				{
					AluminiumOreBuyPrice = 16;
					AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
					AluminiumOreSellPrice = 8;
					AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
				}
				else if(AluminiumOreCount > 70 && AluminiumOreCount <= 80)
				{
					AluminiumOreBuyPrice = 14;
					AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
					AluminiumOreSellPrice = 7;
					AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
				}
				else if(AluminiumOreCount > 80 && AluminiumOreCount <= 90)
				{
					AluminiumOreBuyPrice = 12;
					AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
					AluminiumOreSellPrice = 6;
					AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
				}
				else if(AluminiumOreCount > 90 && AluminiumOreCount <= 99)
				{
					AluminiumOreBuyPrice = 10;
					AluminiumOreBuyPriceText.text = "Buy(" + AluminiumOreBuyPrice.ToString() + ")";
					AluminiumOreSellPrice = 5;
					AluminiumOreSellPriceText.text = "Sell(" + AluminiumOreSellPrice.ToString() + ")";
				}
				ItemObject AluminiumOre = ExistedItem.GetComponent<ItemObject>();
				AluminiumOre.quantity --;
				if(AluminiumOre.quantity == 0)
				{
					AluminiumOre.inventorySlot.itemGameObject = null;
					AluminiumOre.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyAluminiumIgnot()
	{
		if(AluminiumIgnotCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= AluminiumIgnotBuyPrice)
			{
				int itemIDToAdd = 1010;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject AluminiumIgnot = itemsList.CreateItemObject("Aluminium", 1010, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Aluminium");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(AluminiumIgnot.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - AluminiumIgnotBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					AluminiumIgnotCount --;
					AluminiumIgnotCountText.text = "Aluminium Ignot(" + AluminiumIgnotCount.ToString() + ")";
					if(AluminiumIgnotCount == 0)
					{
						AluminiumIgnotBuyPrice = 50;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 25;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 0 && AluminiumIgnotCount <= 10)
					{
						AluminiumIgnotBuyPrice = 48;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 24;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 10 && AluminiumIgnotCount <= 20)
					{
						AluminiumIgnotBuyPrice = 46;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 23;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 20 && AluminiumIgnotCount <= 30)
					{
						AluminiumIgnotBuyPrice = 44;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 22;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 30 && AluminiumIgnotCount <= 40)
					{
						AluminiumIgnotBuyPrice = 42;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 21;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 40 && AluminiumIgnotCount <= 50)
					{
						AluminiumIgnotBuyPrice = 40;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 20;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 50 && AluminiumIgnotCount <= 60)
					{
						AluminiumIgnotBuyPrice = 38;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 19;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 60 && AluminiumIgnotCount <= 70)
					{
						AluminiumIgnotBuyPrice = 36;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 18;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 70 && AluminiumIgnotCount <= 80)
					{
						AluminiumIgnotBuyPrice = 34;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 17;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 80 && AluminiumIgnotCount <= 90)
					{
						AluminiumIgnotBuyPrice = 32;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 16;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 90 && AluminiumIgnotCount <= 99)
					{
						AluminiumIgnotBuyPrice = 30;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 15;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject AluminiumIgnot = ExistedItem.GetComponent<ItemObject>();
					AluminiumIgnot.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - AluminiumIgnotBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					AluminiumIgnotCount --;
					AluminiumIgnotCountText.text = "Aluminium Ignot(" + AluminiumIgnotCount.ToString() + ")";
					if(AluminiumIgnotCount == 0)
					{
						AluminiumIgnotBuyPrice = 50;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 25;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 0 && AluminiumIgnotCount <= 10)
					{
						AluminiumIgnotBuyPrice = 48;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 24;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 10 && AluminiumIgnotCount <= 20)
					{
						AluminiumIgnotBuyPrice = 46;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 23;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 20 && AluminiumIgnotCount <= 30)
					{
						AluminiumIgnotBuyPrice = 44;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 22;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 30 && AluminiumIgnotCount <= 40)
					{
						AluminiumIgnotBuyPrice = 42;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 21;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 40 && AluminiumIgnotCount <= 50)
					{
						AluminiumIgnotBuyPrice = 40;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 20;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 50 && AluminiumIgnotCount <= 60)
					{
						AluminiumIgnotBuyPrice = 38;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 19;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 60 && AluminiumIgnotCount <= 70)
					{
						AluminiumIgnotBuyPrice = 36;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 18;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 70 && AluminiumIgnotCount <= 80)
					{
						AluminiumIgnotBuyPrice = 34;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 17;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 80 && AluminiumIgnotCount <= 90)
					{
						AluminiumIgnotBuyPrice = 32;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 16;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					else if(AluminiumIgnotCount > 90 && AluminiumIgnotCount <= 99)
					{
						AluminiumIgnotBuyPrice = 30;
						AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
						AluminiumIgnotSellPrice = 15;
						AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellAluminiumIgnot()
	{
		if(AluminiumIgnotCount < 100)
		{
			int itemIDToRemove = 1010;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + AluminiumIgnotSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				AluminiumIgnotCount ++;
				AluminiumIgnotCountText.text = "Aluminium Ignot(" + AluminiumIgnotCount.ToString() + ")";
				if(AluminiumIgnotCount == 0)
				{
					AluminiumIgnotBuyPrice = 50;
					AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
					AluminiumIgnotSellPrice = 25;
					AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
				}
				else if(AluminiumIgnotCount > 0 && AluminiumIgnotCount <= 10)
				{
					AluminiumIgnotBuyPrice = 48;
					AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
					AluminiumIgnotSellPrice = 24;
					AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
				}
				else if(AluminiumIgnotCount > 10 && AluminiumIgnotCount <= 20)
				{
					AluminiumIgnotBuyPrice = 46;
					AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
					AluminiumIgnotSellPrice = 23;
					AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
				}
				else if(AluminiumIgnotCount > 20 && AluminiumIgnotCount <= 30)
				{
					AluminiumIgnotBuyPrice = 44;
					AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
					AluminiumIgnotSellPrice = 22;
					AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
				}
				else if(AluminiumIgnotCount > 30 && AluminiumIgnotCount <= 40)
				{
					AluminiumIgnotBuyPrice = 42;
					AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
					AluminiumIgnotSellPrice = 21;
					AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
				}
				else if(AluminiumIgnotCount > 40 && AluminiumIgnotCount <= 50)
				{
					AluminiumIgnotBuyPrice = 40;
					AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
					AluminiumIgnotSellPrice = 20;
					AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
				}
				else if(AluminiumIgnotCount > 50 && AluminiumIgnotCount <= 60)
				{
					AluminiumIgnotBuyPrice = 38;
					AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
					AluminiumIgnotSellPrice = 19;
					AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
				}
				else if(AluminiumIgnotCount > 60 && AluminiumIgnotCount <= 70)
				{
					AluminiumIgnotBuyPrice = 36;
					AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
					AluminiumIgnotSellPrice = 18;
					AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
				}
				else if(AluminiumIgnotCount > 70 && AluminiumIgnotCount <= 80)
				{
					AluminiumIgnotBuyPrice = 34;
					AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
					AluminiumIgnotSellPrice = 17;
					AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
				}
				else if(AluminiumIgnotCount > 80 && AluminiumIgnotCount <= 90)
				{
					AluminiumIgnotBuyPrice = 32;
					AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
					AluminiumIgnotSellPrice = 16;
					AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
				}
				else if(AluminiumIgnotCount > 90 && AluminiumIgnotCount <= 99)
				{
					AluminiumIgnotBuyPrice = 30;
					AluminiumIgnotBuyPriceText.text = "Buy(" + AluminiumIgnotBuyPrice.ToString() + ")";
					AluminiumIgnotSellPrice = 15;
					AluminiumIgnotSellPriceText.text = "Sell(" + AluminiumIgnotSellPrice.ToString() + ")";
				}
				ItemObject AluminiumIgnot = ExistedItem.GetComponent<ItemObject>();
				AluminiumIgnot.quantity --;
				if(AluminiumIgnot.quantity == 0)
				{
					AluminiumIgnot.inventorySlot.itemGameObject = null;
					AluminiumIgnot.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyCopperOre()
	{
		if(CopperOreCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= CopperOreBuyPrice)
			{
				int itemIDToAdd = 1011;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject CopperOre = itemsList.CreateItemObject("Copper Ore", 1011, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Copper Ore");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(CopperOre.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - CopperOreBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					CopperOreCount --;
					CopperOreCountText.text = "Copper Ore(" + CopperOreCount.ToString() + ")";
					if(CopperOreCount == 0)
					{
						CopperOreBuyPrice = 20;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 10;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 0 && CopperOreCount <= 10)
					{
						CopperOreBuyPrice = 18;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 9;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 10 && CopperOreCount <= 20)
					{
						CopperOreBuyPrice = 16;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 8;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 20 && CopperOreCount <= 30)
					{
						CopperOreBuyPrice = 14;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 7;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 30 && CopperOreCount <= 40)
					{
						CopperOreBuyPrice = 12;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 6;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 40 && CopperOreCount <= 50)
					{
						CopperOreBuyPrice = 10;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 5;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 50 && CopperOreCount <= 60)
					{
						CopperOreBuyPrice = 8;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 4;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 60 && CopperOreCount <= 70)
					{
						CopperOreBuyPrice = 6;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 3;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 70 && CopperOreCount <= 80)
					{
						CopperOreBuyPrice = 4;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 2;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 80 && CopperOreCount <= 99)
					{
						CopperOreBuyPrice = 2;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 1;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject CopperOre = ExistedItem.GetComponent<ItemObject>();
					CopperOre.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - CopperOreBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					CopperOreCount --;
					CopperOreCountText.text = "CopperOre(" + CopperOreCount.ToString() + ")";
					if(CopperOreCount == 0)
					{
						CopperOreBuyPrice = 20;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 10;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 0 && CopperOreCount <= 10)
					{
						CopperOreBuyPrice = 18;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 9;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 10 && CopperOreCount <= 20)
					{
						CopperOreBuyPrice = 16;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 8;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 20 && CopperOreCount <= 30)
					{
						CopperOreBuyPrice = 14;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 7;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 30 && CopperOreCount <= 40)
					{
						CopperOreBuyPrice = 12;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 6;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 40 && CopperOreCount <= 50)
					{
						CopperOreBuyPrice = 10;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 5;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 50 && CopperOreCount <= 60)
					{
						CopperOreBuyPrice = 8;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 4;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 60 && CopperOreCount <= 70)
					{
						CopperOreBuyPrice = 6;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 3;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 70 && CopperOreCount <= 80)
					{
						CopperOreBuyPrice = 4;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 2;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					else if(CopperOreCount > 80 && CopperOreCount <= 99)
					{
						CopperOreBuyPrice = 2;
						CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
						CopperOreSellPrice = 1;
						CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellCopperOre()
	{
		if(CopperOreCount < 100)
		{
			int itemIDToRemove = 1011;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + CopperOreSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				CopperOreCount ++;
				CopperOreCountText.text = "CopperOre(" + CopperOreCount.ToString() + ")";
				if(CopperOreCount == 0)
				{
					CopperOreBuyPrice = 20;
					CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
					CopperOreSellPrice = 10;
					CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
				}
				else if(CopperOreCount > 0 && CopperOreCount <= 10)
				{
					CopperOreBuyPrice = 18;
					CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
					CopperOreSellPrice = 9;
					CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
				}
				else if(CopperOreCount > 10 && CopperOreCount <= 20)
				{
					CopperOreBuyPrice = 16;
					CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
					CopperOreSellPrice = 8;
					CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
				}
				else if(CopperOreCount > 20 && CopperOreCount <= 30)
				{
					CopperOreBuyPrice = 14;
					CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
					CopperOreSellPrice = 7;
					CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
				}
				else if(CopperOreCount > 30 && CopperOreCount <= 40)
				{
					CopperOreBuyPrice = 12;
					CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
					CopperOreSellPrice = 6;
					CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
				}
				else if(CopperOreCount > 40 && CopperOreCount <= 50)
				{
					CopperOreBuyPrice = 10;
					CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
					CopperOreSellPrice = 5;
					CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
				}
				else if(CopperOreCount > 50 && CopperOreCount <= 60)
				{
					CopperOreBuyPrice = 8;
					CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
					CopperOreSellPrice = 4;
					CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
				}
				else if(CopperOreCount > 60 && CopperOreCount <= 70)
				{
					CopperOreBuyPrice = 6;
					CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
					CopperOreSellPrice = 3;
					CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
				}
				else if(CopperOreCount > 70 && CopperOreCount <= 80)
				{
					CopperOreBuyPrice = 4;
					CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
					CopperOreSellPrice = 2;
					CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
				}
				else if(CopperOreCount > 80 && CopperOreCount <= 99)
				{
					CopperOreBuyPrice = 2;
					CopperOreBuyPriceText.text = "Buy(" + CopperOreBuyPrice.ToString() + ")";
					CopperOreSellPrice = 1;
					CopperOreSellPriceText.text = "Sell(" + CopperOreSellPrice.ToString() + ")";
				}
				ItemObject CopperOre = ExistedItem.GetComponent<ItemObject>();
				CopperOre.quantity --;
				if(CopperOre.quantity == 0)
				{
					CopperOre.inventorySlot.itemGameObject = null;
					CopperOre.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyCopperIgnot()
	{
		if(CopperIgnotCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= CopperIgnotBuyPrice)
			{
				int itemIDToAdd = 1014;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject CopperIgnot = itemsList.CreateItemObject("Copper Ignot", 1014, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Copper Ignot");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(CopperIgnot.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - CopperIgnotBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					CopperIgnotCount --;
					CopperIgnotCountText.text = "Copper Ignot(" + CopperIgnotCount.ToString() + ")";
					if(CopperIgnotCount == 0)
					{
						CopperIgnotBuyPrice = 40;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 20;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 0 && CopperIgnotCount <= 10)
					{
						CopperIgnotBuyPrice = 38;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 19;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 10 && CopperIgnotCount <= 20)
					{
						CopperIgnotBuyPrice = 36;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 18;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 20 && CopperIgnotCount <= 30)
					{
						CopperIgnotBuyPrice = 34;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 17;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 30 && CopperIgnotCount <= 40)
					{
						CopperIgnotBuyPrice = 32;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 16;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 40 && CopperIgnotCount <= 50)
					{
						CopperIgnotBuyPrice = 30;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 15;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 50 && CopperIgnotCount <= 60)
					{
						CopperIgnotBuyPrice = 28;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 14;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 60 && CopperIgnotCount <= 70)
					{
						CopperIgnotBuyPrice = 26;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 13;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 70 && CopperIgnotCount <= 80)
					{
						CopperIgnotBuyPrice = 24;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 12;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 80 && CopperIgnotCount <= 90)
					{
						CopperIgnotBuyPrice = 22;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 11;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 90 && CopperIgnotCount <= 99)
					{
						CopperIgnotBuyPrice = 20;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 10;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject CopperIgnot = ExistedItem.GetComponent<ItemObject>();
					CopperIgnot.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - CopperIgnotBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					CopperIgnotCount --;
					CopperIgnotCountText.text = "Copper Ignot(" + CopperIgnotCount.ToString() + ")";
					if(CopperIgnotCount == 0)
					{
						CopperIgnotBuyPrice = 40;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 20;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 0 && CopperIgnotCount <= 10)
					{
						CopperIgnotBuyPrice = 38;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 19;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 10 && CopperIgnotCount <= 20)
					{
						CopperIgnotBuyPrice = 36;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 18;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 20 && CopperIgnotCount <= 30)
					{
						CopperIgnotBuyPrice = 34;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 17;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 30 && CopperIgnotCount <= 40)
					{
						CopperIgnotBuyPrice = 32;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 16;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 40 && CopperIgnotCount <= 50)
					{
						CopperIgnotBuyPrice = 30;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 15;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 50 && CopperIgnotCount <= 60)
					{
						CopperIgnotBuyPrice = 28;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 14;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 60 && CopperIgnotCount <= 70)
					{
						CopperIgnotBuyPrice = 26;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 13;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 70 && CopperIgnotCount <= 80)
					{
						CopperIgnotBuyPrice = 24;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 12;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 80 && CopperIgnotCount <= 99)
					{
						CopperIgnotBuyPrice = 22;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 11;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					else if(CopperIgnotCount > 90 && CopperIgnotCount <= 99)
					{
						CopperIgnotBuyPrice = 20;
						CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
						CopperIgnotSellPrice = 10;
						CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellCopperIgnot()
	{
		if(CopperIgnotCount < 100)
		{
			int itemIDToRemove = 1014;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + CopperIgnotSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				CopperIgnotCount ++;
				CopperIgnotCountText.text = "Copper Ignot(" + CopperIgnotCount.ToString() + ")";
				if(CopperIgnotCount == 0)
				{
					CopperIgnotBuyPrice = 40;
					CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
					CopperIgnotSellPrice = 20;
					CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
				}
				else if(CopperIgnotCount > 0 && CopperIgnotCount <= 10)
				{
					CopperIgnotBuyPrice = 38;
					CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
					CopperIgnotSellPrice = 19;
					CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
				}
				else if(CopperIgnotCount > 10 && CopperIgnotCount <= 20)
				{
					CopperIgnotBuyPrice = 36;
					CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
					CopperIgnotSellPrice = 18;
					CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
				}
				else if(CopperIgnotCount > 20 && CopperIgnotCount <= 30)
				{
					CopperIgnotBuyPrice = 34;
					CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
					CopperIgnotSellPrice = 17;
					CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
				}
				else if(CopperIgnotCount > 30 && CopperIgnotCount <= 40)
				{
					CopperIgnotBuyPrice = 32;
					CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
					CopperIgnotSellPrice = 16;
					CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
				}
				else if(CopperIgnotCount > 40 && CopperIgnotCount <= 50)
				{
					CopperIgnotBuyPrice = 30;
					CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
					CopperIgnotSellPrice = 15;
					CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
				}
				else if(CopperIgnotCount > 50 && CopperIgnotCount <= 60)
				{
					CopperIgnotBuyPrice = 28;
					CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
					CopperIgnotSellPrice = 14;
					CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
				}
				else if(CopperIgnotCount > 60 && CopperIgnotCount <= 70)
				{
					CopperIgnotBuyPrice = 26;
					CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
					CopperIgnotSellPrice = 13;
					CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
				}
				else if(CopperIgnotCount > 70 && CopperIgnotCount <= 80)
				{
					CopperIgnotBuyPrice = 24;
					CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
					CopperIgnotSellPrice = 12;
					CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
				}
				else if(CopperIgnotCount > 80 && CopperIgnotCount <= 99)
				{
					CopperIgnotBuyPrice = 22;
					CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
					CopperIgnotSellPrice = 11;
					CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
				}
				else if(CopperIgnotCount > 90 && CopperIgnotCount <= 99)
				{
					CopperIgnotBuyPrice = 20;
					CopperIgnotBuyPriceText.text = "Buy(" + CopperIgnotBuyPrice.ToString() + ")";
					CopperIgnotSellPrice = 10;
					CopperIgnotSellPriceText.text = "Sell(" + CopperIgnotSellPrice.ToString() + ")";
				}
				ItemObject CopperIgnot = ExistedItem.GetComponent<ItemObject>();
				CopperIgnot.quantity --;
				if(CopperIgnot.quantity == 0)
				{
					CopperIgnot.inventorySlot.itemGameObject = null;
					CopperIgnot.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyFlax()
	{
		if(FlaxCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= FlaxBuyPrice)
			{
				int itemIDToAdd = 1012;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject Flax = itemsList.CreateItemObject("Flax", 1012, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Flax");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(Flax.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - FlaxBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					FlaxCount --;
					FlaxCountText.text = "Flax(" + FlaxCount.ToString() + ")";
					if(FlaxCount == 0)
					{
						FlaxBuyPrice = 20;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 10;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 0 && FlaxCount <= 10)
					{
						FlaxBuyPrice = 18;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 9;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 10 && FlaxCount <= 20)
					{
						FlaxBuyPrice = 16;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 8;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 20 && FlaxCount <= 30)
					{
						FlaxBuyPrice = 14;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 7;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 30 && FlaxCount <= 40)
					{
						FlaxBuyPrice = 12;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 6;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 40 && FlaxCount <= 50)
					{
						FlaxBuyPrice = 10;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 5;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 50 && FlaxCount <= 60)
					{
						FlaxBuyPrice = 8;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 4;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 60 && FlaxCount <= 70)
					{
						FlaxBuyPrice = 6;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 3;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 70 && FlaxCount <= 80)
					{
						FlaxBuyPrice = 4;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 2;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 80 && FlaxCount <= 99)
					{
						FlaxBuyPrice = 2;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 1;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject Flax = ExistedItem.GetComponent<ItemObject>();
					Flax.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - FlaxBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					FlaxCount --;
					FlaxCountText.text = "Flax(" + FlaxCount.ToString() + ")";
					if(FlaxCount == 0)
					{
						FlaxBuyPrice = 20;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 10;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 0 && FlaxCount <= 10)
					{
						FlaxBuyPrice = 18;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 9;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 10 && FlaxCount <= 20)
					{
						FlaxBuyPrice = 16;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 8;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 20 && FlaxCount <= 30)
					{
						FlaxBuyPrice = 14;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 7;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 30 && FlaxCount <= 40)
					{
						FlaxBuyPrice = 12;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 6;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 40 && FlaxCount <= 50)
					{
						FlaxBuyPrice = 10;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 5;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 50 && FlaxCount <= 60)
					{
						FlaxBuyPrice = 8;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 4;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 60 && FlaxCount <= 70)
					{
						FlaxBuyPrice = 6;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 3;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 70 && FlaxCount <= 80)
					{
						FlaxBuyPrice = 4;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 2;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					else if(FlaxCount > 80 && FlaxCount <= 99)
					{
						FlaxBuyPrice = 2;
						FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
						FlaxSellPrice = 1;
						FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellFlax()
	{
		if(FlaxCount < 100)
		{
			int itemIDToRemove = 1012;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + FlaxSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				FlaxCount ++;
				FlaxCountText.text = "Flax(" + FlaxCount.ToString() + ")";
				if(FlaxCount == 0)
				{
					FlaxBuyPrice = 20;
					FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
					FlaxSellPrice = 10;
					FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
				}
				else if(FlaxCount > 0 && FlaxCount <= 10)
				{
					FlaxBuyPrice = 18;
					FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
					FlaxSellPrice = 9;
					FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
				}
				else if(FlaxCount > 10 && FlaxCount <= 20)
				{
					FlaxBuyPrice = 16;
					FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
					FlaxSellPrice = 8;
					FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
				}
				else if(FlaxCount > 20 && FlaxCount <= 30)
				{
					FlaxBuyPrice = 14;
					FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
					FlaxSellPrice = 7;
					FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
				}
				else if(FlaxCount > 30 && FlaxCount <= 40)
				{
					FlaxBuyPrice = 12;
					FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
					FlaxSellPrice = 6;
					FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
				}
				else if(FlaxCount > 40 && FlaxCount <= 50)
				{
					FlaxBuyPrice = 10;
					FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
					FlaxSellPrice = 5;
					FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
				}
				else if(FlaxCount > 50 && FlaxCount <= 60)
				{
					FlaxBuyPrice = 8;
					FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
					FlaxSellPrice = 4;
					FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
				}
				else if(FlaxCount > 60 && FlaxCount <= 70)
				{
					FlaxBuyPrice = 6;
					FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
					FlaxSellPrice = 3;
					FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
				}
				else if(FlaxCount > 70 && FlaxCount <= 80)
				{
					FlaxBuyPrice = 4;
					FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
					FlaxSellPrice = 2;
					FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
				}
				else if(FlaxCount > 80 && FlaxCount <= 99)
				{
					FlaxBuyPrice = 2;
					FlaxBuyPriceText.text = "Buy(" + FlaxBuyPrice.ToString() + ")";
					FlaxSellPrice = 1;
					FlaxSellPriceText.text = "Sell(" + FlaxSellPrice.ToString() + ")";
				}
				ItemObject Flax = ExistedItem.GetComponent<ItemObject>();
				Flax.quantity --;
				if(Flax.quantity == 0)
				{
					Flax.inventorySlot.itemGameObject = null;
					Flax.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyFlaxFabric()
	{
		if(FlaxFabricCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= FlaxFabricBuyPrice)
			{
				int itemIDToAdd = 1013;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject FlaxFabric = itemsList.CreateItemObject("Flax Fabric", 1013, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Flax Fabric");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(FlaxFabric.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - FlaxFabricBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					FlaxFabricCount --;
					FlaxFabricCountText.text = "Flax Fabric(" + FlaxFabricCount.ToString() + ")";
					if(FlaxFabricCount == 0)
					{
						FlaxFabricBuyPrice = 40;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 20;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 0 && FlaxFabricCount <= 10)
					{
						FlaxFabricBuyPrice = 38;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 19;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 10 && FlaxFabricCount <= 20)
					{
						FlaxFabricBuyPrice = 36;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 18;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 20 && FlaxFabricCount <= 30)
					{
						FlaxFabricBuyPrice = 34;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 17;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 30 && FlaxFabricCount <= 40)
					{
						FlaxFabricBuyPrice = 32;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 16;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 40 && FlaxFabricCount <= 50)
					{
						FlaxFabricBuyPrice = 30;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 15;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 50 && FlaxFabricCount <= 60)
					{
						FlaxFabricBuyPrice = 28;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 14;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 60 && FlaxFabricCount <= 70)
					{
						FlaxFabricBuyPrice = 26;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 13;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 70 && FlaxFabricCount <= 80)
					{
						FlaxFabricBuyPrice = 24;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 12;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 80 && FlaxFabricCount <= 90)
					{
						FlaxFabricBuyPrice = 22;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 11;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 90 && FlaxFabricCount <= 99)
					{
						FlaxFabricBuyPrice = 20;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 10;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject FlaxFabric = ExistedItem.GetComponent<ItemObject>();
					FlaxFabric.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - FlaxFabricBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					FlaxFabricCount --;
					FlaxFabricCountText.text = "Copper Ignot(" + FlaxFabricCount.ToString() + ")";
					if(FlaxFabricCount == 0)
					{
						FlaxFabricBuyPrice = 40;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 20;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 0 && FlaxFabricCount <= 10)
					{
						FlaxFabricBuyPrice = 38;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 19;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 10 && FlaxFabricCount <= 20)
					{
						FlaxFabricBuyPrice = 36;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 18;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 20 && FlaxFabricCount <= 30)
					{
						FlaxFabricBuyPrice = 34;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 17;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 30 && FlaxFabricCount <= 40)
					{
						FlaxFabricBuyPrice = 32;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 16;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 40 && FlaxFabricCount <= 50)
					{
						FlaxFabricBuyPrice = 30;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 15;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 50 && FlaxFabricCount <= 60)
					{
						FlaxFabricBuyPrice = 28;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 14;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 60 && FlaxFabricCount <= 70)
					{
						FlaxFabricBuyPrice = 26;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 13;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 70 && FlaxFabricCount <= 80)
					{
						FlaxFabricBuyPrice = 24;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 12;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 80 && FlaxFabricCount <= 99)
					{
						FlaxFabricBuyPrice = 22;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 11;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					else if(FlaxFabricCount > 90 && FlaxFabricCount <= 99)
					{
						FlaxFabricBuyPrice = 20;
						FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
						FlaxFabricSellPrice = 10;
						FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellFlaxFabric()
	{
		if(FlaxFabricCount < 100)
		{
			int itemIDToRemove = 1013;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + FlaxFabricSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				FlaxFabricCount ++;
				FlaxFabricCountText.text = "Copper Ignot(" + FlaxFabricCount.ToString() + ")";
				if(FlaxFabricCount == 0)
				{
					FlaxFabricBuyPrice = 40;
					FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
					FlaxFabricSellPrice = 20;
					FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
				}
				else if(FlaxFabricCount > 0 && FlaxFabricCount <= 10)
				{
					FlaxFabricBuyPrice = 38;
					FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
					FlaxFabricSellPrice = 19;
					FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
				}
				else if(FlaxFabricCount > 10 && FlaxFabricCount <= 20)
				{
					FlaxFabricBuyPrice = 36;
					FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
					FlaxFabricSellPrice = 18;
					FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
				}
				else if(FlaxFabricCount > 20 && FlaxFabricCount <= 30)
				{
					FlaxFabricBuyPrice = 34;
					FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
					FlaxFabricSellPrice = 17;
					FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
				}
				else if(FlaxFabricCount > 30 && FlaxFabricCount <= 40)
				{
					FlaxFabricBuyPrice = 32;
					FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
					FlaxFabricSellPrice = 16;
					FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
				}
				else if(FlaxFabricCount > 40 && FlaxFabricCount <= 50)
				{
					FlaxFabricBuyPrice = 30;
					FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
					FlaxFabricSellPrice = 15;
					FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
				}
				else if(FlaxFabricCount > 50 && FlaxFabricCount <= 60)
				{
					FlaxFabricBuyPrice = 28;
					FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
					FlaxFabricSellPrice = 14;
					FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
				}
				else if(FlaxFabricCount > 60 && FlaxFabricCount <= 70)
				{
					FlaxFabricBuyPrice = 26;
					FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
					FlaxFabricSellPrice = 13;
					FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
				}
				else if(FlaxFabricCount > 70 && FlaxFabricCount <= 80)
				{
					FlaxFabricBuyPrice = 24;
					FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
					FlaxFabricSellPrice = 12;
					FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
				}
				else if(FlaxFabricCount > 80 && FlaxFabricCount <= 99)
				{
					FlaxFabricBuyPrice = 22;
					FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
					FlaxFabricSellPrice = 11;
					FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
				}
				else if(FlaxFabricCount > 90 && FlaxFabricCount <= 99)
				{
					FlaxFabricBuyPrice = 20;
					FlaxFabricBuyPriceText.text = "Buy(" + FlaxFabricBuyPrice.ToString() + ")";
					FlaxFabricSellPrice = 10;
					FlaxFabricSellPriceText.text = "Sell(" + FlaxFabricSellPrice.ToString() + ")";
				}
				ItemObject FlaxFabric = ExistedItem.GetComponent<ItemObject>();
				FlaxFabric.quantity --;
				if(FlaxFabric.quantity == 0)
				{
					FlaxFabric.inventorySlot.itemGameObject = null;
					FlaxFabric.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyResearchData()
	{
		if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= ResearchDataBuyPrice)
		{
			int itemIDToAdd = 1015;
			int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
			if(ExistedItem == null && freeSlotIndex != -1)
			{
				ItemObject ResearchData = itemsList.CreateItemObject("Research Data", 1015, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/ResearchData");
				citySelectedData.smallCity.cityInventory.AddItemToCityInventory(ResearchData.gameObject, freeSlotIndex);
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - ResearchDataBuyPrice;
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else if (ExistedItem != null)
			{
				ItemObject ResearchData = ExistedItem.GetComponent<ItemObject>();
				ResearchData.quantity ++;
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - ResearchDataBuyPrice;
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("Not enough free place in city.");
			}
		}
		else
		{
			Debug.Log("Not enough money.");
		}
	}
	
	public void SellResearchData()
	{
		int itemIDToRemove = 1015;
		GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
		if(ExistedItem != null)
		{
			citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + ResearchDataSellPrice;
			cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
			ItemObject ResearchData = ExistedItem.GetComponent<ItemObject>();
			ResearchData.quantity --;
			if(ResearchData.quantity == 0)
			{
				ResearchData.inventorySlot.itemGameObject = null;
				ResearchData.inventorySlot.isOccupied = false;
				Destroy(ExistedItem);
			}
			cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
		}
		else
		{
			Debug.Log("No item to sell.");
		}
	}
	
	public void BuyOil()
	{
		if(OilCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= OilBuyPrice)
			{
				int itemIDToAdd = 1009;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject Oil = itemsList.CreateItemObject("Oil", 1009, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Oil");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(Oil.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - OilBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					OilCount --;
					OilCountText.text = "Oil(" + OilCount.ToString() + ")";
					if(OilCount == 0)
					{
						OilBuyPrice = 30;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 15;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 0 && OilCount <= 10)
					{
						OilBuyPrice = 28;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 14;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 10 && OilCount <= 20)
					{
						OilBuyPrice = 26;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 13;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 20 && OilCount <= 30)
					{
						OilBuyPrice = 24;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 12;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 30 && OilCount <= 40)
					{
						OilBuyPrice = 22;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 11;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 40 && OilCount <= 50)
					{
						OilBuyPrice = 20;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 10;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 50 && OilCount <= 60)
					{
						OilBuyPrice = 18;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 9;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 60 && OilCount <= 70)
					{
						OilBuyPrice = 16;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 8;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 70 && OilCount <= 80)
					{
						OilBuyPrice = 14;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 7;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 80 && OilCount <= 90)
					{
						OilBuyPrice = 12;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 6;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 90 && OilCount <= 99)
					{
						OilBuyPrice = 10;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 5;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject Oil = ExistedItem.GetComponent<ItemObject>();
					Oil.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - OilBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					OilCount --;
					OilCountText.text = "Oil(" + OilCount.ToString() + ")";
					if(OilCount == 0)
					{
						OilBuyPrice = 30;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 15;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 0 && OilCount <= 10)
					{
						OilBuyPrice = 28;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 14;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 10 && OilCount <= 20)
					{
						OilBuyPrice = 26;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 13;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 20 && OilCount <= 30)
					{
						OilBuyPrice = 24;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 12;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 30 && OilCount <= 40)
					{
						OilBuyPrice = 22;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 11;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 40 && OilCount <= 50)
					{
						OilBuyPrice = 20;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 10;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 50 && OilCount <= 60)
					{
						OilBuyPrice = 18;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 9;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 60 && OilCount <= 70)
					{
						OilBuyPrice = 16;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 8;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 70 && OilCount <= 80)
					{
						OilBuyPrice = 14;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 7;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 80 && OilCount <= 90)
					{
						OilBuyPrice = 12;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 6;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					else if(OilCount > 90 && OilCount <= 99)
					{
						OilBuyPrice = 10;
						OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
						OilSellPrice = 5;
						OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellOil()
	{
		if(OilCount < 100)
		{
			int itemIDToRemove = 1009;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + OilSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				OilCount ++;
				OilCountText.text = "Oil(" + OilCount.ToString() + ")";
				if(OilCount == 0)
				{
					OilBuyPrice = 30;
					OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
					OilSellPrice = 15;
					OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
				}
				else if(OilCount > 0 && OilCount <= 10)
				{
					OilBuyPrice = 28;
					OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
					OilSellPrice = 14;
					OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
				}
				else if(OilCount > 10 && OilCount <= 20)
				{
					OilBuyPrice = 26;
					OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
					OilSellPrice = 13;
					OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
				}
				else if(OilCount > 20 && OilCount <= 30)
				{
					OilBuyPrice = 24;
					OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
					OilSellPrice = 12;
					OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
				}
				else if(OilCount > 30 && OilCount <= 40)
				{
					OilBuyPrice = 22;
					OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
					OilSellPrice = 11;
					OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
				}
				else if(OilCount > 40 && OilCount <= 50)
				{
					OilBuyPrice = 20;
					OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
					OilSellPrice = 10;
					OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
				}
				else if(OilCount > 50 && OilCount <= 60)
				{
					OilBuyPrice = 18;
					OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
					OilSellPrice = 9;
					OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
				}
				else if(OilCount > 60 && OilCount <= 70)
				{
					OilBuyPrice = 16;
					OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
					OilSellPrice = 8;
					OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
				}
				else if(OilCount > 70 && OilCount <= 80)
				{
					OilBuyPrice = 14;
					OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
					OilSellPrice = 7;
					OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
				}
				else if(OilCount > 80 && OilCount <= 90)
				{
					OilBuyPrice = 12;
					OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
					OilSellPrice = 6;
					OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
				}
				else if(OilCount > 90 && OilCount <= 99)
				{
					OilBuyPrice = 10;
					OilBuyPriceText.text = "Buy(" + OilBuyPrice.ToString() + ")";
					OilSellPrice = 5;
					OilSellPriceText.text = "Sell(" + OilSellPrice.ToString() + ")";
				}
				ItemObject Oil = ExistedItem.GetComponent<ItemObject>();
				Oil.quantity --;
				if(Oil.quantity == 0)
				{
					Oil.inventorySlot.itemGameObject = null;
					Oil.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyPetrol()
	{
		if(PetrolCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= PetrolBuyPrice)
			{
				int itemIDToAdd = 1018;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject Petrol = itemsList.CreateItemObject("Petrol", 1018, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Petrol");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(Petrol.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - PetrolBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					PetrolCount --;
					PetrolCountText.text = "Petrol(" + PetrolCount.ToString() + ")";
					if(PetrolCount == 0)
					{
						PetrolBuyPrice = 10;
						PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
						PetrolSellPrice = 5;
						PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
					}
					else if(PetrolCount > 0 && PetrolCount <= 20)
					{
						PetrolBuyPrice = 8;
						PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
						PetrolSellPrice = 4;
						PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
					}
					else if(PetrolCount > 20 && PetrolCount <= 40)
					{
						PetrolBuyPrice = 6;
						PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
						PetrolSellPrice = 3;
						PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
					}
					else if(PetrolCount > 40 && PetrolCount <= 60)
					{
						PetrolBuyPrice = 4;
						PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
						PetrolSellPrice = 2;
						PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
					}
					else if(PetrolCount > 60 && PetrolCount <= 99)
					{
						PetrolBuyPrice = 2;
						PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
						PetrolSellPrice = 1;
						PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject Petrol = ExistedItem.GetComponent<ItemObject>();
					Petrol.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - PetrolBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					PetrolCount --;
					PetrolCountText.text = "Petrol(" + PetrolCount.ToString() + ")";
					if(PetrolCount == 0)
					{
						PetrolBuyPrice = 10;
						PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
						PetrolSellPrice = 5;
						PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
					}
					else if(PetrolCount > 0 && PetrolCount <= 20)
					{
						PetrolBuyPrice = 8;
						PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
						PetrolSellPrice = 4;
						PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
					}
					else if(PetrolCount > 20 && PetrolCount <= 40)
					{
						PetrolBuyPrice = 6;
						PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
						PetrolSellPrice = 3;
						PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
					}
					else if(PetrolCount > 40 && PetrolCount <= 60)
					{
						PetrolBuyPrice = 4;
						PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
						PetrolSellPrice = 2;
						PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
					}
					else if(PetrolCount > 60 && PetrolCount <= 99)
					{
						PetrolBuyPrice = 2;
						PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
						PetrolSellPrice = 1;
						PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellPetrol()
	{
		if(PetrolCount < 100)
		{
			int itemIDToRemove = 1018;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + PetrolSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				PetrolCount ++;
				PetrolCountText.text = "Petrol(" + PetrolCount.ToString() + ")";
				if(PetrolCount == 0)
				{
					PetrolBuyPrice = 10;
					PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
					PetrolSellPrice = 5;
					PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
				}
				else if(PetrolCount > 0 && PetrolCount <= 20)
				{
					PetrolBuyPrice = 8;
					PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
					PetrolSellPrice = 4;
					PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
				}
				else if(PetrolCount > 20 && PetrolCount <= 40)
				{
					PetrolBuyPrice = 6;
					PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
					PetrolSellPrice = 3;
					PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
				}
				else if(PetrolCount > 40 && PetrolCount <= 60)
				{
					PetrolBuyPrice = 4;
					PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
					PetrolSellPrice = 2;
					PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
				}
				else if(PetrolCount > 60 && PetrolCount <= 99)
				{
					PetrolBuyPrice = 2;
					PetrolBuyPriceText.text = "Buy(" + PetrolBuyPrice.ToString() + ")";
					PetrolSellPrice = 1;
					PetrolSellPriceText.text = "Sell(" + PetrolSellPrice.ToString() + ")";
				}
				ItemObject Petrol = ExistedItem.GetComponent<ItemObject>();
				Petrol.quantity --;
				if(Petrol.quantity == 0)
				{
					Petrol.inventorySlot.itemGameObject = null;
					Petrol.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyCobaltOre()
	{
		if(CobaltOreCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= CobaltOreBuyPrice)
			{
				int itemIDToAdd = 1016;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject CobaltOre = itemsList.CreateItemObject("Cobalt Ore", 1016, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Cobalt Ore");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(CobaltOre.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - CobaltOreBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					CobaltOreCount --;
					CobaltOreCountText.text = "Cobalt Ore(" + CobaltOreCount.ToString() + ")";
					if(CobaltOreCount == 0)
					{
						CobaltOreBuyPrice = 30;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 15;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 0 && CobaltOreCount <= 10)
					{
						CobaltOreBuyPrice = 28;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 14;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 10 && CobaltOreCount <= 20)
					{
						CobaltOreBuyPrice = 26;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 13;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 20 && CobaltOreCount <= 30)
					{
						CobaltOreBuyPrice = 24;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 12;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 30 && CobaltOreCount <= 40)
					{
						CobaltOreBuyPrice = 22;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 11;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 40 && CobaltOreCount <= 50)
					{
						CobaltOreBuyPrice = 20;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 10;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 50 && CobaltOreCount <= 60)
					{
						CobaltOreBuyPrice = 18;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 9;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 60 && CobaltOreCount <= 70)
					{
						CobaltOreBuyPrice = 16;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 8;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 70 && CobaltOreCount <= 80)
					{
						CobaltOreBuyPrice = 14;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 7;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 80 && CobaltOreCount <= 90)
					{
						CobaltOreBuyPrice = 12;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 6;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 90 && CobaltOreCount <= 99)
					{
						CobaltOreBuyPrice = 10;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 5;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject CobaltOre = ExistedItem.GetComponent<ItemObject>();
					CobaltOre.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - CobaltOreBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					CobaltOreCount --;
					CobaltOreCountText.text = "CobaltOre(" + CobaltOreCount.ToString() + ")";
					if(CobaltOreCount == 0)
					{
						CobaltOreBuyPrice = 30;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 15;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 0 && CobaltOreCount <= 10)
					{
						CobaltOreBuyPrice = 28;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 14;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 10 && CobaltOreCount <= 20)
					{
						CobaltOreBuyPrice = 26;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 13;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 20 && CobaltOreCount <= 30)
					{
						CobaltOreBuyPrice = 24;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 12;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 30 && CobaltOreCount <= 40)
					{
						CobaltOreBuyPrice = 22;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 11;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 40 && CobaltOreCount <= 50)
					{
						CobaltOreBuyPrice = 20;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 10;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 50 && CobaltOreCount <= 60)
					{
						CobaltOreBuyPrice = 18;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 9;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 60 && CobaltOreCount <= 70)
					{
						CobaltOreBuyPrice = 16;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 8;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 70 && CobaltOreCount <= 80)
					{
						CobaltOreBuyPrice = 14;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 7;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 80 && CobaltOreCount <= 90)
					{
						CobaltOreBuyPrice = 12;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 6;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					else if(CobaltOreCount > 90 && CobaltOreCount <= 99)
					{
						CobaltOreBuyPrice = 10;
						CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
						CobaltOreSellPrice = 5;
						CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellCobaltOre()
	{
		if(CobaltOreCount < 100)
		{
			int itemIDToRemove = 1016;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + CobaltOreSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				CobaltOreCount ++;
				CobaltOreCountText.text = "CobaltOre(" + CobaltOreCount.ToString() + ")";
				if(CobaltOreCount == 0)
				{
					CobaltOreBuyPrice = 30;
					CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
					CobaltOreSellPrice = 15;
					CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
				}
				else if(CobaltOreCount > 0 && CobaltOreCount <= 10)
				{
					CobaltOreBuyPrice = 28;
					CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
					CobaltOreSellPrice = 14;
					CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
				}
				else if(CobaltOreCount > 10 && CobaltOreCount <= 20)
				{
					CobaltOreBuyPrice = 26;
					CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
					CobaltOreSellPrice = 13;
					CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
				}
				else if(CobaltOreCount > 20 && CobaltOreCount <= 30)
				{
					CobaltOreBuyPrice = 24;
					CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
					CobaltOreSellPrice = 12;
					CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
				}
				else if(CobaltOreCount > 30 && CobaltOreCount <= 40)
				{
					CobaltOreBuyPrice = 22;
					CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
					CobaltOreSellPrice = 11;
					CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
				}
				else if(CobaltOreCount > 40 && CobaltOreCount <= 50)
				{
					CobaltOreBuyPrice = 20;
					CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
					CobaltOreSellPrice = 10;
					CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
				}
				else if(CobaltOreCount > 50 && CobaltOreCount <= 60)
				{
					CobaltOreBuyPrice = 18;
					CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
					CobaltOreSellPrice = 9;
					CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
				}
				else if(CobaltOreCount > 60 && CobaltOreCount <= 70)
				{
					CobaltOreBuyPrice = 16;
					CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
					CobaltOreSellPrice = 8;
					CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
				}
				else if(CobaltOreCount > 70 && CobaltOreCount <= 80)
				{
					CobaltOreBuyPrice = 14;
					CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
					CobaltOreSellPrice = 7;
					CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
				}
				else if(CobaltOreCount > 80 && CobaltOreCount <= 90)
				{
					CobaltOreBuyPrice = 12;
					CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
					CobaltOreSellPrice = 6;
					CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
				}
				else if(CobaltOreCount > 90 && CobaltOreCount <= 99)
				{
					CobaltOreBuyPrice = 10;
					CobaltOreBuyPriceText.text = "Buy(" + CobaltOreBuyPrice.ToString() + ")";
					CobaltOreSellPrice = 5;
					CobaltOreSellPriceText.text = "Sell(" + CobaltOreSellPrice.ToString() + ")";
				}
				ItemObject CobaltOre = ExistedItem.GetComponent<ItemObject>();
				CobaltOre.quantity --;
				if(CobaltOre.quantity == 0)
				{
					CobaltOre.inventorySlot.itemGameObject = null;
					CobaltOre.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyCobaltIgnot()
	{
		if(CobaltIgnotCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= CobaltIgnotBuyPrice)
			{
				int itemIDToAdd = 1017;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject CobaltIgnot = itemsList.CreateItemObject("CobaltIgnot", 1017, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/CobaltIgnot");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(CobaltIgnot.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - CobaltIgnotBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					CobaltIgnotCount --;
					CobaltIgnotCountText.text = "Cobalt Ignot(" + CobaltIgnotCount.ToString() + ")";
					if(CobaltIgnotCount == 0)
					{
						CobaltIgnotBuyPrice = 50;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 25;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 0 && CobaltIgnotCount <= 10)
					{
						CobaltIgnotBuyPrice = 48;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 24;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 10 && CobaltIgnotCount <= 20)
					{
						CobaltIgnotBuyPrice = 46;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 23;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 20 && CobaltIgnotCount <= 30)
					{
						CobaltIgnotBuyPrice = 44;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 22;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 30 && CobaltIgnotCount <= 40)
					{
						CobaltIgnotBuyPrice = 42;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 21;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 40 && CobaltIgnotCount <= 50)
					{
						CobaltIgnotBuyPrice = 40;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 20;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 50 && CobaltIgnotCount <= 60)
					{
						CobaltIgnotBuyPrice = 38;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 19;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 60 && CobaltIgnotCount <= 70)
					{
						CobaltIgnotBuyPrice = 36;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 18;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 70 && CobaltIgnotCount <= 80)
					{
						CobaltIgnotBuyPrice = 34;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 17;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 80 && CobaltIgnotCount <= 90)
					{
						CobaltIgnotBuyPrice = 32;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 16;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 90 && CobaltIgnotCount <= 99)
					{
						CobaltIgnotBuyPrice = 30;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 15;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject CobaltIgnot = ExistedItem.GetComponent<ItemObject>();
					CobaltIgnot.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - CobaltIgnotBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					CobaltIgnotCount --;
					CobaltIgnotCountText.text = "Cobalt Ignot(" + CobaltIgnotCount.ToString() + ")";
					if(CobaltIgnotCount == 0)
					{
						CobaltIgnotBuyPrice = 50;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 25;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 0 && CobaltIgnotCount <= 10)
					{
						CobaltIgnotBuyPrice = 48;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 24;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 10 && CobaltIgnotCount <= 20)
					{
						CobaltIgnotBuyPrice = 46;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 23;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 20 && CobaltIgnotCount <= 30)
					{
						CobaltIgnotBuyPrice = 44;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 22;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 30 && CobaltIgnotCount <= 40)
					{
						CobaltIgnotBuyPrice = 42;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 21;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 40 && CobaltIgnotCount <= 50)
					{
						CobaltIgnotBuyPrice = 40;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 20;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 50 && CobaltIgnotCount <= 60)
					{
						CobaltIgnotBuyPrice = 38;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 19;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 60 && CobaltIgnotCount <= 70)
					{
						CobaltIgnotBuyPrice = 36;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 18;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 70 && CobaltIgnotCount <= 80)
					{
						CobaltIgnotBuyPrice = 34;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 17;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 80 && CobaltIgnotCount <= 90)
					{
						CobaltIgnotBuyPrice = 32;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 16;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					else if(CobaltIgnotCount > 90 && CobaltIgnotCount <= 99)
					{
						CobaltIgnotBuyPrice = 30;
						CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
						CobaltIgnotSellPrice = 15;
						CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellCobaltIgnot()
	{
		if(CobaltIgnotCount < 100)
		{
			int itemIDToRemove = 1017;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + CobaltIgnotSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				CobaltIgnotCount ++;
				CobaltIgnotCountText.text = "Cobalt Ignot(" + CobaltIgnotCount.ToString() + ")";
				if(CobaltIgnotCount == 0)
				{
					CobaltIgnotBuyPrice = 50;
					CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
					CobaltIgnotSellPrice = 25;
					CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
				}
				else if(CobaltIgnotCount > 0 && CobaltIgnotCount <= 10)
				{
					CobaltIgnotBuyPrice = 48;
					CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
					CobaltIgnotSellPrice = 24;
					CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
				}
				else if(CobaltIgnotCount > 10 && CobaltIgnotCount <= 20)
				{
					CobaltIgnotBuyPrice = 46;
					CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
					CobaltIgnotSellPrice = 23;
					CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
				}
				else if(CobaltIgnotCount > 20 && CobaltIgnotCount <= 30)
				{
					CobaltIgnotBuyPrice = 44;
					CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
					CobaltIgnotSellPrice = 22;
					CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
				}
				else if(CobaltIgnotCount > 30 && CobaltIgnotCount <= 40)
				{
					CobaltIgnotBuyPrice = 42;
					CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
					CobaltIgnotSellPrice = 21;
					CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
				}
				else if(CobaltIgnotCount > 40 && CobaltIgnotCount <= 50)
				{
					CobaltIgnotBuyPrice = 40;
					CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
					CobaltIgnotSellPrice = 20;
					CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
				}
				else if(CobaltIgnotCount > 50 && CobaltIgnotCount <= 60)
				{
					CobaltIgnotBuyPrice = 38;
					CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
					CobaltIgnotSellPrice = 19;
					CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
				}
				else if(CobaltIgnotCount > 60 && CobaltIgnotCount <= 70)
				{
					CobaltIgnotBuyPrice = 36;
					CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
					CobaltIgnotSellPrice = 18;
					CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
				}
				else if(CobaltIgnotCount > 70 && CobaltIgnotCount <= 80)
				{
					CobaltIgnotBuyPrice = 34;
					CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
					CobaltIgnotSellPrice = 17;
					CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
				}
				else if(CobaltIgnotCount > 80 && CobaltIgnotCount <= 90)
				{
					CobaltIgnotBuyPrice = 32;
					CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
					CobaltIgnotSellPrice = 16;
					CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
				}
				else if(CobaltIgnotCount > 90 && CobaltIgnotCount <= 99)
				{
					CobaltIgnotBuyPrice = 30;
					CobaltIgnotBuyPriceText.text = "Buy(" + CobaltIgnotBuyPrice.ToString() + ")";
					CobaltIgnotSellPrice = 15;
					CobaltIgnotSellPriceText.text = "Sell(" + CobaltIgnotSellPrice.ToString() + ")";
				}
				ItemObject CobaltIgnot = ExistedItem.GetComponent<ItemObject>();
				CobaltIgnot.quantity --;
				if(CobaltIgnot.quantity == 0)
				{
					CobaltIgnot.inventorySlot.itemGameObject = null;
					CobaltIgnot.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyPlastic()
	{
		if(PlasticCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= PlasticBuyPrice)
			{
				int itemIDToAdd = 1019;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject Plastic = itemsList.CreateItemObject("Plastic", 1019, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Plastic");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(Plastic.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - PlasticBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					PlasticCount --;
					PlasticCountText.text = "Cobalt Ignot(" + PlasticCount.ToString() + ")";
					if(PlasticCount == 0)
					{
						PlasticBuyPrice = 80;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 40;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 0 && PlasticCount <= 10)
					{
						PlasticBuyPrice = 78;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 39;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 10 && PlasticCount <= 20)
					{
						PlasticBuyPrice = 76;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 38;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 20 && PlasticCount <= 30)
					{
						PlasticBuyPrice = 74;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 37;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 30 && PlasticCount <= 40)
					{
						PlasticBuyPrice = 72;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 36;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 40 && PlasticCount <= 50)
					{
						PlasticBuyPrice = 70;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 35;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 50 && PlasticCount <= 60)
					{
						PlasticBuyPrice = 68;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 34;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 60 && PlasticCount <= 70)
					{
						PlasticBuyPrice = 66;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 33;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 70 && PlasticCount <= 80)
					{
						PlasticBuyPrice = 64;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 32;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 80 && PlasticCount <= 90)
					{
						PlasticBuyPrice = 62;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 31;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 90 && PlasticCount <= 99)
					{
						PlasticBuyPrice = 60;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 30;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject Plastic = ExistedItem.GetComponent<ItemObject>();
					Plastic.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - PlasticBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					PlasticCount --;
					PlasticCountText.text = "Cobalt Ignot(" + PlasticCount.ToString() + ")";
					if(PlasticCount == 0)
					{
						PlasticBuyPrice = 80;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 40;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 0 && PlasticCount <= 10)
					{
						PlasticBuyPrice = 78;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 39;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 10 && PlasticCount <= 20)
					{
						PlasticBuyPrice = 76;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 38;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 20 && PlasticCount <= 30)
					{
						PlasticBuyPrice = 74;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 37;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 30 && PlasticCount <= 40)
					{
						PlasticBuyPrice = 72;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 36;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 40 && PlasticCount <= 50)
					{
						PlasticBuyPrice = 70;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 35;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 50 && PlasticCount <= 60)
					{
						PlasticBuyPrice = 68;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 34;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 60 && PlasticCount <= 70)
					{
						PlasticBuyPrice = 66;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 33;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 70 && PlasticCount <= 80)
					{
						PlasticBuyPrice = 64;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 32;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 80 && PlasticCount <= 90)
					{
						PlasticBuyPrice = 62;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 31;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					else if(PlasticCount > 90 && PlasticCount <= 99)
					{
						PlasticBuyPrice = 60;
						PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
						PlasticSellPrice = 30;
						PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellPlastic()
	{
		if(PlasticCount < 100)
		{
			int itemIDToRemove = 1019;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + PlasticSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				PlasticCount ++;
				PlasticCountText.text = "Cobalt Ignot(" + PlasticCount.ToString() + ")";
				if(PlasticCount == 0)
				{
					PlasticBuyPrice = 80;
					PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
					PlasticSellPrice = 40;
					PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
				}
				else if(PlasticCount > 0 && PlasticCount <= 10)
				{
					PlasticBuyPrice = 78;
					PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
					PlasticSellPrice = 39;
					PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
				}
				else if(PlasticCount > 10 && PlasticCount <= 20)
				{
					PlasticBuyPrice = 76;
					PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
					PlasticSellPrice = 38;
					PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
				}
				else if(PlasticCount > 20 && PlasticCount <= 30)
				{
					PlasticBuyPrice = 74;
					PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
					PlasticSellPrice = 37;
					PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
				}
				else if(PlasticCount > 30 && PlasticCount <= 40)
				{
					PlasticBuyPrice = 72;
					PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
					PlasticSellPrice = 36;
					PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
				}
				else if(PlasticCount > 40 && PlasticCount <= 50)
				{
					PlasticBuyPrice = 70;
					PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
					PlasticSellPrice = 35;
					PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
				}
				else if(PlasticCount > 50 && PlasticCount <= 60)
				{
					PlasticBuyPrice = 68;
					PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
					PlasticSellPrice = 34;
					PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
				}
				else if(PlasticCount > 60 && PlasticCount <= 70)
				{
					PlasticBuyPrice = 66;
					PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
					PlasticSellPrice = 33;
					PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
				}
				else if(PlasticCount > 70 && PlasticCount <= 80)
				{
					PlasticBuyPrice = 64;
					PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
					PlasticSellPrice = 32;
					PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
				}
				else if(PlasticCount > 80 && PlasticCount <= 90)
				{
					PlasticBuyPrice = 62;
					PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
					PlasticSellPrice = 31;
					PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
				}
				else if(PlasticCount > 90 && PlasticCount <= 99)
				{
					PlasticBuyPrice = 60;
					PlasticBuyPriceText.text = "Buy(" + PlasticBuyPrice.ToString() + ")";
					PlasticSellPrice = 30;
					PlasticSellPriceText.text = "Sell(" + PlasticSellPrice.ToString() + ")";
				}
				ItemObject Plastic = ExistedItem.GetComponent<ItemObject>();
				Plastic.quantity --;
				if(Plastic.quantity == 0)
				{
					Plastic.inventorySlot.itemGameObject = null;
					Plastic.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
		
	public void BuyGrain()
	{
		if(GrainCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= GrainBuyPrice)
			{
				int itemIDToAdd = 1020;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject Grain = itemsList.CreateItemObject("Grain", 1020, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Grain");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(Grain.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - GrainBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					GrainCount --;
					GrainCountText.text = "Grain(" + GrainCount.ToString() + ")";
					if(GrainCount == 0)
					{
						GrainBuyPrice = 20;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 10;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 0 && GrainCount <= 10)
					{
						GrainBuyPrice = 18;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 9;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 10 && GrainCount <= 20)
					{
						GrainBuyPrice = 16;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 8;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 20 && GrainCount <= 30)
					{
						GrainBuyPrice = 14;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 7;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 30 && GrainCount <= 40)
					{
						GrainBuyPrice = 12;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 6;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 40 && GrainCount <= 50)
					{
						GrainBuyPrice = 10;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 5;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 50 && GrainCount <= 60)
					{
						GrainBuyPrice = 8;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 4;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 60 && GrainCount <= 70)
					{
						GrainBuyPrice = 6;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 3;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 70 && GrainCount <= 80)
					{
						GrainBuyPrice = 4;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 2;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 80 && GrainCount <= 99)
					{
						GrainBuyPrice = 2;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 1;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject Grain = ExistedItem.GetComponent<ItemObject>();
					Grain.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - GrainBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					GrainCount --;
					GrainCountText.text = "Grain(" + GrainCount.ToString() + ")";
					if(GrainCount == 0)
					{
						GrainBuyPrice = 20;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 10;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 0 && GrainCount <= 10)
					{
						GrainBuyPrice = 18;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 9;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 10 && GrainCount <= 20)
					{
						GrainBuyPrice = 16;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 8;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 20 && GrainCount <= 30)
					{
						GrainBuyPrice = 14;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 7;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 30 && GrainCount <= 40)
					{
						GrainBuyPrice = 12;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 6;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 40 && GrainCount <= 50)
					{
						GrainBuyPrice = 10;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 5;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 50 && GrainCount <= 60)
					{
						GrainBuyPrice = 8;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 4;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 60 && GrainCount <= 70)
					{
						GrainBuyPrice = 6;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 3;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 70 && GrainCount <= 80)
					{
						GrainBuyPrice = 4;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 2;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					else if(GrainCount > 80 && GrainCount <= 99)
					{
						GrainBuyPrice = 2;
						GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
						GrainSellPrice = 1;
						GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellGrain()
	{
		if(GrainCount < 100)
		{
			int itemIDToRemove = 1020;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + GrainSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				GrainCount ++;
				GrainCountText.text = "Grain(" + GrainCount.ToString() + ")";
				if(GrainCount == 0)
				{
					GrainBuyPrice = 20;
					GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
					GrainSellPrice = 10;
					GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
				}
				else if(GrainCount > 0 && GrainCount <= 10)
				{
					GrainBuyPrice = 18;
					GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
					GrainSellPrice = 9;
					GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
				}
				else if(GrainCount > 10 && GrainCount <= 20)
				{
					GrainBuyPrice = 16;
					GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
					GrainSellPrice = 8;
					GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
				}
				else if(GrainCount > 20 && GrainCount <= 30)
				{
					GrainBuyPrice = 14;
					GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
					GrainSellPrice = 7;
					GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
				}
				else if(GrainCount > 30 && GrainCount <= 40)
				{
					GrainBuyPrice = 12;
					GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
					GrainSellPrice = 6;
					GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
				}
				else if(GrainCount > 40 && GrainCount <= 50)
				{
					GrainBuyPrice = 10;
					GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
					GrainSellPrice = 5;
					GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
				}
				else if(GrainCount > 50 && GrainCount <= 60)
				{
					GrainBuyPrice = 8;
					GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
					GrainSellPrice = 4;
					GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
				}
				else if(GrainCount > 60 && GrainCount <= 70)
				{
					GrainBuyPrice = 6;
					GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
					GrainSellPrice = 3;
					GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
				}
				else if(GrainCount > 70 && GrainCount <= 80)
				{
					GrainBuyPrice = 4;
					GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
					GrainSellPrice = 2;
					GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
				}
				else if(GrainCount > 80 && GrainCount <= 99)
				{
					GrainBuyPrice = 2;
					GrainBuyPriceText.text = "Buy(" + GrainBuyPrice.ToString() + ")";
					GrainSellPrice = 1;
					GrainSellPriceText.text = "Sell(" + GrainSellPrice.ToString() + ")";
				}
				ItemObject Grain = ExistedItem.GetComponent<ItemObject>();
				Grain.quantity --;
				if(Grain.quantity == 0)
				{
					Grain.inventorySlot.itemGameObject = null;
					Grain.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
		
	public void BuyTomato()
	{
		if(TomatoCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= TomatoBuyPrice)
			{
				int itemIDToAdd = 503;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject Tomato = itemsList.CreateItemObject("Tomato", 503, 1, 9, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.heal, "Sprites/Tomato");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(Tomato.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - TomatoBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					TomatoCount --;
					TomatoCountText.text = "Tomato(" + TomatoCount.ToString() + ")";
					if(TomatoCount == 0)
					{
						TomatoBuyPrice = 20;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 10;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 0 && TomatoCount <= 10)
					{
						TomatoBuyPrice = 18;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 9;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 10 && TomatoCount <= 20)
					{
						TomatoBuyPrice = 16;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 8;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 20 && TomatoCount <= 30)
					{
						TomatoBuyPrice = 14;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 7;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 30 && TomatoCount <= 40)
					{
						TomatoBuyPrice = 12;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 6;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 40 && TomatoCount <= 50)
					{
						TomatoBuyPrice = 10;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 5;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 50 && TomatoCount <= 60)
					{
						TomatoBuyPrice = 8;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 4;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 60 && TomatoCount <= 70)
					{
						TomatoBuyPrice = 6;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 3;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 70 && TomatoCount <= 80)
					{
						TomatoBuyPrice = 4;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 2;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 80 && TomatoCount <= 99)
					{
						TomatoBuyPrice = 2;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 1;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject Tomato = ExistedItem.GetComponent<ItemObject>();
					Tomato.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - TomatoBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					TomatoCount --;
					TomatoCountText.text = "Tomato(" + TomatoCount.ToString() + ")";
					if(TomatoCount == 0)
					{
						TomatoBuyPrice = 20;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 10;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 0 && TomatoCount <= 10)
					{
						TomatoBuyPrice = 18;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 9;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 10 && TomatoCount <= 20)
					{
						TomatoBuyPrice = 16;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 8;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 20 && TomatoCount <= 30)
					{
						TomatoBuyPrice = 14;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 7;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 30 && TomatoCount <= 40)
					{
						TomatoBuyPrice = 12;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 6;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 40 && TomatoCount <= 50)
					{
						TomatoBuyPrice = 10;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 5;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 50 && TomatoCount <= 60)
					{
						TomatoBuyPrice = 8;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 4;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 60 && TomatoCount <= 70)
					{
						TomatoBuyPrice = 6;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 3;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 70 && TomatoCount <= 80)
					{
						TomatoBuyPrice = 4;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 2;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					else if(TomatoCount > 80 && TomatoCount <= 99)
					{
						TomatoBuyPrice = 2;
						TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
						TomatoSellPrice = 1;
						TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellTomato()
	{
		if(TomatoCount < 100)
		{
			int itemIDToRemove = 503;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + TomatoSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				TomatoCount ++;
				TomatoCountText.text = "Tomato(" + TomatoCount.ToString() + ")";
				if(TomatoCount == 0)
				{
					TomatoBuyPrice = 20;
					TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
					TomatoSellPrice = 10;
					TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
				}
				else if(TomatoCount > 0 && TomatoCount <= 10)
				{
					TomatoBuyPrice = 18;
					TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
					TomatoSellPrice = 9;
					TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
				}
				else if(TomatoCount > 10 && TomatoCount <= 20)
				{
					TomatoBuyPrice = 16;
					TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
					TomatoSellPrice = 8;
					TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
				}
				else if(TomatoCount > 20 && TomatoCount <= 30)
				{
					TomatoBuyPrice = 14;
					TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
					TomatoSellPrice = 7;
					TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
				}
				else if(TomatoCount > 30 && TomatoCount <= 40)
				{
					TomatoBuyPrice = 12;
					TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
					TomatoSellPrice = 6;
					TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
				}
				else if(TomatoCount > 40 && TomatoCount <= 50)
				{
					TomatoBuyPrice = 10;
					TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
					TomatoSellPrice = 5;
					TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
				}
				else if(TomatoCount > 50 && TomatoCount <= 60)
				{
					TomatoBuyPrice = 8;
					TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
					TomatoSellPrice = 4;
					TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
				}
				else if(TomatoCount > 60 && TomatoCount <= 70)
				{
					TomatoBuyPrice = 6;
					TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
					TomatoSellPrice = 3;
					TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
				}
				else if(TomatoCount > 70 && TomatoCount <= 80)
				{
					TomatoBuyPrice = 4;
					TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
					TomatoSellPrice = 2;
					TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
				}
				else if(TomatoCount > 80 && TomatoCount <= 99)
				{
					TomatoBuyPrice = 2;
					TomatoBuyPriceText.text = "Buy(" + TomatoBuyPrice.ToString() + ")";
					TomatoSellPrice = 1;
					TomatoSellPriceText.text = "Sell(" + TomatoSellPrice.ToString() + ")";
				}
				ItemObject Tomato = ExistedItem.GetComponent<ItemObject>();
				Tomato.quantity --;
				if(Tomato.quantity == 0)
				{
					Tomato.inventorySlot.itemGameObject = null;
					Tomato.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
	
	public void BuyCarrot()
	{
		if(CarrotCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= CarrotBuyPrice)
			{
				int itemIDToAdd = 504;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject Carrot = itemsList.CreateItemObject("Carrot", 504, 1, 9, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.heal, "Sprites/Carrot");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(Carrot.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - CarrotBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					CarrotCount --;
					CarrotCountText.text = "Carrot(" + CarrotCount.ToString() + ")";
					if(CarrotCount == 0)
					{
						CarrotBuyPrice = 20;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 10;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 0 && CarrotCount <= 10)
					{
						CarrotBuyPrice = 18;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 9;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 10 && CarrotCount <= 20)
					{
						CarrotBuyPrice = 16;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 8;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 20 && CarrotCount <= 30)
					{
						CarrotBuyPrice = 14;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 7;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 30 && CarrotCount <= 40)
					{
						CarrotBuyPrice = 12;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 6;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 40 && CarrotCount <= 50)
					{
						CarrotBuyPrice = 10;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 5;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 50 && CarrotCount <= 60)
					{
						CarrotBuyPrice = 8;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 4;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 60 && CarrotCount <= 70)
					{
						CarrotBuyPrice = 6;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 3;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 70 && CarrotCount <= 80)
					{
						CarrotBuyPrice = 4;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 2;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 80 && CarrotCount <= 99)
					{
						CarrotBuyPrice = 2;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 1;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject Carrot = ExistedItem.GetComponent<ItemObject>();
					Carrot.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - CarrotBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					CarrotCount --;
					CarrotCountText.text = "Carrot(" + CarrotCount.ToString() + ")";
					if(CarrotCount == 0)
					{
						CarrotBuyPrice = 20;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 10;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 0 && CarrotCount <= 10)
					{
						CarrotBuyPrice = 18;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 9;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 10 && CarrotCount <= 20)
					{
						CarrotBuyPrice = 16;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 8;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 20 && CarrotCount <= 30)
					{
						CarrotBuyPrice = 14;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 7;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 30 && CarrotCount <= 40)
					{
						CarrotBuyPrice = 12;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 6;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 40 && CarrotCount <= 50)
					{
						CarrotBuyPrice = 10;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 5;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 50 && CarrotCount <= 60)
					{
						CarrotBuyPrice = 8;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 4;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 60 && CarrotCount <= 70)
					{
						CarrotBuyPrice = 6;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 3;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 70 && CarrotCount <= 80)
					{
						CarrotBuyPrice = 4;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 2;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					else if(CarrotCount > 80 && CarrotCount <= 99)
					{
						CarrotBuyPrice = 2;
						CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
						CarrotSellPrice = 1;
						CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellCarrot()
	{
		if(CarrotCount < 100)
		{
			int itemIDToRemove = 504;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + CarrotSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				CarrotCount ++;
				CarrotCountText.text = "Carrot(" + CarrotCount.ToString() + ")";
				if(CarrotCount == 0)
				{
					CarrotBuyPrice = 20;
					CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
					CarrotSellPrice = 10;
					CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
				}
				else if(CarrotCount > 0 && CarrotCount <= 10)
				{
					CarrotBuyPrice = 18;
					CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
					CarrotSellPrice = 9;
					CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
				}
				else if(CarrotCount > 10 && CarrotCount <= 20)
				{
					CarrotBuyPrice = 16;
					CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
					CarrotSellPrice = 8;
					CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
				}
				else if(CarrotCount > 20 && CarrotCount <= 30)
				{
					CarrotBuyPrice = 14;
					CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
					CarrotSellPrice = 7;
					CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
				}
				else if(CarrotCount > 30 && CarrotCount <= 40)
				{
					CarrotBuyPrice = 12;
					CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
					CarrotSellPrice = 6;
					CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
				}
				else if(CarrotCount > 40 && CarrotCount <= 50)
				{
					CarrotBuyPrice = 10;
					CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
					CarrotSellPrice = 5;
					CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
				}
				else if(CarrotCount > 50 && CarrotCount <= 60)
				{
					CarrotBuyPrice = 8;
					CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
					CarrotSellPrice = 4;
					CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
				}
				else if(CarrotCount > 60 && CarrotCount <= 70)
				{
					CarrotBuyPrice = 6;
					CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
					CarrotSellPrice = 3;
					CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
				}
				else if(CarrotCount > 70 && CarrotCount <= 80)
				{
					CarrotBuyPrice = 4;
					CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
					CarrotSellPrice = 2;
					CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
				}
				else if(CarrotCount > 80 && CarrotCount <= 99)
				{
					CarrotBuyPrice = 2;
					CarrotBuyPriceText.text = "Buy(" + CarrotBuyPrice.ToString() + ")";
					CarrotSellPrice = 1;
					CarrotSellPriceText.text = "Sell(" + CarrotSellPrice.ToString() + ")";
				}
				ItemObject Carrot = ExistedItem.GetComponent<ItemObject>();
				Carrot.quantity --;
				if(Carrot.quantity == 0)
				{
					Carrot.inventorySlot.itemGameObject = null;
					Carrot.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
		
	public void BuyDove()
	{
		if(DoveCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= DoveBuyPrice)
			{
				int itemIDToAdd = 1021;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject Dove = itemsList.CreateItemObject("Dove", 1021, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.resource, "Sprites/Dove");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(Dove.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - DoveBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					DoveCount --;
					DoveCountText.text = "Dove(" + DoveCount.ToString() + ")";
					if(DoveCount == 0)
					{
						DoveBuyPrice = 30;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 15;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 0 && DoveCount <= 10)
					{
						DoveBuyPrice = 28;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 14;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 10 && DoveCount <= 20)
					{
						DoveBuyPrice = 26;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 13;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 20 && DoveCount <= 30)
					{
						DoveBuyPrice = 24;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 12;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 30 && DoveCount <= 40)
					{
						DoveBuyPrice = 22;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 11;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 40 && DoveCount <= 50)
					{
						DoveBuyPrice = 20;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 10;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 50 && DoveCount <= 60)
					{
						DoveBuyPrice = 18;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 9;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 60 && DoveCount <= 70)
					{
						DoveBuyPrice = 16;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 8;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 70 && DoveCount <= 80)
					{
						DoveBuyPrice = 14;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 7;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 80 && DoveCount <= 90)
					{
						DoveBuyPrice = 12;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 6;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 90 && DoveCount <= 99)
					{
						DoveBuyPrice = 10;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 5;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject Dove = ExistedItem.GetComponent<ItemObject>();
					Dove.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - DoveBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					DoveCount --;
					DoveCountText.text = "Dove(" + DoveCount.ToString() + ")";
					if(DoveCount == 0)
					{
						DoveBuyPrice = 30;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 15;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 0 && DoveCount <= 10)
					{
						DoveBuyPrice = 28;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 14;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 10 && DoveCount <= 20)
					{
						DoveBuyPrice = 26;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 13;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 20 && DoveCount <= 30)
					{
						DoveBuyPrice = 24;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 12;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 30 && DoveCount <= 40)
					{
						DoveBuyPrice = 22;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 11;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 40 && DoveCount <= 50)
					{
						DoveBuyPrice = 20;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 10;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 50 && DoveCount <= 60)
					{
						DoveBuyPrice = 18;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 9;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 60 && DoveCount <= 70)
					{
						DoveBuyPrice = 16;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 8;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 70 && DoveCount <= 80)
					{
						DoveBuyPrice = 14;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 7;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 80 && DoveCount <= 90)
					{
						DoveBuyPrice = 12;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 6;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					else if(DoveCount > 90 && DoveCount <= 99)
					{
						DoveBuyPrice = 10;
						DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
						DoveSellPrice = 5;
						DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellDove()
	{
		if(DoveCount < 100)
		{
			int itemIDToRemove = 1021;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + DoveSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				DoveCount ++;
				DoveCountText.text = "Dove(" + DoveCount.ToString() + ")";
				if(DoveCount == 0)
				{
					DoveBuyPrice = 30;
					DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
					DoveSellPrice = 15;
					DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
				}
				else if(DoveCount > 0 && DoveCount <= 10)
				{
					DoveBuyPrice = 28;
					DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
					DoveSellPrice = 14;
					DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
				}
				else if(DoveCount > 10 && DoveCount <= 20)
				{
					DoveBuyPrice = 26;
					DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
					DoveSellPrice = 13;
					DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
				}
				else if(DoveCount > 20 && DoveCount <= 30)
				{
					DoveBuyPrice = 24;
					DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
					DoveSellPrice = 12;
					DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
				}
				else if(DoveCount > 30 && DoveCount <= 40)
				{
					DoveBuyPrice = 22;
					DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
					DoveSellPrice = 11;
					DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
				}
				else if(DoveCount > 40 && DoveCount <= 50)
				{
					DoveBuyPrice = 20;
					DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
					DoveSellPrice = 10;
					DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
				}
				else if(DoveCount > 50 && DoveCount <= 60)
				{
					DoveBuyPrice = 18;
					DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
					DoveSellPrice = 9;
					DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
				}
				else if(DoveCount > 60 && DoveCount <= 70)
				{
					DoveBuyPrice = 16;
					DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
					DoveSellPrice = 8;
					DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
				}
				else if(DoveCount > 70 && DoveCount <= 80)
				{
					DoveBuyPrice = 14;
					DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
					DoveSellPrice = 7;
					DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
				}
				else if(DoveCount > 80 && DoveCount <= 90)
				{
					DoveBuyPrice = 12;
					DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
					DoveSellPrice = 6;
					DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
				}
				else if(DoveCount > 90 && DoveCount <= 99)
				{
					DoveBuyPrice = 10;
					DoveBuyPriceText.text = "Buy(" + DoveBuyPrice.ToString() + ")";
					DoveSellPrice = 5;
					DoveSellPriceText.text = "Sell(" + DoveSellPrice.ToString() + ")";
				}
				ItemObject Dove = ExistedItem.GetComponent<ItemObject>();
				Dove.quantity --;
				if(Dove.quantity == 0)
				{
					Dove.inventorySlot.itemGameObject = null;
					Dove.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
		
	public void BuyBread()
	{
		if(BreadCount > 0)
		{
			if(citySelectedData != null && citySelectedData.smallCity.playerScript.Currency >= BreadBuyPrice)
			{
				int itemIDToAdd = 502;
				int freeSlotIndex = citySelectedData.smallCity.cityInventory.GetFreeItemObjectIndex();
				GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToAdd);
				if(ExistedItem == null && freeSlotIndex != -1)
				{
					ItemObject Bread = itemsList.CreateItemObject("Bread", 502, 1, 9, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.heal, "Sprites/Bread");
					citySelectedData.smallCity.cityInventory.AddItemToCityInventory(Bread.gameObject, freeSlotIndex);
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - BreadBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					BreadCount --;
					BreadCountText.text = "Bread(" + BreadCount.ToString() + ")";
					if(BreadCount == 0)
					{
						BreadBuyPrice = 50;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 25;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 0 && BreadCount <= 10)
					{
						BreadBuyPrice = 48;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 24;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 10 && BreadCount <= 20)
					{
						BreadBuyPrice = 16;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 8;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 20 && BreadCount <= 30)
					{
						BreadBuyPrice = 14;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 7;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 30 && BreadCount <= 40)
					{
						BreadBuyPrice = 12;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 6;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 40 && BreadCount <= 50)
					{
						BreadBuyPrice = 10;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 5;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 50 && BreadCount <= 60)
					{
						BreadBuyPrice = 8;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 4;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 60 && BreadCount <= 70)
					{
						BreadBuyPrice = 6;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 3;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 70 && BreadCount <= 80)
					{
						BreadBuyPrice = 4;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 2;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 80 && BreadCount <= 99)
					{
						BreadBuyPrice = 2;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 1;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else if (ExistedItem != null)
				{
					ItemObject Bread = ExistedItem.GetComponent<ItemObject>();
					Bread.quantity ++;
					citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency - BreadBuyPrice;
					cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
					BreadCount --;
					BreadCountText.text = "Bread(" + BreadCount.ToString() + ")";
					if(BreadCount == 0)
					{
						BreadBuyPrice = 20;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 10;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 0 && BreadCount <= 10)
					{
						BreadBuyPrice = 18;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 9;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 10 && BreadCount <= 20)
					{
						BreadBuyPrice = 16;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 8;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 20 && BreadCount <= 30)
					{
						BreadBuyPrice = 14;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 7;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 30 && BreadCount <= 40)
					{
						BreadBuyPrice = 12;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 6;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 40 && BreadCount <= 50)
					{
						BreadBuyPrice = 10;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 5;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 50 && BreadCount <= 60)
					{
						BreadBuyPrice = 8;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 4;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 60 && BreadCount <= 70)
					{
						BreadBuyPrice = 6;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 3;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 70 && BreadCount <= 80)
					{
						BreadBuyPrice = 4;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 2;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					else if(BreadCount > 80 && BreadCount <= 99)
					{
						BreadBuyPrice = 2;
						BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
						BreadSellPrice = 1;
						BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
					}
					cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
				}
				else
				{
					Debug.Log("Not enough free place in city.");
				}
			}
			else
			{
				Debug.Log("Not enough money.");
			}
		}
	}
	
	public void SellBread()
	{
		if(BreadCount < 100)
		{
			int itemIDToRemove = 502;
			GameObject ExistedItem = citySelectedData.smallCity.cityInventory.FindItemWithIDInCityInventory(itemIDToRemove);
			if(ExistedItem != null)
			{
				citySelectedData.smallCity.playerScript.Currency = citySelectedData.smallCity.playerScript.Currency + BreadSellPrice;
				cityInventoryUI.Currency.text = "Currency: " + citySelectedData.smallCity.playerScript.Currency.ToString();
				BreadCount ++;
				BreadCountText.text = "Bread(" + BreadCount.ToString() + ")";
				if(BreadCount == 0)
				{
					BreadBuyPrice = 20;
					BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
					BreadSellPrice = 10;
					BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
				}
				else if(BreadCount > 0 && BreadCount <= 10)
				{
					BreadBuyPrice = 18;
					BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
					BreadSellPrice = 9;
					BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
				}
				else if(BreadCount > 10 && BreadCount <= 20)
				{
					BreadBuyPrice = 16;
					BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
					BreadSellPrice = 8;
					BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
				}
				else if(BreadCount > 20 && BreadCount <= 30)
				{
					BreadBuyPrice = 14;
					BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
					BreadSellPrice = 7;
					BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
				}
				else if(BreadCount > 30 && BreadCount <= 40)
				{
					BreadBuyPrice = 12;
					BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
					BreadSellPrice = 6;
					BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
				}
				else if(BreadCount > 40 && BreadCount <= 50)
				{
					BreadBuyPrice = 10;
					BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
					BreadSellPrice = 5;
					BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
				}
				else if(BreadCount > 50 && BreadCount <= 60)
				{
					BreadBuyPrice = 8;
					BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
					BreadSellPrice = 4;
					BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
				}
				else if(BreadCount > 60 && BreadCount <= 70)
				{
					BreadBuyPrice = 6;
					BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
					BreadSellPrice = 3;
					BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
				}
				else if(BreadCount > 70 && BreadCount <= 80)
				{
					BreadBuyPrice = 4;
					BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
					BreadSellPrice = 2;
					BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
				}
				else if(BreadCount > 80 && BreadCount <= 99)
				{
					BreadBuyPrice = 2;
					BreadBuyPriceText.text = "Buy(" + BreadBuyPrice.ToString() + ")";
					BreadSellPrice = 1;
					BreadSellPriceText.text = "Sell(" + BreadSellPrice.ToString() + ")";
				}
				ItemObject Bread = ExistedItem.GetComponent<ItemObject>();
				Bread.quantity --;
				if(Bread.quantity == 0)
				{
					Bread.inventorySlot.itemGameObject = null;
					Bread.inventorySlot.isOccupied = false;
					Destroy(ExistedItem);
				}
				cityInventoryUI.UpdateCertianCityItemSprites(citySelectedData.smallCity.cityInventory);
			}
			else
			{
				Debug.Log("No item to sell.");
			}
		}
	}
}