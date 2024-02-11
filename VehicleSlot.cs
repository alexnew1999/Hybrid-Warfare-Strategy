using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSlot : MonoBehaviour
{
    public GameObject vehicleObject;
    public bool isOccupied;
    public SlotType slotType;
	public MashineFactory mashineFactory;
	public bool isSelected;

    public void SetVehicleObject(GameObject vehicleObj)
    {
		vehicleObject = vehicleObj;
        isOccupied = true;

        VehicleData vehicleData = vehicleObj.GetComponent<VehicleData>();
        if (vehicleData != null)
        {
            vehicleData.SetVehicleSlot(this);
        }
    }

    // Метод для очистки слота
    public void ClearSlot()
    {
        vehicleObject = null;
        isOccupied = false;
    }
}