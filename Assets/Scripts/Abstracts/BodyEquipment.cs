using UnityEngine;

public abstract class BodyEquipment : Equipment
{
    [SerializeField] protected Element defensiveElement;

    public override EquipmentType Type => EquipmentType.Chest;
}
