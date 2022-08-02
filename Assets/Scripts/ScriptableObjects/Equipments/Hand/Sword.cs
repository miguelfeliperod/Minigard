using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "ScriptableObjects/Weapons/Sword")]
public class Sword : HandEquipment
{
    public Sword(EquipmentType equipmentType) : base(equipmentType) { }
}
