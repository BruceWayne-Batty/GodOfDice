using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class SelectionController : MonoBehaviour
{
    public TextMeshProUGUI title;     //Title of the panel
    public GameObject gearCardPrefab; // Prefab of the gear card
    public Transform panelTransform;  // Reference to the panel's transform
    public GearDatabase gearDatabase; // Reference to the GearDatabase





    public void StartGameSelection()
    {
        title.text = "Starting Gear";
        PopulatePanel(gearDatabase.PickGear(0,2));



    }

    public void PopulatePanel(List<GearData> pickedGearData)
    {
        // Clear existing gear cards
        foreach (Transform child in panelTransform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate a card for each gear ID
        foreach (GearData gearData in pickedGearData)
        {
            if (gearData != null)
            {
                GameObject gearCard = Instantiate(gearCardPrefab, panelTransform);
                GearShowcase gearShowcase = gearCard.GetComponent<GearShowcase>();
                if (gearShowcase != null)
                {
                    gearShowcase.DisplayGear(gearData);
                }
            }
        }
    }
}
