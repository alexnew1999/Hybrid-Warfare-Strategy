using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRememberer : MonoBehaviour
{
	public int currentTurn;
	public int currentPlayer;
	public TurnCounter turnCounter;
	
	public void RecalculateTurns()
	{
		turnCounter = FindObjectOfType<TurnCounter>();
		if(turnCounter != null)
		{
			turnCounter.turnCount = currentTurn;
			turnCounter.endTurnConfirmation.ownerPlayerID = currentPlayer;
			turnCounter.UpdateTurnCounter();
		}
	}
}
