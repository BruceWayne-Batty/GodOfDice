using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GearPanelController : MonoBehaviour
{
    //UI Components On the Panel

    public TextMeshProUGUI atkText;
    public TextMeshProUGUI defText;
    public TextMeshProUGUI gearName;
    public TextMeshProUGUI gearDescription;

    public GameObject energySlotsPrefab;

    //Panel Info
    public RectTransform panelTransform;

    //Controller Of ActionDice On the Panel
    public DiceController actionCostDice;

    public Image gearImage;

    //Gear Data 
    public GearManager gearManager;
    private GearDataInGame gearToShow;

    private float atkRate;
    private float defRate;
    private int energySlotsCount;
    private int actionCost;
    private int deckCount = 0;
    private int currentIndex = 0;
    private int currentID; //Store the Current ID 


    //Preset Data
    public string imagesFolderPath = "Assets/Images/GearImages/"; // Path to the folder where images are stored


    // Start is called before the first frame update
    public void InitialPanel()
    {
        UpdateGear();
        ShowData();
    }



    /***Function to show gearData on Panel***/
    private void ShowData()
    {
        //Show GearInfo
        gearName.text = gearToShow.gearName;
        atkText.text = "x" + atkRate.ToString();
        defText.text = "x" + defRate.ToString();
        gearDescription.text = gearToShow.Description;

        //Load GearImage
        string imagePath = $"{imagesFolderPath}{currentID}.png";
        Sprite gearSprite = UIManager.LoadSprite(imagePath);

        //Show GearImage
        if (gearSprite != null)
        {
            gearImage.sprite = gearSprite;
        }
        else
        {
            Debug.Log("GearImage Missing");
        }


        //Show CostDice
        actionCostDice.InitialDice(4, actionCost); //use dice to show the action cost, so dicecontroller is called here

        //Instantiate Energy Slots
        for (int i = 0; i < energySlotsCount; i++)
        {
            GameObject gearCard = Instantiate(energySlotsPrefab, panelTransform);
        }

    }

    private void UpdateGear()
    {
        gearToShow = gearManager.gearsDeck[currentIndex];
        atkRate = gearToShow.DamageRate;
        defRate = gearToShow.ShieldRate;
        energySlotsCount = gearToShow.EnergySlots;
        actionCost = gearToShow.ActionCost;
        deckCount = gearManager.GetDeckSize();
        currentID = gearToShow.ID;
    }


}
