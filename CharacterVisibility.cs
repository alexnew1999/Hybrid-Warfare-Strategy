using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisibility : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
	private BoxCollider2D boxCollider2D;
	private CharacterData characterData;

    private void Start()
    {
		spriteRenderer = GetComponent<SpriteRenderer>();
		boxCollider2D = GetComponent<BoxCollider2D>();
		characterData = GetComponent<CharacterData>();
		if(characterData.InCityInventory)
		{
			if(spriteRenderer != null && boxCollider2D != null)
			{
				SetNotVisibile();
			}
		}
    }

    public void SetNotVisibile()
    {
		if(spriteRenderer != null && boxCollider2D != null)
		{
			spriteRenderer.enabled = false;
			boxCollider2D.enabled = false;
		}
    }
	
	public void SetVisibile()
	{
		if(spriteRenderer != null && boxCollider2D != null)
		{
			spriteRenderer.enabled = true;
			boxCollider2D.enabled = true;
		}
    }
}