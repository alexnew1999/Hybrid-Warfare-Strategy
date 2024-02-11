using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WearAI : MonoBehaviour
{
	public CharacterData characterData;
	public GameObject itemGameObject;
	
	public void WearSmth(CharacterData characterData, GameObject itemGameObject)
	{
		ItemObject itemObject = itemGameObject.GetComponent<ItemObject>();
		if (itemObject != null)
		{
			switch (itemObject.itemType)
			{
				case ItemType.weapon:
				if (!characterData.characterInventory.weaponSlot.isOccupied)
				{
					characterData.characterInventory.weaponSlot.itemGameObject = itemGameObject;
					characterData.characterInventory.weaponSlot.isOccupied = true;
					itemObject.inventorySlot = characterData.characterInventory.weaponSlot;
					characterData.attackChance = itemObject.attackChance;
					characterData.damage = itemObject.damage;
					characterData.heavyDamage = itemObject.heavyDamage;
					characterData.armorpierceDamage = itemObject.armorpierceDamage;
					characterData.attackRange = itemObject.attackRange;
					characterData.AmmoType = itemObject.AmmoType;
					characterData.ammoUsage = itemObject.ammoUsage;
					characterData.maxMP -= itemObject.maximalMP;
					itemObject.IsWeared = true;
				}
				else
				{
					Debug.Log("Slot is occupied");
				}
				break;
				case ItemType.helmet:
				if (!characterData.characterInventory.helmetSlot.isOccupied)
				{
					characterData.characterInventory.helmetSlot.itemGameObject = itemGameObject;
					characterData.characterInventory.helmetSlot.isOccupied = true;
					itemObject.inventorySlot = characterData.characterInventory.helmetSlot;
					characterData.maxhealth = Mathf.FloorToInt(Mathf.Min(characterData.maxhealth + itemObject.health, Mathf.Infinity));
					characterData.softDef = Mathf.FloorToInt(Mathf.Min(characterData.softDef + itemObject.softDef, Mathf.Infinity));
					characterData.hardDef = Mathf.FloorToInt(Mathf.Min(characterData.hardDef + itemObject.hardDef, Mathf.Infinity));
					characterData.health += itemObject.health;
					itemObject.IsWeared = true;
				}
				else
				{
					Debug.Log("Slot is occupied");
				}
				break;
				case ItemType.shirt:
				if (!characterData.characterInventory.shirtSlot.isOccupied)
				{
					characterData.characterInventory.shirtSlot.itemGameObject = itemGameObject;
					characterData.characterInventory.shirtSlot.isOccupied = true;
					itemObject.inventorySlot = characterData.characterInventory.shirtSlot;
					characterData.maxhealth = Mathf.FloorToInt(Mathf.Min(characterData.maxhealth + itemObject.health, Mathf.Infinity));
					characterData.softDef = Mathf.FloorToInt(Mathf.Min(characterData.softDef + itemObject.softDef, Mathf.Infinity));
					characterData.hardDef = Mathf.FloorToInt(Mathf.Min(characterData.hardDef + itemObject.hardDef, Mathf.Infinity));
					characterData.health += itemObject.health;
					characterData.characterInventory.inventorySize += itemObject.slots;
					characterData.characterInventory.MaintainSlots();
					itemObject.IsWeared = true;
				}
				else
				{
					Debug.Log("Slot is occupied");
				}
				break;
				case ItemType.vest:
				if (!characterData.characterInventory.vestSlot.isOccupied)
				{
					characterData.characterInventory.vestSlot.itemGameObject = itemGameObject;
					characterData.characterInventory.vestSlot.isOccupied = true;
					itemObject.inventorySlot = characterData.characterInventory.vestSlot;
					characterData.maxhealth = Mathf.FloorToInt(Mathf.Min(characterData.maxhealth + itemObject.health, Mathf.Infinity));
					characterData.softDef = Mathf.FloorToInt(Mathf.Min(characterData.softDef + itemObject.softDef, Mathf.Infinity));
					characterData.hardDef = Mathf.FloorToInt(Mathf.Min(characterData.hardDef + itemObject.hardDef, Mathf.Infinity));
					characterData.health += itemObject.health;
					characterData.maxMP -= itemObject.maximalMP;
					characterData.characterInventory.inventorySize += itemObject.slots;
					characterData.characterInventory.MaintainSlots();
					itemObject.IsWeared = true;
				}
				else
				{
					Debug.Log("Slot is occupied");
				}
				break;
				case ItemType.ammo:
				if (!characterData.characterInventory.ammoSlot.isOccupied)
				{
					characterData.characterInventory.ammoSlot.itemGameObject = itemGameObject;
					characterData.characterInventory.ammoSlot.isOccupied = true;
					itemObject.inventorySlot = characterData.characterInventory.ammoSlot;
					itemObject.IsWeared = true;
				}
				else
				{
					Debug.Log("Slot is occupied");
				}
				break;
			}
		}
	}
	
	public void WearSmthAfterLoad(CharacterData characterData, GameObject itemGameObject)
	{
		ItemObject itemObject = itemGameObject.GetComponent<ItemObject>();
		if (itemObject != null)
		{
			switch (itemObject.itemType)
			{
				case ItemType.weapon:
				characterData.characterInventory.weaponSlot.itemGameObject = itemGameObject;
				itemObject.inventorySlot = characterData.characterInventory.weaponSlot;
				characterData.characterInventory.weaponSlot.isOccupied = true;
				break;
				case ItemType.helmet:
				characterData.characterInventory.helmetSlot.itemGameObject = itemGameObject;
				itemObject.inventorySlot = characterData.characterInventory.helmetSlot;
				characterData.characterInventory.helmetSlot.isOccupied = true;
				break;
				case ItemType.shirt:
				characterData.characterInventory.shirtSlot.itemGameObject = itemGameObject;
				itemObject.inventorySlot = characterData.characterInventory.shirtSlot;
				characterData.characterInventory.shirtSlot.isOccupied = true;
				break;
				case ItemType.vest:
				characterData.characterInventory.vestSlot.itemGameObject = itemGameObject;
				itemObject.inventorySlot = characterData.characterInventory.vestSlot;
				characterData.characterInventory.vestSlot.isOccupied = true;
				break;
				case ItemType.ammo:
				characterData.characterInventory.ammoSlot.itemGameObject = itemGameObject;
				itemObject.inventorySlot = characterData.characterInventory.ammoSlot;
				characterData.characterInventory.ammoSlot.isOccupied = true;
				break;
			}
		}
	}
}
