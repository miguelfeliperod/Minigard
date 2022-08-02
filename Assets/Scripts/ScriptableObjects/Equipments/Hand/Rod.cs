using UnityEngine;

[CreateAssetMenu(fileName = "Rod", menuName = "ScriptableObjects/Weapons/Rod")]
public class Rod : HandEquipment
{
    public Rod(EquipmentType equipmentType) : base(equipmentType) { }
}
