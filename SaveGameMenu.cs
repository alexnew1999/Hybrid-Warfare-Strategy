using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveGameMenu : MonoBehaviour
{
	public GameObject escMenu;
	public GameObject saveGameMenu;
	public GameObject saveInputMenu;
    public Button saveSaveGame1;
	public Button saveSaveGame2;
	public Button saveSaveGame3;
    public Button saveSaveGame4;
	public TextMeshProUGUI SaveGame1Text;
	public TextMeshProUGUI SaveGame2Text;
	public TextMeshProUGUI SaveGame3Text;
	public TextMeshProUGUI SaveGame4Text;
	public Button OKButton;
    public Button backButton;
	public Button backToSavesButton;
	public TMP_InputField savegameName;
	public int SaveNumber1 = 0;
	public int SaveNumber2 = 0;
	public int SaveNumber3 = 0;
	public int SaveNumber4 = 0;
	public string SaveFileName1 = "No saved data.";
	public string SaveFileName2 = "No saved data.";
	public string SaveFileName3 = "No saved data.";
	public string SaveFileName4 = "No saved data.";
	
	private void Start()
    {
        // Прикрепляем функции к событиям клика на кнопках
        backButton.onClick.AddListener(BackToMenu);
		backToSavesButton.onClick.AddListener(BackToSaves);
		saveSaveGame1.onClick.AddListener(SaveSaveGame1);
		saveSaveGame2.onClick.AddListener(SaveSaveGame2);
		saveSaveGame3.onClick.AddListener(SaveSaveGame3);
		saveSaveGame4.onClick.AddListener(SaveSaveGame4);
		OKButton.onClick.AddListener(SaveGame);
		OKButton.onClick.AddListener(BackToSaves);
		saveGameMenu.SetActive(false);
		saveInputMenu.SetActive(false);
    }
	
	private void BackToMenu()
    {
        saveGameMenu.SetActive(false);
		escMenu.SetActive(true);
    }
	
	private void BackToSaves()
    {
		saveInputMenu.SetActive(false);
		SaveNumber1 = 0;
		SaveNumber2 = 0;
		SaveNumber3 = 0;
		SaveNumber4 = 0;
    }
	
	void SaveGame()
	{
		if (SaveNumber1 == 1)
		{
			SaveFileName1 = savegameName.text;
			SaveGame1Text.text = SaveFileName1;
			savegameName.text = "";
			SaveLoadManager.SaveGame(SaveFileName1);
		}
		else if (SaveNumber2 == 1)
		{
			SaveFileName2 = savegameName.text;
			SaveGame2Text.text = SaveFileName2;
			savegameName.text = "";
			SaveLoadManager.SaveGame(SaveFileName2);
		}
		else if (SaveNumber3 == 1)
		{
			SaveFileName3 = savegameName.text;
			SaveGame3Text.text = SaveFileName3;
			savegameName.text = "";
			SaveLoadManager.SaveGame(SaveFileName3);
		}
		else if (SaveNumber4 == 1)
		{
			SaveFileName4 = savegameName.text;
			SaveGame4Text.text = SaveFileName4;
			savegameName.text = "";
			SaveLoadManager.SaveGame(SaveFileName4);
		}
		SaveNumber1 = 0;
		SaveNumber2 = 0;
		SaveNumber3 = 0;
		SaveNumber4 = 0;
		saveInputMenu.SetActive(false);
	}
	
	private void SaveSaveGame1()
    {
		SaveNumber1 = 1;
		saveInputMenu.SetActive(true);
    }
	
	private void SaveSaveGame2()
    {
		SaveNumber2 = 1;
		saveInputMenu.SetActive(true);
    }
	
	private void SaveSaveGame3()
    {
		SaveNumber3 = 1;
		saveInputMenu.SetActive(true);
    }
	
	private void SaveSaveGame4()
    {
		SaveNumber4 = 1;
		saveInputMenu.SetActive(true);
    }
}
