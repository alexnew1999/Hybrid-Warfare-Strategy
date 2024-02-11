using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Linq;

public class SaveLoadManager
{
	[System.Serializable]
	public class TradeSerializable
	{
		public int WoodCount;
		public int WoodSellPrice;
		public int WoodBuyPrice;
		public int CoalCount;
		public int CoalSellPrice;
		public int CoalBuyPrice;
		public int IronOreCount;
		public int IronOreSellPrice;
		public int IronOreBuyPrice;
		public int IronIgnotCount;
		public int IronIgnotSellPrice;
		public int IronIgnotBuyPrice;
		public int StoneCount;
		public int StoneSellPrice;
		public int StoneBuyPrice;
		public int SaltpeterCount;
		public int SaltpeterSellPrice;
		public int SaltpeterBuyPrice;
		public int GunpowderCount;
		public int GunpowderSellPrice;
		public int GunpowderBuyPrice;
		public int AluminiumOreCount;
		public int AluminiumOreSellPrice;
		public int AluminiumOreBuyPrice;
		public int AluminiumIgnotCount;
		public int AluminiumIgnotSellPrice;
		public int AluminiumIgnotBuyPrice;
		public int CopperOreCount;
		public int CopperOreSellPrice;
		public int CopperOreBuyPrice;
		public int CopperIgnotCount;
		public int CopperIgnotSellPrice;
		public int CopperIgnotBuyPrice;
		public int FlaxCount;
		public int FlaxSellPrice;
		public int FlaxBuyPrice;
		public int FlaxFabricCount;
		public int FlaxFabricSellPrice;
		public int FlaxFabricBuyPrice;
		public int OilCount;
		public int OilSellPrice;
		public int OilBuyPrice;
		public int PetrolCount;
		public int PetrolSellPrice;
		public int PetrolBuyPrice;
		public int CobaltOreCount;
		public int CobaltOreSellPrice;
		public int CobaltOreBuyPrice;
		public int CobaltIgnotCount;
		public int CobaltIgnotSellPrice;
		public int CobaltIgnotBuyPrice;
		public int PlasticCount;
		public int PlasticSellPrice;
		public int PlasticBuyPrice;
		public int GrainCount;
		public int GrainSellPrice;
		public int GrainBuyPrice;
		public int CarrotCount;
		public int CarrotSellPrice;
		public int CarrotBuyPrice;
		public int TomatoCount;
		public int TomatoSellPrice;
		public int TomatoBuyPrice;
		public int DoveCount;
		public int DoveSellPrice;
		public int DoveBuyPrice;
		public int BreadCount;
		public int BreadSellPrice;
		public int BreadBuyPrice;
		
		public TradeSerializable(Trade trade)
		{
			WoodCount = trade.WoodCount;
			WoodSellPrice = trade.WoodSellPrice;
			WoodBuyPrice = trade.WoodBuyPrice;
			CoalCount = trade.CoalCount;
			CoalSellPrice = trade.CoalSellPrice;
			CoalBuyPrice = trade.CoalBuyPrice;
			IronOreCount = trade.IronOreCount;
			IronOreSellPrice = trade.IronOreSellPrice;
			IronOreBuyPrice = trade.IronOreBuyPrice;
			IronIgnotCount = trade.IronIgnotCount;
			IronIgnotSellPrice = trade.IronIgnotSellPrice;
			IronIgnotBuyPrice = trade.IronIgnotBuyPrice;
			StoneCount = trade.StoneCount;
			StoneSellPrice = trade.StoneSellPrice;
			StoneBuyPrice = trade.StoneBuyPrice;
			SaltpeterCount = trade.SaltpeterCount;
			SaltpeterSellPrice = trade.SaltpeterSellPrice;
			SaltpeterBuyPrice = trade.SaltpeterBuyPrice;
			GunpowderCount = trade.GunpowderCount;
			GunpowderSellPrice = trade.GunpowderSellPrice;
			GunpowderBuyPrice = trade.GunpowderBuyPrice;
			AluminiumOreCount = trade.AluminiumOreCount;
			AluminiumOreSellPrice = trade.AluminiumOreSellPrice;
			AluminiumOreBuyPrice = trade.AluminiumOreBuyPrice;
			AluminiumIgnotCount = trade.AluminiumIgnotCount;
			AluminiumIgnotSellPrice = trade.AluminiumIgnotSellPrice;
			AluminiumIgnotBuyPrice = trade.AluminiumIgnotBuyPrice;
			CopperOreCount = trade.CopperOreCount;
			CopperOreSellPrice = trade.CopperOreSellPrice;
			CopperOreBuyPrice = trade.CopperOreBuyPrice;
			CopperIgnotCount = trade.CopperIgnotCount;
			CopperIgnotSellPrice = trade.CopperIgnotSellPrice;
			CopperIgnotBuyPrice = trade.CopperIgnotBuyPrice;
			FlaxCount = trade.FlaxCount;
			FlaxSellPrice = trade.FlaxSellPrice;
			FlaxBuyPrice = trade.FlaxBuyPrice;
			FlaxFabricCount = trade.FlaxFabricCount;
			FlaxFabricSellPrice = trade.FlaxFabricSellPrice;
			FlaxFabricBuyPrice = trade.FlaxFabricBuyPrice;
			OilCount = trade.OilCount;
			OilSellPrice = trade.OilSellPrice;
			OilBuyPrice = trade.OilBuyPrice;
			PetrolCount = trade.PetrolCount;
			PetrolSellPrice = trade.PetrolSellPrice;
			PetrolBuyPrice = trade.PetrolBuyPrice;
			CobaltOreCount = trade.CobaltOreCount;
			CobaltOreSellPrice = trade.CobaltOreSellPrice;
			CobaltOreBuyPrice = trade.CobaltOreBuyPrice;
			CobaltIgnotCount = trade.CobaltIgnotCount;
			CobaltIgnotSellPrice = trade.CobaltIgnotSellPrice;
			CobaltIgnotBuyPrice = trade.CobaltIgnotBuyPrice;
			PlasticCount = trade.PlasticCount;
			PlasticSellPrice = trade.PlasticSellPrice;
			PlasticBuyPrice = trade.PlasticBuyPrice;
			GrainCount = trade.GrainCount;
			GrainSellPrice = trade.GrainSellPrice;
			GrainBuyPrice = trade.GrainBuyPrice;
			CarrotCount = trade.CarrotCount;
			CarrotSellPrice = trade.CarrotSellPrice;
			CarrotBuyPrice = trade.CarrotBuyPrice;
			TomatoCount = trade.TomatoCount;
			TomatoSellPrice = trade.TomatoSellPrice;
			TomatoBuyPrice = trade.TomatoBuyPrice;
			DoveCount = trade.DoveCount;
			DoveSellPrice = trade.DoveSellPrice;
			DoveBuyPrice = trade.DoveBuyPrice;
			BreadCount = trade.BreadCount;
			BreadSellPrice = trade.BreadSellPrice;
			BreadBuyPrice = trade.BreadBuyPrice;
		}
	}
	
	[System.Serializable]
	public class TurnRemembererSerializable
	{
		public int currentTurn;
		public int currentPlayer;
		
		public TurnRemembererSerializable(TurnRememberer turnRememberer)
		{
			currentTurn = turnRememberer.turnCounter.turnCount;
			currentPlayer = turnRememberer.turnCounter.endTurnConfirmation.ownerPlayerID;
		}
	}
	
	[System.Serializable]
	public class MashineFactorySerializable
	{
		public int ownerPlayerID;
		public int GlobalID;
		public int currentCellGlobalID;
		public int Population;
		public int PopulationAP;
		public int PopulationMaxAP;
		
		public MashineFactorySerializable(MashineFactory mashineFactory)
		{
			ownerPlayerID = mashineFactory.ownerPlayerID;
			GlobalID = mashineFactory.GlobalID;
			currentCellGlobalID = mashineFactory.cellData.GlobalID;
			Population = mashineFactory.Population;
			PopulationAP = mashineFactory.PopulationAP;
			PopulationMaxAP = mashineFactory.PopulationMaxAP;
		}
	}
	
	[System.Serializable]
	public class ForgeSerializable
	{
		public int ownerPlayerID;
		public int GlobalID;
		public int currentCellGlobalID;
		public int Population;
		public int PopulationAP;
		public int PopulationMaxAP;
		
		public ForgeSerializable(Forge forge)
		{
			ownerPlayerID = forge.ownerPlayerID;
			GlobalID = forge.GlobalID;
			currentCellGlobalID = forge.cellData.GlobalID;
			Population = forge.Population;
			PopulationAP = forge.PopulationAP;
			PopulationMaxAP = forge.PopulationMaxAP;
		}
	}
	
	[System.Serializable]
	public class BuildingSiteSerializable
	{
		public int WoodToBuild;
		public int StoneToBuild;
		public int TurnToBuild;
		public int IronToBuild;
		public string spritePath;
		public int currentCellGlobalID;
		public bool forge;
		public bool mine;
		public bool farm;
		public bool trench;
		public bool preTrench;
		public int GlobalID;
		
		public BuildingSiteSerializable(BuildingSite buildingSite)
		{
			WoodToBuild = buildingSite.WoodToBuild;
			StoneToBuild = buildingSite.StoneToBuild;
			TurnToBuild = buildingSite.TurnToBuild;
			IronToBuild = buildingSite.IronToBuild;
			spritePath = buildingSite.spritePath;
			currentCellGlobalID = buildingSite.cellData.GlobalID;
			forge = buildingSite.forge;
			mine = buildingSite.mine;
			farm = buildingSite.farm;
			trench = buildingSite.trench;
			preTrench = buildingSite.preTrench;		
			if(buildingSite.GlobalID > 0)
			{
				GlobalID = buildingSite.GlobalID;
			}
		}
	}
	
	[System.Serializable]
	public class ItemObjectSerializable
	{
		public string itemName;
		public int itemID;
		public int quantity;
		public int maxquantity;
		public int damage;
		public int heavyDamage;
		public int armorpierceDamage;
		public int health;
		public int softDef;
		public int hardDef;
		public int attackRange;
		public int slots;
		public float attackChance;
		public float coverChance;
		public int maximalMP;
		public string AmmoType;
		public int ammoUsage;
		public string SpritePath;
		public int GlobalIDowner;
		public bool IsWeared;
		public ItemType itemType;
		
