using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{

    //Store Dice Data. For Normal Faces, using corresponding faces. For Unnormal Faces, use int number greater than 20 to represent
    private int[] diceFaces;
    private int faceCount;

    //Path to Images Storage
    public string imagesFolderPath = "Assets/Images/DiceImages/";

    //Components To Control
    public Image diceBack;
    public Image diceFace;

    // Start is called before the first frame update
    public void InitialDice(int totalFaces, int initialShow)
    {
        faceCount = totalFaces;
        diceFaces = new int[faceCount];
        imagesFolderPath = $"{imagesFolderPath}{faceCount}/";
        for (int i = 0; i < faceCount; i++)
        {
            diceFaces[i] = i + 1;
        }
        ShowDice(initialShow);
    }

    public void ShowDice(int face)
    {
        string backImagePath = $"{imagesFolderPath}base.png";
        string faceImagePath = $"{imagesFolderPath}{face}.png";
        Sprite diceBackSprite = UIManager.LoadSprite(backImagePath);
        Sprite diceFaceSprite = UIManager.LoadSprite(faceImagePath);

        //Loadback Image
        if (diceBackSprite != null)
        {
            diceBack.sprite = diceBackSprite;
        }
        else
        {
            Debug.Log("diceBackImage Missing");
        }

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
