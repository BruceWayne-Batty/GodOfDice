using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePanelController : MonoBehaviour
{

    public RectTransform panelTransform;  // Reference to the panel's transform

    public DiceManager diceManager;
    public GameObject dicePrefab;


    public void InitialPanel()
    {
        foreach (DiceData diceData in diceManager.diceDeck)
        {
            GameObject newDice = Instantiate(dicePrefab, panelTransform);
            DiceController newDiceController = newDice.GetComponent<DiceController>();
            newDiceController.InitialDice(diceData);
        }
    }


    public void UpdatePanel()
    {
        foreach (Transform child in panelTransform)
        {
            Destroy(child.gameObject);
        }
        InitialPanel();
    }


    public void RollAllDices()
    {
        foreach (Transform child in panelTransform)
        {
            child.gameObject.GetComponent<DiceController>().RollDice();
        }
    }


}
