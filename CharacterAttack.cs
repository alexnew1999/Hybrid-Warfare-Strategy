using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterAttack : MonoBehaviour
{
    public float bulletSpeed = 5f;
	public float bulletLifetime = 2f;
	public float flashDuration = 1f;
    public Color flashColor = new Color(1f, 0f, 0f, 1f);
    private CharacterData characterData;
	public CharacterData enemyCharacterData;
	public Pathfinder pathfinder;
	public CharacterSelection characterSelection;
	public TextMeshProUGUI DebugInfoPanel;
	private GameObject DebugInfoPanelObj;

    private void Start()
    {
        characterData = GetComponent<CharacterData>();
		CharacterMovement characterMovement = GetComponent<CharacterMovement>();
		DebugInfoPanel = characterMovement.DebugInfoPanel;
		DebugInfoPanelObj = characterMovement.DebugInfoPanelObj;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && characterData != null)
        {
            // Получаем позицию мыши в мировых координатах
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Пускаем луч к точке нажатия мыши и получаем информацию о столкновении
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;
                CharacterData targetCharacterData = hitObject.GetComponent<CharacterData>();
				SmallCity targetSmallCity = hitObject.GetComponent<SmallCity>();
				
				if (targetCharacterData != null)
				{
					if (characterData.usableAP > 0)
					{
						AttackMethod(hitObject, targetCharacterData);
					}
					else
					{
						if (!DebugInfoPanelObj.activeSelf)
						{
							DebugInfoPanelObj.SetActive(true);
						}

						DebugInfoPanel.text = "Not enough Attack Points!";
					}
				}
				else if (targetSmallCity != null && targetSmallCity.cityInventory.HasEnemyCharacters(characterData.ownerPlayerID, out enemyCharacterData))
				{
					if (characterData.usableAP > 0)
					{
						targetCharacterData = enemyCharacterData;
						AttackMethod(hitObject, targetCharacterData);
					}
					else
					{
						if (!DebugInfoPanelObj.activeSelf)
						{
							DebugInfoPanelObj.SetActive(true);
						}

						DebugInfoPanel.text = "Not enough Attack Points!";
					}
				}
            }
        }
    }
	
	public void AttackMethod(GameObject hitObject, CharacterData targetCharacterData)
	{
        if (targetCharacterData != null && targetCharacterData != characterData)
        {
            // Проверяем, есть ли достаточно usableAP для атаки
            if (characterData.usableAP >= 1)
            {
                // Проверяем, находится ли цель в диапазоне атаки
                if (IsWithinAttackRange(targetCharacterData))
                {
					if (characterData.characterInventory.weaponSlot.itemGameObject != null)
					{
						ItemObject equippedWeapon = characterData.characterInventory.weaponSlot.itemGameObject.GetComponent<ItemObject>();
						if (characterData.AmmoType == equippedWeapon.AmmoType)
						{
							if (characterData.characterInventory.ammoSlot.itemGameObject != null)
							{
								ItemObject equippedAmmo = characterData.characterInventory.ammoSlot.itemGameObject.GetComponent<ItemObject>();
								if (equippedAmmo.quantity >= characterData.ammoUsage)
								{
									// Проверяем, совпадают ли ownerPlayerID у атакующего и цели
									if (characterData.ownerPlayerID != targetCharacterData.ownerPlayerID)
									{
										int usedAmmo = 0;
										if(characterData.attackRange > 1)
										{
											while (characterData.ammoUsage > usedAmmo)
											{
												float randomValue = Random.Range(0f, 101f);
												AttackCharacter(characterData, targetCharacterData, randomValue);
												usedAmmo++;
											}
										}
										else
										{
											float randomValue = Random.Range(0f, 101f);
											AttackCharacterMelee(characterData, targetCharacterData, randomValue);
										}

										characterData.usableAP -= 1;
										if(characterData.usableAP == 0)
										{
											characterSelection.FirearmGO.SetActive(false);
											characterSelection.HandAttackGO.SetActive(false);
											characterSelection.MeleeAttackGO.SetActive(false);
										}
										equippedAmmo.quantity -= characterData.ammoUsage;
										
										if (equippedAmmo.quantity == 0)
										{
											GameObject ItemToDelete = characterData.characterInventory.ammoSlot.itemGameObject;
											equippedAmmo = null;
											characterData.characterInventory.ammoSlot.isOccupied = false;
											Destroy(ItemToDelete);
										}
												
										// После завершения движения, найдем скрипт SelectedCharacterInfo
										SelectedCharacterInfo characterInfoScript = FindObjectOfType<SelectedCharacterInfo>();

										// Проверяем, что мы нашли скрипт
										if (characterInfoScript != null)
										{
											// Обновляем информацию о персонаже
											characterInfoScript.UpdateCharacterInfo(characterData);
										}
												
										// После завершения движения, найдем скрипт CharacterHoverInfo
										CharacterHoverInfo characterInfoHoverScript = FindObjectOfType<CharacterHoverInfo>();

										// Проверяем, что мы нашли скрипт
										if (characterInfoHoverScript != null)
										{
											// Обновляем информацию о персонаже
											characterInfoHoverScript.UpdateHoverInfo();
										}
									}
									else
									{
										if (!DebugInfoPanelObj.activeSelf)
										{
											DebugInfoPanelObj.SetActive(true);
										}

										DebugInfoPanel.text = "Friendly fire!";
									}
								}
								else
								{
									if (!DebugInfoPanelObj.activeSelf)
									{
										DebugInfoPanelObj.SetActive(true);
									}

									DebugInfoPanel.text = "Not enoug ammo!";
								}
							}
							else
							{	
								if (!DebugInfoPanelObj.activeSelf)
								{
									DebugInfoPanelObj.SetActive(true);
								}

								DebugInfoPanel.text = "No ammo!";
							}
						}
						else
						{
							if (!DebugInfoPanelObj.activeSelf)
							{
								DebugInfoPanelObj.SetActive(true);
							}

							DebugInfoPanel.text = "This ammo is for another weapon!";
						}
					}
					else
					{
						if (characterData.ownerPlayerID != targetCharacterData.ownerPlayerID)
						{
							float randomValue = Random.Range(0f, 101f);
							AttackCharacterMelee(characterData, targetCharacterData, randomValue);
							characterData.usableAP -= 1;
							if(characterData.usableAP == 0)
							{
								characterSelection.FirearmGO.SetActive(false);
								characterSelection.HandAttackGO.SetActive(false);
								characterSelection.MeleeAttackGO.SetActive(false);
							}
							
							if (targetCharacterData.InCityInventory)
							{
								ItemObject characterWeapon = characterData.characterInventory.weaponSlot.itemGameObject.GetComponent<ItemObject>();
								if (characterWeapon != null)
								{
									if (characterWeapon.itemName == "Maxim Gun")
									{
										SmallCity smallCity = targetCharacterData.characterSlot.cityInventory.smallCity;
										MashineFactory mashineFactory = targetCharacterData.characterSlot.mashineFactory;
										Forge forge = targetCharacterData.currentCell.forge;
										if (smallCity != null)
										{
											smallCity.Population -= Random.Range(0, 101);
										}
										else if (mashineFactory != null)
										{
											mashineFactory.Population -= Random.Range(0, 101);
										}
										else if (forge != null)
										{
											forge.Population -= Random.Range(0, 101);
										}
									}									
								}
							}
							if (targetCharacterData.currentCell.trench != null)
							{
								ItemObject characterWeapon = characterData.characterInventory.weaponSlot.itemGameObject.GetComponent<ItemObject>();
								if (characterWeapon != null)
								{
									if (characterWeapon.itemName == "Mortar 82-BM-37")
									{
										int ChanceToHit = Random.Range(0, 101);
										int ChanceToDestroy = Random.Range(0, 11);
										if(ChanceToDestroy > ChanceToHit)
										{
											Destroy(targetCharacterData.currentCell.Building);
											targetCharacterData.currentCell.node.baseCost = 1;
											targetCharacterData.currentCell.trench = null;
											targetCharacterData.currentCell.preTrench = null;
											targetCharacterData.currentCell.terrainType = TerrainType.None;
										}
									}									
								}
							}

							SelectedCharacterInfo characterInfoScript = FindObjectOfType<SelectedCharacterInfo>();
							if (characterInfoScript != null)
							{
								characterInfoScript.UpdateCharacterInfo(characterData);
							}
							CharacterHoverInfo characterInfoHoverScript = FindObjectOfType<CharacterHoverInfo>();
							if (characterInfoHoverScript != null)
							{
								characterInfoHoverScript.UpdateHoverInfo();
							}
						}
						else
						{
							if (!DebugInfoPanelObj.activeSelf)
							{
								DebugInfoPanelObj.SetActive(true);
							}

							DebugInfoPanel.text = "Friendly fire!";
						}
					}
				}
                else
                {
					if (!DebugInfoPanelObj.activeSelf)
					{
						DebugInfoPanelObj.SetActive(true);
					}

					DebugInfoPanel.text = "Target is out of attack range!";
                }
            }
        }
	}

    private void AttackCharacter(CharacterData attacker, CharacterData target, float randomValue)
    {
		ItemObject attackerWeapon = attacker.characterInventory.weaponSlot.itemGameObject.GetComponent<ItemObject>();
		ItemObject attackerAmmo = attacker.characterInventory.ammoSlot.itemGameObject.GetComponent<ItemObject>();
		ItemObject targetHelmet = target.characterInventory.helmetSlot.itemGameObject.GetComponent<ItemObject>();
		ItemObject targetShirt = target.characterInventory.shirtSlot.itemGameObject.GetComponent<ItemObject>();
		ItemObject targetVest = target.characterInventory.vestSlot.itemGameObject.GetComponent<ItemObject>();
		float totalCoverChance = 0f;
		if(targetHelmet != null)
		{
			totalCoverChance += targetHelmet.coverChance;
		}
		if(targetShirt != null)
		{
			totalCoverChance += targetShirt.coverChance;
		}
		if(targetVest != null)
		{
			totalCoverChance += targetVest.coverChance;
		}
		target.coverChance += target.currentCell.coverChance;
		if (randomValue <= Mathf.Max(attackerWeapon.attackChance - totalCoverChance, 0)) 
		{
			//if (attacker.attackRange > 1)
			//{
				//Collider2D targetCollider = target.thisCharacter.GetComponent<Collider2D>();
				//Vector2 randomPoint = GetRandomPointInCollider(targetCollider);
				//GameObject bullet = Instantiate(bulletPrefab, attacker.transform.position, Quaternion.identity);
				//Vector2 direction = (randomPoint - (Vector2)attacker.transform.position).normalized;
				//while (bullet != null && Vector2.Distance(bullet.transform.position, randomPoint) > 0.1f)
				//{
					//bullet.transform.position += (Vector3)direction * bulletSpeed * Time.deltaTime;
				//}
				//Destroy(bullet);
			//}
			SpriteRenderer characterSpriteRenderer = target.thisCharacter.GetComponent<SpriteRenderer>();
			Debug.Log("characterSpriteRenderer: " + characterSpriteRenderer);
			FlashEnemyCharacter(characterSpriteRenderer);
			int softDefSum = 0;
			int hardDefSum = 0;
			int damageSum = attackerWeapon.damage;
			int heavyDamageSum = attackerWeapon.heavyDamage;
			int armorpierceDamageSum = attackerWeapon.armorpierceDamage;
			if(targetHelmet != null)
			{
				softDefSum += targetHelmet.softDef;
				hardDefSum += targetHelmet.hardDef;
			}
			if(targetShirt != null)
			{
				softDefSum += targetShirt.softDef;
				hardDefSum += targetShirt.hardDef;
			}
			if(targetVest != null)
			{
				softDefSum += targetVest.softDef;
				hardDefSum += targetVest.hardDef;
			}
			if(attackerAmmo != null)
			{
				damageSum += attackerAmmo.damage;
				heavyDamageSum += attackerAmmo.heavyDamage;
				armorpierceDamageSum += attackerAmmo.armorpierceDamage;
			}			
			int damage = Mathf.Max(damageSum - softDefSum, 0) + Mathf.Max(heavyDamageSum - hardDefSum, 0) + armorpierceDamageSum;
			target.health -= damage;
			if (!DebugInfoPanelObj.activeSelf)
			{
				DebugInfoPanelObj.SetActive(true);
			}

			DebugInfoPanel.text = "Target hit! Damage: " + damage;
			if (target.health <= 0)
			{
				target.currentCell.characterData = null;
				target.currentCell.IsOccupied = false;
				Collider2D cellCollider = target.currentCell.GetComponent<Collider2D>();
				cellCollider.enabled = true;
				
				Destroy(target.gameObject);
				characterSelection.ResetAllCellColors();
				characterSelection.RemoveAllTargetMarkers();
				pathfinder.FindAllPossibleMoves(attacker.currentCell.node, attacker, out List<Node> possibleMoves);
				pathfinder.FindEnemiesInRange(attacker.currentCell.node, attacker);
				DebugInfoPanel.text = "Target hit! Damage: " + damage + ". Enemy man down!";
			}
			if (target.InCityInventory)
			{
				if (attackerWeapon != null)
				{
					if (attackerWeapon.itemName == "Maxim Gun")
					{
						SmallCity smallCity = target.characterSlot.cityInventory.smallCity;
						MashineFactory mashineFactory = target.characterSlot.mashineFactory;
						Forge forge = target.currentCell.forge;
						if (smallCity != null)
						{
							smallCity.Population -= Random.Range(0, 101);
						}
						else if (mashineFactory != null)
						{
							mashineFactory.Population -= Random.Range(0, 101);
						}
						else if (forge != null)
						{
							forge.Population -= Random.Range(0, 101);
						}
					}									
				}
			}
			if (target.currentCell.trench != null)
			{
				if (attackerWeapon != null)
				{
					if (attackerWeapon.itemName == "Mortar 82-BM-37")
					{
						int ChanceToHit = Random.Range(0, 101);
						int ChanceToDestroy = Random.Range(0, 11);
						if(ChanceToDestroy > ChanceToHit)
						{
							Destroy(target.currentCell.Building);
							target.currentCell.node.baseCost = 1;
							target.currentCell.trench = null;
							target.currentCell.preTrench = null;
							target.currentCell.terrainType = TerrainType.None;
						}
					}									
				}
			}
			CharacterHoverInfo characterHoverInfo = target.thisCharacter.GetComponent<CharacterHoverInfo>();
			characterHoverInfo.CharacterInfoDeactivate();
		}
		else
		{
			target.health -= 0;
			if (!DebugInfoPanelObj.activeSelf)
			{
				DebugInfoPanelObj.SetActive(true);
			}

			DebugInfoPanel.text = "Missed!";
		}
    }

    private void AttackCharacterMelee(CharacterData attacker, CharacterData target, float randomValue)
    {
		float attackChance = 0f;
		ItemObject attackerWeapon = attacker.characterInventory.weaponSlot.itemGameObject.GetComponent<ItemObject>();
		if(attackerWeapon != null)
		{
			attackChance = attackerWeapon.attackChance;
		}
		else if(attackerWeapon == null)
		{
			attackChance = attacker.attackChance;
		}
		if (randomValue <= attackChance)
		{
			//if (attacker.attackRange > 1)
			//{
				//Collider2D targetCollider = target.thisCharacter.GetComponent<Collider2D>();
				//Vector2 randomPoint = GetRandomPointInCollider(targetCollider);
				//GameObject bullet = Instantiate(bulletPrefab, attacker.transform.position, Quaternion.identity);
				//Vector2 direction = (randomPoint - (Vector2)attacker.transform.position).normalized;
				//while (bullet != null && Vector2.Distance(bullet.transform.position, randomPoint) > 0.1f)
				//{
					//bullet.transform.position += (Vector3)direction * bulletSpeed * Time.deltaTime;
				//}
				//Destroy(bullet);
			//}
			SpriteRenderer characterSpriteRenderer = target.thisCharacter.GetComponent<SpriteRenderer>();
			Debug.Log("characterSpriteRenderer: " + characterSpriteRenderer);
			FlashEnemyCharacter(characterSpriteRenderer);
			
			ItemObject targetHelmet = target.characterInventory.helmetSlot.itemGameObject.GetComponent<ItemObject>();
			ItemObject targetShirt = target.characterInventory.shirtSlot.itemGameObject.GetComponent<ItemObject>();
			ItemObject targetVest = target.characterInventory.vestSlot.itemGameObject.GetComponent<ItemObject>();
			
			int softDefSum = 0;
			int hardDefSum = 0;
			int damageSum = attackerWeapon.damage;
			int heavyDamageSum = attackerWeapon.heavyDamage;
			int armorpierceDamageSum = attackerWeapon.armorpierceDamage;
			if(targetHelmet != null)
			{
				softDefSum += targetHelmet.softDef;
				hardDefSum += targetHelmet.hardDef;
			}
			if(targetShirt != null)
			{
				softDefSum += targetShirt.softDef;
				hardDefSum += targetShirt.hardDef;
			}
			if(targetVest != null)
			{
				softDefSum += targetVest.softDef;
				hardDefSum += targetVest.hardDef;
			}			
			int damage = Mathf.Max(damageSum - softDefSum, 0) + Mathf.Max(heavyDamageSum - hardDefSum, 0) + armorpierceDamageSum;
			target.health -= damage;
			if (!DebugInfoPanelObj.activeSelf)
			{
				DebugInfoPanelObj.SetActive(true);
			}

			DebugInfoPanel.text = "Target hit! Damage: " + damage;
			if (target.health <= 0)
			{
				target.currentCell.characterData = null;
				target.currentCell.IsOccupied = false;
				Collider2D cellCollider = target.currentCell.GetComponent<Collider2D>();
				cellCollider.enabled = true;
				
				Destroy(target.gameObject);
				characterSelection.ResetAllCellColors();
				characterSelection.RemoveAllTargetMarkers();
				pathfinder.FindAllPossibleMoves(attacker.currentCell.node, attacker, out List<Node> possibleMoves);
				pathfinder.FindEnemiesInRange(attacker.currentCell.node, attacker);
				DebugInfoPanel.text = "Target hit! Damage: " + damage + ". Enemy man down!";
			}
			CharacterHoverInfo characterHoverInfo = target.thisCharacter.GetComponent<CharacterHoverInfo>();
			characterHoverInfo.CharacterInfoDeactivate();
		}
		else
		{
			target.health -= 0;
			if (!DebugInfoPanelObj.activeSelf)
			{
				DebugInfoPanelObj.SetActive(true);
			}

			DebugInfoPanel.text = "Missed!";
		}
    }

    private bool IsWithinAttackRange(CharacterData target)
    {
        return Vector2.Distance(transform.position, target.transform.position) <= characterData.attackRange;
    }
    
	private Vector2 GetRandomPointInCollider(Collider2D collider)
    {
        // Получаем случайные координаты в пределах размеров коллайдера
        float randomX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        float randomY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);

        // Возвращаем случайную точку
        return new Vector2(randomX, randomY);
    }
	
	private IEnumerator FlashEnemyCharacter(SpriteRenderer characterSpriteRenderer)
    {
		Debug.Log("1");
        float elapsedTime = 0f;

        while (elapsedTime < flashDuration)
        {
            characterSpriteRenderer.color = flashColor;
            yield return new WaitForSeconds(0.1f);
            characterSpriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            elapsedTime += 0.2f;
        }

        characterSpriteRenderer.color = Color.white;
    }
}