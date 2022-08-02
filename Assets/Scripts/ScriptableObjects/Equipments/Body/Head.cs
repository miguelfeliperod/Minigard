using UnityEngine;

[CreateAssetMenu(fileName = "Head", menuName = "ScriptableObjects/Equipments/Head")]
public class Head : BodyEquipment
{
    public Head(EquipmentType equipmentType) : base(equipmentType)
    {
        type = EquipmentType.Head;
    }
}
