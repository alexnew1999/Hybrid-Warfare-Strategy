using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mobilization : MonoBehaviour
{
    public Button mobilizationButton; // Ссылка на кнопку мобилизации
    public Sprite activeButtonSprite; // Спрайт для активной кнопки
    public Sprite inactiveButtonSprite; // Спрайт для неактивной кнопки
    private bool isMobilizationActive = true;

    public static Mobilization Instance { get; private set; }

    private void Start()
    {
        if (mobilizationButton != null)
        {
            // На старте кнопка неактивна
            mobilizationButton.interactable = isMobilizationActive;
            UpdateMobilizationButtonState(); // Обновляем спрайт кнопки
            // Добавляем обработчик нажатия на кнопку мобилизации
            mobilizationButton.onClick.AddListener(ActivateMobilization);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void ActivateMobilization()
    {
        SmallCity[] allCities = FindObjectsOfType<SmallCity>();

        // Проверяем все города
        foreach (SmallCity city in allCities)
        {
            if (city.InvOpen && !city.MobilizationInProgress && city.PopulationWorkable >= 100)
            {
                
                CityInventory cityInventory = city.cityInventory;

                if (cityInventory != null && cityInventory.GetFreeCharacterObjectIndex() != -1)
                {
                    // Если CityInventory найден и у него есть свободные слоты, активируем мобилизацию
                    city.MobilizationInProgress = true;
                    isMobilizationActive = false; // Устанавливаем флаг активации мобилизации
                    UpdateMobilizationButtonState(); // Обновляем спрайт кнопки
					break;
                }
            }
        }
    }
	
	public void ActivateMobilizationAI(SmallCity city)
    {
        if (!city.MobilizationInProgress && city.PopulationWorkable >= 100)
        {
            CityInventory cityInventory = city.cityInventory;
            if (cityInventory != null && cityInventory.GetFreeCharacterObjectIndex() != -1)
            {
                city.MobilizationInProgress = true;
                isMobilizationActive = false; // Устанавливаем флаг активации мобилизации
                UpdateMobilizationButtonState(); // Обновляем спрайт кнопки
            }
        }
    }

    public void ReActivateMobilization(SmallCity smallCity)
    {
		SmallCity selectedCity = null;
		selectedCity = smallCity;
		
		if (selectedCity != null)
		{
			CityInventory cityInventory = smallCity.cityInventory;

			if (selectedCity.MobilizationInProgress)
			{
				isMobilizationActive = false;
				UpdateMobilizationButtonState(); // Обновляем спрайт кнопки
			}
			else
			{
				isMobilizationActive = true;
				UpdateMobilizationButtonState(); // Обновляем спрайт кнопки
			}
		}
    }

    private void UpdateMobilizationButtonState()
    {
        if (mobilizationButton != null)
        {
            mobilizationButton.interactable = isMobilizationActive;
            mobilizationButton.image.sprite = isMobilizationActive ? inactiveButtonSprite : activeButtonSprite;
        }
    }
}