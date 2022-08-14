using UnityEngine;

public abstract class HandEquipment : Equipment
{
    public Element element;
    public StatusAilment statusAilment;
    public abstract TargetPattern BasicAttackPattern { get; }
    public abstract int Range { get; }
    public abstract int MaxQuantity { get; }
    public abstract TargetTeam TargetTeam{ get; }
    public abstract WeaponType WeaponType{ get; }
    public HandEquipment(EquipmentType equipmentType) : base(equipmentType)
    {
        type = EquipmentType.Hand;
    }
}