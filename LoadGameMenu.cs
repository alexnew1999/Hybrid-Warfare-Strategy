using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadGameMenu : MonoBehaviour
{
	public GameObject mainMenu;
	public GameObject escMenu;
	public GameObject loadGameMenu;
    public Button loadSaveGame1;
	public Button loadSaveGame2;
	public Button loadSaveGame3;
    public Button loadSaveGame4;
	public Button ActivateCustomMenu;
	public TextMeshProUGUI SaveGame1Text;
	public TextMeshProUGUI SaveGame2Text;
	public TextMeshProUGUI SaveGame3Text;
	public TextMeshProUGUI SaveGame4Text;
	public SaveGameMenu saveGameMenu;
    public Button backButton;
	public int FromWereOpened = 0;
	public GameObject customLoadMenu;   
	public TMP_InputField customLoadName;
	public Button Load;
    public Button Back;
	public string CustomSaveName;
	
	private void Start()
    {
        // Прикрепляем функции к событиям клика на кнопках
        backButton.onClick.AddListener(BackToMenu);
		loadSaveGame1.onClick.AddListener(LoadSaveGame1);
		loadSaveGame2.onClick.AddListener(LoadSaveGame2);
		loadSaveGame3.onClick.AddListener(LoadSaveGame3);
		loadSaveGame4.onClick.AddListener(LoadSaveGame4);
		ActivateCustomMenu.onClick.AddListener(CustomMenuActivator);
		customLoadName.onValueChanged.AddListener(OnInputValueChangedSaveName);
		Load.onClick.AddListener(LoadSavedGame);
		Back.onClick.AddListener(BackFromCustomInput);
		loadGameMenu.SetActive(false);
		customLoadMenu.SetActive(false);
    }
	
	private void LoadSavedGame()
	{
		if(CustomSaveName != null)
		{
			SaveLoadManager.LoadGame(CustomSaveName);
			customLoadMenu.SetActive(false);
			loadGameMenu.SetActive(false);
		}
	}
	
	private void OnInputValueChangedSaveName(string newValue)
    {
		CustomSaveName = newValue;
	}
	
	private void BackFromCustomInput()
    {
		customLoadMenu.SetActive(false);
    }
	
	private void CustomMenuActivator()
    {
		customLoadMenu.SetActive(true);
    }
	
	private void BackToMenu()
    {
		if(FromWereOpened == 2)
		{
			loadGameMenu.SetActive(false);
			mainMenu.SetActive(true);
			FromWereOpened = 0;
		}
		else if(FromWereOpened == 1)
		{
			loadGameMenu.SetActive(false);
			escMenu.SetActive(true);
			FromWereOpened = 0;
		}
    }
	
	private void LoadSaveGame1()
    {
		if(saveGameMenu.SaveFileName1 != null)
		{
			SaveLoadManager.LoadGame(saveGameMenu.SaveFileName1);
			loadGameMenu.SetActive(false);
		}
    }
	
	private void LoadSaveGame2()
    {
		if(saveGameMenu.SaveFileName2 != null)
		{
			SaveLoadManager.LoadGame(saveGameMenu.SaveFileName2);
			loadGameMenu.SetActive(false);
		}
    }
	
	private void LoadSaveGame3()
    {
		if(saveGameMenu.SaveFileName3 != null)
		{
			SaveLoadManager.LoadGame(saveGameMenu.SaveFileName3);
			loadGameMenu.SetActive(false);
		}
    }
	
	private void LoadSaveGame4()
    {
		if(saveGameMenu.SaveFileName4 != null)
		{
			SaveLoadManager.LoadGame(saveGameMenu.SaveFileName4);
			loadGameMenu.SetActive(false);
		}
    }
}
