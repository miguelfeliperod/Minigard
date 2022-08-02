using UnityEngine;

[CreateAssetMenu(fileName = "Lance", menuName = "ScriptableObjects/Weapons/Lance")]
public class Lance : HandEquipment
{
    public Lance(EquipmentType equipmentType) : base(equipmentType) { }
}
