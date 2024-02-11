using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CharacterInventory : MonoBehaviour
{
    public int characterID;
    public int inventorySize = 2;
	public int existingInventorySize = 0;
	public bool isCharacterInventoryOpen = false;
	public CharacterInventorySlots characterInventorySlots;
	public ItemsList itemsList;
	public CharacterData characterData;
	
	public static CharacterInventory Instance { get; private set; }
	
	public Image CharacterSprite;
	
	public InventorySlot CommonSlot1;
	public InventorySlot CommonSlot2;
	public InventorySlot CommonSlot3;
	public InventorySlot CommonSlot4;
	public InventorySlot CommonSlot5;
	public InventorySlot CommonSlot6;
	public InventorySlot CommonSlot7;
	public InventorySlot CommonSlot8;
	
	public InventorySlot weaponSlot;
	public InventorySlot helmetSlot;
	public InventorySlot shirtSlot;
	public InventorySlot vestSlot;
	public InventorySlot ammoSlot;
	
	private void Start()
	{
		for (int i = existingInventorySize + 1; i <= inventorySize; i++)
		{
			var commonSlotObject = new GameObject("CommonSlot" + i);
			commonSlotObject.transform.parent = transform; // Установите родительский объект
			var commonSlot = commonSlotObject.AddComponent<InventorySlot>();
			commonSlot.slotType = SlotType.Common;
			commonSlot.characterInventory = this;
			
			if (i == 1 && CommonSlot1 == null)
			{
				CommonSlot1 = commonSlot;
			}
			else if (i == 2 && CommonSlot2 == null)
			{
				CommonSlot2 = commonSlot;
			}
			else if (i == 3 && CommonSlot3 == null)
			{
				CommonSlot3 = commonSlot;
			}
			else if (i == 4 && CommonSlot4 == null)
			{
				CommonSlot4 = commonSlot;
			}
			else if (i == 5 && CommonSlot5 == null)
			{
				CommonSlot5 = commonSlot;
			}
			else if (i == 6 && CommonSlot6 == null)
			{
				CommonSlot6 = commonSlot;
			}
			else if (i == 7 && CommonSlot7 == null)
			{
				CommonSlot7 = commonSlot;
			}
			else if (i == 8 && CommonSlot8 == null)
			{
				CommonSlot8 = commonSlot;
			}
		}
		existingInventorySize = inventorySize;

		// Создайте и настройте специализированные слоты
		var weaponSlotObject = new GameObject("WeaponSlot");
		weaponSlotObject.transform.parent = transform; // Установите родительский объект
		weaponSlot = weaponSlotObject.AddComponent<InventorySlot>();
		weaponSlot.characterInventory = this;
		weaponSlot.slotType = SlotType.Weapon;

		var helmetSlotObject = new GameObject("HelmetSlot");
		helmetSlotObject.transform.parent = transform; // Установите родительский объект
		helmetSlot = helmetSlotObject.AddComponent<InventorySlot>();
		helmetSlot.characterInventory = this;
		helmetSlot.slotType = SlotType.Helmet;

		var shirtSlotObject = new GameObject("ShirtSlot");
		shirtSlotObject.transform.parent = transform; // Установите родительский объект
		shirtSlot = shirtSlotObject.AddComponent<InventorySlot>();
		shirtSlot.characterInventory = this;
		shirtSlot.slotType = SlotType.Shirt;

		var vestSlotObject = new GameObject("VestSlot");
		vestSlotObject.transform.parent = transform; // Установите родительский объект
		vestSlot = vestSlotObject.AddComponent<InventorySlot>();
		vestSlot.characterInventory = this;
		vestSlot.slotType = SlotType.Vest;
		
		var ammoSlotObject = new GameObject("AmmoSlot");
		ammoSlotObject.transform.parent = transform; // Установите родительский объект
		ammoSlot = ammoSlotObject.AddComponent<InventorySlot>();
		ammoSlot.characterInventory = this;
		ammoSlot.slotType = SlotType.Ammo;
		
		characterInventorySlots = FindObjectOfType<CharacterInventorySlots>();
		itemsList = FindObjectOfType<ItemsList>();
		List<Item> itemList = itemsList.GetItemsList();
				
		if (CharacterSprite != null)
		{
			// Получаем компонент Image
			Image imageComponent = CharacterSprite.GetComponent<Image>();

			// Проверка на null, чтобы избежать ошибок, если компонент Image не найден
			if (imageComponent != null)
			{
				// Устанавливаем новый цвет с альфа-каналом 0
				imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, 0);
			}
		}
		weaponSlot = transform.Find("WeaponSlot").GetComponent<InventorySlot>();
		helmetSlot = transform.Find("HelmetSlot").GetComponent<InventorySlot>();
		shirtSlot = transform.Find("ShirtSlot").GetComponent<InventorySlot>();
		vestSlot = transform.Find("VestSlot").GetComponent<InventorySlot>();
		ammoSlot = transform.Find("AmmoSlot").GetComponent<InventorySlot>();
    }
	
	public void MaintainSlots()
	{
		// Создайте и настройте 8 общих слотов
		for (int i = existingInventorySize  + 1; i <= inventorySize; i++)
		{
			var commonSlotObject = new GameObject("CommonSlot" + i);
			commonSlotObject.transform.parent = transform; // Установите родительский объект
			var commonSlot = commonSlotObject.AddComponent<InventorySlot>();
			commonSlot.slotType = SlotType.Common;
			commonSlot.characterInventory = this;
			
			if (i == 1 && CommonSlot1 == null)
			{
				CommonSlot1 = commonSlot;
			}
			else if (i == 2 && CommonSlot2 == null)
			{
				CommonSlot2 = commonSlot;
			}
			else if (i == 3 && CommonSlot3 == null)
			{
				CommonSlot3 = commonSlot;
			}
			else if (i == 4 && CommonSlot4 == null)
			{
				CommonSlot4 = commonSlot;
			}
			else if (i == 5 && CommonSlot5 == null)
			{
				CommonSlot5 = commonSlot;
			}
			else if (i == 6 && CommonSlot6 == null)
			{
				CommonSlot6 = commonSlot;
			}
			else if (i == 7 && CommonSlot7 == null)
			{
				CommonSlot7 = commonSlot;
			}
			else if (i == 8 && CommonSlot8 == null)
			{
				CommonSlot8 = commonSlot;
			}
			existingInventorySize = inventorySize;
		}
    }
	
	public void DeleteSlotsFromEnd(int slotsToDelete)
	{
		int deletedSlotsCount = 0;

		for (int i = 8; i >= 1 && deletedSlotsCount < slotsToDelete; i--)
		{
			switch (i)
			{
				case 8:
					if (CommonSlot8 != null)
					{
						Destroy(CommonSlot8.gameObject);
						CommonSlot8 = null;
						deletedSlotsCount++;
					}
					break;
				case 7:
					if (CommonSlot7 != null)
					{
						Destroy(CommonSlot7.gameObject);
						CommonSlot7 = null;
						deletedSlotsCount++;
					}
					break;
				case 6:
					if (CommonSlot6 != null)
					{
						Destroy(CommonSlot6.gameObject);
						CommonSlot6 = null;
						deletedSlotsCount++;
					}
					break;
				case 5:
					if (CommonSlot5 != null)
					{
						Destroy(CommonSlot5.gameObject);
						CommonSlot5 = null;
						deletedSlotsCount++;
					}
					break;
				case 4:
					if (CommonSlot4 != null)
					{
						Destroy(CommonSlot4.gameObject);
						CommonSlot4 = null;
						deletedSlotsCount++;
					}
					break;
				case 3:
					if (CommonSlot3 != null)
					{
						Destroy(CommonSlot3.gameObject);
						CommonSlot3 = null;
						deletedSlotsCount++;
					}
					break;
				case 2:
					if (CommonSlot2 != null)
					{
						Destroy(CommonSlot2.gameObject);
						CommonSlot2 = null;
						deletedSlotsCount++;
					}
					break;
				case 1:
					if (CommonSlot1 != null)
					{
						Destroy(CommonSlot1.gameObject);
						CommonSlot1 = null;
						deletedSlotsCount++;
					}
					break;

				default:
					break;
			}
		}
	}
	
	public bool HasFreeInventorySlotCharacter(CharacterInventory characterInventory)
	{
		if (CommonSlot1 != null && CommonSlot1.characterInventory == characterInventory && CommonSlot1.itemGameObject == null)
		{
			return true; // Есть свободный слот в данном городе
		}
		else if (CommonSlot2 != null && CommonSlot2.characterInventory == characterInventory && CommonSlot2.itemGameObject == null)
		{
			return true; // Есть свободный слот в данном городе
		}
		else if (CommonSlot3 != null && CommonSlot3.characterInventory == characterInventory && CommonSlot3.itemGameObject == null)
		{
			return true; // Есть свободный слот в данном городе
		}
		else if (CommonSlot4 != null && CommonSlot4.characterInventory == characterInventory && CommonSlot4.itemGameObject == null)
		{
			return true; // Есть свободный слот в данном городе
		}
		else if (CommonSlot5 != null && CommonSlot5.characterInventory == characterInventory && CommonSlot5.itemGameObject == null)
		{
			return true; // Есть свободный слот в данном городе
		}
		else if (CommonSlot6 != null && CommonSlot6.characterInventory == characterInventory && CommonSlot6.itemGameObject == null)
		{
			return true; // Есть свободный слот в данном городе
		}
		else if (CommonSlot7 != null && CommonSlot7.characterInventory == characterInventory && CommonSlot7.itemGameObject == null)
		{
			return true; // Есть свободный слот в данном городе
		}
		else if (CommonSlot8 != null && CommonSlot8.characterInventory == characterInventory && CommonSlot8.itemGameObject == null)
		{
			return true; // Есть свободный слот в данном городе
		}

		return false; // Все слоты в данном городе заняты
	}

	public void AddItemToCharacterInventory(GameObject itemObject, int slotIndex)
	{
		if (slotIndex >= 1 && slotIndex <= inventorySize)
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
				// Поместите персонажа в инвентарь города
				targetSlot.SetItemObject(itemObject);
			}
		}
	}
	
	public void RemoveItemFromCharacterInventory(int slotIndex)
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
	
	public int GetFreeItemObjectIndexCharacter()
	{
		for (int i = 1; i <= inventorySize; i++)
		{
			switch (i)
			{
				case 1:
					if (CommonSlot1 == null || !CommonSlot1.isOccupied)
						return i;
					break;
				case 2:
					if (CommonSlot2 == null || !CommonSlot2.isOccupied)
						return i;
					break;
				case 3:
					if (CommonSlot3 == null || !CommonSlot3.isOccupied)
						return i;
					break;
				case 4:
					if (CommonSlot4 == null || !CommonSlot4.isOccupied)
						return i;
					break;
				case 5:
					if (CommonSlot5 == null || !CommonSlot5.isOccupied)
						return i;
					break;
				case 6:
					if (CommonSlot6 == null || !CommonSlot6.isOccupied)
						return i;
					break;
				case 7:
					if (CommonSlot7 == null || !CommonSlot7.isOccupied)
						return i;
					break;
				case 8:
					if (CommonSlot8 == null || !CommonSlot8.isOccupied)
						return i;
					break;
				default:
					break;
			}
		}
		return -1;
	}
	
	public void UpdateItemSpritesCharacter()
    {
        UpdateItemSpriteCharacter(CommonSlot1);
        UpdateItemSpriteCharacter(CommonSlot2);
        UpdateItemSpriteCharacter(CommonSlot3);
        UpdateItemSpriteCharacter(CommonSlot4);
		UpdateItemSpriteCharacter(CommonSlot5);
        UpdateItemSpriteCharacter(CommonSlot6);
        UpdateItemSpriteCharacter(CommonSlot7);
        UpdateItemSpriteCharacter(CommonSlot8);
		
		UpdateItemSpriteCharacter(weaponSlot);
        UpdateItemSpriteCharacter(helmetSlot);
        UpdateItemSpriteCharacter(shirtSlot);
        UpdateItemSpriteCharacter(vestSlot);
		UpdateItemSpriteCharacter(ammoSlot);
    }
	
	public void UpdateItemSpriteCharacter(InventorySlot inventorySlot)
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
						// Ваш код для обновления отображения спрайта персонажа
						// Например, вы можете использовать этот спрайт внутри вашего кода для отображения персонажа
						Sprite itemSprite = itemObject.itemSprite;
						// Далее вы можете использовать characterSprite в вашем коде для отображения персонажа
					}
				}
            }
        }
    }
	
	public InventorySlot GetInventorySlotCharacter(int index)
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
	
	public void RemoveItemWithIDFromInventoryCharacter(int itemID)
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
	
	public bool CheckItemWithIDInInventoryCharacter(int itemID)
	{
		if (CommonSlot1 != null && CommonSlot1.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot1.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}

		if (CommonSlot2 != null && CommonSlot2.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot2.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}
		
		if (CommonSlot3 != null && CommonSlot3.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot3.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}

		if (CommonSlot4 != null && CommonSlot4.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot4.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}
		
		if (CommonSlot5 != null && CommonSlot5.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot5.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}

		if (CommonSlot6 != null && CommonSlot6.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot6.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}
		
		if (CommonSlot7 != null && CommonSlot7.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot7.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}

		if (CommonSlot8 != null && CommonSlot8.itemGameObject != null)
		{
			ItemObject itemObject = CommonSlot8.itemGameObject.GetComponent<ItemObject>();
			if (itemObject != null && itemObject.itemID == itemID)
			{
				return true;
			}
		}
		return false;
	}
	
	public GameObject FindItemWithIDInInventoryCharacter(int itemID)
	{
		if (CommonSlot1 != null && CommonSlot1.itemGameObject != null)
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

		if (CommonSlot2 != null && CommonSlot2.itemGameObject != null)
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
		
		if (CommonSlot3 != null && CommonSlot3.itemGameObject != null)
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

		if (CommonSlot4 != null && CommonSlot4.itemGameObject != null)
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
		
		if (CommonSlot5 != null && CommonSlot5.itemGameObject != null)
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

		if (CommonSlot6 != null && CommonSlot6.itemGameObject != null)
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
		
		if (CommonSlot7 != null && CommonSlot7.itemGameObject != null)
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

		if (CommonSlot8 != null && CommonSlot8.itemGameObject != null)
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
}