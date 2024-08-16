using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    public List<GearDataInGame> gearsDeck;


    private int maxInDeck;

    // Add a gear to the deck
    public void AddGear(GearData gearData)
    {
        GearDataInGame newGearDataInGame = new GearDataInGame(gearData);
        gearsDeck.Add(newGearDataInGame);
        Debug.Log(newGearDataInGame.gearName + " has been added to the deck.");
    }

    // Remove a gear from the deck

    public void RemoveGear(GearDataInGame gearData)
    {
        if (gearsDeck.Contains(gearData))
        {
            gearsDeck.Remove(gearData);
            Debug.Log(gearData.gearName + " has been removed from the deck.");
        }
        else
        {
            Debug.Log(gearData.gearName + " is not in the deck.");
        }
    }


    public void RemoveGearByID(int gearID)
    {
        GearDataInGame gearToRemove = FindGearByID(gearID);
        RemoveGear(gearToRemove);
    }



    // Get the number of gears in the deck
    public int GetDeckSize()
    {
        return gearsDeck.Count;
    }

    // Find a gear by ID
    public GearDataInGame FindGearByID(int id)
    {
        return gearsDeck.Find(gear => gear.ID == id);
    }
}
