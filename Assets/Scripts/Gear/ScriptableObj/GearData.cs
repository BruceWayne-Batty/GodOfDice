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
    public int ActionCost; //Action Cost of the gear
    public int EnergySlots; //Number of Energy Slots of the gear
    public GearCategory gearCategory; // Category (Weapon or Shield)
    public float DamageRate; // Damage rate (for weapons)
    public float ShieldRate; // Shield rate (for shields)
    [TextArea] // This attribute makes the description field larger in the inspector
    public string Description; // Description of the gear

    public DiceType companionDice;
}



//The class that will be store in player's gear deck
[System.Serializable]
public class GearDataInGame
{
    public int ID;
    public string gearName;
    public int RareLevel;
    public int ActionCost; 
    public int EnergySlots; 
    public GearCategory gearCategory;
    public float DamageRate;
    public float ShieldRate;
    public string Description;
    public DiceType companionDice;

    // Constructor to initialize GearData from a Gear ScriptableObject
    public GearDataInGame(GearData gearData)
    {
        ID = gearData.ID;
        gearName = gearData.gearName;
        RareLevel = gearData.RareLevel;
        ActionCost = gearData.ActionCost;
        EnergySlots = gearData.EnergySlots;
        gearCategory = gearData.gearCategory;
        DamageRate = gearData.DamageRate;
        ShieldRate = gearData.ShieldRate;
        Description = gearData.Description;
        companionDice = gearData.companionDice;
    }

    // Method to upgrade the gear (example implementation)
    public void UpgradeGear(int additionalRareLevel, float additionalDamageRate, float additionalShieldRate)
    {
        RareLevel += additionalRareLevel;
        DamageRate += additionalDamageRate;
        ShieldRate += additionalShieldRate;
    }
}