using UnityEngine;

public abstract class BodyEquipment : Equipment
{
    [SerializeField] protected Element defensiveElement;

    public BodyEquipment(EquipmentType equipmentType) : base(equipmentType)
    {
    }
}
