using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CitySelection : MonoBehaviour
{
    private GameObject selectedCity;
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
				SmallCity smallCity = hitObject.GetComponent<SmallCity>();
				CellData cellData = hitObject.GetComponent<CellData>();

				if (smallCity != null && smallCity.ownerPlayerID == endTurnConfirmation.ownerPlayerID)
				{
					if (!smallCity.isSelected)
					{
						// Снимаем выбор с предыдущего города (если выбран)
						if (selectedCity != null)
						{
							DeselectCity();
						}
						// Выбираем новый город и устанавливаем isSelected = true
						SelectCity(hitObject);
					}
					else if (smallCity.isSelected && hitObject != selectedCity)
					{
						// Снимаем выбор с текущего города, если выбран другой город
						DeselectCity();
					}
				}
				else if(cellData != null)
				{
					if(cellData.smallCity != null)
					{
						if(cellData.smallCity.ownerPlayerID == endTurnConfirmation.ownerPlayerID)
						{
							if (!cellData.smallCity.isSelected)
							{
								// Снимаем выбор с предыдущего города (если выбран)
								if (selectedCity != null)
								{
									DeselectCity();
								}
								// Выбираем новый город и устанавливаем isSelected = true
								SelectCityFromCell(hitObject);
							}
							else if (cellData.smallCity.isSelected && hitObject != selectedCity)
							{
								// Снимаем выбор с текущего города, если выбран другой город
								DeselectCity();
							}
						}
						else
						{
							// Снимаем выбор с текущего города, если выбран другой город
							DeselectCity();
						}
					}
					else if (selectedCity != null)
					{
						// Снимаем выбор с текущего города, если выбран объект без компонента SmallCity
						DeselectCity();
					}
				}
				else if (selectedCity != null)
				{
					// Снимаем выбор с текущего города, если выбран объект без компонента SmallCity
					DeselectCity();
				}
			}
			else if (EventSystem.current.IsPointerOverGameObject())
            {
				
			}
			else if (selectedCity != null)
			{
				// Снимаем выбор с текущего города, если кликнуто на пустом месте
				DeselectCity();
			}
		}
	}

	private void SelectCity(GameObject city)
	{
		SmallCity smallCity = city.GetComponent<SmallCity>();
		SelectedCityInfo selectedCityInfo = city.GetComponent<SelectedCityInfo>();
		if(smallCity != null)
		{
			if (!smallCity.isSelected)
			{
				// Устанавливаем isSelected для текущего SmallCity
				smallCity.isSelected = true;

				selectedCity = city;
				selectedCityInfo.ActivateCityInfoPanelManually(smallCity);
			}
		}
	}
	
	private void SelectCityFromCell(GameObject cell)
	{
		CellData cellData = cell.GetComponent<CellData>();
		if(cellData != null)
		{
			if (!cellData.smallCity.isSelected)
			{
				// Устанавливаем isSelected для текущего SmallCity
				cellData.smallCity.isSelected = true;

				selectedCity = cellData.smallCity.ThisCity;
			}
		}
	}

	private void DeselectCity()
	{
		if (selectedCity != null)
		{                
			// Снимаем isSelected для текущего SmallCity
			SmallCity smallCity = selectedCity.GetComponent<SmallCity>();
			if (smallCity != null)
			{
				smallCity.isSelected = false;
			}
			selectedCity = null;
		}
	}
}