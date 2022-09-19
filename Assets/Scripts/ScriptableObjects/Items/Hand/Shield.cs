using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "ScriptableObjects/Equipments/Shield")]
public class Shield : HandEquipment
{
    public override TargetPattern BasicAttackPattern => TargetPattern.None;
    public override int Range => 0;
    public override TargetTeam TargetTeam => TargetTeam.None;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Shield;
}
