using UnityEngine;

[CreateAssetMenu(fileName = "Chest", menuName = "ScriptableObjects/Equipments/Chest")]
public class Chest : BodyEquipment
{
    public Chest(EquipmentType equipmentType) : base(equipmentType)
    {
        type = EquipmentType.Chest;
    }
}
