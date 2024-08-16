using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    public List<GearData> PickGear(int RareLevel, int numOfDesiredGear)
    {
        // Find all gears that match the given RareLevel
        List<GearData> filteredGears = allGears.Where(gear => gear.RareLevel == RareLevel).ToList();

        // Shuffle the list to randomize the selection
        filteredGears = filteredGears.OrderBy(gear => Random.value).ToList();

        // Take the desired number of gears (or all if there are fewer than desired)
        List<GearData> selectedGears = filteredGears.Take(numOfDesiredGear).ToList();

        return selectedGears;
    }

    public List<int> PickGearID(int RareLevel, int numOfDesiredGear)
    {
        // Find all gears that match the given RareLevel
        List<GearData> filteredGears = allGears.Where(gear => gear.RareLevel == RareLevel).ToList();

        // Shuffle the list to randomize the selection
        filteredGears = filteredGears.OrderBy(gear => Random.value).ToList();

        // Take the desired number of gears (or all if there are fewer than desired)
        List<int> selectedGearIDs = filteredGears.Take(numOfDesiredGear).Select(gear => gear.ID).ToList();

        return selectedGearIDs;
    }


}
