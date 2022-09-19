using UnityEngine;

[CreateAssetMenu(fileName = "Bow", menuName = "ScriptableObjects/Equipments/Weapons/Bow")]
public class Bow : HandEquipment
{
    public override TargetPattern BasicAttackPattern => TargetPattern.BackFirst;
    public override int Range => 1;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Bow;
}
