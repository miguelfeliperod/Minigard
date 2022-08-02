using UnityEngine;

[CreateAssetMenu(fileName = "Staff", menuName = "ScriptableObjects/Weapons/Staff")]
public class Staff : HandEquipment
{
    public Staff(EquipmentType equipmentType) : base(equipmentType) { }
}
