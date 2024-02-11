using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class CharacterInventoryUI : MonoBehaviour
{
    public GameObject characterInventoryPanel;
    private CharacterData selectedCharacter;
	public CitySelectedData citySelectedData; 
	public CityInventoryUI cityInventoryUI;
	public ForgeUI forgeUI;
	public MashineFactoryUI mashineFactoryUI;
	public Image item1Image;
	public Image item1Slot;
	public TextMeshProUGUI item1Text;
	public Image item2Image;
	public Image item2Slot;
	public TextMeshProUGUI item2Text;
	public Image item3Image;
	public Image item3Slot;
	public TextMeshProUGUI item3Text;
	public Image item4Image;
	public Image item4Slot;
	public TextMeshProUGUI item4Text;
	public Image item5Image;
	public Image item5Slot;
	public TextMeshProUGUI item5Text;
	public Image item6Image;
	public Image item6Slot;
	public TextMeshProUGUI item6Text;
	public Image item7Image;
	public Image item7Slot;
	public TextMeshProUGUI item7Text;
	public Image item8Image;
	public Image item8Slot;
	public TextMeshProUGUI item8Text;
	public Image ItemHelmet;
	public Image ItemShirt;
	public Image ItemVest;
	public Image ItemWeapon;
	public Image ItemAmmo;
	public TextMeshProUGUI itemAmmoText;
	
	public GameObject selectedItemPanel;
	public TextMeshProUGUI itemNameText;
	
	public GameObject CityOrForgeInvButtonObj;
	public Button CityOrForgeInvButton;
	public TextMeshProUGUI CityOrForgeInvButtonText;
	
	public Image CharacterSprite;
	public TextMeshProUGUI CharacterNameText;
	public Button exitButton;
	
	public CharacterInventory characterInventory;
	public ItemsList itemsList;
	public ItemSelection itemSelection;
	public Wear wear;
	public CharacterSelectedData characterSelectedData;
	public EndTurnConfirmation endTurnConfirmation;
	
	public Button itemButton1;
	public Button itemButton2;
	public Button itemButton3;
	public Button itemButton4;
	public Button itemButton5;
	public Button itemButton6;
	public Button itemButton7;
	public Button itemButton8;
	
	public Button HelmetButton;
	public Button ShirtButton;
	public Button VestButton;
	public Button WeaponButton;
	public Button AmmoButton;

    public bool isCharacterInventoryPanelOpen = false; // Флаг, открыто ли диалоговое окно

    private void Start()
    {
        characterInventoryPanel.SetActive(false);
		selectedItemPanel.SetActive(false);
		CityOrForgeInvButtonObj.SetActive(false);
		
		// Добавьте обработчик нажатия на кнопку "Exit"
		exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void Update()
    {
        // Если нажата клавиша "I"
        if (Input.GetKeyDown(KeyCode.I))
        {
			CharacterData selectedCharacter = null;
			selectedCharacter = characterSelectedData.characterData;

			if (selectedCharacter != null && selectedCharacter.ownerPlayerID == endTurnConfirmation.ownerPlayerID)
			{
				OpenInventoryUI(selectedCharacter.characterInventory);
				selectedCharacter.InvOpen = true;
				CharacterSprite.sprite = selectedCharacter.characterImage;
				CharacterSprite.color = new Color(CharacterSprite.color.r, CharacterSprite.color.g, CharacterSprite.color.b, 255);
				CharacterNameText.text = selectedCharacter.characterName;
				characterInventory = selectedCharacter.characterInventory;
				characterInventory.isCharacterInventoryOpen = true;
				RemoveListeners();
				
				if(characterInventory.CommonSlot1 != null)
				{
					itemButton1.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot1));
				}
				if(characterInventory.CommonSlot2 != null)
				{
					itemButton2.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot2));
				}
				if(characterInventory.CommonSlot3 != null)
				{
					itemButton3.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot3));
				}
				if(characterInventory.CommonSlot4 != null)
				{
					itemButton4.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot4));
				}
				if(characterInventory.CommonSlot5 != null)
				{
					itemButton5.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot5));
				}
				if(characterInventory.CommonSlot6 != null)
				{
					itemButton6.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot6));
				}
				if(characterInventory.CommonSlot7 != null)
				{
					itemButton7.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot7));
				}
				if(characterInventory.CommonSlot8 != null)
				{
					itemButton8.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot8));
				}
			
				WeaponButton.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.weaponSlot));
				HelmetButton.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.helmetSlot));
				ShirtButton.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.shirtSlot));
				VestButton.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.vestSlot));
				AmmoButton.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.ammoSlot));
				
				if(selectedCharacter.currentCell.smallCity != null && !cityInventoryUI.isCityInventoryPanelOpen)
				{
					CityOrForgeInvButtonObj.SetActive(true);
					CityOrForgeInvButtonText.text = "CityInv";
					CityOrForgeInvButton.onClick.AddListener(() => CityButtonHandlerCharacter(characterSelectedData.characterData.currentCell.smallCity.cityInventory));
					cityInventoryUI.CharacterInvButtonObj.SetActive(false);
				}
				else if(selectedCharacter.currentCell.forge != null && !forgeUI.isForgePanelOpen)
				{
					CityOrForgeInvButtonObj.SetActive(true);
					CityOrForgeInvButtonText.text = "ForgeInv";
					CityOrForgeInvButton.onClick.AddListener(() => ForgeButtonHandlerCharacter(characterSelectedData.characterData.currentCell.forge));
				}
				else if(selectedCharacter.currentCell.mashineFactory != null && !mashineFactoryUI.isMashineFactoryPanelOpen && selectedCharacter.currentCell.buildingSite == null) 
				{
					CityOrForgeInvButtonObj.SetActive(true);
					CityOrForgeInvButtonText.text = "FactoryInv";
					CityOrForgeInvButton.onClick.AddListener(() => MashineFactoryButtonHandlerCharacter(characterSelectedData.characterData.currentCell.mashineFactory));
				}
				
				selectedCharacter = null;
			}
        }
    }
	
	public void OpenInventoryOnClick()
	{
		CharacterData selectedCharacter = null;
		selectedCharacter = characterSelectedData.characterData;
		
		if (selectedCharacter != null && selectedCharacter.ownerPlayerID == endTurnConfirmation.ownerPlayerID)
		{
			OpenInventoryUI(selectedCharacter.characterInventory);
			selectedCharacter.InvOpen = true;
			CharacterSprite.sprite = selectedCharacter.characterImage;
			CharacterSprite.color = new Color(CharacterSprite.color.r, CharacterSprite.color.g, CharacterSprite.color.b, 255);
			CharacterNameText.text = selectedCharacter.characterName;
			characterInventory = selectedCharacter.characterInventory;
			characterInventory.isCharacterInventoryOpen = true;
			RemoveListeners();
			
				if(characterInventory.CommonSlot1 != null)
				{
					itemButton1.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot1));
				}
				if(characterInventory.CommonSlot2 != null)
				{
					itemButton2.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot2));
				}
				if(characterInventory.CommonSlot3 != null)
				{
					itemButton3.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot3));
				}
				if(characterInventory.CommonSlot4 != null)
				{
					itemButton4.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot4));
				}
				if(characterInventory.CommonSlot5 != null)
				{
					itemButton5.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot5));
				}
				if(characterInventory.CommonSlot6 != null)
				{
					itemButton6.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot6));
				}
				if(characterInventory.CommonSlot7 != null)
				{
					itemButton7.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot7));
				}
				if(characterInventory.CommonSlot8 != null)
				{
					itemButton8.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.CommonSlot8));
				}
			
			WeaponButton.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.weaponSlot));
			HelmetButton.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.helmetSlot));
			ShirtButton.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.shirtSlot));
			VestButton.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.vestSlot));
			AmmoButton.onClick.AddListener(() => ItemClickHandlerCharacter(characterInventory.ammoSlot));
			
			if(selectedCharacter.currentCell.smallCity != null && !cityInventoryUI.isCityInventoryPanelOpen)
			{
				CityOrForgeInvButtonObj.SetActive(true);
				CityOrForgeInvButtonText.text = "CityInv";
				CityOrForgeInvButton.onClick.AddListener(() => CityButtonHandlerCharacter(characterSelectedData.characterData.currentCell.smallCity.cityInventory));
				cityInventoryUI.CharacterInvButtonObj.SetActive(false);
			}
			else if(selectedCharacter.currentCell.forge != null && !forgeUI.isForgePanelOpen && selectedCharacter.currentCell.buildingSite == null)
			{
				CityOrForgeInvButtonObj.SetActive(true);
				CityOrForgeInvButtonText.text = "ForgeInv";
				CityOrForgeInvButton.onClick.AddListener(() => ForgeButtonHandlerCharacter(characterSelectedData.characterData.currentCell.forge));
			}
			else if(selectedCharacter.currentCell.mashineFactory != null && !mashineFactoryUI.isMashineFactoryPanelOpen && selectedCharacter.currentCell.buildingSite == null) 
			{
				CityOrForgeInvButtonObj.SetActive(true);
				CityOrForgeInvButtonText.text = "FactoryInv";
				CityOrForgeInvButton.onClick.AddListener(() => MashineFactoryButtonHandlerCharacter(characterSelectedData.characterData.currentCell.mashineFactory));
			}
			selectedCharacter = null;
		}
	}
	
	private void OpenInventoryUI(CharacterInventory characterInventory)
	{
		isCharacterInventoryPanelOpen = true;
		characterInventoryPanel.SetActive(true);
		DeactivateSlotIcons();
		if (characterInventory != null)
		{
			if(characterInventory.CommonSlot1 != null)
			{
				SetImageWithAlpha(item1Image, GetItemImage(characterInventory.CommonSlot1));
				item1Slot.enabled = true;
			}
			if(characterInventory.CommonSlot2 != null)
			{
				SetImageWithAlpha(item2Image, GetItemImage(characterInventory.CommonSlot2));
				item2Slot.enabled = true;
			}
			if(characterInventory.CommonSlot3 != null)
			{
				SetImageWithAlpha(item3Image, GetItemImage(characterInventory.CommonSlot3));
				item3Slot.enabled = true;
			}
			if(characterInventory.CommonSlot4 != null)
			{
				SetImageWithAlpha(item4Image, GetItemImage(characterInventory.CommonSlot4));
				item4Slot.enabled = true;
			}
			if(characterInventory.CommonSlot5 != null)
			{
				SetImageWithAlpha(item5Image, GetItemImage(characterInventory.CommonSlot5));
				item5Slot.enabled = true;
			}
			if(characterInventory.CommonSlot6 != null)
			{
				SetImageWithAlpha(item6Image, GetItemImage(characterInventory.CommonSlot6));
				item6Slot.enabled = true;
			}
			if(characterInventory.CommonSlot7 != null)
			{
				SetImageWithAlpha(item7Image, GetItemImage(characterInventory.CommonSlot7));
				item7Slot.enabled = true;
			}
			if(characterInventory.CommonSlot8 != null)
			{
				SetImageWithAlpha(item8Image, GetItemImage(characterInventory.CommonSlot8));
				item8Slot.enabled = true;
			}
			
			SetImageWithAlpha(ItemHelmet, GetItemImage(characterInventory.helmetSlot));
			SetImageWithAlpha(ItemShirt, GetItemImage(characterInventory.shirtSlot));
			SetImageWithAlpha(ItemVest, GetItemImage(characterInventory.vestSlot));
			SetImageWithAlpha(ItemWeapon, GetItemImage(characterInventory.weaponSlot));
			SetImageWithAlpha(ItemAmmo, GetItemImage(characterInventory.ammoSlot));
			if(characterInventory.ammoSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterInventory.ammoSlot.itemGameObject.GetComponent<ItemObject>();
				if(itemObject.quantity > 1)
				{
					itemAmmoText.text = itemObject.quantity.ToString();
				}
				else
				{
					itemAmmoText.text = "";
				}
			}
			else
			{
				itemAmmoText.text = "";
			}

			// Добавим метод для установки изображения с учетом альфа-канала
			void SetImageWithAlpha(Image image, Sprite sprite)
			{
				if (image != null)
				{
					image.sprite = sprite;
					image.color = sprite != null ? Color.white : new Color(0, 0, 0, 0); // Устанавливаем прозрачность, если спрайт отсутствует
				}
			}

			for (int i = 1; i <= 8; i++)
			{
				InventorySlot inventorySlot = null;
				Image itemSprite = null;

				switch (i)
				{
					case 1:
						inventorySlot = characterInventory.CommonSlot1;
						itemSprite = item1Image;
						if(characterInventory.CommonSlot1 != null && characterInventory.CommonSlot1.itemGameObject != null)
						{
							ItemObject itemObject = characterInventory.CommonSlot1.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item1Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item1Text.text = "";
							}
						}
						else
						{
							item1Text.text = "";
						}
						break;
					case 2:
						inventorySlot = characterInventory.CommonSlot2;
						itemSprite = item2Image;
						if(characterInventory.CommonSlot2 != null && characterInventory.CommonSlot2.itemGameObject != null)
						{
							ItemObject itemObject = characterInventory.CommonSlot2.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item2Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item2Text.text = "";
							}
						}
						else
						{
							item2Text.text = "";
						}
						break;
					case 3:
						inventorySlot = characterInventory.CommonSlot3;
						itemSprite = item3Image;
						if(characterInventory.CommonSlot3 != null && characterInventory.CommonSlot3.itemGameObject != null)
						{
							ItemObject itemObject = characterInventory.CommonSlot3.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item3Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item3Text.text = "";
							}
						}
						else
						{
							item3Text.text = "";
						}
						break;
					case 4:
						inventorySlot = characterInventory.CommonSlot4;
						itemSprite = item4Image;
						if(characterInventory.CommonSlot4 != null && characterInventory.CommonSlot4.itemGameObject != null)
						{
							ItemObject itemObject = characterInventory.CommonSlot4.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item4Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item4Text.text = "";
							}
						}
						else
						{
							item4Text.text = "";
						}
						break;
					case 5:
						inventorySlot = characterInventory.CommonSlot5;
						itemSprite = item5Image;
						if(characterInventory.CommonSlot5 != null && characterInventory.CommonSlot5.itemGameObject != null)
						{
							ItemObject itemObject = characterInventory.CommonSlot5.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item5Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item5Text.text = "";
							}
						}
						else
						{
							item5Text.text = "";
						}
						break;
					case 6:
						inventorySlot = characterInventory.CommonSlot6;
						itemSprite = item6Image;
						if(characterInventory.CommonSlot6 != null && characterInventory.CommonSlot6.itemGameObject != null)
						{
							ItemObject itemObject = characterInventory.CommonSlot6.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item6Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item6Text.text = "";
							}
						}
						else
						{
							item6Text.text = "";
						}
						break;
					case 7:
						inventorySlot = characterInventory.CommonSlot7;
						itemSprite = item7Image;
						if(characterInventory.CommonSlot7 != null && characterInventory.CommonSlot7.itemGameObject != null)
						{
							ItemObject itemObject = characterInventory.CommonSlot7.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item7Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item7Text.text = "";
							}
						}
						else
						{
							item7Text.text = "";
						}
						break;
					case 8:
						inventorySlot = characterInventory.CommonSlot8;
						itemSprite = item8Image;
						if(characterInventory.CommonSlot8 != null && characterInventory.CommonSlot8.itemGameObject != null)
						{
							ItemObject itemObject = characterInventory.CommonSlot8.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item8Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item8Text.text = "";
							}
						}
						else
						{
							item8Text.text = "";
						}
						break;
				}

				if (inventorySlot != null)
				{
					GameObject itemObj = inventorySlot.itemGameObject;

					if (itemObj != null)
					{
						ItemObject itemObject = itemObj.GetComponent<ItemObject>();

						if (itemObject != null)
						{
							Sprite itemSpr = itemObject.itemSprite;
						}
					}
				}
			}
		}
	//characterInventory.UpdateItemSpritesCharacter();
	}
	
	public void UpdateItemSpritesCharacter()
	{
		CharacterInventory selectedInventory = FindObjectsOfType<CharacterInventory>().FirstOrDefault(inventory => inventory.isCharacterInventoryOpen);
		if (selectedInventory!= null)
		{
			if(selectedInventory.CommonSlot1 != null)
			{
				SetImageWithAlpha(item1Image, GetItemImage(selectedInventory.CommonSlot1));
				item1Slot.enabled = true;
			}
			if(selectedInventory.CommonSlot2 != null)
			{
				SetImageWithAlpha(item2Image, GetItemImage(selectedInventory.CommonSlot2));
				item2Slot.enabled = true;
			}
			if(selectedInventory.CommonSlot3 != null)
			{
				SetImageWithAlpha(item3Image, GetItemImage(selectedInventory.CommonSlot3));
				item3Slot.enabled = true;
			}
			if(selectedInventory.CommonSlot4 != null)
			{
				SetImageWithAlpha(item4Image, GetItemImage(selectedInventory.CommonSlot4));
				item4Slot.enabled = true;
			}
			if(selectedInventory.CommonSlot5 != null)
			{
				SetImageWithAlpha(item5Image, GetItemImage(selectedInventory.CommonSlot5));
				item5Slot.enabled = true;
			}
			if(selectedInventory.CommonSlot6 != null)
			{
				SetImageWithAlpha(item6Image, GetItemImage(selectedInventory.CommonSlot6));
				item6Slot.enabled = true;
			}
			if(selectedInventory.CommonSlot7 != null)
			{
				SetImageWithAlpha(item7Image, GetItemImage(selectedInventory.CommonSlot7));
				item7Slot.enabled = true;
			}
			if(selectedInventory.CommonSlot8 != null)
			{
				SetImageWithAlpha(item8Image, GetItemImage(selectedInventory.CommonSlot8));
				item8Slot.enabled = true;
			}
			
			SetImageWithAlpha(ItemHelmet, GetItemImage(selectedInventory.helmetSlot));
			SetImageWithAlpha(ItemShirt, GetItemImage(selectedInventory.shirtSlot));
			SetImageWithAlpha(ItemVest, GetItemImage(selectedInventory.vestSlot));
			SetImageWithAlpha(ItemWeapon, GetItemImage(selectedInventory.weaponSlot));
			SetImageWithAlpha(ItemAmmo, GetItemImage(selectedInventory.ammoSlot));
			if(selectedInventory.ammoSlot.itemGameObject != null)
			{
				ItemObject itemObject = selectedInventory.ammoSlot.itemGameObject.GetComponent<ItemObject>();
				if(itemObject.quantity > 1)
				{
					itemAmmoText.text = itemObject.quantity.ToString();
				}
				else
				{
					itemAmmoText.text = "";
				}
			}
			else
			{
				itemAmmoText.text = "";
			}

			// Добавим метод для установки изображения с учетом альфа-канала
			void SetImageWithAlpha(Image image, Sprite sprite)
			{
				if (image != null)
				{
					image.sprite = sprite;

					if (sprite == null)
					{
						image.color = new Color(0, 0, 0, 0); // Устанавливаем прозрачность, если спрайт отсутствует
					}
					else
					{
						image.color = Color.white;
					}
				}
			}
		}

		for (int i = 1; i <= 8; i++)
		{
			InventorySlot inventorySlot = null;
			Image itemSprite = null;

				switch (i)
				{
					case 1:
						inventorySlot = selectedInventory.CommonSlot1;
						itemSprite = item1Image;
						if(selectedInventory.CommonSlot1 != null)
						{
							if(selectedInventory.CommonSlot1.itemGameObject != null)
							{
								ItemObject itemObject = selectedInventory.CommonSlot1.itemGameObject.GetComponent<ItemObject>();
								if(itemObject.quantity > 1)
								{
									item1Text.text = itemObject.quantity.ToString();
								}
								else
								{
									item1Text.text = "";
								}
							}
							else
							{
								item1Text.text = "";
							}
						}
						break;
					case 2:
						inventorySlot = selectedInventory.CommonSlot2;
						itemSprite = item2Image;
						if(selectedInventory.CommonSlot2 != null)
						{
							if(selectedInventory.CommonSlot2.itemGameObject != null)
							{
								ItemObject itemObject = selectedInventory.CommonSlot2.itemGameObject.GetComponent<ItemObject>();
								if(itemObject.quantity > 1)
								{
									item2Text.text = itemObject.quantity.ToString();
								}
								else
								{
									item2Text.text = "";
								}
							}
							else
							{
								item2Text.text = "";
							}
						}
						break;
					case 3:
						inventorySlot = selectedInventory.CommonSlot3;
						itemSprite = item3Image;
						if(selectedInventory.CommonSlot3 != null)
						{
							if(selectedInventory.CommonSlot3.itemGameObject != null)
							{
								ItemObject itemObject = selectedInventory.CommonSlot3.itemGameObject.GetComponent<ItemObject>();
								if(itemObject.quantity > 1)
								{
									item3Text.text = itemObject.quantity.ToString();
								}
								else
								{
									item3Text.text = "";
								}
							}
							else
							{
								item3Text.text = "";
							}
						}
						break;
					case 4:
						inventorySlot = selectedInventory.CommonSlot4;
						itemSprite = item4Image;
						if(selectedInventory.CommonSlot4 != null)
						{
							if(selectedInventory.CommonSlot4.itemGameObject != null)
							{
								ItemObject itemObject = selectedInventory.CommonSlot4.itemGameObject.GetComponent<ItemObject>();
								if(itemObject.quantity > 1)
								{
									item4Text.text = itemObject.quantity.ToString();
								}
								else
								{
									item4Text.text = "";
								}
							}
							else
							{
								item4Text.text = "";
							}
						}
						break;
					case 5:
						inventorySlot = selectedInventory.CommonSlot5;
						itemSprite = item5Image;
						if(selectedInventory.CommonSlot5 != null)
						{
							if(selectedInventory.CommonSlot5.itemGameObject != null)
							{
								ItemObject itemObject = selectedInventory.CommonSlot5.itemGameObject.GetComponent<ItemObject>();
								if(itemObject.quantity > 1)
								{
									item5Text.text = itemObject.quantity.ToString();
								}
								else
								{
									item5Text.text = "";
								}
							}
							else
							{
								item5Text.text = "";
							}
						}
						break;
					case 6:
						inventorySlot = selectedInventory.CommonSlot6;
						itemSprite = item6Image;
						if(selectedInventory.CommonSlot6 != null)
						{
							if(selectedInventory.CommonSlot6.itemGameObject != null)
							{
								ItemObject itemObject = selectedInventory.CommonSlot6.itemGameObject.GetComponent<ItemObject>();
								if(itemObject.quantity > 1)
								{
									item6Text.text = itemObject.quantity.ToString();
								}
								else
								{
									item6Text.text = "";
								}
							}
							else
							{
								item6Text.text = "";
							}
						}
						break;
					case 7:
						inventorySlot = selectedInventory.CommonSlot7;
						itemSprite = item7Image;
						if(selectedInventory.CommonSlot7 != null)
						{
							if(selectedInventory.CommonSlot7.itemGameObject != null)
							{
								ItemObject itemObject = selectedInventory.CommonSlot7.itemGameObject.GetComponent<ItemObject>();
								if(itemObject.quantity > 1)
								{
									item7Text.text = itemObject.quantity.ToString();
								}
								else
								{
									item7Text.text = "";
								}
							}
							else
							{
								item7Text.text = "";
							}
						}
						break;
					case 8:
						inventorySlot = selectedInventory.CommonSlot8;
						itemSprite = item8Image;
						if(selectedInventory.CommonSlot8 != null)
						{
							if(selectedInventory.CommonSlot8.itemGameObject != null)
							{
								ItemObject itemObject = selectedInventory.CommonSlot8.itemGameObject.GetComponent<ItemObject>();
								if(itemObject.quantity > 1)
								{
									item8Text.text = itemObject.quantity.ToString();
								}
								else
								{
									item8Text.text = "";
								}
							}
							else
							{
								item8Text.text = "";
							}
						}
						break;
				}
			if (inventorySlot != null)
			{
				GameObject itemObj = inventorySlot.itemGameObject;

				if (itemObj != null)
				{
					ItemObject itemObject = itemObj.GetComponent<ItemObject>();

					if (itemObject != null)
					{
						Sprite itemSpr = itemObject.itemSprite;
					}
				}
			}
		}
	}

	private void SetImageWithAlpha(Image itemImage, Sprite slotSprite)
	{
		if (itemImage != null)
		{
			if (slotSprite == null)
			{
				itemImage.color = new Color(1f, 1f, 1f, 0f);
			}
			else
			{
				itemImage.sprite = slotSprite;
				itemImage.color = Color.white;
			}
		}
	}
	
	private Image GetItemImageForSlot(int slotIndex)
	{
		switch (slotIndex)
		{
			case 1:
				return item1Image;
			case 2:
				return item2Image;
			case 3:
				return item3Image;
			case 4:
				return item4Image;
			case 5:
				return item5Image;
			case 6:
				return item6Image;
			case 7:
				return item7Image;
			case 8:
				return item8Image;
			default:
				return null;
		}
	}
	
	public void CloseCharacterInventoryUI()
	{
		// Сбрасываем InvOpen в false для всех городов, у которых оно true
		CharacterData[] allCharacters = FindObjectsOfType<CharacterData>();
		foreach (CharacterData character in allCharacters)
		{
			if (character.InvOpen)
			{
				character.InvOpen = false;
				character.isSelected = false;
				CharacterSprite.sprite = null;
				CharacterSprite.color = new Color(1f, 1f, 1f, 0f);
				character.characterInventory.isCharacterInventoryOpen = false;
			}
		}
		
		selectedItemPanel.SetActive(false);
		CityOrForgeInvButtonObj.SetActive(false);
		itemNameText.text = "";
		CityOrForgeInvButtonText.text = "";
		
		item1Image.sprite = null;
		item2Image.sprite = null;
		item3Image.sprite = null;
		item4Image.sprite = null;
		item5Image.sprite = null;
		item6Image.sprite = null;
		item7Image.sprite = null;
		item8Image.sprite = null;
		
		item1Text.text = "";
		item2Text.text = "";
		item3Text.text = "";
		item4Text.text = "";
		item5Text.text = "";
		item6Text.text = "";
		item7Text.text = "";
		item8Text.text = "";

		// Очищаем изображения персонажей
		ItemHelmet.sprite = null;
		ItemShirt.sprite = null;
		ItemVest.sprite = null;
		ItemWeapon.sprite = null;
		ItemAmmo.sprite = null;
		
		CharacterInventory[] characterInventorys = FindObjectsOfType<CharacterInventory>();

		// Закрываем инвентарь
		isCharacterInventoryPanelOpen = false;
		characterInventoryPanel.SetActive(false);
		itemSelection.isFlashing = false;
		itemSelection.ButtonPanel.SetActive(false);
		itemSelection.ItemSeparationObj.SetActive(false);
		itemSelection.SplitButtonObj.SetActive(false);
		
		
		InventorySlot[] allSlots = FindObjectsOfType<InventorySlot>();

		// Проходимся по каждому слоту и устанавливаем isOccupied в false
		foreach (InventorySlot slot in allSlots)
		{
			slot.isSelected = false;
		}
		characterSelectedData.characterData = null;
	}
		
	private void OnExitButtonClick()
	{
		CloseCharacterInventoryUI();
	}
	
    public CharacterInventory FindCharacterInventory(int characterID)
    {
        // Найти CharacterInventory с заданным characterID
        CharacterInventory[] characterInventorys = FindObjectsOfType<CharacterInventory>();
		
        foreach (CharacterInventory characterInventory in characterInventorys)
        {
            if (characterInventory.characterID == characterID)
            {
                return characterInventory;
            }
        }

        return null; // Возвращаем null, если не найдено
    }
	
	private Sprite GetItemImage(InventorySlot inventorySlot)
	{
		if (inventorySlot != null && inventorySlot.itemGameObject != null)
		{
			ItemObject itemObj = inventorySlot.itemGameObject.GetComponent<ItemObject>();

			if (itemObj != null && itemObj.itemSprite != null)
			{
				return itemObj.itemSprite;
			}
		}

		return null;
	}
	
	private void ItemClickHandlerCharacter(InventorySlot inventorySlot)
	{
		if (inventorySlot != null && inventorySlot.itemGameObject == null)
		{
			InventorySlot selectedInventorySlot = FindObjectOfType<InventorySlot>();
			inventorySlot.itemGameObject = selectedInventorySlot.itemGameObject;
			selectedInventorySlot.isSelected = false;
		}
		else if (inventorySlot != null && inventorySlot.itemGameObject != null)
		{
			GameObject itemGameObject = inventorySlot.itemGameObject;
			
			ItemObject itemObject = itemGameObject.GetComponent<ItemObject>();
			
			itemSelection.SelectItem(itemGameObject);
			
			if (itemObject.quantity > 1)
			{
				itemSelection.ItemSeparationObj.SetActive(true);
			}

			//CloseInventoryUI();
		}
	}
	
	public Button GetButtonForItemCharacter(GameObject itemGameObject, CharacterInventory characterInventory)
    {
        if (characterInventory.CommonSlot1 != null && itemGameObject == characterInventory.CommonSlot1.itemGameObject)
            return itemButton1;
        else if (characterInventory.CommonSlot2 != null && itemGameObject == characterInventory.CommonSlot2.itemGameObject)
            return itemButton2;
        else if (characterInventory.CommonSlot3 != null && itemGameObject == characterInventory.CommonSlot3.itemGameObject)
            return itemButton3;
        else if (characterInventory.CommonSlot4 != null && itemGameObject == characterInventory.CommonSlot4.itemGameObject)
            return itemButton4;
        else if (characterInventory.CommonSlot5 != null && itemGameObject == characterInventory.CommonSlot5.itemGameObject)
            return itemButton5;
        else if (characterInventory.CommonSlot6 != null && itemGameObject == characterInventory.CommonSlot6.itemGameObject)
            return itemButton6;
        else if (characterInventory.CommonSlot7 != null && itemGameObject == characterInventory.CommonSlot7.itemGameObject)
            return itemButton7;
        else if (characterInventory.CommonSlot8 != null && itemGameObject == characterInventory.CommonSlot8.itemGameObject)
            return itemButton8;
		else if (itemGameObject == characterInventory.weaponSlot.itemGameObject)
            return WeaponButton;
        else if (itemGameObject == characterInventory.helmetSlot.itemGameObject)
            return HelmetButton;
        else if (itemGameObject == characterInventory.shirtSlot.itemGameObject)
            return ShirtButton;
        else if (itemGameObject == characterInventory.vestSlot.itemGameObject)
            return VestButton;
		else if (itemGameObject == characterInventory.ammoSlot.itemGameObject)
            return AmmoButton;

        return null;
    }
	
	private void RemoveListeners()
	{
		itemButton1.onClick.RemoveAllListeners();
		itemButton2.onClick.RemoveAllListeners();
		itemButton3.onClick.RemoveAllListeners();
		itemButton4.onClick.RemoveAllListeners();
		itemButton5.onClick.RemoveAllListeners();
		itemButton6.onClick.RemoveAllListeners();
		itemButton7.onClick.RemoveAllListeners();
		itemButton8.onClick.RemoveAllListeners();
		
		WeaponButton.onClick.RemoveAllListeners();
		HelmetButton.onClick.RemoveAllListeners();
		ShirtButton.onClick.RemoveAllListeners();
		VestButton.onClick.RemoveAllListeners();
		AmmoButton.onClick.RemoveAllListeners();
		CityOrForgeInvButton.onClick.RemoveAllListeners();
	}
	
	private void DeactivateSlotIcons()
	{
		item1Slot.enabled = false;
		item2Slot.enabled = false;
		item3Slot.enabled = false;
		item4Slot.enabled = false;
		item5Slot.enabled = false;
		item6Slot.enabled = false;
		item7Slot.enabled = false;
		item8Slot.enabled = false;
	}
	
	private void CityButtonHandlerCharacter(CityInventory cityInventory)
	{
		if(!cityInventoryUI.isCityInventoryPanelOpen)
		{
			if (cityInventory != null)
			{
				cityInventoryUI.OpenInventoryUI(cityInventory);
				CityOrForgeInvButtonObj.SetActive(false);
				citySelectedData.smallCity = characterSelectedData.characterData.currentCell.smallCity;
			}
		}
	}
	
	private void ForgeButtonHandlerCharacter(Forge forge)
	{
		if(!forgeUI.isForgePanelOpen)
		{
			if (forge != null)
			{
				forgeUI.OpenForgeUI(forge);
				forgeUI.DemobilizeButtonObj.SetActive(true);
				CityOrForgeInvButtonObj.SetActive(false);
			}
		}
	}
	
	private void MashineFactoryButtonHandlerCharacter(MashineFactory mashineFactory)
	{
		if(!mashineFactoryUI.isMashineFactoryPanelOpen)
		{
			if (mashineFactory != null)
			{
				mashineFactoryUI.OpenMashineFactoryInventory(mashineFactory);
				CityOrForgeInvButtonObj.SetActive(false);
			}
		}
	}
}
