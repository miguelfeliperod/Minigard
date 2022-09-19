using UnityEngine;

[CreateAssetMenu(fileName = "Staff", menuName = "ScriptableObjects/Equipments/Weapons/Staff")]
public class Staff : HandEquipment
{
    public override TargetPattern BasicAttackPattern => TargetPattern.MiddleFirst;
    public override int Range => 1;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Staff;
}
