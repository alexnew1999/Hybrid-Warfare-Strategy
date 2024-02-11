using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSlot : MonoBehaviour
{
    public GameObject characterObject;
    public bool isOccupied;
    public SlotType slotType;
    public CityInventory cityInventory;
	public MashineFactory mashineFactory;
	public VehicleInventory vehicleInventory;
	public bool isSelected;

    public void SetCharacterObject(GameObject characterObj)
    {
        characterObject = characterObj;
        isOccupied = true;

        CharacterData characterData = characterObj.GetComponent<CharacterData>();
        if (characterData != null)
        {
            characterData.SetCharacterSlot(this);
        }
    }

    public void ClearSlot()
    {
        characterObject = null;
        isOccupied = false;
    }
}