using UnityEngine;

public abstract class HandEquipment : Equipment
{
    [SerializeField] protected Element element;
    public HandEquipment(EquipmentType equipmentType) : base(equipmentType)
    {
        type = EquipmentType.Hand;
    }
}