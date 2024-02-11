using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilizedSpriteFixer : MonoBehaviour
{
    public Sprite characterImage;
	
    public void UpdateCharacterSprite(CharacterData characterData)
    {
        if (characterData != null && characterImage != null)
        {
            characterData.characterImage = characterImage;
        }
    }
}