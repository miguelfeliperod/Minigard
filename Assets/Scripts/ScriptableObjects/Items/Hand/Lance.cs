using UnityEngine;

[CreateAssetMenu(fileName = "Lance", menuName = "ScriptableObjects/Equipments/Weapons/Lance")]
public class Lance : HandEquipment
{
    public override TargetPattern BasicAttackPattern => TargetPattern.FrontFirst;
    public override int Range => 4;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Lance;
}
