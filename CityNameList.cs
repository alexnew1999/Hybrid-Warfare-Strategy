using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityNameList : MonoBehaviour
{
    // Список предварительно заданных имен
    public string[] cityNames = new string[]
    {
        "Warsaw",
        "Prague",
        "Budapest",
        "Belgrade",
        "Sofia",
        "Kiev",
		"Bratislava",
        "Ljubljana",
        "Riga",
		"Vilnius",
        "Tallinn",
        "Zagreb",
        "Minsk",
        "Bucharest",
        "Sarajevo",
		"Skopje",
        "Brno",
        "Krakow",
		"Gdansk",
        "Odessa",
        "Cluj-Napoca",
        "Kaunas",
        "Lublin",
        "Varna",
		"Ostrava",
        "Lviv",
        "Tirana",
		"Plovdiv",
        "Tartu",
        "Kosice",
        "Timisoara",
        "Banska Bystrica",
        "Chernivtsi",
		"Novi Sad",
        "Klaipeda",
        "Pecs",
        "Gyor",
		"Debrecen",
        "Kragujevac",
        "Oradea",
    };
	
	public string GetRandomCityName()
    {
        if (cityNames != null && cityNames.Length > 0)
        {
            int randomIndex = Random.Range(0, cityNames.Length);
            return cityNames[randomIndex];
        }
        else
        {
            Debug.LogWarning("CityNames array is empty or null. Please assign a valid list of city names.");
            return "DefaultCityName";
        }
    }
}
