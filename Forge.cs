using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forge : MonoBehaviour
{
	public List<InventorySlot> commonSlots;

	public ItemsList itemsList;
	public CellData cellData;
	public GameObject forgeObject;
	public int ownerPlayerID;
	public int Population;
	public int PopulationAP;
	public int PopulationMaxAP;
	public bool isSelected = false;
	public int GlobalID;
	public int currentCellGlobalID;
	
	public InventorySlot CommonSlot1 { get; private set; }
	public InventorySlot CommonSlot2 { get; private set; }
	public InventorySlot CommonSlot3 { get; private set; }
	public InventorySlot CommonSlot4 { get; private set; }
	public InventorySlot CommonSlot5 { get; private set; }
	public InventorySlot CommonSlot6 { get; private set; }
	public InventorySlot CommonSlot7 { get; private set; }
	public InventorySlot CommonSlot8 { get; private set; }
	
	public bool isForgeInventoryOpen;
	public CharacterSelectedData characterSelectedData;
	
	private void Start()
    {
		if(characterSelectedData == null)
		{
			characterSelectedData = FindObjectOfType<CharacterSelectedData>();
		}
		itemsList = FindObjectOfType<ItemsList>();
		
		commonSlots = new List<InventorySlot>();

		for (int i = 1; i <= 8; i++)
		{
			var commonSlotObject = new GameObject("CommonSlot" + i);
			commonSlotObject.transform.parent = transform;
			var commonSlot = commonSlotObject.AddComponent<InventorySlot>();
			commonSlot.slotType = SlotType.Common;
			commonSlot.forge = this;
			commonSlots.Add(commonSlot);
			
			if (i == 1)
			{
				CommonSlot1 = commonSlot;
			}
			else if (i == 2)
			{
				CommonSlot2 = commonSlot;
			}
			else if (i == 3)
			{
				CommonSlot3 = commonSlot;
			}
			else if (i == 4)
			{
				CommonSlot4 = commonSlot;
			}
			else if (i == 5)
			{
				CommonSlot5 = commonSlot;
			}
			else if (i == 6)
			{
				CommonSlot6 = commonSlot;
			}
			else if (i == 7)
			{
				CommonSlot7 = commonSlot;
			}
			else if (i == 8)
			{
				CommonSlot8 = commonSlot;
			}
		}
	}
	
	public bool HasFreeInventorySlotForge(Forge forge)
	{
		foreach (InventorySlot inventorySlot in commonSlots)
		{
			if (inventorySlot.forge == forge && inventorySlot.itemGameObject == null)
			{
				return true; // Есть свободный слот в данном городе
			}
		}

		return false; // Все слоты в данном городе заняты
	}
	
	public void AddItemToForgeInventory(GameObject itemObject, int slotIndex)
	{
		if (slotIndex >= 1 && slotIndex <= 8)
		{
			InventorySlot targetSlot = null;
			
			switch (slotIndex)
			{
				case 1:
					targetSlot = CommonSlot1;
					break;
				case 2:
					targetSlot = CommonSlot2;
					break;
				case 3:
					targetSlot = CommonSlot3;
					break;
				case 4:
					targetSlot = CommonSlot4;
					break;
				case 5:
					targetSlot = CommonSlot5;
					break;
				case 6:
					targetSlot = CommonSlot6;
					break;
				case 7:
					targetSlot = CommonSlot7;
					break;
				case 8:
					targetSlot = CommonSlot8;
					break;
			}

			if (targetSlot != null)
			{
				targetSlot.SetItemObject(itemObject);
			}
		}
	}
	
	public void RemoveItemFromForgeInventory(int slotIndex)
	{
		InventorySlot commonSlot = null;

		if (slotIndex == 1)
		{
			commonSlot = CommonSlot1;
			CommonSlot1 = null;
		}
		else if (slotIndex == 2)
		{
			commonSlot = CommonSlot2;
			CommonSlot2 = null;
		}
		else if (slotIndex == 3)
		{
			commonSlot = CommonSlot3;
			CommonSlot3 = null;
		}
		else if (slotIndex == 4)
		{
			commonSlot = CommonSlot4;
			CommonSlot4 = null;
		}
		else if (slotIndex == 5)
		{
			commonSlot = CommonSlot5;
			CommonSlot5 = null;
		}
		else if (slotIndex == 6)
		{
			commonSlot = CommonSlot6;
			CommonSlot6 = null;
		}
		else if (slotIndex == 7)
		{
			commonSlot = CommonSlot7;
			CommonSlot7 = null;
		}
		else if (slotIndex == 8)
		{
			commonSlot = CommonSlot8;
			CommonSlot8 = null;
		}

		if (commonSlot != null)
		{
			commonSlot.ClearSlot();
		}
	}
	
	public int GetFreeItemObjectIndexForge()
	{
		if (CommonSlot1 == null || !CommonSlot1.isOccupied) return 1;
		if (CommonSlot2 == null || !CommonSlot2.isOccupied) return 2;
		if (CommonSlot3 == null || !CommonSlot3.isOccupied) return 3;
		if (CommonSlot4 == null || !CommonSlot4.isOccupied) return 4;
		if (CommonSlot5 == null || !CommonSlot5.isOccupied) return 5;
		if (CommonSlot6 == null || !CommonSlot6.isOccupied) return 6;
		if (CommonSlot7 == null || !CommonSlot7.isOccupied) return 7;
		if (CommonSlot8 == null || !CommonSlot8.isOccupied) return 8;

		return -1; // Возвращаем -1, если не найден свободный слот
	}
	
	public void UpdateItemSpritesForge()
    {
        UpdateItemSpriteForge(CommonSlot1);
        UpdateItemSpriteForge(CommonSlot2);
        UpdateItemSpriteForge(CommonSlot3);
        UpdateItemSpriteForge(CommonSlot4);
		UpdateItemSpriteForge(CommonSlot5);
        UpdateItemSpriteForge(CommonSlot6);
        UpdateItemSpriteForge(CommonSlot7);
        UpdateItemSpriteForge(CommonSlot8);
    }
	
	public void UpdateItemSpriteForge(InventorySlot inventorySlot)
    {
        if (inventorySlot != null)
        {
            if (inventorySlot.itemGameObject != null)
            {
				if (inventorySlot.itemGameObject != null)
				{
					ItemObject itemObject = inventorySlot.itemGameObject.GetComponent<ItemObject>();

					if (itemObject != null && itemObject.itemSprite != null)
					{
						Sprite itemSprite = itemObject.itemSprite;
					}
				}
            }
        }
    }
	
	public InventorySlot GetInventorySlotForge(int index)
	{
		InventorySlot targetSlot = null;

		switch (index)
		{
			case 1:
				targetSlot = CommonSlot1;
				break;
			case 2:
				targetSlot = CommonSlot2;
				break;
			case 3:
				targetSlot = CommonSlot3;
				break;
			case 4:
				targetSlot = CommonSlot4;
				break;
			case 5:
				targetSlot = CommonSlot5;
				break;
			case 6:
				targetSlot = CommonSlot6;
				break;
			case 7:
				targetSlot = CommonSlot7;
				break;
			case 8:
				targetSlot = CommonSlot8;
				break;
		}
		return targetSlot;
	}
	

	public void RemoveItemWithIDFromInventoryForge(int itemID)
	{
		if (CommonSlot1 != null && CommonSlot1.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot1.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity > 1)
				{
					itemObject.quantity--;
				}
				else
				{
					GameObject itemToDestroy = CommonSlot1.itemGameObject;
					CommonSlot1.itemGameObject = null;
					CommonSlot1.isOccupied = false;
					Destroy(itemToDestroy);
				}
				return;
			}
		}

		if (CommonSlot2 != null && CommonSlot2.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot2.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity > 1)
				{
					itemObject.quantity--;
				}
				else
				{
					GameObject itemToDestroy = CommonSlot2.itemGameObject;
					CommonSlot2.itemGameObject = null;
					CommonSlot2.isOccupied = false;
					Destroy(itemToDestroy);
				}
				return;
			}
		}
		
		if (CommonSlot3 != null && CommonSlot3.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot3.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity > 1)
				{
					itemObject.quantity--;
				}
				else
				{
					GameObject itemToDestroy = CommonSlot3.itemGameObject;
					CommonSlot3.itemGameObject = null;
					CommonSlot3.isOccupied = false;
					Destroy(itemToDestroy);
				}
				return;
			}
		}

		if (CommonSlot4 != null && CommonSlot4.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot4.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity > 1)
				{
					itemObject.quantity--;
				}
				else
				{
					GameObject itemToDestroy = CommonSlot4.itemGameObject;
					CommonSlot4.itemGameObject = null;
					CommonSlot4.isOccupied = false;
					Destroy(itemToDestroy);
				}
				return;
			}
		}
		
		if (CommonSlot5 != null && CommonSlot5.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot5.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity > 1)
				{
					itemObject.quantity--;
				}
				else
				{
					GameObject itemToDestroy = CommonSlot5.itemGameObject;
					CommonSlot5.itemGameObject = null;
					CommonSlot5.isOccupied = false;
					Destroy(itemToDestroy);
				}
				return;
			}
		}

		if (CommonSlot6 != null && CommonSlot6.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot6.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity > 1)
				{
					itemObject.quantity--;
				}
				else
				{
					GameObject itemToDestroy = CommonSlot6.itemGameObject;
					CommonSlot6.itemGameObject = null;
					CommonSlot6.isOccupied = false;
					Destroy(itemToDestroy);
				}
				return;
			}
		}
		
		if (CommonSlot7 != null && CommonSlot7.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot7.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity > 1)
				{
					itemObject.quantity--;
				}
				else
				{
					GameObject itemToDestroy = CommonSlot7.itemGameObject;
					CommonSlot7.itemGameObject = null;
					CommonSlot7.isOccupied = false;
					Destroy(itemToDestroy);
				}
				return;
			}
		}

		if (CommonSlot8 != null && CommonSlot8.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot8.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity > 1)
				{
					itemObject.quantity--;
				}
				else
				{
					GameObject itemToDestroy = CommonSlot8.itemGameObject;
					CommonSlot8.itemGameObject = null;
					CommonSlot8.isOccupied = false;
					Destroy(itemToDestroy);
				}
				return;
			}
		}
	}

	public bool HasItemWithIDForge(int itemID)
	{
		for (int i = 1; i <= 8; i++)
		{
			InventorySlot inventorySlot = null;

			switch (i)
			{
				case 1:
					inventorySlot = CommonSlot1;
					break;
				case 2:
					inventorySlot = CommonSlot2;
					break;
				case 3:
					inventorySlot = CommonSlot3;
					break;
				case 4:
					inventorySlot = CommonSlot4;
					break;
				case 5:
					inventorySlot = CommonSlot5;
					break;
				case 6:
					inventorySlot = CommonSlot6;
					break;
				case 7:
					inventorySlot = CommonSlot7;
					break;
				case 8:
					inventorySlot = CommonSlot8;
					break;
			}
			if (inventorySlot != null && inventorySlot.itemGameObject != null)
			{
				ItemObject itemObject = inventorySlot.itemGameObject.GetComponent<ItemObject>();
				if (itemObject != null && itemObject.itemID == itemID)
				{
					return true;
				}
			}
		}
		return false;
	}
	
	public bool CheckItemWithIDInInventoryForge(int itemID)
	{
		if (CommonSlot1.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot1.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}

		if (CommonSlot2.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot2.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}
		
		if (CommonSlot3.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot3.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}

		if (CommonSlot4.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot4.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}
		
		if (CommonSlot5.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot5.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}

		if (CommonSlot6.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot6.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}
		
		if (CommonSlot7.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot7.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}

		if (CommonSlot8.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot8.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}
		return false;
	}
	
	public GameObject FindItemWithIDInInventoryForge(int itemID)
	{
		if (CommonSlot1.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot1.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity < itemObject.maxquantity)
				{
					return CommonSlot1.itemGameObject;
				}
			}
		}

		if (CommonSlot2.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot2.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity < itemObject.maxquantity)
				{
					return CommonSlot2.itemGameObject;
				}
			}
		}
		
		if (CommonSlot3.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot3.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity < itemObject.maxquantity)
				{
					return CommonSlot3.itemGameObject;
				}
			}
		}

		if (CommonSlot4.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot4.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity < itemObject.maxquantity)
				{
					return CommonSlot4.itemGameObject;
				}
			}
		}
		
		if (CommonSlot5.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot5.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity < itemObject.maxquantity)
				{
					return CommonSlot5.itemGameObject;
				}
			}
		}

		if (CommonSlot6.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot6.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity < itemObject.maxquantity)
				{
					return CommonSlot6.itemGameObject;
				}
			}
		}
		
		if ( CommonSlot7.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot7.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity < itemObject.maxquantity)
				{
					return CommonSlot7.itemGameObject;
				}
			}
		}

		if (CommonSlot8.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot8.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				if (itemObject.quantity < itemObject.maxquantity)
				{
					return CommonSlot8.itemGameObject;
				}
			}
		}
		return null;
	}
	
	public bool CheckNumberOfItemsWithIDInInventoryForge(int itemID, int itemQuantity)
	{
		if (CommonSlot1.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot1.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID && itemObject.quantity >= itemQuantity)
			{
				return true;
			}
		}

		if (CommonSlot2.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot2.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID && itemObject.quantity >= itemQuantity)
			{
				return true;
			}
		}
		
		if (CommonSlot3.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot3.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID && itemObject.quantity >= itemQuantity)
			{
				return true;
			}
		}

		if (CommonSlot4.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot4.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID && itemObject.quantity >= itemQuantity)
			{
				return true;
			}
		}
		
		if (CommonSlot5.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot5.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID && itemObject.quantity >= itemQuantity)
			{
				return true;
			}
		}

		if (CommonSlot6.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot6.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID && itemObject.quantity >= itemQuantity)
			{
				return true;
			}
		}
		
		if (CommonSlot7.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot7.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID && itemObject.quantity >= itemQuantity)
			{
				return true;
			}
		}

		if (CommonSlot8.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot8.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID && itemObject.quantity >= itemQuantity)
			{
				return true;
			}
		}
		return false;
	}
}
