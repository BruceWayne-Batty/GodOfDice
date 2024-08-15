using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GearDatabase", menuName = "Gear/Gear Database")]
public class GearDatabase : ScriptableObject
{
    public List<GearData> allGears;

    // Method to get gear by ID
    public GearData GetGearByID(int id)
    {
        return allGears.Find(gear => gear.ID == id);
    }

    // Method to get gear by name
    public GearData GetGearByName(string gearName)
    {
        return allGears.Find(gear => gear.gearName == gearName);
    }
}
