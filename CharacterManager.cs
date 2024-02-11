using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
	public List<CharacterData> characters = new List<CharacterData>();
	public CityManager cityManager;

	public GameObject GetCharacterByID(int characterID)
	{
		foreach (CharacterData character in characters)
		{
			if (character.characterID == characterID)
			{
				return character.gameObject;
			}
		}
		return null;
	}
}
