using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FarmUI : MonoBehaviour
{
	public Farm selectedFarm;
	
	public GameObject FarmUIPanel;
	
	public Button CarrotButton;
	public TextMeshProUGUI CarrotText;
	public Button GrainButton;
	public TextMeshProUGUI GrainText;
	public Button TomatoButton;
	public TextMeshProUGUI TomatoText;
	public Button FlaxButton;
	public TextMeshProUGUI FlaxText;
	
	public void Start()
	{
		FarmUIPanel.SetActive(false);
	}
	
	public void OpenFarmChoise(Farm farm)
	{
		FarmUIPanel.SetActive(false);
		selectedFarm = farm;
		TomatoText.text = "Count: " + selectedFarm.TomatoCount;
		CarrotText.text = "Count: " + selectedFarm.CarrotCount;
		FlaxText.text = "Count: " + selectedFarm.FlaxCount;
		GrainText.text = "Count: " + selectedFarm.GrainCount;
		
		if(selectedFarm.CurrentFarm == "Tomato")
		{
			TomatoButton.interactable = false;
		
			CarrotButton.interactable = true;
			FlaxButton.interactable = true;
			GrainButton.interactable = true;
		}
		if(selectedFarm.CurrentFarm == "Carrot")
		{
			CarrotButton.interactable = false;
		
			TomatoButton.interactable = true;
			FlaxButton.interactable = true;
			GrainButton.interactable = true;
		}
		if(selectedFarm.CurrentFarm == "Flax")
		{
			FlaxButton.interactable = false;
			
			TomatoButton.interactable = true;
			CarrotButton.interactable = true;
			GrainButton.interactable = true;
		}
		if(selectedFarm.CurrentFarm == "Grain")
		{
			GrainButton.interactable = false;
			
			TomatoButton.interactable = true;
			CarrotButton.interactable = true;
			FlaxButton.interactable = true;
		}
	}
	
	public void ChoseTomato()
	{
		TomatoButton.interactable = false;
		
		CarrotButton.interactable = true;
		FlaxButton.interactable = true;
		GrainButton.interactable = true;
		
		selectedFarm.CurrentFarm = "Tomato";
	}
	
	public void ChoseCarrot()
	{
		CarrotButton.interactable = false;
		
		TomatoButton.interactable = true;
		FlaxButton.interactable = true;
		GrainButton.interactable = true;
		
		selectedFarm.CurrentFarm = "Carrot";
	}
	
	public void ChoseFlax()
	{
		FlaxButton.interactable = false;
		
		TomatoButton.interactable = true;
		CarrotButton.interactable = true;
		GrainButton.interactable = true;
		
		selectedFarm.CurrentFarm = "Flax";
	}
	
	public void ChoseGrain()
	{
		GrainButton.interactable = false;
		
		TomatoButton.interactable = true;
		CarrotButton.interactable = true;
		FlaxButton.interactable = true;
		
		selectedFarm.CurrentFarm = "Grain";
	}
}
