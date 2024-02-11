using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExitConfirmation : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;
	public GameObject dialogBox;
	public GameObject whiteBackground;

    private void Start()
    {
        dialogBox.SetActive(false);
		whiteBackground.SetActive(false);
		        
        yesButton.onClick.AddListener(ExitGame);
        noButton.onClick.AddListener(BackToMenu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
	
	public void BackToMenu()
    {
        dialogBox.SetActive(false);
		whiteBackground.SetActive(false);
    }
}
