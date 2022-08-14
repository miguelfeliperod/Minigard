using UnityEngine;

[CreateAssetMenu(fileName = "Staff", menuName = "ScriptableObjects/Weapons/Staff")]
public class Staff : HandEquipment
{
    public Staff(EquipmentType equipmentType) : base(equipmentType) { }

    public override TargetPattern BasicAttackPattern => TargetPattern.MiddleFirst;
    public override int Range => 1;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Staff;
}
