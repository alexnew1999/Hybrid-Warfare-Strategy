using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForgeSelection : MonoBehaviour
{
    private GameObject selectedForgeObject;
    private Forge selectedForge;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, LayerMask.GetMask("City"));

			if (hit.collider != null)
			{
				GameObject hitObject = hit.collider.gameObject;
				Forge forge = hitObject.GetComponent<Forge>();

				if (forge != null)
				{
					if (!forge.isSelected)
					{
						if (selectedForgeObject != null)
						{
							DeselectForge();
						}
						SelectForge(hitObject);
					}
					else if (forge.isSelected && hitObject != selectedForgeObject)
					{
						DeselectForge();
					}
				}
				else if (selectedForgeObject != null)
				{
					DeselectForge();
				}
			}
			else if (EventSystem.current.IsPointerOverGameObject())
            {
				
			}
			else if (selectedForgeObject != null)
			{
				DeselectForge();
			}
		}
	}

	private void SelectForge(GameObject forge1)
	{
		Forge forge = forge1.GetComponent<Forge>();

		if (!forge.isSelected)
		{
			forge.isSelected = true;

			selectedForgeObject = forge1;
		}
	}

	private void DeselectForge()
	{
		if (selectedForgeObject != null)
		{                
			// Снимаем isSelected для текущего SmallCity
			Forge forge = selectedForgeObject.GetComponent<Forge>();
			if (forge != null)
			{
				forge.isSelected = false;
			}
			selectedForgeObject = null;
		}
	}
}
