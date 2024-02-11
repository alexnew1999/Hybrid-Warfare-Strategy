using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class MashineFactoryUI : MonoBehaviour
{
	public GameObject mashineFactoryPanel;
	public MashineFactory mashineFactory;
	public Image mashineFactoryImageRenderer;
	public TextMeshProUGUI ownerPlayerIDText;
	public ItemSelection itemSelection;
	public CrafterData crafterData;
	public TextMeshProUGUI PopulationText;
	public TextMeshProUGUI PopulationAP;
	public CharacterInventoryUI characterInventoryUI;
	public CharacterSelection characterSelection;
	public CharacterSelectedData characterSelectedData;
	public MashineFactorySelectedData mashineFactorySelectedData;
	public SelectedCharacterInfo selectedCharacterInfo;
	public EndTurnConfirmation endTurnConfirmation;
	
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
	
	public Image unit1Image;
	public Image unit2Image;
	public Image vehicle1Image;
	public Image vehicle2Image;
	
	public Button characterButton1;
	public Button characterButton2;
	public Button vehicleButton1;
	public Button vehicleButton2;
	
	public Button ManufactureButton;
	public Button UpgradeButton;
	
	public GameObject GoOutButtonObj;
	public GameObject CharacterInvButtonObj;
	public Button GoOutButton;
	public Button CharacterInvButton;
	public Button DemobilizeButton;
	public GameObject DemobilizeButtonObj;
	
	public bool isMashineFactoryPanelOpen = false;
	
	public ItemsList itemsList;

    private void Start()
    {
		mashineFactoryPanel.SetActive(false);
		selectedItemPanel.SetActive(false);
		GoOutButtonObj.SetActive(false);
		CharacterInvButtonObj.SetActive(false);
		DemobilizeButtonObj.SetActive(false);
	}

	public void OpenMashineFactoryInventory(MashineFactory selectedMashineFactory)
	{
		if (selectedMashineFactory != null && selectedMashineFactory.ownerPlayerID == endTurnConfirmation.ownerPlayerID)
		{
			ownerPlayerIDText.text = "OwnerPlayerID: " + selectedMashineFactory.ownerPlayerID;
			PopulationAP.text = "Workers AP: " + selectedMashineFactory.PopulationAP;
			PopulationText.text = "Workers: " + selectedMashineFactory.Population;
			
			crafterData.mashineCrafter = selectedMashineFactory.HasWorkers();
			crafterData.mashineCraftZone = selectedMashineFactory.cellData;
			crafterData.mashineFactory = selectedMashineFactory;
			
			RemoveListeners();

			OpenMashineFactoryUI(selectedMashineFactory);
			selectedMashineFactory.isMashineFactoryInventoryOpen = true;
						
			itemButton1.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot1));
			itemButton2.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot2));
			itemButton3.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot3));
			itemButton4.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot4));
			itemButton5.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot5));
			itemButton6.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot6));
			itemButton7.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot7));
			itemButton8.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot8));
			characterButton1.onClick.AddListener(() => CharacterClickHandlerMashineFactory(selectedMashineFactory.CharacterCommonSlot1));
			characterButton2.onClick.AddListener(() => CharacterClickHandlerMashineFactory(selectedMashineFactory.CharacterCommonSlot2));
			
			vehicleButton1.onClick.AddListener(() => VehicleClickHandler(selectedMashineFactory.VehicleCommonSlot1));
			vehicleButton2.onClick.AddListener(() => VehicleClickHandler(selectedMashineFactory.VehicleCommonSlot2));
		}
	}
	
	public void OpenMashineFactoryInventoryOnClick()
	{
		MashineFactory selectedMashineFactory = null;
		selectedMashineFactory = mashineFactorySelectedData.mashineFactory;
		if (selectedMashineFactory != null && selectedMashineFactory.ownerPlayerID == endTurnConfirmation.ownerPlayerID)
		{
			ownerPlayerIDText.text = "OwnerPlayerID: " + selectedMashineFactory.ownerPlayerID;
			PopulationAP.text = "Workers AP: " + selectedMashineFactory.PopulationAP;
			PopulationText.text = "Workers: " + selectedMashineFactory.Population;

			RemoveListeners();

			OpenMashineFactoryUI(selectedMashineFactory);
			selectedMashineFactory.isMashineFactoryInventoryOpen = true;
						
			itemButton1.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot1));
			itemButton2.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot2));
			itemButton3.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot3));
			itemButton4.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot4));
			itemButton5.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot5));
			itemButton6.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot6));
			itemButton7.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot7));
			itemButton8.onClick.AddListener(() => ItemClickHandlerMashineFactory(selectedMashineFactory.CommonSlot8));
			
			characterButton1.onClick.AddListener(() => CharacterClickHandlerMashineFactory(selectedMashineFactory.CharacterCommonSlot1));
			characterButton2.onClick.AddListener(() => CharacterClickHandlerMashineFactory(selectedMashineFactory.CharacterCommonSlot2));
			
			vehicleButton1.onClick.AddListener(() => VehicleClickHandler(selectedMashineFactory.VehicleCommonSlot1));
			vehicleButton2.onClick.AddListener(() => VehicleClickHandler(selectedMashineFactory.VehicleCommonSlot2));
		}
	}

	private Image GetItemImageForSlotMashineFactory(int slotIndex)
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

	public void OpenMashineFactoryUI(MashineFactory selectedMashineFactory)
	{
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.CityOrForgeInvButtonObj.SetActive(false);
		}
		crafterData.mashineCrafter = selectedMashineFactory.HasWorkers();
		crafterData.mashineCraftZone = selectedMashineFactory.cellData;
		crafterData.mashineFactory = selectedMashineFactory;
		if(itemSelection.itemIsSelected)
		{
			itemSelection.ButtonPanel.SetActive(true);
		}
		isMashineFactoryPanelOpen = true;
		mashineFactoryPanel.SetActive(true);

		SetImageWithAlpha(item1Image, GetItemImageMashineFactory(selectedMashineFactory.CommonSlot1));
		SetImageWithAlpha(item2Image, GetItemImageMashineFactory(selectedMashineFactory.CommonSlot2));
		SetImageWithAlpha(item3Image, GetItemImageMashineFactory(selectedMashineFactory.CommonSlot3));
		SetImageWithAlpha(item4Image, GetItemImageMashineFactory(selectedMashineFactory.CommonSlot4));
		SetImageWithAlpha(item5Image, GetItemImageMashineFactory(selectedMashineFactory.CommonSlot5));
		SetImageWithAlpha(item6Image, GetItemImageMashineFactory(selectedMashineFactory.CommonSlot6));
		SetImageWithAlpha(item7Image, GetItemImageMashineFactory(selectedMashineFactory.CommonSlot7));
		SetImageWithAlpha(item8Image, GetItemImageMashineFactory(selectedMashineFactory.CommonSlot8));
		
		SetImageWithAlpha(unit1Image, GetCharacterImageFactory(selectedMashineFactory.CharacterCommonSlot1));
		SetImageWithAlpha(unit2Image, GetCharacterImageFactory(selectedMashineFactory.CharacterCommonSlot2));
		SetImageWithAlpha(vehicle1Image, GetVehicleImageFactory(selectedMashineFactory.VehicleCommonSlot1));
		SetImageWithAlpha(vehicle2Image, GetVehicleImageFactory(selectedMashineFactory.VehicleCommonSlot2));

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
					inventorySlot = selectedMashineFactory.CommonSlot1;
					itemSprite = item1Image;
					if(selectedMashineFactory.CommonSlot1.itemGameObject != null)
					{
						ItemObject itemObject = selectedMashineFactory.CommonSlot1.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedMashineFactory.CommonSlot2;
					itemSprite = item2Image;
					if(selectedMashineFactory.CommonSlot2.itemGameObject != null)
					{
						ItemObject itemObject = selectedMashineFactory.CommonSlot2.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedMashineFactory.CommonSlot3;
					itemSprite = item3Image;
					if(selectedMashineFactory.CommonSlot3.itemGameObject != null)
					{
						ItemObject itemObject = selectedMashineFactory.CommonSlot3.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedMashineFactory.CommonSlot4;
					itemSprite = item4Image;
					if(selectedMashineFactory.CommonSlot4.itemGameObject != null)
					{
						ItemObject itemObject = selectedMashineFactory.CommonSlot4.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedMashineFactory.CommonSlot5;
					itemSprite = item5Image;
					if(selectedMashineFactory.CommonSlot5.itemGameObject != null)
					{
						ItemObject itemObject = selectedMashineFactory.CommonSlot5.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedMashineFactory.CommonSlot6;
					itemSprite = item6Image;
					if(selectedMashineFactory.CommonSlot6.itemGameObject != null)
					{
						ItemObject itemObject = selectedMashineFactory.CommonSlot6.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedMashineFactory.CommonSlot7;
					itemSprite = item7Image;
					if(selectedMashineFactory.CommonSlot7.itemGameObject != null)
					{
						ItemObject itemObject = selectedMashineFactory.CommonSlot7.itemGameObject.GetComponent<ItemObject>();
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
					inventorySlot = selectedMashineFactory.CommonSlot8;
					itemSprite = item8Image;
					if(selectedMashineFactory.CommonSlot8.itemGameObject != null)
					{
						ItemObject itemObject = selectedMashineFactory.CommonSlot8.itemGameObject.GetComponent<ItemObject>();
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
		selectedMashineFactory.UpdateItemSpritesMashineFactory();
	}
	
	public void UpdateItemSpritesMashineFactory()
	{
		MashineFactory mashineFactory = FindObjectsOfType<MashineFactory>().FirstOrDefault(inventory => inventory.isMashineFactoryInventoryOpen);
		if (mashineFactory!= null)
		{
			SetImageWithAlpha(item1Image, GetItemImageMashineFactory(mashineFactory.CommonSlot1));
			SetImageWithAlpha(item2Image, GetItemImageMashineFactory(mashineFactory.CommonSlot2));
			SetImageWithAlpha(item3Image, GetItemImageMashineFactory(mashineFactory.CommonSlot3));
			SetImageWithAlpha(item4Image, GetItemImageMashineFactory(mashineFactory.CommonSlot4));
			SetImageWithAlpha(item5Image, GetItemImageMashineFactory(mashineFactory.CommonSlot5));
			SetImageWithAlpha(item6Image, GetItemImageMashineFactory(mashineFactory.CommonSlot6));
			SetImageWithAlpha(item7Image, GetItemImageMashineFactory(mashineFactory.CommonSlot7));
			SetImageWithAlpha(item8Image, GetItemImageMashineFactory(mashineFactory.CommonSlot8));
		
			SetImageWithAlpha(unit1Image, GetCharacterImageFactory(mashineFactory.CharacterCommonSlot1));
			SetImageWithAlpha(unit2Image, GetCharacterImageFactory(mashineFactory.CharacterCommonSlot2));
			SetImageWithAlpha(vehicle1Image, GetVehicleImageFactory(mashineFactory.VehicleCommonSlot1));
			SetImageWithAlpha(vehicle2Image, GetVehicleImageFactory(mashineFactory.VehicleCommonSlot2));

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
					inventorySlot = mashineFactory.CommonSlot1;
					itemSprite = item1Image;
					if(mashineFactory.CommonSlot1.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot1.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item1Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item1Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot1.itemGameObject == null)
					{
						item1Text.text = "";
					}
					break;
				case 2:
					inventorySlot = mashineFactory.CommonSlot2;
					itemSprite = item2Image;
					if(mashineFactory.CommonSlot2.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot2.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item2Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item2Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot2.itemGameObject == null)
					{
						item2Text.text = "";
					}
					break;
				case 3:
					inventorySlot = mashineFactory.CommonSlot3;
					itemSprite = item3Image;
					if(mashineFactory.CommonSlot3.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot3.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item3Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item3Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot3.itemGameObject == null)
					{
						item3Text.text = "";
					}
					break;
				case 4:
					inventorySlot = mashineFactory.CommonSlot4;
					itemSprite = item4Image;
					if(mashineFactory.CommonSlot4.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot4.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item4Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item4Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot4.itemGameObject == null)
					{
						item4Text.text = "";
					}
					break;
				case 5:
					inventorySlot = mashineFactory.CommonSlot5;
					itemSprite = item5Image;
					if(mashineFactory.CommonSlot5.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot5.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item5Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item5Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot5.itemGameObject == null)
					{
						item5Text.text = "";
					}
					break;
				case 6:
					inventorySlot = mashineFactory.CommonSlot6;
					itemSprite = item6Image;
					if(mashineFactory.CommonSlot6.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot6.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item6Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item6Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot6.itemGameObject == null)
					{
						item6Text.text = "";
					}
					break;
				case 7:
					inventorySlot = mashineFactory.CommonSlot7;
					itemSprite = item7Image;
					if(mashineFactory.CommonSlot7.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot7.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item7Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item7Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot7.itemGameObject == null)
					{
						item7Text.text = "";
					}
					break;
				case 8:
					inventorySlot = mashineFactory.CommonSlot8;
					itemSprite = item8Image;
					if(mashineFactory.CommonSlot8.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot8.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item8Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item8Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot8.itemGameObject == null)
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
	
	public void UpdateItemSpritesCertainMashineFactory(MashineFactory mashineFactory)
	{
		if (mashineFactory!= null)
		{
			SetImageWithAlpha(item1Image, GetItemImageMashineFactory(mashineFactory.CommonSlot1));
			SetImageWithAlpha(item2Image, GetItemImageMashineFactory(mashineFactory.CommonSlot2));
			SetImageWithAlpha(item3Image, GetItemImageMashineFactory(mashineFactory.CommonSlot3));
			SetImageWithAlpha(item4Image, GetItemImageMashineFactory(mashineFactory.CommonSlot4));
			SetImageWithAlpha(item5Image, GetItemImageMashineFactory(mashineFactory.CommonSlot5));
			SetImageWithAlpha(item6Image, GetItemImageMashineFactory(mashineFactory.CommonSlot6));
			SetImageWithAlpha(item7Image, GetItemImageMashineFactory(mashineFactory.CommonSlot7));
			SetImageWithAlpha(item8Image, GetItemImageMashineFactory(mashineFactory.CommonSlot8));
			
			SetImageWithAlpha(unit1Image, GetCharacterImageFactory(mashineFactory.CharacterCommonSlot1));
			SetImageWithAlpha(unit2Image, GetCharacterImageFactory(mashineFactory.CharacterCommonSlot2));
			SetImageWithAlpha(vehicle1Image, GetVehicleImageFactory(mashineFactory.VehicleCommonSlot1));
			SetImageWithAlpha(vehicle2Image, GetVehicleImageFactory(mashineFactory.VehicleCommonSlot2));

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
					inventorySlot = mashineFactory.CommonSlot1;
					itemSprite = item1Image;
					if(mashineFactory.CommonSlot1.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot1.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item1Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item1Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot1.itemGameObject == null)
					{
						item1Text.text = "";
					}
					break;
				case 2:
					inventorySlot = mashineFactory.CommonSlot2;
					itemSprite = item2Image;
					if(mashineFactory.CommonSlot2.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot2.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item2Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item2Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot2.itemGameObject == null)
					{
						item2Text.text = "";
					}
					break;
				case 3:
					inventorySlot = mashineFactory.CommonSlot3;
					itemSprite = item3Image;
					if(mashineFactory.CommonSlot3.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot3.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item3Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item3Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot3.itemGameObject == null)
					{
						item3Text.text = "";
					}
					break;
				case 4:
					inventorySlot = mashineFactory.CommonSlot4;
					itemSprite = item4Image;
					if(mashineFactory.CommonSlot4.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot4.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item4Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item4Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot4.itemGameObject == null)
					{
						item4Text.text = "";
					}
					break;
				case 5:
					inventorySlot = mashineFactory.CommonSlot5;
					itemSprite = item5Image;
					if(mashineFactory.CommonSlot5.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot5.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item5Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item5Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot5.itemGameObject == null)
					{
						item5Text.text = "";
					}
					break;
				case 6:
					inventorySlot = mashineFactory.CommonSlot6;
					itemSprite = item6Image;
					if(mashineFactory.CommonSlot6.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot6.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item6Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item6Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot6.itemGameObject == null)
					{
						item6Text.text = "";
					}
					break;
				case 7:
					inventorySlot = mashineFactory.CommonSlot7;
					itemSprite = item7Image;
					if(mashineFactory.CommonSlot7.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot7.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item7Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item7Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot7.itemGameObject == null)
					{
						item7Text.text = "";
					}
					break;
				case 8:
					inventorySlot = mashineFactory.CommonSlot8;
					itemSprite = item8Image;
					if(mashineFactory.CommonSlot8.itemGameObject != null)
					{
						ItemObject itemObject = mashineFactory.CommonSlot8.itemGameObject.GetComponent<ItemObject>();
						if(itemObject.quantity > 1)
						{
							item8Text.text = itemObject.quantity.ToString();
						}
						else
						{
							item8Text.text = "";
						}
					}
					else if(mashineFactory.CommonSlot8.itemGameObject == null)
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
	
	public void CloseInventoryUIMashineFactory()
	{
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.CityOrForgeInvButtonObj.SetActive(true);
			characterInventoryUI.CityOrForgeInvButtonText.text = "FactoryInv";
		}
		// Сбрасываем InvOpen в false для всех городов, у которых оно true
		MashineFactory[] allMashineFactorys = FindObjectsOfType<MashineFactory>();
		foreach (MashineFactory mashineFactory1 in allMashineFactorys)
		{
			if (mashineFactory1.isMashineFactoryInventoryOpen)
			{
				mashineFactory1.isMashineFactoryInventoryOpen = false;
			}
		}
		
		selectedItemPanel.SetActive(false);
		itemNameText.text = "";
		
		ownerPlayerIDText.text = "";
		
		item1Image.sprite = null;
		item2Image.sprite = null;
		item3Image.sprite = null;
		item4Image.sprite = null;
		item5Image.sprite = null;
		item6Image.sprite = null;
		item7Image.sprite = null;
		item8Image.sprite = null;
		
		unit1Image.sprite = null;
		unit2Image.sprite = null;
		vehicle1Image.sprite = null;
		vehicle2Image.sprite = null;
		
		item1Text.text = "";
		item2Text.text = "";
		item3Text.text = "";
		item4Text.text = "";
		item5Text.text = "";
		item6Text.text = "";
		item7Text.text = "";
		item8Text.text = "";
		
		crafterData.mashineCrafter = null;
		crafterData.mashineCraftZone = null;
		crafterData.mashineFactory = null;

		// Закрываем инвентарь
		isMashineFactoryPanelOpen = false;
		mashineFactoryPanel.SetActive(false);
		itemSelection.isFlashing = false;
		itemSelection.itemIsSelected = false;
		itemSelection.ButtonPanel.SetActive(false);
		itemSelection.ItemSeparationObj.SetActive(false);
		itemSelection.SplitButtonObj.SetActive(false);
		
		GoOutButtonObj.SetActive(false);
		CharacterInvButtonObj.SetActive(false);
		
		InventorySlot[] allSlots = FindObjectsOfType<InventorySlot>();

		// Проходимся по каждому слоту и устанавливаем isOccupied в false
		foreach (InventorySlot slot in allSlots)
		{
			slot.isSelected = false;
		}
	}
		
	private void OnExitButtonClick()
	{
		CloseInventoryUIMashineFactory();
	}
	
	private void VehicleClickHandler(VehicleSlot vehicleSlot)
	{
		if (vehicleSlot != null && vehicleSlot.vehicleObject != null)
		{
			GameObject vehicleObject = vehicleSlot.vehicleObject;
			
			VehicleData vehicleData = vehicleObject.GetComponent<VehicleData>();
			
			GoOutButtonObj.SetActive(true);
			GoOutButton.onClick.AddListener(() => GoOutVehicle(vehicleSlot, vehicleData));
			//CharacterInvButtonObj.SetActive(true);
			//CharacterInvButton.onClick.AddListener(() => OpenCharacterInv(vehicleData));
			//itemSelection.SelectVehicle(vehicleObject);
			
			//if(craft.craftPanel)
			//{
			//	craft.craftPanel.SetActive(false);
			//}
			if(characterInventoryUI.isCharacterInventoryPanelOpen)
			{
				characterInventoryUI.CloseCharacterInventoryUI();
			}
		}
	}
	
	private void CharacterClickHandlerMashineFactory(CharacterSlot characterSlot)
	{
		if (characterSlot != null && characterSlot.characterObject != null)
		{
			GameObject characterObject = characterSlot.characterObject;
			CharacterData characterData = characterObject.GetComponent<CharacterData>();
			GoOutButtonObj.SetActive(true);
			GoOutButton.onClick.AddListener(() => GoOut(characterSlot, characterData));
			CharacterInvButtonObj.SetActive(true);
			CharacterInvButton.onClick.AddListener(() => OpenCharacterInv(characterData));
			itemSelection.SelectCharacter(characterObject);
			
			//if(craft.craftPanel)
			//{
			//	craft.craftPanel.SetActive(false);
			//}
			if(characterInventoryUI.isCharacterInventoryPanelOpen)
			{
				characterInventoryUI.CloseCharacterInventoryUI();
			}
		}
	}
	
	private void GoOut(CharacterSlot characterSlot, CharacterData characterData)
	{
		if (characterSlot != null && characterData != null)
		{
			GoOutButtonObj.SetActive(false);
			CharacterInvButtonObj.SetActive(false);
			CharacterVisibility characterVisibility = characterData.thisCharacter.GetComponent<CharacterVisibility>();
			characterVisibility.SetVisibile();

			characterSelection.SelectCharacter(characterSlot.characterObject);

			selectedCharacterInfo.CharacterInfoFromInventory(characterData);
			characterSelectedData.characterData = characterData;

			CloseInventoryUIMashineFactory();
			//if(craft.craftPanel)
			//{
			//	craft.craftPanel.SetActive(false);
			//}
			if(characterInventoryUI.isCharacterInventoryPanelOpen)
			{
				characterInventoryUI.CloseCharacterInventoryUI();
			}
		}
	}
	
	private void GoOutVehicle(VehicleSlot vehicleSlot, VehicleData vehicleData)
	{
		if (vehicleSlot != null && vehicleData != null)
		{
			GoOutButtonObj.SetActive(false);
			CharacterInvButtonObj.SetActive(false);
			//CharacterVisibility characterVisibility = characterData.thisCharacter.GetComponent<CharacterVisibility>();
			//characterVisibility.SetVisibile();

			characterSelection.SelectVehicle(vehicleSlot.vehicleObject);

			//selectedCharacterInfo.CharacterInfoFromInventory(characterData);
			//characterSelectedData.characterData = characterData;

			CloseInventoryUIMashineFactory();
			//if(craft.craftPanel)
			//{
			//	craft.craftPanel.SetActive(false);
			//}
			if(characterInventoryUI.isCharacterInventoryPanelOpen)
			{
				characterInventoryUI.CloseCharacterInventoryUI();
			}
		}
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
	
	private void ItemClickHandlerMashineFactory(InventorySlot inventorySlot)
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
	
	private Sprite GetItemImageMashineFactory(InventorySlot inventorySlot)
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
	
	private Sprite GetCharacterImageFactory(CharacterSlot characterSlot)
	{
		if (characterSlot != null && characterSlot.characterObject != null)
		{
			CharacterData characterData = characterSlot.characterObject.GetComponent<CharacterData>();

			if (characterData != null && characterData.characterImage != null)
			{
				return characterData.characterImage;
			}
		}
		return null;
	}
	
	private Sprite GetVehicleImageFactory(VehicleSlot vehicleSlot)
	{
		if (vehicleSlot != null && vehicleSlot.vehicleObject != null)
		{
			VehicleData vehicleData = vehicleSlot.vehicleObject.GetComponent<VehicleData>();

			if (vehicleData != null && vehicleData.vehicleImage != null)
			{
				return vehicleData.vehicleImage;
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
	
	public void UpdateMashineFactoryUI()
	{
		for (int i = 1; i <= 8; i++)
		{
			InventorySlot inventorySlot = null;
			Image itemSprite = null;

			switch (i)
			{
				case 1:
					inventorySlot = mashineFactory.CommonSlot1;
					itemSprite = item1Image;
					break;
				case 2:
					inventorySlot = mashineFactory.CommonSlot2;
					itemSprite = item2Image;
					break;
				case 3:
					inventorySlot = mashineFactory.CommonSlot3;
					itemSprite = item3Image;
					break;
				case 4:
					inventorySlot = mashineFactory.CommonSlot4;
					itemSprite = item4Image;
					break;
				case 5:
					inventorySlot = mashineFactory.CommonSlot5;
					itemSprite = item5Image;
					break;
				case 6:
					inventorySlot = mashineFactory.CommonSlot6;
					itemSprite = item6Image;
					break;
				case 7:
					inventorySlot = mashineFactory.CommonSlot7;
					itemSprite = item7Image;
					break;
				case 8:
					inventorySlot = mashineFactory.CommonSlot8;
					itemSprite = item8Image;
					break;
			}
			
			SetImageWithAlpha(item1Image, GetItemImageMashineFactory(mashineFactory.CommonSlot1));
			SetImageWithAlpha(item2Image, GetItemImageMashineFactory(mashineFactory.CommonSlot2));
			SetImageWithAlpha(item3Image, GetItemImageMashineFactory(mashineFactory.CommonSlot3));
			SetImageWithAlpha(item4Image, GetItemImageMashineFactory(mashineFactory.CommonSlot4));
			SetImageWithAlpha(item5Image, GetItemImageMashineFactory(mashineFactory.CommonSlot5));
			SetImageWithAlpha(item6Image, GetItemImageMashineFactory(mashineFactory.CommonSlot6));
			SetImageWithAlpha(item7Image, GetItemImageMashineFactory(mashineFactory.CommonSlot7));
			SetImageWithAlpha(item8Image, GetItemImageMashineFactory(mashineFactory.CommonSlot8));

			void SetImageWithAlpha(Image image, Sprite sprite)
			{
				if (image != null)
				{
					image.sprite = sprite;
					image.color = sprite != null ? Color.white : new Color(0, 0, 0, 0); // Устанавливаем прозрачность, если спрайт отсутствует
				}
			}
		}
		for (int i = 1; i <= 4; i++)
		{
			CharacterSlot characterSlot = null;
			VehicleSlot vehicleSlot = null;
			Image characterSprite = null;

			switch (i)
			{
				case 1:
					characterSlot = mashineFactory.CharacterCommonSlot1;
					characterSprite = unit1Image;
					break;
				case 2:
					characterSlot = mashineFactory.CharacterCommonSlot2;
					characterSprite = unit2Image;
					break;
				case 3:
					vehicleSlot = mashineFactory.VehicleCommonSlot1;
					characterSprite = vehicle1Image;
					break;
				case 4:
					vehicleSlot = mashineFactory.VehicleCommonSlot2;
					characterSprite = vehicle2Image;
					break;
			}
			
			SetImageWithAlpha(unit1Image, GetCharacterImageFactory(mashineFactory.CharacterCommonSlot1));
			SetImageWithAlpha(unit2Image, GetCharacterImageFactory(mashineFactory.CharacterCommonSlot2));
			SetImageWithAlpha(vehicle1Image, GetVehicleImageFactory(mashineFactory.VehicleCommonSlot1));
			SetImageWithAlpha(vehicle2Image, GetVehicleImageFactory(mashineFactory.VehicleCommonSlot2));

			void SetImageWithAlpha(Image image, Sprite sprite)
			{
				if (image != null)
				{
					image.sprite = sprite;
					image.color = sprite != null ? Color.white : new Color(0, 0, 0, 0);
				}
			}
		}
	}
	
	public Button GetButtonForItemMashineFactory(GameObject itemGameObject, MashineFactory mashineFactory)
    {
        if (itemGameObject == mashineFactory.CommonSlot1.itemGameObject)
            return itemButton1;
        else if (itemGameObject == mashineFactory.CommonSlot2.itemGameObject)
            return itemButton2;
        else if (itemGameObject == mashineFactory.CommonSlot3.itemGameObject)
            return itemButton3;
        else if (itemGameObject == mashineFactory.CommonSlot4.itemGameObject)
            return itemButton4;
        else if (itemGameObject == mashineFactory.CommonSlot5.itemGameObject)
            return itemButton5;
        else if (itemGameObject == mashineFactory.CommonSlot6.itemGameObject)
            return itemButton6;
        else if (itemGameObject == mashineFactory.CommonSlot7.itemGameObject)
            return itemButton7;
        else if (itemGameObject == mashineFactory.CommonSlot8.itemGameObject)
            return itemButton8;

        return null;
    }
	
	public Button GetButtonForCharacterMashineFactory(GameObject characterObject, MashineFactory mashineFactory)
    {
        if (characterObject == mashineFactory.CharacterCommonSlot1.characterObject)
            return characterButton1;
        else if (characterObject == mashineFactory.CharacterCommonSlot2.characterObject)
            return characterButton2;

        return null;
    }
}