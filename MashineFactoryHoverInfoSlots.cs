using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MashineFactoryHoverInfoSlots : MonoBehaviour
{
    public GameObject infoPanel;
	public TextMeshProUGUI mashineFactoryNameText;
    public TextMeshProUGUI mashineFactoryOwnerText;
    public Image mashineFactoryImage;
	private Camera mainCamera;
	private MashineFactory mashineFactory;
}