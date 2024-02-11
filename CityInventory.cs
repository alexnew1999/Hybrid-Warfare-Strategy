using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CityInventory : MonoBehaviour
{
	public List<InventorySlot> commonSlots;
	public List<CharacterSlot> characterSlots;
	public IDCounter iDCounter;
	
	public Image cityImageRenderer;

    public int cityID;

    public CityInventorySlots cityInventorySlots;
	public SmallCity smallCity;
	public CellData currentCell;
	public Node currentNode;
	public CityManager cityManager;
	public CharacterManager characterManager;
	
	public CharacterSlot CharacterCommonSlot1 { get; private set; }
	public CharacterSlot CharacterCommonSlot2 { get; private set; }
	public CharacterSlot CharacterCommonSlot3 { get; private set; }
	public CharacterSlot CharacterCommonSlot4 { get; private set; }
	
	public InventorySlot CommonSlot1 { get; private set; }
	public InventorySlot CommonSlot2 { get; private set; }
	public InventorySlot CommonSlot3 { get; private set; }
	public InventorySlot CommonSlot4 { get; private set; }
	public InventorySlot CommonSlot5 { get; private set; }
	public InventorySlot CommonSlot6 { get; private set; }
	public InventorySlot CommonSlot7 { get; private set; }
	public InventorySlot CommonSlot8 { get; private set; }
	
	public ItemsList itemsList;
	public CharacterNameList nameList;
	
	public bool isCityInventoryOpen = false;
    
    private void Start()
    {
		nameList = FindObjectOfType<CharacterNameList>();
		itemsList = FindObjectOfType<ItemsList>();
		iDCounter = FindObjectOfType<IDCounter>();
			
		commonSlots = new List<InventorySlot>();

		// Создайте и настройте 8 общих слотов инвентаря
		for (int i = 1; i <= 8; i++)
		{
			var commonSlotObject = new GameObject("CommonSlot" + i);
			commonSlotObject.transform.parent = transform; // Установите родительский объект
			var commonSlot = commonSlotObject.AddComponent<InventorySlot>();
			commonSlot.slotType = SlotType.Common;
			commonSlot.cityInventory = this; // Устанавливаем ссылку на CityInventory
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

		characterSlots = new List<CharacterSlot>();

		// Создайте и настройте 4 общих слота персонажей
		for (int i = 1; i <= 4; i++)
		{
			var characterSlotObject = new GameObject("CharacterCommonSlot" + i);
			characterSlotObject.transform.parent = transform; // Установите родительский объект
			var characterCommonSlot = characterSlotObject.AddComponent<CharacterSlot>();
			characterCommonSlot.slotType = SlotType.Character;
			characterCommonSlot.cityInventory = this; // Устанавливаем ссылку на CityInventory
			characterSlots.Add(characterCommonSlot);

			// Инициализируйте слоты персонажей, если это необходимо
			if (i == 1)
			{
				CharacterCommonSlot1 = characterCommonSlot;
			}
			else if (i == 2)
			{
				CharacterCommonSlot2 = characterCommonSlot;
			}
			else if (i == 3)
			{
				CharacterCommonSlot3 = characterCommonSlot;
			}
			else if (i == 4)
			{
				CharacterCommonSlot4 = characterCommonSlot;
			}
		}
		
		cityInventorySlots = FindObjectOfType<CityInventorySlots>();
		cityImageRenderer = cityInventorySlots.CityImageRenderer;
				
		cityManager = FindObjectOfType<CityManager>();
		characterManager = FindObjectOfType<CharacterManager>();
		if(smallCity == null)
		{
			smallCity = cityManager.GetCityByID(cityID);
		}
		if(currentCell == null)
		{
			currentCell = smallCity.currentCell;
		}
		if(currentNode == null && smallCity.currentCell != null)
		{
			currentNode = currentCell.node;
		}
    }

	public bool HasFreeInventorySlot(CityInventory cityInventory)
	{
		foreach (InventorySlot inventorySlot in commonSlots)
		{
			if (inventorySlot.cityInventory == cityInventory && inventorySlot.itemGameObject == null)
			{
				return true; // Есть свободный слот в данном городе
			}
		}

		return false; // Все слоты в данном городе заняты
	}
	
	public bool HasFreeCharacterSlot(CityInventory cityInventory)
	{
		foreach (CharacterSlot characterSlot in characterSlots)
		{
			if (characterSlot.cityInventory == cityInventory && characterSlot.characterObject == null)
			{
				return true; // Есть свободный слот в данном городе
			}
		}

		return false; // Все слоты в данном городе заняты
	}

	public void AddCharacterToCityInventory(GameObject characterObject, int slotIndex)
	{
		if (slotIndex >= 1 && slotIndex <= 4)
		{
			CharacterSlot targetSlot = null;

			switch (slotIndex)
			{
				case 1:
					targetSlot = CharacterCommonSlot1;
					break;
				case 2:
					targetSlot = CharacterCommonSlot2;
					break;
				case 3:
					targetSlot = CharacterCommonSlot3;
					break;
				case 4:
					targetSlot = CharacterCommonSlot4;
					break;
			}

			if (targetSlot != null)
			{
				// Поместите персонажа в инвентарь города
				targetSlot.SetCharacterObject(characterObject);
			}
		}
	}
	
	public void AddItemToCityInventory(GameObject itemObject, int slotIndex)
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
				// Поместите персонажа в инвентарь города
				targetSlot.SetItemObject(itemObject);
			}
		}
	}
	
	public void RemoveCharacterFromCityInventory(int slotIndex)
	{
		CharacterSlot characterSlot = null;

		if (slotIndex == 1)
		{
			characterSlot = CharacterCommonSlot1;
			CharacterCommonSlot1 = null;
		}
		else if (slotIndex == 2)
		{
			characterSlot = CharacterCommonSlot2;
			CharacterCommonSlot2 = null;
		}
		else if (slotIndex == 3)
		{
			characterSlot = CharacterCommonSlot3;
			CharacterCommonSlot3 = null;
		}
		else if (slotIndex == 4)
		{
			characterSlot = CharacterCommonSlot4;
			CharacterCommonSlot4 = null;
		}

		if (characterSlot != null)
		{
			characterSlot.ClearSlot();
		}
	}
	
	public void RemoveItemFromCityInventory(int slotIndex)
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

	public int GetFreeCharacterObjectIndex()
	{
		if (CharacterCommonSlot1 == null || !CharacterCommonSlot1.isOccupied) return 1;
		if (CharacterCommonSlot2 == null || !CharacterCommonSlot2.isOccupied) return 2;
		if (CharacterCommonSlot3 == null || !CharacterCommonSlot3.isOccupied) return 3;
		if (CharacterCommonSlot4 == null || !CharacterCommonSlot4.isOccupied) return 4;

		return -1; // Возвращаем -1, если не найден свободный слот
	}
	
	public int GetFreeItemObjectIndex()
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

    public void UpdateCharacterSprites()
    {
        UpdateCharacterSprite(CharacterCommonSlot1);
        UpdateCharacterSprite(CharacterCommonSlot2);
        UpdateCharacterSprite(CharacterCommonSlot3);
        UpdateCharacterSprite(CharacterCommonSlot4);
    }
	
	public void UpdateItemSprites()
    {
        UpdateItemSprite(CommonSlot1);
        UpdateItemSprite(CommonSlot2);
        UpdateItemSprite(CommonSlot3);
        UpdateItemSprite(CommonSlot4);
		UpdateItemSprite(CommonSlot5);
        UpdateItemSprite(CommonSlot6);
        UpdateItemSprite(CommonSlot7);
        UpdateItemSprite(CommonSlot8);
    }

    private void UpdateCharacterSprite(CharacterSlot characterSlot)
    {
        if (characterSlot != null)
        {
            if (characterSlot.characterObject != null)
            {
				if (characterSlot.characterObject != null)
				{
					CharacterData characterData = characterSlot.characterObject.GetComponent<CharacterData>();

					if (characterData != null && characterData.characterImage != null)
					{
						// Ваш код для обновления отображения спрайта персонажа
						// Например, вы можете использовать этот спрайт внутри вашего кода для отображения персонажа
						Sprite characterSprite = characterData.characterImage;
						// Далее вы можете использовать characterSprite в вашем коде для отображения персонажа
					}
				}
            }
        }
    }
	
	public void UpdateItemSprite(InventorySlot inventorySlot)
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
	
	public void GenerateNewCharacterData()
	{
		int freeSlotIndex = GetFreeCharacterObjectIndex();

		if (freeSlotIndex != -1)
		{
			GameObject newCharacterObject = new GameObject("Character");
			
			newCharacterObject.layer = LayerMask.NameToLayer("Units");

			CharacterData newCharacter = newCharacterObject.AddComponent<CharacterData>();
			newCharacter.thisCharacter = newCharacterObject;
			newCharacter.playerScript = smallCity.playerScript;
			newCharacter.ownerPlayerID = smallCity.ownerPlayerID;
			if(smallCity.playerScript.aIControlled != null)
			{
				if(smallCity.playerScript.aIControlled.AIDefendDrone1 == null)
				{
					AIDefendDrone aIDefendDrone = newCharacterObject.AddComponent<AIDefendDrone>();
					newCharacter.aIDefendDrone = aIDefendDrone;
					aIDefendDrone.characterData = newCharacter;
					aIDefendDrone.cityCell = smallCity.currentCell;
					smallCity.playerScript.aIControlled.AIDefendDrone1 = newCharacterObject;
				}
				else if(smallCity.playerScript.aIControlled.AIDefendDrone2 == null)
				{
					AIDefendDrone aIDefendDrone = newCharacterObject.AddComponent<AIDefendDrone>();
					newCharacter.aIDefendDrone = aIDefendDrone;
					aIDefendDrone.characterData = newCharacter;
					aIDefendDrone.cityCell = smallCity.currentCell;
					smallCity.playerScript.aIControlled.AIDefendDrone2 = newCharacterObject;
				}
				else if(smallCity.playerScript.aIControlled.AIAttackDrone1 == null)
				{
					AIDefendDrone aIDefendDrone = newCharacterObject.AddComponent<AIDefendDrone>();
					newCharacter.aIDefendDrone = aIDefendDrone;
					aIDefendDrone.characterData = newCharacter;
					aIDefendDrone.cityCell = smallCity.currentCell;
					smallCity.playerScript.aIControlled.AIAttackDrone1 = newCharacterObject;
				}
			}

			string[] characterNames = nameList.characterNames;
			string randomName = GetRandomName(characterNames);
			int randomNumber = Random.Range(1, 100);

			newCharacter.characterName = randomName + " " + randomNumber.ToString();
			newCharacterObject.name = newCharacter.characterName;
			newCharacter.GenerateNewCharacterID();
			newCharacter.currentCell = currentCell;
			newCharacter.currentNode = currentNode;
			newCharacter.coverChance = 30f;
			newCharacter.InCityInventory = true;
			newCharacter.GlobalID = iDCounter.globalID;
			iDCounter.globalID++;
			Vector2 cellPosition = currentCell.transform.position;
			newCharacterObject.transform.position = cellPosition;
			
			BoxCollider2D boxCollider = newCharacterObject.AddComponent<BoxCollider2D>();
			boxCollider.size = new Vector2(0.96f, 0.96f);
			
			CharacterInventory characterInventory = newCharacterObject.AddComponent<CharacterInventory>();
			
			characterInventory.characterID = newCharacter.characterID;
			newCharacter.characterInventory = characterInventory;
			characterInventory.characterData = newCharacter;

			SpriteRenderer spriteRenderer = newCharacterObject.AddComponent<SpriteRenderer>();
			Sprite characterSprite = Resources.Load<Sprite>(newCharacter.spritePath);
			spriteRenderer.sprite = characterSprite;
			spriteRenderer.sortingLayerName = "In City Units Layer";
			spriteRenderer.sortingOrder = 0;
			
			CharacterVisibility characterVisibility = newCharacterObject.AddComponent<CharacterVisibility>();
			
			CharacterHoverInfo characterHoverInfo = newCharacterObject.AddComponent<CharacterHoverInfo>();

			CharacterSlot targetSlot = GetCharacterSlot(freeSlotIndex);

			if (targetSlot != null)
			{
				targetSlot.SetCharacterObject(newCharacterObject);

				// Добавляем ссылку на нового персонажа в CharacterCommonSlot1, CharacterCommonSlot2 и т.д.
				AddCharacterToCityInventory(newCharacterObject, freeSlotIndex);
			}

			// Поиск MobilizedSpriteFixer в сцене и обновление спрайта CharacterData
			MobilizedSpriteFixer spriteFixer = FindObjectOfType<MobilizedSpriteFixer>();
			if (spriteFixer != null)
			{
				spriteFixer.UpdateCharacterSprite(newCharacter);
			}
			UpdateCharacterSprites();
		}
	}

	public CharacterSlot GetCharacterSlot(int index)
	{
		CharacterSlot targetSlot = null;

		switch (index)
		{
			case 1:
				targetSlot = CharacterCommonSlot1;
				break;
			case 2:
				targetSlot = CharacterCommonSlot2;
				break;
			case 3:
				targetSlot = CharacterCommonSlot3;
				break;
			case 4:
				targetSlot = CharacterCommonSlot4;
				break;
		}
		return targetSlot;
	}
	
	public InventorySlot GetInventorySlot(int index)
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
	
	string GetRandomName(string[] names)
	{
		if (names == null || names.Length == 0)
		{
			return "";
		}

		int randomIndex = Random.Range(0, names.Length);
		return names[randomIndex];
	}
	
	public bool HasEnemyCharacters(int playerID, out CharacterData enemyCharacterData)
	{
		enemyCharacterData = null;

		if (CharacterCommonSlot1 != null && CharacterCommonSlot1.isOccupied && GetCharacterOwnerID(CharacterCommonSlot1) != playerID)
		{
			enemyCharacterData = GetCharacterData(CharacterCommonSlot1);
			return true;
		}

		if (CharacterCommonSlot2 != null && CharacterCommonSlot2.isOccupied && GetCharacterOwnerID(CharacterCommonSlot2) != playerID)
		{
			enemyCharacterData = GetCharacterData(CharacterCommonSlot2);
			return true;
		}

		if (CharacterCommonSlot3 != null && CharacterCommonSlot3.isOccupied && GetCharacterOwnerID(CharacterCommonSlot3) != playerID)
		{
			enemyCharacterData = GetCharacterData(CharacterCommonSlot3);
			return true;
		}

		if (CharacterCommonSlot4 != null && CharacterCommonSlot4.isOccupied && GetCharacterOwnerID(CharacterCommonSlot4) != playerID)
		{
			enemyCharacterData = GetCharacterData(CharacterCommonSlot4);
			return true;
		}

		return false;
	}

	private CharacterData GetCharacterData(CharacterSlot characterSlot)
	{
		if (characterSlot != null && characterSlot.characterObject != null)
		{
			return characterSlot.characterObject.GetComponent<CharacterData>();
		}
		return null; // Вернем null в случае, если не удалось получить CharacterData
	}

	private int GetCharacterOwnerID(CharacterSlot characterSlot)
	{
		if (characterSlot != null && characterSlot.characterObject != null)
		{
			CharacterData characterData = characterSlot.characterObject.GetComponent<CharacterData>();
			if (characterData != null)
			{
				return characterData.ownerPlayerID;
			}
		}
		return -1; // Вернем -1 в случае, если не удалось получить ownerPlayerID
	}
	
	public void RemoveItemWithIDFromInventory(int itemID)
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

	public bool HasItemWithID(int itemID)
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
	
	public bool CheckNumberOfItemsWithIDInCityInventory(int itemID, int itemQuantity)
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
	
	public GameObject FindItemWithIDInCityInventory(int itemID)
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
