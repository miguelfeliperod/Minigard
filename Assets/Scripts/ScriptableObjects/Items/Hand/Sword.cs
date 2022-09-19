using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "ScriptableObjects/Equipments/Weapons/Sword")]
public class Sword : HandEquipment
{
    public override TargetPattern BasicAttackPattern => TargetPattern.FrontFirst;
    public override int Range => 1;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;

    public override WeaponType WeaponType => WeaponType.Sword;
}
