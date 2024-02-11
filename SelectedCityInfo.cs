using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectedCityInfo : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI cityNameText;
    public TextMeshProUGUI cityIDText;
    public TextMeshProUGUI cityPopulationText;
    public TextMeshProUGUI cityOwnerText;
    public Image cityImage;
	public Image InvIcon;
	public CitySelectedData citySelectedData;

    private void Start()
    {
		SelectedCityInfoSlots infoSlotsScript = FindObjectOfType<SelectedCityInfoSlots>();

        // Копируем ссылки из SelectedCityInfoSlots в текущий скрипт
        if (infoSlotsScript != null)
        {
            infoPanel = infoSlotsScript.infoPanel;
            cityNameText = infoSlotsScript.cityNameText;
            cityIDText = infoSlotsScript.cityIDText;
            cityPopulationText = infoSlotsScript.cityPopulationText;
            cityOwnerText = infoSlotsScript.cityOwnerText;
            cityImage = infoSlotsScript.cityImage;
			InvIcon = infoSlotsScript.InvIcon;
			citySelectedData = infoSlotsScript.citySelectedData;
        }
    }

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hitCity = Physics2D.Raycast(mouseWorldPos, Vector2.zero, LayerMask.GetMask("City"));
			if (hitCity.collider != null)
			{
				GameObject hitObject = hitCity.collider.gameObject;
				SmallCity smallCity = hitObject.GetComponent<SmallCity>();

				if (smallCity != null)
				{
					citySelectedData.smallCity = smallCity;
					cityNameText.text = "City Name: " + smallCity.cityName;
					cityIDText.text = "City ID: " + smallCity.cityID;
					cityPopulationText.text = "Population: " + smallCity.Population;
					cityOwnerText.text = "OwnerPlayerID: " + smallCity.ownerPlayerID;

					SpriteRenderer citySpriteRenderer = smallCity.GetComponent<SpriteRenderer>();
					if (citySpriteRenderer != null)
					{
						cityImage.sprite = citySpriteRenderer.sprite;
					}

					cityImage.gameObject.SetActive(true);
					infoPanel.SetActive(true);
				}
				else if (EventSystem.current.IsPointerOverGameObject())
				{
				
				}
				else
				{
					// Если объект без SmallCity, отключаем информационную панель
					DeactivateCityInfoPanel();
				}
			}
			else if (EventSystem.current.IsPointerOverGameObject())
            {
			
			}
			else
			{
				// Если кликнули на пустом месте, отключаем информационную панель
				DeactivateCityInfoPanel();
			}
		}
	}

    public void DeactivateCityInfoPanel()
    {
        // Очищаем текстовые поля и скрываем изображение персонажа
        cityNameText.text = "";
        cityIDText.text = "";
        cityPopulationText.text = "";
        cityOwnerText.text = "";
        cityImage.gameObject.SetActive(false);
        infoPanel.SetActive(false);
    }
	
	public void ActivateCityInfoPanelManually(SmallCity smallCity)
	{
		if (smallCity != null)
		{
			citySelectedData.smallCity = smallCity;

			cityNameText.text = "City Name: " + smallCity.cityName;
			cityIDText.text = "City ID: " + smallCity.cityID;
			cityPopulationText.text = "Population: " + smallCity.Population;
			cityOwnerText.text = "OwnerPlayerID: " + smallCity.ownerPlayerID;
			SpriteRenderer citySpriteRenderer = smallCity.GetComponent<SpriteRenderer>();
			if (citySpriteRenderer != null)
			{
				cityImage.sprite = citySpriteRenderer.sprite;
			}

			cityImage.gameObject.SetActive(true);
			infoPanel.SetActive(true);
		}
	}
}
