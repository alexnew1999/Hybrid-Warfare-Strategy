using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterHoverInfoSlots : MonoBehaviour
{
    public GameObject infoPanel; // Ссылка на всплывающее окно
	public TextMeshProUGUI characterNameText;
	public TextMeshProUGUI characterHealthText;
	public TextMeshProUGUI characterDamageText;
	public TextMeshProUGUI characterMPText;
	public TextMeshProUGUI characterAPText;
	public TextMeshProUGUI characterOwnerText;
	public TextMeshProUGUI characterCoverText;
	public Image characterImage;
	public Image characterWeapon;
	public Image characterAmmo;
	public Image characterHelmet;
	public Image characterVest;
	public Image characterShirt;
	public GameObject characterWeaponGO;
	public GameObject characterAmmoGO;
	public GameObject characterHelmetGO;
	public GameObject characterVestGO;
	public GameObject characterShirtGO;
	
	public void Start()
	{
		characterWeaponGO.SetActive(false);
		characterAmmoGO.SetActive(false);
		characterHelmetGO.SetActive(false);
		characterVestGO.SetActive(false);
		characterShirtGO.SetActive(false);
	}
}
