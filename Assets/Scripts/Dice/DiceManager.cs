using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public List<DiceData> diceDeck;

    private int maxInDeck;
    private int newID = 0;


    public void AddDice_Type(DiceType diceType)
    {
        DiceData newDice = new DiceData(diceType);
        newDice.ID = newID;
        newID++;
        diceDeck.Add(newDice); 
    }

    public void RemoveDice(DiceData diceData)
    {
        if (diceDeck.Contains(diceData))
        {
            diceDeck.Remove(diceData);
            Debug.Log(diceData.ID + " has been removed from the deck.");
        }
        else
        {
            Debug.Log(diceData.diceType.ToString() + " is not in the deck.");
        }
    }


    public void RemoveDiceByID(int diceID)
    {
        DiceData diceToRemove = FindDiceByID(diceID);
        RemoveDice(diceToRemove);
    }

    public DiceData FindDiceByID(int diceID)
    {
        return diceDeck.Find(dice => dice.ID == diceID);
    }
}
