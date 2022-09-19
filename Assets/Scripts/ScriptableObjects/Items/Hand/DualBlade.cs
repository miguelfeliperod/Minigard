using UnityEngine;

[CreateAssetMenu(fileName = "DualBlade", menuName = "ScriptableObjects/Equipments/Weapons/DualBlade")]
public class DualBlade : HandEquipment
{
    public override TargetPattern BasicAttackPattern => TargetPattern.Random;
    public override int Range => 2;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.DualBlade;
}
