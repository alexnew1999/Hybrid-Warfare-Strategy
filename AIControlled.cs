using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIControlled : MonoBehaviour
{
	public PlayerScript playerScript;
	public Mobilization mobilization;
	public Pathfinder pathfinder;
	public CharacterSelection characterSelection;
	public WearAI wearAI;
	public ItemsList itemsList;
	public GameObject AIDefendDrone1;
	public GameObject AIDefendDrone2;
	public GameObject AIAttackDrone1;
	public GameObject AIAttackDrone2;
	public GameObject AIAttackDrone3;
	public GameObject AIAttackDrone4;
	public GameObject AIAttackDrone5;
	public GameObject AIAttackDrone6;
	public GameObject AIAttackDrone7;
	public GameObject AIAttackDrone8;
	public GameObject AIAttackDrone9;
	public GameObject AIAttackDrone10;
	public List<Node> possibleMoves;
	public List<Node> nodesToDefend;
	public List<Node> nodesToDefendMove;
	public List<CharacterData> possibleEnemyes;
	public int ownerPlayerID;
	
	public EndTurnConfirmation endTurnConfirmation;
	private bool aiTurnInProgress = false;
	
	private void Start()
	{
		mobilization = FindObjectOfType<Mobilization>();
		if(wearAI == null)
		{
			wearAI = FindObjectOfType<WearAI>();
		}
		if(itemsList == null)
		{
			itemsList = FindObjectOfType<ItemsList>();
		}
		if(pathfinder == null)
		{
			pathfinder = FindObjectOfType<Pathfinder>();
		}
		if(endTurnConfirmation == null)
		{
			endTurnConfirmation = FindObjectOfType<EndTurnConfirmation>();
		}
		if(characterSelection == null)
		{
			characterSelection = FindObjectOfType<CharacterSelection>();
		}
	}

    public void AITurn()
    {
        if (!aiTurnInProgress)
        {
            StartCoroutine(AITurnCoroutine());
        }
    }
	
    private IEnumerator AITurnCoroutine()
    {
        aiTurnInProgress = true;

        SmallCity[] allCitys = FindObjectsOfType<SmallCity>();

        foreach (SmallCity city in allCitys)
        {
            if (city.ownerPlayerID == playerScript.ownerPlayerID)
            {
                if (city.Population >= 600)
                {
					if (AIDefendDrone1 == null)
					{
						mobilization.ActivateMobilizationAI(city);
					}
					else if (AIDefendDrone2 == null)
					{
						mobilization.ActivateMobilizationAI(city);
					}
                }
				if (nodesToDefend == null)
				{
					nodesToDefend = pathfinder.FindNodesToDefend(city.currentNode);
				}
            }
            yield return null;
        }
		
		CharacterData[] characters = FindObjectsOfType<CharacterData>();

		foreach (CharacterData character in characters)
		{
			 if (character.ownerPlayerID == playerScript.ownerPlayerID && character.aIDefendDrone != null)
			{
				StartCoroutine(SetupAI(character));
			}
		}
        endTurnConfirmation.NotYourTurn.SetActive(false);
        endTurnConfirmation.EndTurn();

        aiTurnInProgress = false;
    }
	
	private Node GetRandomNode(List<Node> nodes)
    {
        if (nodes.Count == 0)
        {
            return null;
        }

        int randomIndex = UnityEngine.Random.Range(0, nodes.Count);

        Node randomNode = nodes[randomIndex];

        // nodes.RemoveAt(randomIndex);

        return randomNode;
    }
	
	private CharacterData GetRandomEnemy(List<CharacterData> characters)
    {
        if (characters.Count == 0)
        {
            return null;
        }

        int randomIndex = UnityEngine.Random.Range(0, characters.Count);

        CharacterData randomCharacter = characters[randomIndex];

        // nodes.RemoveAt(randomIndex);

        return randomCharacter;
    }
	
	private List<Node> GetCommonNodes(List<Node> list1, List<Node> list2)
    {
        // Используем LINQ для получения пересечения списков
        List<Node> commonNodes = list1.Intersect(list2).ToList();
        return commonNodes;
    }
	
	private IEnumerator SetupAI(CharacterData character)
	{
		if(character.aIDefendDrone.characterMovementAI == null)
		{
			CharacterMovementAI movementScript = character.thisCharacter.AddComponent<CharacterMovementAI>();
			CharacterAttackAI attackScript = character.thisCharacter.AddComponent<CharacterAttackAI>();
			movementScript.characterData = character;
			attackScript.characterData = character;
			attackScript.pathfinder = pathfinder;
			movementScript.pathfinder = pathfinder;
			character.aIDefendDrone.characterMovementAI = movementScript;
			character.aIDefendDrone.characterAttackAI = attackScript;
			movementScript.characterSelection = characterSelection;
			if(character.characterInventory.weaponSlot.itemGameObject == null)
			{
				ItemObject MosinRifle = itemsList.CreateItemObject("Mosin Rifle", 4, 1, 1, 12, 0, 5, 0, 0, 0, 4, 0, 95, 0, 0, "mm762x54R", 1, ItemType.weapon, "Sprites/MosinRifle");
				ItemObject mm762x54R = itemsList.CreateItemObject("7.62x54mmR", 402, 30, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "None", 0, ItemType.ammo, "Sprites/mm762x54R");
				wearAI.WearSmth(character, MosinRifle.gameObject);
				wearAI.WearSmth(character, mm762x54R.gameObject);
			}
		}
		if(character.aIDefendDrone.targetCharacter == null)
		{
			possibleEnemyes = null;
			possibleEnemyes = pathfinder.FindEnemiesInRangeAI(character.currentNode, character);
			CharacterData targetCharacter = GetRandomEnemy(possibleEnemyes);
			if(targetCharacter == null)
			{
				possibleMoves = pathfinder.FindAllPossibleMovesAI(character.currentNode, character, out possibleMoves);
				nodesToDefendMove = null;
				nodesToDefendMove = GetCommonNodes(possibleMoves, nodesToDefend);
				Node randomNode = GetRandomNode(nodesToDefendMove);
				if(randomNode != null)
				{
					pathfinder.FindPath(character.currentNode, randomNode, character, out List<Node> path);
					character.aIDefendDrone.characterMovementAI.MoveToPositionAI(path, randomNode, character);
					possibleEnemyes = null;
					possibleEnemyes = pathfinder.FindEnemiesInRangeAI(character.currentNode, character);
					targetCharacter = GetRandomEnemy(possibleEnemyes);
					if(targetCharacter != null)
					{
						character.aIDefendDrone.targetCharacter = targetCharacter;
						if(character.aIDefendDrone.characterData.usableAP > 0)
						{
							character.aIDefendDrone.characterAttackAI.AttackMethod(targetCharacter);
						}
					}
				}
			}
			else if(targetCharacter != null)
			{
				character.aIDefendDrone.targetCharacter = targetCharacter;
				if(character.aIDefendDrone.characterData.usableAP > 0)
				{
					character.aIDefendDrone.characterAttackAI.AttackMethod(targetCharacter);
					if(character.aIDefendDrone.characterData.usableMP > 0)
					{
						possibleMoves = pathfinder.FindAllPossibleMovesAI(character.currentNode, character, out possibleMoves);
						nodesToDefendMove = null;
						nodesToDefendMove = GetCommonNodes(possibleMoves, nodesToDefend);
						Node randomNode = GetRandomNode(nodesToDefendMove);
						if(randomNode != null)
						{
							pathfinder.FindPath(character.currentNode, randomNode, character, out List<Node> path);
							character.aIDefendDrone.characterMovementAI.MoveToPositionAI(path, randomNode, character);
						}
					}
				}
			}
			else if(character.aIDefendDrone.targetCharacter != null)
			{
				if(character.aIDefendDrone.characterData.usableAP > 0)
				{
					character.aIDefendDrone.characterAttackAI.AttackMethod(targetCharacter);
					if(character.aIDefendDrone.characterData.usableMP > 0)
					{
						possibleMoves = pathfinder.FindAllPossibleMovesAI(character.currentNode, character, out possibleMoves);
						nodesToDefendMove = null;
						nodesToDefendMove = GetCommonNodes(possibleMoves, nodesToDefend);
						Node randomNode = GetRandomNode(nodesToDefendMove);
						if(randomNode != null)
						{
							pathfinder.FindPath(character.currentNode, randomNode, character, out List<Node> path);
							character.aIDefendDrone.characterMovementAI.MoveToPositionAI(path, randomNode, character);
						}
					}
				}
			}
		}
		else if(character.aIDefendDrone.targetCharacter != null)
		{
			if(character.aIDefendDrone.characterData.usableAP > 0)
			{
				character.aIDefendDrone.characterAttackAI.AttackMethod(character.aIDefendDrone.targetCharacter);
				if(character.aIDefendDrone.characterData.usableMP > 0)
				{
					possibleMoves = pathfinder.FindAllPossibleMovesAI(character.currentNode, character, out possibleMoves);
					nodesToDefendMove = null;
					nodesToDefendMove = GetCommonNodes(possibleMoves, nodesToDefend);
					Node randomNode = GetRandomNode(nodesToDefendMove);
					if(randomNode != null)
					{
						pathfinder.FindPath(character.currentNode, randomNode, character, out List<Node> path);
						character.aIDefendDrone.characterMovementAI.MoveToPositionAI(path, randomNode, character);
					}
				}
			}
		}
		 yield return null;
	}
}
