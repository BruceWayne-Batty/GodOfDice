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

    //Controller Of Dice On the Panel
    public DiceController actionCost;

    public Image gearImage;

    //Gear Data 
    public GearManager gearManager;
    private GearDataInGame gearToShow;
    private int deckCount = 0;
    private int currentIndex = 0;

    //Preset Data
    public string imagesFolderPath = "Assets/Images/GearImages/"; // Path to the folder where images are stored


    // Start is called before the first frame update
    public void InitialPanel()
    {
        gearToShow = gearManager.gearsDeck[currentIndex];
        deckCount = 1;
        ShowData();
    }



    /***Function to show gearData on Panel***/
    private void ShowData()
    {
        gearName.text = gearToShow.gearName;
        atkText.text = "x" + gearToShow.DamageRate.ToString();
        defText.text = "x" + gearToShow.ShieldRate.ToString();
        gearDescription.text = gearToShow.Description;
        string imagePath = $"{imagesFolderPath}{gearToShow.ID}.png";
        Sprite gearSprite = LoadSprite(imagePath);
        if (gearSprite != null)
        {
            gearImage.sprite = gearSprite;
        }
        else
        {
            Debug.Log("GearImage Missing");
        }
        actionCost.InitialDice(4,4);

    }

    /***Functions To Load Image***/
    private Sprite LoadSprite(string path)
    {
        // Load the texture from the path
        Texture2D texture = LoadTexture(path);
        if (texture == null) return null;

        // Create a sprite from the texture
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    private Texture2D LoadTexture(string filePath)
    {
        // Load image file data into a byte array
        byte[] fileData;
        if (System.IO.File.Exists(filePath))
        {
            fileData = System.IO.File.ReadAllBytes(filePath);
            Texture2D tex = new Texture2D(2, 2);
            if (tex.LoadImage(fileData))
            {
                return tex;
            }
        }
        return null;
    }

}
