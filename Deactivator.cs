using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivator : MonoBehaviour
{
    public GameObject uiElement1;
	public GameObject uiElement2;
	public GameObject uiElement3;
	public GameObject uiElement4;
	public GameObject uiElement5;
	public GameObject uiElement6;
	public GameObject uiElement7;
	public GameObject uiElement8;
	public GameObject uiElement9;
	public GameObject uiElement10;
	public GameObject uiElement11;
	public GameObject uiElement12;
	public GameObject uiElement13;
	public GameObject uiElement14;
	public GameObject uiElement15;
	
    void Start()
    {
        // Деактивируем все элементы UI при старте
        DeactivateUIElements();
    }

    // Метод для деактивации элементов UI
    public void DeactivateUIElements()
    {
        uiElement1.SetActive(false);
		uiElement2.SetActive(false);
        uiElement3.SetActive(false);
		uiElement4.SetActive(false);
		uiElement5.SetActive(false);
		uiElement6.SetActive(false);
		uiElement7.SetActive(false);
		uiElement8.SetActive(false);
		uiElement9.SetActive(false);
		uiElement10.SetActive(false);
		uiElement11.SetActive(false);
		uiElement12.SetActive(false);
		uiElement13.SetActive(false);
		uiElement14.SetActive(false);
		uiElement15.SetActive(false);
    }
}
