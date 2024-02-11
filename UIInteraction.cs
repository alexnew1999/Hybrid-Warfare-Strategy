using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInteraction : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private Transform itemBeingDragged;
    private Vector2 startPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        itemBeingDragged = transform;
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (itemBeingDragged != null)
        {
            // Перетаскиваем элемент
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            itemBeingDragged.position = new Vector2(newPosition.x, newPosition.y);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Здесь вы можете обработать завершение перетаскивания, например, определить, в какую ячейку был перемещен элемент.
        // Обновите инвентарь города и UI соответственно.
        itemBeingDragged = null;
    }
}