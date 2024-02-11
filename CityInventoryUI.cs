using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class CityInventoryUI : MonoBehaviour
{
    public GameObject cityInventoryPanel;
	public GameObject cityInfoPanel;
	public GameObject resourceTradePanel;
	public GameObject technologyReserchPanel;
	public GameObject ResearchPanel;
	public GameObject PopulationPanel;
    private SmallCity selectedCity;
    private CityManager cityManager;
	private CityInventory cityInventory;
	public Craft craft;
	public Mobilization mobilization;
	public Image cityImageRenderer; // Для спрайта города
	public TextMeshProUGUI cityNameText;
	public TextMeshProUGUI PopulationText;
	public TextMeshProUGUI ownerPlayerIDText;
	public TextMeshProUGUI PopulationAP;
	public TextMeshProUGUI Currency;
	public SelectedCharacterInfo selectedCharacterInfo;
	public ItemSelection itemSelection;
	public CharacterInventoryUI characterInventoryUI;
	public CitySelectedData citySelectedData;
	public EndTurnConfirmation endTurnConfirmation;
	public CharacterSelectedData characterSelectedData;
	public CharacterSelection characterSelection;
	public TechnologyReserch technologyReserch;
	public PopulationByAge populationByAge;
	
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
	public Image unit1Image;
	public Image unit2Image;
	public Image unit3Image;
	public Image unit4Image;
	
	public GameObject selectedItemPanel;
	public TextMeshProUGUI itemNameText;
	
	public Button exitButton;
	public Button characterButton1;
	public Button characterButton2;
	public Button characterButton3;
	public Button characterButton4;
	
	public Button itemButton1;
	public Button itemButton2;
	public Button itemButton3;
	public Button itemButton4;
	public Button itemButton5;
	public Button itemButton6;
	public Button itemButton7;
	public Button itemButton8;
	
	public Button CraftButton;
	public Button ResourceButton;
	public Button TradeButton;
	public Button BuildButton;
	
	public Button DemobilizeButton;
	public Button GoOutButton;
	public Button CharacterInvButton;
	public GameObject GoOutButtonObj;
	public GameObject CharacterInvButtonObj;
	public GameObject DemobilizeButtonObj;

    public bool isCityInventoryPanelOpen = false;
	
	public ItemsList itemsList;
	
	Dictionary<int, CityInventory> cityInventoryDict = new Dictionary<int, CityInventory>();

    private void Start()
    {
		cityInventoryPanel.SetActive(false);
		selectedItemPanel.SetActive(false);
		GoOutButtonObj.SetActive(false);
		CharacterInvButtonObj.SetActive(false);
		DemobilizeButtonObj.SetActive(false);
		ResearchPanel.SetActive(false);
		PopulationPanel.SetActive(false);
	}

    public void InitiateUI()
    {
		itemsList = FindObjectOfType<ItemsList>();
        // Найдем и сохраним ссылку на менеджер городов
        cityManager = FindObjectOfType<CityManager>();
		
		// Добавьте обработчик нажатия на кнопку "Exit"
		exitButton.onClick.AddListener(OnExitButtonClick);
		
		CraftButton.onClick.AddListener(OpenCraftWindow);
		
		CityInventory[] cityInventories = FindObjectsOfType<CityInventory>();
		foreach (CityInventory cityInventory in cityInventories)
		{
			// Предполагается, что CityInventory имеет поле cityID
			cityInventoryDict[cityInventory.cityID] = cityInventory;
		}
    }

	private void Update()
	{
		// Если нажата клавиша "I"
		if (Input.GetKeyDown(KeyCode.I))
		{
			SmallCity selectedCity = null;
			selectedCity = citySelectedData.smallCity;

			if (selectedCity != null && selectedCity.ownerPlayerID == endTurnConfirmation.ownerPlayerID)
			{
				if(characterSelectedData.characterData != null)
				{
					if(characterSelectedData.characterData.currentCell != selectedCity.currentCell)
					{
						characterSelectedData.characterData = null;
					}	
				}
				SpriteRenderer citySpriteRenderer = selectedCity.GetComponent<SpriteRenderer>();
				cityImageRenderer.sprite = citySpriteRenderer.sprite;
				SmallCity smallCity = selectedCity.GetComponent<SmallCity>();
				cityNameText.text = smallCity.cityName;
				ownerPlayerIDText.text = "OwnerPlayerID: " + smallCity.ownerPlayerID;
				PopulationAP.text = "PopulationAP: " + smallCity.PopulationAP;
				PopulationText.text = "Population: " + smallCity.PopulationWorkable;
				Currency.text = "Currency: " + smallCity.playerScript.Currency;
					
				mobilization.ReActivateMobilization(selectedCity);
				RemoveListeners();

				CityInventory cityInventory = selectedCity.cityInventory;
				OpenInventoryUI(cityInventory);
				selectedCity.InvOpen = true;
				cityInventory.isCityInventoryOpen = true;
				
				characterButton1.onClick.AddListener(() => CharacterClickHandler(cityInventory.CharacterCommonSlot1));
				characterButton2.onClick.AddListener(() => CharacterClickHandler(cityInventory.CharacterCommonSlot2));
				characterButton3.onClick.AddListener(() => CharacterClickHandler(cityInventory.CharacterCommonSlot3));
				characterButton4.onClick.AddListener(() => CharacterClickHandler(cityInventory.CharacterCommonSlot4));
					
				itemButton1.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot1));
				itemButton2.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot2));
				itemButton3.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot3));
				itemButton4.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot4));
				itemButton5.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot5));
				itemButton6.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot6));
				itemButton7.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot7));
				itemButton8.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot8));
					
				selectedCity = null;
				cityInfoPanel.SetActive(false);
			}
		}
	}
	
	public void OpenCityInventoryOnClick()
	{
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.CityOrForgeInvButtonObj.SetActive(false);
		}
		SmallCity selectedCity = null;
		selectedCity = citySelectedData.smallCity;
		
		if (selectedCity != null && selectedCity.ownerPlayerID == endTurnConfirmation.ownerPlayerID)
		{
			SpriteRenderer citySpriteRenderer = selectedCity.GetComponent<SpriteRenderer>();
			cityImageRenderer.sprite = citySpriteRenderer.sprite;
			SmallCity smallCity = selectedCity.GetComponent<SmallCity>();
			cityNameText.text = smallCity.cityName;
			ownerPlayerIDText.text = "OwnerPlayerID: " + smallCity.ownerPlayerID;
			PopulationAP.text = "PopulationAP: " + smallCity.PopulationAP;
			PopulationText.text = "Population: " + smallCity.Population;
			Currency.text = "Currency: " + smallCity.playerScript.Currency;
			
			mobilization.ReActivateMobilization(selectedCity);
			RemoveListeners();

			CityInventory cityInventory = selectedCity.cityInventory;
			OpenInventoryUI(cityInventory);
			selectedCity.InvOpen = true;
			cityInventory.isCityInventoryOpen = true;
				
			characterButton1.onClick.AddListener(() => CharacterClickHandler(cityInventory.CharacterCommonSlot1));
			characterButton2.onClick.AddListener(() => CharacterClickHandler(cityInventory.CharacterCommonSlot2));
			characterButton3.onClick.AddListener(() => CharacterClickHandler(cityInventory.CharacterCommonSlot3));
			characterButton4.onClick.AddListener(() => CharacterClickHandler(cityInventory.CharacterCommonSlot4));
				
			itemButton1.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot1));
			itemButton2.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot2));
			itemButton3.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot3));
			itemButton4.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot4));
			itemButton5.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot5));
			itemButton6.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot6));
			itemButton7.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot7));
			itemButton8.onClick.AddListener(() => ItemClickHandler(cityInventory.CommonSlot8));
				
			selectedCity = null;
			cityInfoPanel.SetActive(false);
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

	public void OpenInventoryUI(CityInventory cityInventory)
	{
		if (cityInventory != null)
		{
			technologyReserch.chosenCity = cityInventory.smallCity;
			isCityInventoryPanelOpen = true;
			cityInventoryPanel.SetActive(true);
			
			if(itemSelection.itemIsSelected)
			{
				itemSelection.ButtonPanel.SetActive(true);
				
			}
			
			cityImageRenderer.sprite = cityInventory.cityImageRenderer.sprite;
			mobilization.ReActivateMobilization(cityInventory.cityImageRenderer.gameObject.GetComponent<SmallCity>());
				
			SetImageWithAlpha(item1Image, GetItemImage(cityInventory.CommonSlot1));
			SetImageWithAlpha(item2Image, GetItemImage(cityInventory.CommonSlot2));
			SetImageWithAlpha(item3Image, GetItemImage(cityInventory.CommonSlot3));
			SetImageWithAlpha(item4Image, GetItemImage(cityInventory.CommonSlot4));
			SetImageWithAlpha(item5Image, GetItemImage(cityInventory.CommonSlot5));
			SetImageWithAlpha(item6Image, GetItemImage(cityInventory.CommonSlot6));
			SetImageWithAlpha(item7Image, GetItemImage(cityInventory.CommonSlot7));
			SetImageWithAlpha(item8Image, GetItemImage(cityInventory.CommonSlot8));
			
			SetImageWithAlpha(unit1Image, GetCharacterImage(cityInventory.CharacterCommonSlot1));
			SetImageWithAlpha(unit2Image, GetCharacterImage(cityInventory.CharacterCommonSlot2));
			SetImageWithAlpha(unit3Image, GetCharacterImage(cityInventory.CharacterCommonSlot3));
			SetImageWithAlpha(unit4Image, GetCharacterImage(cityInventory.CharacterCommonSlot4));

			// Добавим метод для установки изображения с учетом альфа-канала
			void SetImageWithAlpha(Image image, Sprite sprite)
			{
				if (image != null)
				{
					image.sprite = sprite;
					image.color = sprite != null ? Color.white : new Color(0, 0, 0, 0); // Устанавливаем прозрачность, если спрайт отсутствует
				}
			}

			cityImageRenderer.sprite = cityInventory.cityImageRenderer != null ? cityInventory.cityImageRenderer.sprite : null;

			for (int i = 1; i <= 8; i++)
			{
				InventorySlot inventorySlot = null;
				Image itemSprite = null;

				switch (i)
				{
					case 1:
						inventorySlot = cityInventory.CommonSlot1;
						itemSprite = item1Image;
						if(cityInventory.CommonSlot1.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot1.itemGameObject.GetComponent<ItemObject>();
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
						inventorySlot = cityInventory.CommonSlot2;
						itemSprite = item2Image;
						if(cityInventory.CommonSlot2.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot2.itemGameObject.GetComponent<ItemObject>();
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
						inventorySlot = cityInventory.CommonSlot3;
						itemSprite = item3Image;
						if(cityInventory.CommonSlot3.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot3.itemGameObject.GetComponent<ItemObject>();
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
						inventorySlot = cityInventory.CommonSlot4;
						itemSprite = item4Image;
						if(cityInventory.CommonSlot4.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot4.itemGameObject.GetComponent<ItemObject>();
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
						inventorySlot = cityInventory.CommonSlot5;
						itemSprite = item5Image;
						if(cityInventory.CommonSlot5.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot5.itemGameObject.GetComponent<ItemObject>();
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
						inventorySlot = cityInventory.CommonSlot6;
						itemSprite = item6Image;
						if(cityInventory.CommonSlot6.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot6.itemGameObject.GetComponent<ItemObject>();
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
						inventorySlot = cityInventory.CommonSlot7;
						itemSprite = item7Image;
						if(cityInventory.CommonSlot7.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot7.itemGameObject.GetComponent<ItemObject>();
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
						inventorySlot = cityInventory.CommonSlot8;
						itemSprite = item8Image;
						if(cityInventory.CommonSlot8.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot8.itemGameObject.GetComponent<ItemObject>();
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

			for (int i = 1; i <= 4; i++)
			{
				CharacterSlot characterSlot = null;
				Image characterSprite = null;

				switch (i)
				{
					case 1:
						characterSlot = cityInventory.CharacterCommonSlot1;
						characterSprite = unit1Image;
						break;
					case 2:
						characterSlot = cityInventory.CharacterCommonSlot2;
						characterSprite = unit2Image;
						break;
					case 3:
						characterSlot = cityInventory.CharacterCommonSlot3;
						characterSprite = unit3Image;
						break;
					case 4:
						characterSlot = cityInventory.CharacterCommonSlot4;
						characterSprite = unit4Image;
						break;
				}

				if (characterSlot != null)
				{
					GameObject characterObject = characterSlot.characterObject;

					if (characterObject != null)
					{
						CharacterData characterData = characterObject.GetComponent<CharacterData>();

						if (characterData != null)
						{
							Sprite characterImage = characterData.characterImage;
						}
					}
				}
			}
		}
		cityInventory.UpdateCharacterSprites();
		cityInventory.UpdateItemSprites();
	}
	
	public void UpdateItemSprites()
	{
		CityInventory selectedInventory = FindObjectsOfType<CityInventory>().FirstOrDefault(inventory => inventory.isCityInventoryOpen);
		if (selectedInventory!= null)
		{
			SetImageWithAlpha(item1Image, GetItemImage(selectedInventory.CommonSlot1));
			SetImageWithAlpha(item2Image, GetItemImage(selectedInventory.CommonSlot2));
			SetImageWithAlpha(item3Image, GetItemImage(selectedInventory.CommonSlot3));
			SetImageWithAlpha(item4Image, GetItemImage(selectedInventory.CommonSlot4));
			SetImageWithAlpha(item5Image, GetItemImage(selectedInventory.CommonSlot5));
			SetImageWithAlpha(item6Image, GetItemImage(selectedInventory.CommonSlot6));
			SetImageWithAlpha(item7Image, GetItemImage(selectedInventory.CommonSlot7));
			SetImageWithAlpha(item8Image, GetItemImage(selectedInventory.CommonSlot8));

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
						break;
					case 2:
						inventorySlot = selectedInventory.CommonSlot2;
						itemSprite = item2Image;
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
						break;
					case 3:
						inventorySlot = selectedInventory.CommonSlot3;
						itemSprite = item3Image;
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
						break;
					case 4:
						inventorySlot = selectedInventory.CommonSlot4;
						itemSprite = item4Image;
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
						break;
					case 5:
						inventorySlot = selectedInventory.CommonSlot5;
						itemSprite = item5Image;
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
						break;
					case 6:
						inventorySlot = selectedInventory.CommonSlot6;
						itemSprite = item6Image;
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
						break;
					case 7:
						inventorySlot = selectedInventory.CommonSlot7;
						itemSprite = item7Image;
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
						break;
					case 8:
						inventorySlot = selectedInventory.CommonSlot8;
						itemSprite = item8Image;
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
	
	public void UpdateCertianCityItemSprites(CityInventory selectedInventory)
	{
		if (selectedInventory!= null)
		{
			SetImageWithAlpha(item1Image, GetItemImage(selectedInventory.CommonSlot1));
			SetImageWithAlpha(item2Image, GetItemImage(selectedInventory.CommonSlot2));
			SetImageWithAlpha(item3Image, GetItemImage(selectedInventory.CommonSlot3));
			SetImageWithAlpha(item4Image, GetItemImage(selectedInventory.CommonSlot4));
			SetImageWithAlpha(item5Image, GetItemImage(selectedInventory.CommonSlot5));
			SetImageWithAlpha(item6Image, GetItemImage(selectedInventory.CommonSlot6));
			SetImageWithAlpha(item7Image, GetItemImage(selectedInventory.CommonSlot7));
			SetImageWithAlpha(item8Image, GetItemImage(selectedInventory.CommonSlot8));

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
						break;
					case 2:
						inventorySlot = selectedInventory.CommonSlot2;
						itemSprite = item2Image;
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
						break;
					case 3:
						inventorySlot = selectedInventory.CommonSlot3;
						itemSprite = item3Image;
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
						break;
					case 4:
						inventorySlot = selectedInventory.CommonSlot4;
						itemSprite = item4Image;
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
						break;
					case 5:
						inventorySlot = selectedInventory.CommonSlot5;
						itemSprite = item5Image;
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
						break;
					case 6:
						inventorySlot = selectedInventory.CommonSlot6;
						itemSprite = item6Image;
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
						break;
					case 7:
						inventorySlot = selectedInventory.CommonSlot7;
						itemSprite = item7Image;
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
						break;
					case 8:
						inventorySlot = selectedInventory.CommonSlot8;
						itemSprite = item8Image;
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
	
	public void CloseInventoryUI()
	{
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.CityOrForgeInvButtonObj.SetActive(true);
			characterInventoryUI.CityOrForgeInvButtonText.text = "CityInv";
		}
		resourceTradePanel.SetActive(false);
		
		// Сбрасываем InvOpen в false для всех городов, у которых оно true
		SmallCity[] allCities = FindObjectsOfType<SmallCity>();
		foreach (SmallCity city in allCities)
		{
			if (city.InvOpen)
			{
				city.InvOpen = false;
				city.isSelected = false;
				city.cityInventory.isCityInventoryOpen = false;
			}
		}
		
		selectedItemPanel.SetActive(false);
		itemNameText.text = "";

		unit1Image.sprite = null;
		unit2Image.sprite = null;
		unit3Image.sprite = null;
		unit4Image.sprite = null;
		
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
		
		CityInventory[] cityInventories = FindObjectsOfType<CityInventory>();

		foreach (CityInventory cityInventory in cityInventories)
		{
			cityInventory.UpdateCharacterSprites();
		}

		// Закрываем инвентарь
		isCityInventoryPanelOpen = false;
		cityInventoryPanel.SetActive(false);
		craft.craftPanel.SetActive(false);
		itemSelection.isFlashing = false;
		itemSelection.isFlashingCharacter = false;
		itemSelection.itemIsSelected = false;
		itemSelection.ButtonPanel.SetActive(false);
		itemSelection.ItemSeparationObj.SetActive(false);
		itemSelection.SplitButtonObj.SetActive(false);
		GoOutButtonObj.SetActive(false);
		CharacterInvButtonObj.SetActive(false);
		DemobilizeButtonObj.SetActive(false);
		
		InventorySlot[] allSlots = FindObjectsOfType<InventorySlot>();

		// Проходимся по каждому слоту и устанавливаем isOccupied в false
		foreach (InventorySlot slot in allSlots)
		{
			slot.isSelected = false;
		}
		citySelectedData.smallCity = null;
	}
		
	private void OnExitButtonClick()
	{
		mobilization.ReActivateMobilization(selectedCity);
		CloseInventoryUI();
	}
	
	private void OpenCraftWindow()
	{
		craft.craftPanel.SetActive(true);
		if(characterInventoryUI.isCharacterInventoryPanelOpen)
		{
			characterInventoryUI.characterInventoryPanel.SetActive(false);
			characterInventoryUI.isCharacterInventoryPanelOpen = false;
		}
		if(citySelectedData.smallCity != null)
		{
			if(citySelectedData.smallCity.playerScript.InfantryArmorResearch1 == 1)
			{
				craft.SSh39Research.SetActive(true);
			}
			if(citySelectedData.smallCity.playerScript.InfantryArmorResearch2 == 1)
			{
				craft.Vest6B2Research.SetActive(true);
			}
			if(citySelectedData.smallCity.playerScript.InfantryArmorResearch2 == 1)
			{
				craft.TacticalVestResearch.SetActive(true);
			}
			if(citySelectedData.smallCity.playerScript.InfantryClothesResearch1 == 1)
			{
				craft.CamoBalaclavaResearch.SetActive(true);
			}
			if(citySelectedData.smallCity.playerScript.InfantryClothesResearch2 == 1)
			{
				craft.CamoJacketResearch.SetActive(true);
			}
			if(citySelectedData.smallCity.playerScript.InfantryClothesResearch3 == 1)
			{
				craft.ShemaghResearch.SetActive(true);
			}
		}
	}
	
	public CityInventory FindCityInventory(int cityID)
	{
		CityInventory[] cityInventories = FindObjectsOfType<CityInventory>();

		foreach (CityInventory cityInventory in cityInventories)
		{
			if (cityInventory.cityID == cityID)
			{
				return cityInventory;
			}
		}

		return null;
	}
	
	private void CharacterClickHandler(CharacterSlot characterSlot)
	{
		if (characterSlot != null && characterSlot.characterObject != null)
		{
			GameObject characterObject = characterSlot.characterObject;
			
			CharacterData characterData = characterObject.GetComponent<CharacterData>();
			characterSelectedData.characterData = characterData;
			GoOutButtonObj.SetActive(true);
			GoOutButton.onClick.AddListener(() => GoOut(characterSlot, characterData));
			CharacterInvButtonObj.SetActive(true);
			CharacterInvButton.onClick.AddListener(() => OpenCharacterInv(characterData));
			itemSelection.SelectCharacter(characterObject);
			//DemobilizeButton.onClick.AddListener(() => Demobilization(characterData));
			if(craft.craftPanel)
			{
				craft.craftPanel.SetActive(false);
			}
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

			CloseInventoryUI();
			if(craft.craftPanel)
			{
				craft.craftPanel.SetActive(false);
			}
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

			if(craft.craftPanel)
			{
				craft.craftPanel.SetActive(false);
			}
		}
	}
	
	private void ItemClickHandler(InventorySlot inventorySlot)
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
	
	private Sprite GetCharacterImage(CharacterSlot characterSlot)
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
	
	private void RemoveListeners()
	{
		characterButton1.onClick.RemoveAllListeners();
		characterButton2.onClick.RemoveAllListeners();
		characterButton3.onClick.RemoveAllListeners();
		characterButton4.onClick.RemoveAllListeners();
		
		itemButton1.onClick.RemoveAllListeners();
		itemButton2.onClick.RemoveAllListeners();
		itemButton3.onClick.RemoveAllListeners();
		itemButton4.onClick.RemoveAllListeners();
		itemButton5.onClick.RemoveAllListeners();
		itemButton6.onClick.RemoveAllListeners();
		itemButton7.onClick.RemoveAllListeners();
		itemButton8.onClick.RemoveAllListeners();
		
		GoOutButton.onClick.RemoveAllListeners();
		CharacterInvButton.onClick.RemoveAllListeners();
	}
	
	public void UpdateCityUI()
	{
		for (int i = 1; i <= 8; i++)
		{
			InventorySlot inventorySlot = null;
			Image itemSprite = null;

			switch (i)
				{
					case 1:
						inventorySlot = cityInventory.CommonSlot1;
						itemSprite = item1Image;
						if(cityInventory.CommonSlot1.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot1.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item1Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item1Text.text = null;
							}
						}
						else if(cityInventory.CommonSlot1.itemGameObject == null)
						{
							item1Text.text = null;
						}
						break;
					case 2:
						inventorySlot = cityInventory.CommonSlot2;
						itemSprite = item2Image;
						if(cityInventory.CommonSlot2.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot2.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item2Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item2Text.text = null;
							}
						}
						else if(cityInventory.CommonSlot2.itemGameObject == null)
						{
							item2Text.text = null;
						}
						break;
					case 3:
						inventorySlot = cityInventory.CommonSlot3;
						itemSprite = item3Image;
						if(cityInventory.CommonSlot3.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot3.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item3Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item3Text.text = null;
							}
						}
						else if(cityInventory.CommonSlot3.itemGameObject == null)
						{
							item3Text.text = null;
						}
						break;
					case 4:
						inventorySlot = cityInventory.CommonSlot4;
						itemSprite = item4Image;
						if(cityInventory.CommonSlot4.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot4.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item4Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item4Text.text = null;
							}
						}
						else if(cityInventory.CommonSlot4.itemGameObject == null)
						{
							item4Text.text = null;
						}
						break;
					case 5:
						inventorySlot = cityInventory.CommonSlot5;
						itemSprite = item5Image;
						if(cityInventory.CommonSlot5.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot5.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item5Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item5Text.text = null;
							}
						}
						else if(cityInventory.CommonSlot5.itemGameObject == null)
						{
							item5Text.text = null;
						}
						break;
					case 6:
						inventorySlot = cityInventory.CommonSlot6;
						itemSprite = item6Image;
						if(cityInventory.CommonSlot6.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot6.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item6Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item6Text.text = null;
							}
						}
						else if(cityInventory.CommonSlot6.itemGameObject == null)
						{
							item6Text.text = null;
						}
						break;
					case 7:
						inventorySlot = cityInventory.CommonSlot7;
						itemSprite = item7Image;
						if(cityInventory.CommonSlot7.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot7.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item7Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item7Text.text = null;
							}
						}
						else if(cityInventory.CommonSlot7.itemGameObject == null)
						{
							item7Text.text = null;
						}
						break;
					case 8:
						inventorySlot = cityInventory.CommonSlot8;
						itemSprite = item8Image;
						if(cityInventory.CommonSlot8.itemGameObject != null)
						{
							ItemObject itemObject = cityInventory.CommonSlot8.itemGameObject.GetComponent<ItemObject>();
							if(itemObject.quantity > 1)
							{
								item8Text.text = itemObject.quantity.ToString();
							}
							else
							{
								item8Text.text = null;
							}
						}
						else if(cityInventory.CommonSlot8.itemGameObject == null)
						{
							item8Text.text = null;
						}
						break;
				}
			
			SetImageWithAlpha(item1Image, GetItemImage(cityInventory.CommonSlot1));
			SetImageWithAlpha(item2Image, GetItemImage(cityInventory.CommonSlot2));
			SetImageWithAlpha(item3Image, GetItemImage(cityInventory.CommonSlot3));
			SetImageWithAlpha(item4Image, GetItemImage(cityInventory.CommonSlot4));
			SetImageWithAlpha(item5Image, GetItemImage(cityInventory.CommonSlot5));
			SetImageWithAlpha(item6Image, GetItemImage(cityInventory.CommonSlot6));
			SetImageWithAlpha(item7Image, GetItemImage(cityInventory.CommonSlot7));
			SetImageWithAlpha(item8Image, GetItemImage(cityInventory.CommonSlot8));

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
	
	public Button GetButtonForItem(GameObject itemGameObject, CityInventory cityInventory)
    {
        if (itemGameObject == cityInventory.CommonSlot1.itemGameObject)
            return itemButton1;
        else if (itemGameObject == cityInventory.CommonSlot2.itemGameObject)
            return itemButton2;
        else if (itemGameObject == cityInventory.CommonSlot3.itemGameObject)
            return itemButton3;
        else if (itemGameObject == cityInventory.CommonSlot4.itemGameObject)
            return itemButton4;
        else if (itemGameObject == cityInventory.CommonSlot5.itemGameObject)
            return itemButton5;
        else if (itemGameObject == cityInventory.CommonSlot6.itemGameObject)
            return itemButton6;
        else if (itemGameObject == cityInventory.CommonSlot7.itemGameObject)
            return itemButton7;
        else if (itemGameObject == cityInventory.CommonSlot8.itemGameObject)
            return itemButton8;

        return null;
    }
	
	public Button GetButtonForCharacter(GameObject CharacterGameObject, CityInventory cityInventory)
    {
        if (CharacterGameObject == cityInventory.CharacterCommonSlot1.characterObject)
            return characterButton1;
        else if (CharacterGameObject == cityInventory.CharacterCommonSlot2.characterObject)
            return characterButton2;
        else if (CharacterGameObject == cityInventory.CharacterCommonSlot3.characterObject)
            return characterButton3;
        else if (CharacterGameObject == cityInventory.CharacterCommonSlot4.characterObject)
            return characterButton4;

        return null;
    }
	
	public void OpenPopulationList()
	{
		populationByAge.OpenPopulationListFromScript(citySelectedData.smallCity);
	}
	
	//public void Demobilization(CharacterData characterData)
	//{
	//	if(characterData.usableAP > 0)
	//	{
	//		characterData.currentCell.forge.Population += 100;
	//		characterData.currentCell.forge.PopulationAP += 1;
	//		BoxCollider2D collider = characterData.currentCell.GetComponent<BoxCollider2D>();
	//		characterSelection.DeselectCharacter();
	//		Destroy(characterData.thisCharacter);
	//		characterInventoryUI.CloseCharacterInventoryUI();
	//		DemobilizeButtonObj.SetActive(true);
	//		DemobilizeButton.onClick.RemoveAllListeners();
	//	}
	//}
}