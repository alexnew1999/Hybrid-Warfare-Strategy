using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectedMashineFactoryInfo : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI mashineFactoryNameText;
    public TextMeshProUGUI mashineFactoryOwnerText;
    public Image mashineFactoryImage;
	public Image InvIcon;
	public MashineFactorySelectedData mashineFactorySelectedData;

    private void Start()
    {
		SelectedMashineFactoryInfoSlots infoSlotsScript = FindObjectOfType<SelectedMashineFactoryInfoSlots>();

        if (infoSlotsScript != null)
        {
            infoPanel = infoSlotsScript.infoPanel;
            mashineFactoryNameText = infoSlotsScript.mashineFactoryNameText;
            mashineFactoryOwnerText = infoSlotsScript.mashineFactoryOwnerText;
            mashineFactoryImage = infoSlotsScript.mashineFactoryImage;
			InvIcon = infoSlotsScript.InvIcon;
			mashineFactorySelectedData = infoSlotsScript.mashineFactorySelectedData;
        }
    }

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hitCity = Physics2D.Raycast(mouseWorldPos, Vector2.zero, LayerMask.GetMask("City"));
			if (hitCity.collider != null)
			{
				GameObject hitObject = hitCity.collider.gameObject;
				MashineFactory mashineFactory = hitObject.GetComponent<MashineFactory>();

				if (mashineFactory != null)
				{
					mashineFactorySelectedData.mashineFactory = mashineFactory;
					mashineFactoryOwnerText.text = "OwnerPlayerID: " + mashineFactory.ownerPlayerID;
					
					infoPanel.SetActive(true);
				}
				else if (EventSystem.current.IsPointerOverGameObject())
				{
				
				}
				else
				{
					DeactivateMashineFactoryInfoPanel();
				}
			}
			else if (EventSystem.current.IsPointerOverGameObject())
            {
			
			}
			else
			{
				DeactivateMashineFactoryInfoPanel();
			}
		}
	}

    public void DeactivateMashineFactoryInfoPanel()
    {
        mashineFactoryOwnerText.text = "";
        infoPanel.SetActive(false);
    }
	
	public void ActivateMashineFactoryInfoPanelManually(MashineFactory mashineFactory)
	{
		if (mashineFactory != null)
		{
			mashineFactorySelectedData.mashineFactory = mashineFactory;
			mashineFactoryOwnerText.text = "OwnerPlayerID: " + mashineFactory.ownerPlayerID;

			infoPanel.SetActive(true);
		}
	}
}
