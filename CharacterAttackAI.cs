using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackAI : MonoBehaviour
{
    public CharacterData characterData;
	public CharacterData enemyCharacterData;
	public Pathfinder pathfinder;
	public void AttackMethod(CharacterData targetCharacterData)
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
												float randomValue = Random.Range(0f, 100f);
												AttackCharacter(characterData, targetCharacterData, randomValue);
												usedAmmo++;
											}
										}
										else
										{
											float randomValue = Random.Range(0f, 100f);
											AttackCharacter(characterData, targetCharacterData, randomValue);
										}
										if(targetCharacterData.aIDefendDrone != null)
										{
											if(targetCharacterData.aIDefendDrone.targetCharacter != null)
											{
												targetCharacterData.aIDefendDrone.targetCharacter = null;
											}
											targetCharacterData.aIDefendDrone.targetCharacter = characterData;
										}

										// Уменьшаем usableAP на 1 после атаки
										characterData.usableAP -= 1;
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
										Debug.Log("Friendly fire!");
									}
								}
								else
								{
									Debug.Log("Not enoug ammo!");
								}
							}
							else
							{
								Debug.Log("No ammo!");
							}
						}
						else
						{
							Debug.Log("This ammo is for another weapon!");
						}
					}
					else
					{
						// Проверяем, совпадают ли ownerPlayerID у атакующего и цели
						if (characterData.ownerPlayerID != targetCharacterData.ownerPlayerID)
						{
							float randomValue = Random.Range(0f, 100f);
							AttackCharacter(characterData, targetCharacterData, randomValue);

							characterData.usableAP -= 1;
									
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
							Debug.Log("Friendly fire!");
						}
					}
				}
                else if(characterData.usableMP >= 1)
				{
					List<Node> pathToEnemy = pathfinder.FindPathAI(characterData.currentNode, targetCharacterData.currentNode, characterData);
					characterData.aIDefendDrone.characterMovementAI.MoveToPositionAI(pathToEnemy, targetCharacterData.currentNode, characterData);
					AttackMethod(targetCharacterData);
				}				
				else
                {
                    Debug.Log("Target is out of attack range!");
					characterData.aIDefendDrone.targetCharacter = null;
                }
            }
        }
	}

    private void AttackCharacter(CharacterData attacker, CharacterData target, float randomValue)
    {
		float totalCoverChance = target.coverChance + target.currentCell.coverChance;
		if (randomValue <= Mathf.Max(attacker.attackChance - totalCoverChance, 0))
		{
			int damage = Mathf.Max(attacker.damage - target.softDef, 0) + Mathf.Max(attacker.heavyDamage - target.hardDef, 0) + attacker.armorpierceDamage;
			target.health -= damage;
			Debug.Log("Target hit! Damage: " + damage);
			if (target.health <= 0)
			{
				target.currentCell.characterData = null;
				target.currentCell.IsOccupied = false;
				Collider2D cellCollider = target.currentCell.GetComponent<Collider2D>();
				cellCollider.enabled = true;
				
				Destroy(target.gameObject);
			}
		}
		else
		{
			// Атака промахнулась
			target.health -= 0; // Нанесение нулевого урона
			Debug.Log("Missed!");
		}
    }

    // Метод для проверки, находится ли цель в диапазоне атаки
    private bool IsWithinAttackRange(CharacterData target)
    {
        // Проверяем, находится ли цель в диапазоне атаки
        return Vector2.Distance(transform.position, target.transform.position) <= characterData.attackRange;
    }
}
