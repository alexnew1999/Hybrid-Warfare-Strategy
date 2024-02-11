using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterHoverInfo : MonoBehaviour
{
    public GameObject infoPanel; // Ссылка на всплывающее окно
	public TextMeshProUGUI characterNameText;
	public TextMeshProUGUI characterHealthText;
	public TextMeshProUGUI characterDamageText;
	public TextMeshProUGUI characterMPText;
	public TextMeshProUGUI characterAPText;
	public TextMeshProUGUI characterOwnerText;
	public TextMeshProUGUI characterCoverText;
	public Image characterImage;
	public Image characterWeapon;
	public Image characterAmmo;
	public Image characterHelmet;
	public Image characterVest;
	public Image characterShirt;
	public GameObject characterWeaponGO;
	public GameObject characterAmmoGO;
	public GameObject characterHelmetGO;
	public GameObject characterVestGO;
	public GameObject characterShirtGO;
    private SpriteRenderer SpriteRenderer;
	private Camera mainCamera;
	private CharacterData characterData;
	private TileInfoLoader tileInfoLoader;

    private void Start()
    {
		CharacterHoverInfoSlots slots = FindObjectOfType<CharacterHoverInfoSlots>();

        infoPanel = slots.infoPanel;
        characterNameText = slots.characterNameText;
        characterHealthText = slots.characterHealthText;
        characterDamageText = slots.characterDamageText;
        characterMPText = slots.characterMPText;
        characterAPText = slots.characterAPText;
		characterOwnerText = slots.characterOwnerText;
		characterCoverText = slots.characterCoverText;
        characterImage = slots.characterImage;
		characterWeapon = slots.characterWeapon;
		characterAmmo = slots.characterAmmo;
		characterHelmet = slots.characterHelmet;
		characterVest = slots.characterVest;
		characterShirt = slots.characterShirt;
		characterWeaponGO = slots.characterWeaponGO;
		characterAmmoGO = slots.characterAmmoGO;
		characterHelmetGO = slots.characterHelmetGO;
		characterVestGO = slots.characterVestGO;
		characterShirtGO = slots.characterShirtGO;
		
        mainCamera = Camera.main;
    
        // Находим скрипт CharacterData на этом же объекте или на объекте с персонажем
        characterData = GetComponent<CharacterData>();
    }

	void OnMouseEnter()
	{
		// Проверяем, что у нас есть данные персонажа и isSelected = false
		if (characterData != null && !characterData.isSelected)
		{
			// Отображаем информацию о персонаже в текстовом поле
			characterNameText.text = "Name: " + characterData.characterName;

			characterHealthText.text = "\nHealth: " + characterData.health;
			
			characterDamageText.text = "\nDamage: " + characterData.damage;
			
			characterMPText.text = "\nMP: " + characterData.usableMP;
		
			characterAPText.text = "\nAP: " + characterData.usableAP;
			
			characterOwnerText.text = "\nPlayer: " + characterData.ownerPlayerID;
			
			characterCoverText.text = "\nCover chns: " + characterData.coverChance;
			
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			characterImage.sprite = spriteRenderer.sprite;
			characterImage.gameObject.SetActive(true);
			
			if(characterData.characterInventory.weaponSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.weaponSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite weaponSprite = Resources.Load<Sprite>(spritePath);
				characterWeapon.sprite = weaponSprite;
				characterWeaponGO.SetActive(true);
			}
			if(characterData.characterInventory.ammoSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.ammoSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite ammoSprite = Resources.Load<Sprite>(spritePath);
				characterAmmo.sprite = ammoSprite;
				characterAmmoGO.SetActive(true);
			}
			if(characterData.characterInventory.helmetSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.helmetSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite helmetSprite = Resources.Load<Sprite>(spritePath);
				characterHelmet.sprite = helmetSprite;
				characterHelmetGO.SetActive(true);
			}
			if(characterData.characterInventory.vestSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.vestSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite vestSprite = Resources.Load<Sprite>(spritePath);
				characterVest.sprite = vestSprite;
				characterVestGO.SetActive(true);
			}
			if(characterData.characterInventory.shirtSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.shirtSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite shirtSprite = Resources.Load<Sprite>(spritePath);
				characterShirt.sprite = shirtSprite;
				characterShirtGO.SetActive(true);
			}
		
			// Включаем всплывающую панель
			infoPanel.SetActive(true);
			tileInfoLoader = characterData.currentCell.GetComponent<TileInfoLoader>();
			if(tileInfoLoader != null)
			{
				tileInfoLoader.ActivateInfoTile();
			}
		}
	}

	void OnMouseExit()
	{
		// Очищаем текстовое поле
		characterNameText.text = "";

		characterHealthText.text = "";
		
		characterDamageText.text = "";

		characterMPText.text = "";
		
		characterAPText.text = "";
		
		characterOwnerText.text = "";
			
		characterCoverText.text = "";
		
		characterWeapon.sprite = null;
		characterWeaponGO.SetActive(false);
		characterAmmo.sprite = null;
		characterAmmoGO.SetActive(false);
		characterHelmet.sprite = null;
		characterHelmetGO.SetActive(false);
		characterVest.sprite = null;
		characterVestGO.SetActive(false);
		characterShirt.sprite = null;
		characterShirtGO.SetActive(false);
		
		// Скрываем фото персонажа
		characterImage.gameObject.SetActive(false);
		
		// Выключаем всплывающую панель
		infoPanel.SetActive(false);
		if(tileInfoLoader != null)
		{
			tileInfoLoader.DectivateInfoTile();
			tileInfoLoader = null;
		}
	}
	
	public void UpdateHoverInfo()
    {
    // Получите информацию о персонаже, на которого указывает мышь в данный момент
    CharacterData characterData = GetCharacterDataUnderMouse();

		if (characterData != null)
		{
        // Обновляем информацию о персонаже
			characterNameText.text = "Name: " + characterData.characterName;
			characterHealthText.text = "\nHealth: " + characterData.health;
			characterDamageText.text = "\nDamage: " + characterData.damage;
			characterMPText.text = "\nMP: " + characterData.usableMP;
			characterAPText.text = "\nAP: " + characterData.usableAP;
			characterOwnerText.text = "\nPlayer: " + characterData.ownerPlayerID;
			characterCoverText.text = "\nCover chns: " + characterData.coverChance;
			
			if(characterData.characterInventory.weaponSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.weaponSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite weaponSprite = Resources.Load<Sprite>(spritePath);
				characterWeapon.sprite = weaponSprite;
				characterWeaponGO.SetActive(true);
			}
			if(characterData.characterInventory.ammoSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.ammoSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite ammoSprite = Resources.Load<Sprite>(spritePath);
				characterAmmo.sprite = ammoSprite;
				characterAmmoGO.SetActive(true);
			}
			if(characterData.characterInventory.helmetSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.helmetSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite helmetSprite = Resources.Load<Sprite>(spritePath);
				characterHelmet.sprite = helmetSprite;
				characterHelmetGO.SetActive(true);
			}
			if(characterData.characterInventory.vestSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.vestSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite vestSprite = Resources.Load<Sprite>(spritePath);
				characterVest.sprite = vestSprite;
				characterVestGO.SetActive(true);
			}
			if(characterData.characterInventory.shirtSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.shirtSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite shirtSprite = Resources.Load<Sprite>(spritePath);
				characterShirt.sprite = shirtSprite;
				characterShirtGO.SetActive(true);
			}
		}
    }
	
	private CharacterData GetCharacterDataUnderMouse()
	{
		// Получите позицию мыши в мировых координатах
		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// Пускаем луч к точке нажатия мыши и получаем информацию о столкновении
		RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, LayerMask.GetMask("Units"));

		if (hit.collider != null)
		{
			GameObject hitObject = hit.collider.gameObject;
			CharacterData characterData = hitObject.GetComponent<CharacterData>();
			return characterData;
		}

		return null; // Если мышь не указывает на персонажа, возвращаем null
	}
	
	public void CharacterInfoActivate()
	{
		if (characterData != null && !characterData.isSelected)
		{
			// Отображаем информацию о персонаже в текстовом поле
			characterNameText.text = "Name: " + characterData.characterName;

			characterHealthText.text = "\nHealth: " + characterData.health;
			
			characterDamageText.text = "\nDamage: " + characterData.damage;
			
			characterMPText.text = "\nMP: " + characterData.usableMP;
		
			characterAPText.text = "\nAP: " + characterData.usableAP;
			
			characterOwnerText.text = "\nPlayer: " + characterData.ownerPlayerID;
			
			characterCoverText.text = "\nCover chns: " + characterData.coverChance;
			
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			characterImage.sprite = spriteRenderer.sprite;
			characterImage.gameObject.SetActive(true);
			
			if(characterData.characterInventory.weaponSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.weaponSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite weaponSprite = Resources.Load<Sprite>(spritePath);
				characterWeapon.sprite = weaponSprite;
				characterWeaponGO.SetActive(true);
			}
			if(characterData.characterInventory.ammoSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.ammoSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite ammoSprite = Resources.Load<Sprite>(spritePath);
				characterAmmo.sprite = ammoSprite;
				characterAmmoGO.SetActive(true);
			}
			if(characterData.characterInventory.helmetSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.helmetSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite helmetSprite = Resources.Load<Sprite>(spritePath);
				characterHelmet.sprite = helmetSprite;
				characterHelmetGO.SetActive(true);
			}
			if(characterData.characterInventory.vestSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.vestSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite vestSprite = Resources.Load<Sprite>(spritePath);
				characterVest.sprite = vestSprite;
				characterVestGO.SetActive(true);
			}
			if(characterData.characterInventory.shirtSlot.itemGameObject != null)
			{
				ItemObject itemObject = characterData.characterInventory.shirtSlot.itemGameObject.GetComponent<ItemObject>();
				string spritePath = itemObject.SpritePath;
				Sprite shirtSprite = Resources.Load<Sprite>(spritePath);
				characterShirt.sprite = shirtSprite;
				characterShirtGO.SetActive(true);
			}
		
			// Включаем всплывающую панель
			infoPanel.SetActive(true);
			tileInfoLoader = characterData.currentCell.GetComponent<TileInfoLoader>();
			if(tileInfoLoader != null)
			{
				tileInfoLoader.ActivateInfoTile();
			}
		}
	}
	
	public void CharacterInfoDeactivate()
	{
		characterNameText.text = "";

		characterHealthText.text = "";
		
		characterDamageText.text = "";

		characterMPText.text = "";
		
		characterAPText.text = "";
		
		characterOwnerText.text = "";
			
		characterCoverText.text = "";
		
		characterWeapon.sprite = null;
		characterWeaponGO.SetActive(false);
		characterAmmo.sprite = null;
		characterAmmoGO.SetActive(false);
		characterHelmet.sprite = null;
		characterHelmetGO.SetActive(false);
		characterVest.sprite = null;
		characterVestGO.SetActive(false);
		characterShirt.sprite = null;
		characterShirtGO.SetActive(false);
		
		// Скрываем фото персонажа
		characterImage.gameObject.SetActive(false);
		
		// Выключаем всплывающую панель
		infoPanel.SetActive(false);
		if(tileInfoLoader != null)
		{
			tileInfoLoader.DectivateInfoTile();
			tileInfoLoader = null;
		}
	}
}
