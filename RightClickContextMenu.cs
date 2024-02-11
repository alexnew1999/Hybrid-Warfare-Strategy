using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class RightClickContextMenu : MonoBehaviour, IPointerClickHandler
{
    public GameObject contextMenu; // Префаб контекстного меню
    private GameObject currentContextMenu;

    // Событие вызывается при нажатии на объект правой кнопкой мыши
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            ShowContextMenu(eventData.position); // Передаем позицию клика
        }
    }

    // Показать контекстное меню
    private void ShowContextMenu(Vector2 position)
    {
        if (contextMenu != null)
        {
            // Создать экземпляр контекстного меню в точке, где был сделан клик
            currentContextMenu = Instantiate(contextMenu, position, Quaternion.identity);
            
            // Найти кнопку "Back" в контекстном меню
            Button backButton = currentContextMenu.GetComponentInChildren<Button>();
            
            // Добавить обработчик события для кнопки "Back"
            if (backButton != null)
            {
                backButton.onClick.AddListener(HideContextMenu);
            }
        }
    }

    // Скрыть контекстное меню
    private void HideContextMenu()
    {
        if (currentContextMenu != null)
        {
            Destroy(currentContextMenu);
        }
    }
}