		public ItemObjectSerializable(ItemObject itemObject)
		{
			itemName = itemObject.itemName;
			itemID = itemObject.itemID;
			quantity = itemObject.quantity;
			maxquantity = itemObject.maxquantity;
			damage = itemObject.damage;
			heavyDamage = itemObject.heavyDamage;
			armorpierceDamage = itemObject.armorpierceDamage;
			health = itemObject.health;
			softDef = itemObject.softDef;
			hardDef = itemObject.hardDef;
			attackRange = itemObject.attackRange;
			slots = itemObject.slots;
			attackChance = itemObject.attackChance;
			coverChance = itemObject.coverChance;
			maximalMP = itemObject.maximalMP;
			AmmoType = itemObject.AmmoType;
			ammoUsage = itemObject.ammoUsage;
			SpritePath = itemObject.SpritePath;
			IsWeared = itemObject.IsWeared;
			itemType = itemObject.itemType;
			if(itemObject.inventorySlot.cityInventory != null)
			{
				GlobalIDowner = itemObject.inventorySlot.cityInventory.smallCity.GlobalID;
			}
			else if(itemObject.inventorySlot.characterInventory != null)
			{
				GlobalIDowner = itemObject.inventorySlot.characterInventory.characterData.GlobalID;
			}
			else if(itemObject.inventorySlot.forge != null)
			{
				GlobalIDowner = itemObject.inventorySlot.forge.GlobalID;
			}
		}
	}
	[System.Serializable]
	public class NodeSerializable
	{
		public int gridX;
		public int gridY;
		public int baseCost;
		public int gCost;
		public int hCost;
		public int GlobalID;
		
		public NodeSerializable(Node node)
		{
			gridX = node.gridX;
			gridY = node.gridY;
			baseCost = node.baseCost;
			gCost = node.gCost;
			hCost = node.hCost;
			GlobalID = node.GlobalID;
		}
	}
	[System.Serializable]
	public class SmallCitySerializable
	{
		public bool MobilizationInProgress;
		public string cityName;
		public int cityID;
		public int turnToResearch;
		public int ownerPlayerID;
		public int Population;
		public int PopulationWorkable;
		public int PopulationAP;
		public int PopulationMaxAP;
		public int GlobalID;
		public string spritePath;
		public int currentCellGlobalID;
		public bool AIControlled;
		public int AIDefendDrone1;
		public int AIDefendDrone2;
		public int AIAttackDrone1;
		public int AIAttackDrone2;
		public int AIAttackDrone3;
		public int Multiplayer;
		public int Currency;
		public string CurrentResearch;
		public int InfantryLightWeaponResearch1;
		public int InfantryLightWeaponResearch2;
		public int InfantryLightWeaponResearch3;
		public int InfantryLightWeaponResearch4point1;
		public int InfantryLightWeaponResearch4point2;
		public int InfantryLightWeaponResearch11;
		public int InfantryHeavyWeaponResearch1;
		public int InfantryHeavyWeaponResearch2;
		
		public int PopulationAge0M;
		public int PopulationAge0W;
		public int PopulationAge1M;
		public int PopulationAge1W;
		public int PopulationAge2M;
		public int PopulationAge2W;
		public int PopulationAge3M;
		public int PopulationAge3W;
		public int PopulationAge4M;
		public int PopulationAge4W;
		public int PopulationAge5M;
		public int PopulationAge5W;
		public int PopulationAge6M;
		public int PopulationAge6W;
		public int PopulationAge7M;
		public int PopulationAge7W;
		public int PopulationAge8M;
		public int PopulationAge8W;
		public int PopulationAge9M;
		public int PopulationAge9W;
		public int PopulationAge10M;
		public int PopulationAge10W;
		public int PopulationAge11M;
		public int PopulationAge11W;
		public int PopulationAge12M;
		public int PopulationAge12W;
		public int PopulationAge13M;
		public int PopulationAge13W;
		public int PopulationAge14M;
		public int PopulationAge14W;
		public int PopulationAge15M;
		public int PopulationAge15W;
		public int PopulationAge16M;
		public int PopulationAge16W;
		public int PopulationAge17M;
		public int PopulationAge17W;
		public int PopulationAge18M;
		public int PopulationAge18W;
		public int PopulationAge19M;
		public int PopulationAge19W;
		public int PopulationAge20M;
		public int PopulationAge20W;
		public int PopulationAge21M;
		public int PopulationAge21W;
		public int PopulationAge22M;
		public int PopulationAge22W;
		public int PopulationAge23M;
		public int PopulationAge23W;
		public int PopulationAge24M;
		public int PopulationAge24W;
		public int PopulationAge25M;
		public int PopulationAge25W;
		public int PopulationAge26M;
		public int PopulationAge26W;
		public int PopulationAge27M;
		public int PopulationAge27W;
		public int PopulationAge28M;
		public int PopulationAge28W;
		public int PopulationAge29M;
		public int PopulationAge29W;
		public int PopulationAge30M;
		public int PopulationAge30W;
		public int PopulationAge31M;
		public int PopulationAge31W;
		public int PopulationAge32M;
		public int PopulationAge32W;
		public int PopulationAge33M;
		public int PopulationAge33W;
		public int PopulationAge34M;
		public int PopulationAge34W;
		public int PopulationAge35M;
		public int PopulationAge35W;
		public int PopulationAge36M;
		public int PopulationAge36W;
		public int PopulationAge37M;
		public int PopulationAge37W;
		public int PopulationAge38M;
		public int PopulationAge38W;
		public int PopulationAge39M;
		public int PopulationAge39W;
		public int PopulationAge40M;
		public int PopulationAge40W;
		public int PopulationAge41M;
		public int PopulationAge41W;
		public int PopulationAge42M;
		public int PopulationAge42W;
		public int PopulationAge43M;
		public int PopulationAge43W;
		public int PopulationAge44M;
		public int PopulationAge44W;
		public int PopulationAge45M;
		public int PopulationAge45W;
		public int PopulationAge46M;
		public int PopulationAge46W;
		public int PopulationAge47M;
		public int PopulationAge47W;
		public int PopulationAge48M;
		public int PopulationAge48W;
		public int PopulationAge49M;
		public int PopulationAge49W;
		public int PopulationAge50M;
		public int PopulationAge50W;
		public int PopulationAge51M;
		public int PopulationAge51W;
		public int PopulationAge52M;
		public int PopulationAge52W;
		public int PopulationAge53M;
		public int PopulationAge53W;
		public int PopulationAge54M;
		public int PopulationAge54W;
		public int PopulationAge55M;
		public int PopulationAge55W;
		public int PopulationAge56M;
		public int PopulationAge56W;
		public int PopulationAge57M;
		public int PopulationAge57W;
		public int PopulationAge58M;
		public int PopulationAge58W;
		public int PopulationAge59M;
		public int PopulationAge59W;
		public int PopulationAge60M;
		public int PopulationAge60W;
		public int PopulationAge61M;
		public int PopulationAge61W;
		public int PopulationAge62M;
		public int PopulationAge62W;
		public int PopulationAge63M;
		public int PopulationAge63W;
		public int PopulationAge64M;
		public int PopulationAge64W;
		public int PopulationAge65M;
		public int PopulationAge65W;
		public int PopulationAge66M;
		public int PopulationAge66W;
		public int PopulationAge67M;
		public int PopulationAge67W;
		public int PopulationAge68M;
		public int PopulationAge68W;
		public int PopulationAge69M;
		public int PopulationAge69W;
		public int PopulationAge70M;
		public int PopulationAge70W;
		public float minDeathRateJung;
		public float maxDeathRateJung;
		public float minDeathRateOld;
		public float maxDeathRateOld;
		public float minBirthRateJung;
		public float maxBirthRateJung;
		
