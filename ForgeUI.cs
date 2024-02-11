using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class ForgeUI : MonoBehaviour
{
	public GameObject forgePanel;
	public Forge forge;
	public Image forgeImageRenderer;
	public TextMeshProUGUI ownerPlayerIDText;
	public TextMeshProUGUI PopulationText;
	public TextMeshProUGUI PopulationAP;
	public ItemSelection itemSelection;
	public CharacterInventoryUI characterInventoryUI;
	public CrafterData crafterData;
	public CharacterSelection characterSelection;
	public CharacterSelectedData characterSelectedData;
	
	public Image item1Image;
	public TextMeshProUGUI item1Text;
	public Image item2Image;
	public TextMeshProUGUI item2Text;
	public Image item3Image;
	public TextMeshProUGUI item3Text;
	public Image item4Image;
	public TextMeshProUGUI item4Text;
	public Image item5Image;
	public TextMeshProUGUI item5Text;
	public Image item6Image;
	public TextMeshProUGUI item6Text;
	public Image item7Image;
	public TextMeshProUGUI item7Text;
	public Image item8Image;
	public TextMeshProUGUI item8Text;
	
	public GameObject selectedItemPanel;
	public TextMeshProUGUI itemNameText;
	
	public Button exitButton;
	
	public Button itemButton1;
	public Button itemButton2;
	public Button itemButton3;
	public Button itemButton4;
	public Button itemButton5;
	public Button itemButton6;
	public Button itemButton7;
	public Button itemButton8;
	
	public Button DemobilizeButton;
	public Button CharacterInvButton;
	public GameObject DemobilizeButtonObj;
	public GameObject CharacterInvButtonObj;
	
	public bool isForgePanelOpen = false;
	
	public ItemsList itemsList;

    private void Start()
    {
		forgePanel.SetActive(false);
		selectedItemPanel.SetActive(false);
		CharacterInvButtonObj.SetActive(false);
		DemobilizeButtonObj.SetActive(false);
	}

	public void OpenForgeInventory(Forge selectedForge)
	{
		GameObject selectedForgeObject = selectedForge.forgeObject;
		SpriteRenderer forgeSpriteRenderer = selectedForgeObject.GetComponent<SpriteRenderer>();
		forgeImageRenderer.sprite = forgeSpriteRenderer.sprite;
		RemoveListeners();

		OpenForgeUI(selectedForge);
		selectedForge.isForgeInventoryOpen = true;
					
		itemButton1.onClick.AddListener(() => ItemClickHandlerForge(selectedForge.CommonSlot1));
		itemButton2.onClick.AddListener(() => ItemClickHandlerForge(selectedForge.CommonSlot2));
		itemButton3.onClick.AddListener(() => ItemClickHandlerForge(selectedForge.CommonSlot3));
		itemButton4.onClick.AddListener(() => ItemClickHandlerForge(selectedForge.CommonSlot4));
		itemButton5.onClick.AddListener(() => ItemClickHandlerForge(selectedForge.CommonSlot5));
		itemButton6.onClick.AddListener(() => ItemClickHandlerForge(selectedForge.CommonSlot6));
		itemButton7.onClick.AddListener(() => ItemClickHandlerForge(selectedForge.CommonSlot7));
		itemButton8.onClick.AddListener(() => ItemClickHandlerForge(selectedForge.CommonSlot8));
	}

	private Image GetItemImageForSlotForge(int slotIndex)
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

	public void OpenForgeUI(Forge selectedForge)
	{
		crafterData.forge = selectedForge;
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.CityOrForgeInvButtonObj.SetActive(false);
			DemobilizeButtonObj.SetActive(true);
		}
		
		if(itemSelection.itemIsSelected)
		{
			itemSelection.ButtonPanel.SetActive(true);
		}
		isForgePanelOpen = true;
		forgePanel.SetActive(true);
		
		ownerPlayerIDText.text = "OwnerPlayerID: " + selectedForge.ownerPlayerID;
		PopulationAP.text = "Workers AP: " + selectedForge.PopulationAP;
		PopulationText.text = "Workers: " + selectedForge.Population;

		SetImageWithAlpha(item1Image, GetItemImageForge(selectedForge.CommonSlot1));
		SetImageWithAlpha(item2Image, GetItemImageForge(selectedForge.CommonSlot2));
		SetImageWithAlpha(item3Image, GetItemImageForge(selectedForge.CommonSlot3));
		SetImageWithAlpha(item4Image, GetItemImageForge(selectedForge.CommonSlot4));
		SetImageWithAlpha(item5Image, GetItemImageForge(selectedForge.CommonSlot5));
		SetImageWithAlpha(item6Image, GetItemImageForge(selectedForge.CommonSlot6));
		SetImageWithAlpha(item7Image, GetItemImageForge(selectedForge.CommonSlot7));
		SetImageWithAlpha(item8Image, GetItemImageForge(selectedForge.CommonSlot8));

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
					inventorySlot = selectedForge.CommonSlot1;
					itemSprite = item1Image;
					if(selectedForge.CommonSlot1.itemGameObject != null)
					{
						ItemObject itemObject = selectedForge.CommonSlot1.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedForge.CommonSlot2;
					itemSprite = item2Image;
					if(selectedForge.CommonSlot2.itemGameObject != null)
					{
						ItemObject itemObject = selectedForge.CommonSlot2.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedForge.CommonSlot3;
					itemSprite = item3Image;
					if(selectedForge.CommonSlot3.itemGameObject != null)
					{
						ItemObject itemObject = selectedForge.CommonSlot3.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedForge.CommonSlot4;
					itemSprite = item4Image;
					if(selectedForge.CommonSlot4.itemGameObject != null)
					{
						ItemObject itemObject = selectedForge.CommonSlot4.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedForge.CommonSlot5;
					itemSprite = item5Image;
					if(selectedForge.CommonSlot5.itemGameObject != null)
					{
						ItemObject itemObject = selectedForge.CommonSlot5.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedForge.CommonSlot6;
					itemSprite = item6Image;
					if(selectedForge.CommonSlot6.itemGameObject != null)
					{
						ItemObject itemObject = selectedForge.CommonSlot6.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedForge.CommonSlot7;
					itemSprite = item7Image;
					if(selectedForge.CommonSlot7.itemGameObject != null)
					{
						ItemObject itemObject = selectedForge.CommonSlot7.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedForge.CommonSlot8;
					itemSprite = item8Image;
					if(selectedForge.CommonSlot8.itemGameObject != null)
					{
						ItemObject itemObject = selectedForge.CommonSlot8.itemGameObject.GetComponent<ItemObject>();
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
		selectedForge.UpdateItemSpritesForge();
	}
	
	public void UpdateItemSpritesForge()
	{
		Forge forge = FindObjectsOfType<Forge>().FirstOrDefault(inventory => inventory.isForgeInventoryOpen);
		if (forge == null)
		{
			forge = crafterData.forge;
		}
		
		if (forge!= null)
		{
			SetImageWithAlpha(item1Image, GetItemImageForge(forge.CommonSlot1));
			SetImageWithAlpha(item2Image, GetItemImageForge(forge.CommonSlot2));
			SetImageWithAlpha(item3Image, GetItemImageForge(forge.CommonSlot3));
			SetImageWithAlpha(item4Image, GetItemImageForge(forge.CommonSlot4));
			SetImageWithAlpha(item5Image, GetItemImageForge(forge.CommonSlot5));
			SetImageWithAlpha(item6Image, GetItemImageForge(forge.CommonSlot6));
			SetImageWithAlpha(item7Image, GetItemImageForge(forge.CommonSlot7));
			SetImageWithAlpha(item8Image, GetItemImageForge(forge.CommonSlot8));

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
			for (int i = 1; i <= 8; i++)
			{
				InventorySlot inventorySlot = null;
				Image itemSprite = null;
				switch (i)
				{
					case 1:
						inventorySlot = forge.CommonSlot1;
						itemSprite = item1Image;
						if(forge.CommonSlot1.itemGameObject != null)
						{
							ItemObject itemObject = forge.CommonSlot1.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item1Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item1Text.text = "";
							}
						}
						else if(forge.CommonSlot1.itemGameObject == null)
						{
							item1Text.text = "";
						}
						break;
					case 2:
						inventorySlot = forge.CommonSlot2;
						itemSprite = item2Image;
						if(forge.CommonSlot2.itemGameObject != null)
						{
							ItemObject itemObject = forge.CommonSlot2.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item2Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item2Text.text = "";
							}
						}
						else if(forge.CommonSlot2.itemGameObject == null)
						{
							item2Text.text = "";
						}
						break;
					case 3:
						inventorySlot = forge.CommonSlot3;
						itemSprite = item3Image;
						if(forge.CommonSlot3.itemGameObject != null)
						{
							ItemObject itemObject = forge.CommonSlot3.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item3Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item3Text.text = "";
							}
						}
						else if(forge.CommonSlot3.itemGameObject == null)
						{
							item3Text.text = "";
						}
						break;
					case 4:
						inventorySlot = forge.CommonSlot4;
						itemSprite = item4Image;
						if(forge.CommonSlot4.itemGameObject != null)
						{
							ItemObject itemObject = forge.CommonSlot4.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item4Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item4Text.text = "";
							}
						}
						else if(forge.CommonSlot4.itemGameObject == null)
						{
							item4Text.text = "";
						}
						break;
					case 5:
						inventorySlot = forge.CommonSlot5;
						itemSprite = item5Image;
						if(forge.CommonSlot5.itemGameObject != null)
						{
							ItemObject itemObject = forge.CommonSlot5.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item5Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item5Text.text = "";
							}
						}
						else if(forge.CommonSlot5.itemGameObject == null)
						{
							item5Text.text = "";
						}
						break;
					case 6:
						inventorySlot = forge.CommonSlot6;
						itemSprite = item6Image;
						if(forge.CommonSlot6.itemGameObject != null)
						{
							ItemObject itemObject = forge.CommonSlot6.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item6Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item6Text.text = "";
							}
						}
						else if(forge.CommonSlot6.itemGameObject == null)
						{
							item6Text.text = "";
						}
						break;
					case 7:
						inventorySlot = forge.CommonSlot7;
						itemSprite = item7Image;
						if(forge.CommonSlot7.itemGameObject != null)
						{
							ItemObject itemObject = forge.CommonSlot7.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item7Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item7Text.text = "";
							}
						}
						else if(forge.CommonSlot7.itemGameObject == null)
						{
							item7Text.text = "";
						}
						break;
					case 8:
						inventorySlot = forge.CommonSlot8;
						itemSprite = item8Image;
						if(forge.CommonSlot8.itemGameObject != null)
						{
							ItemObject itemObject = forge.CommonSlot8.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item8Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item8Text.text = "";
							}
						}
						else if(forge.CommonSlot8.itemGameObject == null)
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
	}
	
	public void UpdateItemSpritesCertainForge(Forge forge)
	{
		if (forge!= null)
		{
			SetImageWithAlpha(item1Image, GetItemImageForge(forge.CommonSlot1));
			SetImageWithAlpha(item2Image, GetItemImageForge(forge.CommonSlot2));
			SetImageWithAlpha(item3Image, GetItemImageForge(forge.CommonSlot3));
			SetImageWithAlpha(item4Image, GetItemImageForge(forge.CommonSlot4));
			SetImageWithAlpha(item5Image, GetItemImageForge(forge.CommonSlot5));
			SetImageWithAlpha(item6Image, GetItemImageForge(forge.CommonSlot6));
			SetImageWithAlpha(item7Image, GetItemImageForge(forge.CommonSlot7));
			SetImageWithAlpha(item8Image, GetItemImageForge(forge.CommonSlot8));

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
					inventorySlot = forge.CommonSlot1;
					itemSprite = item1Image;
					if(forge.CommonSlot1.itemGameObject != null)
					{
						ItemObject itemObject = forge.CommonSlot1.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item1Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item1Text.text = "";
						}
					}
					else if(forge.CommonSlot1.itemGameObject == null)
					{
						item1Text.text = "";
					}
					break;
				case 2:
					inventorySlot = forge.CommonSlot2;
					itemSprite = item2Image;
					if(forge.CommonSlot2.itemGameObject != null)
					{
						ItemObject itemObject = forge.CommonSlot2.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item2Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item2Text.text = "";
						}
					}
					else if(forge.CommonSlot2.itemGameObject == null)
					{
						item2Text.text = "";
					}
					break;
				case 3:
					inventorySlot = forge.CommonSlot3;
					itemSprite = item3Image;
					if(forge.CommonSlot3.itemGameObject != null)
					{
						ItemObject itemObject = forge.CommonSlot3.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item3Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item3Text.text = "";
						}
					}
					else if(forge.CommonSlot3.itemGameObject == null)
					{
						item3Text.text = "";
					}
					break;
				case 4:
					inventorySlot = forge.CommonSlot4;
					itemSprite = item4Image;
					if(forge.CommonSlot4.itemGameObject != null)
					{
						ItemObject itemObject = forge.CommonSlot4.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item4Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item4Text.text = "";
						}
					}
					else if(forge.CommonSlot4.itemGameObject == null)
					{
						item4Text.text = "";
					}
					break;
				case 5:
					inventorySlot = forge.CommonSlot5;
					itemSprite = item5Image;
					if(forge.CommonSlot5.itemGameObject != null)
					{
						ItemObject itemObject = forge.CommonSlot5.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item5Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item5Text.text = "";
						}
					}
					else if(forge.CommonSlot5.itemGameObject == null)
					{
						item5Text.text = "";
					}
					break;
				case 6:
					inventorySlot = forge.CommonSlot6;
					itemSprite = item6Image;
					if(forge.CommonSlot6.itemGameObject != null)
					{
						ItemObject itemObject = forge.CommonSlot6.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item6Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item6Text.text = "";
						}
					}
					else if(forge.CommonSlot6.itemGameObject == null)
					{
						item6Text.text = "";
					}
					break;
				case 7:
					inventorySlot = forge.CommonSlot7;
					itemSprite = item7Image;
					if(forge.CommonSlot7.itemGameObject != null)
					{
						ItemObject itemObject = forge.CommonSlot7.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item7Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item7Text.text = "";
						}
					}
					else if(forge.CommonSlot7.itemGameObject == null)
					{
						item7Text.text = "";
					}
					break;
				case 8:
					inventorySlot = forge.CommonSlot8;
					itemSprite = item8Image;
					if(forge.CommonSlot8.itemGameObject != null)
					{
						ItemObject itemObject = forge.CommonSlot8.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item8Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item8Text.text = "";
						}
					}
					else if(forge.CommonSlot8.itemGameObject == null)
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
	
	public void CloseInventoryUIForge()
	{
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.CityOrForgeInvButtonObj.SetActive(true);
			characterInventoryUI.CityOrForgeInvButtonText.text = "ForgeInv";
		}
		// Сбрасываем InvOpen в false для всех городов, у которых оно true
		Forge[] allForges = FindObjectsOfType<Forge>();
		foreach (Forge forge1 in allForges)
		{
			if (forge1.isForgeInventoryOpen)
			{
				forge1.isSelected = false;
				forge1.isForgeInventoryOpen = false;
			}
		}
		
		crafterData.forge = null;
		selectedItemPanel.SetActive(false);
		itemNameText.text = "";
		
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
		

		// Закрываем инвентарь
		isForgePanelOpen = false;
		forgePanel.SetActive(false);
		itemSelection.isFlashing = false;
		itemSelection.itemIsSelected = false;
		itemSelection.ButtonPanel.SetActive(false);
		itemSelection.ItemSeparationObj.SetActive(false);
		itemSelection.SplitButtonObj.SetActive(false);
		
		InventorySlot[] allSlots = FindObjectsOfType<InventorySlot>();

		// Проходимся по каждому слоту и устанавливаем isOccupied в false
		foreach (InventorySlot slot in allSlots)
		{
			slot.isSelected = false;
		}
	}
		
	private void OnExitButtonClick()
	{
		CloseInventoryUIForge();
	}
	
	private void ItemClickHandlerForge(InventorySlot inventorySlot)
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
	
	private Sprite GetItemImageForge(InventorySlot inventorySlot)
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
	}
	
	public void UpdateForgeUI()
	{
		for (int i = 1; i <= 8; i++)
		{
			InventorySlot inventorySlot = null;
			Image itemSprite = null;

			switch (i)
			{
				case 1:
					inventorySlot = forge.CommonSlot1;
					itemSprite = item1Image;
					break;
				case 2:
					inventorySlot = forge.CommonSlot2;
					itemSprite = item2Image;
					break;
				case 3:
					inventorySlot = forge.CommonSlot3;
					itemSprite = item3Image;
					break;
				case 4:
					inventorySlot = forge.CommonSlot4;
					itemSprite = item4Image;
					break;
				case 5:
					inventorySlot = forge.CommonSlot5;
					itemSprite = item5Image;
					break;
				case 6:
					inventorySlot = forge.CommonSlot6;
					itemSprite = item6Image;
					break;
				case 7:
					inventorySlot = forge.CommonSlot7;
					itemSprite = item7Image;
					break;
				case 8:
					inventorySlot = forge.CommonSlot8;
					itemSprite = item8Image;
					break;
			}
			
			SetImageWithAlpha(item1Image, GetItemImageForge(forge.CommonSlot1));
			SetImageWithAlpha(item2Image, GetItemImageForge(forge.CommonSlot2));
			SetImageWithAlpha(item3Image, GetItemImageForge(forge.CommonSlot3));
			SetImageWithAlpha(item4Image, GetItemImageForge(forge.CommonSlot4));
			SetImageWithAlpha(item5Image, GetItemImageForge(forge.CommonSlot5));
			SetImageWithAlpha(item6Image, GetItemImageForge(forge.CommonSlot6));
			SetImageWithAlpha(item7Image, GetItemImageForge(forge.CommonSlot7));
			SetImageWithAlpha(item8Image, GetItemImageForge(forge.CommonSlot8));

			void SetImageWithAlpha(Image image, Sprite sprite)
			{
				if (image != null)
				{
					image.sprite = sprite;
					image.color = sprite != null ? Color.white : new Color(0, 0, 0, 0); // Устанавливаем прозрачность, если спрайт отсутствует
				}
			}
		}
	}
	
	public Button GetButtonForItemForge(GameObject itemGameObject, Forge forge)
    {
        if (itemGameObject == forge.CommonSlot1.itemGameObject)
            return itemButton1;
        else if (itemGameObject == forge.CommonSlot2.itemGameObject)
            return itemButton2;
        else if (itemGameObject == forge.CommonSlot3.itemGameObject)
            return itemButton3;
        else if (itemGameObject == forge.CommonSlot4.itemGameObject)
            return itemButton4;
        else if (itemGameObject == forge.CommonSlot5.itemGameObject)
            return itemButton5;
        else if (itemGameObject == forge.CommonSlot6.itemGameObject)
            return itemButton6;
        else if (itemGameObject == forge.CommonSlot7.itemGameObject)
            return itemButton7;
        else if (itemGameObject == forge.CommonSlot8.itemGameObject)
            return itemButton8;

        return null;
    }
	
	private void OpenCharacterInv(CharacterData characterData)
	{
		if (characterData != null)
		{
			CharacterInvButton.onClick.RemoveAllListeners();
			CharacterInvButtonObj.SetActive(false);
			if(characterInventoryUI.isCharacterInventoryPanelOpen)
			{
				characterInventoryUI.CloseCharacterInventoryUI();
			}
			characterSelectedData.characterData = characterData;
			
			characterInventoryUI.OpenInventoryOnClick();

			//if(craft.craftPanel)
			//{
			//	craft.craftPanel.SetActive(false);
			//}
		}
	}
	
	public void Demobilization()
	{
		if(crafterData.forge.cellData.characterData.usableAP > 0)
		{
			crafterData.forge.cellData.characterData.currentCell.forge.Population += 100;
			crafterData.forge.cellData.characterData.currentCell.forge.PopulationAP += 1;
			BoxCollider2D collider = crafterData.forge.cellData.characterData.currentCell.GetComponent<BoxCollider2D>();
			collider.enabled = true;
			characterSelection.DeselectCharacter();
			Destroy(crafterData.forge.cellData.characterData.thisCharacter);
			characterInventoryUI.CloseCharacterInventoryUI();
			DemobilizeButtonObj.SetActive(false);
		}
	}
}
