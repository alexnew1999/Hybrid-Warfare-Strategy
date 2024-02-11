using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 10;
    public float zoomSpeed = 5;
    public float minScale = 0.5f;
    public float maxScale = 2.0f;

    private void Update()
    {
        // Перемещение камеры с помощью клавиатуры
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        Camera.main.transform.Translate(moveDirection * dragSpeed * Time.deltaTime);

        // Перетаскивание камеры средней кнопкой мыши
        if (Input.GetMouseButton(2)) // 2 соответствует средней кнопке мыши
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            Vector3 dragDirection = new Vector3(-mouseX, -mouseY, 0);
            Camera.main.transform.Translate(dragDirection * dragSpeed * Time.deltaTime);
        }

        // Изменение масштаба при прокрутке колесика
        float scrollDelta = Input.mouseScrollDelta.y;
        float scaleDelta = scrollDelta * zoomSpeed * Time.deltaTime;
        Vector3 newScale = transform.localScale + new Vector3(scaleDelta, scaleDelta, 0);

        // Ограничиваем масштаб в пределах, которые вам нужны
        newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
        newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);

        // Устанавливаем новый масштаб
        transform.localScale = newScale;

        // Проверка, если курсор мыши находится у краев экрана
        //if (Input.mousePosition.x < 10 || Input.mousePosition.x > Screen.width - 10 ||
        //    Input.mousePosition.y < 10 || Input.mousePosition.y > Screen.height - 10)
        //{
        //    // Определите, в каком направлении нужно двигать камеру
        //    Vector3 cameraMoveDirection = new Vector3(0, 0, 0);
        //    
        //    if (Input.mousePosition.x < 10)
        //    {
        //        cameraMoveDirection.x = -1;
        //    }
        //    else if (Input.mousePosition.x > Screen.width - 10)
        //    {
        //        cameraMoveDirection.x = 1;
        //    }
        //    
        //    if (Input.mousePosition.y < 10)
        //    {
        //        cameraMoveDirection.y = -1;
        //    }
        //    else if (Input.mousePosition.y > Screen.height - 10)
        //    {
        //        cameraMoveDirection.y = 1;
        //    }
        //    
        //    // Переместите камеру в заданном направлении
        //    Camera.main.transform.Translate(cameraMoveDirection * dragSpeed * Time.deltaTime);
        //}
    }
}