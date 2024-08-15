using UnityEngine;

public enum GearCategory
{
    Weapon,
    Shield,
    Special,
}

[CreateAssetMenu(fileName = "NewGear", menuName = "Gear")]
public class Gear : ScriptableObject
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