using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/***This is the parent class for all dice controller, main functions of dice controlling is implemented in this class***/
public class DiceController : MonoBehaviour
{

    /***Now a specific class DiceData is used for store dice data, this script is only used for controlling UI components and showing dice***/
    //Store Dice Data. For Normal Faces, using corresponding faces. For Unnormal Faces, use int number greater than 20 to represent
    //private int[] diceFaces;
    //private int faceCount;


    //Dice to show
    public DiceData diceToShow;
    public int currentFace;



    //Path to Images Storage
    public string imagesFolderPath = "Assets/Images/DiceImages/";

    //Components To Control

    public Image diceBack;
    public Image diceFace;


    //Controlling Parameters
    public float rollDuration = 1f; // How long the dice should roll.
    public float rollSpeed = 0.1f; // How fast the dice faces change.


  


    // To Initial Dice
    public void InitialDice(DiceData diceData)
    {
        diceToShow = diceData;
        int size = diceToShow.GetSize();
        InitialDice(size, size);
    }
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

        //Set and Show Initial Face
        currentFace = initialShow;
        ShowDice(currentFace);

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
            Debug.Log("diceFaceImage Missing" + face);
        }

    }

    public void RollDice()
    {
        StartCoroutine(RollDiceRoutine());
    }


    private IEnumerator RollDiceRoutine()
    {
        float elapsedTime = 0f; ;
        while (elapsedTime < rollDuration)
        {
            int randomFaceIndex = Random.Range(0, diceToShow.GetSize());
            ShowDice(randomFaceIndex+1);

            elapsedTime += rollSpeed;
            yield return new WaitForSeconds(rollSpeed);
        }
        int finalIndex = Random.Range(0, diceToShow.GetSize());
        ShowDice(finalIndex+1);
        currentFace = finalIndex + 1;
    }

}
