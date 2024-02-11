using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    private GameObject selectedCharacter;
	private GameObject selectedVehicle;
    private CharacterMovement selectedCharacterMovement;
	private VehicleMovement selectedVehicleMovement;
    private CharacterAttack selectedCharacterAttack;
	private VehicleAttack selectedVehicleAttack;
    private CharacterData selectedCharacterData;
	private VehicleData selectedVehicleData;
	private SpriteRenderer characterSpriteRenderer;
	private SpriteRenderer vehicleSpriteRenderer;
	private bool isFlashing = false;
	private bool isFlashingVehicle = false;
	private List<CellData> cellsInRadius;
	public Pathfinder pathfinder;
	public float minAlpha = 0.3f;
	public float maxAlpha = 1f;
	public float alphaStep = 0.1f;
	public CharacterSelectedData characterSelectedData;
	public VehicleSelectedData vehicleSelectedData;
	public CharacterVisibility characterVisibility;
	public EndTurnConfirmation endTurnConfirmation;
	public GameObject bulletPrefab;
	public SelectedCharacterInfo selectedCharacterInfo;
	public SelectedVehicleInfo selectedVehicleInfo;
	public CharacterInventoryUI characterInventoryUI;
	public VehicleInventoryUIBA64 vehicleInventoryUIBA64;
	public ForgeUI forgeUI;
	public FarmUI farmUI;

	public GameObject FirearmGO;
	public GameObject MovementGO;
	public GameObject HandAttackGO;
	public GameObject MeleeAttackGO;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f, LayerMask.GetMask("Units"));

			if (hit.collider != null)
			{
				GameObject hitObject = hit.collider.gameObject;
				CharacterData characterData = hitObject.GetComponent<CharacterData>();
				Forge forge = hitObject.GetComponent<Forge>();
				Farm farm = hitObject.GetComponent<Farm>();

				if (characterData != null && characterData.ownerPlayerID == endTurnConfirmation.ownerPlayerID)
				{
					if (!characterData.isSelected)
					{
						if (selectedCharacter != null)
						{
							DeselectCharacter();
						}
						characterSelectedData.characterData = null;
						SelectCharacter(hitObject);
					}
					else if (EventSystem.current.IsPointerOverGameObject())
					{
					
					}
					else if (characterData.isSelected && hitObject != selectedCharacter)
					{
						DeselectCharacter();
					}
				}
				else if (EventSystem.current.IsPointerOverGameObject())
				{
				
				}
				else if (selectedCharacter != null)
				{
					DeselectCharacter();
				}
				
				if(characterData == null && forge != null)
				{
					forgeUI.OpenForgeInventory(forge);
					forgeUI.forge = forge;
				}
				
				if(characterData == null && farm != null)
				{
					farmUI.OpenFarmChoise(farm);
				}
			}
			else if (EventSystem.current.IsPointerOverGameObject())
            {
				
			}
			else if (selectedCharacter != null)
			{
				DeselectCharacter();
			}
		}
	}
	
	public void FindTargets()
	{
		pathfinder.FindEnemiesInRange(characterSelectedData.characterData.currentNode, characterSelectedData.characterData);
	}
	
	public void FindMoves()
	{
		pathfinder.FindAllPossibleMoves(characterSelectedData.characterData.currentNode, characterSelectedData.characterData, out List<Node> possibleMoves);
		MovementGO.SetActive(false);
	}

	public void SelectCharacter(GameObject character)
	{
		CharacterData characterData = character.GetComponent<CharacterData>();
		if (!characterData.isSelected)
		{
			selectedCharacterInfo.CharacterInfoFromInventory(characterData);
			characterData.isSelected = true;
			characterSelectedData.characterData = characterData;
			characterData.currentNode.gCost = 0;
			characterData.currentNode.hCost = 0;

			CharacterMovement existingMovement = character.GetComponent<CharacterMovement>();
			if (existingMovement != null)
			{
				Destroy(existingMovement);
			}

			if (existingMovement == null)
			{
				CharacterMovement movementScript = character.AddComponent<CharacterMovement>();
				selectedCharacterMovement = movementScript;
				movementScript.pathfinder = pathfinder;
				if (characterData.usableMP > 0)
				{
					MovementGO.SetActive(true);
				}
			}
			else
			{
				selectedCharacterMovement = existingMovement;
			}

			CharacterAttack existingAttack = character.GetComponent<CharacterAttack>();
			if (existingAttack != null)
			{
				Destroy(existingAttack);
			}

			if (existingAttack == null)
			{
				CharacterAttack attackScript = character.AddComponent<CharacterAttack>();
				selectedCharacterAttack = attackScript;
				attackScript.characterSelection = this;
				attackScript.pathfinder = pathfinder;
				if (characterData.usableAP > 0)
				{
					if(characterData.characterInventory.weaponSlot.itemGameObject != null)
					{
						ItemObject itemObject  = characterData.characterInventory.weaponSlot.itemGameObject.GetComponent<ItemObject>();
						if(itemObject != null && itemObject.attackRange == 1)
						{
							MeleeAttackGO.SetActive(true);
						}
						else if(itemObject != null && itemObject.attackRange > 1)
						{
							FirearmGO.SetActive(true);
						}
					}
					else if(characterData.characterInventory.weaponSlot.itemGameObject == null)
					{
						HandAttackGO.SetActive(true);
					}
				}
			}
			else
			{
				selectedCharacterAttack = existingAttack;
			}
			selectedCharacter = character;
		}
		characterSpriteRenderer = character.GetComponent<SpriteRenderer>();

		if(!isFlashing)
		{
			StartCoroutine(FlashCharacter());
		}
	}

	private IEnumerator FlashCharacter()
	{
		if(!isFlashing)
		{
			isFlashing = true;
			characterSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
			while (isFlashing)
			{
				// Уменьшаем альфа канал
				for (float alpha = maxAlpha; alpha >= minAlpha; alpha -= alphaStep)
				{
					characterSpriteRenderer.color = new Color(1f, 1f, 1f, alpha);
					yield return new WaitForSeconds(0.1f);
				}

				
				for (float alpha = minAlpha; alpha <= maxAlpha; alpha += alphaStep)
				{
					characterSpriteRenderer.color = new Color(1f, 1f, 1f, alpha);
					yield return new WaitForSeconds(0.1f);
				}
			}

			characterSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
			yield return new WaitForSeconds(0.5f);
			isFlashing = false;
		}
	}

	private void AddMarkerScript(List<CellData> cells)
	{
		foreach (var cell in cells)
		{
			WalkMarkerScript existingMarker = cell.GetComponent<WalkMarkerScript>();

			if (existingMarker == null)
			{
				if (cell != null)
				{
					WalkMarkerScript markerScript = cell.gameObject.AddComponent<WalkMarkerScript>();
				}
			}
		}
	}
	
	private void EnqueueIfNotVisited(Queue<CellData> queue, HashSet<CellData> visited, CellData neighbor)
	{
		if (neighbor != null && !visited.Contains(neighbor))
		{
			queue.Enqueue(neighbor);
			visited.Add(neighbor);
		}
	}
	
	public void DeselectCharacter()
	{
		if (selectedCharacter != null)
		{
			selectedCharacterInfo.DeactivateInfoPanel();
			CharacterData characterData = selectedCharacter.GetComponent<CharacterData>();
			if (characterData != null)
			{
				characterData.isSelected = false;
			}
			
			if (characterData.currentCell.IsOccupiedByCity)
			{
				CharacterVisibility characterVisibility = selectedCharacter.GetComponent<CharacterVisibility>();
				characterVisibility.SetNotVisibile();
			}
			
			if (characterData.currentCell.mashineFactory != null && characterData.currentCell.buildingSite == null)
			{
				CharacterVisibility characterVisibility = selectedCharacter.GetComponent<CharacterVisibility>();
				characterVisibility.SetNotVisibile();
			}

			if (selectedCharacterMovement != null)
			{
				Destroy(selectedCharacterMovement);
			}

			if (selectedCharacterAttack != null)
			{
				Destroy(selectedCharacterAttack);
			}
			
			if(characterInventoryUI.isCharacterInventoryPanelOpen)
			{
				characterInventoryUI.CloseCharacterInventoryUI();
			}
			selectedCharacter = null;
			selectedCharacterMovement = null;
			selectedCharacterAttack = null;
			RemoveAllTargetMarkers();

			if (isFlashing)
			{
				StopCoroutine(FlashCharacter());
				characterSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
				isFlashing = false;
			}
			else
			{
				characterSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
			}
			ResetAllCellColors();

			FirearmGO.SetActive(false);
			MovementGO.SetActive(false);
			HandAttackGO.SetActive(false);
			MeleeAttackGO.SetActive(false);
		}
	}
	public void ResetAllCellColors()
	{
		Node[] nodes = FindObjectsOfType<Node>();

		foreach (Node node in nodes)
		{
			ResetCellColor(node);
		}
		RemoveAllHighlightMarkers();
	}

	public void ResetCellColor(Node node)
	{
		SpriteRenderer cellRenderer = node.GetComponent<SpriteRenderer>();
		if (cellRenderer != null)
		{
			cellRenderer.color = Color.white;
		}
	}
	
	public static void RemoveAllHighlightMarkers()
    {
        HighlightMarker[] markers = GameObject.FindObjectsOfType<HighlightMarker>();

        foreach (HighlightMarker marker in markers)
        {
            Destroy(marker);
        }
    }
	
	public void RemoveAllTargetMarkers()
	{
		TargetMarker[] targetMarkers = FindObjectsOfType<TargetMarker>();

		foreach (TargetMarker targetMarker in targetMarkers)
		{
			Destroy(targetMarker.gameObject);
		}
	}
	
	public void SelectVehicle(GameObject vehicle)
	{
		VehicleData vehicleData = vehicle.GetComponent<VehicleData>();
		if (!vehicleData.isSelected)
		{
			selectedVehicleInfo.VehicleInfoFromInventory(vehicleData);
			vehicleData.isSelected = true;
			vehicleSelectedData.vehicleData = vehicleData;
			vehicleData.currentNode.gCost = 0;
			vehicleData.currentNode.hCost = 0;

			VehicleMovement existingMovement = vehicle.GetComponent<VehicleMovement>();
			if (existingMovement != null)
			{
				Destroy(existingMovement);
			}

			if (existingMovement == null)
			{
				VehicleMovement movementScript = vehicle.AddComponent<VehicleMovement>();
				selectedVehicleMovement = movementScript;
				movementScript.pathfinder = pathfinder;
			}
			else
			{
				selectedVehicleMovement = existingMovement;
			}

			VehicleAttack existingAttack = vehicle.GetComponent<VehicleAttack>();
			if (existingAttack != null)
			{
				Destroy(existingAttack);
			}

			if (existingAttack == null)
			{
				VehicleAttack attackScript = vehicle.AddComponent<VehicleAttack>();
				selectedVehicleAttack = attackScript;
				attackScript.characterSelection = this;
				attackScript.pathfinder = pathfinder;
			}
			else
			{
				selectedVehicleAttack = existingAttack;
			}
			selectedVehicle = vehicle;
		}
		vehicleSpriteRenderer = vehicle.GetComponent<SpriteRenderer>();

		if(!isFlashingVehicle)
		{
			StartCoroutine(FlashVehicle());
		}
	}
	
	public void DeselectVehicle()
	{
		if (selectedVehicle != null)
		{
			selectedVehicleInfo.DeactivateInfoPanel();
			VehicleData vehicleData = selectedVehicle.GetComponent<VehicleData>();
			if (vehicleData != null)
			{
				vehicleData.isSelected = false;
			}
			
			if (vehicleData.currentCell.mashineFactory != null && vehicleData.currentCell.buildingSite == null)
			{
				BoxCollider2D boxCollider = vehicleData.thisVehicle.GetComponent<BoxCollider2D>();
				SpriteRenderer spriteRenderer = vehicleData.thisVehicle.GetComponent<SpriteRenderer>();
				boxCollider.enabled = false;
				spriteRenderer.enabled = false;
			}

			if (selectedVehicleMovement != null)
			{
				Destroy(selectedVehicleMovement);
			}

			if (selectedVehicleAttack != null)
			{
				Destroy(selectedVehicleAttack);
			}
			
			if(vehicleInventoryUIBA64.isVehicleInventoryPanelOpen)
			{
				vehicleInventoryUIBA64.CloseVehicleInventoryUI();
			}
			selectedVehicle = null;
			selectedVehicleMovement = null;
			selectedVehicleAttack = null;
			RemoveAllTargetMarkers();

			if (isFlashingVehicle)
			{
				StopCoroutine(FlashVehicle());
				vehicleSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
				isFlashingVehicle = false;
			}
			else
			{
				vehicleSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
			}
			ResetAllCellColors();
		}
	}
	
	private IEnumerator FlashVehicle()
	{
		if(!isFlashingVehicle)
		{
			isFlashingVehicle = true;
			vehicleSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
			while (isFlashingVehicle)
			{
				// Уменьшаем альфа канал
				for (float alpha = maxAlpha; alpha >= minAlpha; alpha -= alphaStep)
				{
					vehicleSpriteRenderer.color = new Color(1f, 1f, 1f, alpha);
					yield return new WaitForSeconds(0.1f);  // Время задержки между шагами
				}

				// Увеличиваем альфа канал
				for (float alpha = minAlpha; alpha <= maxAlpha; alpha += alphaStep)
				{
					vehicleSpriteRenderer.color = new Color(1f, 1f, 1f, alpha);
					yield return new WaitForSeconds(0.1f);  // Время задержки между шагами
				}
			}

			vehicleSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
			yield return new WaitForSeconds(0.5f);
			isFlashingVehicle = false;
		}
	}
}