		public SmallCitySerializable(SmallCity smallCity)
		{
			MobilizationInProgress = smallCity.MobilizationInProgress;
			cityName = smallCity.cityName;
			cityID = smallCity.cityID;
			ownerPlayerID = smallCity.ownerPlayerID;
			Population = smallCity.Population;
			PopulationWorkable = smallCity.PopulationWorkable;
			PopulationAP = smallCity.PopulationAP;
			PopulationMaxAP = smallCity.PopulationMaxAP;
			turnToResearch = smallCity.turnToResearch;
			GlobalID = smallCity.GlobalID;
			spritePath = smallCity.spritePath;
			currentCellGlobalID = smallCity.currentCell.GlobalID;
			AIControlled = smallCity.playerScript.aIControlled;
			Multiplayer = smallCity.playerScript.Multiplayer;
			Currency = smallCity.playerScript.Currency;
			
			PopulationAge0M = smallCity.PopulationAge0M;
			PopulationAge0W = smallCity.PopulationAge0W;
			PopulationAge1M = smallCity.PopulationAge1M;
			PopulationAge1W = smallCity.PopulationAge1W;
			PopulationAge2M = smallCity.PopulationAge2M;
			PopulationAge2W = smallCity.PopulationAge2W;
			PopulationAge3M = smallCity.PopulationAge3M;
			PopulationAge3W = smallCity.PopulationAge3W;
			PopulationAge4M = smallCity.PopulationAge4M;
			PopulationAge4W = smallCity.PopulationAge4W;
			PopulationAge5M = smallCity.PopulationAge5M;
			PopulationAge5W = smallCity.PopulationAge5W;
			PopulationAge6M = smallCity.PopulationAge6M;
			PopulationAge6W = smallCity.PopulationAge6W;
			PopulationAge7M = smallCity.PopulationAge7M;
			PopulationAge7W = smallCity.PopulationAge7W;
			PopulationAge8M = smallCity.PopulationAge8M;
			PopulationAge8W = smallCity.PopulationAge8W;
			PopulationAge9M = smallCity.PopulationAge9M;
			PopulationAge9W = smallCity.PopulationAge9W;
			PopulationAge10M = smallCity.PopulationAge10M;
			PopulationAge10W = smallCity.PopulationAge10W;
			PopulationAge11M = smallCity.PopulationAge11M;
			PopulationAge11W = smallCity.PopulationAge11W;
			PopulationAge12M = smallCity.PopulationAge12M;
			PopulationAge12W = smallCity.PopulationAge12W;
			PopulationAge13M = smallCity.PopulationAge13M;
			PopulationAge13W = smallCity.PopulationAge13W;
			PopulationAge14M = smallCity.PopulationAge14M;
			PopulationAge14W = smallCity.PopulationAge14W;
			PopulationAge15M = smallCity.PopulationAge15M;
			PopulationAge15W = smallCity.PopulationAge15W;
			PopulationAge16M = smallCity.PopulationAge16M;
			PopulationAge16W = smallCity.PopulationAge16W;
			PopulationAge17M = smallCity.PopulationAge17M;
			PopulationAge17W = smallCity.PopulationAge17W;
			PopulationAge18M = smallCity.PopulationAge18M;
			PopulationAge18W = smallCity.PopulationAge18W;
			PopulationAge19M = smallCity.PopulationAge19M;
			PopulationAge19W = smallCity.PopulationAge19W;
			PopulationAge20M = smallCity.PopulationAge20M;
			PopulationAge20W = smallCity.PopulationAge20W;
			PopulationAge21M = smallCity.PopulationAge21M;
			PopulationAge21W = smallCity.PopulationAge21W;
			PopulationAge22M = smallCity.PopulationAge22M;
			PopulationAge22W = smallCity.PopulationAge22W;
			PopulationAge23M = smallCity.PopulationAge23M;
			PopulationAge23W = smallCity.PopulationAge23W;
			PopulationAge24M = smallCity.PopulationAge24M;
			PopulationAge24W = smallCity.PopulationAge24W;
			PopulationAge25M = smallCity.PopulationAge25M;
			PopulationAge25W = smallCity.PopulationAge25W;
			PopulationAge26M = smallCity.PopulationAge26M;
			PopulationAge26W = smallCity.PopulationAge26W;
			PopulationAge27M = smallCity.PopulationAge27M;
			PopulationAge27W = smallCity.PopulationAge27W;
			PopulationAge28M = smallCity.PopulationAge28M;
			PopulationAge28W = smallCity.PopulationAge28W;
			PopulationAge29M = smallCity.PopulationAge29M;
			PopulationAge29W = smallCity.PopulationAge29W;
			PopulationAge30M = smallCity.PopulationAge30M;
			PopulationAge30W = smallCity.PopulationAge30W;
			PopulationAge31M = smallCity.PopulationAge31M;
			PopulationAge31W = smallCity.PopulationAge31W;
			PopulationAge32M = smallCity.PopulationAge32M;
			PopulationAge32W = smallCity.PopulationAge32W;
			PopulationAge33M = smallCity.PopulationAge33M;
			PopulationAge33W = smallCity.PopulationAge33W;
			PopulationAge34M = smallCity.PopulationAge34M;
			PopulationAge34W = smallCity.PopulationAge34W;
			PopulationAge35M = smallCity.PopulationAge35M;
			PopulationAge35W = smallCity.PopulationAge35W;
			PopulationAge36M = smallCity.PopulationAge36M;
			PopulationAge36W = smallCity.PopulationAge36W;
			PopulationAge37M = smallCity.PopulationAge37M;
			PopulationAge37W = smallCity.PopulationAge37W;
			PopulationAge38M = smallCity.PopulationAge38M;
			PopulationAge38W = smallCity.PopulationAge38W;
			PopulationAge39M = smallCity.PopulationAge39M;
			PopulationAge39W = smallCity.PopulationAge39W;
			PopulationAge40M = smallCity.PopulationAge40M;
			PopulationAge40W = smallCity.PopulationAge40W;
			PopulationAge41M = smallCity.PopulationAge41M;
			PopulationAge41W = smallCity.PopulationAge41W;
			PopulationAge42M = smallCity.PopulationAge42M;
			PopulationAge42W = smallCity.PopulationAge42W;
			PopulationAge43M = smallCity.PopulationAge43M;
			PopulationAge43W = smallCity.PopulationAge43W;
			PopulationAge44M = smallCity.PopulationAge44M;
			PopulationAge44W = smallCity.PopulationAge44W;
			PopulationAge45M = smallCity.PopulationAge45M;
			PopulationAge45W = smallCity.PopulationAge45W;
			PopulationAge46M = smallCity.PopulationAge46M;
			PopulationAge46W = smallCity.PopulationAge46W;
			PopulationAge47M = smallCity.PopulationAge47M;
			PopulationAge47W = smallCity.PopulationAge47W;
			PopulationAge48M = smallCity.PopulationAge48M;
			PopulationAge48W = smallCity.PopulationAge48W;
			PopulationAge49M = smallCity.PopulationAge49M;
			PopulationAge49W = smallCity.PopulationAge49W;
			PopulationAge50M = smallCity.PopulationAge50M;
			PopulationAge50W = smallCity.PopulationAge50W;
			PopulationAge51M = smallCity.PopulationAge51M;
			PopulationAge51W = smallCity.PopulationAge51W;
			PopulationAge52M = smallCity.PopulationAge52M;
			PopulationAge52W = smallCity.PopulationAge52W;
			PopulationAge53M = smallCity.PopulationAge53M;
			PopulationAge53W = smallCity.PopulationAge53W;
			PopulationAge54M = smallCity.PopulationAge54M;
			PopulationAge54W = smallCity.PopulationAge54W;
			PopulationAge55M = smallCity.PopulationAge55M;
			PopulationAge55W = smallCity.PopulationAge55W;
			PopulationAge56M = smallCity.PopulationAge56M;
			PopulationAge56W = smallCity.PopulationAge56W;
			PopulationAge57M = smallCity.PopulationAge57M;
			PopulationAge57W = smallCity.PopulationAge57W;
			PopulationAge58M = smallCity.PopulationAge58M;
			PopulationAge58W = smallCity.PopulationAge58W;
			PopulationAge59M = smallCity.PopulationAge59M;
			PopulationAge59W = smallCity.PopulationAge59W;
			PopulationAge60M = smallCity.PopulationAge60M;
			PopulationAge60W = smallCity.PopulationAge60W;
			PopulationAge61M = smallCity.PopulationAge61M;
			PopulationAge61W = smallCity.PopulationAge61W;
			PopulationAge62M = smallCity.PopulationAge62M;
			PopulationAge62W = smallCity.PopulationAge62W;
			PopulationAge63M = smallCity.PopulationAge63M;
			PopulationAge63W = smallCity.PopulationAge63W;
			PopulationAge64M = smallCity.PopulationAge64M;
			PopulationAge64W = smallCity.PopulationAge64W;
			PopulationAge65M = smallCity.PopulationAge65M;
			PopulationAge65W = smallCity.PopulationAge65W;
			PopulationAge66M = smallCity.PopulationAge66M;
			PopulationAge66W = smallCity.PopulationAge66W;
			PopulationAge67M = smallCity.PopulationAge67M;
			PopulationAge67W = smallCity.PopulationAge67W;
			PopulationAge68M = smallCity.PopulationAge68M;
			PopulationAge68W = smallCity.PopulationAge68W;
			PopulationAge69M = smallCity.PopulationAge69M;
			PopulationAge69W = smallCity.PopulationAge69W;
			PopulationAge70M = smallCity.PopulationAge70M;
			PopulationAge70W = smallCity.PopulationAge70W;
			minDeathRateJung = smallCity.minDeathRateJung;
			maxDeathRateJung = smallCity.maxDeathRateJung;
			minDeathRateOld = smallCity.minDeathRateOld;
			maxDeathRateOld = smallCity.maxDeathRateOld;
			minBirthRateJung = smallCity.minBirthRateJung;
			maxBirthRateJung = smallCity.maxBirthRateJung;
			
			CurrentResearch = smallCity.playerScript.CurrentResearch;
			InfantryLightWeaponResearch1 = smallCity.playerScript.InfantryLightWeaponResearch1;
			InfantryLightWeaponResearch2 = smallCity.playerScript.InfantryLightWeaponResearch2;
			InfantryLightWeaponResearch3 = smallCity.playerScript.InfantryLightWeaponResearch3;
			InfantryLightWeaponResearch4point1 = smallCity.playerScript.InfantryLightWeaponResearch4point1;
			InfantryLightWeaponResearch4point2 = smallCity.playerScript.InfantryLightWeaponResearch4point2;
			InfantryLightWeaponResearch11 = smallCity.playerScript.InfantryLightWeaponResearch11;
			InfantryHeavyWeaponResearch1 = smallCity.playerScript.InfantryHeavyWeaponResearch1;
			InfantryHeavyWeaponResearch2 = smallCity.playerScript.InfantryHeavyWeaponResearch2;
			if(smallCity.playerScript.aIControlled != null)
			{
				if(smallCity.playerScript.aIControlled.AIDefendDrone1 != null)
				{
					CharacterData characterData = smallCity.playerScript.aIControlled.AIDefendDrone1.GetComponent<CharacterData>();
					AIDefendDrone1 = characterData.GlobalID;
				}
				if(smallCity.playerScript.aIControlled.AIDefendDrone2 != null)
				{
					CharacterData characterData = smallCity.playerScript.aIControlled.AIDefendDrone2.GetComponent<CharacterData>();
					AIDefendDrone2 = characterData.GlobalID;
				}
				if(smallCity.playerScript.aIControlled.AIAttackDrone1 != null)
				{
					CharacterData characterData = smallCity.playerScript.aIControlled.AIAttackDrone1.GetComponent<CharacterData>();
					AIAttackDrone1 = characterData.GlobalID;
				}
				if(smallCity.playerScript.aIControlled.AIAttackDrone2 != null)
				{
					CharacterData characterData = smallCity.playerScript.aIControlled.AIAttackDrone2.GetComponent<CharacterData>();
					AIAttackDrone2 = characterData.GlobalID;
				}
				if(smallCity.playerScript.aIControlled.AIAttackDrone3 != null)
				{
					CharacterData characterData = smallCity.playerScript.aIControlled.AIAttackDrone3.GetComponent<CharacterData>();
					AIAttackDrone3 = characterData.GlobalID;
				}
			}
		}
	}
	[System.Serializable]
	public class CharacterDataSerializable
	{
	public bool InCityInventory;
    public string characterName;
    public int ownerPlayerID;
    public int health;
    public int maxhealth;
    public int damage;
	public int heavyDamage;
	public int armorpierceDamage;
	public int softDef;
	public int hardDef;
    public int characterID;
    public int usableMP;
    public int maxMP;
    public int usableAP;
    public int maxAP;
    public int attackRange;
	public float attackChance;
	public float coverChance;
	public int transformTo;
	public string AmmoType;
	public int ammoUsage;
	public string spritePath;
	public int GlobalID;
	public int globalIDcurrentCell;
	public int inventorySize;
	public int WeaponSlotChanges;
	public int AmmoSlotChanges;
	public int HelmetSlotChanges;
	public int VestSlotChanges;
	public int ShirtSlotChanges;
	
	    public CharacterDataSerializable(CharacterData characterData)
		{
			InCityInventory = characterData.InCityInventory;
			characterName = characterData.characterName;
			ownerPlayerID = characterData.ownerPlayerID;
			health = characterData.health;
			maxhealth = characterData.maxhealth;
			damage = characterData.damage;
			heavyDamage = characterData.heavyDamage;
			armorpierceDamage = characterData.armorpierceDamage;
			softDef = characterData.softDef;
			hardDef = characterData.hardDef;
			characterID = characterData.characterID;
			usableMP = characterData.usableMP;
			maxMP = characterData.maxMP;
			usableAP = characterData.usableAP;
			maxAP = characterData.maxAP;
			attackRange = characterData.attackRange;
			attackChance = characterData.attackChance;
			coverChance = characterData.coverChance;
			transformTo = characterData.transformTo;
			AmmoType = characterData.AmmoType;
			ammoUsage = characterData.ammoUsage;
			spritePath = characterData.spritePath;
			GlobalID = characterData.GlobalID;
			globalIDcurrentCell = characterData.currentCell.GlobalID;
			inventorySize = characterData.characterInventory.inventorySize;
			WeaponSlotChanges = characterData.WeaponSlotChanges;
			AmmoSlotChanges = characterData.AmmoSlotChanges;
			HelmetSlotChanges = characterData.HelmetSlotChanges;
			VestSlotChanges = characterData.VestSlotChanges;
			ShirtSlotChanges = characterData.ShirtSlotChanges;
		}
	}
	
