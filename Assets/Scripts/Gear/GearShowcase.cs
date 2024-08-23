using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GearShowcase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int gearID; // The ID of the gear to display
    
    
    //The GearData to show of this gearCard
    public GearData gearData;

    //Controllers and Manager
    public GearManager gearManager;
    public UIManager uiManager;
    public DiceManager diceManager;


    //Component of the panel
    public Image gearImage;              // Image of the gear
    public TextMeshProUGUI gearNameText; // Name of the gear
    public TextMeshProUGUI gearInfo;     // Description of the gear


    //public GearDatabase gearDatabase;    // GearDatabase of the game
    public string imagesFolderPath = "Assets/Images/GearImages/"; // Path to the folder where images are stored


    //Set to ture is in the first selection scene
    public bool isFirstSelction;


    //For controlling the Hoving effect
    public Vector3 hoverOffset = new Vector3(0, 10, 0); // The amount to move the card up when hovered
    public float hoverDuration = 0.2f;                  // Duration of the floating animation
    private Vector3 originalPosition;                   // Store the original position of the card



    void Start()
    {
        // Store the original position of the card
        originalPosition = transform.localPosition;


        // Get the gearManager
        gearManager = FindObjectOfType<GearManager>();
        uiManager = FindObjectOfType<UIManager>();
        diceManager = FindObjectOfType<DiceManager>();
    }

    public void AssignGear(GearData PickedGear)
    {
        gearData = PickedGear;
    }

    public void DisplayGear(GearData gearToShow)
    {
        // Assign GearData
        AssignGear(gearToShow);
        gearID = gearData.ID;
        Debug.Log(gearData.ID + gearData.Description);
        if (gearData != null)
        {
            // Update the gear name
            gearNameText.text = gearData.gearName;
            gearInfo.text = gearData.Description;

            // Load and update the gear image
            string imagePath = $"{imagesFolderPath}{gearID}.png";
            Sprite gearSprite = UIManager.LoadSprite(imagePath);
            if (gearSprite != null)
            {
                gearImage.sprite = gearSprite;
            }
            else
            {
                Debug.LogError($"Image not found at path: {imagePath}");
            }
        }
        else
        {
            Debug.LogError($"Gear with ID {gearID} not found in the database.");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Pointer Entered");

        // Move the card up when the mouse hovers over it
        LeanTween.moveLocal(gameObject, originalPosition + hoverOffset, hoverDuration).setEaseInOutQuad();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Move the card back to its original position when the mouse leaves
        LeanTween.moveLocal(gameObject, originalPosition, hoverDuration).setEaseInOutQuad();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Call the AddGear method from the gearManager when the card is clicked
        if (gearManager != null)
        {
            gearManager.AddGear(gearData);
            diceManager.AddDice_Type(gearData.companionDice);
        }
        if (isFirstSelction)
        {
            uiManager.TransitionToState(SceneState.MainGame);
        }
        
    }
}