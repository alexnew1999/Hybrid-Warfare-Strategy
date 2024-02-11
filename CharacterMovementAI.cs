using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterMovementAI : MonoBehaviour
{
	public float moveSpeed = 5f;
	public CharacterSelection characterSelection;
	public CharacterVisibility characterVisibility;
	private Vector2 targetPosition;
	public CharacterData characterData;
	public Pathfinder pathfinder;
	public SpriteRenderer spriteRenderer;
	public void MoveToPositionAI(List<Node> path, Node targetNode, CharacterData characterData)
	{
		BoxCollider2D cellCollider = characterData.currentCell.GetComponent<BoxCollider2D>();

		if (!characterData.currentCell.IsOccupiedByCity && cellCollider != null)
		{
			// Отключаем коллайдер, если он присутствует
			cellCollider.enabled = true;
		}
		if (spriteRenderer == null)
		{
			spriteRenderer = characterData.thisCharacter.GetComponent<SpriteRenderer>();
			spriteRenderer.sortingLayerName = "Units Layer";
			spriteRenderer.sortingOrder = 0;
		}
		characterVisibility = GetComponent<CharacterVisibility>();
		characterVisibility.SetVisibile();
		characterData.currentCell.IsOccupied = false;
		characterData.currentCell.characterData = null;
		if(path != null)
		{
			StartCoroutine(MoveAlongPathAI(path));
		}
		characterData.currentNode = targetNode;
		characterData.currentCell = targetNode.cellData;
		if (!characterData.currentCell.IsOccupiedByCity && characterData.currentCell.mashineFactory == null)
		{
			characterData.InCityInventory = false;
			characterData.currentCell.IsOccupied = true;
			characterData.currentCell.characterData = characterData;
			cellCollider.enabled = true;
		}
		else if (characterData.currentCell.mashineFactory != null)
		{
			characterData.currentCell.IsOccupied = false;
			cellCollider.enabled = false;
		}
		if (path != null && path.Count > 0)
		{
			int totalCost = path.Sum(node => node.baseCost);
			characterData.usableMP -= totalCost;
		}
		cellCollider = characterData.currentCell.GetComponent<BoxCollider2D>();
		cellCollider.enabled = false;
	}

    private IEnumerator MoveAlongPathAI(List<Node> path)
    {
        foreach (Node targetNode in path)
        {
            targetPosition = new Vector2(targetNode.transform.position.x, targetNode.transform.position.y);

            while ((Vector2)transform.position != targetPosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
		ResetGCost(path);
		
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
    }
	
	private void ResetGCost(List<Node> path)
	{
		foreach (Node node in path)
		{
			node.gCost = 0;
		}
	}
}
