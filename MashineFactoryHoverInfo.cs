using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MashineFactoryHoverInfo : MonoBehaviour
{
    public GameObject infoPanel;
	public TextMeshProUGUI mashineFactoryNameText;
    public TextMeshProUGUI mashineFactoryOwnerText;
    public Image mashineFactoryImage;
	private Camera mainCamera;
	private MashineFactory mashineFactory;

    private void Start()
    {
		MashineFactoryHoverInfoSlots infoSlotsScript = FindObjectOfType<MashineFactoryHoverInfoSlots>();

        if (infoSlotsScript != null)
        {
            infoPanel = infoSlotsScript.infoPanel;
            mashineFactoryNameText = infoSlotsScript.mashineFactoryNameText;
            mashineFactoryOwnerText = infoSlotsScript.mashineFactoryOwnerText;
            mashineFactoryImage = infoSlotsScript.mashineFactoryImage;
        }
		mainCamera = Camera.main;
		mashineFactory = GetComponent<MashineFactory>();
    }

	void OnMouseEnter()
	{
		if (mashineFactory != null && !mashineFactory.isSelected)
		{
			mashineFactoryOwnerText.text = "OwnerPlayerID: " + mashineFactory.ownerPlayerID;
		
			infoPanel.SetActive(true);
		}
	}

	void OnMouseExit()
	{
		mashineFactoryOwnerText.text = "";

		infoPanel.SetActive(false);
	}
	
	private MashineFactory GetMashineFactoryUnderMouse()
	{
		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

		if (hit.collider != null)
		{
			GameObject hitObject = hit.collider.gameObject;
			MashineFactory mashineFactory = hitObject.GetComponent<MashineFactory>();
			return mashineFactory;
		}

		return null;
	}
	
	public void MashineFactoryInfoActivate()
	{
		if (mashineFactory != null && !mashineFactory.isSelected)
		{
			mashineFactoryOwnerText.text = "OwnerPlayerID: " + mashineFactory.ownerPlayerID;
		
			infoPanel.SetActive(true);
		}
	}

	public void MashineFactoryInfoDeactivate()
	{
		mashineFactoryOwnerText.text = "";

		infoPanel.SetActive(false);
	}
}
