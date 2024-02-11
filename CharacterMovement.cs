using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class CharacterMovement : MonoBehaviour
{
    public CharacterData characterData;
	private CharacterData anotherCharacter;
	private CharacterVisibility characterVisibility;
	private SpriteRenderer spriteRenderer;
	private CharacterAttack characterAttack;
	private Camera mainCamera;
	private GameObject characterObject;
	private List<Node> path; // Путь, полученный из метода FindPath
	public Pathfinder pathfinder;
	private Node startNode;
	public List<Node> possibleMoves;
	public MovementCorroutine movementCorroutine;
	public TextMeshProUGUI DebugInfoPanel;
	public GameObject DebugInfoPanelObj;
	
	private void Start()
	{
		movementCorroutine = FindObjectOfType<MovementCorroutine>();
		movementCorroutine.characterMovement = this;
		DebugInfoPanel = movementCorroutine.DebugInfoPanel;
		DebugInfoPanelObj = movementCorroutine.DebugInfoPanelObj;
		mainCamera = Camera.main;
		characterData = GetComponent<CharacterData>();
		characterVisibility = GetComponent<CharacterVisibility>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sortingLayerName = "Units Layer";
		characterObject = characterData.thisCharacter;
		spriteRenderer.sortingOrder = 0;
		startNode = characterData.currentNode;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
			if (hit.collider != null)
			{
				SmallCity smallCity = hit.collider.GetComponent<SmallCity>();
				MashineFactory mashineFactory = hit.collider.GetComponent<MashineFactory>();
				VehicleData vehicleData = hit.collider.GetComponent<VehicleData>();
				if (smallCity != null)
				{
					Node targetNode = smallCity.currentCell.node;
					List<Node> possibleMoves = pathfinder.GetPossibleMoves();
					
					if (possibleMoves.Contains(targetNode))
					{
						List<Node> path;
						pathfinder.FindPath(startNode, targetNode, characterData, out path);
						int firstCost = path.Sum(node => node.baseCost);

						if (characterData != null && characterData.usableMP >= firstCost && firstCost > 0)
						{
							characterData.usableMP -= firstCost;
							ResetGCost(possibleMoves);
							possibleMoves = new List<Node>();
							MoveToPositionCity(path, targetNode, characterData);
						}
						else
						{
							if (!DebugInfoPanelObj.activeSelf)
							{
								DebugInfoPanelObj.SetActive(true);
							}
							DebugInfoPanel.text = "Not enough move points.";
						}
					}
					else
					{
						if (!DebugInfoPanelObj.activeSelf)
						{
							DebugInfoPanelObj.SetActive(true);
						}
						DebugInfoPanel.text = "Not possible to move here.";
					}
				}
				else if (mashineFactory != null)
				{
					Node targetNode = mashineFactory.cellData.node;
					List<Node> possibleMoves = pathfinder.GetPossibleMoves();
					
					if (possibleMoves.Contains(targetNode))
					{
						List<Node> path;
						pathfinder.FindPath(startNode, targetNode, characterData, out path);
						int firstCost = path.Sum(node => node.baseCost);

						if (characterData != null && characterData.usableMP >= firstCost && firstCost > 0)
						{
							characterData.usableMP -= firstCost;
							ResetGCost(possibleMoves);
							possibleMoves = new List<Node>();
							MoveToPositionMashineFactory(path, targetNode, characterData);
						}
						else
						{
							if (!DebugInfoPanelObj.activeSelf)
							{
								DebugInfoPanelObj.SetActive(true);
							}
							DebugInfoPanel.text = "Not enough move points.";
						}
					}
					else
					{
						if (!DebugInfoPanelObj.activeSelf)
						{
							DebugInfoPanelObj.SetActive(true);
						}
						DebugInfoPanel.text = "Not possible to move here.";
					}
				}
				else if (vehicleData != null)
				{
					Node targetNode = vehicleData.currentCell.node;
					List<Node> possibleMoves = pathfinder.GetPossibleMoves();
					if (possibleMoves.Contains(targetNode))
					{
						List<Node> path;
						pathfinder.FindPath(startNode, targetNode, characterData, out path);
						int firstCost = path.Sum(node => node.baseCost);

						if (characterData != null && characterData.usableMP >= firstCost && firstCost > 0)
						{
							characterData.usableMP -= firstCost;
							ResetGCost(possibleMoves);
							possibleMoves = new List<Node>();
							MoveToPositionVehicle(path, targetNode, characterData, vehicleData);
						}
						else
						{
							if (!DebugInfoPanelObj.activeSelf)
							{
								DebugInfoPanelObj.SetActive(true);
							}
							DebugInfoPanel.text = "Not enough move points.";
						}
					}
					else
					{
						if (!DebugInfoPanelObj.activeSelf)
						{
							DebugInfoPanelObj.SetActive(true);
						}
						DebugInfoPanel.text = "Not possible to move here.";
					}
				}
				else
				{
					Node targetNode = hit.collider.GetComponent<Node>();
					List<Node> possibleMoves = pathfinder.GetPossibleMoves();
					CharacterData anotherCharacter = hit.collider.GetComponent<CharacterData>();
					if(targetNode != null)
					{
						if(targetNode.cellData.IsOccupiedByCity)
						{
							if (possibleMoves.Contains(targetNode))
							{
								List<Node> path;
								pathfinder.FindPath(startNode, targetNode, characterData, out path);
								int firstCost = path.Sum(node => node.baseCost);

								if (characterData != null && characterData.usableMP >= firstCost && firstCost > 0)
								{
									characterData.usableMP -= firstCost;
									ResetGCost(possibleMoves);
									possibleMoves = new List<Node>();
									MoveToPositionCity(path, targetNode, characterData);
								}
								else
								{
									if (!DebugInfoPanelObj.activeSelf)
									{
										DebugInfoPanelObj.SetActive(true);
									}
									DebugInfoPanel.text = "Not enough move points.";
								}
							}
							else
							{
								if (!DebugInfoPanelObj.activeSelf)
								{
									DebugInfoPanelObj.SetActive(true);
								}
								DebugInfoPanel.text = "Not possible to move here.";
							}
						}
						else if (possibleMoves.Contains(targetNode))
						{
							List<Node> path = new List<Node>();
							pathfinder.FindPath(startNode, targetNode, characterData, out path);
							int firstCost = path.Sum(node => node.baseCost);
							if (characterData != null && characterData.usableMP >= firstCost && firstCost > 0)
							{
								characterData.usableMP -= firstCost;
								ResetGCost(possibleMoves);
								possibleMoves = new List<Node>();
								MoveToPosition(path, targetNode, characterData);
								pathfinder.FindAllPossibleMoves(characterData.currentNode, characterData, out List<Node> possibleMoves2);
								startNode = characterData.currentNode;
							}
							else
							{
								if (!DebugInfoPanelObj.activeSelf)
								{
									DebugInfoPanelObj.SetActive(true);
								}
								DebugInfoPanel.text = "Not enough move points.";
							}
						}
						else
						{
							if (!DebugInfoPanelObj.activeSelf)
							{
								DebugInfoPanelObj.SetActive(true);
							}

							DebugInfoPanel.text = "Not possible to move here.";
						}
					}
					else if (anotherCharacter != null)
					{
						
					}
					else
					{
						if (!DebugInfoPanelObj.activeSelf)
						{
							DebugInfoPanelObj.SetActive(true);
						}

						DebugInfoPanel.text = "Not possible to move here.";
					}
				}
			}
		}
	}

	public void MoveToPosition(List<Node> path, Node targetNode, CharacterData characterData)
	{
		BoxCollider2D cellCollider = characterData.currentCell.GetComponent<BoxCollider2D>();

		if (!characterData.currentCell.IsOccupiedByCity && cellCollider != null && characterData.currentCell.mashineFactory == null && characterData.InVehicleInventory == true)
		{
			cellCollider.enabled = true;
		}
		characterData.currentCell.IsOccupied = false;
		characterData.currentCell.characterData = null;
		movementCorroutine.Execute(path, startNode, characterData, targetNode);
	}
	
	public void MoveToPositionCity(List<Node> path, Node targetNode, CharacterData characterData)
	{
		BoxCollider2D cellCollider = characterData.currentCell.GetComponent<BoxCollider2D>();
		if (!characterData.currentCell.IsOccupiedByCity && cellCollider != null && characterData.currentCell.mashineFactory == null && !characterData.InVehicleInventory)
		{
			cellCollider.enabled = true;
		}
		characterData.currentCell.IsOccupied = false;
		characterData.currentCell.characterData = null;
		movementCorroutine.ExecuteCity(targetNode.cellData.smallCity, characterData.thisCharacter, path, spriteRenderer, characterVisibility);
	}
	
	public void MoveToPositionMashineFactory(List<Node> path, Node targetNode, CharacterData characterData)
	{
		BoxCollider2D cellCollider = characterData.currentCell.GetComponent<BoxCollider2D>();

		if (!characterData.currentCell.IsOccupiedByCity && cellCollider != null && characterData.currentCell.mashineFactory == null && characterData.InVehicleInventory == true)
		{
			cellCollider.enabled = true;
		}
		characterData.currentCell.IsOccupied = false;
		characterData.currentCell.characterData = null;
		movementCorroutine.ExecuteMashineFactory(targetNode.cellData.mashineFactory, characterData.thisCharacter, path, spriteRenderer, characterVisibility);
	}
	
	public void MoveToPositionVehicle(List<Node> path, Node targetNode, CharacterData characterData, VehicleData vehicleData)
	{
		BoxCollider2D cellCollider = characterData.currentCell.GetComponent<BoxCollider2D>();

		if (!characterData.currentCell.IsOccupiedByCity && cellCollider != null && characterData.currentCell.mashineFactory == null && characterData.InVehicleInventory == true)
		{
			cellCollider.enabled = true;
		}
		characterData.currentCell.IsOccupied = false;
		characterData.currentCell.characterData = null;
		movementCorroutine.ExecuteToVehicle(characterData, vehicleData, path, spriteRenderer);
	}
	
	private void ResetGCost(List<Node> path)
	{
		foreach (Node node in path)
		{	
			node.gCost = 0;
		}
	}
}