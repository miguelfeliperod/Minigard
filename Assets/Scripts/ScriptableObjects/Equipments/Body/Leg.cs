using UnityEngine;

[CreateAssetMenu(fileName = "Leg", menuName = "ScriptableObjects/Equipments/Leg")]
public class Leg : BodyEquipment
{
    public Leg(EquipmentType equipmentType) : base(equipmentType)
    {
        type = EquipmentType.Legs;
    }
}
