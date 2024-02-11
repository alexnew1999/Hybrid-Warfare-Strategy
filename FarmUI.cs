using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
			TomatoButton.interactible = false;
		
			CarrotButton.interactible = true;
			FlaxButton.interactible = true;
			GrainButton.interactible = true;
		}
		if(selectedFarm.CurrentFarm == "Carrot")
		{
			CarrotButton.interactible = false;
		
			TomatoButton.interactible = true;
			FlaxButton.interactible = true;
			GrainButton.interactible = true;
		}
		if(selectedFarm.CurrentFarm == "Flax")
		{
			FlaxButton.interactible = false;
			
			TomatoButton.interactible = true;
			CarrotButton.interactible = true;
			GrainButton.interactible = true;
		}
		if(selectedFarm.CurrentFarm == "Grain")
		{
			GrainButton.interactible = false;
			
			TomatoButton.interactible = true;
			CarrotButton.interactible = true;
			FlaxButton.interactible = true;
		}
	}
	
	public void ChoseTomato()
	{
		TomatoButton.interactible = false;
		
		CarrotButton.interactible = true;
		FlaxButton.interactible = true;
		GrainButton.interactible = true;
		
		selectedFarm.CurrentFarm = "Tomato";
	}
	
	public void ChoseCarrot()
	{
		CarrotButton.interactible = false;
		
		TomatoButton.interactible = true;
		FlaxButton.interactible = true;
		GrainButton.interactible = true;
		
		selectedFarm.CurrentFarm = "Carrot";
	}
	
	public void ChoseFlax()
	{
		FlaxButton.interactible = false;
		
		TomatoButton.interactible = true;
		CarrotButton.interactible = true;
		GrainButton.interactible = true;
		
		selectedFarm.CurrentFarm = "Flax";
	}
	
	public void ChoseGrain()
	{
		GrainButton.interactible = false;
		
		TomatoButton.interactible = true;
		CarrotButton.interactible = true;
		FlaxButton.interactible = true;
		
		selectedFarm.CurrentFarm = "Grain";
	}
}
