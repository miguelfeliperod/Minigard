using UnityEngine;

[CreateAssetMenu(fileName = "Grimory", menuName = "ScriptableObjects/Equipments/Weapons/Grimory")]
public class Grimory : HandEquipment
{
    public override TargetPattern BasicAttackPattern => TargetPattern.MiddleFirst;
    public override int Range => 1;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Grimory;
}
