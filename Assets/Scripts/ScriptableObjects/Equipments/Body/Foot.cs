using UnityEngine;

[CreateAssetMenu(fileName = "Foot", menuName = "ScriptableObjects/Equipments/Foot")]

public class Foot : BodyEquipment
{
    public Foot(EquipmentType equipmentType) : base(equipmentType)
    {
        type = EquipmentType.Foot;
    }
}
