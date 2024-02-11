using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CityHoverInfo : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI cityNameText;
    public TextMeshProUGUI cityIDText;
    public TextMeshProUGUI cityPopulationText;
    public TextMeshProUGUI cityOwnerText;
    public Image cityImage;
	private SpriteRenderer SpriteRenderer;
	private Camera mainCamera; // Ссылка на главную камеру
	private SmallCity smallCity;

    private void Start()
    {
		CityHoverInfoSlots infoSlotsScript = FindObjectOfType<CityHoverInfoSlots>();

        // Копируем ссылки из SelectedCityInfoSlots в текущий скрипт
        if (infoSlotsScript != null)
        {
            infoPanel = infoSlotsScript.infoPanel;
            cityNameText = infoSlotsScript.cityNameText;
            cityIDText = infoSlotsScript.cityIDText;
            cityPopulationText = infoSlotsScript.cityPopulationText;
            cityOwnerText = infoSlotsScript.cityOwnerText;
            cityImage = infoSlotsScript.cityImage;
        }
		mainCamera = Camera.main;
		smallCity = GetComponent<SmallCity>();
    }

	void OnMouseEnter()
	{
		// Проверяем, что у нас есть данные персонажа и isSelected = false
		if (smallCity != null && !smallCity.isSelected)
		{
			// Отображаем информацию о персонаже в текстовом поле
			cityNameText.text = "Name: " + smallCity.cityName;

			cityIDText.text = "CityID: " + smallCity.cityID;
			
			cityOwnerText.text = "OwnerPlayerID: " + smallCity.ownerPlayerID;
			
			cityPopulationText.text = "Population: " + smallCity.Population;
			
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			cityImage.sprite = spriteRenderer.sprite;
			cityImage.gameObject.SetActive(true);
		
			// Включаем всплывающую панель
			infoPanel.SetActive(true);
		}
	}

	void OnMouseExit()
	{
		// Очищаем текстовое поле
		cityNameText.text = "";

		cityIDText.text = "";
		
		cityOwnerText.text = "";

		cityPopulationText.text = "";
		
		// Скрываем фото персонажа
		cityImage.gameObject.SetActive(false);
		
		// Выключаем всплывающую панель
		infoPanel.SetActive(false);
	}
	
	private SmallCity GetSmallCityUnderMouse()
	{
		// Получите позицию мыши в мировых координатах
		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// Пускаем луч к точке нажатия мыши и получаем информацию о столкновении
		RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, LayerMask.GetMask("City"));

		if (hit.collider != null)
		{
			GameObject hitObject = hit.collider.gameObject;
			SmallCity smallCity = hitObject.GetComponent<SmallCity>();
			return smallCity;
		}

		return null; // Если мышь не указывает на персонажа, возвращаем null
	}
	
	public void CityInfoActivate()
	{
		// Проверяем, что у нас есть данные персонажа и isSelected = false
		if (smallCity != null && !smallCity.isSelected)
		{
			// Отображаем информацию о персонаже в текстовом поле
			cityNameText.text = "Name: " + smallCity.cityName;

			cityIDText.text = "CityID: " + smallCity.cityID;
			
			cityOwnerText.text = "OwnerPlayerID: " + smallCity.ownerPlayerID;

			cityPopulationText.text = "Population: " + smallCity.Population;
			
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			cityImage.sprite = spriteRenderer.sprite;
			cityImage.gameObject.SetActive(true);
		
			// Включаем всплывающую панель
			infoPanel.SetActive(true);
		}
	}

	public void CityInfoDeactivate()
	{
		// Очищаем текстовое поле
		cityNameText.text = "";

		cityIDText.text = "";
		
		cityOwnerText.text = "";

		cityPopulationText.text = "";
		
		// Скрываем фото персонажа
		cityImage.gameObject.SetActive(false);
		
		// Выключаем всплывающую панель
		infoPanel.SetActive(false);
	}
}
