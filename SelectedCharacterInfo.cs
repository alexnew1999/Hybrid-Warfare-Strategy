using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectedCharacterInfo : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI characterHealthText;
    public TextMeshProUGUI characterDamageText;
    public TextMeshProUGUI characterMPText;
    public TextMeshProUGUI characterAPText;
	public TextMeshProUGUI attackChance;
    public TextMeshProUGUI range;
    public Image characterImage;
	public Image InvIcon;
	public Image MineIcon;
	public Image BuildIcon;
	public CharacterSelectedData characterSelectedData;

	//private void Update()
	//{
		//if (Input.GetMouseButtonDown(0))
		//{
			//Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//RaycastHit2D hitCharacter = Physics2D.Raycast(mouseWorldPos, Vector2.zero, LayerMask.GetMask("Units"));

			//if (hitCharacter.collider != null)
			//{
				//GameObject hitObject = hitCharacter.collider.gameObject;
				//CharacterData characterData = hitObject.GetComponent<CharacterData>();

				//if (characterData != null)
				//{
					//characterSelectedData.characterData = characterData;
					// Отображаем информацию о персонаже, если он выбран
					//characterNameText.text = "Name: " + characterData.characterName;
					//characterHealthText.text = "Health: " + characterData.health;
					//characterDamageText.text = "Damage: " + characterData.damage;
					//characterMPText.text = "MP: " + characterData.usableMP;
					//characterAPText.text = "AP: " + characterData.usableAP;
					//characterImage.sprite = characterData.characterImage;
					//characterImage.gameObject.SetActive(true);
					//infoPanel.SetActive(true);
				//}
				//else if (EventSystem.current.IsPointerOverGameObject())
				//{
				
				//}
				//else
				//{
					// Если объект без CharacterData, отключаем информационную панель
					//DeactivateInfoPanel();
				//}
			//}
			//else if (EventSystem.current.IsPointerOverGameObject())
            //{
				
			//}
			//else
			//{
				//DeactivateInfoPanel();
			//}
		//}
	//}
	
	public void CharacterInfoFromInventory (CharacterData characterData)
	{
		characterNameText.text = "Name: " + characterData.characterName;
		characterHealthText.text = "Health: " + characterData.health;
		characterDamageText.text = "Damage: " + characterData.damage;
		characterMPText.text = "MP: " + characterData.usableMP;
		characterAPText.text = "AP: " + characterData.usableAP;
		attackChance.text = "AT Chance: " + characterData.attackChance;
		range.text = "Range: " + characterData.attackRange;
		characterImage.sprite = characterData.characterImage;
		characterImage.gameObject.SetActive(true);
		infoPanel.SetActive(true);
	}
	
	private bool IsPointerOverUI()
    {
        // Проверка, находится ли указатель мыши (или касание) над объектом UI
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void DeactivateInfoPanel()
    {
        // Очищаем текстовые поля и скрываем изображение персонажа
        characterNameText.text = "";
        characterHealthText.text = "";
        characterDamageText.text = "";
        characterMPText.text = "";
        characterAPText.text = "";
		attackChance.text = "";
		range.text = "";
        characterImage.gameObject.SetActive(false);
        infoPanel.SetActive(false);
    }
	
	public void UpdateCharacterInfo(CharacterData characterData)
    {
        // Обновляем информацию о персонаже
        characterNameText.text = "Name: " + characterData.characterName;
        characterHealthText.text = "Health: " + characterData.health;
        characterDamageText.text = "Damage: " + characterData.damage;
        characterMPText.text = "MP: " + characterData.usableMP;
        characterAPText.text = "AP: " + characterData.usableAP;
		attackChance.text = "AT Chance: " + characterData.attackChance;
		range.text = "Range: " + characterData.attackRange;
        characterImage.sprite = characterData.characterImage;
    }
	
	public void UpdateCharacterUsableAP(CharacterData characterData)
    {
        characterAPText.text = "AP: " + characterData.usableAP;
    }
}