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
    public RectTransform panelTransform;  // Reference to the panel's transform
    public GearDatabase gearDatabase; // Reference to the GearDatabase
    public float cardSpacing = 10f; // Spacing between the cards

    public int numberOfCards;


    public void StartGameSelection()
    {
        title.text = "Starting Gear";
        PopulatePanel(gearDatabase.PickGear(0,3));



    }

    public void PopulatePanel(List<GearData> pickedGearData)
    {
        // Clear existing gear cards
        foreach (Transform child in panelTransform)
        {
            Destroy(child.gameObject);
        }

        // Get the Number of Cards
        numberOfCards = pickedGearData.Count;

        // Get the width of the panel
        float panelWidth = panelTransform.rect.width;

        // Get the width of the card
        float cardWidth = gearCardPrefab.GetComponent<RectTransform>().rect.width;

        // Calculate the total width occupied by the cards including spacing
        float totalCardsWidth = (cardWidth * numberOfCards) + (cardSpacing * (numberOfCards - 1));

        // Calculate the starting position so that the cards are centered
        float startX = (cardWidth - totalCardsWidth) / 2f;



        // Instantiate a card for each gear ID
        int tempConut = 0;
        foreach (GearData gearData in pickedGearData)
        {
            if (gearData != null)
            {   
                //Instantiate the card
                GameObject gearCard = Instantiate(gearCardPrefab, panelTransform);

                //calculate the postion and replace it
                // Calculate the card's position
                float posX = startX + (cardWidth + cardSpacing) * tempConut;
                gearCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, 0);

                GearShowcase gearShowcase = gearCard.GetComponent<GearShowcase>();
                if (gearShowcase != null)
                {
                    gearShowcase.DisplayGear(gearData);
                }
            }
            tempConut++;
        }
    }
}
