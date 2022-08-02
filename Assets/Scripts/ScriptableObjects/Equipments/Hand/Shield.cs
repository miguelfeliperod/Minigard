using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "ScriptableObjects/Equipments/Shield")]
public class Shield : HandEquipment
{
    public Shield(EquipmentType equipmentType) : base(equipmentType)
    {
    }
}
