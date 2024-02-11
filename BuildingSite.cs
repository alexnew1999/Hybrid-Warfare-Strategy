using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSite : MonoBehaviour
{
	public int WoodToBuild;
	public int StoneToBuild;
	public int TurnToBuild;
	public int IronToBuild;
	public string spritePath = "Sprites/Terrain/BuildingSite";
	public CellData cellData;
	public Forge forge;
	public MashineFactory mashineFactory;
	public Mine mine;
	public Farm farm;
	public Trench trench;
	public PreTrench preTrench;
	public int currentCellGlobalID;
	public int GlobalID;
}
