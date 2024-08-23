using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DiceType
{
    d4  = 4,
    d6  = 6,
    d8  = 8,
    d10 = 10,
    d12 = 12,
    d20 = 20,
}


[System.Serializable]
public class DiceData
{
    public int ID;
    public DiceType diceType;
    public int[] Faces;


    public DiceData(DiceType type)
    {
        diceType = type;
        Faces = new int[(int)diceType];
        for (int i = 0; i < (int)diceType; i++)
        {
            Faces[i] = i + 1;
        }

    }

    public int GetSize()
    {
        return Faces.Length;
    }
}
