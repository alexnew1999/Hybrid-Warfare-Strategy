using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CityManager : MonoBehaviour
{
    // Список городов и их CityID
    public List<CityData> cities = new List<CityData>();
	public CityInventoryUI cityInventoryUI;
	public Mobilization mobilization;

    // Класс для хранения данных о городе
    [System.Serializable]
    public class CityData
    {
        public int cityID; // Идентификатор города
        public int ownerPlayerID;
        public SmallCity smallCity; // Ссылка на скрипт SmallCity

        public CityData(int id)
        {
            cityID = id;
        }
    }

    // Метод для добавления города в список
	public void AddCity(int cityID, int ownerPlayerID, SmallCity  smallCity)
	{
		CityData cityData = new CityData(cityID);
		cityData.ownerPlayerID = ownerPlayerID;
		cityData.smallCity = smallCity;
		cities.Add(cityData);
	}

    // Метод для удаления города из списка по его идентификатору
    public void RemoveCity(int cityID)
    {
        CityData cityToRemove = cities.Find(city => city.cityID == cityID);
        cities.Remove(cityToRemove);
    }

    // Метод для получения выбранного города
    public SmallCity GetSelectedCity()
    {
        foreach (CityData cityData in cities)
        {
            if (cityData.smallCity != null && cityData.smallCity.isSelected)
            {
                return cityData.smallCity;
            }
        }
        return null; // Возвращаем null, если не найден выбранный город
    }

	public SmallCity GetCityByID(int cityID)
	{
		return cities.FirstOrDefault(cityData => cityData.cityID == cityID)?.smallCity;
	}
	
	public void MobilizeCity(int cityID)
    {
        SmallCity city = GetCityByID(cityID);
        CityInventory cityInventory = cityInventoryUI.FindCityInventory(cityID);

        if (city != null && cityInventory != null && city.MobilizationInProgress)
        {
            if (cityInventory.GetFreeCharacterObjectIndex() != -1)
            {
				int totalRecruitsNeeded = 100;
				int numAgeGroups = 45 - 18 + 1;
				int recruitsPerGroup = totalRecruitsNeeded / numAgeGroups;
				Debug.Log("recruitsPerGroup: " + recruitsPerGroup);
				if(city.PopulationAge18M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge18M = city.PopulationAge18M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge19M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge19M = city.PopulationAge19M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge20M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge20M = city.PopulationAge20M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge21M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge21M = city.PopulationAge21M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge23M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge23M = city.PopulationAge23M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge23M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge23M = city.PopulationAge23M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge24M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge24M = city.PopulationAge24M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge25M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge25M = city.PopulationAge25M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge26M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge26M = city.PopulationAge26M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge27M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge27M = city.PopulationAge27M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge28M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge28M = city.PopulationAge28M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge29M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge29M = city.PopulationAge29M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge30M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge30M = city.PopulationAge30M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge31M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge31M = city.PopulationAge31M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge32M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge32M = city.PopulationAge32M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge33M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge33M = city.PopulationAge33M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge34M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge34M = city.PopulationAge34M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge35M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge35M = city.PopulationAge35M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge36M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge36M = city.PopulationAge36M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge37M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge37M = city.PopulationAge37M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge38M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge38M = city.PopulationAge38M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge39M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge39M = city.PopulationAge39M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge40M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge40M = city.PopulationAge40M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge41M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge41M = city.PopulationAge41M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge42M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge42M = city.PopulationAge42M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge43M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge43M = city.PopulationAge43M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge44M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge44M = city.PopulationAge44M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				if(city.PopulationAge45M >= recruitsPerGroup && totalRecruitsNeeded >= 0)
				{
					city.PopulationAge45M = city.PopulationAge45M - recruitsPerGroup;
					totalRecruitsNeeded -= recruitsPerGroup;
					Debug.Log("totalRecruitsNeeded: " + totalRecruitsNeeded);
				}
				while (totalRecruitsNeeded > 0)
				{
					if(city.PopulationAge18M > 0)
					{
						city.PopulationAge18M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge19M > 0)
					{
						city.PopulationAge19M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge20M > 0)
					{
						city.PopulationAge20M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge21M > 0)
					{
						city.PopulationAge21M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge23M > 0)
					{
						city.PopulationAge23M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge23M > 0)
					{
						city.PopulationAge23M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge24M > 0)
					{
						city.PopulationAge24M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge25M > 0)
					{
						city.PopulationAge25M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge26M > 0)
					{
						city.PopulationAge26M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge27M > 0)
					{
						city.PopulationAge27M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge28M > 0)
					{
						city.PopulationAge28M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge29M > 0)
					{
						city.PopulationAge29M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge30M > 0)
					{
						city.PopulationAge30M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge31M > 0)
					{
						city.PopulationAge31M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge32M > 0)
					{
						city.PopulationAge32M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge33M > 0)
					{
						city.PopulationAge33M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge34M > 0)
					{
						city.PopulationAge34M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge35M > 0)
					{
						city.PopulationAge35M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge36M > 0)
					{
						city.PopulationAge36M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge37M > 0)
					{
						city.PopulationAge37M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge38M > 0)
					{
						city.PopulationAge38M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge39M > 0)
					{
						city.PopulationAge39M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge40M > 0)
					{
						city.PopulationAge40M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge41M > 0)
					{
						city.PopulationAge41M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge42M > 0)
					{
						city.PopulationAge42M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge43M > 0)
					{
						city.PopulationAge43M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge44M > 0)
					{
						city.PopulationAge44M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
					if(city.PopulationAge45M > 0)
					{
						city.PopulationAge45M--;
						totalRecruitsNeeded--;
						if (totalRecruitsNeeded == 0)
							break;
					}
				}
                cityInventory.GenerateNewCharacterData();
            }

            city.MobilizationInProgress = false;
			Mobilization.Instance.mobilizationButton.image.sprite = Mobilization.Instance.inactiveButtonSprite;
        }
    }
}