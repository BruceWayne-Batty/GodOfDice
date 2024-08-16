using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GearShowcase : MonoBehaviour
{
    public int gearID; // The ID of the gear to display
    public GearData gearData;



    //Component of the panel
    public Image gearImage;              // Image of the gear
    public TextMeshProUGUI gearNameText; // Name of the gear
    public TextMeshProUGUI gearInfo;     // Description of the gear


    public GearDatabase gearDatabase;    // GearDatabase of the game
    public string imagesFolderPath = "Assets/Images/GearImages/"; // Path to the folder where images are stored



    public void AssignGear(GearData PickedGear)
    {
        gearData = PickedGear;
    }

    public void DisplayGear(GearData gearToShow)
    {
        // Assign Gear ID
        gearID = gearToShow.ID;
        Debug.Log(gearToShow.ID + gearToShow.Description);
        if (gearToShow != null)
        {
            // Update the gear name
            gearNameText.text = gearToShow.gearName;
            gearInfo.text = gearToShow.Description;

            // Load and update the gear image
            string imagePath = $"{imagesFolderPath}{gearID}.png";
            Sprite gearSprite = LoadSprite(imagePath);
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