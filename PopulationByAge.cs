using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopulationByAge : MonoBehaviour
{
    public GameObject PopulationPanel;
	public CityInventoryUI cityInventoryUI;
	public SmallCity chosenCity;
	
	public TextMeshProUGUI Age1;
	public TextMeshProUGUI Age2;
	public TextMeshProUGUI Age3;
	public TextMeshProUGUI Age4;
	public TextMeshProUGUI Age5;
	public TextMeshProUGUI Age6;
	public TextMeshProUGUI Age7;
	public TextMeshProUGUI Age8;
	public TextMeshProUGUI Age9;
	public TextMeshProUGUI Age10;
	
	public TextMeshProUGUI Man1;
	public TextMeshProUGUI Man2;
	public TextMeshProUGUI Man3;
	public TextMeshProUGUI Man4;
	public TextMeshProUGUI Man5;
	public TextMeshProUGUI Man6;
	public TextMeshProUGUI Man7;
	public TextMeshProUGUI Man8;
	public TextMeshProUGUI Man9;
	public TextMeshProUGUI Man10;
	
	public TextMeshProUGUI Woman1;
	public TextMeshProUGUI Woman2;
	public TextMeshProUGUI Woman3;
	public TextMeshProUGUI Woman4;
	public TextMeshProUGUI Woman5;
	public TextMeshProUGUI Woman6;
	public TextMeshProUGUI Woman7;
	public TextMeshProUGUI Woman8;
	public TextMeshProUGUI Woman9;
	public TextMeshProUGUI Woman10;
	
	public TextMeshProUGUI NewbornM;
	public TextMeshProUGUI NewbornW;
	
	public void OpenPopulationListFromScript(SmallCity smallCity)
	{
		chosenCity = smallCity;
		PopulationPanel.SetActive(true);
		cityInventoryUI.CloseInventoryUI();
		cityInventoryUI.characterInventoryUI.CityOrForgeInvButtonObj.SetActive(false);
		cityInventoryUI.characterInventoryUI.characterInventoryPanel.SetActive(false);
		NewbornM.text = chosenCity.PopulationAge0M.ToString();
		NewbornW.text = chosenCity.PopulationAge0W.ToString();
	}
	
	public void OpenPopulation1()
	{
		Age1.text = "1";
		Age2.text = "2";
		Age3.text = "3";
		Age4.text = "4";
		Age5.text = "5";
		Age6.text = "6";
		Age7.text = "7";
		Age8.text = "8";
		Age9.text = "9";
		Age10.text = "10";
		
		Man1.text = chosenCity.PopulationAge1M.ToString();
		Man2.text = chosenCity.PopulationAge2M.ToString();
		Man3.text = chosenCity.PopulationAge3M.ToString();
		Man4.text = chosenCity.PopulationAge4M.ToString();
		Man5.text = chosenCity.PopulationAge5M.ToString();
		Man6.text = chosenCity.PopulationAge6M.ToString();
		Man7.text = chosenCity.PopulationAge7M.ToString();
		Man8.text = chosenCity.PopulationAge8M.ToString();
		Man9.text = chosenCity.PopulationAge9M.ToString();
		Man10.text = chosenCity.PopulationAge10M.ToString();
		
		Woman1.text = chosenCity.PopulationAge1W.ToString();
		Woman2.text = chosenCity.PopulationAge2W.ToString();
		Woman3.text = chosenCity.PopulationAge3W.ToString();
		Woman4.text = chosenCity.PopulationAge4W.ToString();
		Woman5.text = chosenCity.PopulationAge5W.ToString();
		Woman6.text = chosenCity.PopulationAge6W.ToString();
		Woman7.text = chosenCity.PopulationAge7W.ToString();
		Woman8.text = chosenCity.PopulationAge8W.ToString();
		Woman9.text = chosenCity.PopulationAge9W.ToString();
		Woman10.text = chosenCity.PopulationAge10W.ToString();
	}
	
	public void OpenPopulation2()
	{
		Age1.text = "11";
		Age2.text = "12";
		Age3.text = "13";
		Age4.text = "14";
		Age5.text = "15";
		Age6.text = "16";
		Age7.text = "17";
		Age8.text = "18";
		Age9.text = "19";
		Age10.text = "20";
		
		Man1.text = chosenCity.PopulationAge11M.ToString();
		Man2.text = chosenCity.PopulationAge12M.ToString();
		Man3.text = chosenCity.PopulationAge13M.ToString();
		Man4.text = chosenCity.PopulationAge14M.ToString();
		Man5.text = chosenCity.PopulationAge15M.ToString();
		Man6.text = chosenCity.PopulationAge16M.ToString();
		Man7.text = chosenCity.PopulationAge17M.ToString();
		Man8.text = chosenCity.PopulationAge18M.ToString();
		Man9.text = chosenCity.PopulationAge19M.ToString();
		Man10.text = chosenCity.PopulationAge20M.ToString();
		
		Woman1.text = chosenCity.PopulationAge11W.ToString();
		Woman2.text = chosenCity.PopulationAge12W.ToString();
		Woman3.text = chosenCity.PopulationAge13W.ToString();
		Woman4.text = chosenCity.PopulationAge14W.ToString();
		Woman5.text = chosenCity.PopulationAge15W.ToString();
		Woman6.text = chosenCity.PopulationAge16W.ToString();
		Woman7.text = chosenCity.PopulationAge17W.ToString();
		Woman8.text = chosenCity.PopulationAge18W.ToString();
		Woman9.text = chosenCity.PopulationAge19W.ToString();
		Woman10.text = chosenCity.PopulationAge20W.ToString();
	}
	
	public void OpenPopulation3()
	{
		Age1.text = "21";
		Age2.text = "22";
		Age3.text = "23";
		Age4.text = "24";
		Age5.text = "25";
		Age6.text = "26";
		Age7.text = "27";
		Age8.text = "28";
		Age9.text = "29";
		Age10.text = "30";
		
		Man1.text = chosenCity.PopulationAge21M.ToString();
		Man2.text = chosenCity.PopulationAge22M.ToString();
		Man3.text = chosenCity.PopulationAge23M.ToString();
		Man4.text = chosenCity.PopulationAge24M.ToString();
		Man5.text = chosenCity.PopulationAge25M.ToString();
		Man6.text = chosenCity.PopulationAge26M.ToString();
		Man7.text = chosenCity.PopulationAge27M.ToString();
		Man8.text = chosenCity.PopulationAge28M.ToString();
		Man9.text = chosenCity.PopulationAge29M.ToString();
		Man10.text = chosenCity.PopulationAge30M.ToString();
		
		Woman1.text = chosenCity.PopulationAge21W.ToString();
		Woman2.text = chosenCity.PopulationAge22W.ToString();
		Woman3.text = chosenCity.PopulationAge23W.ToString();
		Woman4.text = chosenCity.PopulationAge24W.ToString();
		Woman5.text = chosenCity.PopulationAge25W.ToString();
		Woman6.text = chosenCity.PopulationAge26W.ToString();
		Woman7.text = chosenCity.PopulationAge27W.ToString();
		Woman8.text = chosenCity.PopulationAge28W.ToString();
		Woman9.text = chosenCity.PopulationAge29W.ToString();
		Woman10.text = chosenCity.PopulationAge30W.ToString();
	}
	
	public void OpenPopulation4()
	{
		Age1.text = "31";
		Age2.text = "32";
		Age3.text = "33";
		Age4.text = "34";
		Age5.text = "35";
		Age6.text = "36";
		Age7.text = "37";
		Age8.text = "38";
		Age9.text = "39";
		Age10.text = "40";
		
		Man1.text = chosenCity.PopulationAge31M.ToString();
		Man2.text = chosenCity.PopulationAge32M.ToString();
		Man3.text = chosenCity.PopulationAge33M.ToString();
		Man4.text = chosenCity.PopulationAge34M.ToString();
		Man5.text = chosenCity.PopulationAge35M.ToString();
		Man6.text = chosenCity.PopulationAge36M.ToString();
		Man7.text = chosenCity.PopulationAge37M.ToString();
		Man8.text = chosenCity.PopulationAge38M.ToString();
		Man9.text = chosenCity.PopulationAge39M.ToString();
		Man10.text = chosenCity.PopulationAge40M.ToString();
		
		Woman1.text = chosenCity.PopulationAge31W.ToString();
		Woman2.text = chosenCity.PopulationAge32W.ToString();
		Woman3.text = chosenCity.PopulationAge33W.ToString();
		Woman4.text = chosenCity.PopulationAge34W.ToString();
		Woman5.text = chosenCity.PopulationAge35W.ToString();
		Woman6.text = chosenCity.PopulationAge36W.ToString();
		Woman7.text = chosenCity.PopulationAge37W.ToString();
		Woman8.text = chosenCity.PopulationAge38W.ToString();
		Woman9.text = chosenCity.PopulationAge39W.ToString();
		Woman10.text = chosenCity.PopulationAge40W.ToString();
	}
	
	public void OpenPopulation5()
	{
		Age1.text = "41";
		Age2.text = "42";
		Age3.text = "43";
		Age4.text = "44";
		Age5.text = "45";
		Age6.text = "46";
		Age7.text = "47";
		Age8.text = "48";
		Age9.text = "49";
		Age10.text = "50";
		
		Man1.text = chosenCity.PopulationAge41M.ToString();
		Man2.text = chosenCity.PopulationAge42M.ToString();
		Man3.text = chosenCity.PopulationAge43M.ToString();
		Man4.text = chosenCity.PopulationAge44M.ToString();
		Man5.text = chosenCity.PopulationAge45M.ToString();
		Man6.text = chosenCity.PopulationAge46M.ToString();
		Man7.text = chosenCity.PopulationAge47M.ToString();
		Man8.text = chosenCity.PopulationAge48M.ToString();
		Man9.text = chosenCity.PopulationAge49M.ToString();
		Man10.text = chosenCity.PopulationAge50M.ToString();
		
		Woman1.text = chosenCity.PopulationAge41W.ToString();
		Woman2.text = chosenCity.PopulationAge42W.ToString();
		Woman3.text = chosenCity.PopulationAge43W.ToString();
		Woman4.text = chosenCity.PopulationAge44W.ToString();
		Woman5.text = chosenCity.PopulationAge45W.ToString();
		Woman6.text = chosenCity.PopulationAge46W.ToString();
		Woman7.text = chosenCity.PopulationAge47W.ToString();
		Woman8.text = chosenCity.PopulationAge48W.ToString();
		Woman9.text = chosenCity.PopulationAge49W.ToString();
		Woman10.text = chosenCity.PopulationAge50W.ToString();
	}
	
	public void OpenPopulation6()
	{
		Age1.text = "51";
		Age2.text = "52";
		Age3.text = "53";
		Age4.text = "54";
		Age5.text = "55";
		Age6.text = "56";
		Age7.text = "57";
		Age8.text = "58";
		Age9.text = "59";
		Age10.text = "60";
		
		Man1.text = chosenCity.PopulationAge51M.ToString();
		Man2.text = chosenCity.PopulationAge52M.ToString();
		Man3.text = chosenCity.PopulationAge53M.ToString();
		Man4.text = chosenCity.PopulationAge54M.ToString();
		Man5.text = chosenCity.PopulationAge55M.ToString();
		Man6.text = chosenCity.PopulationAge56M.ToString();
		Man7.text = chosenCity.PopulationAge57M.ToString();
		Man8.text = chosenCity.PopulationAge58M.ToString();
		Man9.text = chosenCity.PopulationAge59M.ToString();
		Man10.text = chosenCity.PopulationAge60M.ToString();
		
		Woman1.text = chosenCity.PopulationAge51W.ToString();
		Woman2.text = chosenCity.PopulationAge52W.ToString();
		Woman3.text = chosenCity.PopulationAge53W.ToString();
		Woman4.text = chosenCity.PopulationAge54W.ToString();
		Woman5.text = chosenCity.PopulationAge55W.ToString();
		Woman6.text = chosenCity.PopulationAge56W.ToString();
		Woman7.text = chosenCity.PopulationAge57W.ToString();
		Woman8.text = chosenCity.PopulationAge58W.ToString();
		Woman9.text = chosenCity.PopulationAge59W.ToString();
		Woman10.text = chosenCity.PopulationAge60W.ToString();
	}
	
	public void OpenPopulation7()
	{
		Age1.text = "61";
		Age2.text = "62";
		Age3.text = "63";
		Age4.text = "64";
		Age5.text = "65";
		Age6.text = "66";
		Age7.text = "67";
		Age8.text = "68";
		Age9.text = "69";
		Age10.text = "70+";
		
		Man1.text = chosenCity.PopulationAge61M.ToString();
		Man2.text = chosenCity.PopulationAge62M.ToString();
		Man3.text = chosenCity.PopulationAge63M.ToString();
		Man4.text = chosenCity.PopulationAge64M.ToString();
		Man5.text = chosenCity.PopulationAge65M.ToString();
		Man6.text = chosenCity.PopulationAge66M.ToString();
		Man7.text = chosenCity.PopulationAge67M.ToString();
		Man8.text = chosenCity.PopulationAge68M.ToString();
		Man9.text = chosenCity.PopulationAge69M.ToString();
		Man10.text = chosenCity.PopulationAge70M.ToString();
		
		Woman1.text = chosenCity.PopulationAge61W.ToString();
		Woman2.text = chosenCity.PopulationAge62W.ToString();
		Woman3.text = chosenCity.PopulationAge63W.ToString();
		Woman4.text = chosenCity.PopulationAge64W.ToString();
		Woman5.text = chosenCity.PopulationAge65W.ToString();
		Woman6.text = chosenCity.PopulationAge66W.ToString();
		Woman7.text = chosenCity.PopulationAge67W.ToString();
		Woman8.text = chosenCity.PopulationAge68W.ToString();
		Woman9.text = chosenCity.PopulationAge69W.ToString();
		Woman10.text = chosenCity.PopulationAge70W.ToString();
	}
	
	public void ClosePopulationList()
	{
		PopulationPanel.SetActive(false);
		
		Age1.text = "";
		Age2.text = "";
		Age3.text = "";
		Age4.text = "";
		Age5.text = "";
		Age6.text = "";
		Age7.text = "";
		Age8.text = "";
		Age9.text = "";
		Age10.text = "";
		
		Man1.text = "";
		Man2.text = "";
		Man3.text = "";
		Man4.text = "";
		Man5.text = "";
		Man6.text = "";
		Man7.text = "";
		Man8.text = "";
		Man9.text = "";
		Man10.text = "";
		
		Woman1.text = "";
		Woman2.text = "";
		Woman3.text = "";
		Woman4.text = "";
		Woman5.text = "";
		Woman6.text = "";
		Woman7.text = "";
		Woman8.text = "";
		Woman9.text = "";
		Woman10.text = "";
		
		NewbornM.text = "";
		NewbornW.text = "";
	}
}
