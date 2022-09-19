using UnityEngine;

[CreateAssetMenu(fileName = "Axe", menuName = "ScriptableObjects/Equipments/Weapons/Axe")]
public class Axe : HandEquipment
{
    public override TargetPattern BasicAttackPattern => TargetPattern.FrontFirst;
    public override int Range => 3;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Axe;
}
