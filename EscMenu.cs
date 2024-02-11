using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EscMenu : MonoBehaviour
{
	public GameObject EscMenuObject;
	public GameObject loadGameMenuObject;
	public GameObject saveGameMenuObject;
	public GameObject exitMenu;
	public GameObject whiteBackground;
	public Button continiueButton;
	public Button loadGameButton;
	public Button saveGameButton;
	public Button optionsButton;
	public Button exitButton;
	public LoadGameMenu loadGameMenu;
	public SaveGameMenu saveGameMenu;
	private bool isDialogOpen = false;
	
	private void Start()
    {
        // Прикрепляем функции к событиям клика на кнопках
        continiueButton.onClick.AddListener(Continiue);
        optionsButton.onClick.AddListener(OpenOptions);
        loadGameButton.onClick.AddListener(OpenLoadGameMenu);
		saveGameButton.onClick.AddListener(OpenSaveGameMenu);
		exitButton.onClick.AddListener(OpenExitMenu);
		EscMenuObject.SetActive(false);
    }
	
	private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isDialogOpen)
            {
                CloseDialog();
            }
            else
            {
                OpenDialog();
            }
        }
    }
	
	private void OpenDialog()
    {
        isDialogOpen = true;
        EscMenuObject.SetActive(true);
    }

    private void CloseDialog()
    {
        isDialogOpen = false;
        EscMenuObject.SetActive(false);
    }
	
	private void Continiue()
	{
		EscMenuObject.SetActive(false);
	}
	
	private void OpenOptions()
	{
		
	}
	
	private void OpenLoadGameMenu()
	{
		if(saveGameMenu.SaveFileName1 != null)
		{
			loadGameMenu.SaveGame1Text.text = saveGameMenu.SaveFileName1;
		}
		if(saveGameMenu.SaveFileName2 != null)
		{
			loadGameMenu.SaveGame2Text.text = saveGameMenu.SaveFileName2;
		}
		if(saveGameMenu.SaveFileName3 != null)
		{
			loadGameMenu.SaveGame3Text.text = saveGameMenu.SaveFileName3;
		}
		if(saveGameMenu.SaveFileName4 != null)
		{
			loadGameMenu.SaveGame4Text.text = saveGameMenu.SaveFileName4;
		}
		EscMenuObject.SetActive(false);
		loadGameMenuObject.SetActive(true);
		loadGameMenu.FromWereOpened = 1;
	}
	
	private void OpenSaveGameMenu()
	{
		EscMenuObject.SetActive(false);
		saveGameMenuObject.SetActive(true);
	}
	
	private void OpenExitMenu()
	{
		EscMenuObject.SetActive(false);
		exitMenu.SetActive(true);
		whiteBackground.SetActive(true);
	}
}
