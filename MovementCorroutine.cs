using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class MovementCorroutine : MonoBehaviour
{
	public float moveSpeed = 5f;
	private List<Node> path;
	public Pathfinder pathfinder;
	private Vector2 targetPosition;
	public CharacterSelection characterSelection;
	public CharacterMovement characterMovement;
	public VehicleMovement vehicleMovement;
	public TextMeshProUGUI DebugInfoPanel;
	public GameObject DebugInfoPanelObj;
	public GameObject MovementGO;
	
	public void Execute(List<Node> path, Node startNode, CharacterData characterData, Node targetNode2)
	{
		characterSelection.ResetAllCellColors();
		characterSelection.RemoveAllTargetMarkers();
		StartCoroutine(MoveAlongPath(path, startNode, characterData, targetNode2));
		ResetGCost(path);
		characterData.currentNode = targetNode2;
		characterData.currentCell = targetNode2.cellData;
		if (!characterData.currentCell.IsOccupiedByCity)
		{
			characterData.currentCell.IsOccupied = true;
			characterData.currentCell.characterData = characterData;
			characterData.InCityInventory = false;
		}
		BoxCollider2D cellCollider = characterData.currentCell.GetComponent<BoxCollider2D>();
		cellCollider.enabled = false;
		if(characterData.usableMP == 0)
		{
			MovementGO.SetActive(false);
		}
	}
	
	public void ExecuteCity(SmallCity smallCity, GameObject characterObject, List<Node> path, SpriteRenderer spriteRenderer, CharacterVisibility characterVisibility)
	{
		characterSelection.ResetAllCellColors();
		characterSelection.RemoveAllTargetMarkers();
		MoveToCity(smallCity, characterObject, path, spriteRenderer, characterVisibility);
	}
	
	public void ExecuteMashineFactory(MashineFactory mashineFactory, GameObject characterObject, List<Node> path, SpriteRenderer spriteRenderer, CharacterVisibility characterVisibility)
	{
		characterSelection.ResetAllCellColors();
		characterSelection.RemoveAllTargetMarkers();
		MoveToMashineFactory(mashineFactory, characterObject, path, spriteRenderer, characterVisibility);
	}
	
    public IEnumerator MoveAlongPath(List<Node> path, Node startNode, CharacterData characterData, Node targetNode2)
    {
		if (characterData.characterSlot == null)
		{
			BoxCollider2D cellCollider = characterData.currentCell.GetComponent<BoxCollider2D>();
			cellCollider.enabled = true;
		}
		if (characterData.characterSlot != null)
		{
			CharacterVisibility characterVisibility = characterData.thisCharacter.GetComponent<CharacterVisibility>();
			if (characterData.characterSlot.characterObject != null)
			{
				characterData.characterSlot.isOccupied = false;
				characterData.characterSlot.characterObject = null;
			}
			
			if (characterData.characterSlot != null)
			{
				characterData.characterSlot = null;
			}
			characterVisibility.SetVisibile();
		}
		
		UpdateCharacterInfo(characterData);
		startNode = characterData.currentNode;
		
		foreach (Node targetNode in path)
		{
			Vector2 targetPosition = new Vector2(targetNode.transform.position.x, targetNode.transform.position.y);

			while ((Vector2)characterData.thisCharacter.GetComponent<Transform>().position != targetPosition)
			{
				characterData.thisCharacter.transform.position = Vector2.MoveTowards(characterData.thisCharacter.transform.position, targetPosition, moveSpeed * Time.deltaTime);
				yield return null;
			}
		}
    }
	
	public void MoveToCity(SmallCity smallCity, GameObject characterObject, List<Node> path, SpriteRenderer spriteRenderer, CharacterVisibility characterVisibility)
	{
		CityInventory cityInventory = smallCity.cityInventory;

		if (cityInventory != null)
		{
			int slotIndex = cityInventory.GetFreeCharacterObjectIndex();
			if (slotIndex != -1)
			{
				CharacterData characterData = characterObject.GetComponent<CharacterData>();
				if (characterData != null)
				{
					if (characterData.characterSlot != null)
					{
						if (characterData.characterSlot.characterObject != null)
						{
							characterData.characterSlot.isOccupied = false;
							characterData.characterSlot.characterObject = null;
						}
						if (characterData.characterSlot != null)
						{
							characterData.characterSlot = null;
						}
					}
					characterData.currentNode = smallCity.currentNode;
					characterData.currentCell = smallCity.currentCell;
					characterData.InCityInventory = true;
					if(smallCity.ownerPlayerID != characterData.ownerPlayerID)
					{
						smallCity.ownerPlayerID = characterData.ownerPlayerID;
						smallCity.playerScript = characterData.playerScript;
					}
					StartCoroutine(MoveTowards(path, targetPosition, moveSpeed, characterObject, smallCity.ThisCity, characterVisibility));
					
					ResetGCost(path);
					Node startNode = characterData.currentNode;
					UpdateCharacterInfo(characterData);
				}
				cityInventory.AddCharacterToCityInventory(characterObject, slotIndex);
			}
			else
			{
				if (!DebugInfoPanelObj.activeSelf)
				{
					DebugInfoPanelObj.SetActive(true);
				}
				DebugInfoPanel.text = "No available character slots in the city's inventory.";
			}
		}
	}
	
	public void MoveToMashineFactory(MashineFactory mashineFactory, GameObject characterObject, List<Node> path, SpriteRenderer spriteRenderer, CharacterVisibility characterVisibility)
	{
		int slotIndex = mashineFactory.GetFreeCharacterObjectIndexMashineFactory();
		if (slotIndex != -1)
		{
			CharacterData characterData = characterObject.GetComponent<CharacterData>();
			if (characterData != null)
			{
				if (characterData.characterSlot != null)
				{
					if (characterData.characterSlot.characterObject != null)
					{
						characterData.characterSlot.isOccupied = false;
						characterData.characterSlot.characterObject = null;
					}
					if (characterData.characterSlot != null)
					{
						characterData.characterSlot = null;
					}
				}
				characterData.currentNode = mashineFactory.cellData.node;
				characterData.currentCell = mashineFactory.cellData;
				//characterData.InCityInventory = true;
				if(mashineFactory.ownerPlayerID != characterData.ownerPlayerID)
				{
					mashineFactory.ownerPlayerID = characterData.ownerPlayerID;
				}
				StartCoroutine(MoveTowards(path, targetPosition, moveSpeed, characterObject, mashineFactory.mashineFactoryObject, characterVisibility));
				
				ResetGCost(path);
				Node startNode = characterData.currentNode;
				UpdateCharacterInfo(characterData);
			}
			mashineFactory.AddCharacterToMashineFactoryInventory(characterObject, slotIndex);
		}
		else
		{
			if (!DebugInfoPanelObj.activeSelf)
			{
				DebugInfoPanelObj.SetActive(true);
			}
			DebugInfoPanel.text = "No available character slots in the mashine factory.";
		}
	}
			
	public IEnumerator MoveTowards(List<Node> path, Vector2 targetPosition, float speed, GameObject characterObject, GameObject city,  CharacterVisibility characterVisibility)
    {
		Vector2 cityTransform = city.transform.position;
		Vector2 characterTransform = characterObject.transform.position;
		foreach (Node targetNode in path)
		{
			while ((Vector2)characterObject.GetComponent<Transform>().position != cityTransform)
			{
				characterObject.transform.position = Vector2.MoveTowards(characterObject.transform.position, cityTransform, speed * Time.deltaTime);
				yield return null;
			}
		}
		characterVisibility.SetNotVisibile();
    }

	private void ResetGCost(List<Node> path)
	{
		foreach (Node node in path)
		{
			node.gCost = 0;
		}
	}
	
	private void UpdateCharacterInfo(CharacterData characterData)
    {
        SelectedCharacterInfo characterInfoScript = FindObjectOfType<SelectedCharacterInfo>();

        if (characterInfoScript != null)
        {
            characterInfoScript.UpdateCharacterInfo(characterData);
        }
    }
	
	public void ExecuteVehicle(List<Node> path, Node startNode, VehicleData vehicleData, Node targetNode2)
	{
		characterSelection.ResetAllCellColors();
		characterSelection.RemoveAllTargetMarkers();
		StartCoroutine(MoveAlongPathVehicle(path, startNode, vehicleData, targetNode2));
		ResetGCost(path);
		vehicleData.currentNode = targetNode2;
		vehicleData.currentCell = targetNode2.cellData;
		if (!vehicleData.currentCell.IsOccupiedByCity)
		{
			vehicleData.currentCell.IsOccupied = true;
			vehicleData.currentCell.vehicleData = vehicleData;
		}
		BoxCollider2D cellCollider = vehicleData.currentCell.GetComponent<BoxCollider2D>();
		cellCollider.enabled = false;
	}
	
	public IEnumerator MoveAlongPathVehicle(List<Node> path, Node startNode, VehicleData vehicleData, Node targetNode2)
    {
		if (vehicleData.vehicleSlot == null)
		{
			BoxCollider2D cellCollider = vehicleData.currentCell.GetComponent<BoxCollider2D>();
			cellCollider.enabled = true;
		}
		if (vehicleData.vehicleSlot != null)
		{
			if (vehicleData.vehicleSlot.vehicleObject != null)
			{
				vehicleData.vehicleSlot.isOccupied = false;
				vehicleData.vehicleSlot.vehicleObject = null;
			}
			
			if (vehicleData.vehicleSlot != null)
			{
				vehicleData.vehicleSlot = null;
			}
		}
		
		UpdateVehicleInfo(vehicleData);
		startNode = vehicleData.currentNode;
		
		foreach (Node targetNode in path)
		{
			Vector2 targetPosition = new Vector2(targetNode.transform.position.x, targetNode.transform.position.y);

			while ((Vector2)vehicleData.thisVehicle.GetComponent<Transform>().position != targetPosition)
			{
				vehicleData.thisVehicle.transform.position = Vector2.MoveTowards(vehicleData.thisVehicle.transform.position, targetPosition, moveSpeed * Time.deltaTime);
				yield return null;
			}
		}
    }
	
	private void UpdateVehicleInfo(VehicleData vehicleData)
    {
        SelectedVehicleInfo vehicleInfoScript = FindObjectOfType<SelectedVehicleInfo>();

        if (vehicleInfoScript != null)
        {
            vehicleInfoScript.UpdateVehicleInfo(vehicleData);
        }
    }
	
	public void ExecuteMashineFactoryVechicle(MashineFactory mashineFactory, GameObject vehicleObject, List<Node> path, SpriteRenderer spriteRenderer)
	{
		characterSelection.ResetAllCellColors();
		characterSelection.RemoveAllTargetMarkers();
		MoveToMashineFactoryVehicle(mashineFactory, vehicleObject, path, spriteRenderer);
	}
	
	public void ExecuteToVehicle(CharacterData characterData, VehicleData vehicleData, List<Node> path, SpriteRenderer spriteRenderer)
	{
		characterSelection.ResetAllCellColors();
		characterSelection.RemoveAllTargetMarkers();
		MoveToVechicle(characterData, vehicleData, path, spriteRenderer);
	}
	
	public void MoveToMashineFactoryVehicle(MashineFactory mashineFactory, GameObject vehicleObject, List<Node> path, SpriteRenderer spriteRenderer)
	{
		int slotIndex = mashineFactory.GetFreeVehicleObjectIndexMashineFactory();
		if (slotIndex != -1)
		{
			VehicleData vehicleData = vehicleObject.GetComponent<VehicleData>();
			if (vehicleData != null)
			{
				if (vehicleData.vehicleSlot != null)
				{
					if (vehicleData.vehicleSlot.vehicleObject != null)
					{
						vehicleData.vehicleSlot.isOccupied = false;
						vehicleData.vehicleSlot.vehicleObject = null;
					}
					if (vehicleData.vehicleSlot != null)
					{
						vehicleData.vehicleSlot = null;
					}
				}
				vehicleData.currentNode = mashineFactory.cellData.node;
				vehicleData.currentCell = mashineFactory.cellData;
				//characterData.InCityInventory = true;
				if(mashineFactory.ownerPlayerID != vehicleData.ownerPlayerID)
				{
					mashineFactory.ownerPlayerID = vehicleData.ownerPlayerID;
				}
				StartCoroutine(MoveTowardsVehicle(path, targetPosition, moveSpeed, vehicleObject, mashineFactory.mashineFactoryObject));
				
				ResetGCost(path);
				Node startNode = vehicleData.currentNode;
				UpdateVehicleInfo(vehicleData);
			}
			mashineFactory.AddVehicleToMashineFactoryInventory(vehicleObject, slotIndex);
		}
		else
		{
			if (!DebugInfoPanelObj.activeSelf)
			{
				DebugInfoPanelObj.SetActive(true);
			}
			DebugInfoPanel.text = "No available vehicle slots in the mashine factory.";
		}
	}
	
	public void MoveToVechicle(CharacterData characterData, VehicleData vehicleData, List<Node> path, SpriteRenderer spriteRenderer)
	{
		if (vehicleData.vehicleInventory.HasFreeCharacterSlotVehicle(vehicleData.vehicleInventory))
		{
			int avaibleSlot = vehicleData.vehicleInventory.GetFreeCharacterObjectIndexVehicle();
			if (avaibleSlot != -1)
			{
				CharacterSlot characterSlot = vehicleData.vehicleInventory.GetCharacterSlotVehicle(avaibleSlot);
				if (characterSlot != null)
				{
					//characterSlot
				}
				StartCoroutine(MoveTowardsToVehicle(path, targetPosition, moveSpeed, vehicleData, characterData));
				
				ResetGCost(path);
				vehicleData.vehicleInventory.AddCharacterToVehicleInventory(vehicleData.thisVehicle, avaibleSlot);
				characterData.InVehicleInventory = true;
			}
		}
		else
		{
			if (!DebugInfoPanelObj.activeSelf)
			{
				DebugInfoPanelObj.SetActive(true);
			}
			DebugInfoPanel.text = "No available character slots in the vehicle.";
		}
	}
	
	public IEnumerator MoveTowardsVehicle(List<Node> path, Vector2 targetPosition, float speed, GameObject vehicleObject, GameObject mashineFactory)
    {
		Vector2 cityTransform = mashineFactory.transform.position;
		Vector2 vehicleTransform = vehicleObject.transform.position;
		foreach (Node targetNode in path)
		{
			while ((Vector2)vehicleObject.GetComponent<Transform>().position != cityTransform)
			{
				vehicleObject.transform.position = Vector2.MoveTowards(vehicleObject.transform.position, cityTransform, speed * Time.deltaTime);
				yield return null;
			}
		}
		BoxCollider2D boxCollider = vehicleObject.GetComponent<BoxCollider2D>();
		SpriteRenderer spriteRenderer = vehicleObject.GetComponent<SpriteRenderer>();
		boxCollider.enabled = false;
		spriteRenderer.enabled = false;  
    }
	
	public IEnumerator MoveTowardsToVehicle(List<Node> path, Vector2 targetPosition, float speed, VehicleData vehicleData, CharacterData characterData)
    {
		Vector2 vehicleTransform = vehicleData.thisVehicle.transform.position;
		Vector2 characterTransform = characterData.thisCharacter.transform.position;
		foreach (Node targetNode in path)
		{
			while ((Vector2)characterData.thisCharacter.GetComponent<Transform>().position != vehicleTransform)
			{
				characterData.thisCharacter.transform.position = Vector2.MoveTowards(characterData.thisCharacter.transform.position, vehicleTransform, speed * Time.deltaTime);
				yield return null;
			}
		}
		BoxCollider2D boxCollider = characterData.thisCharacter.GetComponent<BoxCollider2D>();
		SpriteRenderer spriteRenderer = characterData.thisCharacter.GetComponent<SpriteRenderer>();
		boxCollider.enabled = false;
		spriteRenderer.enabled = false;  
    }
}
