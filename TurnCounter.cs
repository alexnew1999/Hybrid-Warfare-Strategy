using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnCounter : MonoBehaviour
{
    public TextMeshProUGUI turnCounterText; // Ссылка на текстовый элемент для отображения количества ходов
	public TextMeshProUGUI turnOwnerText;
    public int turnCount = 1; // Начальное количество ходов
	public EndTurnConfirmation endTurnConfirmation;
	
	private void Start()
    {
        UpdateTurnCounter();
    }

    public void NextTurn()
    {
        turnCount++;
        UpdateTurnCounter();
    }

    public void UpdateTurnCounter()
    {
        // Обновление текста с текущим количеством ходов
        turnCounterText.text = "Current Turn: " + turnCount;
		turnOwnerText.text = "Current Player: Player" + endTurnConfirmation.ownerPlayerID;
    }
	
	public void NextPlayer()
    {
        UpdateTurnCounter();
    }
}
