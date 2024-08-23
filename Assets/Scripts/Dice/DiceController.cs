using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DiceController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    //Dice UI Data
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    /***Now a specific class DiceData is used for store dice data, this script is only used for controlling UI components and showing dice***/
    //Store Dice Data. For Normal Faces, using corresponding faces. For Unnormal Faces, use int number greater than 20 to represent
    //private int[] diceFaces;
    //private int faceCount;

    //Path to Images Storage
    public string imagesFolderPath = "Assets/Images/DiceImages/";

    //Components To Control
    public Image diceBack;
    public Image diceFace;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    /***Drag Functions***/
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // Make the block semi-transparent during drag
        canvasGroup.blocksRaycasts = false; // Allow the block to pass through other UI elements
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GetCanvasScaleFactor();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }

    private float GetCanvasScaleFactor()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        return canvas.scaleFactor;
    }


    // To Initial Dice Manually
    public void InitialDice(int totalFaces, int initialShow)
    {
        //Initial Image Folder Path
        imagesFolderPath = $"{imagesFolderPath}{totalFaces}/";

        string backImagePath = $"{imagesFolderPath}base.png";
        Sprite diceBackSprite = UIManager.LoadSprite(backImagePath);


        //Loadback Image
        if (diceBackSprite != null)
        {
            diceBack.sprite = diceBackSprite;
        }
        else
        {
            Debug.Log("diceBackImage Missing");
        }
        ShowDice(initialShow);
    }

    public void ShowDice(int face)
    {
        string faceImagePath = $"{imagesFolderPath}{face}.png";
        Sprite diceFaceSprite = UIManager.LoadSprite(faceImagePath);
        //LoadFace Image
        if (diceFaceSprite != null)
        {
            diceFace.sprite = diceFaceSprite;
        }
        else
        {
            Debug.Log("diceFaceImage Missing");
        }

    }
}