	[System.Serializable]
	public class CellDataSerializable
	{
    public string cellName;
	public int xCoordinate;
    public int yCoordinate;
	public int ownerPlayerID;
	public int Wood;
	public int IronOre;
	public int Saltpeter;
	public int Stone;
	public int Coal;
	public int AluminiumOre;
	public int Oil;
	public int Flax;
	public int CopperOre;
	public int CobaltOre;
	public bool IsOccupied;
	public bool IsOccupiedByCity;
	public string spritePath;
	public float coverChance;
	public int GlobalID;
	public bool forestObject;
	public bool ironMountainObject;
	public bool stoneMountainObject;
	public bool saltpeterMountainObject;
	public bool coalMountainObject;
	public bool copperMountainObject;
	public int smallCityGlobalID;
	public bool Trench = false;
	public bool Mine = false;
	public bool Farm = false;
	public int TomatoCount;
	public int GrainCount;
	public int FlaxCount;
	public int CarrotCount;
	public string CurrentFarm;
	
	    public CellDataSerializable(CellData cellData)
		{
			cellName = cellData.cellName;
			xCoordinate = cellData.xCoordinate;
			yCoordinate = cellData.yCoordinate;
			ownerPlayerID = cellData.ownerPlayerID;
			Wood = cellData.Wood;
			IronOre = cellData.IronOre;
			Saltpeter = cellData.Saltpeter;
			Stone = cellData.Stone;
			Coal = cellData.Coal;
			AluminiumOre = cellData.AluminiumOre;
			Oil = cellData.Oil;
			Flax = cellData.Flax;
			CopperOre = cellData.CopperOre;
			CobaltOre = cellData.CobaltOre;
			IsOccupied = cellData.IsOccupied;
			IsOccupiedByCity = cellData.IsOccupiedByCity;
			spritePath = cellData.spritePath;
			GlobalID = cellData.GlobalID;
			forestObject = cellData.forestObject;
			ironMountainObject = cellData.ironMountainObject;
			stoneMountainObject = cellData.stoneMountainObject;
			saltpeterMountainObject = cellData.saltpeterMountainObject;
			coalMountainObject = cellData.coalMountainObject;
			copperMountainObject = cellData.copperMountainObject;
			coverChance = cellData.coverChance;
			if(cellData.smallCity != null)
			{
				smallCityGlobalID = cellData.smallCity.GlobalID;
			}
			if(cellData.buildingSite == null)
			{
				if(cellData.trench != null)
				{
					Trench = true;
				}
				else if(cellData.mine != null)
				{
					Mine = true;
				}
				else if(cellData.farm != null)
				{
					Farm = true;
					TomatoCount = cellData.farm.TomatoCount;
					GrainCount = cellData.farm.GrainCount;
					FlaxCount = cellData.farm.FlaxCount;
					CarrotCount = cellData.farm.CarrotCount;
					CurrentFarm = cellData.farm.CurrentFarm;
				}
			}
		}
	}
	
    [System.Serializable]
	public struct ObjectData
	{
		public SerializableVector3 position;
		public SerializableVector3 rotation;
		public TradeSerializable tradeSerializable;
		public MashineFactorySerializable mashineFactorySerializable;
		public CharacterDataSerializable characterDataSerializable;
		public CellDataSerializable cellDataSerializable;
		public NodeSerializable nodeSerializable;
		public ItemObjectSerializable itemObjectSerializable;
		public SmallCitySerializable smallCitySerializable;
		public BuildingSiteSerializable buildingSiteSerializable;
		public ForgeSerializable forgeSerializable;
		public TurnRemembererSerializable turnRemembererSerializable;
	}

    [System.Serializable]
    public class SaveData
    {
        public List<ObjectData> objectsData = new List<ObjectData>();
		public string saveFilePath;
		
		public SaveData(string filePath)
		{
			saveFilePath = filePath;
		}
    }

