using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkirmishMenu : MonoBehaviour
{
	public GameObject mainMenu;
	public GameObject skirmishMenu;
	public GameObject turnCounter;
	public GameObject endTurn;
	public GameObject Player1;
	public GameObject Player2;
	public GameObject Player3;
	public GameObject Player4;
	public GameObject Player1Chose;
	public GameObject Player2Chose;
	public GameObject Player3Chose;
	public GameObject Player4Chose;
	public GridGenerator gridGenerator;
    public TMP_InputField gridSizeXInput;
    public TMP_InputField gridSizeYInput;
	public TMP_InputField numberOfPlayers;
    public Button generateButton;
    public Button backButton;
	public int cityNumberToMake;
	public PlayerControllers playerControllers;

    void Start()
    {
        // Прикрепляем функции к событиям клика на кнопках
        generateButton.onClick.AddListener(GridData);
        backButton.onClick.AddListener(BackToMainMenu);
		
        gridSizeXInput.characterValidation = TMP_InputField.CharacterValidation.Integer;
        gridSizeYInput.characterValidation = TMP_InputField.CharacterValidation.Integer;
		numberOfPlayers.characterValidation = TMP_InputField.CharacterValidation.Integer;

        gridSizeXInput.onValueChanged.AddListener(OnInputValueChanged);
        gridSizeYInput.onValueChanged.AddListener(OnInputValueChanged);
		numberOfPlayers.onValueChanged.AddListener(OnInputValueChangedPlayer);
		Player1.SetActive(false);
		Player2.SetActive(false);
		Player3.SetActive(false);
		Player4.SetActive(false);
		Player1Chose.SetActive(false);
		Player2Chose.SetActive(false);
		Player3Chose.SetActive(false);
		Player4Chose.SetActive(false);
    }

	void GridData()
	{
		// Проверяем ввод на числа
		if (int.TryParse(gridSizeXInput.text, out int x) && int.TryParse(gridSizeYInput.text, out int y))
		{
			if (int.TryParse(numberOfPlayers.text, out int number))
			{
				if (gridGenerator != null)
				{
					gridGenerator.SetGridSize(x, y, cityNumberToMake);
					skirmishMenu.SetActive(false);
					turnCounter.SetActive(true);
					endTurn.SetActive(true);
					gridGenerator.GenerateGrid();
				}
			}
		}
	}

    void BackToMainMenu()
    {
        // Загружаем сцену с основным меню
        skirmishMenu.SetActive(false);
		mainMenu.SetActive(true);
    }
	
    void OnInputValueChanged(string newValue)
    {
        // Удаляем все символы, кроме цифр
        string filteredValue = new string(newValue.Where(char.IsDigit).ToArray());

        // Обновляем значение в поле ввода
        if (gridSizeXInput.text == newValue)
        {
            gridSizeXInput.text = filteredValue;
        }
        else if (gridSizeYInput.text == newValue)
        {
            gridSizeYInput.text = filteredValue;
        }

        // Проверяем, если введенное значение меньше 1, заменяем его на 10
        if (int.TryParse(filteredValue, out int value) && value < 1)
        {
            if (gridSizeXInput.text == newValue)
            {
                gridSizeXInput.text = "10";
            }
            else if (gridSizeYInput.text == newValue)
            {
                gridSizeYInput.text = "10";
            }
        }
    }
	
	void OnInputValueChangedPlayer(string newValue)
    {
        // Удаляем все символы, кроме цифр
        string filteredValue = new string(newValue.Where(char.IsDigit).ToArray());

        // Обновляем значение в поле ввода
        if (numberOfPlayers.text == newValue)
        {
            numberOfPlayers.text = filteredValue;
        }

		if (int.TryParse(filteredValue, out int value))
		{
			if (numberOfPlayers.text == newValue && value < 2)
			{
				numberOfPlayers.text = "2";
				Player1.SetActive(true);
				Player2.SetActive(true);
				Player1Chose.SetActive(true);
				Player2Chose.SetActive(true);
				Player3.SetActive(false);
				Player4.SetActive(false);
				Player3Chose.SetActive(false);
				Player4Chose.SetActive(false);
				cityNumberToMake = 2;
			}
			else if (numberOfPlayers.text == newValue && value > 4)
			{
				numberOfPlayers.text = "4";
				Player1.SetActive(true);
				Player2.SetActive(true);
				Player3.SetActive(true);
				Player4.SetActive(true);
				Player1Chose.SetActive(true);
				Player2Chose.SetActive(true);
				Player3Chose.SetActive(true);
				Player4Chose.SetActive(true);
				cityNumberToMake = 4;
			}
			else if (numberOfPlayers.text == newValue && value == 2)
			{
				Player1.SetActive(true);
				Player2.SetActive(true);
				Player1Chose.SetActive(true);
				Player2Chose.SetActive(true);
				Player3.SetActive(false);
				Player4.SetActive(false);
				Player3Chose.SetActive(false);
				Player4Chose.SetActive(false);
				cityNumberToMake = 2;
			}
			else if (numberOfPlayers.text == newValue && value == 3)
			{
				Player1.SetActive(true);
				Player2.SetActive(true);
				Player3.SetActive(true);
				Player1Chose.SetActive(true);
				Player2Chose.SetActive(true);
				Player3Chose.SetActive(true);
				Player4.SetActive(false);
				Player4Chose.SetActive(false);
				cityNumberToMake = 3;
			}
			else if (numberOfPlayers.text == newValue && value == 4)
			{
				Player1.SetActive(true);
				Player2.SetActive(true);
				Player3.SetActive(true);
				Player4.SetActive(true);
				Player1Chose.SetActive(true);
				Player2Chose.SetActive(true);
				Player3Chose.SetActive(true);
				Player4Chose.SetActive(true);
				cityNumberToMake = 4;
			}
		}
    }
	
	public void Player1Menu(int value)
	{
		if (value == 0)
		{
			playerControllers.Player1Controller = 0;
		}
	}
	
	public void Player2Menu(int value)
	{
		if (value == 0)
		{
			playerControllers.Player2Controller = 0;
		}
		else if (value == 1)
		{
			playerControllers.Player2Controller = 1;
		}
		else if (value == 2)
		{
			playerControllers.Player2Controller = 2;
		}
	}
	
	public void Player3Menu(int value)
	{
		if (value == 0)
		{
			playerControllers.Player3Controller = 0;
		}
		else if (value == 1)
		{
			playerControllers.Player3Controller = 1;
		}
		else if (value == 2)
		{
			playerControllers.Player3Controller = 2;
		}
	}
	
	public void Player4Menu(int value)
	{
		if (value == 0)
		{
			playerControllers.Player4Controller = 0;
		}
		else if (value == 1)
		{
			playerControllers.Player4Controller = 1;
		}
		else if (value == 2)
		{
			playerControllers.Player4Controller = 2;
		}
	}
}