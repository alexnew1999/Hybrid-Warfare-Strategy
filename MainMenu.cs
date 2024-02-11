using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
	public GameObject mainMenu;
	public GameObject skirmishMenu;
	public GameObject multiplayerMenu;
	public GameObject loadGameMenuObject;
    public Button skirsmishButton;
	public Button multiplayerButton;
	public Button loadGameButton;
    public Button optionsButton;
    public Button quitButton;
	public NetworkGameManager networkGameManager;
	public SaveGameMenu saveGameMenu;
	public LoadGameMenu loadGameMenu;

    private void Start()
    {
        // Прикрепляем функции к событиям клика на кнопках
        skirsmishButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(OpenOptions);
		loadGameButton.onClick.AddListener(OpenLoadGame);
        quitButton.onClick.AddListener(QuitGame);
		multiplayerButton.onClick.AddListener(StartMultiplayerGame);
		skirmishMenu.SetActive(false);
    }

    private void StartGame()
    {
        skirmishMenu.SetActive(true);
		mainMenu.SetActive(false);
    }
	
	private void StartMultiplayerGame()
	{
		multiplayerMenu.SetActive(true);
		mainMenu.SetActive(false);
		networkGameManager.localhostText.text = "Host:" + NetworkGameManager.localhost;
		networkGameManager.portText.text = "Port:" + NetworkGameManager.port.ToString();
	}

    private void OpenLoadGame()
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
		loadGameMenu.FromWereOpened = 2;
        loadGameMenuObject.SetActive(true);
		mainMenu.SetActive(false);
    }

    private void OpenOptions()
    {

    }

    private void QuitGame()
    {
        // Завершаем приложение
        Application.Quit();
    }
}

