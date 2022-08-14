using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "ScriptableObjects/Equipments/Shield")]
public class Shield : HandEquipment
{
    public Shield(EquipmentType equipmentType) : base(equipmentType){}

    public override TargetPattern BasicAttackPattern => TargetPattern.None;
    public override int Range => 0;
    public override TargetTeam TargetTeam => TargetTeam.None;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Shield;
}
