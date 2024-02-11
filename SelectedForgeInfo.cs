using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectedForgeInfo : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI cityOwnerText;
    public Image forgeImage;
	public Image InvIcon;

    private void Start()
    {
		SelectedCityInfoSlots infoSlotsScript = FindObjectOfType<SelectedCityInfoSlots>();

        // Копируем ссылки из SelectedCityInfoSlots в текущий скрипт
        if (infoSlotsScript != null)
        {
            infoPanel = infoSlotsScript.infoPanel;
            cityOwnerText = infoSlotsScript.cityOwnerText;
            forgeImage = infoSlotsScript.cityImage;
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
				Forge forge = hitObject.GetComponent<Forge>();

				if (forge != null)
				{
					// Отображаем информацию о городе, если он выбран
					cityOwnerText.text = "OwnerPlayerID: " + forge.ownerPlayerID;

					SpriteRenderer forgeSpriteRenderer = forge.GetComponent<SpriteRenderer>();
					if (forgeSpriteRenderer != null)
					{
						forgeImage.sprite = forgeSpriteRenderer.sprite;
					}

					forgeImage.gameObject.SetActive(true);
					infoPanel.SetActive(true);
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
        cityOwnerText.text = "";
        forgeImage.gameObject.SetActive(false);
        infoPanel.SetActive(false);
    }
}
