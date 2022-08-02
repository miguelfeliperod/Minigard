using UnityEngine;

[CreateAssetMenu(fileName = "GreatSword", menuName = "ScriptableObjects/Weapons/GreatSword")]
public class GreatSword : HandEquipment
{
    public GreatSword(EquipmentType equipmentType) : base(equipmentType) { }
}
