using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData : MonoBehaviour
{
	public bool InCityInventory = false;
	public bool InVehicleInventory = false;
    public bool isSelected = false;
	public bool InvOpen = false;
    public string characterName;
	public int ownerPlayerID;
    public int health = 20;
    public int maxhealth = 20;
    public int damage = 2;
	public int heavyDamage = 0;
	public int armorpierceDamage = 0;
	public int softDef = 0;
	public int hardDef = 0;
    public int characterID;
    public int usableMP = 3;
    public int maxMP = 3;
    public int usableAP = 1;
    public int maxAP = 1;
    public int attackRange = 1;
	public float attackChance = 90f;
	public float coverChance = 0f;
	public int transformTo = 12;
	public string characterType = "Mobilized";
    public Sprite characterImage;
    public CellData currentCell;
	public int globalIDcurrentCell;
	public Node currentNode;
	public CharacterInventory characterInventory;
	public string AmmoType = "None";
	public int ammoUsage = 0;
	public AIDefendDrone aIDefendDrone;
	public GameObject thisCharacter;
	public PlayerScript playerScript;
	public string spritePath = "Sprites/Units/Mobilized";

    private static int lastCharacterID = 0;
	public int GlobalID;
	public int WeaponSlotChanges = 0;
	public int AmmoSlotChanges = 0;
	public int HelmetSlotChanges = 0;
	public int VestSlotChanges = 0;
	public int ShirtSlotChanges = 0;
	
	public CharacterSlot characterSlot;

    public void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		
        if (spriteRenderer != null)
        {
            characterImage = spriteRenderer.sprite;
        }
		if (globalIDcurrentCell > 0)
		{
			CellData[] AllCellData = FindObjectsOfType<CellData>();
			foreach (CellData cell in AllCellData)
			{
				if(globalIDcurrentCell == cell.GlobalID)
				{
					currentCell = cell;
					currentNode = cell.node;
					currentCell.characterData = this;
					globalIDcurrentCell = 0;
				}
			}
		}
    }
	
	public void UpdateSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		characterImage = Resources.Load<Sprite>(spritePath);
		spriteRenderer.sprite = characterImage;
    }

    public void GenerateNewCharacterID()
    {
        // Устанавливаем новый CharacterID, инкрементируя последний использованный
        characterID = ++lastCharacterID;
    }
	
	public void SetCharacterSlot(CharacterSlot slot)
    {
        characterSlot = slot;
        // Другие действия, которые вы хотите выполнить при установке слота
    }
}