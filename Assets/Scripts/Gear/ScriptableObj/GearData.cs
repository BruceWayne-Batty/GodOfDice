using UnityEngine;

public enum GearCategory
{
    Weapon,
    Shield,
    Special,
}

[CreateAssetMenu(fileName = "NewGearData", menuName = "Gear/GearData")]
public class GearData : ScriptableObject
{
    public int ID;
    public string gearName; // Name of the gear
    public int RareLevel; // Rarity level of the gear
    public GearCategory gearCategory; // Category (Weapon or Shield)
    public float DamageRate; // Damage rate (for weapons)
    public float ShieldRate; // Shield rate (for shields)
    [TextArea] // This attribute makes the description field larger in the inspector
    public string Description; // Description of the gear
}



//The class that will be store in player's gear deck
[System.Serializable]
public class GearDataInGame
{
    public int ID;
    public string gearName;
    public int RareLevel;
    public GearCategory gearCategory;
    public float DamageRate;
    public float ShieldRate;
    public string Description;

    // Constructor to initialize GearData from a Gear ScriptableObject
    public GearDataInGame(GearData gearData)
    {
        ID = gearData.ID;
        gearName = gearData.gearName;
        RareLevel = gearData.RareLevel;
        gearCategory = gearData.gearCategory;
        DamageRate = gearData.DamageRate;
        ShieldRate = gearData.ShieldRate;
        Description = gearData.Description;
    }

    // Method to upgrade the gear (example implementation)
    public void UpgradeGear(int additionalRareLevel, float additionalDamageRate, float additionalShieldRate)
    {
        RareLevel += additionalRareLevel;
        DamageRate += additionalDamageRate;
        ShieldRate += additionalShieldRate;
    }
}