    public static void SaveGame(string saveFileName)
    {
        string saveFilePath = Path.Combine(Application.persistentDataPath, saveFileName);
        SaveData saveData = new SaveData(saveFilePath);
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
			Trade trade = obj.GetComponent<Trade>();
			MashineFactory mashineFactory = obj.GetComponent<MashineFactory>();
			TurnRememberer turnRememberer = obj.GetComponent<TurnRememberer>();
			CharacterData characterData = obj.GetComponent<CharacterData>();
			CellData cellData = obj.GetComponent<CellData>();
			Node node = obj.GetComponent<Node>();
			SmallCity smallCity = obj.GetComponent<SmallCity>();
			ItemObject itemObject = obj.GetComponent<ItemObject>();
			CharacterInventory characterInventory = obj.GetComponent<CharacterInventory>();
			BuildingSite buildingSite = obj.GetComponent<BuildingSite>();
			Forge forge = obj.GetComponent<Forge>();
			
			if (trade != null || mashineFactory != null || turnRememberer != null || forge != null || buildingSite != null || itemObject != null || smallCity != null || characterData != null || cellData != null || node != null)
			{
				ObjectData objectData = new ObjectData
				{
					position = new SerializableVector3(obj.transform.position),
					rotation = new SerializableVector3(obj.transform.rotation.eulerAngles)
				};
				
				if (trade != null)
				{
					TradeSerializable tradeSerializable = new TradeSerializable(trade);
					objectData.tradeSerializable = tradeSerializable;
				}
				
				if (mashineFactory != null)
				{
					MashineFactorySerializable mashineFactorySerializable = new MashineFactorySerializable(mashineFactory);
					objectData.mashineFactorySerializable = mashineFactorySerializable;
				}
				
				if (turnRememberer != null)
				{
					TurnRemembererSerializable turnRemembererSerializable = new TurnRemembererSerializable(turnRememberer);
					objectData.turnRemembererSerializable = turnRemembererSerializable;
				}
				
				if (characterData != null)
				{
					CharacterDataSerializable characterDataSerializable = new CharacterDataSerializable(characterData);
					objectData.characterDataSerializable = characterDataSerializable;
				}
				
				if (cellData != null)
				{
					CellDataSerializable cellDataSerializable = new CellDataSerializable(cellData);
					objectData.cellDataSerializable = cellDataSerializable;
				}
				
				if (itemObject != null)
				{
					ItemObjectSerializable itemObjectSerializable = new ItemObjectSerializable(itemObject);
					objectData.itemObjectSerializable = itemObjectSerializable;
				}
				
				if (smallCity != null)
				{
					SmallCitySerializable smallCitySerializable = new SmallCitySerializable(smallCity);
					objectData.smallCitySerializable = smallCitySerializable;
				}
				
				if (node != null)
				{
					NodeSerializable nodeSerializable = new NodeSerializable(node);
					objectData.nodeSerializable = nodeSerializable;
				}
				
				if (buildingSite != null)
				{
					BuildingSiteSerializable buildingSiteSerializable = new BuildingSiteSerializable(buildingSite);
					objectData.buildingSiteSerializable = buildingSiteSerializable;
				}
				else if (forge != null)
				{
					ForgeSerializable forgeSerializable = new ForgeSerializable(forge);
					objectData.forgeSerializable = forgeSerializable;
				}
				saveData.objectsData.Add(objectData);
			}
			if (cellData != null)
			{
				obj.AddComponent<OldTile>();
			}
		}

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = File.Create(saveFileName))
        {
            formatter.Serialize(fileStream, saveData);
        }

        Debug.Log("Game saved!");
    }

    public static void LoadGame(string saveFileName)
    {
        if (File.Exists(saveFileName))
        {
			GridGenerator gridGenerator = GameObject.FindObjectsOfType<GridGenerator>().FirstOrDefault();
			gridGenerator.cellManager.ClearAllCells();
			Trade trade = GameObject.FindObjectsOfType<Trade>().FirstOrDefault();
			GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
			foreach (GameObject obj in allObjects)
			{
				MashineFactory mashineFactory = obj.GetComponent<MashineFactory>();
				TurnRememberer turnRememberer = obj.GetComponent<TurnRememberer>();
				Mine mine = obj.GetComponent<Mine>();
				Forge forge = obj.GetComponent<Forge>();
				Trench trench = obj.GetComponent<Trench>();
				Farm farm = obj.GetComponent<Farm>();
				BuildingSite buildingSite = obj.GetComponent<BuildingSite>();
				CharacterData characterData = obj.GetComponent<CharacterData>();
				CellData cellData = obj.GetComponent<CellData>();
				Forest forest = obj.GetComponent<Forest>();
				IronMountain ironMountain = obj.GetComponent<IronMountain>();
				StoneMountain stoneMountain = obj.GetComponent<StoneMountain>();
				SaltpeterMountain saltpeterMountain = obj.GetComponent<SaltpeterMountain>();
				CoalMountain coalMountain = obj.GetComponent<CoalMountain>();
				CopperMountain copperMountain = obj.GetComponent<CopperMountain>();
				SmallCity smallCity = obj.GetComponent<SmallCity>();
				ItemObject itemObject = obj.GetComponent<ItemObject>();
				
				if (mashineFactory != null || turnRememberer != null || mine != null || farm != null || trench != null || forge != null || buildingSite != null || itemObject != null || smallCity != null || characterData != null || cellData != null || forest != null || ironMountain != null || stoneMountain != null || saltpeterMountain != null || coalMountain != null || copperMountain != null)
				{
					UnityEngine.Object.Destroy(obj);
				}
			}
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = File.Open(saveFileName, FileMode.Open))
            {
                SaveData saveData = (SaveData)formatter.Deserialize(fileStream);
				
                foreach (ObjectData objectData in saveData.objectsData)
                {
                    GameObject obj = new GameObject();
                    obj.transform.position = objectData.position.ToVector3();
                    obj.transform.rotation = Quaternion.Euler(objectData.rotation.ToVector3());
					
					TradeSerializable tradeSerializable = objectData.tradeSerializable;
					if (tradeSerializable != null)
					{
						trade.WoodCount = tradeSerializable.WoodCount;
						trade.WoodSellPrice = tradeSerializable.WoodSellPrice;
						trade.WoodBuyPrice = tradeSerializable.WoodBuyPrice;
						trade.CoalCount = tradeSerializable.CoalCount;
						trade.CoalSellPrice = tradeSerializable.CoalSellPrice;
						trade.CoalBuyPrice = tradeSerializable.CoalBuyPrice;
						trade.IronOreCount = tradeSerializable.IronOreCount;
						trade.IronOreSellPrice = tradeSerializable.IronOreSellPrice;
						trade.IronOreBuyPrice = tradeSerializable.IronOreBuyPrice;
						trade.IronIgnotCount = tradeSerializable.IronIgnotCount;
						trade.IronIgnotSellPrice = tradeSerializable.IronIgnotSellPrice;
						trade.IronIgnotBuyPrice = tradeSerializable.IronIgnotBuyPrice;
						trade.StoneCount = tradeSerializable.StoneCount;
						trade.StoneSellPrice = tradeSerializable.StoneSellPrice;
						trade.StoneBuyPrice = tradeSerializable.StoneBuyPrice;
						trade.SaltpeterCount = tradeSerializable.SaltpeterCount;
						trade.SaltpeterSellPrice = tradeSerializable.SaltpeterSellPrice;
						trade.SaltpeterBuyPrice = tradeSerializable.SaltpeterBuyPrice;
						trade.GunpowderCount = tradeSerializable.GunpowderCount;
						trade.GunpowderSellPrice = tradeSerializable.GunpowderSellPrice;
						trade.GunpowderBuyPrice = tradeSerializable.GunpowderBuyPrice;
						trade.AluminiumOreCount = tradeSerializable.AluminiumOreCount;
						trade.AluminiumOreSellPrice = tradeSerializable.AluminiumOreSellPrice;
						trade.AluminiumOreBuyPrice = tradeSerializable.AluminiumOreBuyPrice;
						trade.AluminiumIgnotCount = tradeSerializable.AluminiumIgnotCount;
						trade.AluminiumIgnotSellPrice = tradeSerializable.AluminiumIgnotSellPrice;
						trade.AluminiumIgnotBuyPrice = tradeSerializable.AluminiumIgnotBuyPrice;
						trade.CopperOreCount = tradeSerializable.CopperOreCount;
						trade.CopperOreSellPrice = tradeSerializable.CopperOreSellPrice;
						trade.CopperOreBuyPrice = tradeSerializable.CopperOreBuyPrice;
						trade.CopperIgnotCount = tradeSerializable.CopperIgnotCount;
						trade.CopperIgnotSellPrice = tradeSerializable.CopperIgnotSellPrice;
						trade.CopperIgnotBuyPrice = tradeSerializable.CopperIgnotBuyPrice;
						trade.FlaxCount = tradeSerializable.FlaxCount;
						trade.FlaxSellPrice = tradeSerializable.FlaxSellPrice;
						trade.FlaxBuyPrice = tradeSerializable.FlaxBuyPrice;
						trade.FlaxFabricCount = tradeSerializable.FlaxFabricCount;
						trade.FlaxFabricSellPrice = tradeSerializable.FlaxFabricSellPrice;
						trade.FlaxFabricBuyPrice = tradeSerializable.FlaxFabricBuyPrice;
						trade.OilCount = tradeSerializable.OilCount;
						trade.OilSellPrice = tradeSerializable.OilSellPrice;
						trade.OilBuyPrice = tradeSerializable.OilBuyPrice;
						trade.PetrolCount = tradeSerializable.PetrolCount;
						trade.PetrolSellPrice = tradeSerializable.PetrolSellPrice;
						trade.PetrolBuyPrice = tradeSerializable.PetrolBuyPrice;
						trade.CobaltOreCount = tradeSerializable.CobaltOreCount;
						trade.CobaltOreSellPrice = tradeSerializable.CobaltOreSellPrice;
						trade.CobaltOreBuyPrice = tradeSerializable.CobaltOreBuyPrice;
						trade.CobaltIgnotCount = tradeSerializable.CobaltIgnotCount;
						trade.CobaltIgnotSellPrice = tradeSerializable.CobaltIgnotSellPrice;
						trade.CobaltIgnotBuyPrice = tradeSerializable.CobaltIgnotBuyPrice;
						trade.PlasticCount = tradeSerializable.PlasticCount;
						trade.PlasticSellPrice = tradeSerializable.PlasticSellPrice;
						trade.PlasticBuyPrice = tradeSerializable.PlasticBuyPrice;
						trade.GrainCount = trade.GrainCount;
						trade.GrainSellPrice = trade.GrainSellPrice;
						trade.GrainBuyPrice = trade.GrainBuyPrice;
						trade.CarrotCount = trade.CarrotCount;
						trade.CarrotSellPrice = trade.CarrotSellPrice;
						trade.CarrotBuyPrice = trade.CarrotBuyPrice;
						trade.TomatoCount = trade.TomatoCount;
						trade.TomatoSellPrice = trade.TomatoSellPrice;
						trade.TomatoBuyPrice = trade.TomatoBuyPrice;
						trade.DoveCount = trade.DoveCount;
						trade.DoveSellPrice = trade.DoveSellPrice;
						trade.DoveBuyPrice = trade.DoveBuyPrice;
						trade.BreadCount = trade.BreadCount;
						trade.BreadSellPrice = trade.BreadSellPrice;
						trade.BreadBuyPrice = trade.BreadBuyPrice;
					}
					
					MashineFactorySerializable mashineFactorySerializable = objectData.mashineFactorySerializable;
					if (mashineFactorySerializable != null)
					{
						MashineFactory mashineFactory = obj.AddComponent<MashineFactory>();
						mashineFactory.ownerPlayerID = mashineFactorySerializable.ownerPlayerID;
						mashineFactory.GlobalID = mashineFactorySerializable.GlobalID;
						mashineFactory.currentCellGlobalID = mashineFactorySerializable.currentCellGlobalID;
						mashineFactory.Population = mashineFactorySerializable.Population;
						mashineFactory.PopulationAP = mashineFactorySerializable.PopulationAP;
						mashineFactory.PopulationMaxAP = mashineFactorySerializable.PopulationMaxAP;
					}
					
					TurnRemembererSerializable turnRemembererSerializable = objectData.turnRemembererSerializable;
					if (turnRemembererSerializable != null)
					{
						TurnRememberer turnRememberer = obj.AddComponent<TurnRememberer>();
						turnRememberer.currentTurn = turnRemembererSerializable.currentTurn;
						turnRememberer.currentPlayer = turnRemembererSerializable.currentPlayer;
					}
					
					ForgeSerializable forgeSerializable = objectData.forgeSerializable;
					if (forgeSerializable != null)
					{
						Forge forge = obj.AddComponent<Forge>();
						forge.ownerPlayerID = forgeSerializable.ownerPlayerID;
						forge.Population = forgeSerializable.Population;
						forge.PopulationAP = forgeSerializable.PopulationAP;
						forge.PopulationMaxAP = forgeSerializable.PopulationMaxAP;
						forge.GlobalID = forgeSerializable.GlobalID;
						forge.currentCellGlobalID = forgeSerializable.currentCellGlobalID;
						forge.forgeObject = obj;
						
						SpriteRenderer forgeSpriteRenderer = obj.AddComponent<SpriteRenderer>();
						string spritePath = "Sprites/Building/Building";
						Sprite forgeSprite = Resources.Load<Sprite>(spritePath);
						forgeSpriteRenderer.sprite = forgeSprite;
						forgeSpriteRenderer.sortingLayerName = "Forest Layer";
					}
					
					BuildingSiteSerializable buildingSiteSerializable = objectData.buildingSiteSerializable;
					if (buildingSiteSerializable != null)
					{
						BuildingSite buildingSite = obj.AddComponent<BuildingSite>();
						buildingSite.WoodToBuild = buildingSiteSerializable.WoodToBuild;
						buildingSite.StoneToBuild = buildingSiteSerializable.StoneToBuild;
						buildingSite.TurnToBuild = buildingSiteSerializable.TurnToBuild;
						buildingSite.IronToBuild = buildingSiteSerializable.IronToBuild;
						buildingSite.spritePath = buildingSiteSerializable.spritePath;
						buildingSite.currentCellGlobalID = buildingSiteSerializable.currentCellGlobalID;
						if(buildingSiteSerializable.mine)
						{
							Mine mine = obj.AddComponent<Mine>();
							buildingSite.mine = mine;
						}
						if(buildingSiteSerializable.forge)
						{
							Forge forge = obj.AddComponent<Forge>();
							forge.forgeObject = obj;
							forge.GlobalID = buildingSiteSerializable.GlobalID;
						}
						if(buildingSiteSerializable.farm)
						{
							Farm farm = obj.AddComponent<Farm>();
							buildingSite.farm = farm;
						}
						if(buildingSiteSerializable.trench)
						{
							Trench trench = obj.AddComponent<Trench>();
							buildingSite.trench = trench;
						}
						if(buildingSiteSerializable.preTrench)
						{
							PreTrench preTrench = obj.AddComponent<PreTrench>();
							buildingSite.preTrench = preTrench;
						}
						
						SpriteRenderer spriteRenderer = obj.AddComponent<SpriteRenderer>();
						Sprite buildingSiteSprite = Resources.Load<Sprite>(buildingSite.spritePath);
						spriteRenderer.sprite = buildingSiteSprite;
						spriteRenderer.sortingLayerName = "City Layer";
					}
						
					ItemObjectSerializable itemObjectSerializable = objectData.itemObjectSerializable;
					if (itemObjectSerializable != null)
					{
						ItemObject itemObject = obj.AddComponent<ItemObject>();
						itemObject.itemName = itemObjectSerializable.itemName;
						itemObject.itemID = itemObjectSerializable.itemID;
						itemObject.quantity = itemObjectSerializable.quantity;
						itemObject.maxquantity = itemObjectSerializable.maxquantity;
						itemObject.damage = itemObjectSerializable.damage;
						itemObject.heavyDamage = itemObjectSerializable.heavyDamage;
						itemObject.armorpierceDamage = itemObjectSerializable.armorpierceDamage;
						itemObject.health = itemObjectSerializable.health;
						itemObject.softDef = itemObjectSerializable.softDef;
						itemObject.hardDef = itemObjectSerializable.hardDef;
						itemObject.attackRange = itemObjectSerializable.attackRange;
						itemObject.slots = itemObjectSerializable.slots;
						itemObject.attackChance = itemObjectSerializable.attackChance;
						itemObject.coverChance = itemObjectSerializable.coverChance;
						itemObject.maximalMP = itemObjectSerializable.maximalMP;
						itemObject.AmmoType = itemObjectSerializable.AmmoType;
						itemObject.ammoUsage = itemObjectSerializable.ammoUsage;
						itemObject.SpritePath = itemObjectSerializable.SpritePath;
						itemObject.GlobalIDowner = itemObjectSerializable.GlobalIDowner; 
						itemObject.thisItem = obj;
						itemObject.IsWeared = itemObjectSerializable.IsWeared;
						itemObject.itemType = itemObjectSerializable.itemType;
						
						Sprite itemSprite = Resources.Load<Sprite>(itemObject.SpritePath);
						itemObject.itemSprite = itemSprite;
						
						obj.name = itemObject.itemName;
					}
					
					CellDataSerializable cellDataSerializable = objectData.cellDataSerializable;
					if (cellDataSerializable != null)
					{
						CellData cellData = obj.AddComponent<CellData>();
						cellData.cellName = cellDataSerializable.cellName;
						cellData.xCoordinate = cellDataSerializable.xCoordinate;
						cellData.yCoordinate = cellDataSerializable.yCoordinate;
						cellData.ownerPlayerID = cellDataSerializable.ownerPlayerID;
						cellData.Wood = cellDataSerializable.Wood;
						cellData.IronOre = cellDataSerializable.IronOre;
						cellData.Saltpeter = cellDataSerializable.Saltpeter;
						cellData.Stone = cellDataSerializable.Stone;
						cellData.Coal = cellDataSerializable.Coal;
						cellData.AluminiumOre = cellDataSerializable.AluminiumOre;
						cellData.Oil = cellDataSerializable.Oil;
						cellData.Flax = cellDataSerializable.Flax;
						cellData.CopperOre = cellDataSerializable.CopperOre;
						cellData.CobaltOre = cellDataSerializable.CobaltOre;
						cellData.IsOccupied = cellDataSerializable.IsOccupied;
						cellData.IsOccupiedByCity = cellDataSerializable.IsOccupiedByCity;
						cellData.spritePath = cellDataSerializable.spritePath;
						cellData.GlobalID = cellDataSerializable.GlobalID;
						cellData.currentCell = obj;
						cellData.smallCityGlobalID = cellDataSerializable.smallCityGlobalID;
						
						obj.name = cellData.cellName;
						SpriteRenderer spriteRenderer = obj.AddComponent<SpriteRenderer>();
						Sprite cellSprite = Resources.Load<Sprite>(cellData.spritePath);
						spriteRenderer.sprite = cellSprite;
						spriteRenderer.sortingLayerName = "Terrain Layer";
						BoxCollider2D collider = obj.AddComponent<BoxCollider2D>();
						float cellSize = 0.96f;
						collider.size = new Vector2(cellSize, cellSize);
						int terrainLayer = LayerMask.NameToLayer("Terrain");
						if (terrainLayer == -1)
						{
							terrainLayer = LayerMask.NameToLayer("Terrain");
						}
						obj.layer = terrainLayer;
						
						TileInfoLoader existingTileInfoLoader = gridGenerator.existingTileInfoLoader;
						TileInfoLoader tileInfoLoader = obj.AddComponent<TileInfoLoader>();
						if (existingTileInfoLoader != null)
						{
							tileInfoLoader.infoPanel = existingTileInfoLoader.infoPanel;
							tileInfoLoader.tileNameText = existingTileInfoLoader.tileNameText;
							tileInfoLoader.tileIDText = existingTileInfoLoader.tileIDText;
							tileInfoLoader.tileCoordinatesText = existingTileInfoLoader.tileCoordinatesText;
							tileInfoLoader.tileOwnerText = existingTileInfoLoader.tileOwnerText;
							tileInfoLoader.tileWoodText = existingTileInfoLoader.tileWoodText;
							tileInfoLoader.tileIronOreText = existingTileInfoLoader.tileIronOreText;
							tileInfoLoader.tileSaltpeterText = existingTileInfoLoader.tileSaltpeterText;
							tileInfoLoader.tileStoneText = existingTileInfoLoader.tileStoneText;
							tileInfoLoader.tileCoalText = existingTileInfoLoader.tileCoalText;
							tileInfoLoader.tileAluminiumOreText = existingTileInfoLoader.tileAluminiumOreText;
							tileInfoLoader.tileOilText = existingTileInfoLoader.tileOilText;
							tileInfoLoader.tileFlaxText = existingTileInfoLoader.tileFlaxText;
							tileInfoLoader.tileCopperOreText = existingTileInfoLoader.tileCopperOreText;
							tileInfoLoader.tileCobaltOreText = existingTileInfoLoader.tileCobaltOreText;
							tileInfoLoader.tileMPcostText = existingTileInfoLoader.tileMPcostText;
							tileInfoLoader.tileInfoController = existingTileInfoLoader.tileInfoController;
						}
						if(cellDataSerializable.forestObject)
						{
							GameObject forestObj = new GameObject("Forest");
							forestObj.transform.position = cellData.transform.position;
							SpriteRenderer forestSpriteRenderer = forestObj.AddComponent<SpriteRenderer>();
							string spritePath = "Sprites/Terrain/Forest";
							Sprite forestSprite = Resources.Load<Sprite>(spritePath);
							forestSpriteRenderer.sprite = forestSprite;
							forestSpriteRenderer.sortingLayerName = "Forest Layer";
							cellData.forestObject = forestObj;
						}
						if(cellDataSerializable.ironMountainObject)
						{
							GameObject mountainObj = new GameObject("Iron Mountain");
							mountainObj.transform.position = cellData.transform.position;
							SpriteRenderer mountainSpriteRenderer = mountainObj.AddComponent<SpriteRenderer>();
							string spritePath = "Sprites/Terrain/Mountain";
							Sprite mountainSprite = Resources.Load<Sprite>(spritePath);
							mountainSpriteRenderer.sprite = mountainSprite;
							mountainSpriteRenderer.sortingLayerName = "Forest Layer";
							cellData.ironMountainObject = mountainObj;
						}
						if(cellDataSerializable.stoneMountainObject)
						{
							GameObject mountainObj = new GameObject("Stone Mountain");
							mountainObj.transform.position = cellData.transform.position;
							SpriteRenderer mountainSpriteRenderer = mountainObj.AddComponent<SpriteRenderer>();
							string spritePath = "Sprites/Terrain/Mountain";
							Sprite mountainSprite = Resources.Load<Sprite>(spritePath);
							mountainSpriteRenderer.sprite = mountainSprite;
							mountainSpriteRenderer.sortingLayerName = "Forest Layer";
							cellData.stoneMountainObject = mountainObj;
						}
						if(cellDataSerializable.saltpeterMountainObject)
						{
							GameObject mountainObj = new GameObject("Saltpeter Mountain");
							mountainObj.transform.position = cellData.transform.position;
							SpriteRenderer mountainSpriteRenderer = mountainObj.AddComponent<SpriteRenderer>();
							string spritePath = "Sprites/Terrain/Mountain";
							Sprite mountainSprite = Resources.Load<Sprite>(spritePath);
							mountainSpriteRenderer.sprite = mountainSprite;
							mountainSpriteRenderer.sortingLayerName = "Forest Layer";
							cellData.saltpeterMountainObject = mountainObj;
						}
						if(cellDataSerializable.coalMountainObject)
						{
							GameObject mountainObj = new GameObject("Coal Mountain");
							mountainObj.transform.position = cellData.transform.position;
							SpriteRenderer mountainSpriteRenderer = mountainObj.AddComponent<SpriteRenderer>();
							string spritePath = "Sprites/Terrain/Mountain";
							Sprite mountainSprite = Resources.Load<Sprite>(spritePath);
							mountainSpriteRenderer.sprite = mountainSprite;
							mountainSpriteRenderer.sortingLayerName = "Forest Layer";
							cellData.coalMountainObject = mountainObj;
						}
						if(cellDataSerializable.copperMountainObject)
						{
							GameObject mountainObj = new GameObject("Copper Mountain");
							mountainObj.transform.position = cellData.transform.position;
							SpriteRenderer mountainSpriteRenderer = mountainObj.AddComponent<SpriteRenderer>();
							string spritePath = "Sprites/Terrain/Mountain";
							Sprite mountainSprite = Resources.Load<Sprite>(spritePath);
							mountainSpriteRenderer.sprite = mountainSprite;
							mountainSpriteRenderer.sortingLayerName = "Forest Layer";
							cellData.copperMountainObject = mountainObj;
						}
						if(cellDataSerializable.Trench)
						{
							GameObject trenchObj = new GameObject("Trench");
							trenchObj.transform.position = cellData.transform.position;
							Trench trench = trenchObj.AddComponent<Trench>();
							SpriteRenderer trenchSpriteRenderer = trenchObj.AddComponent<SpriteRenderer>();
							string spritePath = "Sprites/Building/Trench";
							Sprite mountainSprite = Resources.Load<Sprite>(spritePath);
							trenchSpriteRenderer.sprite = mountainSprite;
							trenchSpriteRenderer.sortingLayerName = "Forest Layer";
							cellData.trench = trench;
						}
						if(cellDataSerializable.Mine)
						{
							GameObject mineObj = new GameObject("Mine");
							mineObj.transform.position = cellData.transform.position;
							Mine mine = mineObj.AddComponent<Mine>();
							SpriteRenderer mineSpriteRenderer = mineObj.AddComponent<SpriteRenderer>();
							string spritePath = "Sprites/Building/Mine";
							Sprite mountainSprite = Resources.Load<Sprite>(spritePath);
							mineSpriteRenderer.sprite = mountainSprite;
							mineSpriteRenderer.sortingLayerName = "Forest Layer";
							cellData.mine = mine;
						}
						if(cellDataSerializable.Farm)
						{
							GameObject farmObj = new GameObject("Farm");
							farmObj.transform.position = cellData.transform.position;
							Farm farm = farmObj.AddComponent<Farm>();
							farm.ownerPlayerID = cellData.ownerPlayerID;
							SpriteRenderer farmSpriteRenderer = farmObj.AddComponent<SpriteRenderer>();
							string spritePath = "Sprites/Building/Farm";
							Sprite mountainSprite = Resources.Load<Sprite>(spritePath);
							farmSpriteRenderer.sprite = mountainSprite;
							farmSpriteRenderer.sortingLayerName = "Forest Layer";
							cellData.farm = farm;
							farm.cellData = cellData;
							farm.finished = 1;
							farm.TomatoCount = cellDataSerializable.TomatoCount;
							farm.GrainCount = cellDataSerializable.GrainCount;
							farm.FlaxCount = cellDataSerializable.FlaxCount;
							farm.CarrotCount = cellDataSerializable.CarrotCount;
							farm.CurrentFarm = cellDataSerializable.CurrentFarm;
						}
					}
					
					NodeSerializable nodeSerializable = objectData.nodeSerializable;
					if (nodeSerializable != null)
					{
						Node node = obj.AddComponent<Node>();
						node.gridX = nodeSerializable.gridX;
						node.gridY = nodeSerializable.gridY;
						node.baseCost = nodeSerializable.baseCost;
						node.gCost = nodeSerializable.gCost;
						node.hCost = nodeSerializable.hCost;
						node.GlobalID = nodeSerializable.GlobalID;
						CellData cellData = obj.GetComponent<CellData>();
						node.cellData = cellData;
						node.cellData.node = node;
					}
					
					SmallCitySerializable smallCitySerializable = objectData.smallCitySerializable;
					if (smallCitySerializable != null)
					{
						obj.layer = LayerMask.NameToLayer("City");
						BoxCollider2D collider = obj.AddComponent<BoxCollider2D>();
						SmallCity smallCity = obj.AddComponent<SmallCity>();
						smallCity.MobilizationInProgress = smallCitySerializable.MobilizationInProgress;
						smallCity.cityName = smallCitySerializable.cityName;
						smallCity.cityID = smallCitySerializable.cityID;
						smallCity.turnToResearch = smallCitySerializable.turnToResearch;
						smallCity.ownerPlayerID = smallCitySerializable.ownerPlayerID;
						smallCity.PopulationWorkable = smallCitySerializable.PopulationWorkable;
						smallCity.Population = smallCitySerializable.Population;
						smallCity.PopulationAP = smallCitySerializable.PopulationAP;
						smallCity.PopulationMaxAP = smallCitySerializable.PopulationMaxAP;
						smallCity.GlobalID = smallCitySerializable.GlobalID;
						smallCity.spritePath = smallCitySerializable.spritePath;
						smallCity.ThisCity = obj;
						smallCity.aIDefendDrone1 = smallCitySerializable.AIDefendDrone1;
						smallCity.aIDefendDrone2 = smallCitySerializable.AIDefendDrone2;
						smallCity.aIAttackDrone1 = smallCitySerializable.AIAttackDrone1;
						smallCity.aIAttackDrone2 = smallCitySerializable.AIAttackDrone2;
						smallCity.aIAttackDrone3 = smallCitySerializable.AIAttackDrone3;
				
						smallCity.PopulationAge0M = smallCitySerializable.PopulationAge0M;
						smallCity.PopulationAge0W = smallCitySerializable.PopulationAge0W;
						smallCity.PopulationAge1M = smallCitySerializable.PopulationAge1M;
						smallCity.PopulationAge1W = smallCitySerializable.PopulationAge1W;
						smallCity.PopulationAge2M = smallCitySerializable.PopulationAge2M;
						smallCity.PopulationAge2W = smallCitySerializable.PopulationAge2W;
						smallCity.PopulationAge3M = smallCitySerializable.PopulationAge3M;
						smallCity.PopulationAge3W = smallCitySerializable.PopulationAge3W;
						smallCity.PopulationAge4M = smallCitySerializable.PopulationAge4M;
						smallCity.PopulationAge4W = smallCitySerializable.PopulationAge4W;
						smallCity.PopulationAge5M = smallCitySerializable.PopulationAge5M;
						smallCity.PopulationAge5W = smallCitySerializable.PopulationAge5W;
						smallCity.PopulationAge6M = smallCitySerializable.PopulationAge6M;
						smallCity.PopulationAge6W = smallCitySerializable.PopulationAge6W;
						smallCity.PopulationAge7M = smallCitySerializable.PopulationAge7M;
						smallCity.PopulationAge7W = smallCitySerializable.PopulationAge7W;
						smallCity.PopulationAge8M = smallCitySerializable.PopulationAge8M;
						smallCity.PopulationAge8W = smallCitySerializable.PopulationAge8W;
						smallCity.PopulationAge9M = smallCitySerializable.PopulationAge9M;
						smallCity.PopulationAge9W = smallCitySerializable.PopulationAge9W;
						smallCity.PopulationAge10M = smallCitySerializable.PopulationAge10M;
						smallCity.PopulationAge10W = smallCitySerializable.PopulationAge10W;
						smallCity.PopulationAge11M = smallCitySerializable.PopulationAge11M;
						smallCity.PopulationAge11W = smallCitySerializable.PopulationAge11W;
						smallCity.PopulationAge12M = smallCitySerializable.PopulationAge12M;
						smallCity.PopulationAge12W = smallCitySerializable.PopulationAge12W;
						smallCity.PopulationAge13M = smallCitySerializable.PopulationAge13M;
						smallCity.PopulationAge13W = smallCitySerializable.PopulationAge13W;
						smallCity.PopulationAge14M = smallCitySerializable.PopulationAge14M;
						smallCity.PopulationAge14W = smallCitySerializable.PopulationAge14W;
						smallCity.PopulationAge15M = smallCitySerializable.PopulationAge15M;
						smallCity.PopulationAge15W = smallCitySerializable.PopulationAge15W;
						smallCity.PopulationAge16M = smallCitySerializable.PopulationAge16M;
						smallCity.PopulationAge16W = smallCitySerializable.PopulationAge16W;
						smallCity.PopulationAge17M = smallCitySerializable.PopulationAge17M;
						smallCity.PopulationAge17W = smallCitySerializable.PopulationAge17W;
						smallCity.PopulationAge18M = smallCitySerializable.PopulationAge18M;
						smallCity.PopulationAge18W = smallCitySerializable.PopulationAge18W;
						smallCity.PopulationAge19M = smallCitySerializable.PopulationAge19M;
						smallCity.PopulationAge19W = smallCitySerializable.PopulationAge19W;
						smallCity.PopulationAge20M = smallCitySerializable.PopulationAge20M;
						smallCity.PopulationAge20W = smallCitySerializable.PopulationAge20W;
						smallCity.PopulationAge21M = smallCitySerializable.PopulationAge21M;
						smallCity.PopulationAge21W = smallCitySerializable.PopulationAge21W;
						smallCity.PopulationAge22M = smallCitySerializable.PopulationAge22M;
						smallCity.PopulationAge22W = smallCitySerializable.PopulationAge22W;
						smallCity.PopulationAge23M = smallCitySerializable.PopulationAge23M;
						smallCity.PopulationAge23W = smallCitySerializable.PopulationAge23W;
						smallCity.PopulationAge24M = smallCitySerializable.PopulationAge24M;
						smallCity.PopulationAge24W = smallCitySerializable.PopulationAge24W;
						smallCity.PopulationAge25M = smallCitySerializable.PopulationAge25M;
						smallCity.PopulationAge25W = smallCitySerializable.PopulationAge25W;
						smallCity.PopulationAge26M = smallCitySerializable.PopulationAge26M;
						smallCity.PopulationAge26W = smallCitySerializable.PopulationAge26W;
						smallCity.PopulationAge27M = smallCitySerializable.PopulationAge27M;
						smallCity.PopulationAge27W = smallCitySerializable.PopulationAge27W;
						smallCity.PopulationAge28M = smallCitySerializable.PopulationAge28M;
						smallCity.PopulationAge28W = smallCitySerializable.PopulationAge28W;
						smallCity.PopulationAge29M = smallCitySerializable.PopulationAge29M;
						smallCity.PopulationAge29W = smallCitySerializable.PopulationAge29W;
						smallCity.PopulationAge30M = smallCitySerializable.PopulationAge30M;
						smallCity.PopulationAge30W = smallCitySerializable.PopulationAge30W;
						smallCity.PopulationAge31M = smallCitySerializable.PopulationAge31M;
						smallCity.PopulationAge31W = smallCitySerializable.PopulationAge31W;
						smallCity.PopulationAge32M = smallCitySerializable.PopulationAge32M;
						smallCity.PopulationAge32W = smallCitySerializable.PopulationAge32W;
						smallCity.PopulationAge33M = smallCitySerializable.PopulationAge33M;
						smallCity.PopulationAge33W = smallCitySerializable.PopulationAge33W;
						smallCity.PopulationAge34M = smallCitySerializable.PopulationAge34M;
						smallCity.PopulationAge34W = smallCitySerializable.PopulationAge34W;
						smallCity.PopulationAge35M = smallCitySerializable.PopulationAge35M;
						smallCity.PopulationAge35W = smallCitySerializable.PopulationAge35W;
						smallCity.PopulationAge36M = smallCitySerializable.PopulationAge36M;
						smallCity.PopulationAge36W = smallCitySerializable.PopulationAge36W;
						smallCity.PopulationAge37M = smallCitySerializable.PopulationAge37M;
						smallCity.PopulationAge37W = smallCitySerializable.PopulationAge37W;
						smallCity.PopulationAge38M = smallCitySerializable.PopulationAge38M;
						smallCity.PopulationAge38W = smallCitySerializable.PopulationAge38W;
						smallCity.PopulationAge39M = smallCitySerializable.PopulationAge39M;
						smallCity.PopulationAge39W = smallCitySerializable.PopulationAge39W;
						smallCity.PopulationAge40M = smallCitySerializable.PopulationAge40M;
						smallCity.PopulationAge40W = smallCitySerializable.PopulationAge40W;
						smallCity.PopulationAge41M = smallCitySerializable.PopulationAge41M;
						smallCity.PopulationAge41W = smallCitySerializable.PopulationAge41W;
						smallCity.PopulationAge42M = smallCitySerializable.PopulationAge42M;
						smallCity.PopulationAge42W = smallCitySerializable.PopulationAge42W;
						smallCity.PopulationAge43M = smallCitySerializable.PopulationAge43M;
						smallCity.PopulationAge43W = smallCitySerializable.PopulationAge43W;
						smallCity.PopulationAge44M = smallCitySerializable.PopulationAge44M;
						smallCity.PopulationAge44W = smallCitySerializable.PopulationAge44W;
						smallCity.PopulationAge45M = smallCitySerializable.PopulationAge45M;
						smallCity.PopulationAge45W = smallCitySerializable.PopulationAge45W;
						smallCity.PopulationAge46M = smallCitySerializable.PopulationAge46M;
						smallCity.PopulationAge46W = smallCitySerializable.PopulationAge46W;
						smallCity.PopulationAge47M = smallCitySerializable.PopulationAge47M;
						smallCity.PopulationAge47W = smallCitySerializable.PopulationAge47W;
						smallCity.PopulationAge48M = smallCitySerializable.PopulationAge48M;
						smallCity.PopulationAge48W = smallCitySerializable.PopulationAge48W;
						smallCity.PopulationAge49M = smallCitySerializable.PopulationAge49M;
						smallCity.PopulationAge49W = smallCitySerializable.PopulationAge49W;
						smallCity.PopulationAge50M = smallCitySerializable.PopulationAge50M;
						smallCity.PopulationAge50W = smallCitySerializable.PopulationAge50W;
						smallCity.PopulationAge51M = smallCitySerializable.PopulationAge51M;
						smallCity.PopulationAge51W = smallCitySerializable.PopulationAge51W;
						smallCity.PopulationAge52M = smallCitySerializable.PopulationAge52M;
						smallCity.PopulationAge52W = smallCitySerializable.PopulationAge52W;
						smallCity.PopulationAge53M = smallCitySerializable.PopulationAge53M;
						smallCity.PopulationAge53W = smallCitySerializable.PopulationAge53W;
						smallCity.PopulationAge54M = smallCitySerializable.PopulationAge54M;
						smallCity.PopulationAge54W = smallCitySerializable.PopulationAge54W;
						smallCity.PopulationAge55M = smallCitySerializable.PopulationAge55M;
						smallCity.PopulationAge55W = smallCitySerializable.PopulationAge55W;
						smallCity.PopulationAge56M = smallCitySerializable.PopulationAge56M;
						smallCity.PopulationAge56W = smallCitySerializable.PopulationAge56W;
						smallCity.PopulationAge57M = smallCitySerializable.PopulationAge57M;
						smallCity.PopulationAge57W = smallCitySerializable.PopulationAge57W;
						smallCity.PopulationAge58M = smallCitySerializable.PopulationAge58M;
						smallCity.PopulationAge58W = smallCitySerializable.PopulationAge58W;
						smallCity.PopulationAge59M = smallCitySerializable.PopulationAge59M;
						smallCity.PopulationAge59W = smallCitySerializable.PopulationAge59W;
						smallCity.PopulationAge60M = smallCitySerializable.PopulationAge60M;
						smallCity.PopulationAge60W = smallCitySerializable.PopulationAge60W;
						smallCity.PopulationAge61M = smallCitySerializable.PopulationAge61M;
						smallCity.PopulationAge61W = smallCitySerializable.PopulationAge61W;
						smallCity.PopulationAge62M = smallCitySerializable.PopulationAge62M;
						smallCity.PopulationAge62W = smallCitySerializable.PopulationAge62W;
						smallCity.PopulationAge63M = smallCitySerializable.PopulationAge63M;
						smallCity.PopulationAge63W = smallCitySerializable.PopulationAge63W;
						smallCity.PopulationAge64M = smallCitySerializable.PopulationAge64M;
						smallCity.PopulationAge64W = smallCitySerializable.PopulationAge64W;
						smallCity.PopulationAge65M = smallCitySerializable.PopulationAge65M;
						smallCity.PopulationAge65W = smallCitySerializable.PopulationAge65W;
						smallCity.PopulationAge66M = smallCitySerializable.PopulationAge66M;
						smallCity.PopulationAge66W = smallCitySerializable.PopulationAge66W;
						smallCity.PopulationAge67M = smallCitySerializable.PopulationAge67M;
						smallCity.PopulationAge67W = smallCitySerializable.PopulationAge67W;
						smallCity.PopulationAge68M = smallCitySerializable.PopulationAge68M;
						smallCity.PopulationAge68W = smallCitySerializable.PopulationAge68W;
						smallCity.PopulationAge69M = smallCitySerializable.PopulationAge69M;
						smallCity.PopulationAge69W = smallCitySerializable.PopulationAge69W;
						smallCity.PopulationAge70M = smallCitySerializable.PopulationAge70M;
						smallCity.PopulationAge70W = smallCitySerializable.PopulationAge70W;
						smallCity.minDeathRateJung = smallCitySerializable.minDeathRateJung;
						smallCity.maxDeathRateJung = smallCitySerializable.maxDeathRateJung;
						smallCity.minDeathRateOld = smallCitySerializable.minDeathRateOld;
						smallCity.maxDeathRateOld = smallCitySerializable.maxDeathRateOld;
						smallCity.minBirthRateJung = smallCitySerializable.minBirthRateJung;
						smallCity.maxBirthRateJung = smallCitySerializable.maxBirthRateJung;
						
						CityInventory cityInventory = obj.AddComponent<CityInventory>();
						cityInventory.cityID = smallCity.cityID;
						cityInventory.smallCity = smallCity;
						smallCity.cityInventory = cityInventory;
						
						SelectedCityInfo selectedCityInfo = obj.AddComponent<SelectedCityInfo>();
						CityHoverInfo cityHoverInfo = obj.AddComponent<CityHoverInfo>();
						PlayerScript playerScript = obj.AddComponent<PlayerScript>();
						smallCity.playerScript = playerScript;
						playerScript.ownerPlayerID = smallCity.ownerPlayerID;
						smallCity.playerScript.Multiplayer = smallCitySerializable.Multiplayer;
						
						playerScript.Currency = smallCitySerializable.Currency;
						playerScript.CurrentResearch = smallCitySerializable.CurrentResearch;
						playerScript.InfantryLightWeaponResearch1 = smallCitySerializable.InfantryLightWeaponResearch1;
						playerScript.InfantryLightWeaponResearch2 = smallCitySerializable.InfantryLightWeaponResearch2;
						playerScript.InfantryLightWeaponResearch3 = smallCitySerializable.InfantryLightWeaponResearch3;
						playerScript.InfantryLightWeaponResearch4point1 = smallCitySerializable.InfantryLightWeaponResearch4point1;
						playerScript.InfantryLightWeaponResearch4point2 = smallCitySerializable.InfantryLightWeaponResearch4point2;
						playerScript.InfantryLightWeaponResearch11 = smallCitySerializable.InfantryLightWeaponResearch11;
						playerScript.InfantryHeavyWeaponResearch1 = smallCitySerializable.InfantryHeavyWeaponResearch1;
						playerScript.InfantryHeavyWeaponResearch2 = smallCitySerializable.InfantryHeavyWeaponResearch2;
						
						obj.name = smallCity.cityName;
						SpriteRenderer spriteRenderer = obj.AddComponent<SpriteRenderer>();
						Sprite citySprite = Resources.Load<Sprite>(smallCity.spritePath);
						spriteRenderer.sprite = citySprite;
						spriteRenderer.sortingLayerName = "City Layer";
						if(smallCitySerializable.AIControlled)
						{
							AIControlled aIControlled = obj.AddComponent<AIControlled>();
							playerScript.aIControlled = aIControlled;
							aIControlled.playerScript = playerScript;
							aIControlled.ownerPlayerID = playerScript.ownerPlayerID;
						}
					}
					
					CharacterDataSerializable characterDataSerializable = objectData.characterDataSerializable;
					if (characterDataSerializable != null)
					{
						obj.layer = LayerMask.NameToLayer("Units");
						CharacterData characterData = obj.AddComponent<CharacterData>();
						characterData.InCityInventory = characterDataSerializable.InCityInventory;
						CharacterVisibility characterVisibility = obj.AddComponent<CharacterVisibility>();
						characterData.characterName = characterDataSerializable.characterName;
						characterData.ownerPlayerID = characterDataSerializable.ownerPlayerID;
						characterData.health = characterDataSerializable.health;
						characterData.maxhealth = characterDataSerializable.maxhealth;
						characterData.damage = characterDataSerializable.damage;
						characterData.heavyDamage = characterDataSerializable.heavyDamage;
						characterData.armorpierceDamage =characterDataSerializable.armorpierceDamage;
						characterData.softDef = characterDataSerializable.softDef;
						characterData.hardDef = characterDataSerializable.hardDef;
						characterData.characterID = characterDataSerializable.characterID;
						characterData.usableMP = characterDataSerializable.usableMP;
						characterData.maxMP = characterDataSerializable.maxMP;
						characterData.usableAP = characterDataSerializable.usableAP;
						characterData.maxAP = characterDataSerializable.maxAP;
						characterData.attackRange = characterDataSerializable.attackRange;
						characterData.attackChance = characterDataSerializable.attackChance;
						characterData.coverChance = characterDataSerializable.coverChance;
						characterData.AmmoType = characterDataSerializable.AmmoType;
						characterData.ammoUsage = characterDataSerializable.ammoUsage;
						characterData.spritePath = characterDataSerializable.spritePath;
						characterData.GlobalID = characterDataSerializable.GlobalID;
						characterData.transformTo = characterDataSerializable.GlobalID;
						characterData.coverChance = characterDataSerializable.coverChance;
						characterData.thisCharacter = obj;
						characterData.globalIDcurrentCell = characterDataSerializable.globalIDcurrentCell;
						characterData.WeaponSlotChanges = characterDataSerializable.WeaponSlotChanges;
						characterData.AmmoSlotChanges = characterDataSerializable.AmmoSlotChanges;
						characterData.HelmetSlotChanges = characterDataSerializable.HelmetSlotChanges;
						characterData.VestSlotChanges = characterDataSerializable.VestSlotChanges;
						characterData.ShirtSlotChanges = characterDataSerializable.ShirtSlotChanges;
						
						
						CharacterInventory characterInventory = obj.AddComponent<CharacterInventory>();
						characterInventory.characterID = characterDataSerializable.characterID;
						characterInventory.inventorySize = characterDataSerializable.inventorySize;
						characterInventory.characterData = characterData;
						characterData.characterInventory = characterInventory;
						characterInventory.MaintainSlots();
												
						obj.name = characterData.characterName;
						SpriteRenderer spriteRenderer = obj.AddComponent<SpriteRenderer>();
						Sprite unitSprite = Resources.Load<Sprite>(characterData.spritePath);
						spriteRenderer.sprite = unitSprite;
						spriteRenderer.sortingLayerName = "Units Layer";
						BoxCollider2D collider = obj.AddComponent<BoxCollider2D>();
						if(characterData.currentCell != null)
						{
							if(characterData.currentCell.IsOccupiedByCity)
							{
								characterVisibility.SetNotVisibile();
							}
						}
						CharacterHoverInfo characterHoverInfo = obj.AddComponent<CharacterHoverInfo>();
					}
                }
				gridGenerator.cellManager.Question.SetActive(true);
				foreach (GameObject obj in allObjects)
				{
					CellData cellData = obj.GetComponent<CellData>();
					if(cellData != null && cellData.IsOccupiedByCity)
					{
						GameObject[] allObjects2 = GameObject.FindObjectsOfType<GameObject>();
						foreach (GameObject obj2 in allObjects2)
						{
							SmallCity city = obj2.GetComponent<SmallCity>();
							if(city != null)
							{
								if(cellData.smallCityGlobalID == city.GlobalID)
								{
									cellData.smallCity = city;
									cellData.smallCity.currentCell = cellData;
									cellData.smallCity.currentNode = cellData.node;
									cellData.smallCity.cityInventory.currentCell = cellData;
									cellData.smallCity.cityInventory.currentNode = cellData.node;
									BoxCollider2D cellCollider = cellData.smallCity.currentCell.GetComponent<BoxCollider2D>();
									cellCollider.enabled = false;
									cellData.smallCityGlobalID = 0;
								}
							}
						}
					}
				}
			}
            Debug.Log("Game loaded!");
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }
    }
}