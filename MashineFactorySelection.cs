using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MashineFactorySelection : MonoBehaviour
{
    private GameObject selectedMashineFactory;
	public EndTurnConfirmation endTurnConfirmation;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, LayerMask.GetMask("City"));

			if (hit.collider != null)
			{
				GameObject hitObject = hit.collider.gameObject;
				MashineFactory mashineFactory = hitObject.GetComponent<MashineFactory>();
				CellData cellData = hitObject.GetComponent<CellData>();

				if (mashineFactory != null && mashineFactory.ownerPlayerID == endTurnConfirmation.ownerPlayerID)
				{
					if (!mashineFactory.isSelected)
					{
						if (selectedMashineFactory != null)
						{
							DeselectMashineFactory();
						}
						SelectMashineFactory(hitObject);
					}
					else if (mashineFactory.isSelected && hitObject != selectedMashineFactory)
					{
						DeselectMashineFactory();
					}
				}
				else if(cellData != null)
				{
					if(cellData.mashineFactory != null)
					{
						if(cellData.mashineFactory.ownerPlayerID == endTurnConfirmation.ownerPlayerID)
						{
							if (!cellData.mashineFactory.isSelected)
							{
								if (selectedMashineFactory != null)
								{
									DeselectMashineFactory();
								}
								SelectMashineFactoryFromCell(hitObject);
							}
							else if (cellData.mashineFactory.isSelected && hitObject != selectedMashineFactory)
							{
								DeselectMashineFactory();
							}
						}
						else
						{
							DeselectMashineFactory();
						}
					}
					else if (selectedMashineFactory != null)
					{
						DeselectMashineFactory();
					}
				}
				else if (selectedMashineFactory != null)
				{
					DeselectMashineFactory();
				}
			}
			else if (EventSystem.current.IsPointerOverGameObject())
            {
				
			}
			else if (selectedMashineFactory != null)
			{
				DeselectMashineFactory();
			}
		}
	}

	private void SelectMashineFactory(GameObject factory)
	{
		MashineFactory mashineFactory = factory.GetComponent<MashineFactory>();
		SelectedMashineFactoryInfo selectedMashineFactoryInfo = factory.GetComponent<SelectedMashineFactoryInfo>();
		if(mashineFactory != null)
		{
			if (!mashineFactory.isSelected)
			{
				mashineFactory.isSelected = true;

				selectedMashineFactory = factory;
				selectedMashineFactoryInfo.ActivateMashineFactoryInfoPanelManually(mashineFactory);
			}
		}
	}
	
	private void SelectMashineFactoryFromCell(GameObject cell)
	{
		CellData cellData = cell.GetComponent<CellData>();
		if(cellData != null)
		{
			if (!cellData.mashineFactory.isSelected)
			{
				cellData.mashineFactory.isSelected = true;

				selectedMashineFactory = cellData.mashineFactory.mashineFactoryObject;
			}
		}
	}

	private void DeselectMashineFactory()
	{
		if (selectedMashineFactory != null)
		{
			MashineFactory mashineFactory = selectedMashineFactory.GetComponent<MashineFactory>();
			if (mashineFactory != null)
			{
				mashineFactory.isSelected = false;
			}
			selectedMashineFactory = null;
		}
	}
}