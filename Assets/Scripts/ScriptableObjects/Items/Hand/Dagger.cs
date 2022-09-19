using UnityEngine;

[CreateAssetMenu(fileName = "Dagger", menuName = "ScriptableObjects/Equipments/Weapons/Dagger")]
public class Dagger : HandEquipment
{
    public override TargetPattern BasicAttackPattern => TargetPattern.FrontFirst;
    public override int Range => 1;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Dagger;
}
