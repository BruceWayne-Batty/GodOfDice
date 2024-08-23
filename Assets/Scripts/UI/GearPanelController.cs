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
    //public DiceController actionCostDice;

    public Image gearImage;
    public Image costDiceBackImage;
    public Image costDiceFaceImage;

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
    public string GearFolderPath = "Assets/Images/GearImages/"; // Path to the folder where gear images are stored
    public string DiceFolderPath = "Assets/Images/DiceImages/4/";   // Path to the folder where dice images are stored 


    // Start is called before the first frame update
    public void UpdatePanel()
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
        string GearimagePath = $"{GearFolderPath}{currentID}.png";
        string DiceImageBackPath = $"{DiceFolderPath}base.png";
        string DiceImageFacePath = $"{DiceFolderPath}{actionCost}.png";
        Sprite gearSprite = UIManager.LoadSprite(GearimagePath);
        Sprite DiceBackSprite = UIManager.LoadSprite(DiceImageBackPath);
        Sprite DiceFaceSprite = UIManager.LoadSprite(DiceImageFacePath);

        //Show GearImage
        if (gearSprite != null)
        {
            gearImage.sprite = gearSprite;
        }
        else
        {
            Debug.Log("GearImage Missing");
        }

        costDiceBackImage.sprite = DiceBackSprite;
        costDiceFaceImage.sprite = DiceFaceSprite;



        //Show CostDice
        //actionCostDice.InitialDice(4, actionCost); //use dice to show the action cost, so dice controller is called here

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
